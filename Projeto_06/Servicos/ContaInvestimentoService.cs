using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_06.Servicos
{
    class ContaInvestimentoService
    {
        public static List<ContaInvestimento> ContasInvestimentos { get; set; }
        public ContaInvestimentoService()
        {
            if (ContasInvestimentos == null)
            {
                ContasInvestimentos = new List<ContaInvestimento>();
            }
        }

        public void AdicionarContaInvestimento(List<ContaInvestimento> contasInvestimentos)
        {
            ContaInvestimento ci = new ContaInvestimento();
            Console.WriteLine("Agência: ");
            ci.Agencia = int.Parse(Console.ReadLine());
            Console.WriteLine("Numero: ");
            ci.NumeroDaConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Correntista: ");
            ci.Correntista = Console.ReadLine();
            Console.WriteLine("Saldo: ");
            ci.Deposita(new Random().NextDouble() * 1000000);
            contasInvestimentos.Add(ci);
        }

        public void MostrarContaInvestimento(List<ContaInvestimento> contasInvestimentos)
        {
            Console.WriteLine("-----CONTAS INVESTIMENTO-----");
            foreach (var conta in contasInvestimentos)
            {
                Console.WriteLine("Agencia: " + conta.Agencia);
                Console.WriteLine("Numero: " + conta.NumeroDaConta);
                Console.WriteLine("Correntista: " + conta.Correntista);
                Console.WriteLine("Saldo: " + conta.Saldo);
                Console.WriteLine("----------------");
            }
        }

        public void MenuConta()
        {
            bool MenuContaInvestimento = true;

            while (MenuContaInvestimento)
            {
                Console.Clear();
                Console.WriteLine("MENU CONTA INVESTIMENTO");
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1 - Adicionar conta");
                Console.WriteLine("2 - Editar conta");
                Console.WriteLine("3 - Listar todas as contas");
                Console.WriteLine("4 - Consultar conta");
                Console.WriteLine("5 - Voltar");
                string escolha = Console.ReadLine();
                switch (escolha)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Adicionar conta");
                        AdicionarContaInvestimento(ContasInvestimentos);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Editar conta");
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Listar todas as contas");
                        MostrarContaInvestimento(ContasInvestimentos);
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Consultar conta");
                        ConsultaConta();
                        break;
                    case "5":
                        Console.WriteLine("Voltando ao Menu Principal");
                        Console.ReadLine();
                        Console.Clear();
                        MenuContaInvestimento = false;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida!");
                        break;
                }
            }
        }
        public void ConsultaConta()
        {
            Console.WriteLine("Digite a Conta que deseja consultar: ");
            int valor = int.Parse(Console.ReadLine());

            var conta = ContasInvestimentos.FirstOrDefault(conta => conta.NumeroDaConta == valor);
            if (conta == null)
            {
                Console.WriteLine("A conta desejada não existe");
                ConsultaConta();
            }

            Console.WriteLine("--------DADOS--------");
            Console.WriteLine("Correntista: " + conta.Correntista);
            Console.WriteLine("Agencia: " + conta.Agencia);
            Console.WriteLine("Numero da conta: " + conta.NumeroDaConta);
            Console.WriteLine("-----------------------------");

            EscolhaFuncionalidades(conta);
        }
        public void EscolhaFuncionalidades(ContaInvestimento conta)
        {
            Console.WriteLine("Digite a Funcionalidade desejada: ");
            Console.WriteLine("1 - Saque");
            Console.WriteLine("2 - Deposito");
            Console.WriteLine("3 - Consultar Saldo");
            Console.WriteLine("4 - Retornar para o menu");

            int funcionalidadeDesejada = int.Parse(Console.ReadLine());

            if (funcionalidadeDesejada == 1)
            {
                Console.Write("Digite o valor do saque: ");
                double valorASerSacado = double.Parse(Console.ReadLine());
                bool deuCerto = conta.Saca(valorASerSacado);
                if (deuCerto)
                {
                    Console.WriteLine("Operação realizada com sucesso");
                    EscolhaFuncionalidades(conta);
                    return;
                }
                else
                {
                    Console.WriteLine("O valor é superior ao saldo da conta ");
                    EscolhaFuncionalidades(conta);
                    return;
                }
            }
            else if (funcionalidadeDesejada == 2)
            {
                Console.WriteLine("Digite o valor do deposito: ");
                double ValorASerDepositado = double.Parse(Console.ReadLine());
                conta.Deposita(ValorASerDepositado);
                Console.WriteLine("Deposito realizado com sucesso! ");
                EscolhaFuncionalidades(conta);
                return;
            }
            else if (funcionalidadeDesejada == 3)
            {
                Console.WriteLine("Saldo = R$ " + conta.Saldo);
                Console.ReadLine();
                EscolhaFuncionalidades(conta);

            }
            else
                return;
        }
    }
}
