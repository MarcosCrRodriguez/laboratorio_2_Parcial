using ExcepcionesPropias;
using System.Runtime.CompilerServices;
using System.Text;

namespace Entidades
{
    public static class Stock
    {
        private static int cantCircuitoElect;
        private static int cantCircuitoElectAvanzado;
        private static int cantUnidadProcesamiento;
        private static int cantBarraPlastico;
        private static int cantCableVerde;
        private static int cantCableRojo;
        private static int cantBaraHierro;
        private static int cantEngranajeHierro;
        private static int cantFibrasVidrio;
        private static int cantCondensador;
        private static int cantVentilador;
        private static List<int> listaStock;
        private static List<string> listaMateriales;

        static Stock()
        {
            listaStock = new List<int>();
            listaMateriales = new List<string>();
        }

        #region Propiedades
        public static int CantCircuitosElectronicos
        {
            get { return cantCircuitoElect; }
            set 
            {
                cantCircuitoElect = value;

                if (cantCircuitoElect < 0)
                {
                    cantCircuitoElect = 0;
                }
            }
        }

        public static int CantCircuitosElectronicosAvanzados
        {
            get { return cantCircuitoElectAvanzado; }
            set 
            {
                cantCircuitoElectAvanzado = value;

                if (cantCircuitoElectAvanzado < 0)
                {
                    cantCircuitoElectAvanzado = 0;
                }
            }
        }

        public static int CantUnidadProcesamiento
        {
            get { return cantUnidadProcesamiento; }
            set 
            {
                cantUnidadProcesamiento = value;

                if (cantUnidadProcesamiento < 0)
                {
                    cantUnidadProcesamiento = 0;
                }
            }
        }
        
        public static int CantBarraPlastico
        {
            get { return cantBarraPlastico; }
            set 
            {
                cantBarraPlastico = value;

                if (cantBarraPlastico < 0)
                {
                    cantBarraPlastico = 0;
                }
            }
        }

        public static int CantCableVerde
        {
            get { return cantCableVerde; }
            set 
            {
                cantCableVerde = value;

                if (cantCableVerde < 0)
                {
                    cantCableVerde = 0;
                }
            }
        }

        public static int CantCableRojo
        {
            get { return cantCableRojo; }
            set 
            {
                cantCableRojo = value;

                if (cantCableRojo < 0)
                {
                    cantCableRojo = 0;
                }
            }
        }
        
        public static int CantBaraHierro
        {
            get { return cantBaraHierro; }
            set 
            {
                cantBaraHierro = value;

                if (cantBaraHierro < 0)
                {
                    cantBaraHierro = 0;
                }
            }
        }

        public static int CantEngranajeHierro
        {
            get { return cantEngranajeHierro; }
            set 
            {
                cantEngranajeHierro = value;

                if (cantEngranajeHierro < 0)
                {
                    cantEngranajeHierro = 0;
                }
            }
        }

        public static int CantFibrasVidrio
        {
            get { return cantFibrasVidrio; }
            set 
            {
                cantFibrasVidrio = value;

                if (cantFibrasVidrio < 0)
                {
                    cantFibrasVidrio = 0;
                }
            }
        }
        
        public static int CantCondensador
        {
            get { return cantCondensador; }
            set 
            {
                cantCondensador = value;

                if (cantCondensador < 0)
                {
                    cantCondensador = 0;
                }
            }
        }

        public static int CantVentilador
        {
            get { return cantVentilador; }
            set 
            {
                cantVentilador = value;

                if (cantVentilador < 0)
                {
                    cantVentilador = 0;
                }
            }
        }
        #endregion

        public static int VerificarValorPositivo(int cantidadAgregar, int id, string material)
        {
            int rtn = -1;
            int cantidadStock;

            try
            {
                cantidadStock = StockDAO.LeerPorMaterial(id, material);
                if (cantidadStock != -1)
                {
                    cantidadAgregar += cantidadStock;
                    if (cantidadAgregar >= 0)
                    {
                        rtn = cantidadAgregar;
                    }
                    else
                    {
                        throw new NegativeValueException("El valor en Stock no puede ser menor que 0 - [NegativeValueException]");
                    }
                }
                else
                {
                    throw new NegativeValueException("El valor en Stock no puede ser menor que 0 - [NegativeValueException]");
                }
            }
            catch (FormatException ex)
            {
                throw new FormatException("Error con el formato de la cantidad ingresada", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error inesperado", ex);
            }
            return rtn;
        }

        /// <summary>
        /// Casteo de dato de decimal a entero
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Retorno el dato casteado</returns>
        public static int CasteoExplicito(decimal dato)
        {
            int valor = 0;

            if (dato > -1)
            {
                valor = (int)dato;
            }
            return valor;
        }

        public static int CasteoExplicito(string dato)
        {
            try
            {
                int numero = int.Parse(dato);
                return numero;
            }
            catch (FormatException)
            {
                throw new FormatException("No se pudo convertir el valor. Error de Formato");
            }
            catch (OverflowException)
            {
                throw new OverflowException("El valor está fuera del rango para el tipo de dato");
            }
        }

        /// <summary>
        /// Casteo Explicito de una Lista de decimal a entero
        /// </summary>
        /// <param name="listaDecimal"></param>
        /// <returns>Retornamos la lista casteada</returns>
        public static List<int> CasteoExplicitoLista(List<decimal> listaDecimal)
        {
            List<int> listaInt = new List<int>();

            if (listaDecimal != null && listaDecimal.Count > 0)
            {
                for (int i = 0; i < listaDecimal.Count; i++)
                {
                    listaInt.Add((int)listaDecimal[i]);
                }
            }

            return listaInt;
        }

        public static List<string> InstanciarListaMateriales()
        {
            listaMateriales = new List<string>() {
                "CIRCUITO_ELECTRONICO",
                "CIRCUITO_ELECTRONICO_AVANZADO",
                "UNIDAD_PROCESAMIENTO",
                "BARRA_PLASTICA",
                "CABLE_VERDE",
                "CABLE_ROJO",
                "BARA_HIERRO",
                "ENGRANAJE_HIERRO",
                "FIBRAS_VIDRIO",
                "CONDENSADOR",
                "VENTILADOR"
            };

            return listaMateriales;
        }

        public static List<string> InstanciarListaFormateada()
        {
            List<string> listaStockDB = StockDAO.LeerStockPorID(1077);
            listaMateriales = InstanciarListaMateriales();

            List<string> listaFormat = new List<string>();
            int i = 0;

            foreach (var item in listaStockDB)
            {
                listaFormat.Add($"{listaMateriales[i]}: {listaStockDB[i]}");
                i++;
            }

            return listaFormat;
        }

        /// <summary>
        /// Construimos un StringBuilder con los materiales y cantidades que faltan para producir
        /// la cantidad pedida
        /// </summary>
        /// <param name="listaValores">Lista de valores a restar para la produccion</param>
        /// <param name="dictProducto">Diccionario que contiene el tipo d materiales y sus cantidades disponibles</param>
        /// <returns>Retorna una cadena con los materiales y cantidades faltanes</returns>
        public static string StockFaltante(List<int> listaValores, Dictionary<string, int> dictProducto)
        {
            int resto;

            StringBuilder sb = new StringBuilder();

            int i = 0;

            foreach (KeyValuePair<string, int> item in dictProducto)
            {
                if (item.Value < listaValores[i])
                {
                    resto = listaValores[i] - item.Value;
                    sb.AppendLine($"Falta {resto} de {item.Key}");
                }
                i++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Verificaremos que con el producto con el que estamos trabajando tengamos stock de los
        /// materiales pedidos para producir el producto final
        /// </summary>
        /// <param name="listaValores">Lista de valores a restar para la produccion</param>
        /// <param name="dictProducto">Diccionario que contiene el tipo d materiales y sus cantidades disponibles</param>
        /// <returns>Retorna un booleano para verificar de que haya/no haya stock disponible</returns>
        public static bool VerificarStock(List<int> listaValores, Dictionary<string, int> dictProducto)
        {
            bool retorno = true;

            int i = 0;

            foreach (KeyValuePair<string, int> item in dictProducto)
            {
                if (item.Value < listaValores[i])
                {
                    retorno = false;
                    break;
                }
                i++;
            }

            return retorno;
        }

        /// <summary>
        /// Dependiendo con que producto estemos trabajando modificaremos/actualizaremos los datos del diccionario 
        /// </summary>
        /// <param name="producto">Enumerado pasado a int que nos indica con que producto estamos trabajando</param>
        /// <returns>Retornamos el diccionario actualizado para poder tranajar con el</returns>
        public static Dictionary<string, int> ModificarDiccionario(int producto)
        {
            Dictionary<string, int> dictProducto;

            switch (producto)
            {
                case 0:
                    dictProducto = new Dictionary<string, int>() {
                        { "Unidad Procesamiento" ,Stock.CantUnidadProcesamiento },
                        { "Cable Verde" ,Stock.CantCableVerde },
                        { "Barra Plastico" ,Stock.CantBarraPlastico },
                        { "Bara Hierro" ,Stock.CantBaraHierro },
                        { "Engranaje Hierro" ,Stock.CantEngranajeHierro },
                        { "Fibras Vidrio" ,Stock.CantFibrasVidrio },
                        { "Condensador" ,Stock.CantCondensador },
                        { "Ventilador" ,Stock.CantVentilador }
                        };
                    break;
                case 1:
                    dictProducto = new Dictionary<string, int>() {
                        { "Circuitos Electronicos Avanzados" ,Stock.CantCircuitosElectronicosAvanzados },
                        { "Cable Rojo" ,Stock.CantCableRojo },
                        { "Barra Plastico" ,Stock.CantBarraPlastico },
                        { "Bara Hierro" ,Stock.CantBaraHierro },
                        { "Engranaje Hierro" ,Stock.CantEngranajeHierro },
                        { "Fibras Vidrio" ,Stock.CantFibrasVidrio },
                        { "Condensador" ,Stock.CantCondensador },
                        { "Ventilador" ,Stock.CantVentilador }
                        };
                    break;
                case 2:
                    dictProducto = new Dictionary<string, int>() {
                        { "Circuitos Electronicos" ,Stock.CantCircuitosElectronicos },
                        { "Barra Plastico" ,Stock.CantBarraPlastico },
                        { "Bara Hierro" ,Stock.CantBaraHierro },
                        { "Engranaje Hierro" ,Stock.CantEngranajeHierro }
                        };
                    break;
                case 3:
                    dictProducto = new Dictionary<string, int>() {
                        { "Cable Rojo" ,Stock.CantCableRojo },
                        { "Barra Plastico" ,Stock.CantBarraPlastico },
                        { "Bara Hierro" ,Stock.CantBaraHierro },
                        { "Engranaje Hierro" ,Stock.CantEngranajeHierro },
                        { "Ventilador" ,Stock.CantVentilador }
                        };
                    break;
                default:
                    dictProducto = new Dictionary<string, int>();
                    break;
            }

            return dictProducto;
        }
    }
}
