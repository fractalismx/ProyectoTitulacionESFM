using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.Models.Repository.Infrastructure;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaEncuestas.Models.Repository.Entity
{
    public class UsuarioRepository : ICRUDUser<Usuario>
    {
        private SistemaEncuestaContext usuarioContext = null;

        public UsuarioRepository()
        {
            usuarioContext = usuarioContext ?? new SistemaEncuestaContext();
        }

        public void Create(Usuario tipo)
        {
            usuarioContext.Usuarios.Add(tipo);
        }

        public void Delete(string id)
        {
            Usuario u = GetByID(id);

            usuarioContext.Entry<Usuario>(u).State = EntityState.Deleted;
        }

        public IQueryable<Usuario> FindBy(Expression<Func<Usuario, bool>> condition)
        {
            return usuarioContext.Usuarios.Where(condition).Select(c => c);
        }

        public IQueryable<Usuario> GetAll()
        {
            return usuarioContext.Usuarios.Select(c => c);
        }

        public Usuario GetByID(string id)
        {
            string i = id.ToString();
            return usuarioContext.Usuarios.FirstOrDefault(c => c.Id == i);
        }

        public void Update(Usuario tipo)
        {
            Usuario u = GetByID(tipo.Id);

            if (u != null)
                usuarioContext.Entry<Usuario>(u).State = EntityState.Detached;

            usuarioContext.Entry<Usuario>(tipo).State = EntityState.Modified;
        }
    }
}
