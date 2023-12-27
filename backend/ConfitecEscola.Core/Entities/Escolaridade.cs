using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfitecEscola.Core.Entities
{
    [Table("Escolaridade")]
    public class Escolaridade
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEscolaridade { get; set; }
        [Required]
        [Column("Escolaridade")]
        public string EscolaridadeDesc { get; set; }
        [Required]
        public bool Ativo { get; set; } = true;
    }
}
