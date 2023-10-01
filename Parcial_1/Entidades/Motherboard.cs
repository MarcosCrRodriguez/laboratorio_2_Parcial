using System.Text;

namespace Entidades
{
    public class Motherboard : Producto
    {
        private const int cantCircuitoElectAvanzadoConsumida = 7;
        private const int cantCableRojoConsumida = 12;
        private const int cantBarraPlasticoConsumida = 5;
        private const int cantBaraHierroConsumida = 5;
        private const int cantEngranajeHierroConsumida = 11;
        private const int cantFibrasVidrioConsumida = 15;
        private const int cantcantCondensadorConsumida = 9;
        private const int cantVentiladorConsumida = 1;
        private static int contadorProducto = 0;
        private static string tipoProducto;

        public Motherboard(string razonSocial, string cuit, ulong codigoFabricacion) : base(razonSocial, cuit, codigoFabricacion)
        {
            TipoProducto = TiposProductos.Motherboard.ToString();
        }

        // el atributo 'contadorProducto' y si propiedad podrian heredar de una clase producto
        public static int CantidadProducto
        {
            get { return contadorProducto; } 
            set { contadorProducto += value;}
        }

        public static string TipoProducto
        {
            get { return tipoProducto; }
            set { tipoProducto = value; }
        }

        public int CircuitoElectAvanzadoNecesaria
        {
            get { return cantCircuitoElectAvanzadoConsumida; }
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

        public static explicit operator string(Motherboard m)
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(m.Mostrar());
            sb.AppendLine($"Producto *- {TipoProducto} -*");
            sb.AppendLine($"Cantidad de productos fabricados -> {CantidadProducto}");

            return sb.ToString();
        }
    }
}
