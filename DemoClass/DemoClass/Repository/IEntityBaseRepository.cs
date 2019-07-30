using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DemoClass.Repository
{
    public interface IEntityBaseRepository<T> where T : class
    {
        DbContext GetDbContext();
        IQueryable<T> GetAll(bool isAsNoTracking);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool isDisableTracking = true);
        Task<bool> InsertAsync(T entity);  
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
