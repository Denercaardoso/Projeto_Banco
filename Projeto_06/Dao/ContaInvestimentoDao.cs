using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto_06.Dao
{
    public class ContaInvestimentoDao
    {
        Conexao conexao = new Conexao();
        SqlCommand sqlCommand = new SqlCommand();
        public void Inserir(ContaInvestimento contaInvestimento)
        {
            sqlCommand.CommandText = "INSERT INTO dbo.CONTAINVESTIMENTO VALUES (@ID_Contas);";
            sqlCommand.Parameters.AddWithValue("@ID_Contas", contaInvestimento.Id);

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

        public List<ContaInvestimento> listarCI()
        {
            List<ContaInvestimento> listaContaInvestimentos = new List<ContaInvestimento>();
            //LISTAR INFORMAÇÕES DO BANCO DE DADOS.
            sqlCommand.CommandText = "SELECT * from CONTAINVESTIMENTO " +
                "inner join CONTAS on CONTAS.ID = CONTAINVESTIMENTO.ID_Contas " +
                "inner join CLIENTE on CLIENTE.ID = CONTAS.ID_Cliente";
            try
            {
                sqlCommand.Connection = conexao.Conectar();
                sqlCommand.ExecuteNonQuery();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    ContaInvestimento contaInvestimento = new();
                    contaInvestimento.Id = reader.GetInt32(2);
                    contaInvestimento.Agencia = reader.GetInt32(3);
                    contaInvestimento.NumeroDaConta = reader.GetInt32(4);
                    contaInvestimento.SetSaldoDb(Convert.ToDouble(reader.GetDecimal(5)));

                    Cliente cliente = new();
                    cliente.Id = reader.GetInt32(7);
                    cliente.Nome = reader.GetString(8);
                    cliente.CPF = reader.GetString(9);
                    cliente.RG = reader.GetString(10);
                    cliente.Endereco = reader.GetString(11);
                    contaInvestimento.Cliente = cliente;

                    listaContaInvestimentos.Add(contaInvestimento);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
            return listaContaInvestimentos;
        }
        public bool Excluir(int id)
        {
            sqlCommand.CommandText = "DELETE FROM CONTAINVESTIMENTO WHERE ID_Contas = @ID_Conta; " +
                "DELETE FROM CONTAS WHERE ID =  @ID";
            sqlCommand.Parameters.AddWithValue("@ID_Conta", id);
            sqlCommand.Parameters.AddWithValue("@ID", id);

            try
            {
                sqlCommand.Connection = conexao.Conectar();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return false;
            }
            finally
            {
                conexao.Desconectar();
            }
        }

    }
}
