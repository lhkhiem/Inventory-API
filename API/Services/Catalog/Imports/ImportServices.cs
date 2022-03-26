using API.ViewModels.Catalog.Imports;
using API.ViewModels.Common;
using Data.Entities;
using Inventory.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Catalog.Imports
{
    public class ImportServices : IImportServices
    {
        private readonly InventoryDbContext _context;

        public ImportServices(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> Create(ImportCreateRequest request)
        {
            try
            {
                var import = new Import() { No = request.No, CreateDate = DateTime.Now, Date = request.Date };
                _context.Imports.Add(import);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>("Created.", import.Id);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

        public async Task<ApiResult<int>> Delete(int importId)
        {
            try
            {
                var import = await _context.Imports.FindAsync(importId);
                if (import == null) return new ApiErrorResult<int>("This item is not found.");

                var importDetail = _context.ImportDetails.Where(x => x.ImportId.Equals(importId));
                if (importDetail != null)
                    _context.ImportDetails.RemoveRange(importDetail);

                _context.Imports.Remove(import);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>("Deleted.", import.Id);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

        public async Task<ApiResult<ImportViewModel>> GetById(int importId)
        {
            try
            {
                var import = await _context.Imports.FindAsync(importId);
                if (import == null) return new ApiErrorResult<ImportViewModel>("This item is not found.");
                var importViewModel = new ImportViewModel()
                {
                    Id = import.Id,
                    No = import.No,
                    CreateDate = import.CreateDate,
                    Date = import.Date,
                };
                return new ApiSuccessResult<ImportViewModel>("Found item", importViewModel);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<ImportViewModel>(ex.Message);
            }
        }

        public async Task<ApiResult<PagedResult<ImportViewModel>>> GetPaging(ImportGetPagingRequest request)
        {
            try
            {
                var query = _context.Imports.AsQueryable();
                if (!string.IsNullOrEmpty(request.Keyword))
                    query = query.Where(x => x.No.Contains(request.Keyword));

                int totalRecord = await query.CountAsync();

                if (totalRecord > 0)
                {
                    var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                                        .Select(x => new ImportViewModel()
                                        {
                                            Id = x.Id,
                                            No = x.No,
                                            Date = x.Date,
                                            CreateDate = x.CreateDate
                                        }).ToListAsync();

                    var pagedResult = new PagedResult<ImportViewModel>()
                    {
                        TotalRecord = totalRecord,
                        Items = data
                    };
                    return new ApiSuccessResult<PagedResult<ImportViewModel>>("List items", pagedResult);
                }
                return new ApiErrorResult<PagedResult<ImportViewModel>>("Not have any items.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<PagedResult<ImportViewModel>>(ex.Message);
            }
        }

        public async Task<ApiResult<int>> Update(ImportUpdateRequest request)
        {
            try
            {
                var import = await _context.Imports.FindAsync(request.Id);
                if (import == null) return new ApiErrorResult<int>("This item is not found.");
                import.No = request.No;
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>("Updated.", import.Id);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }
    }
}