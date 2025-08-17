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

namespace Getion_de_Pasientes_de_Consultorio_Medico.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSecion_Click(object sender, EventArgs e)
        {
            string nombre = txtUsuario.Text.Trim();
            string clave = TxtClave.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Por favor complete todos los campos");
                return;
            }
            ServicioUsuario servicio = new ServicioUsuario();
            Usuario usuario = servicio.Autenticar(nombre, clave);

            if (usuario!= null)
            {
                MessageBox.Show("Bienvenido " + usuario.Nombre + " (" + usuario.Rol + ")");
                FrmCentral form = new FrmCentral(usuario);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Contraña incorrecta");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            ConfigurarDiseñoLogin();
        }
        private void ConfigurarDiseñoLogin()
        {
            this.Text = "Iniciar sesión";
            this.BackColor = Color.FromArgb(240, 245, 249);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Título
            var lblTitulo = new Label
            {
                Text = "Inicio de sesión",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.DimGray,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(0, 20, 0, 20)
            };

            // Panel central
            var panelCentral = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 3,
                Padding = new Padding(20),
            };

            panelCentral.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            panelCentral.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            panelCentral.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            panelCentral.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            panelCentral.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

            // Usuario
            var lblUsuario = new Label
            {
                Text = "Usuario:",
                Anchor = AnchorStyles.Left,
                AutoSize = true
            };
            txtUsuario = new TextBox
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right
            };

            // Contraseña
            var lblClave = new Label
            {
                Text = "Contraseña:",
                Anchor = AnchorStyles.Left,
                AutoSize = true
            };
            TxtClave = new TextBox
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                UseSystemPasswordChar = true
            };

            // Botón
            btnIniciarSecion = new Button
            {
                Text = "Iniciar sesión",
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 120,
                Height = 35
            };
            btnIniciarSecion.FlatAppearance.BorderSize = 0;
            btnIniciarSecion.Click += btnIniciarSecion_Click;

            // Agregar al panel
            panelCentral.Controls.Add(lblUsuario, 0, 0);
            panelCentral.Controls.Add(txtUsuario, 1, 0);
            panelCentral.Controls.Add(lblClave, 0, 1);
            panelCentral.Controls.Add(TxtClave, 1, 1);
            panelCentral.Controls.Add(btnIniciarSecion, 1, 2);

            // Layout principal
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            layout.Controls.Add(lblTitulo, 0, 0);
            layout.Controls.Add(panelCentral, 0, 1);

            this.Controls.Clear();
            this.Controls.Add(layout);

            // Enter para enviar
            this.AcceptButton = btnIniciarSecion;
        }
    }
}
