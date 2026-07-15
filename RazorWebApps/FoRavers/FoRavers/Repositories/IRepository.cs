using FoRavers.Models;
using System.Linq.Expressions;

namespace FoRavers.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task<T?> GetByIdAsync(Guid id);
        
        Task AddAsync(T entity);

        void Update(T entity);

        void Remove(T entity);

    }
}
