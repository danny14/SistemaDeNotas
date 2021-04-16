using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class profesor_grado
    {
        public int idProfesor_grado { get; set; }
        public int idProfesor { get; set; }
        public int idGrado { get; set; }
    }
}
