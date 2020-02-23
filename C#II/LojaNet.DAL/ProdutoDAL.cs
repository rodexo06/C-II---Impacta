using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LojaNet.Models;
using LojaNet.Models.Contracts;

namespace LojaNet.DAL
{
    public class ProdutoDAL : IProdutosDAL  
    {
        private LojaContext db = new LojaContext();

        public void Alterar(Produto produto)
        {
            var produtooriginal = ObterporId(produto.Id);
            if (produtooriginal != null)
            {
                produtooriginal.Nome = produto.Nome;
                produtooriginal.Preco= produto.Preco;
                produtooriginal.Estoque= produto.Estoque;
                db.SaveChanges();
            }
        }

        public void Excluir(string id)
        {
            var produto = ObterporId(id);
            if (produto != null)
            {
                db.Produtos.Remove(produto);
                db.SaveChanges();
            }
        }

        public void Incluir(Produto produto)
        {
            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        public Produto ObterporId(string id)
        {
            var produto = db.Produtos.Where(m => m.Id == id).FirstOrDefault();
            return produto;
        }

        public List<Produto> ObterTodosProdutos()
        {
            return db.Produtos.ToList();
        }
    }
}
