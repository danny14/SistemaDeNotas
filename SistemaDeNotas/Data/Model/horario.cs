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

       public int idMateria { get; set; }

        //profe
        public string nombreProfesor { get; set; }

        public string apellidoProfesor { get; set; }

        //periodo
        public string nombrePeriodo { get; set; }
        public int anio { get; set; }

        public Profesores profe;
        public periodo periodo;

        public Profesores GetProfesores()
        {
            profe = new Profesores();
            profe.idProfesor = idProfesor;
            profe.nombreProfesor = nombreProfesor;
            profe.apellidoProfesor = apellidoProfesor;
            return profe;
        }
        public periodo GetPeriodo()
        {
            periodo = new periodo();
            periodo.idPeriodo = idPeriodo;
            periodo.nombrePeriodo = nombrePeriodo;
            periodo.anio = anio;
            return periodo;
        }
    }
       
}
