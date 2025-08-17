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
    public partial class FrmPagos : Form
    {
        public FrmPagos()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbIdPacientePagos.SelectedIndex < 0 || cmbIdPacientePagos.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un paciente.");
                    return;
                }

                if (!int.TryParse(cmbIdPacientePagos.SelectedValue.ToString(), out int idPaciente) || idPaciente <= 0)
                {
                    MessageBox.Show("El paciente seleccionado no tiene un ID válido.");
                    return;
                }

                if (!decimal.TryParse(txtMontoPago.Text, out decimal monto))
                {
                    MessageBox.Show("Ingrese un monto válido, por ejemplo: 1500.50");
                    return;
                }

                var pago = new ModeloPagos
                {
                    idPacien = idPaciente,
                    FechaPago = dptFechaPago.Value,
                    Monto = monto,
                    MetodoPago = txtMetodoPago.Text?.Trim() ?? string.Empty
                };

                ServicioPago.Insertar(pago);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el pago: " + ex.Message);
            }
        }

        private void FrmPagos_Load(object sender, EventArgs e)
        {
            cmbIdPacientePagos.DataSource = ServicioPacientes.ObtenerTodos();
            cmbIdPacientePagos.ValueMember = "Id";
            cmbIdPacientePagos.DisplayMember = "NombreCompleto";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarCampos limpiar = new LimpiarCampos();
            limpiar.limpiarCampos(this);
        }
    }
}
