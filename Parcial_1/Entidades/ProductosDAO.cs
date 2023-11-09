using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductosDAO
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
        public static bool Modificar(string material, int cantidadAgregar, int id)
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
                throw new DataBasesException("Error a la hora de trabajar con Base de Datos", ex);
            }
            finally
            {
                connection.Close();
            }
            return rtn;
        }

        public static int LeerPorMaterial(int id, string material)
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
                throw new DataBasesException("Error a la hora de trabajar con Base de Datos", ex);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
