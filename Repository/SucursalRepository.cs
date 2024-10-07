using Sucursales.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Sucursales.Repository
{

    public class SucursalRepository : ISucursalRepository
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public SucursalRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddAsync(Sucursal sucursal)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync("sp_AddSucursal",
            new { sucursal.NombreS, sucursal.Direccion }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync("sp_DeleteSucursal",
            new { IdSucursal = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Sucursal>> GetAllAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Sucursal>("sp_GetAllSucursal",
            commandType: CommandType.StoredProcedure);
        }

        public async Task<Sucursal?> GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Sucursal?>("sp_GetByIdSucursal",
            new { IdSucursal = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(Sucursal sucursal)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync("sp_UpdateSucursal",
            new { sucursal.IdSucursal, sucursal.NombreS, sucursal.Direccion }, 
            commandType: CommandType.StoredProcedure);
        }
    }
}