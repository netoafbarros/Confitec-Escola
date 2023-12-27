using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfitecEscola.Core.Entities
{
    [Table("Usuario")]
    public class Usuario
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public int IdEscolaridade { get; set; }
        [Required]
        public bool Ativo { get; set; } = true;
    }
}
