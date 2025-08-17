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

namespace Getion_de_Pasientes_de_Consultorio_Medico.Formularios
{
    public partial class FrmCentral : Form
    {
        private Usuario usuarioActual;
        public FrmCentral(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            this.Load += FrmCentral_Load;
        }
        private void FrmCentral_Load(object sender, EventArgs e)
        {
            ConfigurarInterfaz();
            ConfigurarInterfaz();
            ConfigurarDiseño();

        }

        private void ConfigurarInterfaz() 
        {
            if (usuarioActual.Rol == "medico" ) 
            { 
                btnGestinarUsuarios.Visible = false;
                btnGestinarUsuarios.Enabled = false;
                btnReportes.Visible = false;
                btnReportes.Enabled=false;
                btnRegistrarMedicos.Visible = false;
                btnRegistrarMedicos.Enabled=false;
                btnPagos.Enabled = false;
                btnPagos.Visible=false;
                btnPacientes.Enabled=false;
                btnPacientes.Visible=false;
                btnPagos.Visible = false;
                btnPagos.Enabled = false;

            }
            else if (usuarioActual.Rol== "recepcionista") 
            {
                btnGestinarUsuarios.Visible = false;
                btnGestinarUsuarios.Enabled = false;
                btnReportes.Visible = false;
                btnReportes.Enabled = false;
                btnRegistrarMedicos.Visible = false;
                btnRegistrarMedicos.Enabled = false;
                BtnDiagnosticos.Enabled = false;
                BtnDiagnosticos.Visible = false;
                
            }
            else if(usuarioActual.Rol == "admin")
            {

            }
            else
            {
                btnGestinarUsuarios.Visible = false;
                btnGestinarUsuarios.Enabled = false;
                btnReportes.Visible = false;
                btnReportes.Enabled = false;
                btnRegistrarMedicos.Visible = false;
                btnRegistrarMedicos.Enabled = false;
                btnPagos.Enabled = false;
                btnPagos.Visible = false;
                btnPacientes.Enabled = false;
                btnPacientes.Visible = false;
                btnPagos.Visible = false;
                btnPagos.Enabled = false;
                BtnDiagnosticos.Enabled= false;
                BtnDiagnosticos.Visible= false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGestionUsuarios form = new FrmGestionUsuarios();
            form.Show();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            FrmPacientes form = new FrmPacientes();
            form.Show();
        }

        private void btnRegistrarMedicos_Click(object sender, EventArgs e)
        {
            FrmMedico form = new FrmMedico();
            form.Show();
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            FrmCitas form = new FrmCitas ();
            form.Show();
        }

        private void btnCerrar_Secion_Click(object sender, EventArgs e)
        {
            FrmLogin form = new FrmLogin();
            form.Show();
            this.Hide();
        }

        private void BtnDiagnosticos_Click(object sender, EventArgs e)
        {
            FrmDiagnosticoMedico form = new FrmDiagnosticoMedico();
            form.Show();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            FrmPagos form = new FrmPagos();
            form.Show();
        }

        private void ConfigurarDiseño()
        {
            this.BackColor = Color.FromArgb(240, 245, 249);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Text = "Sistema de Gestión Médica";

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 1,
                Padding = new Padding(20),
                BackColor = Color.Transparent
            };

            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 30)); // Gestión
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 40)); // Operaciones
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 20)); // Cerrar Sesión

            // GESTIÓN
            var panelGestion = CrearGrupo("Gestión",
                btnGestinarUsuarios,
                btnReportes,
                btnRegistrarMedicos
            );

            // OPERACIONES (aquí va Citas con los demás)
            var panelOperaciones = CrearGrupo("Operaciones",
                btnCitas,
                BtnDiagnosticos,
                btnPagos,
                btnPacientes
            );

            // CERRAR SESIÓN
            btnCerrar_Secion.BackColor = Color.Firebrick;
            btnCerrar_Secion.ForeColor = Color.White;
            btnCerrar_Secion.FlatStyle = FlatStyle.Flat;
            btnCerrar_Secion.FlatAppearance.BorderSize = 0;
            btnCerrar_Secion.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            var panelCerrar = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(0, 10, 0, 0)
            };
            panelCerrar.Controls.Add(btnCerrar_Secion);

            // Añadir al layout
            layout.Controls.Add(panelGestion, 0, 0);
            layout.Controls.Add(panelOperaciones, 0, 1);
            layout.Controls.Add(panelCerrar, 0, 2);

            this.Controls.Clear();
            this.Controls.Add(layout);
        }

        // Método para crear grupo con botones alineados
        private GroupBox CrearGrupo(string titulo, params Button[] botones)
        {
            var grupo = new GroupBox
            {
                Text = titulo,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.DimGray
            };

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(10),
                WrapContents = true
            };

            foreach (var btn in botones)
            {
                if (btn != null)
                {
                    btn.BackColor = Color.SteelBlue;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Width = 180;
                    btn.Height = 50;
                    btn.Margin = new Padding(8);
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                    btn.MouseEnter += (s, e) => ((Button)s).BackColor = Color.DodgerBlue;
                    btn.MouseLeave += (s, e) => ((Button)s).BackColor = Color.SteelBlue;

                    panel.Controls.Add(btn);
                }
            }

            grupo.Controls.Add(panel);
            return grupo;
        }

    }
}
