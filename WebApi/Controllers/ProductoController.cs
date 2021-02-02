using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PP.Infraestructura.Context;
using PP.IServicio.IProducto;
using PP.Servicio.Dtos.ProductoDto;
using WebApi.AutoMapper;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServicio _productoServicio;

        private readonly DataContext _context;

        private readonly IMapper _mapper; 

        public ProductoController(IProductoServicio productoServicio, DataContext context)
        {
            _productoServicio = productoServicio;

            _context = context;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<PerfilCreationDto>());

            _mapper = config.CreateMapper();
        }

        #region Persistencia

        [HttpPost]
        [Route("CrearProducto")]
        public async Task<IActionResult> Insertar(ProductoCreationDto dto)
        {
            var producto = new ProductoDto
            {
                Descripcion = dto.Descripcion,
                Cantidad = dto.Cantidad,
                Codigo = dto.Codigo,
                Precio = dto.Precio,

                Eliminado = false
            };

            await _productoServicio.Insertar(producto);
            return Ok(dto);
        }

        #endregion

        #region Consulta

        [HttpGet]
        [Route("ObtenerTodos")] 
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var producto = await _productoServicio.ObtenerTodo();
                return Ok(producto);
            }
            catch (System.ArgumentException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Obtener")]
        public async Task<IActionResult> Obtener(string cadenaBuscar)
        {
            try
            {
                var producto = await _productoServicio.Obtener(cadenaBuscar);
                return Ok(producto);

            }
            catch (System.ArgumentException)
            {
                return NotFound("No se encontro el Producto.");
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion
    }
}