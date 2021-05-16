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
                parameters.Add("idNotas", notas.idNotas, DbType.Int32);//QUITAR EL ID Y LOS QUE NO SE DEBEN DE CAMBIAR
                parameters.Add("nota1", notas.nota1, DbType.Single);
                parameters.Add("nota2", notas.nota2, DbType.Single);
                parameters.Add("nota3", notas.nota3, DbType.Single);
                parameters.Add("promedioNotas", notas.promedioNotas, DbType.Single);
                parameters.Add("idEstudiante", notas.idEstudiante, DbType.Int32);
                parameters.Add("idMateria", notas.idMateria, DbType.Int32);
                parameters.Add("idPeriodo", notas.idPeriodo, DbType.Int32);


                const string query = @"INSERT INTO notas (idNotas, nota1, nota2, nota3) 
                VALUES ( @idNotas, @nota1, @nota2, @nota3)";

                await conn.ExecuteAsync(query, new {notas.idNotas, notas.nota1, notas.nota2, notas.nota3},
                    commandType: CommandType.Text);
            }

            return true;
        }

        public async Task<bool> InsertarEstudiante(int idMateria, int idPeriodo)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("idNotas", notas.idNotas, DbType.Int32);//QUITAR EL ID Y LOS QUE NO SE DEBEN DE CAMBIAR
                parameters.Add("nota1", notas.nota1, DbType.Single);
                parameters.Add("nota2", notas.nota2, DbType.Single);
                parameters.Add("nota3", notas.nota3, DbType.Single);
                parameters.Add("promedioNotas", notas.promedioNotas, DbType.Single);
                parameters.Add("idEstudiante", notas.idEstudiante, DbType.Int32);
                parameters.Add("idMateria", notas.idMateria, DbType.Int32);
                parameters.Add("idPeriodo", notas.idPeriodo, DbType.Int32);


                const string query = @"INSERT INTO notas (idNotas, nota1, nota2, nota3) 
                VALUES ( @idNotas, @nota1, @nota2, @nota3)";

                await conn.ExecuteAsync(query, new { notas.idNotas, notas.nota1, notas.nota2, notas.nota3 },
                    commandType: CommandType.Text);
            }

            return true;
        }
        /**
         * Obtener todas las notas 
        **/


        public async Task<IEnumerable<notaestudiante>> GetAllNotas()
         {
        IEnumerable<notaestudiante> notas;
       using (var conn = new SqlConnection(_configuration.Value))
       {
                const string query = @"SELECT estudiante.idEstudiante, estudiante.nombresEstudiante, estudiante.apellidosEstudiante, notas.nota1, notas.nota2, notas.nota3, notas.promedioNotas
FROM estudiante, notas
WHERE estudiante.idEstudiante = notas.idNotas";
                notas = await conn.QueryAsync<notaestudiante>(query, commandType: CommandType.Text);
                 
                
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
        /**
         * Metodo para obtener Promedio de Notas por grado 
        */
        public async Task<Notas> GetNotasPorPromedio(int idGrado)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT AVG (promedioNotas) AS PromedioNotas,materia.nombreMateria as NombreMateria FROM notas, materia WHERE notas.idMateria = materia.idMateria GROUP BY materia.nombreMateria";
                return await conn.QueryFirstAsync<Notas>(query.ToString(), new { idGrado = idGrado }, commandType: CommandType.Text);
            }
                
        }



        /**
         * Metodo para obtener Promedio de Notas por estudiante
        */
        public async Task<Notas> GetNotasPorMateria(int idMateria)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT AVG (promedioNotas) AS PromedioNotas,estudiante.nombresEstudiante FROM notas, estudiante WHERE notas.idEstudiante = estudiante.idEstudiante GROUP BY estudiante.nombresEstudiante";
                return await conn.QueryFirstAsync<Notas>(query.ToString(), new { idMateria = idMateria }, commandType: CommandType.Text);
            }

        }


        protected SqlConnection dbConnection()
        {
            return new SqlConnection(_configuration.Value);
        }


        /*
         * Metodo para actualizar una nota
         */
       
public async Task<bool> NotasUpdate(Notas notas)
        {
            var db = dbConnection();
            var sql = @"UPDATE notas SET nota1 = @nota1, 
                nota2 = @nota2, 
                    nota3 = @nota3
                     WHERE idNotas = @idNotas";

            var result = await db.ExecuteAsync(sql.ToString(), new { notas.nota1, notas.nota2, notas.nota3, notas.idNotas });
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
