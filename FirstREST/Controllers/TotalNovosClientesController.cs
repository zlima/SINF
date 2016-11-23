using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class TotalNovosClientesController : ApiController
    {
        public IEnumerable<Lib_Primavera.Model.TotalNovosClientes> Get()
        {
            return Lib_Primavera.PriIntegration.ListaNovosClientes();
        }
    }
}


