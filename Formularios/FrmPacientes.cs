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

            var paciente = new ModeloPacientes
            {
                NombreCompleto = txtNombreCompletoPaciente.Text.Trim(),
                Fecha_Nac = dtpFechaNacPaciente.Value,
                Direccion = txtDireccionPaciente.Text.Trim(),
                Telefono = txtTelefonoPaciente.Text.Trim()
            };

            ServicioPacientes.Insertar(paciente);


        }

        private void btnEditarPaciente_Click(object sender, EventArgs e)
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

        private void btnEliminarPaciente_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtIdPaciente.Text);
            ServicioPacientes.Eliminar(id);
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos limpiar = new LimpiarCampos();
            limpiar.limpiarCampos(this);
        }
    }
}
