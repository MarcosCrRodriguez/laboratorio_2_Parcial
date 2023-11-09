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
            // tendremos que programar timers para sus distintos procesos
            bool retorno = false;

            switch (proceso) 
            {
                case ProcesoProduccion.Soldar:
                    retorno = true;
                    break;
                case ProcesoProduccion.Ensamblar:
                    retorno = true;
                    break;
                case ProcesoProduccion.Conectar:
                    retorno = true;
                    break;
                case ProcesoProduccion.Empaquetar:
                    retorno = true;
                    break;

            }

            return retorno;
        }

    }
}
