using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class LogFormat
    {
        public static string CrearFormatoExcepcion(string nombreExcepcion, string stackTrace)
        {
            StringBuilder sb = new StringBuilder();
            DateTime now = DateTime.Now;

            sb.AppendLine($"Nombre de la Excepcion: {nombreExcepcion}");
            sb.AppendLine($"Fecha y hora del Error: {now.ToString("yyyy-MM-dd HH:mm:ss")}");
            sb.AppendLine($"StackTrace:\n{stackTrace.ToString()}");

            return sb.ToString();
        }
    }
}
