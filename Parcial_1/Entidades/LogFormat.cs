using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class LogFormat
    {
        /// <summary>
        /// Ingreso datos y los devuelvo con un formato
        /// </summary>
        /// <param name="nombreExcepcion">Nonmbre de un error</param>
        /// <param name="stackTrace">Track del error</param>
        /// <returns>Retorna un conjunto de datos con un formato</returns>
        public static string CrearFormatoExcepcion(string nombreExcepcion, string stackTrace)
        {
            StringBuilder sb = new StringBuilder();
            DateTime now = DateTime.Now;

            sb.AppendLine($"Nombre de la Excepcion: {nombreExcepcion}");
            sb.AppendLine($"Fecha y hora del Error: {now.ToString("yyyy-MM-dd HH:mm:ss")}");
            sb.AppendLine($"StackTrace:\n{stackTrace.ToString()}");

            return sb.ToString();
        }

        /// <summary>
        /// Ingreso datos y los devuelvo con un formato
        /// </summary>
        /// <param name="nombreProceso">Nombre del proceso</param>
        /// <param name="código">Codigo del proceso</param>
        /// <returns>Retorna un conjunto de datos con un formato</returns>
        public static string CrearFormatoDB(string nombreProceso, string código)
        {
            StringBuilder sb = new StringBuilder();
            DateTime now = DateTime.Now;

            sb.AppendLine($"Nombre del proceso: {nombreProceso}");
            sb.AppendLine($"Fecha y hora del Error: {now.ToString("yyyy-MM-dd HH:mm:ss")}");
            sb.AppendLine($"Código: [{código}]");

            return sb.ToString();
        }
    }
}
