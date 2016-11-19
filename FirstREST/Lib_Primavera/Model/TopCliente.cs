using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Lib_Primavera.Model
{
    public class TopCliente 
    {
        public string NomeCliente
        {
            get;
            set;
        }

        public string MoradaCliente
        {
            get;
            set;
        }
        public double RendimentoCliente
        {
            get;
            set;
        }

    }
}
