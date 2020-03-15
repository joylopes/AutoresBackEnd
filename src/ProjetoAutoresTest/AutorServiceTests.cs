using ProjetoAutores.Domain.ViewModel;
using ProjetoAutores.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ServiceTeste
{
    public class AutorServiceTests
    {
        [Fact]
        public void ValidarNomeComPreposicao_NomeContemAgnome_ReTornaTrue()
        {
            //Arrange
            var autorService = new AutorService();

            //Act
            var resultado = autorService.validarNomeComPreposicao("da");

            //Assert
            Assert.True(resultado);
        }

        [Theory]
        [InlineData("das")]
        [InlineData("do")]
        [InlineData("dos")]
        [InlineData("de")]
        public void ValidarNomeComPreposicao_NomeContemAgnome_True(string nome)
        {
            //Arrange
            var autorService = new AutorService();

            //Act
            var resultado = autorService.validarNomeComPreposicao(nome);

            //Assert
            Assert.True(resultado);
        }


        [Fact]
        public void ValidarNomeComPreposicao_NomeContemAgnome_ReTornaFalse()
        {
            //Arrange
            var autorService = new AutorService();

            //Act
            var resultado = autorService.validarNomeComPreposicao("na");

            //Assert
            Assert.False(resultado);
        }

        [Fact]
        public void ValidarNomeComAgnome_NomeContemAgnome_ReTornaTrue()
        {
            //Arrange
            var autorService = new AutorService();

            //Act
            var resultado = autorService.validarNomeComAgnome(new string[] { "FILHO", "filha", "NETO", "neta", "SOBRINHO", "SOBRINHA", "JUNIOR" });

            //Assert
            Assert.True(resultado);
        }

        [Fact]
        public void ValidarNomeComAgnome_NomeContemAgnome_ReTornaFalse()
        {
            //Arrange
            var autorService = new AutorService();

            //Act
            var resultado = autorService.validarNomeComAgnome(new string[] { "antonio", "carlos", "silva" });

            //Assert
            Assert.False(resultado);
        }

        [Fact]
        public void Autor_FormatarNomeSemSobrenome_ReTornaNomeFormatado()
        {
            //Arrange
            var autorService = new AutorService();

            //Act
            var resultado = autorService.FormatarNomeSemSobrenome("silva");

            //Assert
            Assert.Equal(expected: "SILVA", actual: resultado);
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

        [Fact]
        public void Autor_Adicionar_ReTornaErroNomeVazio()
        {
            //Arrange & Act & Assert
            var autorService = new AutorService();
            var model = new List<AutorViewModel>();
            var obj = new AutorViewModel() { Nome = null };
            model.Add(obj);

            var exception = Assert.Throws<Exception>(testCode: () =>
              {
                  autorService.Adicionar(model);
              });

            Assert.Equal(expected: "Nome não pode ser vazio!", actual: exception.Message);
        }

    }
}
