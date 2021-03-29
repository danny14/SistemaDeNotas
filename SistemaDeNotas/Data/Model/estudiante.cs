using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class Estudiante
    {
        public int idEstudiante { get; set; }
        public string NombresEstudiante { get; set; }

        public string Apellidos { get; set; }
        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public int id_programa { get; set; }
    }
}
