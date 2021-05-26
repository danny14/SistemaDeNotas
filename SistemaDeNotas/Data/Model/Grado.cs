using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class Grado
    {

        public int idGrado { get; set; }

        public  string nombreGrado { get; set; }
        public string idMatricula { get; set; }


        //profe
        public int idProfesor { get; set; }

        public string nombreProfesor { get; set; }

        public string apellidoProfesor { get; set; }

        public Profesores profe;
        public Profesores GetProfesores()
        {
            profe = new Profesores();
            profe.idProfesor = idProfesor;
            profe.nombreProfesor = nombreProfesor;
            profe.apellidoProfesor = apellidoProfesor;
            return profe;
        }
    

    }
}
