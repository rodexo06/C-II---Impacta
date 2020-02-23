using System;
using System.Collections.Generic;
using System.Text;

namespace LojaNet.Models
{
    public class Produto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public float Estoque { get; set; }
    }
}
