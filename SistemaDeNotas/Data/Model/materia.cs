using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class Materia
    {
        public int idMateria { get; set; }
      
        public string nombreMateria { get; set; }
        public string diaMateria { get; set; }
        public DateTime horaMateria { get; set; }
        public int idProfesor { get; set; }
    }
}
