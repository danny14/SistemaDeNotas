using SistemaDeNotas.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Services
{
    public interface IMatriculaService
    {
        Task<IEnumerable<matricula>> GetAllNotas();
        Task<matricula> GetNotasDetail(int id);
        Task<bool> NotasDelete(int idMatricula);
        Task<bool> NotasInsert(matricula notas);
        Task<bool> NotasUpdate(matricula notas);
    }
}