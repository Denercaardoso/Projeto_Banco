using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto_06.Dao
{
    class ClienteDao
    {
        Conexao conexao = new Conexao();
        SqlCommand sqlCommand = null;
        public int Inserir(Cliente cliente)
        {
            sqlCommand = new SqlCommand();
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

        public List<Cliente> listarCliente()
        {
            sqlCommand = new SqlCommand();
            List<Cliente> listaClientes = new List<Cliente>();
            //LISTAR INFORMAÇÕES DO BANCO DE DADOS.
            sqlCommand.CommandText = "SELECT * from CLIENTE; ";
            try
            {
                sqlCommand.Connection = conexao.Conectar();
                sqlCommand.ExecuteNonQuery();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cliente = new();
                    cliente.Id = reader.GetInt32(0);
                    cliente.Nome = reader.GetString(1);
                    cliente.CPF = reader.GetString(2);
                    cliente.RG = reader.GetString(3);
                    cliente.Endereco = reader.GetString(4);

                    listaClientes.Add(cliente);
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
            return listaClientes;
        }

        public List<Cliente> listarClientesPorCpf(string CPF)
        {
            sqlCommand = new SqlCommand();
            List<Cliente> listaClientes = new List<Cliente>();
            sqlCommand.CommandText = "SELECT * FROM CLIENTE WHERE CPF = @CPF;";
            sqlCommand.Parameters.AddWithValue("@CPF", CPF);
            try
            {
                sqlCommand.Connection = conexao.Conectar();
                sqlCommand.ExecuteNonQuery();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = reader.GetInt32(0);
                    cliente.Nome = reader.GetString(1);
                    cliente.CPF = reader.GetString(2);
                    cliente.RG = reader.GetString(3);
                    cliente.Endereco = reader.GetString(4);
                    listaClientes.Add(cliente);
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
            return listaClientes;
        }
        public bool Excluir(Cliente cliente)
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "DELETE FROM CLIENTE WHERE CPF = @CPF";
            sqlCommand.Parameters.AddWithValue("@CPF", cliente.CPF);
            try
            {
                sqlCommand.Connection = conexao.Conectar();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public void Editar(Cliente cliente)
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = $"UPDATE CLIENTE SET Nome = '{cliente.Nome}', RG = {cliente.RG}, Endereco = '{cliente.Endereco}' WHERE CPF = '{cliente.CPF}';";

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
