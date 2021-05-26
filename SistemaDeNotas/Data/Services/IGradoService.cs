using SistemaDeNotas.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Services
{
    public interface IGradoService
    {
        Task<IEnumerable<Grado>> GetAllGrados();
        Task<Grado> GetGradoDetail(int id);
        Task<bool> GradoDelete(int idGrado);
        Task<bool> GradoInsert(Grado grado);
        Task<bool> GradoUpdate(Grado grado);
        Task<IEnumerable<Grado>> GetPeriodoGrado(int id);
        Task<IEnumerable<Grado>> GetGradoProfesor(int id);
    }
}