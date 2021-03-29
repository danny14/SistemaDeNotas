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
                parameters.Add("idEstudiante", estudiante.id, DbType.Int32);
                parameters.Add("nombresEstudiante", estudiante.Nombres, DbType.String);
                parameters.Add("apellidosEstudiante", estudiante.Apellidos, DbType.String);
                parameters.Add("direccionEstudiante", estudiante.Direccion, DbType.String);
                parameters.Add("telefonoEstudiante", estudiante.Telefono, DbType.String);
                parameters.Add("correoEstudiante", estudiante.Correo, DbType.String);
                parameters.Add("idProgramaEstudiante", estudiante.id_programa, DbType.Int32);

                const string query = @"INSERT INTO estudiante (id, Nombres, Apellidos, Direccion, Telefono,Correo,id_programa) 
                VALUES (@IdEstudiante, @nombresEstudiante, @apellidosEstudiante,@direccionEstudiante,@telefonoEstudiante,@correoEstudiante, @idProgramaEstudiante)";

                await conn.ExecuteAsync(query, new { estudiante.id, estudiante.Nombres, estudiante.Apellidos, estudiante.Direccion, estudiante.Telefono, estudiante.Correo, estudiante.id_programa }, commandType: CommandType.Text);
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
                            WHERE IdTienda = @id";
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
 
                const string query = "SELECT * FROM estudiante WHERE id = @Id";
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
                parameters.Add("idEstudiante", estudiante.id, DbType.Int32);
                parameters.Add("nombresEstudiante", estudiante.Nombres, DbType.String);
                parameters.Add("apellidosEstudiante", estudiante.Apellidos, DbType.String);
                parameters.Add("direccionEstudiante", estudiante.Direccion, DbType.String);
                parameters.Add("telefonoEstudiante", estudiante.Telefono, DbType.String);
                parameters.Add("correoEstudiante", estudiante.Correo, DbType.String);
                parameters.Add("idProgramaEstudiante", estudiante.id_programa, DbType.Int32);

                const string query = @"UPDATE Tienda SET nombresEstudiantes = @nombresEstudiante,
                                    apellidosEstudiante = @apellidosEstudiante,
                                    direccionEstudiante = @direccionEstudiante,
                                    telefonoEstudiante = @telefonoEstudiante,
                                    correoEstudiante = @correoEstudiante
                                    WHERE idEstudiante = @idEstudiante";

                    await conn.ExecuteAsync(query, new { estudiante.id, estudiante.Nombres, estudiante.Apellidos, estudiante.Direccion, estudiante.Telefono, estudiante.Correo, estudiante.id_programa }, commandType: CommandType.Text);
            }

            return true;
        }
    }
}
