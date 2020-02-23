using LojaNet.BLL;
using LojaNet.BLL.LojaNet.BLL;
using LojaNet.DAL;
using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LojaNet.Services
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "ServiceConsultaCliente" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione ServiceConsultaCliente.svc ou ServiceConsultaCliente.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class ServiceConsultaCliente : IServiceConsultaCliente
    {
        public ClienteInfo ConsultaPorEmail(string chave, string email)
        {
            if (chave != "1234567890@!")
            {
                return null;
            }
            ClienteInfo clienteInfo = null;
            var dal = new ClienteDAL();
            var bll = new ClienteBLL(dal);
            var cliente = bll.ObterporEmail(email);
            if(cliente == null)
            {
                return null;
            }
            else
            {
                clienteInfo = new ClienteInfo
                {
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone
                };
                return clienteInfo;
            }
        }
    }
}
