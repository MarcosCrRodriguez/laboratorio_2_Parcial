using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Archivos
{
    public static class ArchivosTXT<T>
    {
        public static bool EscribirArchivo(string path, T dato)
        {
            bool rtn = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(dato);
                    sw.Close();
                }
                rtn =  true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la carga del archivo", ex);
            }
            return rtn;
        }

        public static string CrearFormatoExcepcion(string nombreExcepcion, string stackTrace)
        {
            StringBuilder sb = new StringBuilder();
            DateTime now = DateTime.Now;

            sb.AppendLine($"Nombre de la Excepcion: {nombreExcepcion}");
            sb.AppendLine($"Fecha y hora del Error: {now.ToString("yyyy-MM-dd HH:mm:ss")}");
            sb.AppendLine($"StackTrace:\n{stackTrace.ToString()}");

            return sb.ToString();
        }

        public static void CargarExcepcionEnArchivo(string path, string nombreExcepcion, string stackTrace)
        {
            string pathTXT = "Log_Excepciones.txt";
            if (Directory.Exists(path))
            {
                //EscribirTXT
                if (!(ArchivosTXT<string>.EscribirArchivo(path + pathTXT, ArchivosTXT<string>.CrearFormatoExcepcion(nombreExcepcion, stackTrace))))
                {
                    throw new Exception("Error inesperado");
                }
            }
        }
    }
}
