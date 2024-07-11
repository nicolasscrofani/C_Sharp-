using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Logger
    {
        public static void Log(string mensaje)
        {
            string path = @"C:\Users\nicol\OneDrive\Escritorio\log.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {mensaje}");
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, como loggear en otro lugar o lanzar una excepción
                Console.WriteLine($"Error al escribir en el archivo de log: {ex.Message}");
            }
        }
    }

}
