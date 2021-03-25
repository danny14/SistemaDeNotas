using SistemaDeNotas.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Services
{
    public interface IMateriaService
    {
        Task<bool> DeleteMateria(int id);
        Task<IEnumerable<Materia>> GetAllMateria();
        Task<bool> GetMateriaDetail(int id);
        Task<bool> MateriaInsert(Materia materia);
        Task<bool> UpdateMateria(Materia materia);
    }
}