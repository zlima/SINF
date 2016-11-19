using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Lib_Primavera.Model
{
    public class TopRendimento
    {
        public string CodArtigo
        {
            get;
            set;
        }

        public string NomeArtigo
        {
            get;
            set;
        }

        public double QuantidadeArtigo
        {
            get;
            set;
        }

        public double PrecUnitArtigo
        {
            get;
            set;
        }
        public double RendimentoArtigo
        {
            get;
            set;
        }
    }
}

