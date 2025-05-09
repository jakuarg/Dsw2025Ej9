namespace Dsw2025Ej9.Entidades;

public class ProductoElectronico : Mercancia
{
    //public string Nombre { get; }
    public string Marca { get; }

    public ProductoElectronico(string nombre, string marca)
    {
        Marca = marca;
        Nombre = nombre;
    }
}
