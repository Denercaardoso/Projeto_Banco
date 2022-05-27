using System;
using System.Collections.Generic;

namespace Projeto_06.Servicos
{
    class ContaPoupancaService
    {
        public static List<ContaPoupanca> ContasPoupancas { get; set; }
        public ContaPoupancaService()
        {
            if (ContasPoupancas == null)
            {
                ContasPoupancas = new List<ContaPoupanca>();
            }
        }
        public void AdicionarContaPoupanca(List<ContaPoupanca> contasPoupancas)
        {
            ContaPoupanca cp = new ContaPoupanca();
            Console.WriteLine("Agência: ");
            cp.Agencia = int.Parse(Console.ReadLine());
            Console.WriteLine("Numero: ");
            cp.NumeroDaConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Correntista: ");
            cp.Correntista = Console.ReadLine();
            Console.WriteLine("Saldo: ");
            cp.Deposita(new Random().NextDouble() * 1000000);
            contasPoupancas.Add(cp);
        }
        public void MostrarContaPoupanca(List<ContaPoupanca> contasPoupancas)
        {
            Console.WriteLine("-----CONTAS POUPANÇAS-----");
            foreach (var conta in contasPoupancas)
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
            bool MenuContaPoupanca = true;

            while (MenuContaPoupanca)
            {
                Console.Clear();
                Console.WriteLine("MENU CONTA POUPANÇA");
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
                        AdicionarContaPoupanca(ContasPoupancas);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Editar conta");
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Listar todas as contas");
                        MostrarContaPoupanca(ContasPoupancas);
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
                        MenuContaPoupanca = false;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida!");
                        break;
                }
            }
        }

    }
}
