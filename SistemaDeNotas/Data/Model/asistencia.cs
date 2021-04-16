using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class asistencia
    {
        public int idAsistencia { get; set; }
        public string asistenciaINJ { get; set; }
        public string asistenciaJUST { get; set; }
        public int idEstudiante { get; set; }
    }
}
