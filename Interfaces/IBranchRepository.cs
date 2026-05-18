using HotelManagement.Models;
using System.Collections.Generic;

namespace HotelManagement.Interfaces
{
    public interface IBranchRepository
    {
        List<Branch> GetAllBranches();
        Branch GetBranchById(int id);
        void Add(Branch branch);
        void Update(Branch branch);
        void Delete(int id); // Xóa mềm (Soft Delete)
    }
}