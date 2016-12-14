using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class PreviousIncomeValuesController : ApiController
    {
        public IEnumerable<Lib_Primavera.Model.TotalIncomeByMonth> Get(string dateBegin)
        {
            return Lib_Primavera.PriIntegration.ListaIncomeLasMonths(dateBegin);
        }
    }
}
