using API.ViewModels.Catalog.ImportDetails;
using API.ViewModels.Common;
using Data.Entities;
using Inventory.Data.EF;
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

        public Task<ApiResult<int>> Delete(int importId, int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResult<ImportDetailViewModel>> GetByImportId(int importId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResult<ImportDetailViewModel>> GetByProductId(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResult<PagedResult<ImportDetailViewModel>>> GetPaging(ImportDetailGetPagingRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResult<int>> Update(ImportDetailUpdateRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}