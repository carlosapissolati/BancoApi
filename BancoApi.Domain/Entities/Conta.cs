using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Entities
{
    public abstract class Conta
    {
        public int Numero { get; set; }
        public double Saldo { get; protected set; }
        public Cliente Titular { get; set; }
        public abstract bool Saca(double saque);
        public abstract void Deposita(double valor);

        public bool Transfere(double valor, Conta contaDestino)
        {
            if (this.Saca(valor))
            {
                contaDestino.Deposita(valor);
                return true;
            }
            else
                return false;
        }
    }
}
