﻿using System.Collections.Generic;

namespace SistemaEncuestas.Models.Domain
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Estatus {get; set; }

        public virtual ICollection<Encuesta> Encuestas { get; set; }
    }
}