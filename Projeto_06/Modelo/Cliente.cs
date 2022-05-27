using System;

namespace Projeto_06
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Endereco { get; set; }

        //List<Cliente> clientes = new List<Cliente>();
        public void MenuCliente()
        {
            bool menuCliente = true;

            while (menuCliente)
            {
                Console.WriteLine("MENU CLIENTE");
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1 - Adicionar cliente");
                Console.WriteLine("2 - Editar cliente");
                Console.WriteLine("3 - Listar todos os clientes");
                Console.WriteLine("4 - Excluir cliente");
                Console.WriteLine("5 - Sair");
                int escolha = int.Parse(Console.ReadLine());
                switch (escolha)
                {
                    case 1:
                        Console.WriteLine("1 - Adicionar cliente");
                        break;
                    case 2:
                        Console.WriteLine("2 - Editar cliente");
                        break;
                    case 3:
                        Console.WriteLine("3 - Listar todos os clientes");
                        break;
                    case 4:
                        Console.WriteLine("4 - Excluir cliente");
                        break;
                    case 5:
                        Console.WriteLine("Sessão Encerrada");
                        Console.ReadLine();
                        Console.Clear();
                        menuCliente = false;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida!");
                        break;
                }
            }
        }
    }
}
