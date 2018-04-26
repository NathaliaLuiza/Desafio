using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuServicoWeb.Models
{
    public class Pessoa
    {
        public long IDPessoa { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

    }
}