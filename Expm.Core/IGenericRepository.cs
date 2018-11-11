using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expm.Core
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(string  id);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AllAsync();
    }
}