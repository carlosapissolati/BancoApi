using BancoApi.Domain.Entities;
using BancoApi.Domain.Interfaces;
using BancoApi.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Services
{
    public class ContaPoupancaService : IContaService
    {

        private readonly IContaPoupancaRepository _contaPoupancaRepository;
        private readonly INotificador _notificador;

        public ContaPoupancaService(IContaPoupancaRepository contaPoupancaRepository, INotificador notificador)
        {
            _contaPoupancaRepository = contaPoupancaRepository;
            _notificador = notificador;
        }

        public bool CriarConta(object conta)
        {
            ContaPoupanca contaPoupanca = (ContaPoupanca) conta;
            if (_contaPoupancaRepository.ExisteConta(contaPoupanca.Id))
            {
                _notificador.Adicionar("Existe um conta corrente com esse id");
                return false;
            }

            _contaPoupancaRepository.CriarConta(contaPoupanca);

            return true;
        }


        public object Depositar(int Id, double Valor)
        {
            ContaPoupanca contaPoupanca;
            if (!_contaPoupancaRepository.ExisteConta(Id))
            {
                _notificador.Adicionar("Não existe essa Conta Corrente");
                return null;
            }

            contaPoupanca = _contaPoupancaRepository.BuscarContaPorId(Id);

            contaPoupanca.Deposita(Valor);

            _contaPoupancaRepository.AlterarConta(contaPoupanca);

            return contaPoupanca;
        }

        public object Sacar(int Id, double Valor)
        {
            ContaPoupanca contaPoupanca;
            if (!_contaPoupancaRepository.ExisteConta(Id))
            {
                _notificador.Adicionar("Não existe essa Conta Corrente");
                return null;
            }

            contaPoupanca = _contaPoupancaRepository.BuscarContaPorId(Id);

            if (!contaPoupanca.Saca(Valor))
            {
                _notificador.Adicionar("Saldo Insuficente");
                return null;
            }

            _contaPoupancaRepository.AlterarConta(contaPoupanca);

            return contaPoupanca;
        }

    }
}
