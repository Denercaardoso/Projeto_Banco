using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_06.Modelo.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_06.Modelo.Dao.Tests
{
    [TestClass()]
    public class CrudContaTests
    {
        [TestMethod()]
        public void inserirContaCorrenteTest()
        {
            //ARRANGE
            var crudConta = new CrudConta();
            var contaCorrente = new ContaCorrente()
            {
                Agencia = 100,
                NumeroDaConta = 1000
            };

            //ACT
            crudConta.CreateContaCorrente(contaCorrente);

            Assert.IsTrue(true);
        }
    }
}