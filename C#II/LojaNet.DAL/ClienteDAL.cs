using LojaNet.Models;
using LojaNet.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaNet.DAL
    // Camada de acesso a dados
{
    public class ClienteDAL : IClienteDAL
    {
        public void Alterar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Excluir(string id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterporEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterporId(string id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ObterTodosClientes()
        {
            throw new NotImplementedException();
        }
    }
}
