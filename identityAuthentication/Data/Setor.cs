using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace identityAuthentication.Data
{
    [Table("Setores")]
    public class Setor
    {
        [Key]
        [Column("IdSetor")]
        public Guid IdSetor { get; set; }

        [Required(ErrorMessage = "O nome do setor é obrigatório.")]
        [StringLength(100)]
        [Column("NomeSetor")]
        public string NomeSetor { get; set; } = string.Empty;

        [Column("Ativo")]
        public bool Ativo { get; set; } = true;

        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }

        // --- Chave Estrangeira ---

        [Required(ErrorMessage = "É obrigatório selecionar uma empresa.")]
        [Column("IdEmpresa")]
        public Guid IdEmpresa { get; set; }

        // Propriedade de navegação para a relação N-1
        // Um Setor pertence a uma Empresa
        [ForeignKey("IdEmpresa")]
        public virtual Empresa? Empresa { get; set; }
    }
}