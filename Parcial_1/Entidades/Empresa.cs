using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empresa
    {
        protected Empresa(string razonSocial, string cuit)
        {
            this.RazonSocial = razonSocial;
            this.CUIT = cuit;
        }

        protected string CUIT { get; set; }
        protected string RazonSocial { get; set; }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Empresa: {RazonSocial} - CUIT: {CUIT}");

            return sb.ToString();
        }

    }
}
