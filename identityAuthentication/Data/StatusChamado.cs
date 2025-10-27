using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic; // Necessário para ICollection

namespace identityAuthentication.Data
{
    [Table("statuschamados")]
    public class StatusChamado
    {
        [Key]
        [Column("idstatus")]
        public Guid IdStatus { get; set; }

        [Required(ErrorMessage = "O nome do status é obrigatório.")]
        [StringLength(50)]
        [Column("nomestatus")]
        public string NomeStatus { get; set; } = string.Empty;

        // --- NOVAS Relações ---

        // Um status pode estar em muitos chamados (como status atual)
        [InverseProperty("Status")] // Especifica qual FK usar em Chamado
        public virtual ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();

        // Um status pode estar em muitos históricos (como status anterior)
        [InverseProperty("StatusAnterior")] // Especifica qual FK usar em ChamadoHistorico
        public virtual ICollection<ChamadoHistorico> HistoricosComoAnterior { get; set; } = new List<ChamadoHistorico>();

        // Um status pode estar em muitos históricos (como status novo)
        [InverseProperty("StatusNovo")] // Especifica qual FK usar em ChamadoHistorico
        public virtual ICollection<ChamadoHistorico> HistoricosComoNovo { get; set; } = new List<ChamadoHistorico>();
    }
}