using SistemaDeNotas.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Services
{
    public interface IPeriodoService
    {
        Task<IEnumerable<periodo>> GetAllPeriodo();
    
    }
}
