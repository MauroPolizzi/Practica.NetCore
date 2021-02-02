using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PP.Dominio.Repositorio;
using PP.Infraestructura.Context;
using PP.IServicio.IEmpleado;
using PP.Servicio.Dtos.EmpleadoDto;
using PP.Servicio.Dtos.ProductoDto;

namespace PP.Servicio.Empleado
{
    public class EmpleadoServicio : IEmpleadoServicio
    {
        private readonly IRepositorio<Dominio.Entidades.Entidades.Empleado> _empleadoRepositorio;

        private DataContext _context;

        public EmpleadoServicio(IRepositorio<Dominio.Entidades.Entidades.Empleado> empleadoRepositorio, DataContext context)
        {
            _empleadoRepositorio = empleadoRepositorio;

            _context = context;
        }

        #region Persistencia

        public async Task Insertar(EmpleadoDto dto)
        {
            var empleado = new Dominio.Entidades.Entidades.Empleado
            {
                Id = dto.Id,

                Eliminado = dto.Eliminado,

                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                TipoCargoEmpleado = dto.TipoCargoEmpleado

            };

            await _empleadoRepositorio.Create(empleado);
        } 

        #endregion

        #region Consulta

        public async Task<IEnumerable<EmpleadoDto>> Obtener(string cadenaBuscar)
        {
            var empleado = await _empleadoRepositorio
                .GetByFilter(x => x.Apellido.Contains(cadenaBuscar));

            return empleado.Select(x => new EmpleadoDto
            {
                Id = x.Id,
                Eliminado = x.Eliminado,

                Nombre = x.Nombre,
                Apellido = x.Apellido,
                TipoCargoEmpleado = x.TipoCargoEmpleado

            }).ToList();
        }


        public async Task<IEnumerable<EmpleadoDto>> ObtenerTodo()
        {
            var empleado = await _empleadoRepositorio.GetAll(null, include: null);

            return empleado.Select(x => new EmpleadoDto
            {
                Id = x.Id,
                Eliminado = x.Eliminado,

                Nombre = x.Nombre,
                Apellido = x.Apellido,
                TipoCargoEmpleado = x.TipoCargoEmpleado

            });
        }

        public Task<EmpleadoDto> ObtenerPorId(long id)
        {
            throw new System.NotImplementedException();
        }

        #endregion

    }
}
