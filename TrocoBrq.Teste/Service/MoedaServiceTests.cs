using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TrocoBrq.Aplication.ViewModels;
using TrocoBrq.Cross.DTO;
using TrocoBrq.Data.Context;
using TrocoBrq.Data.Repository;
using TrocoBrq.Domain.Entities;
using TrocoBrq.Domain.Interface.Repository;
using TrocoBrq.Domain.Interface.Service;
using TrocoBrq.Domain.Service;
using Xunit;

namespace TrocoBrq.Teste.Service
{
    public class MoedaServiceTests : IDisposable
    {
        private MockRepository mockRepository;
        private MoedaDTO[] moedas;
        private Mock<IUnitOfWork> mockUnitOfWork;
        private Mock<IBaseRepository<Moeda, MoedaDTO>> mockIBaseRepository;
        //private Mock<Moeda> moeda;
        private Mock<MoedaDTO> moedaDto;

        public MoedaServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            //this.mockUnitOfWork = this.mockRepository.Create<IUnitOfWork>();
            this.mockUnitOfWork = this.mockRepository.Create<IUnitOfWork>().As<IUnitOfWork>();
            this.mockIBaseRepository = this.mockRepository.Create<IBaseRepository<Moeda, MoedaDTO>>();
        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Sucesso()
        {
            var valorDivida = (decimal)150;
            var valorEntregue = (decimal)200;

            MoedaService service = this.CreateService();

            var baseMoeda = new Mock<IBaseRepository<Moeda, MoedaDTO>>();

            mockUnitOfWork
                .Setup(c => c.MoedaRepository)
                .Returns(baseMoeda.Object);

            mockUnitOfWork
                .Setup(c => c.MoedaRepository.GetAll())
                .Returns(GetMoedas());

            var result = service.ObterTroco(valorDivida, valorEntregue).Result;

            List<MoedaDTO> resultadoEsperado = new List<MoedaDTO>();
            resultadoEsperado.Add(new MoedaDTO
            {

                Valor = 50,
                NotasRetornadas = 1
            });

            Assert.True(result.Status);

            CompareIEnumerable(resultadoEsperado, result.MoedasRetorno,
            (x, y) => x.Valor == y.Valor && x.NotasRetornadas == y.NotasRetornadas);
        }
        
        [Theory]
        [InlineData(15.95, 20)]
        public void SucessoCentavos(decimal valorDivida, decimal valorEntregue)
        {
            MoedaService service = this.CreateService();

            var baseMoeda = new Mock<IBaseRepository<Moeda, MoedaDTO>>();

            mockUnitOfWork
                .Setup(c => c.MoedaRepository)
                .Returns(baseMoeda.Object);

            mockUnitOfWork
                .Setup(c => c.MoedaRepository.GetAll())
                .Returns(GetMoedas());

            var result = service.ObterTroco(valorDivida, valorEntregue).Result;

            List<MoedaDTO> resultadoEsperado = new List<MoedaDTO>();
            resultadoEsperado.Add(new MoedaDTO { Valor = 1, NotasRetornadas = 4 });
            resultadoEsperado.Add(new MoedaDTO { Valor = (decimal)0.05, NotasRetornadas = 1 });

            Assert.True(result.Status);

            CompareIEnumerable(resultadoEsperado, result.MoedasRetorno,
            (x, y) => x.Valor == y.Valor && x.NotasRetornadas == y.NotasRetornadas);
        }
        [Fact]
        public void ErroaoValorMenor()
        {
            var valorDivida = (decimal)10;
            var valorEntregue = (decimal)10000;

            MoedaService service = this.CreateService();

            var userStore = new Mock<IBaseRepository<Moeda, MoedaDTO>>();

            var t = new Mock<CoreContext>();
            mockUnitOfWork
                .Setup(c => c.MoedaRepository)
                .Returns(userStore.Object);

            var result = service.ObterTroco(valorDivida, valorEntregue).Result;

            Assert.False(result.Status);
            Assert.Equal("Não há notas disponíveis para realizar este saque.", result.Mensagem);
        }
        [Fact]
        public void ErroNaoHaNotas()
        {
            var valorDivida = (decimal)10;
            var valorEntregue = (decimal)1;

            MoedaService service = this.CreateService();

            var userStore = new Mock<IBaseRepository<Moeda, MoedaDTO>>();

            var t = new Mock<CoreContext>();
            mockUnitOfWork
                .Setup(c => c.MoedaRepository)
                .Returns(userStore.Object);

            var result = service.ObterTroco(valorDivida, valorEntregue).Result;


            Assert.False(result.Status);
            Assert.Equal("Valor recebido insuficiente", result.Mensagem);
        }

        private MoedaService CreateService()
        {
            return new MoedaService(
                this.mockUnitOfWork.Object);
        }

        private MoedaDTO[] GetMoedas()
        {
            var moedas = new MoedaDTO[]
           {
                new MoedaDTO{
                    Active =true
                    , CriadoPor = "Admin"
                    , DataCriacao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = 100
                }
                , new MoedaDTO{
                    Active =true
                    , CriadoPor = "Admin"
                    , DataCriacao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = 10
                }
                , new MoedaDTO{
                    Active =true
                    , CriadoPor = "Admin"
                    , DataCriacao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = 50
                }
                , new MoedaDTO{
                    Active =true
                    , CriadoPor = "Admin"
                    , DataCriacao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = 5
                }
                , new MoedaDTO{
                    Active =true
                    , CriadoPor = "Admin"
                    , DataCriacao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = 1
                }
                  , new MoedaDTO{
                    Active =true
                    , CriadoPor = "Admin"
                    , DataCriacao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = (decimal)0.5
                }
                  , new MoedaDTO{
                    Active =true
                    , CriadoPor = "Admin"
                    , DataCriacao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = (decimal)0.01
                }
                  , new MoedaDTO{
                    Active =true
                    , CriadoPor = "Admin"
                    , DataCriacao = DateTime.Now
                    , NotasRetornadas = 0
                    , Quantidade = 5
                    , Valor = (decimal)0.05
                }
           };
            return moedas;
        }

        private static void CompareIEnumerable<T>(IEnumerable<T> one, IEnumerable<T> two, Func<T, T, bool> comparisonFunction)
        {
            var oneArray = one as T[] ?? one.ToArray();
            var twoArray = two as T[] ?? two.ToArray();

            //if (oneArray.Length != twoArray.Length)
            //{
            //    Assert.False(oneArray.Length != twoArray.Length);
            //}

            for (int i = 0; i < oneArray.Length; i++)
            {
                var isEqual = comparisonFunction(oneArray[i], twoArray[i]);
                Assert.True(isEqual);
            }
        }
    }
}
