using JP_Devolupment.Domain.Interfaces;
using JP_Devolupment.Infra.Data.Context;

namespace JP_Devolupment.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DevolupmentContext _context;

        public UnitOfWork(DevolupmentContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
