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
        private ClienteDAL dal;
        public ClienteBLL()
        {
            this.dal = new ClienteDAL();
        }
        public void Alterar(Cliente cliente)
        {
            Validar(cliente);
            if (string.IsNullOrEmpty(cliente.Id))
            {
                throw new ApplicationException("O Id deve ser informado");
            }
            dal.Alterar(cliente);
        }

        public void Excluir(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ApplicationException("O Id deve ser informado");
            }
            dal.Excluir(id);
        }

        public void Incluir(Cliente cliente)
        {
            Validar(cliente);
            if (string.IsNullOrEmpty(cliente.Id))
            {
                cliente.Id = Guid.NewGuid().ToString();
            }

            dal.Incluir(cliente);
        }

        private static void Validar(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                throw new ApplicationException("O nome já existe");
            }
        }

        public Cliente ObterporEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterporId(string id)
        {
            return dal.ObterporId(id);
        }

        public List<Cliente> ObterTodosClientes()
        {
            var lista = dal.ObterTodosClientes();
            return lista;
        }
    }
}
