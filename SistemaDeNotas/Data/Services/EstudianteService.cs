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
        /**
         * Obtener las notas del estudiante 
        **/
        public async Task<Estudiante> GetNotasEstudianteDetail(int nota)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {

                const string query = "SELECT notas.nota1, notas.nota2, notas.nota3, notas.promedioNotas, materia.nombreMateria FROM notas , estudiante, materia, periodo WHERE notas.idEstudiante = estudiante.idEstudiante AND notas.idMateria = materia.idMateria AND notas.idPeriodo = periodo.idPeriodo AND estudiante.idEstudiante = @Id";
                return await conn.QueryFirstOrDefaultAsync<Estudiante>(query.ToString(), new { Id = nota }, commandType: CommandType.Text);
            }
        }

        /**
         * Obtener el estado del estudiantes que ya finalizaron la materia o que ya la cursaron
        **/
        public async Task<Notas> GetEstadoFinalizadoEstudiante(int idGrado)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT estudiante.nombresEstudiante, promedioNotas FROM notas, estudiante WHERE notas.idEstudiante = estudiante.idEstudiante AND promedioNotas != 0";
                return await conn.QueryFirstAsync<Notas>(query.ToString(), new { idGrado = idGrado }, commandType: CommandType.Text);
            }

        }

        /**
         * Metodo para obtener los Estudiantes que perdieron
         * 
         */
        public async Task<Notas> GetEstudiantePerdiendo(int idGrado)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT estudiante.nombresEstudiante, promedioNotas FROM notas, estudiante WHERE notas.idEstudiante = estudiante.idEstudiante AND promedioNotas < 3";
                return await conn.QueryFirstAsync<Notas>(query.ToString(), new { idGrado = idGrado }, commandType: CommandType.Text);
            }

        }
        /**
        *  Obtener Estudiante por Materia  
        *
        */
        public async Task<Estudiante> GetEstudianteByMateria(int idMateria, int idProfesor)
        {
            using (var conn = new SqlConnection(_configuration.Value)) {
                const string query = "SELECT estudiante.nombresEstudiante,estudiante.apellidosEstudiante, materia.nombreMateria , profesores.nombreProfesor FROM estudiante,grado,materia,profesores WHERE estudiante.idEstudiante = grado.idEstudiante AND materia.idMateria = grado.idMateria AND profesores.idProfesor = materia.idMateria AND materia.idMateria = @idMateria AND profesores.idProfesor = @idProfesor;";

                return await conn.QueryFirstOrDefaultAsync<Estudiante>(query.ToString(), new { idMateria = idMateria, idProfesor = idProfesor }, commandType: CommandType.Text);
            }
        }
        /**
         *  Obtener Estudiante por Grado
         */
        public async Task<Estudiante> GetEstudianteByGrado(int idMateria, int idProfesor)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT estudiante.nombresEstudiante,estudiante.apellidosEstudiante, materia.nombreMateria , profesores.nombreProfesor FROM estudiante,grado,materia,profesores WHERE estudiante.idEstudiante = grado.idEstudiante AND materia.idMateria = grado.idMateria AND profesores.idProfesor = materia.idMateria AND materia.idMateria = @idMateria AND profesores.idProfesor = @idProfesor;";

                return await conn.QueryFirstOrDefaultAsync<Estudiante>(query.ToString(), new { idMateria = idMateria, idProfesor = idProfesor }, commandType: CommandType.Text);
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

                const string query = @"UPDATE estudiante SET NombresEstudiante = @nombresEstudiante,
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
