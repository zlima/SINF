using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class TotalClientesController : ApiController
    {
        //
        // GET: /TotalClientes
        public IEnumerable<Lib_Primavera.Model.TotalClientes> Get()
        {
            return Lib_Primavera.PriIntegration.TotalClientes();
        }
    }
}
