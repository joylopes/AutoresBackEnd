using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoAutores.Domain.Entities;
using ProjetoAutores.Domain.Interfaces;
using ProjetoAutores.Domain.Interfaces.Services.Autor;
using ProjetoAutores.Domain.ViewModel;
using ProjetoAutores.Domain.Helpers;

namespace ProjetoAutores.Service.Services
{
    public class AutorService : IAutorService
    {
        private IRepository<AutorEntity> _repository;

        public AutorService(IRepository<AutorEntity> repository)
        {
            _repository = repository;
        }

        public AutorService()
        {
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

        public List<AutorViewModel> Adicionar(List<AutorViewModel> autorModel)
        {
            foreach (var item in autorModel)
            {
                AutorEntity autor = new AutorEntity(item.Nome);
                _repository.Insert(autor);
                item.Id = autor.Id;
            }

            return autorModel;
        }

        public Task<AutorEntity> Put(AutorEntity autor)
        {
            throw new System.NotImplementedException();
        }
        public async Task<List<AutorViewModel>> ListarAutoresComNomeFormatado()
        {
            List<AutorViewModel> autoresModel = new List<AutorViewModel>();
            var autores = await _repository.SelectAsync();

            foreach (var item in autores.OrderByDescending(x => x.Id))
            {
                autoresModel.Add(new AutorViewModel
                {
                    Id = item.Id,
                    Nome = this.FormatarNome(item.Nome),
                    DataDeCadastro = item.DataDeCadastro
                });
            }

            return autoresModel;
        }

        public string FormatarNome(string nome)
        {
            string nomeFormatado = String.Empty;
            string[] nomeArray = nome.ToLower().Split(' ');

            if (nomeArray.Length > 1)
                nomeFormatado = this.FormatarNomeComSobrenome(nomeArray);
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

            if (this.validarNomeComAgnome(nomeArray))
                return this.FormatarNomeComAgnome(nomeArray);
            else
                return this.FormatarNomeSemAgnome(nomeArray);

        }
        public string FormatarNomeComAgnome(string[] nomeArray)
        {
            string nomeFormatado = String.Empty;

            if (nomeArray.Length >= 3)
            {
                string sobrenome = nomeArray[nomeArray.Length - 2].ToUpper();
                sobrenome += " " + nomeArray[nomeArray.Length - 1].ToUpper();
                nomeFormatado = sobrenome + ",";

                for (var i = 0; i < nomeArray.Length; i++)
                {
                    if ((nomeArray.Length - 1) != i && (nomeArray.Length - 2) != i)
                    {
                        if (this.validarNomeComPreposicao(nomeArray[i]))
                        {
                            nomeFormatado += " " + nomeArray[i];
                        }
                        else
                        {
                            nomeFormatado += " " + FormatarTexto.Capitalize(nomeArray[i]);
                        }
                    }
                }
            }

            return nomeFormatado;
        }
        public string FormatarNomeSemAgnome(string[] nomeArray)
        {
            string sobrenome = nomeArray[nomeArray.Length - 1].ToUpper();
            string nomeFormatado = sobrenome + ",";

            for (var i = 0; i < nomeArray.Length; i++)
            {
                if ((nomeArray.Length - 1) != i)
                {
                    if (this.validarNomeComPreposicao(nomeArray[i]))
                    {
                        nomeFormatado += " " + nomeArray[i];
                    }
                    else
                    {
                        nomeFormatado += " " + FormatarTexto.Capitalize(nomeArray[i]);
                    }
                }
            }

            return nomeFormatado;
        }
        public bool validarNomeComPreposicao(string nome)
        {
            List<string> listaDePreposicoes = new List<string>() { "da", "de", "do", "das", "dos" };

            if (listaDePreposicoes.Any(l => l.Equals(nome)))
                return true;

            return false;
        }

        public bool validarNomeComAgnome(string[] nomeArray)
        {
            List<string> listaDeAgnomes = new List<string>() { "FILHO", "FILHA", "NETO", "NETA", "SOBRINHO", "SOBRINHA", "JUNIOR" };

            if (listaDeAgnomes.Any(l => l.Equals(nomeArray[nomeArray.Length - 1].ToUpper())))
                return true;

            return false;
        }
    }
}
