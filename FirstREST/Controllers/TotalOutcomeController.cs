using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class TotalOutcomeController : ApiController
    {
        //
        // GET: /TotalOutcome/

        public IEnumerable<Lib_Primavera.Model.TotalOutcome> Get()
        {
            return Lib_Primavera.PriIntegration.ListaOutcome();
        }
    }
}
