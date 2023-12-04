using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductosDAO : IMateriales
    {
        private static string connectionString;
        private static SqlCommand command;
        private static SqlConnection connection;

        static ProductosDAO()
        {
            connectionString = @"Data Source=.;Initial Catalog=Factory_IO;Integrated Security=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        /// <summary>
        /// Modificamos la cantidad de cierto Producto fabricado 
        /// </summary>
        /// <param name="material">Producto a modificar</param>
        /// <param name="cantidadAgregar">Cantidad a agregar</param>
        /// <param name="id">ID de Productos</param>
        /// <returns>Retorna un true o false para verificar que se modifico el Producto con EXITO</returns>
        /// <exception cref="DataBasesException">Lanzara la excepcion en caso de que haya un error con la DB</exception> 
        public bool Modificar(string material, int cantidadAgregar, int id)
        {
            bool rtn = false;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE PRODUCTOS SET {material} = @{material} WHERE ID_PRODUCTOS = @ID_PRODUCTOS";
                command.Parameters.AddWithValue("@ID_PRODUCTOS", id);
                command.Parameters.AddWithValue($"@{material}", cantidadAgregar);
                if (command.ExecuteNonQuery() == 1)
                {
                    rtn = true;
                }
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Error a la hora de trabajar con la DB", ex);
            }
            finally
            {
                connection.Close();
            }
            return rtn;
        }

        /// <summary>
        /// Lectura de un material especifico de la DB
        /// </summary>
        /// <param name="id">ID de Productos</param>
        /// <param name="material">Material a leer</param>
        /// <returns>Retorna la cantidad que hay en el material ingresado</returns>
        /// <exception cref="DataBasesException">Error con la base de datos</exception>
        public int LeerPorMaterial(int id, string material)
        {
            int cantidad = -1;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM PRODUCTOS WHERE ID_PRODUCTOS = @ID_PRODUCTOS";
                command.Parameters.AddWithValue("@ID_PRODUCTOS", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cantidad = Convert.ToInt32(reader[$"{material}"]);
                    }
                }
                return cantidad;
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Error a la hora de trabajar con la DB", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<string> LeerProductosPorID(int id)
        {
            List<string> listaProductos = null;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM PRODUCTOS WHERE ID_PRODUCTOS = @ID_PRODUCTOS";
                command.Parameters.AddWithValue("@ID_PRODUCTOS", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaProductos = new List<string>() {
                            reader["VIDEO_CARD"].ToString(),
                            reader["MOTHERBOARD"].ToString(),
                            reader["RAM"].ToString(),
                            reader["CABINET"].ToString()
                        };
                    }
                }
                return listaProductos;
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Error a la hora de trabajar con la DB", ex);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
