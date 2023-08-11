using System;
using AppVentas.Infraestructura.Datos.Contextos;
namespace AppVentas.Infraestructura.Datos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la DB si esta no existe...!");
            VentaContexto db = new VentaContexto();
            db.Database.EnsureCreated();
            Console.WriteLine("La DB ha sido creada...!");
            Console.ReadKey();
        }
    }
}
