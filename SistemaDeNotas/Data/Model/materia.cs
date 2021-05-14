﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class Materia
    {
        public int idMateria { get; set; }
        public int idProfesor { get; set; }

        public string nombreMateria { get; set; }
        public string dia { get; set; }
        public DateTime hora { get; set; }
        public Profesores profe;
    }
}
