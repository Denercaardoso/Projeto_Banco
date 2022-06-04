using System;
using System.Data.SqlClient;

namespace Projeto_06.Dao
{
    class ClienteDao
    {
        Conexao conexao = new Conexao();
        SqlCommand sqlCommand = new SqlCommand();
        public int Inserir(Cliente cliente)
        {
            sqlCommand.CommandText = "INSERT INTO dbo.CLIENTE VALUES (@Nome, @CPF, @RG, @Endereco); SELECT SCOPE_IDENTITY();";
            sqlCommand.Parameters.AddWithValue("@Nome", cliente.Nome);
            sqlCommand.Parameters.AddWithValue("@CPF", cliente.CPF);
            sqlCommand.Parameters.AddWithValue("@RG", cliente.RG);
            sqlCommand.Parameters.AddWithValue("@Endereco", cliente.Endereco);

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
    }
}
