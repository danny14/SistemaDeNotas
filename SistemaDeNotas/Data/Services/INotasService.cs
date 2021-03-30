using SistemaDeNotas.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Services
{
    public interface INotasService
    {
        Task<IEnumerable<Notas>> GetAllNotas();
        Task<Notas> GetNotasDetail(int id);
        Task<bool> NotasDelete(int idNotas);
        Task<bool> NotasInsert(Notas notas);
        Task<bool> NotasUpdate(Notas notas);
    }
}