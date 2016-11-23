using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Lib_Primavera.Model
{
    public class TotalNovosClientes
    {
        public string CodCliente
        {
            get;
            set;
        }

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
        public DateTime DataCriacaoCliente
        {
            get;
            set;
        }
    }
}
