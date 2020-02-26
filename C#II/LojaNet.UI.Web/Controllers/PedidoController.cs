using LojaNet.Models;
using LojaNet.UI.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaNet.UI.Web.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Incluir()
        {
            var bllCliente = AppContainer.ObterClienteBLL();
            var bllProduto = AppContainer.ObterProdutoBLL();
            var pedido = new PedidoViewModel();
            pedido.FormasPagamento = Enum.GetNames(typeof(FormaPagamentoEnum)).ToList();
            pedido.Clientes = bllCliente.ObterTodosClientes();
            pedido.Produtos = bllProduto.ObterTodosProdutos();
            return View(pedido);
        }
    }
}