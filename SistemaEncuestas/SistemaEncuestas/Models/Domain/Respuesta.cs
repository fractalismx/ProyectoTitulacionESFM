using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEncuestas.Models.Domain
{
    public class Respuesta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Preguntas")]
        [Display(Name = "Pregunta repondida")]
        public int IdPreguntas { get; set; }

        public virtual Pregunta Preguntas { get; set; }
    }
}