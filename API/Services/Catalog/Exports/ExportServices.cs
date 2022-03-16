using API.ViewModels.Catalog.Exports;
using API.ViewModels.Common;
using Data.Entities;
using Inventory.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Catalog.Exports
{
    public class ExportServices : IExportServices
    {
        private readonly InventoryDbContext _context;

        public ExportServices(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> Create(ExportCreateRequest request)
        {
            try
            {
                var export = new Export() { No = request.No, CreateDate = DateTime.Now, Date = request.Date };
                _context.Exports.Add(export);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>("Created.", export.Id);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

        public async Task<ApiResult<int>> Delete(int exportId)
        {
            try
            {
                var export = await _context.Exports.FindAsync(exportId);
                if (export == null) return new ApiErrorResult<int>("This item is not found.");

                var exportDetail = _context.ExportDetails.Where(x => x.ExportId.Equals(exportId));
                if (exportDetail != null)
                    _context.ExportDetails.RemoveRange(exportDetail);

                _context.Exports.Remove(export);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>("Deleted.", export.Id);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

        public async Task<ApiResult<ExportViewModel>> GetById(int exportId)
        {
            try
            {
                var export = await _context.Exports.FindAsync(exportId);
                if (export == null) return new ApiErrorResult<ExportViewModel>("This item is not found.");
                var exportViewModel = new ExportViewModel()
                {
                    Id = export.Id,
                    No = export.No,
                    CreateDate = export.CreateDate,
                    Date = export.Date,
                };
                return new ApiSuccessResult<ExportViewModel>("Found item", exportViewModel);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<ExportViewModel>(ex.Message);
            }
        }

        public async Task<ApiResult<PagedResult<ExportViewModel>>> GetPaging(ExportGetPagingRequest request)
        {
            try
            {
                var query = _context.Exports.AsQueryable();
                if (!string.IsNullOrEmpty(request.Keyword))
                    query = query.Where(x => x.No.Contains(request.Keyword));

                int totalRecord = await query.CountAsync();

                if (totalRecord > 0)
                {
                    var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                                        .Select(x => new ExportViewModel()
                                        {
                                            Id = x.Id,
                                            No = x.No,
                                            Date=x.Date,
                                            CreateDate=x.CreateDate
                                        }).ToListAsync();

                    var pagedResult = new PagedResult<ExportViewModel>()
                    {
                        TotalRecord = totalRecord,
                        Items = data
                    };
                    return new ApiSuccessResult<PagedResult<ExportViewModel>>("List items", pagedResult);
                }
                return new ApiErrorResult<PagedResult<ExportViewModel>>("Not have any items.");
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<PagedResult<ExportViewModel>>(ex.Message);
            }
        }

        public async Task<ApiResult<int>> Update(ExportUpdateRequest request)
        {
            try
            {
                var export = await _context.Exports.FindAsync(request.Id);
                if (export == null) return new ApiErrorResult<int>("This item is not found.");
                export.No = request.No;
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>("Updated.", export.Id);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }
    }
}