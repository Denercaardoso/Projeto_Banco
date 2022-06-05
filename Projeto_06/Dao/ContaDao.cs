using System;
using System.Data.SqlClient;

namespace Projeto_06.Dao
{
    class ContaDao
    {
        Conexao conexao = new Conexao();
        SqlCommand sqlCommand = new SqlCommand();
        public int Inserir(Conta conta)
        {
            sqlCommand.CommandText = "INSERT INTO dbo.CONTAS VALUES (@Agencia, @Numero, @Saldo, @Id_Cliente); SELECT SCOPE_IDENTITY();";
            sqlCommand.Parameters.AddWithValue("@Agencia", conta.Agencia);
            sqlCommand.Parameters.AddWithValue("@Numero", conta.NumeroDaConta);
            sqlCommand.Parameters.AddWithValue("@Saldo", conta.Saldo);
            sqlCommand.Parameters.AddWithValue("@ID_Cliente", conta.Cliente.Id);

            try
            {
                sqlCommand.Connection = conexao.Conectar();
                int id = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return id;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
            return 0;
        }

        public void Editar(Conta conta)
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "UPDATE CONTAS SET AGENCIA = @AGENCIA, NUMERO = @NUMERO WHERE ID = @ID; " +
                "UPDATE CLIENTE SET NOME = @NOME, CPF = @CPF, RG = @RG, ENDERECO = @ENDERECO WHERE ID = @ID_CLIENTE;";
            sqlCommand.Parameters.AddWithValue("@ID", conta.Id);
            sqlCommand.Parameters.AddWithValue("@AGENCIA", conta.Agencia);
            sqlCommand.Parameters.AddWithValue("@NUMERO", conta.NumeroDaConta);

            sqlCommand.Parameters.AddWithValue("@ID_CLIENTE", conta.Cliente.Id);
            sqlCommand.Parameters.AddWithValue("@NOME", conta.Cliente.Nome);
            sqlCommand.Parameters.AddWithValue("@CPF", conta.Cliente.CPF);
            sqlCommand.Parameters.AddWithValue("@RG", conta.Cliente.RG);
            sqlCommand.Parameters.AddWithValue("@ENDERECO", conta.Cliente.Endereco);

            try
            {
                sqlCommand.Connection = conexao.Conectar();
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("erro: " + e.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
    }
}
