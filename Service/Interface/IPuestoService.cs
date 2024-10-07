
using Sucursales.Dto;
using Sucursales.Models;

namespace Sucursales.Service
{
    public interface IPuestoService
    {
        Task<IEnumerable<PuestoDto>> GetAllAsync();
        Task<PuestoDto?> GetById(int id);
        Task<int> AddAsync(Puesto puesto);
        Task<int> UpdateAsync(Puesto puesto);
        Task<int> DeleteAsync(int id);
    }
}