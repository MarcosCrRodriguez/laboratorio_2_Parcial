using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class StockDAO
    {
        private static string connectionString;
        private static SqlCommand command;
        private static SqlConnection connection;

        static StockDAO()
        {
            connectionString = @"Data Source=.;Initial Catalog=Factory_IO;Integrated Security=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        /// <summary>
        /// Modificamos datos del Usuario seleccionado
        /// </summary>
        /// <param name="operario">Operario a modificar</param>
        /// <returns>Retorna un true o false para verificar que se modifico el Usuario con EXITO</returns>
        /// <exception cref="DataBasesException">Lanzara la excepcion en caso de que haya un error con la DB</exception>
        public static bool ModificarStock(string material, int cantidadAgregar, int id)
        {
            bool rtn = false;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE STOCK SET {material} = @{material} WHERE ID_STOCK = @ID_STOCK";
                command.Parameters.AddWithValue("@ID_STOCK", id);
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
                command.CommandText = $"SELECT * FROM STOCK WHERE ID_STOCK = @ID_STOCK";
                command.Parameters.AddWithValue("@ID_STOCK", id);

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

        public static List<string> LeerStockPorID(int id)
        {
            List<string> listaStock = null;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM STOCK WHERE ID_STOCK = @ID_STOCK";
                command.Parameters.AddWithValue("@ID_STOCK", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaStock = new List<string>() {
                            reader["CIRCUITO_ELECTRONICO"].ToString(),
                            reader["CIRCUITO_ELECTRONICO_AVANZADO"].ToString(),
                            reader["UNIDAD_PROCESAMIENTO"].ToString(),
                            reader["BARRA_PLASTICA"].ToString(),
                            reader["CABLE_VERDE"].ToString(),
                            reader["CABLE_ROJO"].ToString(),
                            reader["BARA_HIERRO"].ToString(),
                            reader["ENGRANAJE_HIERRO"].ToString(),
                            reader["FIBRAS_VIDRIO"].ToString(),
                            reader["CONDENSADOR"].ToString(),
                            reader["VENTILADOR"].ToString()
                        };
                    }
                }
                return listaStock;
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
