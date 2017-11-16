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
    public class EncuestaRepository : ICRUD<Encuesta>
    {
        private ApplicationDbContext encuestaContext;

        public EncuestaRepository()
        {
            encuestaContext = ContextFactory.GetContext();
        }

        public void Create(Encuesta tipo)
        {
            encuestaContext.Encuestas.Add(tipo);
        }

        public void Delete(int id)
        {
            Encuesta e = GetByID(id);

            encuestaContext.Entry<Encuesta>(e).State = EntityState.Deleted;
        }

        public IQueryable<Encuesta> FindBy(Expression<Func<Encuesta, bool>> condition)
        {
            return encuestaContext.Encuestas.Where(condition).Select(c => c);
        }

        public IQueryable<Encuesta> GetAll()
        {
            return encuestaContext.Encuestas.Select(c=>c);
        }

        public Encuesta GetByID(int id)
        {
            return encuestaContext.Encuestas.FirstOrDefault(c=>c.Id==id);
        }

        public void Update(Encuesta tipo)
        {
            Encuesta e = GetByID(tipo.Id);

            if (e != null)
                encuestaContext.Entry<Encuesta>(e).State = EntityState.Detached;

            encuestaContext.Entry<Encuesta>(tipo).State = EntityState.Modified;
        }
    }
}