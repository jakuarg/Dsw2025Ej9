using Dsw2025Ej9.Bodegas;
using Dsw2025Ej9.Entidades;
using System.Security.Cryptography.X509Certificates;

namespace Dsw2025Ej9;

internal class Ejemplos
{
    public static void BodegaBasica()
    {
        //Había un barco con una única bodega donde se metía todo sin distinción: manzanas,
        //martillos o pantallas, todos encerrados en cajas genéricas (boxing).
        //Al llegar al puerto, cada caja había que abrirla y “unboxearla” (unboxing),
        //revisar su tipo y volverla a organizar a mano. Este proceso era lento, propenso a errores
        //(un martillo entre las manzanas) y no escalaba cuando llegaban nuevos productos.

        var bodega = new Basica();

        // 1) Almacenar referencias a Alimento y Herramienta
        bodega.Agregar(new Alimento("Manzana"));
        bodega.Agregar(new Herramienta("Martillo"));

        // 2) También podríamos agregar valores: ¡boxing automático!
        bodega.Agregar(42); // el int 42 se convierte a object

        Console.WriteLine("\nRecorriendo bodega (requiere comprobaciones y casteos):");
        foreach (object obj in bodega.Listar())
        {
            // Unboxing de int
            if (obj is int peso)
            {
                Console.WriteLine($"- Peso (unboxed): {peso} kg");
            }
            // Cast a clase Alimento
            else if (obj is Alimento alim)
            {
                Console.WriteLine($"- Alimento: {alim.Nombre}");
            }
            // Cast a clase Herramienta
            else if (obj is Herramienta herr)
            {
                Console.WriteLine($"- Herramienta: {herr.Nombre}");
            }
            else
            {
                Console.WriteLine($"- Otro tipo: {obj.GetType().Name}");
            }
        }
    }

    public static void MultiBodegaTipada()
    {
        // Tras el caos de la única bodega, el capitán construyó tres independientes:
        // una para alimentos, otra para herramientas y la tercera para números enteros.
        // Cada bodega solo acepta su tipo, evitando casting incorrecto,
        // pero el código se repite para cada nueva clase de bodega.

        // Ahora cada bodega está fuertemente tipada
        var bAlimentos = new Alimentos();
        var bHerramientas = new Herramientas();
        var bEnteros = new Enteros();

        bAlimentos.Agregar(new Alimento("Manzana"));
        bHerramientas.Agregar(new Herramienta("Martillo"));
        bEnteros.Agregar(43);

        Console.WriteLine("\nRecorriendo bodegas múltiples:");
        Console.WriteLine("\n--- Contenido Alimentos ---");
        foreach (Alimento a in bAlimentos.Listar())
            Console.WriteLine($"- {a.Nombre}");

        Console.WriteLine("\n--- Contenido Herramientas ---");
        foreach (Herramienta h in bHerramientas.Listar())
            Console.WriteLine($"- {h.Nombre}");

        Console.WriteLine("\n--- Contenido Enteros ---");
        foreach (int e in bEnteros.Listar())
            Console.WriteLine($"- {e}");
    }

    public static void BodegaGenerica()
    {
        //throw new NotImplementedException();
        // Bodega de alimentos
        var bodegaAlimentos = new Bodega<Alimento>();
        bodegaAlimentos.Agregar(new Alimento("Manzanas"));
        bodegaAlimentos.Agregar(new Alimento("Naranjas"));
        //bodegaAlimentos.Listar();

        // Bodega de herramientas
        var bodegaHerramientas = new Bodega<Herramienta>();
        bodegaHerramientas.Agregar(new Herramienta("Martillo", true));
        bodegaHerramientas.Agregar(new Herramienta("Destornillador", true));
        //bodegaHerramientas.Listar();

        // Bodega de productos electrónicos
        var bodegaElectronicos = new Bodega<ProductoElectronico>();
        bodegaElectronicos.Agregar(new ProductoElectronico("Laptop", "Lenovo"));
        bodegaElectronicos.Agregar(new ProductoElectronico("Smartphone", "Apple"));
        //bodegaElectronicos.Listar();
        int opcion = 0;
        int tipo = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("1. Agregar Mercancía");
            Console.WriteLine("2. Eliminar Mercancía");
            Console.WriteLine("3. Listar Mercancía");
            Console.WriteLine("4. Volver");
            opcion = int.Parse(Console.ReadLine()!);
            Console.Clear();
            Console.WriteLine("=============================");
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Agregar Mercancía");
                    Console.WriteLine("=============================");
                    Console.WriteLine("Que tipo de mercancía desea ingresar:");
                    Console.WriteLine("1. Alimento");
                    Console.WriteLine("2. Herramienta");
                    Console.WriteLine("3. Producto Electronico");
                    Console.WriteLine("4. Volver");
                    tipo = int.Parse(Console.ReadLine()!);
                    Console.Clear();
                    Console.WriteLine("=============================");
                    switch (tipo)
                    {
                        case 1:
                            Console.WriteLine("Agregar Alimento");
                            Console.WriteLine("=============================");
                            Console.WriteLine("Ingrese el nombre del alimento:");
                            var nombreAlimento = Console.ReadLine();
                            bodegaAlimentos.Agregar(new Alimento(nombreAlimento));
                            break;
                        case 2:
                            Console.WriteLine("Agregar Herramienta");
                            Console.WriteLine("=============================");
                            Console.WriteLine("Ingrese el nombre de la herramienta:");
                            var nombreHerramienta = Console.ReadLine();
                            Console.WriteLine("La herramienta es eléctrica? [true para si, false para no]");

                            bool esElectrica = bool.Parse(Console.ReadLine());
                            bodegaHerramientas.Agregar(new Herramienta(nombreHerramienta, esElectrica));
                            break;
                        case 3:
                            Console.WriteLine("Agregar Producto Electronico");
                            Console.WriteLine("=============================");
                            Console.WriteLine("Ingrese el nombre del producto electronico:");
                            var nombreProducto = Console.ReadLine();
                            Console.WriteLine("Ingrese la marca:");
                            var marca = Console.ReadLine();
                            bodegaElectronicos.Agregar(new ProductoElectronico(nombreProducto, marca));
                            break;
                        case 4:
                            Console.WriteLine("Volviendo . . .");
                            break;
                        default:
                            Console.WriteLine("Opción no válida");
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Eliminar Mercancía");
                    Console.WriteLine("=============================");
                    Console.WriteLine("De qué tipo de mercancía desea eliminar:");
                    Console.WriteLine("1. Alimento");
                    Console.WriteLine("2. Herramienta");
                    Console.WriteLine("3. Producto Electrónico");
                    Console.WriteLine("4. Volver");
                    tipo = int.Parse(Console.ReadLine()!);
                    Console.Clear();
                    Console.WriteLine("=============================");
                    switch (tipo)
                    {
                        case 1:
                            Console.WriteLine("Eliminar Alimento");
                            Console.WriteLine("=============================");
                            Console.WriteLine("Ingrese el nombre del alimento a eliminar:");
                            var nombreAlimentoEliminar = Console.ReadLine();
                            var alimentoAEliminar = bodegaAlimentos.Obtener(m => m.Nombre == nombreAlimentoEliminar);
                            if (alimentoAEliminar != null)
                            {
                                bodegaAlimentos.Eliminar(alimentoAEliminar);
                                Console.WriteLine($"Alimento '{nombreAlimentoEliminar}' eliminado.");
                            }
                            else
                            {
                                Console.WriteLine($"Alimento '{nombreAlimentoEliminar}' no encontrado.");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Eliminar Herramienta");
                            Console.WriteLine("=============================");
                            Console.WriteLine("Ingrese el nombre de la herramienta a eliminar:");
                            var nombreHerramientaEliminar = Console.ReadLine();
                            var herramientaAEliminar = bodegaHerramientas.Obtener(m => m.Nombre == nombreHerramientaEliminar);
                            if (herramientaAEliminar != null)
                            {
                                bodegaHerramientas.Eliminar(herramientaAEliminar);
                                Console.WriteLine($"Herramienta '{nombreHerramientaEliminar}' eliminada.");
                            }
                            else
                            {
                                Console.WriteLine($"Herramienta '{nombreHerramientaEliminar}' no encontrada.");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Eliminar Producto Electrónico");
                            Console.WriteLine("=============================");
                            Console.WriteLine("Ingrese el nombre del producto electrónico a eliminar:");
                            var nombreProductoEliminar = Console.ReadLine();
                            var productoAEliminar = bodegaElectronicos.Obtener(m => m.Nombre == nombreProductoEliminar);
                            if (productoAEliminar != null)
                            {
                                bodegaElectronicos.Eliminar(productoAEliminar);
                                Console.WriteLine($"Producto Electrónico '{nombreProductoEliminar}' eliminado.");
                            }
                            else
                            {
                                Console.WriteLine($"Producto Electrónico '{nombreProductoEliminar}' no encontrado.");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Volviendo . . .");
                            break;
                        default:
                            Console.WriteLine("Opción no válida");
                            break;
                    }
                    break;

                case 3:
                    Console.WriteLine("Listar");
                    Console.WriteLine("=============================");
                    bodegaAlimentos.Listar();
                    bodegaHerramientas.Listar();
                    bodegaElectronicos.Listar();

                    break;
                case 4:
                    Console.WriteLine("Volviendo . . .");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
            Console.WriteLine("Presione una ENTER para seguir");
            Console.ReadKey();
        } while (opcion != 4);
    }
}