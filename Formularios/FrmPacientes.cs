using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Getion_de_Pasientes_de_Consultorio_Medico.Modelos;
using Getion_de_Pasientes_de_Consultorio_Medico.Servicios;
using Getion_de_Pasientes_de_Consultorio_Medico.Utilidades;

namespace Getion_de_Pasientes_de_Consultorio_Medico.Formularios
{
    public partial class FrmPacientes : Form
    {
        public FrmPacientes()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarPaciente_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNombreCompletoPaciente.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return;
            }

            try
            {

                var paciente = new ModeloPacientes
                {
                    NombreCompleto = txtNombreCompletoPaciente.Text.Trim(),
                    Fecha_Nac = dtpFechaNacPaciente.Value,
                    Direccion = txtDireccionPaciente.Text.Trim(),
                    Telefono = txtTelefonoPaciente.Text.Trim()
                };

                ServicioPacientes.Insertar(paciente);
            }
            catch (Exception ex) {
                MessageBox.Show("Errror al registrar paciente: " + ex);
            }


        }

        private void btnEditarPaciente_Click(object sender, EventArgs e)
        {
            if (TxtIdPaciente.Text == null)
            {
              MessageBox.Show("El di es oblicatorio");
                
            }
            try
            {
                ModeloPacientes paciente = new ModeloPacientes
                {
                    Id = int.Parse(TxtIdPaciente.Text),
                    NombreCompleto = txtNombreCompletoPaciente.Text,
                    Fecha_Nac = dtpFechaNacPaciente.Value,
                    Direccion = txtDireccionPaciente.Text,
                    Telefono = txtTelefonoPaciente.Text
                };

                // Llamamos al método actualizar
                ServicioPacientes.actualizar(paciente);

                // Mensaje de confirmación
                MessageBox.Show("Paciente actualizado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errror al Editar paciente: " + ex);
            }
        }

        private void btnEliminarPaciente_Click(object sender, EventArgs e)
        {
            if (TxtIdPaciente.Text == null)
            {
                MessageBox.Show("El di es oblicatorio");
            }
            try
            {
                int id = int.Parse(TxtIdPaciente.Text);
                ServicioPacientes.Eliminar(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errror al Editar paciente: " + ex);
            }

        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            if (TxtIdPaciente.Text == null)
            {
                MessageBox.Show("El di es oblicatorio");
            }
            try
            {
                int id = int.Parse(TxtIdPaciente.Text);
                ModeloPacientes paciente = ServicioPacientes.BuscarPorId(id);

                if (paciente != null)
                {
                    txtNombreCompletoPaciente.Text = paciente.NombreCompleto;
                    dtpFechaNacPaciente.Value = paciente.Fecha_Nac;
                    txtDireccionPaciente.Text = paciente.Direccion;
                    txtTelefonoPaciente.Text = paciente.Telefono;
                }
                else
                {
                    MessageBox.Show("Paciente no encontrado");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Errror al Buscar paciente: " + ex);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos limpiar = new LimpiarCampos();
            limpiar.limpiarCampos(this);
        }
    }
}
