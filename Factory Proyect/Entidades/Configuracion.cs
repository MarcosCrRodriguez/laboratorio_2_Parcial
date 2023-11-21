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
        private string pathGifLoading;

        public Configuracion(string pathImagenCircuitoAzul, string pathImagenCircuitoRojo, string pathImagenCircuitoCeleste, string pathGifLoading)
        {
            this.pathImagenCircuitoAzul = pathImagenCircuitoAzul;
            this.pathImagenCircuitoRojo = pathImagenCircuitoRojo;
            this.pathImagenCircuitoCeleste = pathImagenCircuitoCeleste;
            this.pathGifLoading = pathGifLoading;
        }

        public string PathImagenCircuitoAzul { get => pathImagenCircuitoAzul; }
        public string PathImagenCircuitoRojo { get => pathImagenCircuitoRojo; }
        public string PathImagenCircuitoCeleste { get => pathImagenCircuitoCeleste; }
        public string PathGifLoading { get => pathGifLoading; }
    }
}
