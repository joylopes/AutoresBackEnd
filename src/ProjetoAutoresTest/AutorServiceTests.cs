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

        [Fact]
        public void Autor_FormatarNomeComSobrenome_ReTornaNomeFormatado()
        {
            //Arrange
            var autorService = new AutorService();

            //Act
            var resultado = autorService.FormatarNomeComSobrenome(new string[] { "joice", "lopes", "da", "silva" });

            //Assert
            Assert.Equal(expected: "SILVA, Joice Lopes da", actual: resultado);
        }

        [Theory]
        [InlineData(new string[] { "carlos", "gustavo", "pereira" }, "PEREIRA, Carlos Gustavo")]
        [InlineData(new string[] { "antonio", "carlos", "da", "silva" }, "SILVA, Antonio Carlos da")]
        public void Autor_FormatarNomeComSobrenome_ReTornaNomeFormatadoCorreto(string[] nome, string resultadoEsperado)
        {
            //Arrange
            var autorService = new AutorService();

            //Act
            var resultado = autorService.FormatarNomeComSobrenome(nome);

            //Assert
            Assert.Equal(expected: resultadoEsperado, actual: resultado);
        }

    }
}
