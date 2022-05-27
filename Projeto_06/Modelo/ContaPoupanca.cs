using System;

namespace Projeto_06
{
    public class ContaPoupanca : Conta
    {
        public override void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public override bool Saca(double valor)
        {
            if (valor > this.Saldo)
                return false;

            this.Saldo -= valor;
            return true;
        }

        public override void QuantidadeContaAtual()
        {
            throw new NotImplementedException();
        }

        public void CalculaRendimento()
        {

        }

    }
}
