using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema; // Necess�rio para [ForeignKey]

namespace identityAuthentication.Data
{
    // Adicione dados de perfil para usu�rios do aplicativo adicionando propriedades � classe ApplicationUser
    public class ApplicationUser : IdentityUser
    {
        // NOVAS PROPRIEDADES (para corresponder ao SQL 'ALTER TABLE')
        
        [Column("IdEmpresa")]
        public Guid? IdEmpresa { get; set; } // Anul�vel, pois o Admin atribui

        [Column("IdSetor")]
        public Guid? IdSetor { get; set; } // Anul�vel

        [ForeignKey("IdEmpresa")]
        public virtual Empresa? Empresa { get; set; }

        [ForeignKey("IdSetor")]
        public virtual Setor? Setor { get; set; }
    }
}