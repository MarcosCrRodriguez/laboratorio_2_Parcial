using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto : Empresa
    {
        protected Producto(string razonSocial, string cuit, ulong codigoFabricacion) : base (razonSocial, cuit)
        {
            this.CodigoFabricacion = codigoFabricacion;
        }

        protected ulong CodigoFabricacion { get; set; }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Codigo de fabricacion: {CodigoFabricacion}");

            return sb.ToString();
        }
    }
}

