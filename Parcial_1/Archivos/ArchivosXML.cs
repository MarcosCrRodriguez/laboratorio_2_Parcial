using System.Xml.Serialization;

namespace Archivos
{
    public class ArchivosXML<T> : IArchivos<T>
    {
        public bool EscribirArchivo(string path, T dato)
        {
            bool rtn = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(sw, dato);
                }
                rtn = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la carga del archivo", ex);
            }
            return rtn;
        }
    }
}