using Projeto_06.Dao;
using System;
using System.Linq;

namespace Projeto_06.Servicos
{
    class ContaPoupancaService
    {
        ContaDao _contaDao = new();

        ContaPoupancaDao contaPoupancaDao = new();
        public void AdicionarContaPoupanca()
        {
            ContaPoupanca cp = new ContaPoupanca();
            Console.WriteLine("Agência: ");
            cp.Agencia = int.Parse(Console.ReadLine());
            Console.WriteLine("Numero: ");
            cp.NumeroDaConta = int.Parse(Console.ReadLine());
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
            cp.Cliente = cliente;

            ClienteDao clienteDao = new ClienteDao();
            cliente.Id = clienteDao.Inserir(cliente);

            cp.Cliente = cliente;

            ContaDao contaDao = new ContaDao();
            cp.Id = contaDao.Inserir(cp);

            ContaPoupancaDao contaPoupancaDao = new();
            contaPoupancaDao.Inserir(cp);

            Console.WriteLine("Saldo: ");
            cp.Deposita(new Random().NextDouble() * 1000000);

        }
        public void MostrarContaPoupanca()
        {
            Console.WriteLine("-----CONTAS POUPANÇAS-----");
            ContaPoupancaDao contaPoupancaDao = new();
            var listarCP = contaPoupancaDao.listarCP();

            foreach (var conta in listarCP)
            {
                Console.WriteLine("Agencia: " + conta.Agencia);
                Console.WriteLine("Numero: " + conta.NumeroDaConta);
                Console.WriteLine("Correntista: " + conta.Cliente.Nome);
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
                Console.WriteLine("5 - Excluir conta");
                Console.WriteLine("6 - Voltar");
                string escolha = Console.ReadLine();
                switch (escolha)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Adicionar conta");
                        AdicionarContaPoupanca();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Editar conta");
                        EditarConta();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Listar todas as contas");
                        MostrarContaPoupanca();
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
                        ExcluirConta();
                        break;
                    case "6":
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
        public void EditarConta()
        {
            Console.WriteLine("-----EDITAR CONTA CORRENTE-----");
            Console.WriteLine("");
            Console.Write("Informe o Numero da conta que deseja editar: ");
            int numeroConta = int.Parse(Console.ReadLine());

            var listaDeContas = contaPoupancaDao.listarCP();
            ContaPoupanca cp = listaDeContas.FirstOrDefault(a => a.NumeroDaConta == numeroConta);

            if (cp != null)
            {
                Console.Write("Digite o numero da agência: ");
                cp.Agencia = int.Parse(Console.ReadLine());
                Console.Write("Digite o nome do correntista: ");
                cp.Cliente.Nome = Console.ReadLine();
                Console.Write("Digite o Cpf do correntista: ");
                cp.Cliente.CPF = Console.ReadLine();
                Console.Write("Digite o RG do correntista: ");
                cp.Cliente.RG = Console.ReadLine();
                Console.Write("Digite o Endereço do correntista: ");
                cp.Cliente.Endereco = Console.ReadLine();

                _contaDao.Editar(cp);

            }
        }

        public void ExcluirConta()
        {
            var contasPoupancas = contaPoupancaDao.listarCP();
            Console.WriteLine("-----EXCLUIR CONTA CORRENTE-----");
            Console.WriteLine("");
            Console.Write("Informe o Numero da conta que deseja excluir: ");
            int numeroConta = int.Parse(Console.ReadLine());


            ContaPoupanca cp = contasPoupancas.FirstOrDefault(a => a.NumeroDaConta == numeroConta);

            if (cp != null)
            {
                var result = contaPoupancaDao.Excluir(cp.Id);
                if (result)
                    Console.WriteLine("Conta apagada com sucesso");
                else
                    Console.WriteLine("Não foi possivel apagar");
                Console.ReadLine();
            }
        }

        public void ConsultaConta()
        {
            Console.WriteLine("Digite a Conta que deseja consultar: ");
            int valor = int.Parse(Console.ReadLine());

            var ListaDeContas = contaPoupancaDao.listarCP();
            var conta = ListaDeContas.FirstOrDefault(conta => conta.NumeroDaConta == valor);
            if (conta == null)
            {
                Console.WriteLine("A conta desejada não existe");
                ConsultaConta();
            }

            Console.WriteLine("--------DADOS--------");
            Console.WriteLine("Correntista: " + conta.Cliente);
            Console.WriteLine("Agencia: " + conta.Agencia);
            Console.WriteLine("Numero da conta: " + conta.NumeroDaConta);
            Console.WriteLine("-----------------------------");

            EscolhaFuncionalidades(conta);
        }
        public void EscolhaFuncionalidades(ContaPoupanca conta)
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
