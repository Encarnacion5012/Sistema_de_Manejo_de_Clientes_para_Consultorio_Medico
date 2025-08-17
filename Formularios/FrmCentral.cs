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
    }
}
