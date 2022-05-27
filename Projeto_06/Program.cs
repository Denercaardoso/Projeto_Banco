using Projeto_06.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_06
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menuPrincipal = true;
            ContaCorrenteService contaCorrenteService = new ContaCorrenteService();
            ContaPoupancaService contaPoupancaService = new ContaPoupancaService();
            ContaInvestimentoService contaInvestimentoService = new ContaInvestimentoService();

            MenuPrincipal();

            void MenuPrincipal()
            {
                while (menuPrincipal)
                {
                    Console.Clear();
                    Console.WriteLine("MENU PRINCIPAL");
                    Console.WriteLine("Informe a opção desejada:");
                    Console.WriteLine("1 - Dados das Contas");
                    Console.WriteLine("2 - Dados dos Clientes");
                    Console.WriteLine("3 - Total de dinheiro em caixa");
                    Console.WriteLine("4 - Total de tributos");
                    Console.WriteLine("5 - Relatórios");
                    Console.WriteLine("6 - Sair");
                    string escolha = Console.ReadLine();
                    switch (escolha)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Dados das Contas");
                            Console.WriteLine("Informe o tipo de conta:");
                            Console.WriteLine("1 - Conta Corrente");
                            Console.WriteLine("2 - Conta Poupança");
                            Console.WriteLine("3 - Conta Investimento");
                            string escolha2 = Console.ReadLine();
                            switch (escolha2)
                            {
                                case "1":
                                    contaCorrenteService.MenuConta();
                                    break;
                                case "2":
                                    contaPoupancaService.MenuConta();
                                    break;
                                case "3":
                                    contaInvestimentoService.MenuConta();
                                    break;
                                default:
                                    Console.WriteLine("Opção Invalida!");
                                    Console.ReadLine();
                                    break;
                            }
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("Dados dos Clientes");
                            break;
                        case "3":
                            SaldoEmCaixa();
                            break;
                        case "4":
                            Console.WriteLine("Total de tributos");
                            break;
                        case "5":
                            Console.WriteLine("Relatórios");
                            Relatorios();
                            break;
                        case "6":
                            Console.WriteLine("Sessão Encerrada");
                            menuPrincipal = false;
                            break;
                        default:
                            Console.WriteLine("Opção Invalida!");
                            break;
                    }
                }
            }


            void Relatorios()
            {
                bool Relatorio = true;

                while (Relatorio)
                {
                    Console.Clear();
                    Console.WriteLine("RELATÓRIO");
                    Console.WriteLine("Informe a opção desejada:");
                    Console.WriteLine("1 - Grandes contas - Saldo maior que R$ 500.000");
                    Console.WriteLine("2 - Correntista");
                    Console.WriteLine("3 - Listar todas as contas");
                    Console.WriteLine("4 - Consultar conta");
                    Console.WriteLine("5 - Excluir conta");
                    Console.WriteLine("6 - Sair");

                    string escolha = Console.ReadLine();
                    switch (escolha)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Grandes contas - Saldo maior que R$ 500.000");
                            MostraContasAcima500k();
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("Correntista");
                            Correntistas();
                            break;
                        case "3":
                            Console.Clear();
                            Console.WriteLine("Listar todas as contas");
                            ListarTodasContas();
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine("Consultar conta");
                            break;
                        case "5":
                            Console.Clear();
                            Console.WriteLine("Excluir conta");
                            break;
                        case "6":
                            Console.Clear();
                            Console.WriteLine("Voltando ao Menu Principal");
                            Console.ReadLine();
                            Console.Clear();
                            Relatorio = false;
                            break;
                        default:
                            Console.WriteLine("Opção Invalida!");
                            break;
                    }
                }
            }
            void SaldoEmCaixa()
            {
                var contas = pegaTodasContas();
                //.Sum: Realizar soma de todos os saldos das contas.
                var saldoEmCaixa = contas.Sum(conta => conta.Saldo);

                Console.WriteLine("Saldo em Caixa: R$ " + saldoEmCaixa.ToString("F2"));
                Console.ReadLine();
                MenuPrincipal();

            }

            void Correntistas()
            {
                var contas = pegaTodasContas();
                //Listar correntista em primeiro lugar
                var contasAcima500kOrdenado = contas.OrderBy(item => item.Correntista)
                //Thenby em caso de correntista igual, pega pelo maior saldo.
                    .ThenByDescending(item => item.Saldo);

                foreach (var conta in contasAcima500kOrdenado)
                {
                    Console.WriteLine("Agencia: " + conta.Agencia);
                    Console.WriteLine("Numero: " + conta.NumeroDaConta);
                    Console.WriteLine("Correntista: " + conta.Correntista);
                    Console.WriteLine("Saldo: R$" + conta.Saldo);
                    Console.WriteLine("----------------");

                }
                Console.ReadLine();
                Console.Clear();
                MenuPrincipal();

            }


            void ListarTodasContas()
            {
                var contas = pegaTodasContas();
                foreach (var conta in contas)
                {
                    Console.WriteLine("Agencia: " + conta.Agencia);
                    Console.WriteLine("Numero: " + conta.NumeroDaConta);
                    Console.WriteLine("Correntista: " + conta.Correntista);
                    Console.WriteLine("Saldo: R$" + conta.Saldo);
                    Console.WriteLine("----------------");

                }
                Console.ReadLine();
                Console.Clear();
                MenuPrincipal();
            }

            void MostraContasAcima500k()
            {
                var contas = pegaTodasContas();
                //Filrado acima de 500000
                contas = contas.Where(item => item.Saldo >= 500000).ToList();

                var contasAcima500kOrdenado = contas.OrderByDescending(item => item.Saldo);

                foreach (var conta in contasAcima500kOrdenado)
                {
                    Console.WriteLine("Agencia: " + conta.Agencia);
                    Console.WriteLine("Numero: " + conta.NumeroDaConta);
                    Console.WriteLine("Correntista: " + conta.Correntista);
                    Console.WriteLine("Saldo: " + conta.Saldo);
                    Console.WriteLine("----------------");

                }
                Console.ReadLine();
                Console.Clear();
                MenuPrincipal();
            }

            List<Conta> pegaTodasContas()
            {
                List<Conta> contas = new();
                //.Where = Filtrar itens da lista == ToList: Transformar em lista.
                var contaCorrentes = ContaCorrenteService.ContasCorrentes;
                var contasPoupancas = ContaPoupancaService.ContasPoupancas;
                var contasInvestimentos = ContaInvestimentoService.ContasInvestimentos;

                //.AddRange: Adicionar listas. 
                contas.AddRange(contaCorrentes);
                contas.AddRange(contasPoupancas);
                contas.AddRange(contasInvestimentos);
                return contas;
            }
        }
    }
}
