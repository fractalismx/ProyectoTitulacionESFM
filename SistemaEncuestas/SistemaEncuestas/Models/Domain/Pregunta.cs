using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEncuestas.Models.Domain
{
    public class Pregunta
    {
        public int Id { get; set; }

        [Display(Name = "Pregunta a formular")]
        public string NombreP { get; set; }

        [ForeignKey("Encuestas")]
        public int IdEncuestas { get; set; }

        public virtual Encuesta Encuestas { get; set; }
        public virtual ICollection<RespuestaUsuario> RespuestaUsuarios { get; set; }

        public virtual ICollection<Respuesta> Respuestas { get; set; }
    }
}