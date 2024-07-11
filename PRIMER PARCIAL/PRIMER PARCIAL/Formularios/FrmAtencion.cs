using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Entidades;

namespace Formularios
{
    public partial class FrmAtencion : Form
    {
        public FrmAtencion()
        {
            InitializeComponent();
        }


        private void FrmAtencion_Load(object sender, EventArgs e)
        {
            lstMedicos.Items.Add(new PersonalMedico("Gustavo", "Rivas", new DateTime(1999, 12, 12), false));
            lstMedicos.Items.Add(new PersonalMedico("Lautaro", "Galarza", new DateTime(1951, 11, 12), true));
            lstPacientes.Items.Add(new Paciente("Mathias", "Bustamante", new DateTime(1998, 6, 16), "Tigre"));
            lstPacientes.Items.Add(new Paciente("Lucas", "Ferrini", new DateTime(1989, 1, 21), "DF"));
            lstPacientes.Items.Add(new Paciente("Lucas", "Rodriguez", new DateTime(1912, 12, 12), "LaBoca"));
            lstPacientes.Items.Add(new Paciente("John Jairo", "Trelles", new DateTime(1978, 8, 30), "Medellin"));

            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void FrmAtencion_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }


        private void btnAtender_Click(object sender, EventArgs e)
        {
            if (lstMedicos.SelectedIndex == -1 || lstPacientes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Medico y un Paciente para poder continuar.", "Error en los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            PersonalMedico medicoSeleccionado = lstMedicos.SelectedItem as PersonalMedico;
            Paciente pacienteSeleccionado = lstPacientes.SelectedItem as Paciente;


            Consulta nuevaConsulta = medicoSeleccionado + pacienteSeleccionado;


            pacienteSeleccionado.Diagnostico = "Paciente curado";


            lstMedicos.SelectedIndex = -1;
            lstPacientes.SelectedIndex = -1;


            string mensajeConsulta = $"{nuevaConsulta.Fecha} se ha atendido a {nuevaConsulta.Paciente.NombreCompleto}";
            MessageBox.Show(mensajeConsulta, "Atención finalizada", MessageBoxButtons.OK);


            rtbInfoMedico.Text += "\n" + mensajeConsulta;
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            this.Close();
        }


        private void lstMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMedicos.SelectedItem != null)
            {

                PersonalMedico medicoSeleccionado = lstMedicos.SelectedItem as PersonalMedico;

                if (medicoSeleccionado != null)
                {
                    rtbInfoMedico.Text = medicoSeleccionado.FichaPersonal();
                }
            }
        }


        private void lstPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void rtbInfoMedico_TextChanged(object sender, EventArgs e)
        {

        }
    }
}