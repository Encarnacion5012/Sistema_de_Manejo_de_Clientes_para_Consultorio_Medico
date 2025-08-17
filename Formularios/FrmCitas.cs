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
    public partial class FrmCitas : Form
    {
        public FrmCitas()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnGuardarCitas_Click(object sender, EventArgs e)
        {
            var cita = new ModeloCita
            {
                idPaciente = (int)cmbIdPacienteCitas.SelectedValue,
                idMedico = (int)cmbIdMedicoCitas.SelectedValue,
                Motivo = txtMotivoCitas.Text.Trim(),
                EstadoCita = cmbEstadoCita.Text,
                FechaHora = dptFechaHoraCita.Value
            };

            ServicioCitas.Insertar(cita);
        
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
        }

        private void btnEditarCitas_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdCitas.Text, out int id))
            {
                var cita = new ModeloCita
                {
                    id= id,
                    idPaciente = (int)cmbIdPacienteCitas.SelectedValue,
                    idMedico = (int)cmbIdMedicoCitas.SelectedValue,
                    Motivo = txtMotivoCitas.Text.Trim(),
                    EstadoCita = cmbEstadoCita.Text,
                    FechaHora = dptFechaHoraCita.Value
                };

                ServicioCitas.Editar(cita);
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido para editar");
            }
        }

        private void btnBuscarCitas_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdCitas.Text, out int id))
            {
                var cita = ServicioCitas.BuscarPorId(id);

                if (cita != null)
                {
                    cmbIdPacienteCitas.SelectedValue = cita.idPaciente;
                    cmbIdMedicoCitas.SelectedValue = cita.idMedico;
                    txtMotivoCitas.Text = cita.Motivo;
                    cmbEstadoCita.Text = cita.EstadoCita;
                    dptFechaHoraCita.Value = cita.FechaHora;
                }
                else
                {
                    MessageBox.Show("Cita no encontrada");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido para buscar");
            }
        }

        private void btnEliminarCitas_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdCitas.Text, out int id))
            {
                var confirmar = MessageBox.Show(
                    "¿Seguro que desea eliminar esta cita?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmar == DialogResult.Yes)
                {
                    ServicioCitas.Eliminar(id);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido para eliminar");
            }
        }

        private void FrmCitas_Load(object sender, EventArgs e)
        {

            cmbIdPacienteCitas.DataSource = ServicioPacientes.ObtenerTodos();
            cmbIdPacienteCitas.ValueMember = "Id";
            cmbIdPacienteCitas.DisplayMember = "NombreCompleto"; // o el campo que uses

            cmbIdMedicoCitas.DataSource = ServicioMedico.ObtenerTodos();
            cmbIdMedicoCitas.ValueMember = "Id";
            cmbIdMedicoCitas.DisplayMember = "Nombre";

            cmbEstadoCita.Items.AddRange(new string[] { "Pendiente", "Completada", "Cancelada" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarCampos limpiar = new LimpiarCampos();
            limpiar.limpiarCampos(this);
        }
    }
}
