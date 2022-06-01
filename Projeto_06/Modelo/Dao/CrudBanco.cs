using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_06.Modelo.Dao
{
    internal class CrudBanco 
    {
        Conexao conexao = new Conexao();

        SqlCommand sqlCommand = new SqlCommand();

        public void InserirCliente(Cliente cliente)
        {
            sqlCommand.CommandText = "INSERT INTO CLIENTE (Nome, CPF, RG , Endereco) VALUES (@Nome, @CPF, @RG, @Endereco); ";
            sqlCommand.Parameters.AddWithValue("@Nome", cliente.Nome);
            sqlCommand.Parameters.AddWithValue("@CPF", cliente.CPF);
            sqlCommand.Parameters.AddWithValue("@RG", cliente.RG);
            sqlCommand.Parameters.AddWithValue("@Endereco", cliente.Endereco);
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

        public void EditarCliente(Cliente cliente)
        {
            sqlCommand.CommandText = "UPDATE CLIENTE SET Nome = @Nome, RG = @RG, Endereco = @Endereco WHERE CPF = @CPF;";
            sqlCommand.Parameters.AddWithValue("@CPF", cliente.CPF);
            sqlCommand.Parameters.AddWithValue("@Nome", cliente.Nome);
            sqlCommand.Parameters.AddWithValue("@RG", cliente.RG);
            sqlCommand.Parameters.AddWithValue("@Endereco", cliente.Endereco);
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
        public void ExcluirCliente(Cliente cliente)
        {
            sqlCommand.CommandText = "DELETE FROM CLIENTE WHERE CPF = @CPF";
            sqlCommand.Parameters.AddWithValue("@CPF", cliente.CPF);
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

        public List<Cliente> listarTodosClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            Cliente clientes = null; 
            sqlCommand.CommandText = "SELECT * FROM CLIENTE";
            try
            {
                sqlCommand.Connection = conexao.Conectar();
                sqlCommand.ExecuteNonQuery();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    clientes = new Cliente(); 
                    clientes.Nome = reader.GetString(1);
                    clientes.CPF = reader.GetString(2);
                    clientes.RG = reader.GetString(3);
                    clientes.Endereco = reader.GetString(4);
                    listaClientes.Add(clientes);
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
            List<Cliente> listaClientes = new List<Cliente>();
            Cliente clientes = null;
            sqlCommand.CommandText = "SELECT * FROM CLIENTE WHERE CPF = @CPF;";
            sqlCommand.Parameters.AddWithValue("@CPF", CPF);
            try
            {
                sqlCommand.Connection = conexao.Conectar();
                sqlCommand.ExecuteNonQuery();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    clientes = new Cliente();
                    clientes.Nome = reader.GetString(1);
                    clientes.CPF = reader.GetString(2);
                    clientes.RG = reader.GetString(3);
                    clientes.Endereco = reader.GetString(4);
                    listaClientes.Add(clientes);
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
    }
}
