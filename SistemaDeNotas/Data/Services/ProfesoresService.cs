using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;
using System.Data;
using SistemaDeNotas.Data.Model;
using System.Data.SqlClient;
using SistemaDeNotas.Data;

namespace SistemaDeProfesor.Data.Services
{
    public class ProfesoresService : IProfesoresService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public ProfesoresService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        /*
         * Insertar una nota
         */
        public async Task<bool> ProfesorInsert(Profesores profesor)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("nombreProfesor", profesor.nombreProfesor, DbType.String);
                parameters.Add("apellidoProfesor", profesor.apellidoProfesor, DbType.String);
                parameters.Add("direccionProfesor", profesor.direccionProfesor, DbType.String);
                parameters.Add("telefonoProfesor", profesor.telefonoProfesor, DbType.String);
                parameters.Add("correoProfesor", profesor.correoProfesor, DbType.String);



                const string query = @"INSERT INTO profesor ( nombreProfesor, apellidoProfesor, direccionProfesor, telefonoProfesor, correoProfesor ) 
                VALUES ( @nombreProfesor, @apellidoProfesor, @direccionProfesor, @telefonoProfesor , @correoProfesor  )";

                await conn.ExecuteAsync(query, new { profesor.nombreProfesor, profesor.apellidoProfesor, profesor.direccionProfesor, profesor.telefonoProfesor, profesor.correoProfesor }, commandType: CommandType.Text);
            }

            return true;
        }


        /**
         * Obtener todos los estudiantes 
        **/
        public async Task<IEnumerable<Profesores>> GetAllProfesor()
        {
            IEnumerable<Profesores> profesor;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT * FROM profesor";
                profesor = await conn.QueryAsync<Profesores>(query, commandType: CommandType.Text);
            }

            return profesor;
        }


        /**
         * Eliminar una Nota
         */
        public async Task<bool> ProfesorDelete(int idProfesor)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var query = @"DELETE FROM profesor
                            WHERE idProfesor = @idProfesor";
                await conn.ExecuteAsync(query.ToString(), new { idProfesor = idProfesor }, commandType: CommandType.Text);
            }

            return true;
        }


        /**
         * Obtener un Materia por ID 
        **/
        public async Task<Profesores> GetProfesorDetail(int id)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {

                const string query = "SELECT * FROM profesor WHERE idProfesor = @Id";
                return await conn.QueryFirstOrDefaultAsync<Profesores>(query.ToString(), new { Id = id }, commandType: CommandType.Text);
            }
        }

        /*
         * Metodo para actualizar una Materia 
         */
        public async Task<bool> ProfesorUpdate(Profesores profesor)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {

                var parameters = new DynamicParameters();

                parameters.Add("nombreProfesor", profesor.nombreProfesor, DbType.String);
                parameters.Add("apellidoProfesor", profesor.apellidoProfesor, DbType.Int32);
                parameters.Add("direccionProfesor", profesor.direccionProfesor, DbType.String);
                parameters.Add("telefonoProfesor", profesor.telefonoProfesor, DbType.Int32);
                parameters.Add("correoProfesor", profesor.correoProfesor, DbType.String);


                const string query = @"UPDATE profesor SET nombreProfesor = @nombreProfesor,
                                    apellidoProfesor = @apellidoProfesor,
                                    direccionProfesor = @direccionProfesor,
                                    telefonoProfesor = @telefonoProfesor,
                                    correoProfesor = @correoProfesor,
                                    WHERE idProfesor = @idProfesor";

                await conn.ExecuteAsync(query, new { profesor.nombreProfesor, profesor.apellidoProfesor, profesor.direccionProfesor, profesor.telefonoProfesor, profesor.correoProfesor }, commandType: CommandType.Text);
            }

            return true;
        }
    }
}
