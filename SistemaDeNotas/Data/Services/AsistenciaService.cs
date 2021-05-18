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
    public class AsistenciaService
    {
        private readonly SqlConnectionConfiguration _configuration;

        public AsistenciaService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<bool> AsistenciaInsert(Asistencia asistencia) {
            using ( var conn = new SqlConnection(_configuration.Value)) 
            {
                var parameters = new DynamicParameters();
                parameters.Add("asistenciaJUST", asistencia.asistenciaJUST, DbType.Int32);
                parameters.Add("fecha", asistencia.fecha, DbType.DateTime);
                parameters.Add("idMatricula", asistencia.idMatricula, DbType.Int32);
                parameters.Add("descripcion", asistencia.descripcion, DbType.String);

                const string query = @"INSERT INTO asistencia ( asistenciaJUST, fecha, idMatricula, descripcion) 
                VALUES (@asistenciaJUST, @fecha,@idMatricula,@descripcion,@descripcion)";

                await conn.ExecuteAsync(query, new { asistencia.asistenciaJUST, asistencia.fecha }, commandType: CommandType.Text);
            }
                return true;
        }

        public async Task<IEnumerable<Asistencia>> GetAllAsistencia()
        {
            IEnumerable<Asistencia> asistencias;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT * FROM asistencia";
                asistencias = await conn.QueryAsync<Asistencia>(query, commandType: CommandType.Text);
            }

            return asistencias;
        }

        public async Task<bool> AsistenciaDelete(int idAsistencia)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var query = @"DELETE FROM asistencia
                            WHERE idAsistencia = @id";
                await conn.ExecuteAsync(query.ToString(), new { id = idAsistencia }, commandType: CommandType.Text);
            }

            return true;
        }

        public async Task<Asistencia> GetAsistenciaDetail(int id)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {

                const string query = "SELECT * FROM asistencia WHERE idAsistencia = @Id";
                return await conn.QueryFirstOrDefaultAsync<Asistencia>(query.ToString(), new { Id = id }, commandType: CommandType.Text);
            }
        }

        public async Task<bool> AsistenciaUpdate(Asistencia asistencia)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {

                var parameters = new DynamicParameters();
                parameters.Add("asistenciaJUST", asistencia.asistenciaJUST, DbType.Int32);
                parameters.Add("fecha", asistencia.fecha, DbType.DateTime);
                parameters.Add("idMatricula", asistencia.idMatricula, DbType.Int32);
                parameters.Add("descripcion", asistencia.descripcion, DbType.String);

                const string query = @"UPDATE asistencia 
                                    SET asistenciaJUST = @asistenciaJUST,
                                    fecha = @fecha,
                                    idMatricula = @idMatricula,
                                    descripcion = @descripcion
                                    WHERE idAsistencia = @idAsistencia";

                await conn.ExecuteAsync(query, new { asistencia.asistenciaJUST, asistencia.fecha, asistencia.idMatricula, asistencia.descripcion }, commandType: CommandType.Text);
            }

            return true;
        }
    }
}
