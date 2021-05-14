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
    public class MateriaService : IMateriaService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public MateriaService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        /*
         * Insertar un Estudiante
         */
        public async Task<bool> MateriaInsert(Materia materia)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("NombreMateria", materia.nombreMateria, DbType.String);
                parameters.Add("idProfesor", materia.idProfesor, DbType.Int32);


                const string query = @"INSERT INTO materia ( NombreMateria, idProfesor ) 
                VALUES ( @NombreMateria, @idProfesor )";

                await conn.ExecuteAsync(query, new { materia.nombreMateria, materia.idProfesor }, commandType: CommandType.Text);
            }

            return true;
        }


        /**
         * Obtener todos los estudiantes 
        **/
        public async Task<IEnumerable<profesormateria>> GetAllMaterias()
        {
            IEnumerable<profesormateria> materia;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"SELECT materia.idMateria, materia.nombreMateria, profesores.nombreProfesor, profesores.apellidoProfesor, materia.dia, materia.hora
                                        FROM profesores, materia
                                            WHERE p.idProfesor = m.idMateria";
                materia = await conn.QueryAsync<profesormateria>(query, commandType: CommandType.Text);
            }

            return materia;
        }


        /**
         * Eliminar una Materia
         */
        public async Task<bool> MateriaDelete(int idMateria)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var query = @"DELETE FROM materia
                            WHERE idMateria = @idMateria";
                await conn.ExecuteAsync(query.ToString(), new { idMateria = idMateria }, commandType: CommandType.Text);
            }

            return true;
        }


        /**
         * Obtener un Materia por ID 
        **/
        public async Task<Estudiante> GetMateriaDetail(int id)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {

                const string query = "SELECT * FROM materia WHERE idMateria = @Id";
                return await conn.QueryFirstOrDefaultAsync<Estudiante>(query.ToString(), new { Id = id }, commandType: CommandType.Text);
            }
        }

        /*
         * Metodo para actualizar una Materia 
         */
        public async Task<bool> MateriaUpdate(Materia materia)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {

                var parameters = new DynamicParameters();

                parameters.Add("nombreMateria", materia.nombreMateria, DbType.String);
                parameters.Add("idProfer", materia.idProfesor, DbType.Int32);

                const string query = @"UPDATE materia SET nombreMateria = @nombreMateria,
                                    idProfesor = @idProfesor
                                    WHERE idMateria = @idMateria";

                await conn.ExecuteAsync(query, new { materia.nombreMateria, materia.idProfesor }, commandType: CommandType.Text);
            }

            return true;
        }

        Task<Materia> IMateriaService.GetMateriaDetail(int id)
        {
            throw new NotImplementedException();
        }
    }
}
