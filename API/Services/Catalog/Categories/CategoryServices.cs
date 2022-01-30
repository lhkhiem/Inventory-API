using API.ViewModels.Catalog.Categories;
using API.ViewModels.Common;
using Data.Entities;
using Inventory.Data.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Catalog.Categories
{
    public class CategoryServices : ICategoryServices
    {
        private readonly InventoryDbContext _context;

        public CategoryServices(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<byte>> Create(CategoryCreateRequest request)
        {
            try
            {
                var category = new Category() { Name = request.Name };
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<byte>("Created.", category.Id);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<byte>(ex.Message);
            }
        }

        public async Task<ApiResult<byte>> Update(CategoryUpdateRequest request)
        {
            try
            {
                var category = await _context.Categories.FindAsync(request.Id);
                if (category == null) return new ApiErrorResult<byte>("This item is not found.");
                category.Name = request.Name;
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<byte>("Updated.", category.Id);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<byte>(ex.Message);
            }
        }

        public async Task<ApiResult<byte>> Delete(byte categoryId)
        {
            try
            {
                var category = await _context.Categories.FindAsync(categoryId);
                if (category == null) return new ApiErrorResult<byte>("This item is not found.");

                var product = await _context.Products.FirstOrDefaultAsync(x=>x.CategoryId.Equals(categoryId));
                if (product!=null) return new ApiErrorResult<byte>("Have 1 or more product used.");

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<byte>("Deleted.", category.Id);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<byte>(ex.Message);
            }
        }

        public async Task<ApiResult<CategoryViewModel>> GetById(byte categoryId)
        {
            try
            {
                var category = await _context.Categories.FindAsync(categoryId);
                if (category == null) return new ApiErrorResult<CategoryViewModel>("This item is not found.");
                var categoryViewModel = new CategoryViewModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                };
                return new ApiSuccessResult<CategoryViewModel>("Found item", categoryViewModel);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<CategoryViewModel>(ex.Message);
            }
        }

        public async Task<ApiResult<PagedResult<CategoryViewModel>>> GetPaging(CategoryGetPagingRequest request)
        {
            try
            {
                var query = _context.Categories.AsQueryable();
                if (!string.IsNullOrEmpty(request.Keyword))
                    query = query.Where(x => x.Name.Contains(request.Keyword));

                int totalRecord = await query.CountAsync();

                if (totalRecord > 0)
                {
                    var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                                        .Select(x => new CategoryViewModel()
                                        {
                                            Id = x.Id,
                                            Name = x.Name,
                                        }).ToListAsync();

                    var pagedResult = new PagedResult<CategoryViewModel>()
                    {
                        TotalRecord = totalRecord,
                        Items = data
                    };
                    return new ApiSuccessResult<PagedResult<CategoryViewModel>>("List items", pagedResult);
                }
                return new ApiErrorResult<PagedResult<CategoryViewModel>>("Not have any items.");
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<PagedResult<CategoryViewModel>>(ex.Message);
            }
        }
    }
}