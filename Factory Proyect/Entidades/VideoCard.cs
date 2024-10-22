﻿using ExcepcionesPropias;
using System.Text;

namespace Entidades
{
    public class VideoCard : Producto
    {
        private IMateriales gestorMateriales;

        private int cantUniProcesamientoConsumida;
        private int cantCableVerdeConsumida;
        private int cantBarraPlasticoConsumida;
        private int cantBaraHierroConsumida;
        private int cantEngranajeHierroConsumida;
        private int cantFibrasVidrioConsumida;
        private int cantCondensadorConsumida;
        private int cantVentiladorConsumida;
        private static int contadorProducto = 0;
        private static string? tipoProducto;
        private static ulong codigoFabricacionV;
        private List<int> listaCantidades;
        private List<int> listaValores;

        public VideoCard()
        {
            this.gestorMateriales = new StockDAO();

            this.cantUniProcesamientoConsumida = 4;
            this.cantCableVerdeConsumida = 9;
            this.cantBarraPlasticoConsumida = 4;
            this.cantBaraHierroConsumida = 3;
            this.cantEngranajeHierroConsumida = 9;
            this.cantFibrasVidrioConsumida = 5;
            this.cantCondensadorConsumida = 7;
            this.cantVentiladorConsumida = 2;
            codigoFabricacionV = 82774327;

            TipoProducto = TiposProductos.VideoCard.ToString();
            this.listaValores = new List<int>();
            this.listaCantidades = new List<int> {
                UnidadProcesamientoNecesaria, CableVerdeNecesaria, BarraPlasticoNecesaria,
                BaraHierroNecesaria, EngranajeHierroNecesaria, FibrasVidrioNecesaria,
                CondensadorNecesaria, VentiladorNecesaria
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

        public static ulong CodigoFabricacionVideocard
        {
            get { return codigoFabricacionV; }
            set { codigoFabricacionV = value; }
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

        #endregion

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
            for (int i = 0; i < listaCantidades.Count; i++)
            {
                this[i] = cantidadFdabricar * this.listaCantidades[i];
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
                cantidadAgregar = Stock.VerificarValorPositivo((valor * this.listaValores[0]), 1077, "UNIDAD_PROCESAMIENTO");
                this.gestorMateriales.Modificar("UNIDAD_PROCESAMIENTO", cantidadAgregar, 1077);
                cantidadAgregar = Stock.VerificarValorPositivo((valor * this.listaValores[1]), 1077, "CABLE_VERDE");
                this.gestorMateriales.Modificar("CABLE_VERDE", cantidadAgregar, 1077);
                cantidadAgregar = Stock.VerificarValorPositivo((valor * this.listaValores[2]), 1077, "BARRA_PLASTICA");
                this.gestorMateriales.Modificar("BARRA_PLASTICA", cantidadAgregar, 1077);
                cantidadAgregar = Stock.VerificarValorPositivo((valor * this.listaValores[3]), 1077, "BARA_HIERRO");
                this.gestorMateriales.Modificar("BARA_HIERRO", cantidadAgregar, 1077);
                cantidadAgregar = Stock.VerificarValorPositivo((valor * this.listaValores[4]), 1077, "ENGRANAJE_HIERRO");
                this.gestorMateriales.Modificar("ENGRANAJE_HIERRO", cantidadAgregar, 1077);
                cantidadAgregar = Stock.VerificarValorPositivo((valor * this.listaValores[5]), 1077, "FIBRAS_VIDRIO");
                this.gestorMateriales.Modificar("FIBRAS_VIDRIO", cantidadAgregar, 1077);
                cantidadAgregar = Stock.VerificarValorPositivo((valor * this.listaValores[6]), 1077, "CONDENSADOR");
                this.gestorMateriales.Modificar("CONDENSADOR", cantidadAgregar, 1077);
                cantidadAgregar = Stock.VerificarValorPositivo((valor * this.listaValores[7]), 1077, "VENTILADOR");
                this.gestorMateriales.Modificar("VENTILADOR", cantidadAgregar, 1077);

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
            sb.AppendLine($"Codigo de fabricacion: {CodigoFabricacionVideocard}");

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
            sb.AppendLine($"Producto *- {TipoProducto} -*");
            sb.AppendLine($"Cantidad de productos fabricados -> {CantidadProducto}");

            return sb.ToString();
        }
    }
}
