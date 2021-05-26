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
    public class AsistenciaPDF : PageModel, IAsistenciaPDF
    {
        private readonly IWebHostEnvironment _env;

        public AsistenciaPDF(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task GeneraPdf(IEnumerable<Asistencia> asistencias)
        {
            string destination = "wwwroot/FilePdf/asistencia.pdf";
            FileInfo file = new FileInfo(destination);
            file.Delete();
            var fileStream = file.Create();
            fileStream.Close();
            PdfDocument pdfdoc = new PdfDocument(new PdfWriter(file));
            pdfdoc.SetTagged();

            //Escribiendo en el Documento
            using (Document document = new Document(pdfdoc))
            {
                document.Add(new Paragraph("Asistencia estudiantil" ));
           
                document.Add(new Paragraph(" "));
        
                float[] columnWidths = new float[] { 70f, 70f, 70f, 70f };
                Table table = new Table(columnWidths);
                Cell cell = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.CYAN)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("id"));
                table.AddCell(cell);
                cell = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.CYAN)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("nombre"));
                table.AddCell(cell);
                cell = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.CYAN)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("asistencia"));
                table.AddCell(cell);
                cell = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.CYAN)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("descripcion"));
                table.AddCell(cell);
                document.Add(table);

                foreach (var asiten in asistencias)
                {
                    table = new Table(columnWidths);
                    table.AddCell(asiten.idEstudiante.ToString());
                    table.AddCell(asiten.nombresEstudiante);
                    table.AddCell(asiten.asistenciaJUST.ToString());
                    table.AddCell(asiten.descripcion);
                    document.Add(table);
                }

                document.Close();
            }

            descargarPDF();
        }


        public FileResult descargarPDF()
        {
            var filePath = Path.Combine(_env.ContentRootPath, "wwwroot/FilePdf", "FacturaSystem.pdf");
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "wwwroot/FilePdf", "asistencia.pdf");
        }


    }
}
