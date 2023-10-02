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
        private List<int> listaCantidadesConstantes;
        private List<int> listaValores;

        public Motherboard(string razonSocial, string cuit, ulong codigoFabricacion) : base(razonSocial, cuit, codigoFabricacion)
        {
            TipoProducto = TiposProductos.Motherboard.ToString();
            listaValores = new List<int>();
            this.listaCantidadesConstantes = new List<int> {
                CircuitoElectAvanzadoNecesaria, CableRojoNecesaria, BarraPlasticoNecesaria,
                BaraHierroNecesaria, EngranajeHierroNecesaria, FibrasVidrioNecesaria,
                CondensadorNecesaria, VentiladorNecesaria
            };
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

        public int this[int index]
        {
            get { return listaValores[index]; }
            set { listaValores[index] = value; }
        }

        /// <summary>
        /// Creamos una lista en donde le damos valores por cada cantidad de materiales que necesitara para
        /// producir la cantidad ingresada
        /// </summary>
        /// <param name="cantidadFdabricar">Cantidad de productos a fabricar</param>
        /// <returns>Retornamos la lista creada con valores enteros</returns>
        public List<int> CrearLista(int cantidadFdabricar)
        {
            this.listaValores.Add(cantidadFdabricar * CircuitoElectAvanzadoNecesaria);
            this.listaValores.Add(cantidadFdabricar * cantCableRojoConsumida);
            this.listaValores.Add(cantidadFdabricar * cantBarraPlasticoConsumida);
            this.listaValores.Add(cantidadFdabricar * cantBaraHierroConsumida);
            this.listaValores.Add(cantidadFdabricar * cantEngranajeHierroConsumida);
            this.listaValores.Add(cantidadFdabricar * cantFibrasVidrioConsumida);
            this.listaValores.Add(cantidadFdabricar * cantcantCondensadorConsumida);
            this.listaValores.Add(cantidadFdabricar * cantVentiladorConsumida);

            return this.listaValores;
        }

        /// <summary>
        /// Pisamos la lista con valores actualizados
        /// </summary>
        /// <param name="cantidadFdabricar">Cantidad de productos a fabricar</param>
        /// <returns>Retornamos la lista con los valores actualizados</returns>
        public List<int> PisarLista(int cantidadFdabricar)
        {
            for (int i = 0; i < listaValores.Count; i++)
            {
                this.listaValores[i] = cantidadFdabricar * this.listaCantidadesConstantes[i];
            }

            return this.listaValores;
        }

        /// <summary>
        /// Creamos un StringBuilder en donde le ingresaremos datos que mostraremos 
        /// </summary>
        /// <returns>Retorna un string con un formato específico</returns>
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Producto *- {TipoProducto} -*");
            sb.AppendLine($"Cantidad de productos fabricados -> {CantidadProducto}");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del metodo Mostrar
        /// </summary>
        /// <param name="m">Clase actual</param>
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
