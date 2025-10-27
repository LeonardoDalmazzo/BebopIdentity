using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace identityAuthentication.Data
{
    [Table("chamados")]
    public class Chamado
    {
        [Key]
        [Column("IdChamado")]
        public Guid IdChamado { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(200)]
        [Column("Titulo")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [Column("Descricao")]
        public string Descricao { get; set; } = string.Empty;

        [Column("DataAbertura")]
        public DateTime DataAbertura { get; set; }

        [Column("DataFechamento")]
        public DateTime? DataFechamento { get; set; }

        // --- Chaves Estrangeiras ---

        [Required]
        [Column("IdSolicitante")]
        public string IdSolicitante { get; set; } = string.Empty;

        [Required]
        [Column("IdEmpresa")]
        public Guid IdEmpresa { get; set; }

        [Column("IdSetor")]
        public Guid? IdSetor { get; set; }

        [Column("IdAtendente")]
        public string? IdAtendente { get; set; }

        [Required]
        [Column("IdCategoria")]
        public Guid IdCategoria { get; set; }

        [Required]
        [Column("IdPrioridade")]
        public Guid IdPrioridade { get; set; }

        [Required]
        [Column("IdStatus")]
        public Guid IdStatus { get; set; }


        [ForeignKey("IdSolicitante")]
        public virtual ApplicationUser? Solicitante { get; set; }

        [ForeignKey("IdAtendente")]
        public virtual ApplicationUser? Atendente { get; set; }

        [ForeignKey("IdEmpresa")]
        public virtual Empresa? Empresa { get; set; }

        [ForeignKey("IdSetor")]
        public virtual Setor? Setor { get; set; }

        [ForeignKey("IdCategoria")]
        public virtual Categoria? Categoria { get; set; }

        [ForeignKey("IdPrioridade")]
        public virtual Prioridade? Prioridade { get; set; }

        [ForeignKey("IdStatus")]
        public virtual StatusChamado? Status { get; set; }

        public virtual ICollection<ChamadoHistorico> Historico { get; set; } = new List<ChamadoHistorico>();
    }
}