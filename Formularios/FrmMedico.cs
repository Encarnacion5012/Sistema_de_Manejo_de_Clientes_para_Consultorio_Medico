using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Getion_de_Pasientes_de_Consultorio_Medico.Servicios;
using Getion_de_Pasientes_de_Consultorio_Medico.Modelos;
using Getion_de_Pasientes_de_Consultorio_Medico.Utilidades;

namespace Getion_de_Pasientes_de_Consultorio_Medico.Formularios
{
    public partial class FrmMedico : Form
    {
        public FrmMedico()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombreMedico.Text == null)
            {
                MessageBox.Show("El nombre es obligatorio");
            }
            try
            {
                ModeloMedico medico = new ModeloMedico
                {
                    Nombre = txtNombreMedico.Text,
                    Apellido = txtApellidoMedico.Text,
                    Especialidad = txtEspecialidadMedico.Text,
                    Telefono = txtTelefonoMedico.Text,
                    Email = txtEmailMedico.Text
                };
                ServicioMedico.Insertar(medico);
            }
            catch (Exception ex) {
                MessageBox.Show("Error al registar Medico: " + ex);
            }
        }
            

        private void btnEliminarMedico_Click(object sender, EventArgs e)
        {
            if (txtIdMedico.Text == null)
            {
                MessageBox.Show("El Id es obligatorio");
            }
            try
            {

                int id = int.Parse(txtIdMedico.Text);
                ServicioMedico.Eliminar(id);
            }
            catch (Exception ex) {
                MessageBox.Show("Error al eliminar Medico: " + ex);
            }
            }

        private void btnBuscarMedico_Click(object sender, EventArgs e)
        {
            if (txtIdMedico.Text == null)
            {
                 MessageBox.Show("El Id es obligatorio");
            }
            try { 
            int id = int.Parse(txtIdMedico.Text);
            ModeloMedico medico = ServicioMedico.BuscarPorId(id);

            if (medico != null)
            {
                txtNombreMedico.Text = medico.Nombre;
                txtApellidoMedico.Text = medico.Apellido;
                txtEspecialidadMedico.Text = medico.Especialidad;
                txtTelefonoMedico.Text = medico.Telefono;
                txtEmailMedico.Text = medico.Email;
            }
            else
            {
                MessageBox.Show("Médico no encontrado");
            }
            }
            catch (Exception ex) {
                MessageBox.Show("Error al eliminar Cliente: " + ex);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos limpiar = new LimpiarCampos();
            limpiar.limpiarCampos(this);
        }

        private void FrmMedico_Load(object sender, EventArgs e)
        {
            ConfigurarDiseñoMedico();
        }
        private void ConfigurarDiseñoMedico()
        {
            this.Text = "Gestión de Médicos";
            this.BackColor = Color.FromArgb(240, 245, 249);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(850, 550);

            // Panel con scroll
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

            // === Grupo Datos del Médico ===
            var grpDatos = new GroupBox
            {
                Text = "Datos del Médico",
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
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // Filas para cada campo
            string[] etiquetas = { "Id:", "Nombre:", "Apellido:", "Especialidad:", "Teléfono:", "Email:" };
            Control[] controles = { txtIdMedico, txtNombreMedico, txtApellidoMedico, txtEspecialidadMedico, txtTelefonoMedico, txtEmailMedico };

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

            EstilizarBoton(btnGuardadMedico, "Guardar", Color.SeaGreen);
            EstilizarBoton(btnEliminarMedico, "Eliminar", Color.Firebrick);
            EstilizarBoton(btnBuscarMedico, "Buscar", Color.SteelBlue);
            EstilizarBoton(btnLimpiar, "Limpiar", Color.Gray);

            panelBotones.Controls.AddRange(new Control[] {
        btnGuardadMedico, btnEliminarMedico, btnBuscarMedico, btnLimpiar
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
            btn.Width = 120;
            btn.Height = 40;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Margin = new Padding(6);

            btn.MouseEnter += (s, e) => ((Button)s).BackColor = ControlPaint.Light(color);
            btn.MouseLeave += (s, e) => ((Button)s).BackColor = color;
        }
    }
    }

