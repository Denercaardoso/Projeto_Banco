using System;
using System.Collections.Generic;
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
            sqlCommand.Parameters.AddWithValue("@ID_Contas", contaCorrente.Id);

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

        public List<ContaCorrente> listarCC()
        {
            List<ContaCorrente> listaContaCorrentes = new List<ContaCorrente>();
            //LISTAR INFORMAÇÕES DO BANCO DE DADOS.
            sqlCommand.CommandText = "SELECT * from CONTACORRENTE " +
                "inner join CONTAS on CONTAS.ID = CONTACORRENTE.ID_Contas " +
                "inner join CLIENTE on CLIENTE.ID = CONTAS.ID_Cliente";
            try
            {
                sqlCommand.Connection = conexao.Conectar();
                sqlCommand.ExecuteNonQuery();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    ContaCorrente contaCorrente = new();
                    contaCorrente.Id = reader.GetInt32(2);
                    contaCorrente.Agencia = reader.GetInt32(3);
                    contaCorrente.NumeroDaConta = reader.GetInt32(4);
                    contaCorrente.SetSaldoDb(Convert.ToDouble(reader.GetDecimal(5)));

                    Cliente cliente = new();
                    cliente.Id = reader.GetInt32(7);
                    cliente.Nome = reader.GetString(8);
                    cliente.CPF = reader.GetString(9);
                    cliente.RG = reader.GetString(10);
                    cliente.Endereco = reader.GetString(11);
                    contaCorrente.Cliente = cliente;

                    listaContaCorrentes.Add(contaCorrente);
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
            return listaContaCorrentes;
        }
    }
}
