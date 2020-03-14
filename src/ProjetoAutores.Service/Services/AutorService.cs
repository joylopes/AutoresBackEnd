using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoAutores.Domain.Entities;
using ProjetoAutores.Domain.Interfaces;
using ProjetoAutores.Domain.Interfaces.Services.Autor;
using ProjetoAutores.Domain.DTO;

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
        public async Task<IEnumerable<AutorDTO>> ListarAutoresComNomeFormatado()
        {
            List<AutorDTO> autoresDTO = new List<AutorDTO>();
            var autores = await _repository.SelectAsync();

            foreach (var item in autores)
            {
                autoresDTO.Add(new AutorDTO
                {
                    Id = item.Id,
                    Nome = this.FormatarNome(item.Nome),
                    DataDeCadastro = item.DataDeCadastro
                });
            }

            return autoresDTO;
        }

        public string FormatarNome(string nome)
        {
            string nomeFormatado = String.Empty;
            string[] nomeArray = nome.ToLower().Split(' ');

            if (nomeArray.Length > 1)
                this.FormatarNomeComSobrenome(nomeArray);
            else if (nomeArray.Length == 1)
                nomeFormatado = this.FormatarNomeSemSobrenome(nome);

            return nomeFormatado;
        }
        public string FormatarNomeSemSobrenome(string nome)
        {
            return nome.ToUpper();
        }
        public string FormatarNomeComSobrenome(string[] nomeArray)
        {
            List<string> listaDeAgnomes = new List<string>() { "FILHO", "FILHA", "NETO", "NETA", "SOBRINHO", "SOBRINHA", "JUNIOR" };
            List<string> listaDePreposicoes = new List<string>() { "da", "de", "do", "das", "dos" };

            if (listaDeAgnomes.Any(l => l.Equals(nomeArray[nomeArray.Length - 1].ToUpper())))
                return this.FormatarNomeComAgnome(nomeArray);
            else
                return this.FormatarNomeSemAgnome(nomeArray);
        }
        public string FormatarNomeComAgnome(string[] nomeArray)
        {

            return null;
        }
        public string FormatarNomeSemAgnome(string[] nomeArray)
        {
            string sobrenome = nomeArray[nomeArray.Length - 1].ToUpper();
            string nomeFormatado = sobrenome + ",";

            for (var i = 0; i < nomeArray.Length; i++)
            {
                if ((nomeArray.Length - 1) != i)
                    nomeFormatado += " " + nomeArray[i];
            }

            return nomeFormatado;
        }
    }
}
