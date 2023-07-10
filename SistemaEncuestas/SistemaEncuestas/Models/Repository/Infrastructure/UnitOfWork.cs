namespace SistemaEncuestas.Models.Repository.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private ApplicationDbContext context =null;

        public ApplicationDbContext Context
        {
            get
            {
                return context = context ?? ContextFactory.GetContext();
            }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Rollback()
        {
            
        }
    }
}