using PP.Infraestructura.Context;
using System;
using PP.Dominio.Entidades.Entidades;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {
                context.Add(new Empleado
                {
                    Nombre = "Mauro",
                    Apellido = "Polizzi",
                    TipoCargoEmpleado = TipoCargoEmpleado.Admin,
                    Eliminado = false,
                });

                context.SaveChanges();
            }
        }
    }
}
