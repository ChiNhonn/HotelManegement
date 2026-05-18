using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using HotelManagement.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagement.Services;

/// <summary>Lắng nghe POST JSON để ghi nhận tiền CK đến (tích hợp VietQR/bank notify qua script hoặc middleware).</summary>
internal static class BankTransferInboundWebhookHost
{
    private const string Prefix = "http://127.0.0.1:7788/";

    private static readonly JsonSerializerOptions JsonOpts = new()
    {
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    private static HttpListener? _listener;
    private static CancellationTokenSource? _cts;

    private sealed class PayloadDto
    {
        public decimal amount { get; set; }
        public string? content { get; set; }
    }

    public static void TryStart(IServiceScopeFactory scopes)
    {
        Stop();
        try
        {
            var listener = new HttpListener();
            listener.Prefixes.Add(Prefix);
            listener.Start();
            _listener = listener;
            _cts = new CancellationTokenSource();
            var ct = _cts.Token;
            _ = Task.Run(() => ListenLoop(listener, scopes, ct), ct);
        }
        catch
        {
            // Port đã dùng hoặc thiếu quyền urlacl — app vẫn chạy, chỉ không có webhook.
        }
    }

    public static void Stop()
    {
        try { _cts?.Cancel(); } catch { /* ignore */ }
        _cts = null;

        try
        {
            _listener?.Stop();
            _listener?.Close();
        }
        catch { /* ignore */ }

        _listener = null;
    }

    private static async Task ListenLoop(HttpListener listener, IServiceScopeFactory scopes, CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            HttpListenerContext ctx;
            try
            {
                ctx = await listener.GetContextAsync().ConfigureAwait(false);
            }
            catch when (ct.IsCancellationRequested || !listener.IsListening)
            {
                break;
            }
            catch (HttpListenerException)
            {
                break;
            }
            catch
            {
                try { await Task.Delay(300, ct).ConfigureAwait(false); } catch { /* cancelled */ }
                continue;
            }

            _ = Task.Run(() => HandleRequest(ctx, scopes), CancellationToken.None);
        }
    }

    private static void HandleRequest(HttpListenerContext ctx, IServiceScopeFactory scopes)
    {
        try
        {
            if (ctx.Request.HttpMethod == "OPTIONS")
            {
                ctx.Response.StatusCode = 204;
                ctx.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                ctx.Response.Headers.Add("Access-Control-Allow-Methods", "POST, OPTIONS");
                ctx.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
                ctx.Response.OutputStream.Close();
                return;
            }

            if (ctx.Request.HttpMethod != "POST")
            {
                WriteJson(ctx.Response, 405, """{"error":"method_not_allowed"}""");
                return;
            }

            using var ms = new MemoryStream();
            ctx.Request.InputStream.CopyTo(ms);
            var json = Encoding.UTF8.GetString(ms.ToArray());

            PayloadDto? payload;
            try
            {
                payload = JsonSerializer.Deserialize<PayloadDto>(json, JsonOpts);
            }
            catch
            {
                WriteJson(ctx.Response, 400, """{"error":"invalid_json"}""");
                return;
            }

            if (payload == null || payload.amount <= 0)
            {
                WriteJson(ctx.Response, 400, """{"error":"invalid_payload"}""");
                return;
            }

            int matched;
            using (var scope = scopes.CreateScope())
            {
                var svc = scope.ServiceProvider.GetRequiredService<IServiceModuleService>();
                svc.RegisterInboundBankTransfer(payload.amount, payload.content ?? "");
                matched = svc.ProcessPendingBankTransferMatches();
            }

            WriteJson(ctx.Response, 200,
                $$"""{"ok":true,"registered":true,"matched":{{matched}}}""");
        }
        catch
        {
            try
            {
                WriteJson(ctx.Response, 500, """{"error":"server"}""");
            }
            catch { /* ignore */ }
        }
    }

    private static void WriteJson(HttpListenerResponse resp, int status, string body)
    {
        resp.StatusCode = status;
        resp.ContentType = "application/json; charset=utf-8";
        resp.Headers.Add("Access-Control-Allow-Origin", "*");
        resp.Headers.Add("Access-Control-Allow-Methods", "POST, OPTIONS");
        resp.Headers.Add("Access-Control-Allow-Headers", "Content-Type");

        var buf = Encoding.UTF8.GetBytes(body);
        resp.ContentLength64 = buf.Length;
        resp.OutputStream.Write(buf, 0, buf.Length);
        resp.OutputStream.Close();
    }
}
