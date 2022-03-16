using API.ViewModels.Catalog.Imports;
using API.ViewModels.Common;
using System.Threading.Tasks;

namespace API.Services.Catalog.Imports
{
    public interface IImportServices
    {
        Task<ApiResult<int>> Create(ImportCreateRequest request);
        Task<ApiResult<int>> Update(ImportUpdateRequest request);
        Task<ApiResult<int>> Delete(int importId);
        Task<ApiResult<PagedResult<ImportViewModel>>> GetPaging(ImportGetPagingRequest request);
        Task<ApiResult<ImportViewModel>> GetById(int importId);
    }
}
