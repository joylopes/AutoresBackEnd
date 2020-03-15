using System.Collections.Generic;
using System;

namespace ProjetoAutores.Domain.ViewModel
{
    public class AutorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<string> listaDeAutores { get; set; }
        public DateTime DataDeCadastro { get; set; }
    }
}
