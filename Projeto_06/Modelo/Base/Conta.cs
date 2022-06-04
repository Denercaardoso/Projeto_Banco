namespace Projeto_06
{
    public abstract class Conta
    {
        public int Id { get; set; }
        public int Agencia { get; set; }
        public int NumeroDaConta { get; set; }
        public Cliente Cliente { get; set; }
        public double Saldo { get; protected set; }
        public int QuantidadeContas { get; set; }

        public void SetSaldoDb(double saldo)
        {
            Saldo = saldo;
        }

        public abstract bool Saca(double valor);
        public abstract void Deposita(double valor);
        public abstract void QuantidadeContaAtual();

    }
}
