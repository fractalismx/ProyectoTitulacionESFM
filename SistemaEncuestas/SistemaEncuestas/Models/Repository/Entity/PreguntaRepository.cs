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
    public class PreguntaRepository : ICRUD<Pregunta>
    {
        private ApplicationDbContext preguntaContext;

        public PreguntaRepository()
        {
            preguntaContext = ContextFactory.GetContext();
        }

        public void Create(Pregunta tipo)
        {
            preguntaContext.Preguntas.Add(tipo);
        }

        public void Delete(int id)
        {
            Pregunta p = GetByID(id);

            preguntaContext.Entry<Pregunta>(p).State = EntityState.Deleted;
        }

        public IQueryable<Pregunta> FindBy(Expression<Func<Pregunta, bool>> condition)
        {
            return preguntaContext.Preguntas.Where(condition).Select(c => c);
        }

        public IQueryable<Pregunta> GetAll()
        {
            return preguntaContext.Preguntas.Select(c=>c);
        }

        public Pregunta GetByID(int id)
        {
            return preguntaContext.Preguntas.FirstOrDefault(c=>c.Id==id);
        }

        public void Update(Pregunta tipo)
        {
            Pregunta p = GetByID(tipo.Id);

            if (p != null)
                preguntaContext.Entry<Pregunta>(p).State = EntityState.Detached;

            preguntaContext.Entry<Pregunta>(tipo).State = EntityState.Detached;
        }
    }
}