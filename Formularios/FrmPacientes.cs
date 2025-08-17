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

        private void FrmPacientes_Load(object sender, EventArgs e)
        {
            ConfigurarDiseñoPacientes();
        }
        private void ConfigurarDiseñoPacientes()
        {
            this.Text = "Gestión de Pacientes";
            this.BackColor = Color.FromArgb(240, 245, 249);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(850, 550);

            // Contenedor con scroll
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

            // === Grupo Datos del Paciente ===
            var grpDatos = new GroupBox
            {
                Text = "Datos del Paciente",
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
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // Filas y controles
            string[] etiquetas = { "Id:", "Nombre Completo:", "Fecha Nacimiento:", "Dirección:", "Teléfono:" };
            Control[] controles = { TxtIdPaciente, txtNombreCompletoPaciente, dtpFechaNacPaciente, txtDireccionPaciente, txtTelefonoPaciente };

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

            EstilizarBoton(btnGuardarPaciente, "Guardar", Color.SeaGreen);
            EstilizarBoton(btnEditarPaciente, "Editar", Color.DarkOrange);
            EstilizarBoton(btnEliminarPaciente, "Eliminar", Color.Firebrick);
            EstilizarBoton(btnBuscarPaciente, "Buscar", Color.SteelBlue);
            EstilizarBoton(btnLimpiar, "Limpiar", Color.Gray);

            panelBotones.Controls.AddRange(new Control[] {
        btnGuardarPaciente, btnEditarPaciente, btnEliminarPaciente, btnBuscarPaciente, btnLimpiar
    });

            // Composición
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
            btn.Width = 120;
            btn.Height = 40;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Margin = new Padding(6);

            btn.MouseEnter += (s, e) => ((Button)s).BackColor = ControlPaint.Light(color);
            btn.MouseLeave += (s, e) => ((Button)s).BackColor = color;
        }
    }
}
