﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ExemploServiço
{
    [DataContract]
    public class Produtos
    {
        public int Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public decimal Preco { get; set; }
    }
}