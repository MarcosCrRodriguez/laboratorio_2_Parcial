using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class OperarioDAO
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

        public static bool GuardarRegistro(Operario operario)
        {
            bool rtn = false; ;
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
            catch (SqlException ex)
            {
                throw new SqlExceptionDuplicateUserDB("No se pudo cargar el Usuario con un DNI ya existente", ex);
            }
            catch (Exception ex)
            {
                throw new DataBasesException("No se pudo cargar el Usuario con un DNI ya existente", ex);
            }
            finally
            {
                connection.Close();
            }
            return rtn;
        }
        public static Operario LeerPorID(int id)
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
                throw new DataBasesException("Error a la hora de trabajar con Base de Datos", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public static Operario LeerPorDNI(long dni)
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
                throw new DataBasesException("Error a la hora de trabajar con Base de Datos", ex);
            }
            finally
            {
                connection.Close();
            }
        }

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
                        Convert.ToDateTime(reader["FECHA_NACIMIENTO"]),
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
