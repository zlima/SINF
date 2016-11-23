using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class GetAccountsPayableController: ApiController
    {
        //
        // GET: /GetAccountsPayable/

       
        public IEnumerable<Lib_Primavera.Model.GetAccountsPayable> Get()
        {
            return Lib_Primavera.PriIntegration.GetAccountsPayable();
        }

    }
}
