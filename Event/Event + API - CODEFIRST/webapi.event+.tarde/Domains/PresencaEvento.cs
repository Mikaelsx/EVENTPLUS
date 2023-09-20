using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(PresencaEvento))]
    public class PresencaEvento
    {
        [Key]
        public Guid IdPresencaEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Situação obrigatoria")]
        public bool Situacao { get; set; }

        // FK Usuario
        [Required(ErrorMessage = "Usuario obrigatorio")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]

        public Usuario Usuario { get; set; }

        // FK Evento
        [Required(ErrorMessage = "O CNPJ é obrigatorio")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]

        public Evento Evento { get; set; }
    }
}
