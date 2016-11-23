using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class TotalOutComeByMonthController : ApiController
    {
        //
        // GET: /Outcome/

        public IEnumerable<Lib_Primavera.Model.TotalOutcomeByMonth> Get(double mes, double ano)
        {
            return Lib_Primavera.PriIntegration.ListaOutcomeByMonth(mes, ano);
        }
    }
}
