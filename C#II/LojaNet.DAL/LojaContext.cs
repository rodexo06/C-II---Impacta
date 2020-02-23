using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using LojaNet.Models;

namespace LojaNet.DAL
{
    class LojaContext : DbContext
    {
        public LojaContext() : base(DbHelper.conexao)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
