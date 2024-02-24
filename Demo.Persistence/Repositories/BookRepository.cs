using Demo.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Demo.Persistence.Repositories
{
    public class BookRepository : GenericRepository<Domain.Book>, IBookRepository
    {
        private readonly DemoDbContext _demoDbContext;

        public BookRepository(DemoDbContext demoDbContext):base(demoDbContext)
        {
            this._demoDbContext = demoDbContext;
        }
        public async Task<bool> IsExistWithTitle(string title, CancellationToken cancellationToken)
        {
            return await _demoDbContext.Books.AnyAsync(a => a.Title == title);
        }

    }
}
