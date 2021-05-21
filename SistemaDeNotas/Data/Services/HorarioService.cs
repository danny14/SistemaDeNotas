﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;
using System.Data;
using SistemaDeNotas.Data.Model;
using System.Data.SqlClient;

namespace SistemaDeNotas.Data.Services
{
    public class HorarioService : IHorarioService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public HorarioService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<horario>> GetHorario()
        {
            IEnumerable<horario> horario;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT * FROM horario";
                horario = await conn.QueryAsync<horario>(query, commandType: CommandType.Text);
            }

            return horario;
        }
    }
}
