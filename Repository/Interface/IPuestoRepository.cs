
using Sucursales.Models;

namespace Sucursales.Repository
{
    public interface IPuestoRepository
    {
        Task<IEnumerable<Puesto>> GetAllAsync();
        Task<Puesto?> GetById(int id);
        Task<int> AddAsync(Puesto puesto);
        Task<int> UpdateAsync(Puesto puesto);
        Task<int> DeleteAsync(int id);
    }
}