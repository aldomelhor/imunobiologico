using Imunobiologico.Negocio.Imunobiologico;
using Imunobiologico.Negocio.Interfaces;
using Imunobiologico.Repositorio.Interface;
using Moq;
using System;
using Xunit;

namespace Imunobiologico.Teste.Imunobiologico
{
    public class ImunobiologicoTestes 
    {

        private ImunobiologicoNegocio _imunobiologico;

        public ImunobiologicoTestes()
        {
            _imunobiologico = new ImunobiologicoNegocio(new Mock<IImunobiologicoRepositorio>().Object);
        }
                
        [Fact]
        public void TesteAdicionaImunobiologicoValido()
        {
            var result = _imunobiologico.Adicionar("PFIZER", DateTime.Now);

            Assert.True(result);
        }
                        
        [Fact]
        public void TesteAdicionaImunobiologicoInvalido()
        {
            var result = _imunobiologico.Adicionar("Outro", DateTime.Now);

            Assert.False(result);
        }

        [Fact]
        public void TesteAdicionaAnoInvalido()
        {
            var result = _imunobiologico.Adicionar("PFIZER", DateTime.Now.AddYears(-5));

            Assert.False(result);
        }

        [Fact]
        public void TesteAtualizaFabricanteInvalido()
        {
            var result = _imunobiologico.Adicionar("Outro", DateTime.Now);

            Assert.False(result);
        }

        [Fact]
        public void TesteAtualizaAnoInvalido()
        {
            var result = _imunobiologico.Atualizar(1, "Outro", DateTime.Now.AddYears(-5));

            Assert.False(result);
        }

        [Fact]
        public void TesteApagaFabricanteInvalido()
        {
            var result = _imunobiologico.Apagar(0);

            Assert.False(result);
        }

    }
}
