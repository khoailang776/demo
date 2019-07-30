using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DemoClass.Repository
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        public EntityBaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DbContext GetDbContext()
        {
            return _dbContext;
        }
        public IQueryable<T> GetAll(bool isAsNoTracking)
        {
            if (isAsNoTracking)
            {
                return _dbContext.Set<T>().AsNoTracking();
            }
            return _dbContext.Set<T>();
        }
        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool isDisableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (isDisableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public async Task<bool> InsertAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Entry<T>(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _dbContext.Attach(entity);
                _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
