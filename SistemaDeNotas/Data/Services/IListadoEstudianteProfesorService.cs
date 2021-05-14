using SistemaDeNotas.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Services
{
    public interface IListadoEstudianteProfesorService
    {
        Task<IEnumerable<ListadoEstudianteProfesor>> GetAllEstudiantesDelProfesorA(int id);
    }
}