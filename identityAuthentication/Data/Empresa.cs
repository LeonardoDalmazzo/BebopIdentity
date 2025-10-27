using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace identityAuthentication.Data
{
    [Table("Empresas")]
    public class Empresa
    {
        [Key]
        [Column("IdEmpresa")]
        public Guid IdEmpresa { get; set; }

        [Required(ErrorMessage = "O nome da empresa é obrigatório.")]
        [StringLength(100)]
        [Column("NomeEmpresa")]
        public string NomeEmpresa { get; set; } = string.Empty;

        [Column("Ativo")]
        public bool Ativo { get; set; } = true;

        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }

        // Relação existente
        public virtual ICollection<Setor> Setores { get; set; } = new List<Setor>();

        // NOVA Relação: Uma empresa pode ter muitos usuários
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
    }
}