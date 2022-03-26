using API.ViewModels.Catalog.ImportDetails;
using API.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services.Catalog.ImportDetails
{
    public interface IImportDetailServices
    {
        Task<ApiResult<int>> Create(ImportDetailCreateRequest request);
        Task<ApiResult<int>> Update(ImportDetailUpdateRequest request);
        Task<ApiResult<int>> Delete(int importId, int productId);
        Task<ApiResult<List<ImportDetailViewModel>>> GetListByImportId(int importId);
        Task<ApiResult<PagedResult<ImportDetailViewModel>>> GetListByProductId(int productId);
    }
}
