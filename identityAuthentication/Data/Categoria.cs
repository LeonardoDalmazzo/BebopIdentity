using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace identityAuthentication.Data
{
    [Table("categorias")] // <-- Corrigido
    public class Categoria
    {
        [Key]
        [Column("idcategoria")] // <-- Corrigido
        public Guid IdCategoria { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [StringLength(100)]
        [Column("nomecategoria")] // <-- Corrigido
        public string NomeCategoria { get; set; } = string.Empty;

        [Column("descricao")] // <-- Corrigido
        public string? Descricao { get; set; }

        [Column("ativo")] // <-- Corrigido
        public bool Ativo { get; set; } = true;

        [Column("datacriacao")] // <-- Corrigido
        public DateTime DataCriacao { get; set; }

        // Propriedade de navegação: Uma Categoria pode ter muitas FAQs
        public virtual ICollection<FAQ> FAQs { get; set; } = new List<FAQ>();
    }
}