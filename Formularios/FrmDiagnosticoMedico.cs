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
    public partial class FrmDiagnosticoMedico : Form
    {
        public FrmDiagnosticoMedico()
        {
            InitializeComponent();
        }

        private void btnGuardarDiag_Click(object sender, EventArgs e)
        {
            try
            {
                var diagnostico = new ModeloDiagnostico
                {
                    idPaciente = Convert.ToInt32(cmbIdPacienteDiagnostico.SelectedValue),
                    idMedico = Convert.ToInt32(cmdIdMedicoDiagnostico.SelectedValue),
                    Sintomas = txtSintomasDiagnostico.Text,
                    Diagnostico = txtDiagnosticoDiag.Text,
                    Tratamiento = txtTratamientoDiagnostico.Text,
                    FechaCita = dptFechaConDiag.Value // DateTimePicker
                };

                ServicioDiagnostico.Insertar(diagnostico);

                MessageBox.Show("Diagnóstico guardado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        } 

        private void FrmDiagnosticoMedico_Load(object sender, EventArgs e)
        {
            cmbIdPacienteDiagnostico.DataSource = ServicioPacientes.ObtenerTodos();
            cmbIdPacienteDiagnostico.ValueMember = "Id";
            cmbIdPacienteDiagnostico.DisplayMember = "NombreCompleto"; // o tu campo visible

            // Médicos
            cmdIdMedicoDiagnostico.DataSource = ServicioMedico.ObtenerTodos();
            cmdIdMedicoDiagnostico.ValueMember = "Id";
            cmdIdMedicoDiagnostico.DisplayMember = "Nombre";
        }

        private void btnGuardarDiagnostico_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(txtIdDiagnostico.Text))
                {
                    MessageBox.Show("Ingrese el ID del diagnóstico a buscar");
                    return;
                }

                int idBuscar = Convert.ToInt32(txtIdDiagnostico.Text);
                var diag = ServicioDiagnostico.BuscarPorId(idBuscar);

                if (diag != null)
                {
                    // Asigno el valor al ComboBox esto hace que muestre el nombre automáticamente
                    cmbIdPacienteDiagnostico.SelectedValue = diag.idPaciente;
                    cmdIdMedicoDiagnostico.SelectedValue = diag.idMedico;

                    txtSintomasDiagnostico.Text = diag.Sintomas;
                    txtDiagnosticoDiag.Text = diag.Diagnostico;
                    txtTratamientoDiagnostico.Text = diag.Tratamiento;
                    dptFechaConDiag.Value = diag.FechaCita;
                }
                else
                {
                    MessageBox.Show("No se encontró el diagnóstico");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos limpiar = new LimpiarCampos();
            limpiar.limpiarCampos(this);
        }
    }
}
