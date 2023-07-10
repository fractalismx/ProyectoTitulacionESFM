using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.Models.Repository.Infrastructure;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaEncuestas.Models.Repository.Entity
{
    public class CategoriaRepository: ICRUD<Categoria>
    {
        private ApplicationDbContext categoriaContext;

        public CategoriaRepository()
        {
            categoriaContext = ContextFactory.GetContext();
        }

        public void Create(Categoria categoria)
        {
            categoriaContext.Categorias.Add(categoria);
        }

        public void Delete(int id)
        {
            Categoria c = GetByID(id);

            categoriaContext.Entry<Categoria>(c).State = EntityState.Deleted;
        }

        public IQueryable<Categoria> FindBy(Expression<Func<Categoria, bool>> condition)
        {
            return categoriaContext.Categorias.Where(condition).Select(c => c);
        }

        public IQueryable<Categoria> GetAll()
        {
            return categoriaContext.Categorias.Select(c=>c);
        }

        public Categoria GetByID(int id)
        {
            return categoriaContext.Categorias.FirstOrDefault(c=>c.Id==id);
        }

        public void Update(Categoria categoria)
        {
            Categoria c = GetByID(categoria.Id);

            if (c != null)
                categoriaContext.Entry<Categoria>(c).State = EntityState.Detached;

            categoriaContext.Entry<Categoria>(categoria).State = EntityState.Modified;
        }
    }
}