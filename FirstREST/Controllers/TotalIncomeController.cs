using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class TotalIncomeController : ApiController
    {
        //
        // GET: /TotalIncome/

        public IEnumerable<Lib_Primavera.Model.TotalIncome> Get()
        {
            return Lib_Primavera.PriIntegration.ListaIncome();
        }
    }
}
