using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEncuestas.Models.Domain
{
    public class RespuestaUsuario
    {
        public int Id { get; set; }

        public int IdEncuesta { get; set; }
        [ForeignKey("Preguntas")]
        public int IdPregunta { get; set; }
        public int IdRespuesta { get; set; }
        [ForeignKey("AspNetUsers")]
        public string IdUsuario { get; set; }

        public virtual Pregunta Preguntas { get; set; }
        public virtual ApplicationUser AspNetUsers { get; set; }
    }
}