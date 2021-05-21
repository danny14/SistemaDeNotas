using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeNotas.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeNotas.Data.PDF
{
    public interface IHorarioPDF
    {
        Task GeneraFactura(IEnumerable<horario> horarios);
        FileResult descargarPDF();
    }
}
