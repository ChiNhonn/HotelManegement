using ClosedXML.Excel;
using HotelManagement.CustomControls;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Services
{
    internal class CustomerServices : ICustomerServices
    {
        private readonly IServiceProvider _serviceProvider;

        public CustomerServices(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<bool> Add(Customer customer)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    using (var context = scope.ServiceProvider.GetRequiredService<IMyDbContext>())
                    {
                        await context.Customers.AddAsync(customer);
                        int result = await context.SaveChangesAsync();
                        return result>0;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(Customer customer)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    using (var context = scope.ServiceProvider.GetRequiredService<IMyDbContext>())
                    {
                        context.Customers.Update(customer);
                        int result = await context.SaveChangesAsync();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> SoftDelete(int Id)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    using (var context = scope.ServiceProvider.GetRequiredService<IMyDbContext>())
                    {
                        var customerToSoftDelete = await context.Customers.FindAsync(Id);

                        if (customerToSoftDelete != null)
                        {
                            customerToSoftDelete.SoftDelete = DateTime.Now;
                            context.Customers.Update(customerToSoftDelete);
                            int result = await context.SaveChangesAsync();
                            return result > 0;
                        }
                        return false; 
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExportCustomersToExcel(List<Customer> customers, string filePath)
        {
            try
            {
                using (var workcustomer = new XLWorkbook())
                {
                    var worksheet = workcustomer.Worksheets.Add("DanhSachKhachHang");
                    worksheet.Cell(1, 1).Value = "Mã Khách Hàng";
                    worksheet.Cell(1, 2).Value = "Tên Khách Hàng";
                    worksheet.Cell(1, 3).Value = "Ngày Sinh";
                    worksheet.Cell(1, 4).Value = "Giới Tính";
                    worksheet.Cell(1, 5).Value = "Xã";
                    worksheet.Cell(1, 6).Value = "Huyện";
                    worksheet.Cell(1, 7).Value = "Tỉnh";
                    worksheet.Cell(1, 8).Value = "Quốc Tịch";
                    worksheet.Cell(1, 9).Value = "Trạng Thái";
                    worksheet.Cell(1, 10).Value = "VIP";

                    var headerRow = worksheet.Range(1, 1, 1, 10);
                    headerRow.Style.Font.Bold = true;
                    headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;
                    headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    int currentRow = 2;
                    foreach (var customer in customers)
                    {
                        worksheet.Cell(currentRow, 1).Value = customer.Id;
                        worksheet.Cell(currentRow, 2).Value = customer.FullName;

                        // Định dạng ngày sinh để Excel không bị lỗi hiển thị
                        worksheet.Cell(currentRow, 3).Value = customer.BirthDay.ToString("dd/MM/yyyy");

                        // Hiển thị chữ thay vì số 1/0
                        worksheet.Cell(currentRow, 4).Value = customer.Gender == 1 ? "Nam" : "Nữ";
                        worksheet.Cell(currentRow, 5).Value = customer.Xa;
                        worksheet.Cell(currentRow, 6).Value = customer.Huyen;
                        worksheet.Cell(currentRow, 7).Value = customer.Tinh;
                        worksheet.Cell(currentRow, 8).Value = customer.Country;
                        worksheet.Cell(currentRow, 9).Value = customer.Status;
                        worksheet.Cell(currentRow, 10).Value = customer.Vip == 1 ? "Có" : "Không";

                        currentRow++;
                    }
                    worksheet.Columns().AdjustToContents();

                    var tableRange = worksheet.Range(1, 1, currentRow - 1, 10);
                    tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // LƯU FILE
                    workcustomer.SaveAs(filePath);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
