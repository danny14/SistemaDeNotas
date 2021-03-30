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
    public class NotasService : INotasService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public NotasService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        /*
         * Insertar una nota
         */
        public async Task<bool> NotasInsert(Notas notas)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("nota1", notas.nota1, DbType.Int32);
                parameters.Add("nota2", notas.nota2, DbType.Int32);
                parameters.Add("nota3", notas.nota3, DbType.Int32);
                parameters.Add("promedioNotas", notas.promedioNotas, DbType.Double);
                parameters.Add("idEstudiante", notas.idEstudiante, DbType.Int32);
                parameters.Add("idMateria", notas.idMateria, DbType.Int32);


                const string query = @"INSERT INTO notas ( nota1, nota2, nota3, promedioNotas, idEstudiante, idMateria ) 
                VALUES ( @nota1, @nota2, @nota3, @promedioNotas , @idEstudiante , @idMateria  )";

                await conn.ExecuteAsync(query, new { notas.nota1, notas.nota2, notas.nota3, notas.promedioNotas, notas.idEstudiante, notas.idMateria }, commandType: CommandType.Text);
            }

            return true;
        }


        /**
         * Obtener todos los estudiantes 
        **/
        public async Task<IEnumerable<Notas>> GetAllNotas()
        {
            IEnumerable<Notas> notas;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT * FROM notas";
                notas = await conn.QueryAsync<Notas>(query, commandType: CommandType.Text);
            }

            return notas;
        }


        /**
         * Eliminar una Nota
         */
        public async Task<bool> NotasDelete(int idNotas)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var query = @"DELETE FROM notas
                            WHERE idNotas = @idNotas";
                await conn.ExecuteAsync(query.ToString(), new { idNotas = idNotas }, commandType: CommandType.Text);
            }

            return true;
        }


        /**
         * Obtener un Materia por ID 
        **/
        public async Task<Notas> GetNotasDetail(int id)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {

                const string query = "SELECT * FROM notas WHERE idNotas = @Id";
                return await conn.QueryFirstOrDefaultAsync<Notas>(query.ToString(), new { Id = id }, commandType: CommandType.Text);
            }
        }

        /*
         * Metodo para actualizar una Materia 
         */
        public async Task<bool> NotasUpdate(Notas notas)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {

                var parameters = new DynamicParameters();

                parameters.Add("nota1", notas.nota1, DbType.String);
                parameters.Add("nota2", notas.nota2, DbType.Int32);
                parameters.Add("nota3", notas.nota3, DbType.String);
                parameters.Add("promedioNotas", notas.promedioNotas, DbType.Int32);
                parameters.Add("idEstudiante", notas.idEstudiante, DbType.String);
                parameters.Add("idMateria", notas.idMateria, DbType.Int32);

                const string query = @"UPDATE materia SET nota1 = @nota1,
                                    nota2 = @nota2,
                                    nota3 = @nota3,
                                    promedioNotas = @promedioNotas,
                                    idEstudiante = @idEstudiante,
                                    idMateria = @idMateria,
                                    WHERE idNotas = @idNotas";

                await conn.ExecuteAsync(query, new { notas.nota1, notas.nota2, notas.nota3, notas.promedioNotas, notas.idEstudiante, notas.idMateria }, commandType: CommandType.Text);
            }

            return true;
        }

    }
}
