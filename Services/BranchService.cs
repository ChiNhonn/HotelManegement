using HotelManagement.Interfaces;
using HotelManagement.Models;
using System;
using System.Collections.Generic;

namespace HotelManagement.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public List<Branch> GetAllBranches()
        {
            return _branchRepository.GetAllBranches();
        }

        public Branch GetBranchById(int id)
        {
            return _branchRepository.GetBranchById(id);
        }

        public void SaveBranch(Branch branch)
        {
            // Kiểm tra và bắt lỗi dữ liệu đầu vào (Validation)
            if (string.IsNullOrWhiteSpace(branch.Phone))
                throw new ArgumentException("Số điện thoại không được để trống.");

            if (string.IsNullOrWhiteSpace(branch.StreetName))
                throw new ArgumentException("Tên đường không được để trống.");

            if (string.IsNullOrWhiteSpace(branch.City))
                throw new ArgumentException("Thành phố không được để trống.");

            // Điều hướng Add hoặc Update dựa vào ID
            if (branch.Id == 0)
            {
                _branchRepository.Add(branch);
            }
            else
            {
                _branchRepository.Update(branch);
            }
        }

        public void DeleteBranch(int id)
        {
            _branchRepository.Delete(id);
        }
    }
}