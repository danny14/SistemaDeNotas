using SistemaDeNotas.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Services
{
    public interface IMateriaService
    {
        Task<IEnumerable<profesormateria>> GetAllMaterias();
        Task<Materia> GetMateriaDetail(int id);
        Task<bool> MateriaDelete(int idMateria);
        Task<bool> MateriaInsert(Materia materia);
        Task<bool> MateriaUpdate(Materia materia);
    }
}