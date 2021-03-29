using SistemaDeNotas.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Services
{
    public interface IEstudianteService
    {
        // Insertar Estudiante
        Task<bool> EstudianteInsert(Estudiante estudiante);
        //Obtener todos los estudiantes
        Task<IEnumerable<Estudiante>> GetAllEstudiantes();
        //obtener un estudiante por ID
        Task<Estudiante> GetEstudianteDetail(int id);

        //actualizar estudiante
        Task<bool> EstudianteUpdate(Estudiante estudiante);
        // Eliminar estudiante
        Task<bool> EstudianteDelete(int id);
    }
}