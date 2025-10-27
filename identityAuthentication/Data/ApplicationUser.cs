using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic; // Necess�rio para ICollection

namespace identityAuthentication.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Column("IdEmpresa")]
        public Guid? IdEmpresa { get; set; }

        [Column("IdSetor")]
        public Guid? IdSetor { get; set; }

        [ForeignKey("IdEmpresa")]
        public virtual Empresa? Empresa { get; set; }

        [ForeignKey("IdSetor")]
        public virtual Setor? Setor { get; set; }

        // --- NOVAS Rela��es Inversas ---

        // Um usu�rio pode ter aberto muitos chamados
        [InverseProperty("Solicitante")] // Especifica qual FK usar em Chamado
        public virtual ICollection<Chamado> ChamadosSolicitados { get; set; } = new List<Chamado>();

        // Um usu�rio (t�cnico) pode ter atendido muitos chamados
        [InverseProperty("Atendente")] // Especifica qual FK usar em Chamado
        public virtual ICollection<Chamado> ChamadosAtendidos { get; set; } = new List<Chamado>();

        // Um usu�rio pode ter escrito muitos hist�ricos
        public virtual ICollection<ChamadoHistorico> Historicos { get; set; } = new List<ChamadoHistorico>();
    }
}