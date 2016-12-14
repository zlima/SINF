using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Lib_Primavera.Model
{
    public class TotalIncomeByMonth
    {
        public double ValorInc
        {
            get;
            set;
        }

        public double ValorOut
        {
            get;
            set;
        }

        public int Date
        {
            get;
            set;
        }
    }
}
