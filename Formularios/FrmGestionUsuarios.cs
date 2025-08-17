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
    public partial class FrmGestionUsuarios : Form
    {
        public FrmGestionUsuarios()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombresGesUsuarios.Text))
                {
                    MessageBox.Show("El nombre es obligatorio");
                    return;
                }

                var usuario = new Usuario
                {
                    Nombre = txtNombresGesUsuarios.Text.Trim(),
                    Clave = txtClaveGesUs.Text.Trim(),
                    Rol = txtRolGesUs.Text.Trim()
                };
                ServicioUsuario.Insertar(usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar Usuario: " + ex);
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdGestionUsuarios.Text))
            {
                MessageBox.Show("El id es obligatorio");
                return;
            }
            try { 
            Usuario usuario = new Usuario
            {
                Id = int.Parse(txtIdGestionUsuarios.Text),
                Nombre = txtNombresGesUsuarios.Text.Trim(),
                Clave = txtClaveGesUs.Text.Trim(),
                Rol = txtRolGesUs.Text.Trim()
            };

            ServicioUsuario.actualizar(usuario);
            MessageBox.Show("Usuario actualizado correctamente.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al Actualizar Usuaro: " + ex);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdGestionUsuarios.Text))
            {
                MessageBox.Show("El id es obligatorio");
                return;
            }
            try
            {

                int id = int.Parse(txtIdGestionUsuarios.Text);
                ServicioUsuario.BuscarPorId(id);

                Usuario usuario = ServicioUsuario.BuscarPorId(id);

                if (usuario != null)
                {
                    txtNombresGesUsuarios.Text = usuario.Nombre;
                    txtClaveGesUs.Text = usuario.Clave;
                    txtRolGesUs.Text = usuario.Rol;
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Buscar Usuaro: " + ex);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdGestionUsuarios.Text))
            {
                MessageBox.Show("El id es obligatorio");
                return;
            }
            try
            {
                int id = int.Parse(txtIdGestionUsuarios.Text);
                ServicioUsuario.Eliminar(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar Usuaro: " + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarCampos limpiar = new LimpiarCampos();
            limpiar.limpiarCampos(this);
        }

        private void FrmGestionUsuarios_Load(object sender, EventArgs e)
        {
            ConfigurarDiseñoUsuarios();
        }
        private void ConfigurarDiseñoUsuarios()
        {
            this.Text = "Gestión de Usuarios";
            this.BackColor = Color.FromArgb(240, 245, 249);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 500);

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
                Text = "Datos del usuario",
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

            // Filas
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // Id
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // Nombre
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // Clave
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // Rol

            // Ajustar controles existentes
            txtIdGestionUsuarios.Dock = DockStyle.Fill;
            txtNombresGesUsuarios.Dock = DockStyle.Fill;
            txtClaveGesUs.Dock = DockStyle.Fill;
            txtRolGesUs.Dock = DockStyle.Fill;

            // Etiquetas + Controles
            tbl.Controls.Add(new Label { Text = "Id:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 0);
            tbl.Controls.Add(txtIdGestionUsuarios, 1, 0);

            tbl.Controls.Add(new Label { Text = "Nombre:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 1);
            tbl.Controls.Add(txtNombresGesUsuarios, 1, 1);

            tbl.Controls.Add(new Label { Text = "Clave:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 2);
            tbl.Controls.Add(txtClaveGesUs, 1, 2);

            tbl.Controls.Add(new Label { Text = "Rol:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 3);
            tbl.Controls.Add(txtRolGesUs, 1, 3);

            grpDatos.Controls.Add(tbl);

            // === Panel de botones ===
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

            EstilizarBoton(btnGuardar, "Guardar", Color.SeaGreen);
            EstilizarBoton(btnActualizar, "Actualizar", Color.DarkOrange);
            EstilizarBoton(btnBuscar, "Buscar", Color.SteelBlue);
            EstilizarBoton(btnEliminar, "Eliminar", Color.Firebrick);
            EstilizarBoton(button1, "Limpiar", Color.Gray);

            panelBotones.Controls.AddRange(new Control[] {
        btnGuardar, btnActualizar, btnBuscar, btnEliminar, button1
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
