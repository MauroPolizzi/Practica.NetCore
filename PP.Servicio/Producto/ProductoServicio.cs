using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PP.Dominio.Repositorio;
using PP.Infraestructura.Context;
using PP.IServicio.IProducto;
using PP.MaperProfiles;
using PP.Servicio.Dtos.ProductoDto;

namespace PP.Servicio.Producto
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IRepositorio<Dominio.Entidades.Entidades.Producto> _productoRepositorio;

        private DataContext _context;

        private IMapper _mapper;

        public ProductoServicio(IRepositorio<Dominio.Entidades.Entidades.Producto> productoRepositorio, DataContext context)
        {
            _productoRepositorio = productoRepositorio;

            _context = context;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MaperProfiles.MapperProfiles>());

            _mapper = config.CreateMapper();
        }

        #region Persistencia

        public async Task Insertar(ProductoDto dto)
        {
            var producto = new Dominio.Entidades.Entidades.Producto
            {
                Id = dto.Id,
                Eliminado = dto.Eliminado,

                Cantidad = dto.Cantidad,
                Codigo = dto.Codigo,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio
            };

            await _productoRepositorio.Create(producto);
        }
        
        #endregion

        #region Consulta 

        public  async Task<IEnumerable<ProductoDto>> Obtener(string cadenaBuscar)
        {
            var producto = await _productoRepositorio.
                GetByFilter(x => x.Descripcion.Contains(cadenaBuscar));

            return producto.Select(x => new ProductoDto
            {
                Id = x.Id,
                Eliminado = x.Eliminado,

                Cantidad = x.Cantidad,
                Codigo = x.Codigo,
                Descripcion = x.Descripcion,
                Precio = x.Precio

            }).ToList();
        }


        public async Task<IEnumerable<ProductoDto>> ObtenerTodo()
        {
            var producto = await _productoRepositorio.GetAll(null, include: null);

            return producto.Select(x => new ProductoDto
            {
                Id = x.Id,
                Eliminado = x.Eliminado,

                Cantidad = x.Cantidad,
                Codigo = x.Codigo,
                Descripcion = x.Descripcion,
                Precio = x.Precio

            }).ToList();
        }

        public Task<ProductoDto> ObtenerPorId(long id)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
