using Demo.Domain;

namespace Demo.Application.Contracts.Persistence
{
    public interface IBookRepository:IGenericRepository<Book>
    {
        Task<bool> IsExistWithTitle(string title, CancellationToken cancellationToken);
    }
}
