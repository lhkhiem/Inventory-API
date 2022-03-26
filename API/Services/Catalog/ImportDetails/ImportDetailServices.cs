using API.ViewModels.Catalog.ImportDetails;
using API.ViewModels.Common;
using Data.Entities;
using Inventory.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Catalog.ImportDetails
{
    public class ImportDetailServices : IImportDetailServices
    {
        private readonly InventoryDbContext _context;

        public ImportDetailServices(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> Create(ImportDetailCreateRequest request)
        {
            try
            {
                if (request.Quantity <= 0) return new ApiErrorResult<int>("Số lượng nhập phải > 0.");
                var importDetail = new ImportDetail()
                {
                    ImportId = request.ImportId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    Note = request.Note,
                };
                _context.ImportDetails.Add(importDetail);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>("Created.", importDetail.ImportId);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

        public async Task<ApiResult<int>> Delete(int importId, int productId)
        {
            try
            {
                var query = await _context.ImportDetails.FindAsync(importId, productId);
                if (query == null) return new ApiErrorResult<int>("This item is not found.");

                _context.ImportDetails.Remove(query);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>("Deleted.", query.ImportId);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

        public async Task<ApiResult<List<ImportDetailViewModel>>> GetListByImportId(int importId)
        {
            try
            {
                var query = _context.ImportDetails.Where(x => x.ImportId==importId).AsQueryable();

                if (!await query.AnyAsync()) return new ApiErrorResult<List<ImportDetailViewModel>>("Không tìm thấy");

                var list = await query.Select(x => new ImportDetailViewModel()
                {
                    ImportId = x.ImportId,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    Note = x.Note,
                }).ToListAsync();

                return new ApiSuccessResult<List<ImportDetailViewModel>>("Thông tin phiếu", list);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<List<ImportDetailViewModel>>(ex.Message);
            }
        }

        public async Task<ApiResult<PagedResult<ImportDetailViewModel>>> GetListByProductId(int productId)
        {
            try
            {
                var query = _context.ImportDetails.Where(x => x.ProductId.Equals(productId)).AsQueryable();

                if (!await query.AnyAsync()) return new ApiErrorResult<PagedResult<ImportDetailViewModel>>("Không tìm thấy");

                int totalRecord = await query.CountAsync();
                var data = await query.Select(x => new ImportDetailViewModel()
                {
                    ImportId = x.ImportId,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    Note = x.Note,
                }).ToListAsync();

                var pagedResult = new PagedResult<ImportDetailViewModel>()
                {
                    TotalRecord = totalRecord,
                    Items = data
                };

                return new ApiSuccessResult<PagedResult<ImportDetailViewModel>>("Thông tin phiếu", pagedResult);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<PagedResult<ImportDetailViewModel>>(ex.Message);
            }
        }

        public async Task<ApiResult<int>> Update(ImportDetailUpdateRequest request)
        {
            try
            {
                var query = await _context.ImportDetails.FindAsync(request.ImportId, request.ProductId);
                if (query == null) return new ApiErrorResult<int>("This item is not found.");
                query.Quantity = request.Quantity;
                query.Note = string.IsNullOrEmpty(request.Note)?String.Empty: request.Note;
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>("Updated.", query.ImportId);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }
    }
}