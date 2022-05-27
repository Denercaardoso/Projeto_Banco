using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_06.Servicos
{
    public class ContaCorrenteService
    {
        public static List<ContaCorrente> ContasCorrentes { get; set; }

        public ContaCorrenteService()
        {
            if (ContasCorrentes == null)
            {
                ContasCorrentes = new List<ContaCorrente>();
            }
        }

        public void AdicionarContaCorrente(List<ContaCorrente> contasCorrentes)
        {
            ContaCorrente cc = new ContaCorrente();
            Console.WriteLine("Agência: ");
            cc.Agencia = int.Parse(Console.ReadLine());
            Console.WriteLine("Numero: ");
            cc.NumeroDaConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Correntista: ");

            Cliente cliente = new Cliente();
            Console.Write("Nome: ");
            cliente.Nome = Console.ReadLine();
            Console.Write("CPF: ");
            cliente.CPF = Console.ReadLine();
            Console.Write("RG: ");
            cliente.RG = Console.ReadLine();
            Console.Write("Endereco: ");
            cliente.Endereco = Console.ReadLine();
            cc.Correntista = cliente;

            Console.WriteLine("Saldo: ");
            //Gerar um saldo aleatorio.
            cc.Deposita(new Random().NextDouble() * 1000000);
            contasCorrentes.Add(cc);
        }

        public void MostrarContaCorrente(List<ContaCorrente> contasCorrentes)
        {
            Console.WriteLine("-----CONTAS CORRENTES-----");
            //Foi modificado com static e criado o contrutor get
            foreach (var conta in ContaCorrenteService.ContasCorrentes)
            {
                Console.WriteLine("Agencia: " + conta.Agencia);
                Console.WriteLine("Numero: " + conta.NumeroDaConta);
                Console.WriteLine("Correntista: " + conta.Correntista.Nome);
                Console.WriteLine("Saldo: " + conta.Saldo);
                Console.WriteLine("----------------");
            }
        }

        public void MenuConta()
        {
            bool MenuContaCorrente = true;

            while (MenuContaCorrente)
            {
                Console.Clear();
                Console.WriteLine("MENU CONTA CORRENTE");
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1 - Adicionar conta");
                Console.WriteLine("2 - Editar conta");
                Console.WriteLine("3 - Listar todas as contas");
                Console.WriteLine("4 - Consultar conta");
                Console.WriteLine("5 - Excluir conta");
                Console.WriteLine("6 - Voltar");
                string escolha = Console.ReadLine();
                switch (escolha)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Adicionar conta");
                        AdicionarContaCorrente(ContasCorrentes);
                        break;
                    case "2":
                        Console.WriteLine("Editar conta");
                        EditarConta(ContasCorrentes);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Listar todas as contas");
                        MostrarContaCorrente(ContasCorrentes);
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Consultar conta");
                        ConsultaConta();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Excluir conta");
                        ExcluirConta(ContasCorrentes);
                        break;
                    case "6":
                        Console.WriteLine("Voltando ao Menu Principal");
                        Console.ReadLine();
                        Console.Clear();
                        MenuContaCorrente = false;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida!");
                        break;
                }
            }
        }
        public void EditarConta(List<ContaCorrente> ContasCorrentes)
        {
            Console.WriteLine("-----EDITAR CONTA CORRENTE-----");
            Console.WriteLine("");
            Console.Write("Informe o Numero da conta que deseja editar: ");
            int numeroConta = int.Parse(Console.ReadLine());


            ContaCorrente cc = ContasCorrentes.FirstOrDefault(a => a.NumeroDaConta == numeroConta);

            if (cc != null)
            {
                Console.Write("Digite o numero da agência: ");
                cc.Agencia = int.Parse(Console.ReadLine());
                Console.Write("Digite o nome do correntista: ");
                cc.Correntista.Nome = Console.ReadLine();
                Console.Write("Digite o Cpf do correntista: ");
                cc.Correntista.CPF = Console.ReadLine();
                Console.Write("Digite o RG do correntista: ");
                cc.Correntista.RG = Console.ReadLine();
                Console.Write("Digite o Endereço do correntista: ");
                cc.Correntista.Endereco = Console.ReadLine(); 

            }
        }
        public void ExcluirConta(List<ContaCorrente> ContasCorrentes)
        {
            Console.WriteLine("-----EXCLUIR CONTA CORRENTE-----");
            Console.WriteLine("");
            Console.Write("Informe o Numero da conta que deseja excluir: ");
            int numeroConta = int.Parse(Console.ReadLine());

            ContaCorrente cc = ContasCorrentes.FirstOrDefault(a => a.NumeroDaConta == numeroConta);

            if (cc != null)
            {
                ContasCorrentes.Remove(cc);
            }
        }

        public void ConsultaConta()
        {
            Console.WriteLine("Digite a Conta que deseja consultar: ");
            int valor = int.Parse(Console.ReadLine());

            var conta = ContasCorrentes.FirstOrDefault(conta => conta.NumeroDaConta == valor);
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

        public void EscolhaFuncionalidades(ContaCorrente conta)
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
