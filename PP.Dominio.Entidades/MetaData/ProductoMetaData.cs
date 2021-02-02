using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Dominio.Entidades.Entidades;

namespace PP.Dominio.Entidades.MetaData
{
    public class ProductoMetaData : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(x => x.Descripcion)
                .HasField("_descripcion")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Cantidad)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Precio)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Codigo)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasQueryFilter(x => x.Eliminado == false);
        }
    }
}
