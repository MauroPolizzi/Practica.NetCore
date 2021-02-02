using System.Collections.Generic;
using System.Threading.Tasks;
using PP.Servicio.Dtos.EmpleadoDto;

namespace PP.IServicio.IEmpleado
{
    public interface IEmpleadoServicio
    {
        Task<IEnumerable<EmpleadoDto>> Obtener(string cadenaBuscar);

        Task<IEnumerable<EmpleadoDto>> ObtenerTodo();

        Task<EmpleadoDto> ObtenerPorId(long id);

        Task Insertar(EmpleadoDto dto);
    }
}
