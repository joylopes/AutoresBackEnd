namespace ProjetoAutores.Domain.Helpers
{
    public static class FormatarTexto
    {

        public static string Capitalize(string texto)
        {
            var textoFormatado = char.ToUpper(texto[0]) + texto.Substring(1);
            return textoFormatado;
        }
    }
}
