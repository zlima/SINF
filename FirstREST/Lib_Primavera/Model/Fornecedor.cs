using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class Fornecedor
    {
        public string CodFornecedor
        {
            get;
            set;
        }

        public string Nome
        {
            get;
            set;
        }

        public string Moeda
        {
            get;
            set;
        }

        public string NumContrib
        {
            get;
            set;
        }

        public string ModoPag
        {
            get;
            set;
        }

        public string CondPag
        {
            get;
            set;
        }

        public double TotalDeb
        {
            get;
            set;
        }

    }
}