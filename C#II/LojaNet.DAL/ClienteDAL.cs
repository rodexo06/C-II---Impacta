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
            DbHelper.ExecuteNonQuery("ClienteAlterar",
                "@Id", cliente.Id,
                "@Nome", cliente.Nome,
                "@Email", cliente.Email,
                "@Telefone", cliente.Telefone);
        }

        public void Excluir(string id)
        {
            DbHelper.ExecuteNonQuery("ClienteExcluir","@Id", id);
        }

        public void Incluir(Cliente cliente)
        {
            DbHelper.ExecuteNonQuery("ClienteIncluir",
                "@Id", cliente.Id,
                "@Nome", cliente.Nome,
                "@Email", cliente.Email,
                "@Telefone", cliente.Telefone);
        }

        public Cliente ObterporEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterporId(string id)
        {
            Cliente cliente = new Cliente();
            using (var reader = DbHelper.ExecuteReader("ClienteObterporId", "@Id", id))
            {
                if (reader.Read())
                {
                    cliente = ObterClienteReader(reader);
                }
            }
            return cliente;
        }

        private static Cliente ObterClienteReader(System.Data.IDataReader reader)
        {
            var cliente = new Cliente
            {
                Id = reader["Id"].ToString(),
                Nome = reader["Nome"].ToString(),
                Telefone = reader["Telefone"].ToString(),
                Email = reader["Email"].ToString()
            };
            return cliente;
        }

        public List<Cliente> ObterTodosClientes()
        {
            var listaCliente = new List<Cliente>();
            using (var reader = DbHelper.ExecuteReader("ClienteListar"))
            {
                while (reader.Read())
                {
                    var cliente = new Cliente
                    {
                        Id = reader["Id"].ToString(),
                        Nome = reader["Nome"].ToString(),
                        Telefone = reader["Telefone"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                    listaCliente.Add(cliente);
                }
            }
            return listaCliente;
        }
    }
}
