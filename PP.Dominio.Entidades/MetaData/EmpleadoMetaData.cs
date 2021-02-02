using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Dominio.Entidades.Entidades;

namespace PP.Dominio.Entidades.MetaData
{
    public class EmpleadoMetaData : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.Property(x => x.Nombre)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Apellido)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasQueryFilter(x => x.Eliminado == false);
        }
    }
}
