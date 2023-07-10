namespace SistemaEncuestas.Models.Repository
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
