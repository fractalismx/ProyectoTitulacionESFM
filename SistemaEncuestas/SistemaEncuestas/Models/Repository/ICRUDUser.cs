using System;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaEncuestas.Models.Repository
{
    public interface ICRUDUser<Tipo>
    {
        void Create(Tipo tipo);
        void Update(Tipo tipo);
        void Delete(string id);
        Tipo GetByID(string id);
        IQueryable<Tipo> GetAll();
        IQueryable<Tipo> FindBy(Expression<Func<Tipo,bool>> condition);
    }
}
