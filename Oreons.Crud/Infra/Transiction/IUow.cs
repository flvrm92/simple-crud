namespace Infra.Transiction
{
    public interface IUow
    {
        void Commit();
        void Rollback();
        void Dispose();
    }
}
