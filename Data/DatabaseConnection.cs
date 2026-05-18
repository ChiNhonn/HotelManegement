using Microsoft.Data.SqlClient;

namespace HotelManagement.Data;

/// <summary>
/// Chuỗi kết nối SQL Server — ưu tiên biến môi trường, sau đó thử các instance phổ biến trên máy dev.
/// </summary>
public static class DatabaseConnection
{
    private const string DatabaseName = "HotelManagement";

    /// <summary>Các máy chủ thử khi không có biến môi trường — gồm cả &lt;Tên máy&gt;\SQLEXPRESS (khớp SSMS).</summary>
    private static readonly string[] CandidateServers =
    [
        @".\SQLEXPRESS",
        $@"{Environment.MachineName}\SQLEXPRESS",
        @"localhost\SQLEXPRESS",
        @"(local)\SQLEXPRESS",
        @"(localdb)\MSSQLLocalDB",
        @"localhost",
        @".",
    ];

    public static string ResolveConnectionString()
    {
        var fromEnv = Environment.GetEnvironmentVariable("HotelManagement_ConnectionString");
        if (!string.IsNullOrWhiteSpace(fromEnv))
            return fromEnv.Trim();

        var failures = new List<string>();

        foreach (var server in CandidateServers)
        {
            var connectionString = Build(server, probe: true);
            if (TryOpen(connectionString, out var error))
                return Build(server, probe: false);

            failures.Add($"{server}: {error}");
        }

        throw new InvalidOperationException(
            "Không kết nối được SQL Server. Đã thử:\n• " + string.Join("\n• ", failures) +
            "\n\nBật dịch vụ SQL Server (SQLEXPRESS hoặc MSSQLSERVER) trong services.msc, " +
            "hoặc đặt biến môi trường HotelManagement_ConnectionString với chuỗi kết nối đúng.");
    }

    public static string Build(string server, bool probe = false)
    {
        var timeout = probe ? 15 : 120;
        var database = probe ? "master" : DatabaseName;
        return
            $"Server={server};Database={database};Trusted_Connection=True;TrustServerCertificate=True;" +
            $"Connect Timeout={timeout};Encrypt=False;MultipleActiveResultSets=True;";
    }

    private static bool TryOpen(string connectionString, out string error)
    {
        try
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            error = string.Empty;
            return true;
        }
        catch (Exception ex)
        {
            error = ex.Message;
            return false;
        }
    }
}
