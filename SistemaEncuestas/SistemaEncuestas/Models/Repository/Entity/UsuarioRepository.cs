using SistemaEncuestas.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using SistemaEncuestas.Models.Repository.Infrastructure;
using System.Data.Entity;

namespace SistemaEncuestas.Models.Repository.Entity
{
    public class UsuarioRepository : ICRUD<Usuario>
    {
        private SistemaEncuestaContext usuarioContext=null;

        public UsuarioRepository()
        {
            usuarioContext = usuarioContext??new SistemaEncuestaContext();
        }
        public void Create(Usuario tipo)
        {
            usuarioContext.Usuarios.Add(tipo);
        }

        public void Delete(int id)
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
            return usuarioContext.Usuarios.Select(c=>c);
        }

        public Usuario GetByID(int id)
        {
            string i = id.ToString();
            return usuarioContext.Usuarios.FirstOrDefault(c=>c.Id==i);
        }

        public void Update(Usuario tipo)
        {
            Usuario u = GetByID(Int32.Parse(tipo.Id));

            if (u != null)
                usuarioContext.Entry<Usuario>(u).State = EntityState.Detached;

            usuarioContext.Entry<Usuario>(tipo).State = EntityState.Modified;
        }
    }
}
