using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema; // Necessário para [ForeignKey]

namespace identityAuthentication.Data
{
    // Adicione dados de perfil para usuários do aplicativo adicionando propriedades à classe ApplicationUser
    public class ApplicationUser : IdentityUser
    {
        // NOVAS PROPRIEDADES (para corresponder ao SQL 'ALTER TABLE')
        
        [Column("IdEmpresa")]
        public Guid? IdEmpresa { get; set; } // Anulável, pois o Admin atribui

        [Column("IdSetor")]
        public Guid? IdSetor { get; set; } // Anulável

        [ForeignKey("IdEmpresa")]
        public virtual Empresa? Empresa { get; set; }

        [ForeignKey("IdSetor")]
        public virtual Setor? Setor { get; set; }
    }
}