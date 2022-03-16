using API.ViewModels.Catalog.Exports;
using API.ViewModels.Common;
using System.Threading.Tasks;

namespace API.Services.Catalog.Exports
{
    public interface IExportServices
    {
        Task<ApiResult<int>> Create(ExportCreateRequest request);
        Task<ApiResult<int>> Update(ExportUpdateRequest request);
        Task<ApiResult<int>> Delete(int exportId);
        Task<ApiResult<PagedResult<ExportViewModel>>> GetPaging(ExportGetPagingRequest request);
        Task<ApiResult<ExportViewModel>> GetById(int exportId);
    }
}
