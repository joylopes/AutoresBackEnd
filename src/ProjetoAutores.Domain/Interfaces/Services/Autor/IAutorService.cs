using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoAutores.Domain.Entities;
using ProjetoAutores.Domain.ViewModel;

namespace ProjetoAutores.Domain.Interfaces.Services.Autor
{
    public interface IAutorService
    {
        Task<AutorEntity> Get(int id);
        Task<IEnumerable<AutorEntity>> GetAll();
        Task<AutorViewModel> ListarAutoresComNomeFormatado();
        Task<AutorEntity> Post(AutorEntity autor);
        AutorViewModel Adicionar(AutorViewModel autor);
        Task<AutorEntity> Put(AutorEntity autor);
        Task<bool> Delete(int id);
    }
}
