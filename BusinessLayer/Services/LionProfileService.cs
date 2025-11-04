using BusinessLayer.DTOs;
using DataAccessLayer;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class LionProfileService
    {
        private readonly LionProfileRepo _repo;

        public LionProfileService(LionProfileRepo repo)
        {
            _repo = repo;
        }

        //getall pagination
        public async Task<LionProfileListResponse> GetAllWithSupplierPagingAsync(int pageIndex, int pageSize = 3)
        {
            // Gọi repository để lấy data từ database
            var (items, totalCount) = await _repo.GetAllWithSupplierAsync(pageIndex, pageSize);

            // Map từ Entity sang DTO (Business Logic)
            var lionlist = items.Select(e => new LionProfileDTO
            {
             LionProfileId=e.LionProfileId,
             LionTypeId=e.LionTypeId,
             LionName=e.LionName,
             Weight=e.Weight,
             Characteristics=e.Characteristics,
             Warning=e.Warning,
             ModifiedDate=e.ModifiedDate,
             LionType=e.LionType,
            }).ToList();

            // Tính toán paging
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return new LionProfileListResponse
            {
                LionProfileList = lionlist,
                CurrentPage = pageIndex,
                TotalPages = totalPages,
                TotalRecords = totalCount,
                PageSize = pageSize
            };
        }

        public async Task<LionProfileDTO> CreateAsync(LionProfileDTO request)
        {
            ValidateRequest(request);

            var entity = new DataAccessLayer.Models.LionProfile
            {
                LionTypeId = request.LionTypeId,
                LionName = request.LionName!,
                Weight = request.Weight,
                Characteristics = request.Characteristics!,
                Warning = request.Warning!,
                ModifiedDate = DateTime.UtcNow
            };
            var created = await _repo.CreateAsync(entity);
            return MapToDto(created);
        }

        //Search = Id để sp cho method Edit
        public async Task<LionProfileDTO?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task UpdateAsync(LionProfileDTO request)
        {
            ValidateRequest(request);
            var existing = await _repo.GetByIdAsync(request.LionProfileId);
            if (existing == null) throw new Exception("Not found");
            existing.LionTypeId = request.LionTypeId;
            existing.LionName = request.LionName!;
            existing.Weight = request.Weight;
            existing.Characteristics = request.Characteristics!;
            existing.Warning = request.Warning!;
            existing.ModifiedDate = DateTime.UtcNow;
            await _repo.UpdateAsync(existing);
        }

        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);

        //Search bình thường 
        public async Task<LionProfileListResponse> SearchPagingAsync(int pageIndex, int pageSize, double? weight, string? lionTypeName)
        {
            var (items, totalCount) = await _repo.SearchAsync(pageIndex, pageSize, weight, lionTypeName);
            var list = items.Select(MapToDto).ToList();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            return new LionProfileListResponse
            {
                LionProfileList = list,
                CurrentPage = pageIndex,
                TotalPages = totalPages,
                TotalRecords = totalCount,
                PageSize = pageSize
            };
        }

        //tạo dropdown liontype cho Create và Edit 
        public Task<List<DataAccessLayer.Models.LionType>> GetLionTypesAsync() => _repo.GetLionTypesAsync();

        //Regex xài chung
        private static void ValidateRequest(LionProfileDTO request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.LionTypeId <= 0) throw new Exception("LionTypeId is required");
            if (string.IsNullOrWhiteSpace(request.LionName) || request.LionName!.Length < 4)
                throw new Exception("LionName must be at least 4 characters");

            // Each word starts with a capital letter and no special # @ & ( )
            var invalidChars = new[] { '#', '@', '&', '(', ')' };
            if (request.LionName!.IndexOfAny(invalidChars) >= 0)
                throw new Exception("LionName contains invalid characters");

            var words = request.LionName!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (words.Any(w => !char.IsUpper(w[0])))
                throw new Exception("Each word in LionName must start with a capital letter");

            if (request.Weight <= 30)
                throw new Exception("Weight must be greater than 30");

            if (string.IsNullOrWhiteSpace(request.Characteristics) || string.IsNullOrWhiteSpace(request.Warning))
                throw new Exception("All fields are required");
        }

        // dùng chung để map 
        private static LionProfileDTO MapToDto(DataAccessLayer.Models.LionProfile e)
        {
            return new LionProfileDTO
            {
                LionProfileId = e.LionProfileId,
                LionTypeId = e.LionTypeId,
                LionName = e.LionName,
                Weight = e.Weight,
                Characteristics = e.Characteristics,
                Warning = e.Warning,
                ModifiedDate = e.ModifiedDate,
                LionType = e.LionType
            };
        }
    }
}
