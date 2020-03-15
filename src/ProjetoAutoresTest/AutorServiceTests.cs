using ProjetoAutores.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ServiceTeste
{
    public class AutorServiceTests
    {
        [Fact]
        public void Autor_FormatarNomeSemSobrenome_ReTornaNomeFormatado()
        {
            //Arrange
            var autorService = new AutorService();

            //Act
            var resultado = autorService.FormatarNomeSemSobrenome("silva");

            //Assert
            Assert.Equal(expected:"SILVA", actual: resultado);
        }

        [Theory]
        [InlineData("Silva", "SILVA")]
        [InlineData("SiLvA", "SILVA")]
        public void Autor_FormatarNomeSemSobrenome_ReTornaNomeFormatadoCorreto(string nome, string resultadoEsperado)
        {
            //Arrange
            var autorService = new AutorService();

            //Act
            var resultado = autorService.FormatarNomeSemSobrenome(nome);

            //Assert
            Assert.Equal(expected: resultadoEsperado, actual: resultado);
        }

    }
}
