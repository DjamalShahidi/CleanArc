using Demo.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DemoDbContext _demoDbContext;

        private IBookRepository _bookRepository;

        public UnitOfWork(DemoDbContext demoDbContext)
        {
            this._demoDbContext = demoDbContext;
        }

        public IBookRepository BookRepository => _bookRepository ??= new BookRepository(_demoDbContext);

        public void Dispose()
        {
            _demoDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(CancellationToken cancellationToken=default)
        {
            await _demoDbContext.SaveChangesAsync();
        }
    }
}
