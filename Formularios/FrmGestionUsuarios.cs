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
    }
}
