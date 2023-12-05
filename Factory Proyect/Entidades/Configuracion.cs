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
        private string pathImagenOjoApagado;
        private string pathImagenOjoPrendido;
        private string pathImagenCamion;
        private string pathGifLoading;
        private string pathGifEnviar;

        public Configuracion(string pathImagenCircuitoAzul, string pathImagenCircuitoRojo, string pathImagenCircuitoCeleste, string pathImagenOjoApagado, string pathImagenOjoPrendido, string pathImagenCamion, string pathGifLoading, string pathGifEnviar)
        {
            this.pathImagenCircuitoAzul = pathImagenCircuitoAzul;
            this.pathImagenCircuitoRojo = pathImagenCircuitoRojo;
            this.pathImagenCircuitoCeleste = pathImagenCircuitoCeleste;
            this.pathImagenOjoApagado = pathImagenOjoApagado;
            this.pathImagenOjoPrendido = pathImagenOjoPrendido;
            this.pathImagenCamion = pathImagenCamion;
            this.pathGifLoading = pathGifLoading;
            this.pathGifEnviar = pathGifEnviar;
        }

        public string PathImagenCircuitoAzul { get => pathImagenCircuitoAzul; }
        public string PathImagenCircuitoRojo { get => pathImagenCircuitoRojo; }
        public string PathImagenCircuitoCeleste { get => pathImagenCircuitoCeleste; }
        public string PathImagenOjoApagado { get => pathImagenOjoApagado; }
        public string PathImagenOjoPrendido { get => pathImagenOjoPrendido; }
        public string PathImagenCamion { get => pathImagenCamion; }
        public string PathGifLoading { get => pathGifLoading; }
        public string PathGifEnviar { get => pathGifEnviar; }
    }
}
