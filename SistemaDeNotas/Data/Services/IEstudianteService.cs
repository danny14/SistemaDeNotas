using SistemaDeNotas.Data.Model;
using SistemaDeNotas.Data.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Services
{
    public interface IEstudianteService
    {
        Task<bool> EstudianteInsert(estudiante estudiante);

        Task<IEnumerable<estudiante>> GetAllEstudiante();
    }
}