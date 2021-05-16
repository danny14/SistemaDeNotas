using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;
using System.Data;
using SistemaDeNotas.Data.Model;
using System.Data.SqlClient;
using SistemaDeNotas.Data;

namespace SistemaDeNotas.Data.Services
{
    public class GradoService : IGradoService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public GradoService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        /*
         * Insertar una grado
         */
        public async Task<bool> GradoInsert(Grado grado)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                
                parameters.Add("nombreGrado", grado.nombreGrado, DbType.String);


                const string query = @"INSERT INTO grado ( idEstudiante, nombreGrado ) 
                VALUES ( @idEstudiante,  @nombreGrado  )";

                await conn.ExecuteAsync(query, new { grado.nombreGrado }, commandType: CommandType.Text);
            }

            return true;
        }


        /**
         * Obtener todos los estudiantes 
        **/
        public async Task<IEnumerable<Grado>> GetAllGrados()
        {
            IEnumerable<Grado> grado;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT * FROM grado";
                grado = await conn.QueryAsync<Grado>(query, commandType: CommandType.Text);
            }

            return grado;
        }


        /**
         * Eliminar una Grado
         */
        public async Task<bool> GradoDelete(int idGrado)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var query = @"DELETE FROM grado
                            WHERE idGrado = @idGrado";
                await conn.ExecuteAsync(query.ToString(), new { idGrado = idGrado }, commandType: CommandType.Text);
            }

            return true;
        }


        /**
         * Obtener un Materia por ID 
        **/
        public async Task<Grado> GetGradoDetail(int id)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {

                const string query = "SELECT * FROM grado WHERE idGrado = @Id";
                return await conn.QueryFirstOrDefaultAsync<Grado>(query.ToString(), new { Id = id }, commandType: CommandType.Text);
            }
        }

        /*
         * Metodo para actualizar una Materia 
         */
        public async Task<bool> GradoUpdate(Grado grado)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {

                var parameters = new DynamicParameters();

                
                parameters.Add("nombreGrado", grado.nombreGrado, DbType.String);

                const string query = @"UPDATE grado 
                                    SET idEstudiante = @idEstudiante,
                                    nombreGrado = @nombreGrado
                                    WHERE idGrado = @idGrado";

                await conn.ExecuteAsync(query, new { grado.nombreGrado }, commandType: CommandType.Text);
            }

            return true;
        }
    }
}
