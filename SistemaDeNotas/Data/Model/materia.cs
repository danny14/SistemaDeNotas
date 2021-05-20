using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class Materia
    {
        public int idMateria { get; set; }
        public int idProfesor { get; set; }

        public string nombreMateria { get; set; }
        public string diaMateria { get; set; }
        public  TimeSpan hora { get; set; }
        public int idGrado { get; set; }



        public string nombreGrado { get; set; }
        public string idMatricula { get; set; }
        public Grado grado;

        public Grado GetGrado()
        {
            grado = new Grado();
            grado.idGrado = idGrado;
            grado.nombreGrado = nombreGrado;
            grado.idMatricula = idMatricula;
            return grado;
        }

    }
}
