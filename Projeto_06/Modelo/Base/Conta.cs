namespace Projeto_06
{
    public abstract class Conta
    {
        public int Agencia { get; set; }
        public int NumeroDaConta { get; set; }
        public Cliente Correntista { get; set; }
        public double Saldo { get; protected set; }
        public int QuantidadeContas { get; set; }

        public abstract bool Saca(double valor);
        public abstract void Deposita(double valor);
        public abstract void QuantidadeContaAtual();

    }
}
