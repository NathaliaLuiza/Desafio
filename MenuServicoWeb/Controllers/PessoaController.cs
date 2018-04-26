using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MenuServicoWeb.Models;
using System.Collections;

namespace MenuServicoWeb.Controllers
{
    public class PessoaController : ApiController
    {
        // GET: api/Pessoa
        public ArrayList Get()
        {
            PessoaProgramme pp = new PessoaProgramme();
            return pp.getPessoa();
        }

        // GET: api/Pessoa/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pessoa
        public HttpResponseMessage Post([FromBody]Pessoa value)
        {
            PessoaProgramme pp = new PessoaProgramme();
            long id;
            id = pp.pessoaAdicionar(value);
            value.IDPessoa = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("pessoa/{0}", id));
            return response;

        }

        // PUT: api/Pessoa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pessoa/5
        public void Delete(int id)
        {
        }
    }
}
