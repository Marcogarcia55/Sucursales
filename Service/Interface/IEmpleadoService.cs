
using Sucursales.Dto;
using Sucursales.Models;

namespace Sucursales.Service
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<EmpleadoDto>> GetAllAsync();
        Task<IEnumerable<EmpleadoConDetallesDto>> GetAllEmpleadoBySucursalAsync(int id);
        Task<EmpleadoDto?> GetById(int id);
        Task<int> AddAsync(Empleado empleado);
        Task<int> UpdateAsync(Empleado empleado);
        Task<int> DeleteAsync(int id);
    }
}