using Infra.Context;

namespace Infra.Transiction
{
    public class Uow : IUow
    {
        private readonly MainDataContext _context;

        public Uow(MainDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Do nothing for now :-)
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
