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
    public class EstudianteService : IEstudianteService
    {
        private readonly SqlConnectionConfiguration _configuration;

        public EstudianteService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        /*
         * Insertar un Estudiante
         */
        public async Task<bool> EstudianteInsert(Estudiante estudiante)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("idEstudiante", estudiante.idEstudiante, DbType.Int32);
                parameters.Add("nombresEstudiante", estudiante.NombresEstudiante, DbType.String);
                parameters.Add("apellidosEstudiante", estudiante.ApellidosEstudiante, DbType.String);
                parameters.Add("direccionEstudiante", estudiante.DireccionEstudiante, DbType.String);
                parameters.Add("telefonoEstudiante", estudiante.TelefonoEstudiante, DbType.String);
                parameters.Add("correoEstudiante", estudiante.CorreoEstudiante, DbType.String);

                const string query = @"INSERT INTO estudiante (idEstudiante, NombresEstudiante, ApellidosEstudiante, DireccionEstudiante, TelefonoEstudiante, CorreoEstudiante) 
                VALUES (@IdEstudiante, @nombresEstudiante, @apellidosEstudiante,@direccionEstudiante,@telefonoEstudiante,@correoEstudiante)";

                await conn.ExecuteAsync(query, new { estudiante.idEstudiante, estudiante.NombresEstudiante, estudiante.ApellidosEstudiante, estudiante.DireccionEstudiante, estudiante.TelefonoEstudiante, estudiante.CorreoEstudiante }, commandType: CommandType.Text);
            }

            return true;
        }


        /**
         * Obtener todos los estudiantes 
        **/
        public async Task<IEnumerable<Estudiante>> GetAllEstudiantes()
        {
            IEnumerable<Estudiante> estudiantes;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT * FROM estudiante";
                estudiantes = await conn.QueryAsync<Estudiante>(query, commandType: CommandType.Text);
            }

            return estudiantes;
        }


        /**
         * Eliminar un Estudiante
         */
        public async Task<bool> EstudianteDelete(int idEstudiante)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var query = @"DELETE FROM Estudiante
                            WHERE idEstudiante = @id";
                await conn.ExecuteAsync(query.ToString(), new { id = idEstudiante }, commandType: CommandType.Text);
            }

            return true;
        }


        /**
         * Obtener un estudiante por ID 
        **/
        public async Task<Estudiante> GetEstudianteDetail(int id)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
 
                const string query = "SELECT * FROM estudiante WHERE idEstudiante = @Id";
                return await conn.QueryFirstOrDefaultAsync<Estudiante>(query.ToString(), new { Id = id }, commandType: CommandType.Text);
            }
        }

        /*
         * Metodo para actualizar un estudiante 
         */
        public async Task<bool> EstudianteUpdate(Estudiante estudiante)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {

                var parameters = new DynamicParameters();
                parameters.Add("idEstudiante", estudiante.idEstudiante, DbType.Int32);
                parameters.Add("nombresEstudiante", estudiante.NombresEstudiante, DbType.String);
                parameters.Add("apellidosEstudiante", estudiante.ApellidosEstudiante, DbType.String);
                parameters.Add("direccionEstudiante", estudiante.DireccionEstudiante, DbType.String);
                parameters.Add("telefonoEstudiante", estudiante.TelefonoEstudiante, DbType.String);
                parameters.Add("correoEstudiante", estudiante.CorreoEstudiante, DbType.String);

                const string query = @"UPDATE Tienda SET NombresEstudiante = @nombresEstudiante,
                                    ApellidosEstudiante = @apellidosEstudiante,
                                    DireccionEstudiante = @direccionEstudiante,
                                    TelefonoEstudiante = @telefonoEstudiante,
                                    CorreoEstudiante = @correoEstudiante
                                    WHERE idEstudiante = @idEstudiante";

                    await conn.ExecuteAsync(query, new { estudiante.idEstudiante, estudiante.NombresEstudiante, estudiante.ApellidosEstudiante, estudiante.DireccionEstudiante, estudiante.TelefonoEstudiante, estudiante.CorreoEstudiante }, commandType: CommandType.Text);
            }

            return true;
        }
    }
}
