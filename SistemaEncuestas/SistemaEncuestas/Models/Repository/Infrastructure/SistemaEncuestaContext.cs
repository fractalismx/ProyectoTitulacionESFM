using SistemaEncuestas.Models.Domain;
using System.Data.Entity;

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