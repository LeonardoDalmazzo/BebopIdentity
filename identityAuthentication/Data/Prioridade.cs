using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic; // Necessário para ICollection

namespace identityAuthentication.Data
{
    [Table("prioridades")]
    public class Prioridade
    {
        [Key]
        [Column("idprioridade")]
        public Guid IdPrioridade { get; set; }

        [Required(ErrorMessage = "O nome da prioridade é obrigatório.")]
        [StringLength(50)]
        [Column("nomeprioridade")]
        public string NomePrioridade { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nível de urgência é obrigatório.")]
        [Range(1, 100, ErrorMessage = "O nível deve ser ao menos 1.")]
        [Column("nivelurgencia")]
        public int NivelUrgencia { get; set; } = 1;

        [Required(ErrorMessage = "A cor é obrigatória.")]
        [StringLength(7)]
        [Column("corhex")]
        public string CorHex { get; set; } = "#FFFFFF";

        // NOVA Relação: Uma prioridade pode estar em muitos chamados
        public virtual ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();
    }
}