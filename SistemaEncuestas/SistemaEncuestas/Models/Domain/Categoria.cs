using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Models.Domain
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Estatus {get; set; }

        public virtual ICollection<Encuesta> Encuestas { get; set; }
    }
}