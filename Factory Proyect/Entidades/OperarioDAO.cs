using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OperarioDAO<T> : IUsuario<T> where T : Operario
    {
        private static string connectionString;
        private static SqlCommand command;
        private static SqlConnection connection;

        static OperarioDAO()
        {
            connectionString = @"Data Source=.;Initial Catalog=Factory_IO;Integrated Security=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        /// <summary>
        /// Guardamos / agregamos un Usuario en la base de datos
        /// </summary>
        /// <param name="usuario">Operario que agregaremos a la DB</param>
        /// <returns>Retorna un true o false para ver si se pudo o no agregar a la DB</returns>
        /// <exception cref="SqlExceptionDuplicateUserDB">Lanzara la excepcion en caso de que el DNI ingresado EXISTA</exception>
        /// <exception cref="DataBasesException">Lanzara la excepcion en caso de que haya un error con la DB</exception>
        public bool GuardarRegistro(T usuario)
        {
            bool rtn = false;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"Insert INTO USUARIOS (DNI, NOMBRE, APELLIDO, EMAIL, EDAD, FECHA_INGRESO, DIRECCION, TELEFONO, CARGO, PASSW) " +
                    $"VALUES (@DNI, @Nombre, @Apellido, @Email, @Edad, @FechaIngreso, @Direccion, @Telefono, @Cargo, @Passw)";
                command.Parameters.AddWithValue("@DNI", usuario.DNI);
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@Edad", usuario.Edad);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@FechaIngreso", usuario.FechaIngreso);
                command.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                command.Parameters.AddWithValue("@Cargo", usuario.Puesto);
                command.Parameters.AddWithValue("@Passw", usuario.Password);
                int rows = command.ExecuteNonQuery();
                rtn = true;
            }
            catch (SqlException ex)
            {
                throw new SqlExceptionDuplicateUserDB("No se pudo cargar el Usuario con un DNI ya existente", ex);
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

        /// <summary>
        /// Leemos y devolvemos un Operario por un ID
        /// </summary>
        /// <param name="id">ID que intentaremos de encontrar en la DB</param>
        /// <returns>Retorna el Operario encontrado por el ID</returns>
        /// <exception cref="DataBasesException">Lanzara la excepcion en caso de que haya un error con la DB</exception>
        public T LeerPorID(int id)
        {
            Operario usuario = null;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM USUARIOS WHERE CODIGO_USUARIO = @CODIGO_USUARIO";
                command.Parameters.AddWithValue("@CODIGO_USUARIO", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario = new Operario(reader["NOMBRE"].ToString(),
                            reader["APELLIDO"].ToString(),
                            Convert.ToInt32(reader["CODIGO_USUARIO"]),
                            reader["CARGO"].ToString(),
                            Convert.ToInt64(reader["DNI"]),
                            reader["EMAIL"].ToString(),
                            Convert.ToInt32(reader["EDAD"]),
                            Convert.ToDateTime(reader["FECHA_INGRESO"]),
                            reader["DIRECCION"].ToString(),
                            reader["TELEFONO"].ToString()
                            );
                    }
                }
                return usuario as T;
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

        /// <summary>
        /// Leemos y devolvemos un Operario por un DNI
        /// </summary>
        /// <param name="dni">DNI que intentaremos de encontrar en la DB</param>
        /// <returns>Retorna el Operario encontrado por el DNI</returns>
        /// <exception cref="DataBasesException">Lanzara la excepcion en caso de que haya un error con la DB</exception>
        public T LeerPorDNI(long dni)
        {
            Operario usuario = null;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM USUARIOS WHERE DNI = @DNI";
                command.Parameters.AddWithValue("@DNI", dni);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario = new Operario(reader["NOMBRE"].ToString(),
                            reader["APELLIDO"].ToString(),
                            Convert.ToInt32(reader["CODIGO_USUARIO"]),
                            reader["CARGO"].ToString(),
                            Convert.ToInt64(reader["DNI"]),
                            reader["EMAIL"].ToString(),
                            Convert.ToInt32(reader["EDAD"]),
                            Convert.ToDateTime(reader["FECHA_INGRESO"]),
                            reader["DIRECCION"].ToString(),
                            reader["TELEFONO"].ToString()
                            );
                    }
                }
                return usuario as T;
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

        /// <summary>
        /// Leemos y devolvemos una Lista de los Operarios (con ciertos datos) que se encuentren en la DB
        /// </summary>
        /// <param name="dato">Cargo del Usuario</param>
        /// <returns>Retorna la Lista</returns>
        /// <exception cref="DataBasesException">Lanzara la excepcion en caso de que haya un error con la DB</exception>
        public static List<Operario> LeerOperarios(string dato)
        {
            List<Operario> personas = new List<Operario>();
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM USUARIOS WHERE CARGO = @Cargo";
                command.Parameters.AddWithValue("@Cargo", dato);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personas.Add(new Operario(reader["NOMBRE"].ToString(),
                            reader["APELLIDO"].ToString(),
                            Convert.ToInt32(reader["CODIGO_USUARIO"]),
                            reader["CARGO"].ToString(),
                            Convert.ToInt64(reader["DNI"]))
                            );
                    }
                }
                return personas;
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Hubo problemas con la carga de la lista desde la BD", ex); ;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Leemos y devolvemos una Lista de los Operarios (con todos sus datos) que se encuentren en la DB
        /// </summary>
        /// <param name="dato">Cargo del Usuario</param>
        /// <returns>Retorna la Lista</returns>
        /// <exception cref="DataBasesException">Lanzara la excepcion en caso de que haya un error con la DB</exception>
        public static List<Operario> LeerOperariosDatosCompletos(string dato)
        {
            List<Operario> personas = new List<Operario>();
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM USUARIOS WHERE CARGO = @Cargo";
                command.Parameters.AddWithValue("@Cargo", dato);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personas.Add(new Operario(reader["NOMBRE"].ToString(),
                        reader["APELLIDO"].ToString(),
                        Convert.ToInt32(reader["CODIGO_USUARIO"]),
                        reader["CARGO"].ToString(),
                        Convert.ToInt64(reader["DNI"]),
                        reader["EMAIL"].ToString(),
                        Convert.ToInt32(reader["EDAD"]),
                        Convert.ToDateTime(reader["FECHA_INGRESO"]),
                        reader["DIRECCION"].ToString(),
                        reader["TELEFONO"].ToString()
                        ));
                    }
                }
                return personas;
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Hubo problemas con la carga de la lista desde la BD", ex); ;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
