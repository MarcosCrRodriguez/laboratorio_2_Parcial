using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Empresa
    {
        protected string razonSocial;
        protected string cuit;
        protected Empresa(string razonSocial, string cuit)
        {
            this.razonSocial = razonSocial;
            this.cuit = cuit;
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

        public abstract string Mostrar();

    }
}
