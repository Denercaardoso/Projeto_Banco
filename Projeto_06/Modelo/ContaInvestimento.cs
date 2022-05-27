using System;

namespace Projeto_06
{
    public class ContaInvestimento : Conta, ITributo
    {
        public double CalculaTributo()
        {
            throw new NotImplementedException();
        }

        public override void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public override void QuantidadeContaAtual()
        {
            throw new NotImplementedException();
        }

        public override bool Saca(double valor)
        {
            if (this.Saldo >= valor)
            {
                this.Saldo -= valor;
                return true;
            }
            else return false;
        }
    }
}
