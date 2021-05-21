using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using iText.Layout;
using iText.Layout.Element;
using System.IO;
using iText.Kernel.Pdf;
using SistemaDeNotas.Data.Model;
using SistemaDeNotas.Data.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using iText.Kernel.Colors;
using iText.Layout.Properties;

namespace SistemaDeNotas.Data.PDF
{
    public class HorarioPDF : PageModel, IHorarioPDF
    {
        private readonly IWebHostEnvironment _env;

        public HorarioPDF(IWebHostEnvironment env)
        {
            _env = env;
        }
        public Task GeneraFactura(IEnumerable<horario> horarios)
        {
            string destination = "wwwroot/FilePdf/FacturaSystem.pdf";
            FileInfo file = new FileInfo(destination);
            file.Delete();
            var fileStream = file.Create();
            fileStream.Close();
            PdfDocument pdfdoc = new PdfDocument(new PdfWriter(file));
            pdfdoc.SetTagged();

            //Escribiendo en el Documento
            using (Document document = new Document(pdfdoc))
            {
                document.Add(new Paragraph("FACTURA DE VENTA No:"));
                document.Add(new Paragraph("Identificación del Cliente:"));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" DETALLE DE LA FACTURA "));
                float[] columnWidths = new float[] { 70f, 200f, 70f, 70f };
                Table table = new Table(columnWidths);
                Cell cell = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.GRAY)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("Código:"));
                table.AddCell(cell);
                cell = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.GRAY)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("Nombre Producto:"));
                table.AddCell(cell);
                cell = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.GRAY)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("Valor:"));
                table.AddCell(cell);
                cell = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.GRAY)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("Cantidad:"));
                table.AddCell(cell);
                document.Add(table);

                foreach (var horario in horarios)
                {
                    table = new Table(columnWidths);
                    table.AddCell(horario.idHorario.ToString());
                    table.AddCell(horario.dia);
                   document.Add(table);
                }

                document.Close();
            }

            descargarPDF();
            return Task.CompletedTask;
        }

        public FileResult descargarPDF()
        {
            var filePath = Path.Combine(_env.ContentRootPath, "wwwroot/FilePdf", "FacturaSystem.pdf");
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "wwwroot/FilePdf", "FacturaSystem.pdf");
        }

    
    }
}
