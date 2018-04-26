using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuServicoWeb.Models
{
    public class Transacao
    {
        public long IDTransacao { get; set; }

        public long IDConta { get; set; }

        public float valorTransacao { get; set; }

        public DateTime dataTransacao { get; set; }

    }
}