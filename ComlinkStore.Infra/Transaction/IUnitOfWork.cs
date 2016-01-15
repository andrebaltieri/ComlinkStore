namespace ComlinkStore.Infra.Transaction
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
