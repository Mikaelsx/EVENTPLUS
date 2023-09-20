
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Email é obrigatório")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Email é obrigatório")]
        [StringLength(60,MinimumLength = 6, ErrorMessage = "A Senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "O Tipo de usuario é obrigatório")]
        public Guid IdTipoUsuario { get; set; }

        // FK TipoUsuario

        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
