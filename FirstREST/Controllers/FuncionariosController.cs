using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class FuncionariosController : ApiController
    {
        //
        // GET: /Funcionarios/

        public IEnumerable<Lib_Primavera.Model.Funcionario> Get()
        {
            return Lib_Primavera.PriIntegration.ListaFuncionarios();
        }
    }
}
