using System.ComponentModel.DataAnnotations;

namespace PP.Dominio.Base
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Eliminado { get; set; }
    }
}
