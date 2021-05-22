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
        public async Task GeneraPdf(IEnumerable<horario> horarios)
        {
            string destination = "wwwroot/FilePdf/FileSystem.pdf";
            FileInfo file = new FileInfo(destination);
            file.Delete();
            var fileStream = file.Create();
            fileStream.Close();
            PdfDocument pdfdoc = new PdfDocument(new PdfWriter(file));
            pdfdoc.SetTagged();

            //Escribiendo en el Documento
            using (Document document = new Document(pdfdoc))
            {
                document.Add(new Paragraph("Horario de clases" ));
           
                document.Add(new Paragraph(" "));
        
                float[] columnWidths = new float[] { 70f, 70f, 70f, 70f, 70f, 70f };
                Table table = new Table(columnWidths);
                Cell cell = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.CYAN)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("HORA"));
                table.AddCell(cell);
                cell = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.CYAN)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("LUNES"));
                table.AddCell(cell);
                cell = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.CYAN)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("MARTES"));
                table.AddCell(cell);
                cell = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.CYAN)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("MIERCOLES"));
                table.AddCell(cell);
                cell = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.CYAN)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("JUEVES"));
                table.AddCell(cell);
                cell = new Cell(1, 1)
                   .SetBackgroundColor(ColorConstants.CYAN)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph("VIERNES"));
                table.AddCell(cell);
                document.Add(table);

                foreach (var horario in horarios)
                {
                    table = new Table(columnWidths);
                    table.AddCell(horario.dia);
                    table.AddCell(horario.nombreMateria);
                    table.AddCell(horario.horaInicio.ToString());
                    table.AddCell(horario.horaFinal.ToString());
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
            return File(fileBytes, "wwwroot/FilePdf", "FacturaSystem.pdf");
        }


    }
}
