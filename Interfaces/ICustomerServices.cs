using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Interfaces
{
    internal interface ICustomerServices
    {
        Task<bool> Add(Customer customer);
        Task<bool> Update(Customer customer);
        Task<bool> SoftDelete(int Id);
        bool ExportCustomersToExcel(List<Customer> customers, string filePath);
    }
}
