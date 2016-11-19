using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class TopClientesController : ApiController
    {
        //
        // GET: /TopCliente/

        public IEnumerable<Lib_Primavera.Model.TopCliente> Get(long nr)
        {
            return Lib_Primavera.PriIntegration.ListaTopCliente(nr);
        }
    }
}
