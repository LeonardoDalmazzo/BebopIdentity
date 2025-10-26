using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace identityAuthentication.Data
{
    [Table("faqs")] // <-- Corrigido
    public class FAQ
    {
        [Key]
        [Column("idfaq")] // <-- Corrigido
        public Guid IdFAQ { get; set; }

        [Required]
        [Column("pergunta")] // <-- Corrigido
        public string Pergunta { get; set; } = string.Empty;

        [Required]
        [Column("resposta")] // <-- Corrigido
        public string Resposta { get; set; } = string.Empty;

        [Column("ativo")] // <-- Corrigido
        public bool Ativo { get; set; } = true;

        [Column("datacriacao")] // <-- Corrigido
        public DateTime DataCriacao { get; set; }

        // Chave Estrangeira para Categoria
        [Column("idcategoria")] // <-- Corrigido
        public Guid IdCategoria { get; set; }

        // Propriedade de navegação
        [ForeignKey("IdCategoria")]
        public virtual Categoria? Categoria { get; set; }
    }
}