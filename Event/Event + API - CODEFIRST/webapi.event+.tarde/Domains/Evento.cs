using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "Date")]
        [Required(ErrorMessage = "A Data do evento é obrigatória")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome do evento é obrigatório")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A Descrição do evento é obrigatória")]
        public string? Descricao { get; set; }

        // FK TipoEvento
        [Required(ErrorMessage = "Tipo do evento é obrigatorio")]

        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]

        public TipoEvento TipoEvento { get; set; }

        // FK Instituicao

        [Required(ErrorMessage = "Tipo da instituicao é obrigatoria")]

        public Guid IdInstituicao { get; set; }

        [ForeignKey(nameof(IdInstituicao))]

        public Instituicao Instituicao { get; set; }

    }
}
