using System.ComponentModel.Design;
using Microsoft.Extensions.DependencyInjection;
using PP.Dominio.Entidades.Entidades;
using PP.Dominio.Repositorio;
using PP.Infraestructura.Context;
using PP.Infraestructura.Repositorio;
using PP.IServicio.IEmpleado;
using PP.IServicio.IProducto;
using PP.Servicio.Empleado;
using PP.Servicio.Producto;

namespace PP.Ioc
{
    public class Inyeccion
    {
        public static void ConfigurationServices(IServiceCollection service)
        {
            service.AddDbContext<DataContext>();


            service.AddTransient<IProductoServicio, ProductoServicio>();
            service.AddTransient<IEmpleadoServicio, EmpleadoServicio>();


            service.AddTransient<IRepositorio<Dominio.Entidades.Entidades.Producto>, Repositorio<
                Dominio.Entidades.Entidades.Producto>>();

            service
                .AddTransient<IRepositorio<Dominio.Entidades.Entidades.Empleado>,
                    Repositorio<Dominio.Entidades.Entidades.Empleado>>();
        }
    }
}
