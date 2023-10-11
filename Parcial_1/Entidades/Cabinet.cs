using System.Text;

namespace Entidades
{
    public class Cabinet : Producto
    {
        private int cantCableRojoConsumida;
        private int cantBarraPlasticoConsumida;
        private int cantBaraHierroConsumida;
        private int cantEngranajeHierroConsumida;
        private int cantVentiladorConsumida;
        private static int contadorProducto = 0;
        private static string? tipoProducto;
        private static ulong codigoFabricacionC;
        private List<int> listaCantidadesConstantes;
        private List<int> listaValores;

        public Cabinet()
        {
            this.cantCableRojoConsumida = 2;
            this.cantBarraPlasticoConsumida = 10;
            this.cantBaraHierroConsumida = 12;
            this.cantEngranajeHierroConsumida = 12;
            this.cantVentiladorConsumida = 4;
            codigoFabricacionC = 43885702;

            TipoProducto = TiposProductos.Cabinet.ToString();
            listaValores = new List<int>();
            this.listaCantidadesConstantes = new List<int> {
                CableRojoNecesaria, BarraPlasticoNecesaria, BaraHierroNecesaria, 
                EngranajeHierroNecesaria, VentiladorNecesaria
            };
        }

        // el atributo 'contadorProducto' y si propiedad podrian heredar de una clase producto
        public static int CantidadProducto
        {
            get { return contadorProducto; }
            set { contadorProducto = value; }
        }

        public static string TipoProducto
        {
            get
            {
                if (tipoProducto != null)
                {
                    return tipoProducto;
                }

                return "No Type";
            }
            set { tipoProducto = value; }
        }

        public static ulong CodigoFabricacionCabinet
        {
            get { return codigoFabricacionC; }
            set { codigoFabricacionC = value; }
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

        /// <summary>
        /// Creamos una lista en donde le damos valores por cada cantidad de materiales que necesitara para
        /// producir la cantidad ingresada
        /// </summary>
        /// <param name="cantidadFdabricar">Cantidad de productos a fabricar</param>
        /// <returns>Retornamos la lista creada con valores enteros</returns>
        public List<int> CrearLista(int cantidadFdabricar)
        {
            this.listaValores.Add(cantidadFdabricar * CableRojoNecesaria);
            this.listaValores.Add(cantidadFdabricar * BarraPlasticoNecesaria);
            this.listaValores.Add(cantidadFdabricar * BaraHierroNecesaria);
            this.listaValores.Add(cantidadFdabricar * EngranajeHierroNecesaria);
            this.listaValores.Add(cantidadFdabricar * VentiladorNecesaria);

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
        /// Le resto las cantidades utilizadas en la fabricacion del producto al Stock
        /// </summary>
        /// <param name="valor">El valor con el que transformo en negativo la lista '-1'</param>
        /// <param name="listaValores">Lista de cantidad de materiales utilizados</param>
        /// <returns>Retora true si se cumplio la condicion, sino false</returns>
        public override bool FabricarProducto(int valor, List<int> listaValores)
        {
            if (listaValores.Count > 0 && listaValores != null)
            {
                Stock.CantCableRojo += valor * this.listaValores[0];
                Stock.CantBarraPlastico += valor * this.listaValores[1];
                Stock.CantBaraHierro += valor * this.listaValores[2];
                Stock.CantEngranajeHierro += valor * this.listaValores[3];
                Stock.CantVentilador += valor * this.listaValores[4];

                return true;
            }

            return false;
        }

        /// <summary>
        /// Creamos un StringBuilder en donde le ingresaremos datos que mostraremos 
        /// </summary>
        /// <returns>Retorna un string con un formato específico</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Empresa: {RazonSocial} - CUIT: {CUIT}");
            sb.AppendLine($"Codigo de fabricacion: {CodigoFabricacionCabinet}");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del metodo Mostrar
        /// </summary>
        /// <param name="c">Clase actual</param>
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
