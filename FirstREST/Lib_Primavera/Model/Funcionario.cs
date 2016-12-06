using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Lib_Primavera.Model
{
    public class Funcionario 
    {
        public string CodFunc
        {
            get;
            set;
        }
        public string NomeFunc
        {
            get;
            set;
        }
        public double OrdenadoMensal
        {
            get;
            set;
        }
        public double HorasMes
        {
            get;
            set;
        }
        public string Sexo
        {
            get;
            set;
        }
        public string Distrito
        {
            get;
            set;
        }
        public double Idade
        {
            get;
            set;
        }
    }
}
