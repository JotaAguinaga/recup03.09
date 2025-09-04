using System;
using System.Collections.Generic;
using recuperatorio; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace consola
{
    internal class Program
    {
        static void Main(string[] args)
         
        {
            List<Empleado> empleados = new List<Empleado>();
            bool seguir = true;

            while (seguir)
            {
                Console.WriteLine("\n1. Registrar empleado");
                Console.WriteLine("2. Mostrar información de un empleado");
                Console.WriteLine("3. Mostrar todos y estadísticas");
                Console.WriteLine("4. Salir");
                Console.Write("Opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("1. Administrativo");
                        Console.WriteLine("2. Vendedor");
                        string tipo = Console.ReadLine();

                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("DNI: ");
                        string dni = Console.ReadLine();

                        // evitar duplicados
                        bool existe = false;
                        foreach (Empleado e in empleados)
                        {
                            if (e.Dni == dni) existe = true;
                        }
                        if (existe)
                        {
                            Console.WriteLine("Ese DNI ya existe, intente con otro.");
                            break;
                        }

                        Console.Write("Sueldo base: ");
                        double sueldo = double.Parse(Console.ReadLine());

                        if (tipo == "1")
                        {
                            Console.Write("Antigüedad: ");
                            int antig = int.Parse(Console.ReadLine());
                            empleados.Add(new Administrativo(nombre, dni, sueldo, antig));
                        }
                        else if (tipo == "2")
                        {
                            Console.Write("Ventas mensuales: ");
                            double ventas = double.Parse(Console.ReadLine());
                            empleados.Add(new Vendedor(nombre, dni, sueldo, ventas));
                        }
                        else
                        {
                            Console.WriteLine("Tipo inválido");
                        }
                        break;

                    case "2":
                        Console.Write("Ingrese DNI: ");
                        string buscarDni = Console.ReadLine();
                        Empleado encontrado = null;
                        foreach (Empleado e in empleados)
                        {
                            if (e.Dni == buscarDni) encontrado = e;
                        }
                        if (encontrado != null)
                        {
                            string tipoE = encontrado is Administrativo ? "Administrativo" : "Vendedor";
                            Console.WriteLine($"Nombre: {encontrado.Nombre}, Tipo: {tipoE}, Sueldo Final: {encontrado.CalcularSueldoFinal()}");
                        }
                        else
                        {
                            Console.WriteLine("Empleado no encontrado");
                        }
                        break;

                    case "3":
                        double totalSueldos = 0;
                        int cantAdmin = 0;
                        int cantVend = 0;

                        foreach (Empleado e in empleados)
                        {
                            string tipoE = e is Administrativo ? "Administrativo" : "Vendedor";
                            Console.WriteLine($"Nombre: {e.Nombre}, DNI: {e.Dni}, Tipo: {tipoE}, Sueldo Final: {e.CalcularSueldoFinal()}");

                            totalSueldos += e.CalcularSueldoFinal();
                            if (tipoE == "Administrativo") cantAdmin++;
                            else cantVend++;
                        }

                        Console.WriteLine($"\nTotal empleados: {empleados.Count}");
                        Console.WriteLine($"Administrativos: {cantAdmin}, Vendedores: {cantVend}");
                        Console.WriteLine($"Total sueldos a pagar: {totalSueldos}");
                        break;

                    case "4":
                        seguir = false;
                        Console.WriteLine("👋Fin del programa");
                        break;

                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
        }
    }
}