using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Getion_de_Pasientes_de_Consultorio_Medico;

namespace Getion_de_Pasientes_de_Consultorio_Medico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConexionAccess conexion = new ConexionAccess();
            try
            {
                conexion.AbrirConeccin();
                MessageBox.Show("Conexion exitosa");
            }
            catch (Exception ex) {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }

            finally
            {
                conexion.CerrarConexion();
            }
        }

        
    }
}
