using SistemaDeNotas.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Services
{
    public interface IAsistenciaService
    {
        Task<bool> AsistenciaDelete(int idAsistencia);
        Task<bool> AsistenciaInsert(Asistencia asistencia);
        Task<bool> AsistenciaUpdate(Asistencia asistencia);
        Task<IEnumerable<Asistencia>> GetAllAsistencia();
        Task<Asistencia> GetAsistenciaDetail(int id);
    }
}