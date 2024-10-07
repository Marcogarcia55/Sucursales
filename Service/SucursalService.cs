
using Sucursales.Dto;
using Sucursales.Models;
using Sucursales.Repository;

namespace Sucursales.Service
{
    public class SucursalService : ISucursalService
    {
        private readonly ISucursalRepository _sucursalRepository;

        public SucursalService(ISucursalRepository sucursalRepository)
        {
            _sucursalRepository = sucursalRepository;
        }
        public async Task<int> AddAsync(Sucursal sucursal)
        {
            return await _sucursalRepository.AddAsync(sucursal);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _sucursalRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SucursalDto>> GetAllAsync()
        {
            return (await _sucursalRepository.GetAllAsync())
            .Select(s => new SucursalDto{Nombre = s.NombreS, Direccion = s.Direccion});
        }

        public async Task<SucursalDto?> GetById(int id)
        {
            return (await _sucursalRepository.GetById(id)) is Sucursal s
            ? new SucursalDto { Nombre = s.NombreS, Direccion = s.Direccion}
            : null;
        }

        public async Task<int> UpdateAsync(Sucursal sucursal)
        {
            return await _sucursalRepository.UpdateAsync(sucursal);
        }
    }
}