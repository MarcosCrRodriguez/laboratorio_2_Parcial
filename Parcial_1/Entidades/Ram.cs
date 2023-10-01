using System.Text;

namespace Entidades
{
    public class Ram : Producto
    {
        private const int cantCircuitoElectConsumida = 2;
        private const int cantBarraPlasticoConsumida = 2;
        private const int cantBaraHierroConsumida = 2;
        private const int cantEngranajeHierroConsumida = 3;
        private static int contadorProducto = 0;
        private static string tipoProducto;

        public Ram(string razonSocial, string cuit, ulong codigoFabricacion) : base(razonSocial, cuit, codigoFabricacion)
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

        public int CircuitoElectNecesaria
        {
            get { return cantCircuitoElectConsumida; }
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

        // intentar realizar una sobrecarga del metodo
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Producto *- {TipoProducto} -*");
            sb.AppendLine($"Cantidad de productos fabricados -> {CantidadProducto}");

            return sb.ToString();
        }

        public static explicit operator string(Ram r)
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(r.Mostrar());
            sb.AppendLine($"Producto *- {TipoProducto} -*");
            sb.AppendLine($"Cantidad de productos fabricados -> {CantidadProducto}");

            return sb.ToString();
        }
    }
}
