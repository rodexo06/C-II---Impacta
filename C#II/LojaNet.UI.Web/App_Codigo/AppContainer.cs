using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaNet.BLL;
using LojaNet.BLL.LojaNet.BLL;
using LojaNet.DAL;
using LojaNet.Models;
using LojaNet.Models.Contracts;

//Mudei o namespace para o web mesmo
namespace LojaNet.UI.Web
{
    public static class AppContainer
    {
        public static IClienteDAL ObterClienteBLL()
        {
            var dal = new ClienteDAL();
            var bll = new ClienteBLL(dal);
            return bll;
        }
        public static IProdutosDAL ObterProdutoBLL()
        {
            var dal = new ProdutoDAL();
            var bll = new ProdutoBLL(dal);
            return bll;
        }
    }
}