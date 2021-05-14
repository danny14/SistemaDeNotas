using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class Notas
    {
        public int idNotas { get; set; }

        public float nota1 { get; set; }

        public float nota2 { get; set; }

        public float nota3 { get; set; }

        public float promedioNotas { get; set; }

        public int idEstudiante { get; set; }

        public int idMateria { get; set; }
        public int idPeriodo { get; set;  }
        public Estudiante estudiantito { get; set; }

        public Estudiante GetEstudiante()
        {
            estudiantito = new Estudiante();
            estudiantito.idEstudiante = idEstudiante;
            estudiantito.NombresEstudiante = estudiantito.NombresEstudiante;
            estudiantito.ApellidosEstudiante = estudiantito.ApellidosEstudiante;
            estudiantito.DireccionEstudiante = estudiantito.DireccionEstudiante;
            estudiantito.TelefonoEstudiante = estudiantito.TelefonoEstudiante;
            estudiantito.CorreoEstudiante = estudiantito.CorreoEstudiante;

            return estudiantito;

        }
    }
}
