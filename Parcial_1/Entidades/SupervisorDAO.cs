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
            bool rtn = false;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"Insert INTO USUARIOS (DNI, NOMBRE, APELLIDO, EMAIL, EDAD, FECHA_NACIMIENTO, DIRECCION, TELEFONO, CARGO, PASSW) " +
                    $"VALUES (@DNI, @Nombre, @Apellido, @Email, @Edad, @FechaNacimiento, @Direccion, @Telefono, @Cargo, @Passw)";
                command.Parameters.AddWithValue("@DNI", operario.DNI);
                command.Parameters.AddWithValue("@Nombre", operario.Nombre);
                command.Parameters.AddWithValue("@Apellido", operario.Apellido);
                command.Parameters.AddWithValue("@Edad", operario.Edad);
                command.Parameters.AddWithValue("@Email", operario.Email);
                command.Parameters.AddWithValue("@FechaNacimiento", operario.FechaNacimiento);
                command.Parameters.AddWithValue("@Direccion", operario.Direccion);
                command.Parameters.AddWithValue("@Telefono", operario.Telefono);
                command.Parameters.AddWithValue("@Cargo", operario.Puesto);
                command.Parameters.AddWithValue("@Passw", operario.Password);
                int rows = command.ExecuteNonQuery();
                rtn = true;
            }
            catch (Exception ex)
            {
                throw new SqlExceptionDuplicateUserDB("No se pudo cargar el Usuario con un DNI ya existente", ex);
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
                            Convert.ToDateTime(reader["FECHA_NACIMIENTO"]),
                            reader["DIRECCION"].ToString(),
                            reader["TELEFONO"].ToString()
                            );
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw;
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
                            Convert.ToDateTime(reader["FECHA_NACIMIENTO"]),
                            reader["DIRECCION"].ToString(),
                            reader["TELEFONO"].ToString()
                            );
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw;
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
            catch (IndexOutOfRangeException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        // le voy a pasar un Operario y asi podre modificarle todos los datos que desee
        public static bool Modificar(string nuevoNombre, int id)
        {
            bool rtn = false;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE USUARIOS SET Nombre = @Nombre WHERE CODIGO_USUARIO = @CODIGO_USUARIO";
                command.Parameters.AddWithValue("@Nombre", nuevoNombre);
                command.Parameters.AddWithValue("@CODIGO_USUARIO", id);
                int rows = command.ExecuteNonQuery();
                rtn = true;
            }
            catch (Exception)
            {

                throw;
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
                rtn = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
            return rtn;
        }
    }
}
