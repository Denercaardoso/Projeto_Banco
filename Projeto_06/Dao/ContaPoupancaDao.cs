using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto_06.Dao
{
    class ContaPoupancaDao
    {
        Conexao conexao = new Conexao();
        SqlCommand sqlCommand = new SqlCommand();
        public void Inserir(ContaPoupanca contaPoupanca)
        {
            sqlCommand.CommandText = "INSERT INTO dbo.CONTAPOUPANCA VALUES (@ID_Contas);";
            sqlCommand.Parameters.AddWithValue("@ID_Contas", contaPoupanca.Id);

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

        public List<ContaPoupanca> listarCP()
        {
            List<ContaPoupanca> listaContaPoupancas = new List<ContaPoupanca>();
            //LISTAR INFORMAÇÕES DO BANCO DE DADOS.
            sqlCommand.CommandText = "SELECT * from CONTAPOUPANCA " +
                "inner join CONTAS on CONTAS.ID = CONTAPOUPANCA.ID_Contas " +
                "inner join CLIENTE on CLIENTE.ID = CONTAS.ID_Cliente";
            try
            {
                sqlCommand.Connection = conexao.Conectar();
                sqlCommand.ExecuteNonQuery();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    ContaPoupanca contaPoupanca = new();
                    contaPoupanca.Id = reader.GetInt32(2);
                    contaPoupanca.Agencia = reader.GetInt32(3);
                    contaPoupanca.NumeroDaConta = reader.GetInt32(4);
                    contaPoupanca.SetSaldoDb(Convert.ToDouble(reader.GetDecimal(5)));

                    Cliente cliente = new();
                    cliente.Id = reader.GetInt32(7);
                    cliente.Nome = reader.GetString(8);
                    cliente.CPF = reader.GetString(9);
                    cliente.RG = reader.GetString(10);
                    cliente.Endereco = reader.GetString(11);
                    contaPoupanca.Cliente = cliente;

                    listaContaPoupancas.Add(contaPoupanca);
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
            return listaContaPoupancas;
        }
        public bool Excluir(int id)
        {
            sqlCommand.CommandText = "DELETE FROM CONTAPOUPANCA WHERE ID_Contas = @ID_Conta; " +
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
