﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class profesores
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string direccion { get; set; }

        public string telefono { get; set; }

        public string correo { get; set; }
    }
}
