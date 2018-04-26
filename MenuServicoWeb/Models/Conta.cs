using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuServicoWeb.Models
{
    public class Conta
    {
        public long ID_Conta { get; set; }

        public long ID_Pessoa { get; set; }

        public float Saldo { get; set; }

        public float LimiteSaqueDia { get; set; }

        public bool FlagAtivo { get; set; }

        public long TipoConta { get; set; }

        public DateTime DataCriacao { get; set; }

    }
}