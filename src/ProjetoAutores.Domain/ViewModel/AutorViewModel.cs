using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace ProjetoAutores.Domain.ViewModel
{
    public class AutorViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public DateTime DataDeCadastro { get; set; }
    }
}
