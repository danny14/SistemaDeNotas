using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class notaestudiante
    {
        public int idEstudiante { get; set; }
        public int idNotas { get; set; }
        public string NombresEstudiante { get; set; }

        public string ApellidosEstudiante { get; set; }
        public float nota1 { get; set; }

        public float nota2 { get; set; }

        public float nota3 { get; set; }

        public float promedioNotas { get; set; }

        public Estudiante estudiantito;
        public Notas noticas;
        public Estudiante GetEstudiante()
        {
            estudiantito = new Estudiante();
            estudiantito.idEstudiante = idEstudiante;
            estudiantito.NombresEstudiante = NombresEstudiante;
            estudiantito.ApellidosEstudiante = ApellidosEstudiante;
            return estudiantito;
        }
        public Notas GetNotas()
        {
            noticas = new Notas();
            noticas.idNotas = idNotas;
            noticas.nota1 = nota1;
            noticas.nota2 = nota2;
            noticas.nota3 = nota3;
            noticas.promedioNotas = promedioNotas;
            return noticas;
        }
        
    }
}
