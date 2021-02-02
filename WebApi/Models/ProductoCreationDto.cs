using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ProductoCreationDto
    {
        public long Id { get; set; }

        public bool Eliminado { get; set; }

        public string Descripcion { get; set; }

        public string Codigo { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}
