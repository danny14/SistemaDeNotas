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
    public class ListadoEstudianteProfesorService : IListadoEstudianteProfesorService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public ListadoEstudianteProfesorService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<ListadoEstudianteProfesor>> GetAllEstudiantesDelProfesorA(int id)
        {
            IEnumerable<ListadoEstudianteProfesor> estudiantes;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT estudiante.nombresEstudiante, estudiante.apellidosEstudiante, materia.nombreMateria FROM estudiante, materia, profesores, notas WHERE notas.idEstudiante = estudiante.idEstudiante AND notas.idMateria = materia.idMateria AND materia.idProfesor = profesores.idProfesor AND profesores.idProfesor = @Id";
                estudiantes = await conn.QueryAsync<ListadoEstudianteProfesor>(query, new {  Id = id }, commandType: CommandType.Text);
            }

            return estudiantes;
        }

    }
}
