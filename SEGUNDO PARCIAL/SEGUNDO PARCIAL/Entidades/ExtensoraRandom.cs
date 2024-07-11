using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtensoraRandom
    {
        private static readonly Random random = new Random();

        public static int GenerarRandom(this List<Serie> lista)
        {
            return random.Next(0, lista.Count);
        }
    }
}
