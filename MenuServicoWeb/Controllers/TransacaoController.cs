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
    public class TransacaoController : ApiController
    {
        // GET: api/Transacao
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Transacao/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Transacao
        public HttpResponseMessage Post([FromBody] Transacao value)
        {
            TransacaoProgramme tp = new TransacaoProgramme();
            long id;
            id = tp.realizarTransacao(value);
            value.IDTransacao = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("transacao/{0}", id));
            return response;

        }

        // PUT: api/Transacao/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Transacao/5
        public void Delete(int id)
        {
        }
    }
}
