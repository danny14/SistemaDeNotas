using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;
using System.Data;
using SistemaDeNotas.Data.Model;
using System.Data.SqlClient;
namespace SistemaDeNotas.Data.Services
{
    public class PeriodoService : IPeriodoService
    {
        private readonly SqlConnectionConfiguration _configuration;

        public PeriodoService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<periodo>> GetAllPeriodo()
        {
            IEnumerable<periodo> listaPeriodo;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT * FROM periodo";
                listaPeriodo = await conn.QueryAsync<periodo>(query, commandType: CommandType.Text);
            }

            return listaPeriodo;
        }
    }
}
