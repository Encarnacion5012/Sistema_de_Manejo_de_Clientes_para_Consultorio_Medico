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

            ConfigurarDiseñoDiagnostico();
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
        private void ConfigurarDiseñoDiagnostico()
        {
            this.Text = "Gestión de Diagnósticos Médicos";
            this.BackColor = Color.FromArgb(240, 245, 249);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(900, 600);

            // Contenedor con scroll
            var scrollHost = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(12)
            };

            // Layout principal
            var layoutMain = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 1,
                RowCount = 2,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // === Grupo de datos ===
            var grpDatos = new GroupBox
            {
                Text = "Datos del diagnóstico",
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(12),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.DimGray
            };

            var tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 2,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // Alturas por fila
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // Id
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // Paciente
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // Médico
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 60)); // Síntomas
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 60)); // Diagnóstico
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 60)); // Tratamiento
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // Fecha

            // Ajustar controles existentes
            txtIdDiagnostico.Dock = DockStyle.Fill;
            cmbIdPacienteDiagnostico.Dock = DockStyle.Fill;
            cmdIdMedicoDiagnostico.Dock = DockStyle.Fill;
            txtSintomasDiagnostico.Dock = DockStyle.Fill; txtSintomasDiagnostico.Multiline = true;
            txtDiagnosticoDiag.Dock = DockStyle.Fill; txtDiagnosticoDiag.Multiline = true;
            txtTratamientoDiagnostico.Dock = DockStyle.Fill; txtTratamientoDiagnostico.Multiline = true;
            dptFechaConDiag.Dock = DockStyle.Fill;
            dptFechaConDiag.Format = DateTimePickerFormat.Custom;
            dptFechaConDiag.CustomFormat = "dd/MM/yyyy";

            // Etiquetas
            tbl.Controls.Add(new Label { Text = "Id:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 0);
            tbl.Controls.Add(txtIdDiagnostico, 1, 0);

            tbl.Controls.Add(new Label { Text = "Id-Paciente:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 1);
            tbl.Controls.Add(cmbIdPacienteDiagnostico, 1, 1);

            tbl.Controls.Add(new Label { Text = "Id-Médico:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 2);
            tbl.Controls.Add(cmdIdMedicoDiagnostico, 1, 2);

            tbl.Controls.Add(new Label { Text = "Síntomas:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 3);
            tbl.Controls.Add(txtSintomasDiagnostico, 1, 3);

            tbl.Controls.Add(new Label { Text = "Diagnóstico:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 4);
            tbl.Controls.Add(txtDiagnosticoDiag, 1, 4);

            tbl.Controls.Add(new Label { Text = "Tratamiento:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 5);
            tbl.Controls.Add(txtTratamientoDiagnostico, 1, 5);

            tbl.Controls.Add(new Label { Text = "Fecha de cita:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 6);
            tbl.Controls.Add(dptFechaConDiag, 1, 6);

            grpDatos.Controls.Add(tbl);

            // === Botones ===
            var panelBotones = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(0),
                Margin = new Padding(0, 12, 0, 0)
            };

            EstilizarBoton(btnGuardarDiag, "Guardar", Color.SeaGreen);
            EstilizarBoton(btnBuscarDiagnostico, "Buscar", Color.SteelBlue);
            EstilizarBoton(btnLimpiar, "Limpiar", Color.Gray);

            panelBotones.Controls.AddRange(new Control[] {
        btnGuardarDiag, btnBuscarDiagnostico, btnLimpiar
    });

            // Componer layout
            layoutMain.Controls.Add(grpDatos, 0, 0);
            layoutMain.Controls.Add(panelBotones, 0, 1);

            scrollHost.Controls.Add(layoutMain);

            this.Controls.Clear();
            this.Controls.Add(scrollHost);
        }

        private void EstilizarBoton(Button btn, string texto, Color color)
        {
            btn.Text = texto;
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Width = 120;
            btn.Height = 40;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Margin = new Padding(6);

            btn.MouseEnter += (s, e) => ((Button)s).BackColor = ControlPaint.Light(color);
            btn.MouseLeave += (s, e) => ((Button)s).BackColor = color;
        }

    }
}
