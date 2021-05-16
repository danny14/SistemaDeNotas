using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class horario
    {

        public int idHorario { get; set; }
        public int idPeriodo { get; set; }
        public int idProfesor { get; set; }

        public string dia { get; set; }

        public TimeSpan horaInicio { get; set; }

        public TimeSpan horaFinal { get; set; }

        //grado
        public int idMateria { get; set; }
    }
       
}
