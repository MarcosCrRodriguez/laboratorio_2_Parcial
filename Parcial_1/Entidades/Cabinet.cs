using System.Text;

namespace Entidades
{
    public class Cabinet : Producto
    {
        private const int cantCableRojoConsumida = 2;
        private const int cantBarraPlasticoConsumida = 10;
        private const int cantBaraHierroConsumida = 12;
        private const int cantEngranajeHierroConsumida = 12;
        private const int cantVentiladorConsumida = 4;
        private static int contadorProducto = 0;
        private static string tipoProducto;

        public Cabinet(string razonSocial, string cuit, ulong codigoFabricacion) : base(razonSocial, cuit, codigoFabricacion)
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

        public int CableRojoNecesaria
        {
            get { return cantCableRojoConsumida; }
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

        public int VentiladorNecesaria
        {
            get { return cantVentiladorConsumida; }
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Producto *- {TipoProducto} -*");
            sb.AppendLine($"Cantidad de productos fabricados -> {CantidadProducto}");

            return sb.ToString();
        }

        public static explicit operator string(Cabinet c)
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(c.Mostrar());
            sb.AppendLine($"Producto *- {TipoProducto} -*");
            sb.AppendLine($"Cantidad de productos fabricados -> {CantidadProducto}");

            return sb.ToString();
        }
    }
}
