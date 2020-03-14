using System;

namespace ProjetoAutores.Domain.Entities
{
    public class AutorEntity : BaseEntity
    {
        public string Nome { get; private set; }
        public AutorEntity(string nome)
        {
            setNome(nome);
        }

        public void setNome(string nome)
        {
            if (string.IsNullOrEmpty(nome)) throw new Exception("Nome não pode ser vazio!");

            this.Nome = nome.Trim();
        }
    }
}
