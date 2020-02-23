using System;
using System.Collections.Generic;
using LojaNet.BLL;
using LojaNet.BLL.LojaNet.BLL;
using LojaNet.DAL;
using LojaNet.Models;
using LojaNet.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaNet.Test
{
    [TestClass]
    public class ClienteBLLTest
    {
        public class ClienteDALMock : IClienteDAL
        {
            public void Alterar(Cliente cliente)
            {
                throw new NotImplementedException();
            }

            public void Excluir(string id, string httpContext)
            {
                throw new NotImplementedException();
            }

            public void Incluir(Cliente cliente)
            {

            }

            public Cliente ObterporEmail(string email)
            {
                return null;
            }

            public Cliente ObterporId(string id)
            {
                return null;
            }

            public List<Cliente> ObterTodosClientes()
            {
                throw new NotImplementedException();
            }
        }


        [TestMethod]
        public void IncluirNomeNullTest()
        {

            var cliente = new Cliente
            {
                Nome = null,
                Email = "email@teste.com",
                Telefone = "981804406"
            };
            var DAL = new ClienteDALMock();
            var bll = new ClienteBLL(DAL);
            bool ok = false;
            try
            {
                bll.Incluir(cliente);
            }
            catch (ApplicationException ex)
            {
                ok = true;
            }

            Assert.IsTrue(ok, "Deveria ter disparado um Exception");
        }


        [TestMethod]
        public void IncluirNomeNotNullTest()
        {

            var cliente = new Cliente
            {
                Nome = "blabla",
                Email = "email@teste.com",
                Telefone = "981804406"
            };
            var DAL = new ClienteDALMock();
            var bll = new ClienteBLL(DAL);
            bool ok = true;
            try
            {
                bll.Incluir(cliente);
            }
            catch (ApplicationException ex)
            {
                ok = false;
            }

            Assert.IsTrue(ok, "Deveria ter disparado um Exception");
        }
    }
}
