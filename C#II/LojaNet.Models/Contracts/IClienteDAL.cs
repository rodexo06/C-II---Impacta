using System;
using System.Collections.Generic;
using System.Text;

namespace LojaNet.Models.Contracts
{
    public interface IClienteDAL
    {
        void Incluir (Cliente cliente);
        void Alterar (Cliente cliente);
        //void Excluir (string id);
        List<Cliente> ObterTodosClientes ();
        Cliente ObterporId(string id);
        Cliente ObterporEmail(string email);
        void Excluir(string id, string httpContext);
    }
}
