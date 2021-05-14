using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class profesormateria
    {
        public int idProfesor { get; set; }
        public int idMateria { get; set; }
        public string nombreProfesor { get; set; }

        public string apellidoProfesor { get; set; }
        

        public string nombreMateria { get; set; }
        public string dia { get; set; }
        public DateTime hora { get; set; }


        public Profesores profe;
        public Materia mate;
        public Profesores GetProfesores()
        {
            profe = new Profesores();
            profe.idProfesor = idProfesor;
            profe.nombreProfesor = nombreProfesor;
            profe.apellidoProfesor = apellidoProfesor;
            return profe;
        }
      
        public Materia GetMateria()
        {
            mate = new Materia();
            mate.idMateria = idMateria;
            mate.nombreMateria = nombreMateria;
            mate.dia = dia;
            mate.hora = hora;
            return mate;
    }
}
}
