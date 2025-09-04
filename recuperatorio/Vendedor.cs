using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recuperatorio
{
    public class Vendedor : Empleado
    {
        public double MontoVentasMensuales { get; set; }

        public Vendedor(string nombre, string dni, double sueldoBase, double montoVentasMensuales)
            : base(nombre, dni, sueldoBase)
        {
            MontoVentasMensuales = montoVentasMensuales;
        }

        public override double CalcularSueldoFinal()
        {
            return SueldoBase + (MontoVentasMensuales * 0.10);
        }
    }
}

