using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Getion_de_Pasientes_de_Consultorio_Medico
{
    public class PruebaAccess
    {
        private string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=consultorio.accdb;";

        public void ProbarConexion()
        {
            try
            {
                using (var conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    MessageBox.Show("¡Conexión exitosa!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
