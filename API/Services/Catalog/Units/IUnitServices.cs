using API.ViewModels.Catalog.Units;
using API.ViewModels.Common;
using System.Threading.Tasks;

namespace API.Services.Catalog.Units
{
    public interface IProductServices
    {
        Task<ApiResult<byte>> Create(UnitCreateRequest request);
        Task<ApiResult<byte>> Update(UnitUpdateRequest request);
        Task<ApiResult<byte>> Delete(byte unitId);
        Task<ApiResult<PagedResult<UnitViewModel>>> GetPaging(UnitGetPagingRequest request);
        Task<ApiResult<UnitViewModel>> GetById(byte unitId);
    }
}
