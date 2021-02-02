using PP.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class EmpleadoCreationDto
    {
        public long Id { get; set; }

        public bool Eliminado { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public TipoCargoEmpleado TipoCargoEmpleado { get; set; }
    }
}
