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
    public static class SupervisorDAO
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

        public static bool GuardarRegistro(Supervisor operario)
        {
            //store prosegure investigar
            bool rtn = false;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"Insert INTO USUARIOS (DNI, NOMBRE, APELLIDO, EMAIL, EDAD, FECHA_INGRESO, DIRECCION, TELEFONO, CARGO, PASSW) " +
                    $"VALUES (@DNI, @Nombre, @Apellido, @Email, @Edad, @FechaIngreso, @Direccion, @Telefono, @Cargo, @Passw)";
                command.Parameters.AddWithValue("@DNI", operario.DNI);
                command.Parameters.AddWithValue("@Nombre", operario.Nombre);
                command.Parameters.AddWithValue("@Apellido", operario.Apellido);
                command.Parameters.AddWithValue("@Edad", operario.Edad);
                command.Parameters.AddWithValue("@Email", operario.Email);
                command.Parameters.AddWithValue("@FechaIngreso", operario.FechaIngreso);
                command.Parameters.AddWithValue("@Direccion", operario.Direccion);
                command.Parameters.AddWithValue("@Telefono", operario.Telefono);
                command.Parameters.AddWithValue("@Cargo", operario.Puesto);
                command.Parameters.AddWithValue("@Passw", operario.Password);
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

        public static Supervisor LeerPorID(int id)
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
                        usuario = new Supervisor(reader["NOMBRE"].ToString(),
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
                return usuario;
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

        public static Supervisor LeerPorDNI(long dni)
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
                        usuario = new Supervisor(reader["NOMBRE"].ToString(),
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
                return usuario;
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
                        personas.Add(new Supervisor(reader["NOMBRE"].ToString(),
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

        public static bool Modificar(Operario operario)
        {
            bool rtn = false;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE USUARIOS SET NOMBRE = @Nombre, APELLIDO = @Apellido, EDAD = @Edad, EMAIL = @Email, TELEFONO = @Telefono, DNI = @DNI, FECHA_INGRESO = @FechaIngreso, DIRECCION = @Direccion, CARGO = @Cargo WHERE CODIGO_USUARIO = @CODIGO_USUARIO";
                command.Parameters.AddWithValue("@CODIGO_USUARIO", operario.ID);
                command.Parameters.AddWithValue("@Nombre", operario.Nombre);
                command.Parameters.AddWithValue("@Apellido", operario.Apellido);
                command.Parameters.AddWithValue("@Edad", operario.Edad);
                command.Parameters.AddWithValue("@Email", operario.Email);
                command.Parameters.AddWithValue("@Telefono", operario.Telefono);
                command.Parameters.AddWithValue("@DNI", operario.DNI);
                command.Parameters.AddWithValue("@FechaIngreso", operario.FechaIngreso);
                command.Parameters.AddWithValue("@Direccion", operario.Direccion);
                command.Parameters.AddWithValue("@Cargo", operario.Puesto);
                int rows = command.ExecuteNonQuery();
                rtn = true;
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

        public static bool Eliminar(int id, string dato)
        {
            bool rtn = false;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"DELETE FROM USUARIOS WHERE CODIGO_USUARIO = @CODIGO_USUARIO AND CARGO = @Cargo";
                command.Parameters.AddWithValue("@CODIGO_USUARIO", id);
                command.Parameters.AddWithValue("@Cargo", dato);
                int rows = command.ExecuteNonQuery();
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
