using Sucursales.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Sucursales.Dto;

namespace Sucursales.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public EmpleadoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<int> AddAsync(Empleado empleado)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync("sp_AddEmpleados",
                new { empleado.Nombre, empleado.Apellido, empleado.IdPuesto, empleado.IdSucursal },
                commandType: CommandType.StoredProcedure);
        }


        public async Task<int> DeleteAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync("sp_DeleteEmpleados",
            new { IdEmpleado = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Empleado>("sp_GetAllEmpleados",
            commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<EmpleadoConDetallesDto>> GetAllEmpleadoBySucursalAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<EmpleadoConDetallesDto>("sp_GetEmpleadosBySucursal",
            new{idSucursal = id},
            commandType: CommandType.StoredProcedure);
        }
        public async Task<Empleado?> GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Empleado?>("sp_GetByIdEmpleados",
            new { IdEmpleado = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(Empleado empleado)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync("sp_UpdateEmpleados",
            new { empleado.IdEmpleado, empleado.Nombre, empleado.Apellido, empleado.IdPuesto, empleado.IdSucursal },
            commandType: CommandType.StoredProcedure);
        }
    }
}