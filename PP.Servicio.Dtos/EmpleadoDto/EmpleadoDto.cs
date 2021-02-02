using PP.Dominio.Entidades.Entidades;
using PP.ServicioBase;

namespace PP.Servicio.Dtos.EmpleadoDto
{
    public class EmpleadoDto : DtoBase
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public TipoCargoEmpleado TipoCargoEmpleado { get; set; }
    }
}
