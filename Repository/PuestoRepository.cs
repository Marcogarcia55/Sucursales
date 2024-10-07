using Sucursales.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Sucursales.Repository
{
    public class PuestoRepository : IPuestoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public PuestoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<int> AddAsync(Puesto puesto)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync("sp_AddPuestos",
                new { puesto.NombreP }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync("sp_DeletePuestos",
            new { IdPuesto = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Puesto>> GetAllAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Puesto>("sp_GetAllPuestos",
            commandType: CommandType.StoredProcedure);
        }

        public async Task<Puesto?> GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Puesto?>("sp_GetByIdPuestos",
            new { IdPuesto = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(Puesto puesto)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync("sp_UpdatePuestos",
            new { puesto.IdPuesto, puesto.NombreP },
            commandType: CommandType.StoredProcedure);
        }
    }
}