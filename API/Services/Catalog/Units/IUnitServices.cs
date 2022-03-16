using API.ViewModels.Catalog.Units;
using API.ViewModels.Common;
using System.Threading.Tasks;

namespace API.Services.Catalog.Units
{
    public interface IUnitServices
    {
        Task<ApiResult<int>> Create(UnitCreateRequest request);
        Task<ApiResult<int>> Update(UnitUpdateRequest request);
        Task<ApiResult<int>> Delete(int unitId);
        Task<ApiResult<PagedResult<UnitViewModel>>> GetPaging(UnitGetPagingRequest request);
        Task<ApiResult<UnitViewModel>> GetById(int unitId);
    }
}
