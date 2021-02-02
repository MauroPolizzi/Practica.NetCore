using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PP.Infraestructura.Context;
using PP.IServicio.IEmpleado;
using PP.Servicio.Dtos.EmpleadoDto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoServicio _empleadoServicio;

        private DataContext _context;

        public EmpleadoController(IEmpleadoServicio empleadoServicio, DataContext context)
        {
            _empleadoServicio = empleadoServicio;

            _context = context;
        }

        // PROBAR APIS DE EMPLEADO Y PRODUCTO

        #region Persistencia

        [HttpPost]
        [Route("CrearEmpleado")]
        public async Task<IActionResult> Insertar(EmpleadoDto dto)
        {
            var empleado = new EmpleadoDto
            {
                Apellido = dto.Apellido,
                Nombre = dto.Nombre,
                TipoCargoEmpleado = dto.TipoCargoEmpleado,

                Eliminado = false

            };

            await _empleadoServicio.Insertar(empleado);
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
                var empleado = await _empleadoServicio.ObtenerTodo();
                return Ok(empleado);
            }
            catch (System.ArgumentException)
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Obtener(string cadenaBuscar)
        {
            try
            {
                var empleado = await _empleadoServicio.Obtener(cadenaBuscar);
                return Ok(empleado);
            }
            catch (System.ArgumentException)
            {
                return NotFound("No se encontro el Empleado.");
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion
    }
}