﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Data.Model
{
    public class materia
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public int cupo { get; set; }

        public int id_profesor { get; set; }
    }
}
