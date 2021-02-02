using PP.Dominio.Base;

namespace PP.Dominio.Entidades.Entidades
{
    public class Empleado : EntityBase
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public TipoCargoEmpleado TipoCargoEmpleado { get; set; }
    }
}
