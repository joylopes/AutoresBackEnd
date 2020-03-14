using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoAutores.Domain.Entities;

namespace ProjetoAutores.Domain.Interfaces.Services.Autor
{
    public interface IAutorService
    {
        Task<AutorEntity> Get();
        Task<IEnumerable<AutorEntity>> GetAll();
        Task<AutorEntity> Post(AutorEntity autor);
        Task<AutorEntity> Put(AutorEntity autor);
        Task<bool> Delete(int id);
    }
}
