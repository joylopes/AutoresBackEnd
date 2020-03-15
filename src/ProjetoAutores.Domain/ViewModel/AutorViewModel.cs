using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace ProjetoAutores.Domain.ViewModel
{
    public class AutorViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public string Nome { get; set; }
        public List<string> listaDeNomes { get; set; }
        [JsonIgnore]
        public DateTime DataDeCadastro { get; set; }
    }
}
