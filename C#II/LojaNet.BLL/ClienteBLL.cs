using LojaNet.DAL;
using LojaNet.Models;
using LojaNet.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaNet.BLL
{
    // Cmada de Validação de dados, regra de negocio
    public class ClienteBLL : IClienteDAL
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
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                throw new ApplicationException("O nome já existe");
            }
            if (string.IsNullOrEmpty(cliente.Id))
            {
                cliente.Id = Guid.NewGuid().ToString();
            }

            var dal = new ClienteDAL();
            dal.Incluir(cliente);
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
