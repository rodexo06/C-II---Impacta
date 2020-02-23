using System;
using System.Collections.Generic;
using System.Text;
using LojaNet.Models;
using LojaNet.DAL;
using LojaNet.Models.Contracts;

namespace LojaNet.BLL
{
    public class ProdutoBLL : IProdutosDAL
    {
        private IProdutosDAL dal;
        public ProdutoBLL(IProdutosDAL produtosDAL)
        {
            this.dal = produtosDAL;
        }
        public void Alterar(Produto produto)
        {
            Validar(produto);
            if (string.IsNullOrEmpty(produto.Id))
            {
                throw new ApplicationException("O Id deve ser informado");
            }
            dal.Alterar(produto);
        }

        public void Excluir(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ApplicationException("O Id deve ser informado");
            }
            dal.Excluir(id.ToString());
        }

        public void Incluir(Produto produto)
        {
            Validar(produto);
            if (string.IsNullOrEmpty(produto.Id))
            {
                produto.Id = Guid.NewGuid().ToString();
            }

            dal.Incluir(produto);
        }

        private static void Validar(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Nome))
            {
                throw new ApplicationException("O nome já existe");
            }
            if(produto.Preco < 0)
            {
                throw new Exception("O preço tem que ser maio que 0");
            }
        }

        public Produto ObterporId(string id)
        {
            return dal.ObterporId(id);
        }

        public List<Produto> ObterTodosProdutos()
        {
            var lista = dal.ObterTodosProdutos();
            return lista;
        }
    }
}
