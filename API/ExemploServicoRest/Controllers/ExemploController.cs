using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExemploServicoRest.Controllers
{
    public class ExemploController : ApiController
    {

        private new List<Fornecedor> obterForncedor()
        {
            var lista = new List<Fornecedor>();
            lista.Add(new Fornecedor { Email = "empresax@gmail.com", Nome = "Empresax" , id = 1});
            lista.Add(new Fornecedor { Email = "empresay@gmail.com", Nome = "Empresay" , id = 2});
            lista.Add(new Fornecedor { Email = "empresaz@gmail.com", Nome = "Empresaz", id = 3 });
            return lista;
        }

        // GET api/<controller>
        public IEnumerable<Fornecedor> Get()
        {
            return obterForncedor();
        }

        // GET api/<controller>/5
        public Fornecedor Get(int id)
        {
            var lista = obterForncedor();
            var fornecedor = lista.Where(m => m.id == id).First();
            return fornecedor;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}