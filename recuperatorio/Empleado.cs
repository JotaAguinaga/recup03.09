using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recuperatorio
    {
        public abstract class Empleado
        {
            public string Nombre { get; set; }
            public string Dni { get; set; }
            public double SueldoBase { get; set; }

            public Empleado(string nombre, string dni, double sueldoBase)
            {
                Nombre = nombre;
                Dni = dni;
                SueldoBase = sueldoBase;
            }

            public abstract double CalcularSueldoFinal();
        }
    }


