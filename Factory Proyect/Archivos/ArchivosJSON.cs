using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Archivos
{
    public class ArchivosJSON<T> : IArchivos<T> where T : class
    {
        /// <summary>
        /// Genero un archivo Json
        /// </summary>
        /// <param name="path">Ruta del archivo</param>
        /// <param name="dato">Dato a cargar en el archivo</param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException">No tiene la autorizacion para realizar la tarea</exception>
        /// <exception cref="JsonException">Error del archivo Json</exception>
        /// <exception cref="Exception">Error generico</exception>
        public bool EscribirArchivo(string path, T dato)
        {
            bool rtn = false;

			try
			{
                JsonSerializerOptions opciones = new JsonSerializerOptions 
                { 
                    Converters = { new JsonStringEnumConverter() } 
                };
                opciones.WriteIndented = true;

                string jsonString = JsonSerializer.Serialize(dato, opciones);

                File.WriteAllText(path, jsonString);
                rtn = true;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException("Problemas de permisos", ex);
            }
            catch (JsonException ex)

            {
                throw new JsonException("Ocurrio un problema con la serializacion Json", ex); 
            }
            catch (Exception ex)
			{
                throw new Exception("Error al trabajar con el archivo", ex); 
            }
            return rtn;
        }

        /// <summary>
        /// Lectura de datos del archivo Json
        /// </summary>
        /// <param name="path">Ruta del archivo</param>
        /// <returns>Retorna el contenido del archivo</returns>
        public static T LeerArchivo(string path)
        {
            try
            {
                string objetoJson = File.ReadAllText(path);
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
                };
                jsonSerializerOptions.WriteIndented = true;

                T objetoDeserealizado = JsonSerializer.Deserialize<T>(objetoJson, jsonSerializerOptions);

                return objetoDeserealizado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
