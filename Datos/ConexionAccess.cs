using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Getion_de_Pasientes_de_Consultorio_Medico
{
    
    public class ConexionAccess
    {
        private OleDbConnection connection;
        
        public ConexionAccess()
        {
            string rutaDB = Path.Combine(Application.StartupPath, "BaseDatos", "consultorio.accdb"); 
            string cadenaConexion = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={rutaDB};Persist Security Info=False;";

            connection = new OleDbConnection(cadenaConexion);
        }

        public void AbrirConeccin()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CerrarConexion()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public OleDbConnection Obtener()
        {
            return connection;
        }
    }
}
