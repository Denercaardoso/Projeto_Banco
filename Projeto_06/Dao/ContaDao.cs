using System;
using System.Data.SqlClient;

namespace Projeto_06.Dao
{
    class ContaDao
    {
        Conexao conexao = new Conexao();
        SqlCommand sqlCommand = new SqlCommand();
        public void Inserir(Conta conta)
        {
            sqlCommand.CommandText = "INSERT INTO dbo.CONTAS VALUES (@Agencia, @Numero, @Saldo, @Id_Cliente);";
            sqlCommand.Parameters.AddWithValue("@Agencia", conta.Agencia);
            sqlCommand.Parameters.AddWithValue("@Numero", conta.NumeroDaConta);
            sqlCommand.Parameters.AddWithValue("@Saldo", conta.Saldo);
            sqlCommand.Parameters.AddWithValue("@ID_Cliente", conta.Correntista.Id);

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
