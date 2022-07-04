using Microsoft.AspNetCore.Mvc;
using Projeto_06;
using Projeto_06.Dao;
using System;

namespace Banco.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetClientes()
        {
            ClienteDao clienteDao = new();

            var resultado = clienteDao.listarCliente();

            return Ok(resultado);
        }

        [HttpPost]
        public IActionResult PostClientes(Cliente cliente)
        {
            ClienteDao clienteDao = new();
            var resultado = clienteDao.Inserir(cliente);
            if (resultado == 0)
            {
                BadRequest("Não foi possivel salvar");
            }
            return Ok(cliente);
        }

        [HttpDelete("{cpf}")]

        public IActionResult DeleteClientes(string cpf)
        {
            var cliente = new Cliente
            {
                CPF = cpf,
            };
            ClienteDao clienteDao = new();
            var excluir = clienteDao.Excluir(cliente);
            if (excluir == false)
            {
                BadRequest("Não foi possível excluir cliente");
            }
            return Ok();
        }
        [HttpPut]

        public IActionResult EditarClientes(Cliente cliente)
        {
            ClienteDao clienteDao = new();
            try
            {
                var clienteExiste = clienteDao.ListarClientePorCpf(cliente.CPF);

            }
            catch (Exception e)
            {
                return BadRequest("Cliente não existe");

            }

            clienteDao.Editar(cliente);
            return Ok();
        }



    }
}
