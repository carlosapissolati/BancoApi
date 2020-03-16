using BancoApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Interfaces
{
    public interface IContaService
    {
        public bool CriarConta(object conta);

        public object Sacar(int Id, double Valor);

        public object Depositar(int Id, double Valor);
    }
}
