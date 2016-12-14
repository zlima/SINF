using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class Dashboard
    {


        /* Exemplo para POST e GET com valores específicos
         public string Morada
        {
            get
            {
                return "MORADA: " + _morada;
            }
            set
            {
                _morada = value;
            }
        }
    
*/
        public int newOrders
        {
            get;
            set;
        }

        public double Revenue
        {
            get;
            set;
        }

        public int Orders
        {
            get;
            set;
        }

        public double AccountsPayable
        {
            get;
            set;
        }

        public double AccountsReceivable
        {
            get;
            set;
        }

        public int NewClients
        {
            get;
            set;
        }

        public int Increment
        {
            get;
            set;
        }

        public List<Model.TopCliente> TopClientes
        {
            get;
            set;
        }

        public List<Model.TopCategoria> TopFamilia
        {
            get;
            set;
        }

        public List<Model.TopVenda> TopProducts
        {
            get;
            set;
        }

        public int CountFac
        {
            get;
            set;
        }




    }
}