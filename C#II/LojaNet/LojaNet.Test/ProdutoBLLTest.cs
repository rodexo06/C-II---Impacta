using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LojaNet.Models.Contracts;
using LojaNet.Models;
using LojaNet.BLL;

namespace LojaNet.Test
{
    /// <summary>
    /// Descrição resumida para ProdutoBLLTest
    /// </summary>
    [TestClass]
    public class ProdutoBLLTest
    {
        public class ProdutoDALMock : IProdutosDAL
        {
            public void Alterar(Produto produto)
            {
                throw new NotImplementedException();
            }

            public void Excluir(string id)
            {
            }

            public void Incluir(Produto produto)
            {
            }

            public Produto ObterporId(string id)
            {
                throw new NotImplementedException();
            }

            public List<Produto> ObterTodosProdutos()
            {
                throw new NotImplementedException();
            }
        }


        [TestMethod]
        public void IncluirNomeNotNullTest()
        {

            var produto = new Produto
            {
                Nome = "blabla",
                Preco = 20,
                Estoque = 20
            };
            var DAL = new ProdutoDALMock();
            var bll = new ProdutoBLL(DAL);
            bool ok = true;
            try
            {
                bll.Incluir(produto);
            }
            catch (ApplicationException ex)
            {
                ok = false;
            }

            Assert.IsTrue(ok, "Deveria ter disparado um Exception");
        }
    }
}
