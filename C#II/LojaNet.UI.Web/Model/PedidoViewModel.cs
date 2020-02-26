using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaNet.UI.Web.Model
{
    public class PedidoViewModel
    {
        public PedidoViewModel()
        {
            this.Clientes = new List<Cliente>();
            this.ListaItens = new List<Item>();
            this.Produtos = new List<Produto>();
            this.FormasPagamento = new List<string>();
            this.Data = DateTime.Now;
        }

        public string Id { get; set; }
        public DateTime Data { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Item> ListaItens { get; set; }
        public string ClienteId { get; set; }
        public List<string> FormasPagamento{ get; set; }
        public List<Produto> Produtos{ get; set; }
        public string FormaPagamento { get; set; }
        public class Item
        {
            public string ProdutoId { get; set; }
            public string ProdutoNome { get; set; }
            public int Quantidade { get; set; }
            public float ValorProduto { get; set; }
            public float ValorTotal
            {
                get { return ValorProduto * Quantidade; }
            }
        }
    }
}