using BancoApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Repository
{
    public interface IContaCorrenteRepository
    {
        public bool ExisteContaCorrente(int id);
        public ContaCorrente BuscarContaCorrentePorId(int id);
        public void CriarContaCorrente(ContaCorrente contaCorrente);
        public void AlterarContaCorrente(ContaCorrente contaCorrente);

    }
}
