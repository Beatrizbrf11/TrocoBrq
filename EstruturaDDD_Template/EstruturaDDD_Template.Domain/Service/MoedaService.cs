using TrocoBrq.Cross.DTO;
using TrocoBrq.Domain.Entities;
using TrocoBrq.Domain.Interface.Repository;
using TrocoBrq.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;

namespace TrocoBrq.Domain.Service
{
    public class MoedaService : IMoedaService
    {
        private readonly IUnitOfWork _uow;

        public MoedaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<RetornoDTO> ObterTroco(decimal valorDivida, decimal valorEntregue)
        {
            var retornoDTO = new RetornoDTO();
            try
            {

                decimal valorTroco = (decimal)valorEntregue - (decimal)valorDivida;
                var moedas = new List<MoedaDTO>();
                var moedasAux = new List<MoedaDTO>();
                var moedasRetorno = new List<MoedaDTO>();

                moedas = _uow.MoedaRepository.GetAll().OrderByDescending(m => m.Valor).ToList();

                #region Validacao 

                if (valorEntregue < valorDivida) { return new RetornoDTO { Status = false, Mensagem = "Valor recebido insuficiente" }; }
                if (valorEntregue == valorDivida) { return new RetornoDTO { Status = false, Mensagem = "Não há troco" }; }

                #endregion

                while (valorTroco != 0)
                {
                    for (int i = 0; i < moedas.Count;)
                    {
                        if (moedas[i].Valor <= valorTroco && moedas[i].Quantidade > 0)
                        {
                            if (moedas[i].Valor == (decimal)0.01d) { }

                            valorTroco -= moedas[i].Valor;
                            moedas[i].Quantidade--;
                            moedas[i].NotasRetornadas++;
                            moedasRetorno.Add(moedas[i]);
                            break;
                        }
                        else
                            moedas.Remove(moedas[i]);
                    }
                    if (valorTroco != 0 && moedas.Count <= 0) { return new RetornoDTO { Status = false, Mensagem = "Não há notas disponíveis para realizar este saque." }; }
                }

                //moedasRetorno.ForEach(moeda => _uow.MoedaRepository.Update(moeda));

                //_uow.Commit();

                return new RetornoDTO { Status = true, MoedasRetorno = moedasRetorno.Distinct().ToList() };

            }
            catch (Exception ex)
            {
                return new RetornoDTO { Status = false, Mensagem = "Erro inesperado" };
            }
        }

        private void UpdateMoeda(MoedaDTO moeda)
        {
            var ctx = _uow.MoedaRepository.GetById(moeda.Id);

            ctx.Quantidade = moeda.Quantidade;

            _uow.MoedaRepository.Update(ctx);
        }
    }
}
