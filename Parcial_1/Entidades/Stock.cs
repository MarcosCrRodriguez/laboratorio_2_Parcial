﻿using System.Text;

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
        private static List<string> listaHardcodeada;
        private static Dictionary<string, int> dictValores;

        static Stock()
        {
            cantCircuitoElect = 2850;
            cantCircuitoElectAvanzado = 2550;
            cantUnidadProcesamiento = 2200;
            cantBarraPlastico = 3700;
            cantCableVerde = 2500;
            cantCableRojo = 2500;
            cantBaraHierro = 3600;
            cantEngranajeHierro = 3600;
            cantFibrasVidrio = 2850;
            cantCondensador = 2250;
            cantVentilador = 2000;
            dictValores = new Dictionary<string, int>();
            listaHardcodeada = new List<string>();
    }

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

        public static List<int> InstanciarListaStock()
        {
            listaStock = new List<int>() {
                CantCircuitosElectronicos,
                CantCircuitosElectronicosAvanzados,
                CantUnidadProcesamiento,
                CantBarraPlastico,
                CantCableVerde,
                CantCableRojo,
                CantBaraHierro,
                CantEngranajeHierro,
                CantFibrasVidrio,
                CantCondensador,
                CantVentilador
            };

            return listaStock;
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

            StringBuilder sb = new StringBuilder();

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

        public static void ActualizarStock(List<int> listaValores)
        {
            Stock.CantCircuitosElectronicos += listaValores[0];
            Stock.CantCircuitosElectronicosAvanzados += listaValores[1];
            Stock.CantUnidadProcesamiento += listaValores[2];
            Stock.CantCableVerde += listaValores[3];
            Stock.CantCableRojo += listaValores[4];
            Stock.CantBarraPlastico += listaValores[5];
            Stock.CantBaraHierro += listaValores[6];
            Stock.CantEngranajeHierro += listaValores[7];
            Stock.CantFibrasVidrio += listaValores[8];
            Stock.CantCondensador += listaValores[9];
            Stock.CantVentilador += listaValores[10];
        }

        //public static Dictionary<string, int> DiccionarioDelStock()
        //{
        //    Dictionary<string, int> dictStock;

        //    dictStock = new Dictionary<string, int>() {
        //        { "Circuitos Electronicos" ,Stock.CantCircuitosElectronicos },
        //        { "Circuitos Electronicos Avanzados" ,Stock.CantCircuitosElectronicosAvanzados },
        //        { "Unidad Procesamiento" ,Stock.CantUnidadProcesamiento },
        //        { "Cable Verde" ,Stock.CantCableVerde },
        //        { "Cable Rojo" ,Stock.CantCableRojo },
        //        { "Barra Plastico" ,Stock.CantBarraPlastico },
        //        { "Bara Hierro" ,Stock.CantBaraHierro },
        //        { "Engranaje Hierro" ,Stock.CantEngranajeHierro },
        //        { "Fibras Vidrio" ,Stock.CantFibrasVidrio },
        //        { "Condensador" ,Stock.CantCondensador },
        //        { "Ventilador" ,Stock.CantVentilador }
        //    };

        //    return dictStock;
        //}
        
        //public static List<string> ListaHarcodeadaStock()
        //{
        //    listaHardcodeada.Add("Circuitos Electronicos");
        //    listaHardcodeada.Add("Circuitos Electronicos Avanzados");
        //    listaHardcodeada.Add("Unidad Procesamiento");
        //    listaHardcodeada.Add("Cable Verde");
        //    listaHardcodeada.Add("Cable Rojo");
        //    listaHardcodeada.Add("Barra Plastico");
        //    listaHardcodeada.Add("Bara Hierro");
        //    listaHardcodeada.Add("Engranaje Hierro");
        //    listaHardcodeada.Add("Fibras Vidrio");
        //    listaHardcodeada.Add("Condensador");
        //    listaHardcodeada.Add("Ventilador");

        //    return listaHardcodeada;
        //}
    }
}
