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

        }
    }
    }

