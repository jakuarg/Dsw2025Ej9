using Dsw2025Ej9.Bodegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej9
{
    public class Menu
    {
        public static void Principal()
        {
            var opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("A que bodega desea entrar:");
                Console.WriteLine("1. Bodega básica");
                Console.WriteLine("2. Bodegas múltiples");
                Console.WriteLine("3. Bodega genérica");
                Console.WriteLine("4. Salir");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("=============================");
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Bodega Básica");
                        Console.WriteLine("=============================");
                        Ejemplos.BodegaBasica();
                        break;
                    case 2:
                        Console.WriteLine("Bodegas Multiples");
                        Console.WriteLine("=============================");
                        Ejemplos.MultiBodegaTipada();
                        break;
                    case 3:
                        Console.WriteLine("Bodega Genérica");
                        Console.WriteLine("=============================");
                        Ejemplos.BodegaGenerica();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo...");
                        Console.WriteLine("=============================");
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        Console.WriteLine("=============================");
                        break;
                }
                Console.ReadKey();
            } while (opcion != 4);
        }
    }
}
