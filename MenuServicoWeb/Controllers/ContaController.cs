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
    public class ContaController : ApiController
    {
        // GET: api/Conta
        public ArrayList Get()
        {
            ContaProgramme cc = new ContaProgramme();
            return cc.getConta();
        }

        // GET: api/Conta/5
        public Conta Get(long id)
        {
            ContaProgramme cc = new ContaProgramme();
            Conta conta = cc.getConta(id);
            return conta;
        }

        // POST: api/Conta
        public HttpResponseMessage Post([FromBody] Conta value)
        {
            ContaProgramme cc = new ContaProgramme();
            long id;
            id = cc.contaAdicionar(value);
            value.ID_Conta = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("conta/{0}", id));
            return response;
        }

        // PUT: api/Conta/5
        public HttpResponseMessage Put(int id, [FromBody]Conta value)
        {
            ContaProgramme cc = new ContaProgramme();
            bool recordExisted = false;
            recordExisted = cc.atualizarConta(id, value);

            HttpResponseMessage response;
            if (recordExisted)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;
        }

        // DELETE: api/Conta/5
        public void Delete(int id)
        {
        }
    }
}
