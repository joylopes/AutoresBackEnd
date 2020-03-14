using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoAutores.Domain.DTO;
using ProjetoAutores.Domain.Entities;

namespace ProjetoAutores.Domain.Interfaces.Services.Autor
{
    public interface IAutorService
    {
        Task<AutorEntity> Get(int id);
        Task<IEnumerable<AutorEntity>> GetAll();
        Task<IEnumerable<AutorDTO>> ListarAutoresComNomeFormatado();
        Task<AutorEntity> Post(AutorEntity autor);
        Task<AutorDTO> Adicionar(AutorDTO autor);
        Task<AutorEntity> Put(AutorEntity autor);
        Task<bool> Delete(int id);
    }
}
