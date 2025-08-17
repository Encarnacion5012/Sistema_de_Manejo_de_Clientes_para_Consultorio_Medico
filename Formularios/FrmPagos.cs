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

            ConfigurarDiseñoPagos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarCampos limpiar = new LimpiarCampos();
            limpiar.limpiarCampos(this);
        }
        private void ConfigurarDiseñoPagos()
        {
            this.Text = "Gestión de Pagos";
            this.BackColor = Color.FromArgb(240, 245, 249);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(850, 550);

            // Contenedor principal con scroll
            var scrollHost = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(12)
            };

            var layoutMain = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 1,
                RowCount = 2,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // === Grupo de Datos del Pago ===
            var grpDatos = new GroupBox
            {
                Text = "Datos del Pago",
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
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // Filas y controles
            string[] etiquetas = { "Paciente:", "Fecha de Pago:", "Monto:", "Método de Pago:" };
            Control[] controles = { cmbIdPacientePagos, dptFechaPago, txtMontoPago, txtMetodoPago };

            for (int i = 0; i < etiquetas.Length; i++)
            {
                tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
                tbl.Controls.Add(new Label { Text = etiquetas[i], AutoSize = true, Anchor = AnchorStyles.Left }, 0, i);

                if (controles[i] != null)
                {
                    controles[i].Dock = DockStyle.Fill;
                    tbl.Controls.Add(controles[i], 1, i);
                }
            }

            grpDatos.Controls.Add(tbl);

            // === Panel de Botones ===
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

            EstilizarBoton(btnRegistrarPago, "Registrar", Color.SeaGreen);
            EstilizarBoton(btnLimpiar, "Limpiar", Color.Gray);

            panelBotones.Controls.AddRange(new Control[] {
        btnRegistrarPago, btnLimpiar
    });

            // Componer layout
            layoutMain.Controls.Add(grpDatos, 0, 0);
            layoutMain.Controls.Add(panelBotones, 0, 1);

            scrollHost.Controls.Add(layoutMain);

            // Reemplazar contenido
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
            btn.Width = 130;
            btn.Height = 40;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Margin = new Padding(6);

            btn.MouseEnter += (s, e) => ((Button)s).BackColor = ControlPaint.Light(color);
            btn.MouseLeave += (s, e) => ((Button)s).BackColor = color;
        }
    }
}
