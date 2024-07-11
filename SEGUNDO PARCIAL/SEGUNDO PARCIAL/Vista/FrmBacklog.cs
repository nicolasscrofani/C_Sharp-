using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Entidades;

namespace Vista
{
    public partial class FrmBacklog : Form
    {
        private List<Serie> backLog;
        private List<Serie> seriesParaVer;
        private Serializadora serializadora;
        private ManejadorBacklog manejador;

        public FrmBacklog()
        {
            InitializeComponent();

            backLog = AccesoDatos.ObtenerBacklog();
            seriesParaVer = new List<Serie>();
            serializadora = new Serializadora();
            manejador = new ManejadorBacklog();

            manejador.serieParaVer += CambiarEstadoSerie;

            lstbBacklog.DataSource = backLog;
            lstbParaVer.DataSource = seriesParaVer;

            manejador.IniciarManejador(backLog, seriesParaVer);
        }

        private void FrmBacklog_Load(object sender, EventArgs e)
        {
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rutaJson = Path.Combine(rutaEscritorio, "SeriesParaVer.json");
            string rutaXml = Path.Combine(rutaEscritorio, "Backlog.xml");

            try
            {
                serializadora.Guardar(backLog, rutaXml);
                ((IGuardar<List<Serie>>)serializadora).Guardar(seriesParaVer, rutaJson);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }

        private void CambiarEstadoSerie(Serie serie)
        {
            ActualizarListBox(lstbBacklog, backLog);
            ActualizarListBox(lstbParaVer, seriesParaVer);
        }

        private void ActualizarListBox(ListBox lb, List<Serie> series)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new Action(() => ActualizarListBox(lb, series)));
            }
            else
            {
                lb.DataSource = null;
                lb.DataSource = series;
            }
        }
    }


}
