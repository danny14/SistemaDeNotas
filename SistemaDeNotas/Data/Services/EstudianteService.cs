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

        public async Task<bool> EstudianteInsert(estudiante estudiante)
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

        public Task<IEnumerable<estudiante>> GetAllEstudiante()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<estudiante>> GetAllEstudiantes()
        {
            IEnumerable<estudiante> estudiantes;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT * FROM estudiante";
                estudiantes = await conn.QueryAsync<estudiante>(query, commandType: CommandType.Text);
            }

            return estudiantes;
        }
    }
}
