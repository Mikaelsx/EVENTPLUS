﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(ComentarioEvento))]
    public class ComentarioEvento
    {
        [Key]
        public Guid IdComentarioEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "O Comentário é obrigatório")]
        public string Descricao { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Informação sobre a exibição obrigatória")]
        public bool Exibe { get; set; }

        // FK Usuario
        [Required(ErrorMessage = "Usuario obrigatorio")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario Usuario{ get; set; }

        // FK Evento
        [Required(ErrorMessage = "Evento obrigatorio")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public Evento Evento { get; set; }
    }
}
