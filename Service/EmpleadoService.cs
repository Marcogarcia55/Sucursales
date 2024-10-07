
using Sucursales.Dto;
using Sucursales.Models;
using Sucursales.Repository;

namespace Sucursales.Service
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }
        public async Task<int> AddAsync(Empleado empleado)
        {
            return await _empleadoRepository.AddAsync(empleado);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _empleadoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmpleadoDto>> GetAllAsync()
        {
            return (await _empleadoRepository.GetAllAsync())
            .Select(e => new EmpleadoDto { Nombre = e.Nombre, Apellido = e.Apellido });
        }

        public async Task<IEnumerable<EmpleadoConDetallesDto>> GetAllEmpleadoBySucursalAsync(int id)
        {
            return (await _empleadoRepository.GetAllEmpleadoBySucursalAsync(id))
            .Select(e => new EmpleadoConDetallesDto
            {
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                NombreP = e.NombreP,
                NombreS = e.NombreS,
                Direccion = e.Direccion
            });
        }

        public async Task<EmpleadoDto?> GetById(int id)
        {
            return (await _empleadoRepository.GetById(id)) is Empleado e
            ? new EmpleadoDto{ Nombre = e.Nombre, Apellido = e.Apellido} : null;
        }

        public async Task<int> UpdateAsync(Empleado puesto)
        {
            return await _empleadoRepository.UpdateAsync(puesto);
        }
    }
}