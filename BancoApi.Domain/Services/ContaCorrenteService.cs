using BancoApi.Domain.Entities;
using BancoApi.Domain.Interfaces;
using BancoApi.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Services
{
    public class ContaCorrenteService : IContaService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRespository;
        private readonly INotificador _notificador;

        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRespository, INotificador notificador)
        {
            _contaCorrenteRespository = contaCorrenteRespository;
            _notificador = notificador;
        }

        public bool CriarConta(object conta)
        {
            ContaCorrente contaCorrente = (ContaCorrente) conta;
            if (_contaCorrenteRespository.ExisteContaCorrente(contaCorrente.Id))
            {
                _notificador.Adicionar("ContaCorrente já cadastrada");
                return false;
            }

            _contaCorrenteRespository.CriarContaCorrente(contaCorrente);

            return true;
        }


        public object Depositar(int Id, double Valor)
        {
            ContaCorrente contaCorrente;
            if (!_contaCorrenteRespository.ExisteContaCorrente(Id))
            {
                _notificador.Adicionar("Não existe essa Conta Corrente");
                return null;
            }

            contaCorrente = _contaCorrenteRespository.BuscarContaCorrentePorId(Id);

            contaCorrente.Deposita(Valor);

            _contaCorrenteRespository.AlterarContaCorrente(contaCorrente);

            return contaCorrente;
        }

        public object Sacar(int Id, double Valor)
        {
            ContaCorrente contaCorrente;
            if (!_contaCorrenteRespository.ExisteContaCorrente(Id))
            {
                _notificador.Adicionar("Não existe essa Conta Corrente");
                return null;
            }

            contaCorrente = _contaCorrenteRespository.BuscarContaCorrentePorId(Id);

            if (!contaCorrente.Saca(Valor))
            {
                _notificador.Adicionar("Saldo Insuficente");
                return null;
            }

            _contaCorrenteRespository.AlterarContaCorrente(contaCorrente);

            return contaCorrente;
        }
    }
}
