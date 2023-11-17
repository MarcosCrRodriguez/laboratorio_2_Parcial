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
                case ProcesoProduccion.Soldado:
                    retorno = true;
                    break;
                case ProcesoProduccion.Ensamblado:
                    retorno = true;
                    break;
                case ProcesoProduccion.Conectado:
                    retorno = true;
                    break;
                case ProcesoProduccion.Empaquetado:
                    retorno = true;
                    break;

            }

            return retorno;
        }

    }
}
