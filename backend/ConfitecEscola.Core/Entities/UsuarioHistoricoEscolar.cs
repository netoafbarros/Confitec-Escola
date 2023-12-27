using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfitecEscola.Core.Entities
{
    [Table("UsuarioHistoricoEscolar")]
    public class UsuarioHistoricoEscolar
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuarioHistoricoEscolar { get; set; }
        [Required]
        public int IdHistoricoEscolar { get; set; }
        [Required]
        public int IdUsuario { get; set; }
    }
}
