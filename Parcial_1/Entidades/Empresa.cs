using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Empresa
    {
        protected static string razonSocial;
        protected static string cuit;
        protected Empresa()
        {
            razonSocial = "Factory.IO";
            cuit = "16-56433112-2";
        }

        protected string CUIT 
        {
            get { return cuit; }
            set { cuit = value; }
        }
        protected string RazonSocial 
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

    }
}
