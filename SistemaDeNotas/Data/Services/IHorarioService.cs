using System;

using SistemaDeNotas.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace SistemaDeNotas.Data.Services
{
    interface IHorarioService
    {
        Task<IEnumerable<horario>> GetHorario();
    }
}
