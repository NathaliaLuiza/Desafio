using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuServicoWeb.Models
{
    public class Cliente
    {
    public long ID { get; set; } 

    public string Nome { get; set; } 

    public string Email { get; set; } 

    public bool Ativo { get; set; }

    }
}