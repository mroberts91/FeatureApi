using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeatureApi.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetByAsync(System.Linq.Expressions.Expression<System.Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> ListAllAsync();
		Task<IReadOnlyList<T>> ListAllAsync(int perPage, int page);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
