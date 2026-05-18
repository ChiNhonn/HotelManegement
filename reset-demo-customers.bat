@echo off
REM Dat bien moi truong roi chay app mot lan — reset khach/don/hoa don truoc man hinh dang nhap.
REM Dong app sau khi mo neu chi muon reset (du lieu da luu trong DB).
set HOTEL_RESET_CUSTOMERS=1
dotnet run --project "%~dp0HotelManagement.csproj"
set HOTEL_RESET_CUSTOMERS=
