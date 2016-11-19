using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;

namespace FirstREST.Controllers
{
    public class TopCategoriasController : ApiController
    {
        //GET: /TopCategorias?nr=
        //

        public IEnumerable<Lib_Primavera.Model.TopCategoria> Get(long nr)
        {
            return Lib_Primavera.PriIntegration.ListaTopCategorias(nr);
        }

    }
}