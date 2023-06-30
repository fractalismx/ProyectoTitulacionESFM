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

        public DbSet<Usuario> Usuarios { get; set; }
        
    }
}