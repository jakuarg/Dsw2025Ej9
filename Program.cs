namespace Dsw2025Ej9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Menu.Principal();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error : {ex.Message}");
                    Console.WriteLine("Presione ENTER para continuar");
                    Console.ReadKey();
                }
            } while (true);
        }
    }
}
