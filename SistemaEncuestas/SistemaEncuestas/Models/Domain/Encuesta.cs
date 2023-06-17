using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Models.Domain
{
    public class Encuesta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Estatus { get; set; }
        public DateTime Alta { get; set; }

        [ForeignKey("Categorias")]
        public int IdCategorias { get; set; }

        public virtual Categoria Categorias { get; set; }
        public virtual ICollection<Pregunta> Preguntas { get; set; }
    }
}