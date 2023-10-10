using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto : Empresa
    {
        protected static ulong codigoFabricacion;
        protected Producto()
        {
            codigoFabricacion = (ulong)new Random().Next(10000000, 99999999);
        }

        protected ulong CodigoFabricacion 
        {
            get { return codigoFabricacion; }
            set { codigoFabricacion = value; } 
        }

        public abstract bool FabricarProducto(int valor, List<int> lista);

        public abstract string Mostrar();
    }
}

