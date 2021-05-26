using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeNotas.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeNotas.Data.PDF
{
    interface IAsistenciaPDF
    {
        Task GeneraPdf(IEnumerable<Asistencia> asistencias);
        FileResult descargarPDF();
    }
}
