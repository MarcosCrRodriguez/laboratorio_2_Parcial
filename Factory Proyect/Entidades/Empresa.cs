using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Empresa
    {
        protected static string? razonSocial;
        protected static string? cuit;
        protected Empresa()
        {
            razonSocial = "Factory.IO";
            cuit = "16-56433112-2";
        }

        #region Propiedades
        protected string CUIT 
        {
            get 
            { 
                if (cuit != null)
                {
                    return cuit;
                }
                else
                {
                    return "N/A";
                }
            }
            set { cuit = value; }
        }
        protected string RazonSocial 
        {
            get
            {
                if (razonSocial != null)
                {
                    return razonSocial;
                }
                else
                {
                    return "N/A";
                }
            }
            set { razonSocial = value; }
        }
        #endregion
    }
}
