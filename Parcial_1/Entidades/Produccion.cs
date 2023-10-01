using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Produccion
    {
        public static bool Elaborar(ProcesoProduccion proceso)
        {
            bool retorno = false;

            switch (proceso) 
            {
                case ProcesoProduccion.Soldar:
                    retorno = true;
                    break;
                case ProcesoProduccion.Conectar:
                    retorno = true;
                    break;

            }

            return retorno;
        }

    }
}
