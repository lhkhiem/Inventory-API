using API.ViewModels.Catalog.Products;
using API.ViewModels.Common;
using Data.Entities;
using Inventory.Data.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Catalog.Products
{
    public class ProductServices : IProductServices
    {
        private readonly InventoryDbContext _context;

        public ProductServices(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> Create(ProductCreateRequest request)
        {
            try
            {
                var product = new Product()
                {
                    Code = request.Code,
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    Quantity = request.Quantity,
                    Status = true,
                    UnitId = request.UnitId,
                    CategoryId = request.CategoryId,
                };
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>("Created.", product.Id);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

        public async Task<ApiResult<int>> Update(ProductUpdateRequest request)
        {
            try
            {
                var product = await _context.Products.FindAsync(request.Id);
                if (product == null) return new ApiErrorResult<int>("This item is not found.");
                product.Name = request.Name;
                product.Description = request.Description;
                product.Code = request.Code;
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>("Updated.", product.Id);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

        public async Task<ApiResult<int>> Delete(int productId)
        {
            try
            {
                var product = await _context.Products.FindAsync(productId);
                if (product == null) return new ApiErrorResult<int>("This item is not found.");

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>("Deleted.", product.Id);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

        public async Task<ApiResult<ProductViewModel>> GetById(int productId)
        {
            try
            {
                var product = await _context.Products.FindAsync(productId);
                if (product == null) return new ApiErrorResult<ProductViewModel>("This item is not found.");

                var productViewModel = new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Code = product.Code,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Status = product.Status,
                };
                return new ApiSuccessResult<ProductViewModel>("Found item", productViewModel);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<ProductViewModel>(ex.Message);
            }
        }

        public async Task<ApiResult<PagedResult<ProductViewModel>>> GetPaging(ProductGetPagingRequest request)
        {
            try
            {
                var query = from p in _context.Products
                            join c in _context.Categories on p.CategoryId equals c.Id
                            join u in _context.Units on p.UnitId equals u.Id
                            select new { p, u, c };

                int totalRecord = await query.CountAsync();
                if (!string.IsNullOrEmpty(request.Keyword))
                    query = query.Where(x => x.p.Name.Contains(request.Keyword));
                if (request.CategoryId > 0)
                {
                    query = query.Where(x => x.c.Id.Equals(request.CategoryId));
                }

                if (totalRecord > 0)
                {
                    var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                                        .Select(x => new ProductViewModel()
                                        {
                                            Id = x.p.Id,
                                            Name = x.p.Name,
                                            Code = x.p.Code,
                                            Description = x.p.Description,
                                            Price = x.p.Price,
                                            Quantity =x. p.Quantity,
                                            Status = x.p.Status,
                                            Unit = x.u,
                                            Category = x.c
                                        }).ToListAsync();

                    var pagedResult = new PagedResult<ProductViewModel>()
                    {
                        TotalRecord = totalRecord,
                        Items = data
                    };
                    return new ApiSuccessResult<PagedResult<ProductViewModel>>("List items", pagedResult);
                }
                return new ApiErrorResult<PagedResult<ProductViewModel>>("Not have any items.");
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<PagedResult<ProductViewModel>>(ex.Message);
            }
        }
    }
}