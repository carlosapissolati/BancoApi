using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Entities
{
    public class ContaPoupanca : Conta
    {
        public override bool Saca(double saque)
        {
            if (this.Saldo >= (saque + 0.10))
            {
                this.Saldo -= (saque + 0.10);
                return true;
            }
            else
                return false;
        }

        public override void Deposita(double valor)
        {
            base.Saldo += valor;
        }
    }
}
