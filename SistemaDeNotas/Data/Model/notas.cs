using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class Notas
    {
        public int id { get; set; }

        public int nota1 { get; set; }

        public int nota2 { get; set; }

        public int nota3 { get; set; }

        public int promedio { get; set; }

        public int id_alumno { get; set; }

        public int id_materia { get; set; }
    }
}
