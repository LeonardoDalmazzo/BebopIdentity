using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic; // Necessário para ICollection

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

        [Required(ErrorMessage = "É obrigatório selecionar uma empresa.")]
        [Column("IdEmpresa")]
        public Guid IdEmpresa { get; set; }

        [ForeignKey("IdEmpresa")]
        public virtual Empresa? Empresa { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();

        // NOVA Relação: Um setor pode ter muitos chamados
        public virtual ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();
    }
}