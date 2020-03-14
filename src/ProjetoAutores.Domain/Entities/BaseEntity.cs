using System;

namespace ProjetoAutores.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataDeCadastro { get; set; }

        public BaseEntity()
        {
            DataDeCadastro = DateTime.UtcNow;
        }
    }
}
