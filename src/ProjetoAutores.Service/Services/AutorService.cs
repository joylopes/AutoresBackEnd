using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoAutores.Domain.Entities;
using ProjetoAutores.Domain.Interfaces;
using ProjetoAutores.Domain.Interfaces.Services.Autor;

namespace ProjetoAutores.Service.Services
{
    public class AutorService : IAutorService
    {
        private IRepository<AutorEntity> _repository;

        public AutorService(IRepository<AutorEntity> repository)
        {
            _repository = repository;
        }
        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AutorEntity> Get(int id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<AutorEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<AutorEntity> Post(AutorEntity autor)
        {
            return await _repository.InsertAsync(autor);
        }

        public Task<AutorEntity> Put(AutorEntity autor)
        {
            throw new System.NotImplementedException();
        }
    }
}
