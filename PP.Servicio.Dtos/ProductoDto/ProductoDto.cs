using PP.ServicioBase;

namespace PP.Servicio.Dtos.ProductoDto
{
    public class ProductoDto : DtoBase 
    {
        public string Descripcion { get; set; }

        public string Codigo { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}
