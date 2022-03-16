using API.ViewModels.Catalog.ExportDetails;
using API.ViewModels.Common;
using Data.Entities;
using Inventory.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Catalog.ExportDetails
{
    public class ExportDetailServices : IExportDetailServices
    {
        private readonly InventoryDbContext _context;

        public ExportDetailServices(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<int> CheckInStock(int productId)
        {
            var ledger = await _context.Ledgers.FirstOrDefaultAsync(x => x.Period.Equals(DateTime.Now.Year.ToString()));
            if (ledger == null) return 0;

            var ledgerDetail = await _context.LedgerDetails.FirstOrDefaultAsync(x => x.ProductId.Equals(productId) && x.LedgerId.Equals(ledger.Period));
            if (ledgerDetail == null) return 0;
            var openQuantity = ledgerDetail.Opening;

            var importList = _context.Imports.Where(x => x.Date.Year.Equals(DateTime.Now.Year) && x.Date <= DateTime.Now).ToList();
            var exportList = _context.Exports.Where(x => x.Date.Year.Equals(DateTime.Now.Year) && x.Date <= DateTime.Now).ToList();

            int importQuantity = 0;
            int exportQuantity = 0;
            if (importList.Count > 0)
                foreach (var importItem in importList)
                {
                    var importListDetail = _context.ImportDetails.Where(x => x.ImportId.Equals(importItem.Id) && x.ProductId.Equals(productId)).ToList();
                    if (importListDetail.Count > 0) importQuantity = importListDetail.Sum(x => x.Quantity);
                }
            if (exportList.Count > 0)
                foreach (var exportItem in exportList)
                {
                    var exportListDetail = _context.ExportDetails.Where(x => x.ExportId.Equals(exportItem.Id) && x.ProductId.Equals(productId)).ToList();
                    if (exportListDetail.Count > 0) exportQuantity = exportListDetail.Sum(x => x.Quantity);
                }
            return openQuantity + importQuantity - exportQuantity;
        }

        public async Task<ApiResult<int>> Create(ExportDetailCreateRequest request)
        {
            try
            {
                int checkStock = await CheckInStock(request.ProductId);
                if (checkStock <= 0 || checkStock < request.Quantity) return new ApiErrorResult<int>("Không tìm thấy hoặc không đủ số lượng tồn kho.");
                if (request.Quantity <= 0) return new ApiErrorResult<int>("Số lượng xuất phải > 0.");
                var exportDetail = new ExportDetail()
                {
                    ExportId = request.ExportId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    Note = request.Note,
                };
                _context.ExportDetails.Add(exportDetail);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>("Created.", exportDetail.ExportId);
            }
            catch (InvalidOperationException)
            {
                return new ApiErrorResult<int>("Sản phẩm này đã tồn tại.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

        public async Task<ApiResult<int>> UpdateQuantity(int exportId, int productId, int newQuantity)
        {
            try
            {
                var result = await _context.ExportDetails.FirstOrDefaultAsync(x => x.ExportId.Equals(exportId) && x.ProductId.Equals(productId));
                if (result == null) return new ApiErrorResult<int>("Không tìm thấy!");
                result.Quantity = newQuantity;
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>("Cập nhật số lượng thành công", newQuantity);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

        public Task<ApiResult<int>> Delete(int exportId, int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResult<ExportDetailViewModel>> GetByExportId(int exportId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResult<ExportDetailViewModel>> GetByProductId(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResult<PagedResult<ExportDetailViewModel>>> GetPaging(ExportDetailGetPagingRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResult<int>> Update(ExportDetailUpdateRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}