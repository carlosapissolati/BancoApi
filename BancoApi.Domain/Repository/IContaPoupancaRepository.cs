using BancoApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Repository
{
    public interface IContaPoupancaRepository
    {
        public bool ExisteConta(int id);
        public ContaPoupanca BuscarContaPorId(int id);
        public void CriarConta(ContaPoupanca contaPoupanca);
        public void AlterarConta(ContaPoupanca contaPoupanca);
    }
}
