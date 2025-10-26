using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace identityAuthentication.Data
{
    [Table("statuschamados")] // <-- Corrigido
    public class StatusChamado
    {
        [Key]
        [Column("idstatus")] // <-- Corrigido
        public Guid IdStatus { get; set; }

        [Required(ErrorMessage = "O nome do status é obrigatório.")]
        [StringLength(50)]
        [Column("nomestatus")] // <-- Corrigido
        public string NomeStatus { get; set; } = string.Empty;
    }
}