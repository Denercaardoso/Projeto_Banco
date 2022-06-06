using System.Collections.Generic;

namespace Projeto_06.Modelo.Dao
{
    internal interface ICrudBanco<T>
    {
        void Editar(T cliente);
        void Excluir(T cliente);
        void Inserir(T cliente);
        T listarByCpf(string CPF);
        List<T> ListarTodos();
    }
}