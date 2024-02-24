using Demo.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Demo.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DemoDbContext _demoDbContext;
        internal DbSet<T> dbSet;

        public GenericRepository(DemoDbContext demoDbContext)
        {
            this._demoDbContext = demoDbContext;
            dbSet = _demoDbContext.Set<T>();

        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _demoDbContext.AddAsync(entity, cancellationToken);
            await _demoDbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<List<T>> AddRangeAsync(List<T> entities, CancellationToken cancellationToken)
        {
            await _demoDbContext.AddRangeAsync(entities, cancellationToken);
            await _demoDbContext.SaveChangesAsync(cancellationToken);
            return entities;
        }
        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
           var entity= await GetAsync(id, cancellationToken);

            return entity != null;
        }

        public async Task<T> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _demoDbContext.Set<T>().FindAsync(id, cancellationToken);
        }

        public async Task Delete(T entity, CancellationToken cancellationToken)
        {
            _demoDbContext.Set<T>().Remove(entity);
            await _demoDbContext.SaveChangesAsync(cancellationToken);
        }

  
        public async Task<List<T>> GetRangeAsync(Expression<Func<T, bool>> filter,int? from=null,int? to=null, CancellationToken cancellationToken=default)
        {
            IQueryable<T> query=dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = query.Where(filter);

            if (from != null || to != null)
            {
                if (from == null)
                {
                    from = 0;
                }
                else if (to == null)
                {
                    to = 10;
                }

                query = query.Skip(from.Value).Take(to.Value);

            }

            return await query.ToListAsync(cancellationToken);

        }

        public async Task Update(T entity, CancellationToken cancellationToken)
        {
            _demoDbContext.Entry(entity).State = EntityState.Modified;
            await _demoDbContext.SaveChangesAsync(cancellationToken);
        }
    }

    //public class Repository<T> : IRepository<T> where T : class
    //}
}
