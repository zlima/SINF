using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class TotalIncomeByMonthController : ApiController
    {
        //
        // GET: /Income/

        public IEnumerable<Lib_Primavera.Model.TotalIncomeByMonth> Get(double mes, double ano)
        {
            return Lib_Primavera.PriIntegration.ListaIncomeByMonth(mes, ano);
        }
    }
}
