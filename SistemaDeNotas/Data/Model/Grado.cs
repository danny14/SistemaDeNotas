using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class Grado
    {

        public int idGrado { get; set; }

        public  string nombreGrado { get; set; }
        public string idEstudiante { get; set; }

        public Estudiante estudiante { get; set; }

    }
}
