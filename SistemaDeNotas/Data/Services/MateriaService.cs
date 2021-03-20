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
    public class MateriaService
    {
        private readonly SqlConnectionConfiguration _configuration;

        public MateriaService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> MateriaInsert(materia materia)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("idMateria", materia.id, DbType.Int32);
                parameters.Add("nombreMateria", materia.nombre, DbType.String);
                parameters.Add("cupoMateria", materia.cupo, DbType.Int32);
                parameters.Add("idProfesorMateria", materia.id_profesor, DbType.Int32);

                const string query = @"INSERT INTO materia (id, nombre, cupo, id_profesor) 
                VALUES (@idMateria, @nombreMateria, @cupoMateria,@idProfesorMateria)";

                await conn.ExecuteAsync(query, new { materia.id, materia.nombre, materia.cupo, materia.id_profesor }, commandType: CommandType.Text);
            }
            return true;
        }

        public async Task<IEnumerable<materia>> GetAllMateria()
        {
            IEnumerable<materia> materias;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "";
                materias = await conn.QueryAsync<materia>(query, commandType: CommandType.Text);
            }

            return materias;
        }
    }
}
