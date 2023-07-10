using System;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaEncuestas.Models.Repository
{
    public interface ICRUD<Tipo>
    {
        void Create(Tipo tipo);
        void Update(Tipo tipo);
        void Delete(int id);
        Tipo GetByID(int id);
        IQueryable<Tipo> GetAll();
        IQueryable<Tipo> FindBy(Expression<Func<Tipo,bool>> condition);
    }
}
