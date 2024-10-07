
using Sucursales.Models;

namespace Sucursales.Repository
{
    public interface ISucursalRepository
    {
        Task<IEnumerable<Sucursal>> GetAllAsync();
        Task<Sucursal?> GetById(int id);
        Task<int> AddAsync(Sucursal sucursal);
        Task<int> UpdateAsync(Sucursal sucursal);
        Task<int> DeleteAsync(int id);
    }
}