using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_06.Modelo.Dao
{
    public class CrudConta : ICrudBanco<ContaCorrente>
    {
        Conexao conexao = new Conexao();

        SqlCommand sqlCommand = new SqlCommand();

        public CrudConta()
        {
           
        }
        public void CreateContaCorrente(ContaCorrente contaCorrente)
        {
            sqlCommand.CommandText = "INSERT INTO CONTAS (Agencia, Numero, Saldo) VALUES (@Agencia, @Numero, @Saldo); ";
            sqlCommand.Parameters.AddWithValue("@Agencia", contaCorrente.Agencia);
            sqlCommand.Parameters.AddWithValue("@Numero", contaCorrente.NumeroDaConta);
            sqlCommand.Parameters.AddWithValue("@Saldo", contaCorrente.Saldo);
            try
            {
                 sqlCommand.Connection = conexao.Conectar();
                 var rowNumber =  sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void Editar(ContaCorrente cliente)
        {
            throw new NotImplementedException();
        }

        public void Excluir(ContaCorrente cliente)
        {
            throw new NotImplementedException();
        }

        public void Inserir(ContaCorrente cliente)
        {
            throw new NotImplementedException();
        }

        public ContaCorrente listarByCpf(string CPF)
        {
            throw new NotImplementedException();
        }

        public List<ContaCorrente> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public void transferirIdContaCorrente(ContaCorrente contaCorrente)
        {

            sqlCommand.CommandText = "INSERT INTO CONTACORRENTE SELECT ID FROM CONTAS;";
            try
            {
                sqlCommand.Connection = conexao.Conectar();
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
    }
}
