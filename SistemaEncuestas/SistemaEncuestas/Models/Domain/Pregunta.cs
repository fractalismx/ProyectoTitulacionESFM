using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Models.Domain
{
    public class Pregunta
    {
        public int Id { get; set; }
        public string NombreP { get; set; }

        [ForeignKey("Encuestas")]
        public int IdEncuestas { get; set; }

        public virtual Encuesta Encuestas { get; set; }

        public virtual ICollection<Respuesta> Respuestas {get;set;}
    }
}