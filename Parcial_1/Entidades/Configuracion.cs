using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Configuracion
    {
        private string pathImagenCircuitoAzul;
        private string pathImagenCircuitoRojo;
        private string pathImagenCircuitoCeleste;

        public Configuracion(string pathImagenCircuitoAzul, string pathImagenCircuitoRojo, string pathImagenCircuitoCeleste)
        {
            this.pathImagenCircuitoAzul = pathImagenCircuitoAzul;
            this.pathImagenCircuitoRojo = pathImagenCircuitoRojo;
            this.pathImagenCircuitoCeleste = pathImagenCircuitoCeleste;
        }

        public string PathImagenCircuitoAzul { get => pathImagenCircuitoAzul; }
        public string PathImagenCircuitoRojo { get => pathImagenCircuitoRojo; }
        public string PathImagenCircuitoCeleste { get => pathImagenCircuitoCeleste; }
    }
}
