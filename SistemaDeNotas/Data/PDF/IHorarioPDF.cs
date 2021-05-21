using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeNotas.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeNotas.Data.PDF
{
    interface IHorarioPDF
    {
        FileResult descargarPDF();
        Task GeneraFactura(horario horario, IEnumerable<horario> horarios);
    }
}
