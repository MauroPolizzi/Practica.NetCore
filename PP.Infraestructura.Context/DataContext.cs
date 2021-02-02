using System.Linq;
using Microsoft.EntityFrameworkCore;
using PP.Dominio.Entidades.Entidades;
using PP.Dominio.Entidades.MetaData;
using static PP.Aplicacion.ConectionString.ConetionString;


namespace PP.Infraestructura.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetWithWindows);
            base.OnConfiguring(optionsBuilder);
        }

        // Esto me desactiva el borrado en cascada
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFks = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

            // Entity Configurations

            modelBuilder.ApplyConfiguration<Producto>(new ProductoMetaData());
            modelBuilder.ApplyConfiguration<Empleado>(new EmpleadoMetaData());
        }



        // Mapeo

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
