using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Entities
{
    public class ContaCorrente : Conta
    {
        public override bool Saca(double saque)
        {

            if (this.Saldo >= (saque + 0.05))
            {
                this.Saldo -= (saque + 0.05);
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
