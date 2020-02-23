using System;
using System.Collections.Generic;
using System.Text;

namespace LojaNet.Models.Contracts
{
    public interface IProdutosDAL
    {
        void Incluir(Produto produto);
        void Alterar(Produto produto );
        void Excluir (string id);
        List<Produto> ObterTodosProdutos();
        Produto ObterporId(string id);
    }
}
