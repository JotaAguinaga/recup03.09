using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recuperatorio
{
    public class Administrativo : Empleado
    {
        public int Antiguedad { get; set; }

        public Administrativo(string nombre, string dni, double sueldoBase, int antiguedad)
            : base(nombre, dni, sueldoBase)
        {
            Antiguedad = antiguedad;
        }

        public override double CalcularSueldoFinal()
        {
            return SueldoBase + (Antiguedad * 1000);
        }
    }
}


