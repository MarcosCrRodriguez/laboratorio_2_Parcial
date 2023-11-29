using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SupervisorDAO<T> : IUsuario<T> where T : Supervisor
    {
        private static string connectionString;
        private static SqlCommand command;
        private static SqlConnection connection;

        static SupervisorDAO()
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
        /// <param name="usuario">Supervisor que agregaremos a la DB</param>
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
        /// Leemos y devolvemos un Supervisor por un ID
        /// </summary>
        /// <param name="id">ID que intentaremos de encontrar en la DB</param>
        /// <returns>Retorna el Supervisor encontrado por ID</returns>
        /// <exception cref="DataBasesException">Lanzara la excepcion en caso de que haya un error con la DB</exception>
        public T LeerPorID(int id)
        {
            Supervisor usuario = null;
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
                        usuario = new Supervisor(Convert.ToInt32(reader["CODIGO_USUARIO"]),
                            reader["CARGO"].ToString(),
                            reader["NOMBRE"].ToString(),
                            reader["APELLIDO"].ToString(),
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
        /// Leemos y devolvemos un Supervisor por un DNI
        /// </summary>
        /// <param name="dni">DNI que intentaremos de encontrar en la DB</param>
        /// <returns>Retorna el Supervisor encontrado por DNI</returns>
        /// <exception cref="DataBasesException">Lanzara la excepcion en caso de que haya un error con la DB</exception>
        public T LeerPorDNI(long dni)
        {
            Supervisor usuario = null;
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
                        usuario = new Supervisor(Convert.ToInt32(reader["CODIGO_USUARIO"]),
                            reader["CARGO"].ToString(),
                            reader["NOMBRE"].ToString(),
                            reader["APELLIDO"].ToString(),
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
        /// Leemos y devolvemos una Lista de los Supervisores (con ciertos datos) que se encuentren en la DB
        /// </summary>
        /// <param name="dato">Cargo del Usuario</param>
        /// <returns>Retorna la Lista</returns>
        /// <exception cref="DataBasesException">Lanzara la excepcion en caso de que haya un error con la DB</exception>
        public static List<Supervisor> LeerSupervisores(string dato)
        {
            List<Supervisor> personas = new List<Supervisor>();
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
                        personas.Add(new Supervisor(Convert.ToInt32(reader["CODIGO_USUARIO"]),
                            reader["CARGO"].ToString(),
                            reader["NOMBRE"].ToString(),
                            reader["APELLIDO"].ToString(),
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
        /// Leemos y devolvemos una Lista de los Supervisores (con ciertos datos) que se encuentren en la DB
        /// </summary>
        /// <param name="dato">Cargo del Usuario</param>
        /// <returns>Retorna la Lista</returns>
        /// <exception cref="DataBasesException">Lanzara la excepcion en caso de que haya un error con la DB</exception>
        public static List<Supervisor> LeerOperariosDatosCompletos(string dato)
        {
            List<Supervisor> personas = new List<Supervisor>();
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
                        personas.Add(new Supervisor(Convert.ToInt32(reader["CODIGO_USUARIO"]),
                        reader["CARGO"].ToString(),
                        reader["NOMBRE"].ToString(),
                        reader["APELLIDO"].ToString(),
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

        /// <summary>
        /// Modificamos datos del Usuario seleccionado
        /// </summary>
        /// <param name="operario">Operario a modificar</param>
        /// <returns>Retorna un true o false para verificar que se modifico el Usuario con EXITO</returns>
        /// <exception cref="DataBasesException">Lanzara la excepcion en caso de que haya un error con la DB</exception>
        public static bool ModificarUsuario(Operario usuario)
        {
            bool rtn = false;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE USUARIOS SET NOMBRE = @Nombre, APELLIDO = @Apellido, EDAD = @Edad, EMAIL = @Email, TELEFONO = @Telefono, DNI = @DNI, FECHA_INGRESO = @FechaIngreso, DIRECCION = @Direccion, CARGO = @Cargo WHERE CODIGO_USUARIO = @CODIGO_USUARIO";
                command.Parameters.AddWithValue("@CODIGO_USUARIO", usuario.ID);
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@Edad", usuario.Edad);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                command.Parameters.AddWithValue("@DNI", usuario.DNI);
                command.Parameters.AddWithValue("@FechaIngreso", usuario.FechaIngreso);
                command.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                command.Parameters.AddWithValue("@Cargo", usuario.Puesto);
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

        /// <summary>
        /// Eliminar un Usuario de la DB a travez de su ID y Cargo
        /// </summary>
        /// <param name="id">ID del Usuario</param>
        /// <param name="dato">Cargo del Usuario</param>
        /// <returns>Retorna un true o false para verificar que se elimino el Usuario con EXITO</returns>
        /// <exception cref="DataBasesException">Lanzara la excepcion en caso de que haya un error con la DB</exception>
        public static bool Eliminar(string dato, int id)
        {
            bool rtn = false;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"DELETE FROM USUARIOS WHERE CODIGO_USUARIO = @CODIGO_USUARIO AND CARGO = @Cargo";
                command.Parameters.AddWithValue("@CODIGO_USUARIO", id);
                command.Parameters.AddWithValue("@Cargo", dato);
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
    }
}
