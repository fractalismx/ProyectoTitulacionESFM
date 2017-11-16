using SistemaEncuestas.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Models.Repository.Infrastructure
{
    public class SistemaEncuestaContext : DbContext
    {
        public SistemaEncuestaContext() : base("MyConnection")
        {
            Database.SetInitializer<SistemaEncuestaContext>(null);
        }

        /*public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }*/
        public DbSet<Usuario> Usuarios { get; set; }
        
    }
}