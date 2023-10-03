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
        private const int cantCondensadorConsumida = 7;
        private const int cantVentiladorConsumida = 2;
        private static int contadorProducto = 0;
        private static string tipoProducto;
        private List<int> listaCantidadesConstantes;
        private List<int> listaValores;

        public VideoCard(string razonSocial, string cuit, ulong codigoFabricacion) : base(razonSocial, cuit, codigoFabricacion)
        {
            TipoProducto = TiposProductos.VideoCard.ToString();
            this.listaValores = new List<int>();
            this.listaCantidadesConstantes = new List<int> {
                UnidadProcesamientoNecesaria, CableVerdeNecesaria, BarraPlasticoNecesaria, 
                BaraHierroNecesaria, EngranajeHierroNecesaria, FibrasVidrioNecesaria,
                CondensadorNecesaria, VentiladorNecesaria
            };
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
            get { return cantCondensadorConsumida; }
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
            this.listaValores.Add(cantidadFdabricar * UnidadProcesamientoNecesaria);
            this.listaValores.Add(cantidadFdabricar * CableVerdeNecesaria);
            this.listaValores.Add(cantidadFdabricar * BarraPlasticoNecesaria);
            this.listaValores.Add(cantidadFdabricar * BaraHierroNecesaria);
            this.listaValores.Add(cantidadFdabricar * EngranajeHierroNecesaria);
            this.listaValores.Add(cantidadFdabricar * FibrasVidrioNecesaria);
            this.listaValores.Add(cantidadFdabricar * CondensadorNecesaria);
            this.listaValores.Add(cantidadFdabricar * VentiladorNecesaria);

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
                this[i] = cantidadFdabricar * this.listaCantidadesConstantes[i];
            }

            return this.listaValores;
        }

        /// <summary>
        /// Creamos un StringBuilder en donde le ingresaremos datos que mostraremos 
        /// </summary>
        /// <returns>Retorna un string con un formato específico</returns>
        public override string Mostrar()
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
        /// <param name="v">Clase actual</param>
        public static explicit operator string(VideoCard v)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(v.Mostrar());

            return sb.ToString();
        }
    }
}
