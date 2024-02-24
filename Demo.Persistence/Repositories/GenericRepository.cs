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

        public async Task<T> AddAsync(T entity)
        {
            await _demoDbContext.AddAsync(entity);
            return entity;
        }

        public async Task<List<T>> AddRangeAsync(List<T> entities)
        {
            await _demoDbContext.AddRangeAsync(entities);
            return entities;
        }
        public async Task<bool> Exists(int id)
        {
           var entity= await GetAsync(id);

            return entity != null;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _demoDbContext.Set<T>().FindAsync(id);
        }

        public void Delete(T entity)
        {
            _demoDbContext.Set<T>().Remove(entity);
        }

  
        public async Task<List<T>> GetRangeAsync(Expression<Func<T, bool>> filter,int? from=null,int? to=null)
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

            return await query.ToListAsync();

        }

        public void Update(T entity)
        {
            _demoDbContext.Entry(entity).State = EntityState.Modified;
        }
    }

    //public class Repository<T> : IRepository<T> where T : class
    //}
}
