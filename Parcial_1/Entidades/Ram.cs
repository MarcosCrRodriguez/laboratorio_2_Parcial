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
        private static ulong codigoFabricacionR;
        private List<int> listaCantidadesConstantes;
        private List<int> listaValores;

        public Ram()
        {
            codigoFabricacionR = 57001313;

            TipoProducto = TiposProductos.Ram.ToString();
            listaValores = new List<int>();
            this.listaCantidadesConstantes = new List<int> {
                CircuitoElectNecesaria, BarraPlasticoNecesaria, BaraHierroNecesaria,
                EngranajeHierroNecesaria 
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

        public static ulong CodigoFabricacionRam
        {
            get { return codigoFabricacionR; }
            set { codigoFabricacionR = value; }
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

        /// <summary>
        /// Creamos una lista en donde le damos valores por cada cantidad de materiales que necesitara para
        /// producir la cantidad ingresada
        /// </summary>
        /// <param name="cantidadFdabricar">Cantidad de productos a fabricar</param>
        /// <returns>Retornamos la lista creada con valores enteros</returns>
        public List<int> CrearLista(int cantidadFdabricar)
        {
            this.listaValores.Add(cantidadFdabricar * CircuitoElectNecesaria);
            this.listaValores.Add(cantidadFdabricar * BarraPlasticoNecesaria);
            this.listaValores.Add(cantidadFdabricar * BaraHierroNecesaria);
            this.listaValores.Add(cantidadFdabricar * EngranajeHierroNecesaria);

            return this.listaValores;
        }

        public int this[int index]
        {
            get { return listaValores[index]; }
            set { listaValores[index] = value; }
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

            sb.AppendLine($"Empresa: {RazonSocial} - CUIT: {CUIT}");
            sb.AppendLine($"Codigo de fabricacion: {CodigoFabricacionRam}");
            sb.AppendLine($"Producto *- {TipoProducto} -*");
            sb.AppendLine($"Cantidad de productos fabricados -> {CantidadProducto}");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del metodo Mostrar
        /// </summary>
        /// <param name="r">Clase actual</param>
        public static explicit operator string(Ram r)
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(r.Mostrar());

            return sb.ToString();
        }
    }
}
