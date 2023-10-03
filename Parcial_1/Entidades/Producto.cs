using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto : Empresa
    {
        protected ulong codigoFabricacion;
        protected Producto(string razonSocial, string cuit, ulong codigoFabricacion) : base (razonSocial, cuit)
        {
            this.codigoFabricacion = codigoFabricacion;
        }

        protected ulong CodigoFabricacion 
        {
            get { return codigoFabricacion; }
            set { codigoFabricacion = value; } 
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Empresa: {RazonSocial} - CUIT: {CUIT}");
            sb.AppendLine($"Codigo de fabricacion: {CodigoFabricacion}");

            return sb.ToString();
        }
    }
}

