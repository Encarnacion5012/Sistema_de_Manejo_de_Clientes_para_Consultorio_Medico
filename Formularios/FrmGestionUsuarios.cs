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
    public partial class FrmGestionUsuarios : Form
    {
        public FrmGestionUsuarios()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
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

        private void btnBuscar_Click(object sender, EventArgs e)
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIdGestionUsuarios.Text);
            ServicioUsuario.Eliminar(id);
        }
    }
}
