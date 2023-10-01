using System.Text;

namespace Entidades
{
    public class VideoCard : Producto
    {
        private const int cantUniProcesamientoConsumida = 4;
        private const int cantCableVerdeConsumida = 9;
        private const int cantBarraPlasticoConsumida = 4;
        private const int cantBaraHierroConsumida = 3;
        private const int cantEngranajeHierroConsumida = 9;
        private const int cantFibrasVidrioConsumida = 5;
        private const int cantcantCondensadorConsumida = 7;
        private const int cantVentiladorConsumida = 2;
        private static int contadorProducto = 0;
        private static string tipoProducto;

        public VideoCard(string razonSocial, string cuit, ulong codigoFabricacion) : base(razonSocial, cuit, codigoFabricacion)
        {
            TipoProducto = TiposProductos.Motherboard.ToString();
        }

        // el atributo 'contadorProducto' y si propiedad podrian heredar de una clase producto
        public static int CantidadProducto
        {
            get { return contadorProducto; }
            set { contadorProducto += value; }
        }

        public static string TipoProducto
        {
            get { return tipoProducto; }
            set { tipoProducto = value; }
        }

        public int UnidadProcesamientoNecesaria
        {
            get { return cantUniProcesamientoConsumida; }
        }

        public int CableVerdeNecesaria
        {
            get { return cantCableVerdeConsumida; }
        }

        public int BarraPlasticoNecesaria
        {
            get { return cantBarraPlasticoConsumida; }
        }

        public int BaraHierroNecesaria
        {
            get { return cantBaraHierroConsumida; }
        }

        public int EngranajeHierroNecesaria
        {
            get { return cantEngranajeHierroConsumida; }
        }

        public int FibrasVidrioNecesaria
        {
            get { return cantFibrasVidrioConsumida; }
        }

        public int CondensadorNecesaria
        {
            get { return cantcantCondensadorConsumida; }
        }

        public int VentiladorNecesaria
        {
            get { return cantVentiladorConsumida; }
        }

        // intentar realizar una sobrecarga del metodo
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Producto *- {TipoProducto} -*");
            sb.AppendLine($"Cantidad de productos fabricados -> {CantidadProducto}");

            return sb.ToString();
        }

        public static explicit operator string(VideoCard v)
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(v.Mostrar());
            sb.AppendLine($"Producto *- {TipoProducto} -*");
            sb.AppendLine($"Cantidad de productos fabricados -> {CantidadProducto}");

            return sb.ToString();
        }
    }
}
