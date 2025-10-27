using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace identityAuthentication.Data
{
    [Table("chamadohistorico")]
    public class ChamadoHistorico
    {
        [Key]
        [Column("IdHistorico")]
        public Guid IdHistorico { get; set; }

        [Required]
        [Column("IdChamado")]
        public Guid IdChamado { get; set; }

        [Required]
        [Column("IdUsuario")]
        public string IdUsuario { get; set; } = string.Empty;

        [Required]
        [Column("Comentario")]
        public string Comentario { get; set; } = string.Empty;

        [Column("DataComentario")]
        public DateTime DataComentario { get; set; }

        [Column("EraStatusId")]
        public Guid? EraStatusId { get; set; }

        [Column("NovoStatusId")]
        public Guid? NovoStatusId { get; set; }


        [ForeignKey("IdChamado")]
        public virtual Chamado? Chamado { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual ApplicationUser? Usuario { get; set; }

        [ForeignKey("EraStatusId")]
        public virtual StatusChamado? StatusAnterior { get; set; }

        [ForeignKey("NovoStatusId")]
        public virtual StatusChamado? StatusNovo { get; set; }
    }
}