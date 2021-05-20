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

        //materia


        public string nombreMateria { get; set; }
        public string diaMateria { get; set; }
        public TimeSpan hora { get; set; }
        public int idGrado { get; set; }


        public Profesores profe;
        public periodo periodo;
        public Materia materia;

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
        public Materia GetMateria()
        {
            materia = new Materia();
            materia.idMateria = idMateria;
            materia.nombreMateria = nombreMateria;
            materia.diaMateria = diaMateria;
            materia.hora = hora;
            materia.idGrado = idGrado;
            return materia;
        }
    }
       
}
