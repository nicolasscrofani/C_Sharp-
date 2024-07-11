using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoBacklog(Serie serie);

    public class ManejadorBacklog
    {
        public event DelegadoBacklog serieParaVer;

        public void IniciarManejador(List<Serie> backLog, List<Serie> seriesParaVer)
        {
            Task.Run(() =>
            {
                MoverSeries(backLog, seriesParaVer);
            });
        }

        private void MoverSeries(List<Serie> backLog, List<Serie> seriesParaVer)
        {
            Random random = new Random();

            while (backLog.Count > 0)
            {
                
                int indiceRandom = random.Next(0, backLog.Count);
                Serie serie = backLog[indiceRandom];

              
                System.Threading.Thread.Sleep(1500);

                AccesoDatos.ActualizarSerie(serie);

                seriesParaVer.Add(serie);

                
                serieParaVer?.Invoke(serie);

               
                backLog.RemoveAt(indiceRandom);
            }
        }
    }



}
