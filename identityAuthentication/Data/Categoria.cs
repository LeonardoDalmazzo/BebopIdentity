using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic; // Necessário para ICollection

namespace identityAuthentication.Data
{
    [Table("categorias")]
    public class Categoria
    {
        [Key]
        [Column("idcategoria")]
        public Guid IdCategoria { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [StringLength(100)]
        [Column("nomecategoria")]
        public string NomeCategoria { get; set; } = string.Empty;

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; } = true;

        [Column("datacriacao")]
        public DateTime DataCriacao { get; set; }

        public virtual ICollection<FAQ> FAQs { get; set; } = new List<FAQ>();

        // NOVA Relação: Uma categoria pode ter muitos chamados
        public virtual ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();
    }
}