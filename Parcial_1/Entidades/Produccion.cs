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
            // intentar en algun momento ver de que agrege ciertos materiales por proceso y en base
            // a eso que devuelva true o false si hay o faltan materia prima 
            bool retorno = false;

            switch (proceso) 
            {
                case ProcesoProduccion.Soldar:
                    retorno = true;
                    break;
                case ProcesoProduccion.Conectar:
                    retorno = true;
                    break;
                case ProcesoProduccion.Ensamblar:
                    retorno = true;
                    break;

            }

            return retorno;
        }

    }
}
