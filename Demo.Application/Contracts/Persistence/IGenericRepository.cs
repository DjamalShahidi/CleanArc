using System.Linq.Expressions;

namespace Demo.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<List<T>> AddRangeAsync(List<T> entities);
        Task<bool> Exists(int id);
        Task<T> GetAsync(int id);
        Task<List<T>> GetRangeAsync(Expression<Func<T, bool>> filter, int? from, int? to );
        void Delete(T entity);
        void Update(T entity);


        //Task<T> Update(T entity);
        //    Task Delete(int id);
        //    Task<int> Count(int id);
        //    Task<T> Find(int id);
        //    Task<T> FindAsync(int id);

    }
}
