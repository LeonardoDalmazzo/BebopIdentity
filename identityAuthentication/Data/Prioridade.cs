using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace identityAuthentication.Data
{
    [Table("prioridades")] // <-- Corrigido
    public class Prioridade
    {
        [Key]
        [Column("idprioridade")] // <-- Corrigido
        public Guid IdPrioridade { get; set; }

        [Required(ErrorMessage = "O nome da prioridade é obrigatório.")]
        [StringLength(50)]
        [Column("nomeprioridade")] // <-- Corrigido
        public string NomePrioridade { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nível de urgência é obrigatório.")]
        [Range(1, 100, ErrorMessage = "O nível deve ser ao menos 1.")]
        [Column("nivelurgencia")] // <-- Corrigido
        public int NivelUrgencia { get; set; } = 1;

        [Required(ErrorMessage = "A cor é obrigatória.")]
        [StringLength(7)]
        [Column("corhex")] // <-- Corrigido
        public string CorHex { get; set; } = "#FFFFFF";
    }
}