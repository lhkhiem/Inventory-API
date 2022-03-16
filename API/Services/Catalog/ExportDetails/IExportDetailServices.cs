using API.ViewModels.Catalog.ExportDetails;
using API.ViewModels.Common;
using System.Threading.Tasks;

namespace API.Services.Catalog.ExportDetails
{
    public interface IExportDetailServices
    {
        Task<ApiResult<int>> Create(ExportDetailCreateRequest request);
        Task<ApiResult<int>> Update(ExportDetailUpdateRequest request);
        Task<ApiResult<int>> UpdateQuantity(int exportId, int productId, int newQuantity);
        Task<ApiResult<int>> Delete(int exportId, int productId);
        Task<ApiResult<PagedResult<ExportDetailViewModel>>> GetPaging(ExportDetailGetPagingRequest request);
        Task<ApiResult<ExportDetailViewModel>> GetByExportId(int exportId);
        Task<ApiResult<ExportDetailViewModel>> GetByProductId(int productId);
        Task<int> CheckInStock(int productId);
    }
}
