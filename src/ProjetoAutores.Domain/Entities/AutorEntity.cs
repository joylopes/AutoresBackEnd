using System;

namespace ProjetoAutores.Domain.Entities
{
    public class AutorEntity : BaseEntity
    {
        private string _Nome;
        public string Nome
        {
            get
            {
                return _Nome;
            }
            set { _Nome = (!string.IsNullOrEmpty(Nome)) ? Nome : throw new Exception("Nome não pode ser vazio!"); }
        }
    }
}
