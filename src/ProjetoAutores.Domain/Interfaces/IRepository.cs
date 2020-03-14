using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoAutores.Domain.Entities;

namespace ProjetoAutores.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<T> SelectAsync(int id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> DeleteAsync(int id);
    }
}
