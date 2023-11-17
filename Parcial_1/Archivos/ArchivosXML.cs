using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class ArchivosXML<T> : IArchivos<T>
    {
        /// <summary>
        /// Genero un archivo XML
        /// </summary>
        /// <param name="path">Ruta del archivo</param>
        /// <param name="dato">Dato a cargar en el archivo</param>
        /// <returns>Retorna true o flase si pudo o no cargar el archivo</returns>
        /// <exception cref="UnauthorizedAccessException">No tienes permisos para escribir en este directorio</exception>
        /// <exception cref="DirectoryNotFoundException">El directorio especificado no existe</exception>
        /// <exception cref="PathTooLongException">La ruta del archivo es demasiado larga</exception>
        /// <exception cref="IOException">Error de entrada/salida al escribir en el archivo</exception>
        /// <exception cref="XmlException">Error de entrada/salida al escribir en el archivo</exception>
        /// <exception cref="InvalidOperationException">Error en el formato XML</exception>
        /// <exception cref="Exception">Error en la carga del archivo</exception>
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
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException("No tienes permisos para escribir en este directorio", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new DirectoryNotFoundException("El directorio especificado no existe", ex);
            }
            catch (PathTooLongException ex)
            {
                throw new PathTooLongException("La ruta del archivo es demasiado larga", ex);
            }
            catch (IOException ex)
            {
                throw new IOException("Error de entrada/salida al escribir en el archivo", ex);
            }
            catch (XmlException ex)
            {
                throw new XmlException("Error en el formato XML", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Error en el XmlSerializer", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la carga del archivo", ex);
            }
            return rtn;
        }
    }
}