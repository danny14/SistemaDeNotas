using SistemaDeNotas.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Services
{
    public interface IProfesoresService
    {
        Task<IEnumerable<Profesores>> GetAllProfesor();
        Task<Profesores> GetProfesorDetail(int id);
        Task<bool> ProfesorDelete(int idProfesor);
        Task<bool> ProfesorInsert(Profesores profesor);
        Task<bool> ProfesorUpdate(Profesores profesor);
    }
}