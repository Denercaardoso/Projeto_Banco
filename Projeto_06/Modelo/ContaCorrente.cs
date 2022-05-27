using System;
using System.Collections.Generic;

namespace Projeto_06
{
    public class ContaCorrente : Conta
    {
        private static List<ContaCorrente> contasCorrentes;

        public ContaCorrente()
        {
            if (contasCorrentes == null)
            {
                contasCorrentes = new List<ContaCorrente>();
            }
        }

        public override void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public override bool Saca(double valor)
        {
            if (this.Saldo >= valor)
            {
                this.Saldo -= valor;
                return true;
            }
            else
                return false;

        }

        public override void QuantidadeContaAtual()
        {
            throw new NotImplementedException();
        }
        public double CalculaTributo()
        {
            //Falta implementar lógica
            return 0;
        }

    }
}
