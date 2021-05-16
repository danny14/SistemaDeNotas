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
    public class MatriculaService : IMatriculaService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public MatriculaService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        /*
         * Insertar una nota
         */
        public async Task<bool> NotasInsert(matricula notas)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
               


                const string query = @"INSERT INTO matricula (idMatricula, nota1, nota2, nota3) 
                VALUES ( @idMatricula, @nota1, @nota2, @nota3)";

                await conn.ExecuteAsync(query, new {},
                    commandType: CommandType.Text);
            }

            return true;
        }

        public async Task<bool> InsertarEstudiante(int idMateria, int idPeriodo)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
              


                const string query = @"INSERT INTO matricula (idMatricula, nota1, nota2, nota3) 
                VALUES ( @idMatricula, @nota1, @nota2, @nota3)";

                await conn.ExecuteAsync(query, new {  },
                    commandType: CommandType.Text);
            }

            return true;
        }
        /**
         * Obtener todas las notas 
        **/


        public async Task<IEnumerable<matricula>> GetAllNotas()
         {
        IEnumerable<matricula> notas;
       using (var conn = new SqlConnection(_configuration.Value))
       {
                const string query = @"SELECT estudiante.idEstudiante, estudiante.nombresEstudiante, estudiante.apellidosEstudiante, matricula.nota1, matricula.nota2, matricula.nota3
FROM estudiante, matricula
WHERE estudiante.idEstudiante = matricula.idMatricula";
                notas = await conn.QueryAsync<matricula>(query, commandType: CommandType.Text);
                 
                
        }
           


            return notas;
         }

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
         * Eliminar una Nota
         */
        public async Task<bool> NotasDelete(int idMatricula)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var query = @"DELETE FROM matricula
                            WHERE idMatricula = @idMatricula";
                await conn.ExecuteAsync(query.ToString(), new { idMatricula = idMatricula }, commandType: CommandType.Text);
            }

            return true;
        }


        /**
         * Obtener un Materia por ID 
        **/
        public async Task<matricula> GetNotasDetail(int id)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {

                const string query = "SELECT * FROM matricula WHERE idMatricula = @Id";
                return await conn.QueryFirstOrDefaultAsync<matricula>(query.ToString(), new { Id = id }, commandType: CommandType.Text);
            }
        }
        /**
         * Metodo para obtener Promedio de Notas por grado 
        */
        public async Task<matricula> GetNotasPorPromedio(int idGrado)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
               const string query = "SELECT * FROM matricula";
                return await conn.QueryFirstAsync<matricula>(query.ToString(), new { idGrado = idGrado }, commandType: CommandType.Text);
                //const string query = "SELECT AVG (promedioNotas) AS PromedioNotas,materia.nombreMateria as NombreMateria FROM matricula, materia WHERE matricula.idMateria = materia.idMateria GROUP BY materia.nombreMateria";
            }

        }



        /**
         * Metodo para obtener Promedio de Notas por estudiante
        */
        public async Task<matricula> GetNotasPorMateria(int idMateria)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT * FROM matricula";
                return await conn.QueryFirstAsync<matricula>(query.ToString(), new { idMateria = idMateria }, commandType: CommandType.Text);
            }

        }


        protected SqlConnection dbConnection()
        {
            return new SqlConnection(_configuration.Value);
        }


        /*
         * Metodo para actualizar una nota
         */
       
public async Task<bool> NotasUpdate(matricula notas)
        {
            var db = dbConnection();
            var sql = @"UPDATE matricula SET nota1 = @nota1, 
                nota2 = @nota2, 
                    nota3 = @nota3
                     WHERE idMatricula = @idMatricula";

            var result = await db.ExecuteAsync(sql.ToString(), new { });
            return result > 0;
            //using (var conn = new SqlConnection(_configuration.Value))
            //{

            //var parameters = new DynamicParameters();
            //parameters.Add("idNotas", notas.idNotas, DbType.Int32);
            //parameters.Add("nota1", notas.nota1, DbType.Single);
            //parameters.Add("nota2", notas.nota2, DbType.Single);
            //parameters.Add("nota3", notas.nota3, DbType.Single);
            // parameters.Add("promedioNotas", notas.promedioNotas, DbType.Single);
            //parameters.Add("idEstudiante", notas.idEstudiante, DbType.Int32);
            //  parameters.Add("idMateria", notas.idMateria, DbType.Int32);


            //}

            // return true;
            }

        }


}
