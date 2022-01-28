using API.ViewModels.Catalog.Units;
using API.ViewModels.Common;
using Data.Entities;
using Inventory.Data.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Catalog.Units
{
    public class UnitServices : IUnitServices
    {
        private readonly InventoryDbContext _context;

        public UnitServices(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<byte>> Create(UnitCreateRequest request)
        {
            try
            {
                var unit = new Unit() { Name = request.Name };
                _context.Units.Add(unit);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<byte>("Created.", unit.Id);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<byte>(ex.Message);
            }
        }

        public async Task<ApiResult<byte>> Update(UnitUpdateRequest request)
        {
            try
            {
                var unit = await _context.Units.FindAsync(request.Id);
                if (unit == null) return new ApiErrorResult<byte>("This item is not found.");
                unit.Name = request.Name;
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<byte>("Updated.", unit.Id);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<byte>(ex.Message);
            }
        }

        public async Task<ApiResult<byte>> Delete(byte unitId)
        {
            try
            {
                var unit = await _context.Units.FindAsync(unitId);
                if (unit == null) return new ApiErrorResult<byte>("This item is not found.");
                _context.Units.Remove(unit);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<byte>("Deleted.", unit.Id);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<byte>(ex.Message);
            }
        }

        public async Task<ApiResult<UnitViewModel>> GetById(byte unitId)
        {
            try
            {
                var unit = await _context.Units.FindAsync(unitId);
                if (unit == null) return new ApiErrorResult<UnitViewModel>("This item is not found.");
                var unitViewModel = new UnitViewModel()
                {
                    Id = unit.Id,
                    Name = unit.Name,
                };
                return new ApiSuccessResult<UnitViewModel>("Found item", unitViewModel);
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<UnitViewModel>(ex.Message);
            }
        }

        public async Task<ApiResult<PagedResult<UnitViewModel>>> GetPaging(UnitGetPagingRequest request)
        {
            try
            {
                var query = _context.Units.AsQueryable();
                if (!string.IsNullOrEmpty(request.Keyword))
                    query = query.Where(x => x.Name.Contains(request.Keyword));

                int totalRecord = await query.CountAsync();

                if (totalRecord > 0)
                {
                    var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                                        .Select(x => new UnitViewModel()
                                        {
                                            Id = x.Id,
                                            Name = x.Name,
                                        }).ToListAsync();

                    var pagedResult = new PagedResult<UnitViewModel>()
                    {
                        TotalRecord = totalRecord,
                        Items = data
                    };
                    return new ApiSuccessResult<PagedResult<UnitViewModel>>("List items", pagedResult);
                }
                return new ApiErrorResult<PagedResult<UnitViewModel>>("Not have any items.");
            }
            catch (System.Exception ex)
            {
                return new ApiErrorResult<PagedResult<UnitViewModel>>(ex.Message);
            }
        }
    }
}