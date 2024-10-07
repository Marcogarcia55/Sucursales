
using Sucursales.Dto;
using Sucursales.Models;

namespace Sucursales.Service
{
    public interface ISucursalService
    {
        Task<IEnumerable<SucursalDto>> GetAllAsync();
        Task<SucursalDto?> GetById(int id);
        Task<int> AddAsync(Sucursal sucursal);
        Task<int> UpdateAsync(Sucursal sucursal);
        Task<int> DeleteAsync(int id);
    }
}