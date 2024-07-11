using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class AccesoDatos
    {
        private static readonly SqlCommand comando;
        private static readonly SqlConnection conexion;

        static AccesoDatos()
        {
            conexion = new SqlConnection("Server=.;Database=20240701-SP;Trusted_Connection=True;");
            comando = new SqlCommand { Connection = conexion };
        }

        public static List<Serie> ObtenerBacklog()
        {
            var series = new List<Serie>();

            try
            {
                conexion.Open();
                comando.CommandText = "SELECT nombre, genero FROM series";

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var serie = new Serie
                        {
                            Nombre = reader["nombre"].ToString(),
                            Genero = reader["genero"].ToString()
                        };
                        series.Add(serie);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw new BacklogException("Error al obtener el backlog de series.", ex);
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return series;
        }

        public static void ActualizarSerie(Serie item)
        {
            using (SqlConnection connection = new SqlConnection("Server=.;Database=20240701-SP;Trusted_Connection=True;"))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                try
                {
                    connection.Open();

                    command.CommandText = "UPDATE series SET alumno = @alumno WHERE nombre = @nombre AND genero = @genero";
                    command.Parameters.AddWithValue("@nombre", item.Nombre);
                    command.Parameters.AddWithValue("@genero", item.Genero);
                    command.Parameters.AddWithValue("@alumno", "nombre_del_alumno");

                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new BacklogException("Error al actualizar la serie en la base de datos.", ex);
                }
            }
        }

    }
}
