using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace ViecLam.Application.Contracts.Persistances
{
    public interface IGenericReponsitory <T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T?> GetByIdAsync(object id);
        Task<T?> FindByIdAsync(object id, bool isTracking = false, CancellationToken cancellationToken = default);
        Task<T?> FindSingleAsync(Expression<Func<T, bool>> predicate, bool isTracking = false, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includeProperties);
        Task DeleteAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task SaveChangeAsync();
        Tuple<int, string> SaveImage(IFormFile imageFile);
        Task DeleteImage(string imageFileName);
        IDbContextTransaction BeginTransaction();
    }
}
