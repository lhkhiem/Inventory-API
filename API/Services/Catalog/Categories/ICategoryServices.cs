using API.ViewModels.Catalog.Categories;
using API.ViewModels.Common;
using System.Threading.Tasks;

namespace API.Services.Catalog.Categories
{
    public interface ICategoryServices
    {
        Task<ApiResult<byte>> Create(CategoryCreateRequest request);
        Task<ApiResult<byte>> Update(CategoryUpdateRequest request);
        Task<ApiResult<byte>> Delete(byte unitId);
        Task<ApiResult<PagedResult<CategoryViewModel>>> GetPaging(CategoryGetPagingRequest request);
        Task<ApiResult<CategoryViewModel>> GetById(byte unitId);
    }
}
