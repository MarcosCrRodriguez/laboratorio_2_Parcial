﻿using System.Text;

namespace Entidades
{
    public class Ram : Producto
    {
        private IMateriales gestorMateriales;

        private int cantCircuitoElectConsumida;
        private int cantBarraPlasticoConsumida;
        private int cantBaraHierroConsumida;
        private int cantEngranajeHierroConsumida;
        private static int contadorProducto = 0;
        private static string? tipoProducto;
        private static ulong codigoFabricacionR;
        private List<int> listaCantidadesConstantes;
        private List<int> listaValores;

        public Ram()
        {
            this.gestorMateriales = new StockDAO();

            this.cantCircuitoElectConsumida = 2;
            this.cantBarraPlasticoConsumida = 2;
            this.cantBaraHierroConsumida = 2;
            this.cantEngranajeHierroConsumida = 3;
            codigoFabricacionR = 57001313;

            TipoProducto = TiposProductos.Ram.ToString();
            listaValores = new List<int>();
            this.listaCantidadesConstantes = new List<int> {
                CircuitoElectNecesaria, BarraPlasticoNecesaria, BaraHierroNecesaria,
                EngranajeHierroNecesaria 
            };
        }

        #region Propiedades
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
        #endregion

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
        /// Le resto las cantidades utilizadas en la fabricacion del producto al Stock
        /// </summary>
        /// <param name="valor">El valor con el que transformo en negativo la lista '-1'</param>
        /// <param name="listaValores">Lista de cantidad de materiales utilizados</param>
        /// <returns>Retora true si se cumplio la condicion, sino false</returns>
        public override bool FabricarProducto(int valor, List<int> listaValores)
        {
            int cantidadAgregar;

            if (listaValores.Count > 0 && listaValores != null)
            {
                cantidadAgregar = Stock.VerificarValorPositivo((valor * this.listaValores[0]), 1077, "CIRCUITO_ELECTRONICO");
                this.gestorMateriales.Modificar("CIRCUITO_ELECTRONICO", cantidadAgregar, 1077);
                cantidadAgregar = Stock.VerificarValorPositivo((valor * this.listaValores[1]), 1077, "BARRA_PLASTICA");
                this.gestorMateriales.Modificar("BARRA_PLASTICA", cantidadAgregar, 1077);
                cantidadAgregar = Stock.VerificarValorPositivo((valor * this.listaValores[2]), 1077, "BARA_HIERRO");
                this.gestorMateriales.Modificar("BARA_HIERRO", cantidadAgregar, 1077);
                cantidadAgregar = Stock.VerificarValorPositivo((valor * this.listaValores[3]), 1077, "ENGRANAJE_HIERRO");
                this.gestorMateriales.Modificar("ENGRANAJE_HIERRO", cantidadAgregar, 1077);

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
            sb.AppendLine($"Codigo de fabricacion: {CodigoFabricacionRam}");

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
            sb.AppendLine($"Producto *- {TipoProducto} -*");
            sb.AppendLine($"Cantidad de productos fabricados -> {CantidadProducto}");

            return sb.ToString();
        }
    }
}
