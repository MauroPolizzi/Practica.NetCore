using PP.Servicio.Dtos.ProductoDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PP.IServicio.IProducto
{
    public interface IProductoServicio
    {
        Task<IEnumerable<ProductoDto>> Obtener(string cadenaBuscar);

        Task<IEnumerable<ProductoDto>> ObtenerTodo();

        Task<ProductoDto> ObtenerPorId(long id);

        Task Insertar(ProductoDto dto);
    }
}
