using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagement.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly HotelDbContext _context;

        public BranchRepository(HotelDbContext context)
        {
            _context = context;
        }

        // Chỉ lấy các chi nhánh chưa bị xóa mềm
        private IQueryable<Branch> ActiveBranches => _context.Branches.Where(b => b.SoftDelete == null);

        public List<Branch> GetAllBranches()
        {
            return ActiveBranches.AsNoTracking().ToList();
        }

        public Branch GetBranchById(int id)
        {
            return ActiveBranches.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Branch branch)
        {
            branch.CreateAt = DateTime.Now;
            _context.Branches.Add(branch);
            _context.SaveChanges();
        }

        public void Update(Branch branch)
        {
            var existing = _context.Branches.FirstOrDefault(b => b.Id == branch.Id);
            if (existing != null)
            {
                existing.HouseNumber = branch.HouseNumber;
                existing.StreetName = branch.StreetName;
                existing.Commune = branch.Commune;
                existing.City = branch.City;
                existing.Country = branch.Country;
                existing.Phone = branch.Phone;
                existing.UpdateAt = DateTime.Now;

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var existing = _context.Branches.FirstOrDefault(b => b.Id == id);
            if (existing != null)
            {
                existing.SoftDelete = DateTime.Now; // Gán ngày xóa mềm thay vì xóa hẳn khỏi DB
                _context.SaveChanges();
            }
        }
    }
}