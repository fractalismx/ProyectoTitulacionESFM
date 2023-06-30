using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.Models.Repository.Infrastructure;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaEncuestas.Models.Repository.Entity
{
    public class RespuestaUsuarioRepository : ICRUD<RespuestaUsuario>
    {
        private ApplicationDbContext respuestaUsuarioContext;

        public RespuestaUsuarioRepository()
        {
            respuestaUsuarioContext = ContextFactory.GetContext();
        }

        public void Create(RespuestaUsuario tipo)
        {
            respuestaUsuarioContext.RespuestaUsuarios.Add(tipo);
        }

        public void Delete(int id)
        {
            RespuestaUsuario r = GetByID(id);

            respuestaUsuarioContext.Entry<RespuestaUsuario>(r).State = EntityState.Deleted;
        }

        public IQueryable<RespuestaUsuario> FindBy(Expression<Func<RespuestaUsuario, bool>> condition)
        {
            return respuestaUsuarioContext.RespuestaUsuarios.Where(condition).Select(c => c);
        }

        public IQueryable<RespuestaUsuario> GetAll()
        {
            return respuestaUsuarioContext.RespuestaUsuarios.Select(c => c);
        }

        public RespuestaUsuario GetByID(int id)
        {
            return respuestaUsuarioContext.RespuestaUsuarios.FirstOrDefault(c => c.Id == id);
        }

        public void Update(RespuestaUsuario tipo)
        {
            RespuestaUsuario r = GetByID(tipo.Id);

            if (r != null)
                respuestaUsuarioContext.Entry<RespuestaUsuario>(r).State = EntityState.Detached;

            respuestaUsuarioContext.Entry<RespuestaUsuario>(tipo).State = EntityState.Modified;
        }
    }
}