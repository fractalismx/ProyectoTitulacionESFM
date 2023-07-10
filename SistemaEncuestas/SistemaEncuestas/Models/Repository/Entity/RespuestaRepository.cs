using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.Models.Repository.Infrastructure;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaEncuestas.Models.Repository.Entity
{
    public class RespuestaRepository: ICRUD<Respuesta>
    {
        private ApplicationDbContext respuestaContext;

        public RespuestaRepository()
        {
            respuestaContext = ContextFactory.GetContext();
        }

        public void Create(Respuesta tipo)
        {
            respuestaContext.Respuestas.Add(tipo);
        }

        public void Delete(int id)
        {
            Respuesta r = GetByID(id);

            respuestaContext.Entry<Respuesta>(r).State = EntityState.Deleted;
        }

        public IQueryable<Respuesta> FindBy(Expression<Func<Respuesta, bool>> condition)
        {
            return respuestaContext.Respuestas.Where(condition).Select(c=>c);
        }

        public IQueryable<Respuesta> GetAll()
        {
            return respuestaContext.Respuestas.Select(c => c);
        }

        public Respuesta GetByID(int id)
        {
            return respuestaContext.Respuestas.FirstOrDefault(c=>c.Id==id);
        }

        public void Update(Respuesta tipo)
        {
            Respuesta r = GetByID(tipo.Id);

            if (r != null)
                respuestaContext.Entry<Respuesta>(r).State = EntityState.Detached;

            respuestaContext.Entry<Respuesta>(tipo).State = EntityState.Modified;
        }
    }
}