using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class matricula
    {
        public int idMatricula { get; set; }
        public int idEstudiante { get; set; }
        public DateTime fechaMatricula { get; set; }
        public int idPeriodo { get; set; }
        public int idMateria { get; set; }
        public int nota1 { get; set; }
        public int nota2 { get; set; }
        public int nota3 { get; set; }
        public string NombresEstudiante { get; set; }

        public string ApellidosEstudiante { get; set; }

        public Estudiante estudiantito;
        public Estudiante GetEstudiante()
        {
            estudiantito = new Estudiante();
            estudiantito.idEstudiante = idEstudiante;
            estudiantito.idEstudiante = idEstudiante;
            estudiantito.NombresEstudiante = NombresEstudiante;
            estudiantito.ApellidosEstudiante = ApellidosEstudiante;
            return estudiantito;
        }


    }
}
