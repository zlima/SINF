using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class NewOrdersNumberController : ApiController
    {
        //
        //GET: /NewOrdersNumber/

        public IEnumerable<Lib_Primavera.Model.NewOrdersNumber> Get()
        {
            return Lib_Primavera.PriIntegration.NewOrdersCount();
        }
    }
}
