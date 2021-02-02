using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using PP.Dominio.Base;

namespace PP.Dominio.Entidades.Entidades
{
    public class Producto : EntityBase
    {
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion;}

            set
            {
                _descripcion = string.Join("", value.Split("")
                    .Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToUpper()).ToArray());
            }
        }

        public string Codigo { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}
