using System.Text;

namespace Entidades
{
    public static class Stock
    {
        private static int cantCircuitoElect = 2850;
        private static int cantCircuitoElectAvanzado = 2550;
        private static int cantUnidadProcesamiento = 2200;
        private static int cantBarraPlastico = 3700;
        private static int cantCableVerde = 2500;
        private static int cantCableRojo = 2500;
        private static int cantBaraHierro = 3600;
        private static int cantEngranajeHierro = 3600;
        private static int cantFibrasVidrio = 2850;
        private static int cantCondensador = 2250;
        private static int cantVentilador = 2000;

        public static int CantCircuitosElectronicos
        {
            get { return cantCircuitoElect; }
            set 
            {
                if (value > 0)
                {
                    cantCircuitoElect += value;
                }
                else
                {
                    cantCircuitoElect += value;
                }
            }
        }

        public static int CantCircuitosElectronicosAvanzados
        {
            get { return cantCircuitoElectAvanzado; }
            set 
            { 
                if (value > 0)
                {
                    cantCircuitoElectAvanzado += value;
                }
                else
                {
                    cantCircuitoElectAvanzado += value;
                }
            }
        }

        public static int CantUnidadProcesamiento
        {
            get { return cantUnidadProcesamiento; }
            set 
            {
                if (value > 0)
                {
                    cantUnidadProcesamiento += value;
                }
                else
                {
                    cantUnidadProcesamiento += value;
                }
            }
        }
        public static int CantBarraPlastico
        {
            get { return cantBarraPlastico; }
            set 
            {
                if (value > 0)
                {
                    cantBarraPlastico += value;
                }
                else
                {
                    cantBarraPlastico += value;
                }
            }
        }

        public static int CantCableVerde
        {
            get { return cantCableVerde; }
            set 
            {
                if (value > 0)
                {
                    cantCableVerde += value;
                }
                else
                {
                    cantCableVerde += value;
                }
            }
        }

        public static int CantCableRojo
        {
            get { return cantCableRojo; }
            set 
            {
                if (value > 0)
                {
                    cantCableRojo += value;
                }
                else
                {
                    cantCableRojo += value;
                }
            }
        }
        public static int CantBaraHierro
        {
            get { return cantBaraHierro; }
            set 
            {
                if (value > 0)
                {
                    cantBaraHierro += value;
                }
                else
                {
                    cantBaraHierro += value;
                }
            }
        }

        public static int CantEngranajeHierro
        {
            get { return cantEngranajeHierro; }
            set 
            {
                if (value > 0)
                {
                    cantEngranajeHierro += value;
                }
                else
                {
                    cantEngranajeHierro += value;
                }
            }
        }

        public static int CantFibrasVidrio
        {
            get { return cantFibrasVidrio; }
            set 
            {
                if (value > 0)
                {
                    cantFibrasVidrio += value;
                }
                else
                {
                    cantFibrasVidrio += value;
                }
            }
        }
        public static int CantCondensador
        {
            get { return cantCondensador; }
            set 
            {
                if (value > 0)
                {
                    cantCondensador += value;
                }
                else
                {
                    cantCondensador += value;
                }
            }
        }

        public static int CantVentilador
        {
            get { return cantVentilador; }
            set 
            {
                if (value > 0)
                {
                    cantVentilador += value;
                }
                else
                {
                    cantVentilador += value;
                }
            }
        }

        /// <summary>
        /// Construimos un StringBuilder con los materiales y cantidades que faltan para producir
        /// la cantidad pedida
        /// </summary>
        /// <param name="listaValores">Lista de valores a restar para la produccion</param>
        /// <param name="dictProducto">Diccionario que contiene el tipo d materiales y sus cantidades disponibles</param>
        /// <param name="producto">Enumerado pasado a int que nos indica con que producto estamos trabajando</param>
        /// <returns>Retorna una cadena con los materiales y cantidades faltanes</returns>
        public static string ConstruccionStock(List<int> listaValores, Dictionary<string, int> dictProducto, int producto)
        {
            int resto;

            StringBuilder sb = new StringBuilder();
            dictProducto = Stock.ModificarDiccionario(producto);

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
        /// <param name="producto">Enumerado pasado a int que nos indica con que producto estamos trabajando</param>
        /// <returns>Retorna un booleano para verificar de que haya/no haya stock disponible</returns>
        public static bool VerificarStock(List<int> listaValores, Dictionary<string, int> dictProducto, int producto)
        {
            bool retorno = true;

            StringBuilder sb = new StringBuilder();
            dictProducto = Stock.ModificarDiccionario(producto);

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
                        { "Ventilador" ,Stock.CantVentilador },
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
                        { "Ventilador" ,Stock.CantVentilador },
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
