using HotelManagement.Models;
using System.Collections.Generic;

namespace HotelManagement.Interfaces
{
    public interface IBranchService
    {
        List<Branch> GetAllBranches();
        Branch GetBranchById(int id);
        void SaveBranch(Branch branch);
        void DeleteBranch(int id);
    }
}