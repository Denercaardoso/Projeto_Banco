using System;
using System.Data.SqlClient;

namespace Projeto_06.Dao
{
    class ContaCorrenteDao
    {
        Conexao conexao = new Conexao();
        SqlCommand sqlCommand = new SqlCommand();
        public void Inserir(ContaCorrente contaCorrente)
        {
            sqlCommand.CommandText = "INSERT INTO dbo.CONTACORRENTE VALUES (@ID_Contas);";
            sqlCommand.Parameters.AddWithValue("@ID_Contas", contaCorrente.Correntista.Id);

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
