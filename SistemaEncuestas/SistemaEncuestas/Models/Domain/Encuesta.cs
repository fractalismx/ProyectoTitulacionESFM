using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEncuestas.Models.Domain
{
    public class Encuesta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Estatus { get; set; }
        public DateTime Alta { get; set; }

        [ForeignKey("Categorias")]
        [Display(Name = "Identificador de categoría")]
        public int IdCategorias { get; set; }

        public virtual Categoria Categorias { get; set; }
        public virtual ICollection<Pregunta> Preguntas { get; set; }
    }
}