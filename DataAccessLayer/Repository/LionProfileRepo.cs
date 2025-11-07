using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class LionProfileRepo
    {
        private readonly Su25lionDbContext _context;

        public LionProfileRepo(Su25lionDbContext context)
        {
            _context = context;
        }

        //get All with pagination 
        
        public async Task<(List<LionProfile> items, int totalCount)> GetAllWithSupplierAsync(int pageIndex, int pageSize)
        {
            var query = _context.LionProfiles
                .Include(e=>e.LionType)
                .AsQueryable();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(e => e.LionProfileId)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<LionProfile?> GetByIdAsync(int id)
        {
            return await _context.LionProfiles.Include(x => x.LionType).FirstOrDefaultAsync(x => x.LionProfileId == id);
        }

        public async Task<LionProfile> CreateAsync(LionProfile entity)
        {
            _context.LionProfiles.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(LionProfile entity)
        {
            _context.LionProfiles.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.LionProfiles.FirstOrDefaultAsync(x => x.LionProfileId == id);
            if (entity != null)
            {
                _context.LionProfiles.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        //search ra r pagination
        public async Task<(List<LionProfile> items, int totalCount)> SearchAsync(int pageIndex, int pageSize, double? weight, string? lionTypeName)
        {
            var baseQuery = _context.LionProfiles.Include(x => x.LionType).AsQueryable();

            if (weight.HasValue && !string.IsNullOrWhiteSpace(lionTypeName))
            {
                var name = lionTypeName.Trim();
                baseQuery = baseQuery.Where(x => x.Weight == weight.Value || (x.LionType.LionTypeName != null && x.LionType.LionTypeName.Contains(name)));
            }
            else if (weight.HasValue)
            {
                baseQuery = baseQuery.Where(x => x.Weight == weight.Value);
            }
            else if (!string.IsNullOrWhiteSpace(lionTypeName))
            {
                var name = lionTypeName.Trim();
                baseQuery = baseQuery.Where(x => x.LionType.LionTypeName != null && x.LionType.LionTypeName.Contains(name));
            }

            var totalCount = await baseQuery.CountAsync();
            var items = await baseQuery
                .OrderByDescending(x => x.LionProfileId)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (items, totalCount);
        }

        //Tra ra full bang LionType dropdown
        public async Task<List<LionType>> GetLionTypesAsync()
        {
            return await _context.LionTypes.OrderBy(x => x.LionTypeName).ToListAsync();
        }
    }
}

