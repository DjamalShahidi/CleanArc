using Demo.Domain;

namespace Demo.Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetListAsync();
        Task<T> AddAsync(T entity);


        //Task<T> Update(T entity);
        //    Task Delete(int id);
        //    Task<int> Count(int id);
        //    Task<T> Find(int id);
        //    Task<T> FindAsync(int id);

    }
}
