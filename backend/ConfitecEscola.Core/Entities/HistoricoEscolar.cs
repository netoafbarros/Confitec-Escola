using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfitecEscola.Core.Entities
{
    [Table("HistoricoEscolar")]
    public class HistoricoEscolar
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHistoricoEscolar { get; set; }
        public string Formato { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public byte[] Arquivo { get; set; }
        [Required]
        public bool Ativo { get; set; } = true;
    }
}
