using System;
using LojaNet.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaNet.Test
{
    [TestClass]
    public class ClientDALTest
    {
        [TestMethod]
        public void ObterPorEmailTestNull()
        {
            string email = "null";
            var dal = new ClienteDAL();
            bool ok = false;
            try
            {
                var cliente = dal.ObterporEmail(email);
            }
            catch (ApplicationException ex)
            {
                if(ex.Message == "O email deve ser informado")
                {
                    ok = true;
                }
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Assert.IsTrue(ok, "Deveria ter disparado um ApplicationException com a mensgaem O email deve ser informado");
        }

        [TestMethod]
        public void ObterPorEmailTest()
        {
            string email = "teste@silva.com.br";
            var dal = new ClienteDAL();
            var cliente = dal.ObterporEmail(email);
            if (cliente == null)
            {
                Console.WriteLine("Cliente encontrado:");
                Console.WriteLine(cliente.Id);
                Console.WriteLine(cliente.Nome);
                Console.WriteLine(cliente.Email);
                Console.WriteLine(cliente.Telefone);
            }
            Assert.IsTrue(cliente != null, "Deveria ser retonado uma instancia de um cliente ");
        }
    }
}
