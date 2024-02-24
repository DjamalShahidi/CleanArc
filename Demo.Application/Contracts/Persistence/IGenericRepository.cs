using System.Linq.Expressions;

namespace Demo.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        Task<List<T>> AddRangeAsync(List<T> entities, CancellationToken cancellationToken);
        Task<bool> Exists(int id, CancellationToken cancellationToken);
        Task<T> GetAsync(int id, CancellationToken cancellationToken);
        Task<List<T>> GetRangeAsync(Expression<Func<T, bool>> filter, int? from, int? to, CancellationToken cancellationToken);
        Task Delete(T entity, CancellationToken cancellationToken);
        Task Update(T entity, CancellationToken cancellationToken);


        //Task<T> Update(T entity);
        //    Task Delete(int id);
        //    Task<int> Count(int id);
        //    Task<T> Find(int id);
        //    Task<T> FindAsync(int id);

    }
}
