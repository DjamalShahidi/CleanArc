using Demo.Domain;

namespace Demo.Application.Persistence.Contracts
{
    public interface IBookRepository:IGenericRepository<Book>
    {
        Task<bool> IsExistWithTitle(string title);

    }
}
