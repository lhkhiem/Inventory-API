using API.ViewModels.Catalog.Categories;
using API.ViewModels.Common;
using System.Threading.Tasks;

namespace API.Services.Catalog.Categories
{
    public interface ICategoryServices
    {
        Task<ApiResult<int>> Create(CategoryCreateRequest request);
        Task<ApiResult<int>> Update(CategoryUpdateRequest request);
        Task<ApiResult<int>> Delete(int unitId);
        Task<ApiResult<PagedResult<CategoryViewModel>>> GetPaging(CategoryGetPagingRequest request);
        Task<ApiResult<CategoryViewModel>> GetById(int unitId);
    }
}
