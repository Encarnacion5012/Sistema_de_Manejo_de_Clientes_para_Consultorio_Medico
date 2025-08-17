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
                MessageBox.Show("Bienbenido " + usuario.Nombre + " (" + usuario.Rol + ")");
                FrmCentral form = new FrmCentral(usuario);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Contraña incorrecta");
            }
        }
    }
}
