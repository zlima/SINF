﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class OrdersCountController : ApiController
    {
        //
        // GET: /OrdersCount/


        public IEnumerable<Lib_Primavera.Model.OrdersCount> Get()
        {
            return Lib_Primavera.PriIntegration.OrdersCount();
        }

    }
}
