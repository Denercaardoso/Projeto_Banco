using System;
using System.Collections.Generic;

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
                Console.WriteLine("5 - Sair");
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
    }
}
