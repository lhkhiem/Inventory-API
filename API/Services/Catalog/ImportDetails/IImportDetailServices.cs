using API.ViewModels.Catalog.ImportDetails;
using API.ViewModels.Common;
using System.Threading.Tasks;

namespace API.Services.Catalog.ImportDetails
{
    public interface IImportDetailServices
    {
        Task<ApiResult<int>> Create(ImportDetailCreateRequest request);
        Task<ApiResult<int>> Update(ImportDetailUpdateRequest request);
        Task<ApiResult<int>> Delete(int importId, int productId);
        Task<ApiResult<PagedResult<ImportDetailViewModel>>> GetPaging(ImportDetailGetPagingRequest request);
        Task<ApiResult<ImportDetailViewModel>> GetByImportId(int importId);
        Task<ApiResult<ImportDetailViewModel>> GetByProductId(int productId);
    }
}
