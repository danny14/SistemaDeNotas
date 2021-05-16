using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class asistencia
    {
        public int idAsistencia { get; set; }
       
        public int asistenciaJUST { get; set; }
        public DateTime fecha { get; set; }
        public int idMatricula { get; set; }
        public string descripcion { get; set; }
    }
}
