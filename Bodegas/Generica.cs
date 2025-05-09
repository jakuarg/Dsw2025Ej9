using Dsw2025Ej9.Entidades;

namespace Dsw2025Ej9.Bodegas;

/*
     * ¡Se decidió construir una bodega por cada tipo!
     * Después de hartarse de añadir BodegaAlimentos, BodegaHerramientas,
     * BodegaElectronica, los marineros descubrieron que podían tener
     * una única bodega que funcione con cualquier mercancía.
     *
     * TU MISIÓN:
     * 1) Crear una clase genérica, con los métodos que debería tener una bodega
     
     * 2) Completar el método EjemploBodegasGenericas (en la clase Ejemplos):
     *      – Instanciar diferentes bodegas, para cada tipo de mercancía.
     *      – Agregar al menos dos elementos de cada tipo.
     *      – Listar y mostrar por consola el contenido de cada bodega.
     *      
     * 3) Asegurar que la nueva bodega genérica solo acepte mercancías
     *
     */
public class Bodega<T>
    where T : Mercancia
{
    private List<T> mercancias = new List<T>();
    public void Agregar(T mercancia)
    {
        mercancias.Add(mercancia);
        Console.WriteLine($"[{typeof(T).Name} ({mercancia.Nombre})  se agregó correctamente.]");
    }
    public void Eliminar(T mercancia)
    {
        mercancias.Remove(mercancia);
        Console.WriteLine($"[{typeof(T).Name}({mercancia.Nombre}) se eliminó correctamente.]");
    }
    public void Listar()
    {
        Console.WriteLine($"[{typeof(T).Name}s en la bodega:]");
        foreach (var mercancia in mercancias)
        {
            Console.WriteLine($"- {mercancia.Nombre}");
        }
    }
    public override string ToString()
    {
        return $"Mercancía: {GetType().Name}";
    }
    public T? Obtener(Predicate<T> criterio) => mercancias.Find(criterio);
}
