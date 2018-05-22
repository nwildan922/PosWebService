using Pos.Repository.Core;
using Pos.Repository.DataAccess;

namespace Pos.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
            Provinces = new ProvinceRepository(_context);
        }
        public IProvinceRepository Provinces { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
