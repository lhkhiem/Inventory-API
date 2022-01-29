using API.ViewModels.Catalog.Products;
using API.ViewModels.Common;
using System.Threading.Tasks;

namespace API.Services.Catalog.Products
{
    public interface IProductServices
    {
        Task<ApiResult<int>> Create(ProductCreateRequest request);
        Task<ApiResult<int>> Update(ProductUpdateRequest request);
        Task<ApiResult<int>> Delete(int ProductId);
        Task<ApiResult<PagedResult<ProductViewModel>>> GetPaging(ProductGetPagingRequest request);
        Task<ApiResult<ProductViewModel>> GetById(int ProductId);
    }
}
