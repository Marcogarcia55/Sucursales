
using Sucursales.Dto;
using Sucursales.Models;
using Sucursales.Repository;

namespace Sucursales.Service
{
    public class PuestoService : IPuestoService
    {
        private readonly IPuestoRepository _puestoRepository;

        public PuestoService(IPuestoRepository puestoRepository)
        {
            _puestoRepository = puestoRepository;
        }
        public async Task<int> AddAsync(Puesto puesto)
        {
            return await _puestoRepository.AddAsync(puesto);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _puestoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PuestoDto>> GetAllAsync()
        {
            return (await _puestoRepository.GetAllAsync())
           .Select(p => new PuestoDto { Nombre = p.NombreP });
            
        }

        public async Task<PuestoDto?> GetById(int id)
        {
            return (await _puestoRepository.GetById(id)) is Puesto p
            ? new PuestoDto {Nombre = p.NombreP} : null;
            
        }

        public async Task<int> UpdateAsync(Puesto puesto)
        {
            return await _puestoRepository.UpdateAsync(puesto);
        }
    }
}