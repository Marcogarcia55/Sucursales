
using Sucursales.Dto;
using Sucursales.Models;

namespace Sucursales.Repository
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> GetAllAsync();
        Task<IEnumerable<EmpleadoConDetallesDto>> GetAllEmpleadoBySucursalAsync(int id);
        Task<Empleado?> GetById(int id);
        Task<int> AddAsync(Empleado empleado);
        Task<int> UpdateAsync(Empleado empleado);
        Task<int> DeleteAsync(int id);
    }
}