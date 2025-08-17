using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Getion_de_Pasientes_de_Consultorio_Medico.Modelos;

namespace Getion_de_Pasientes_de_Consultorio_Medico.Servicios
{
    public class ServicioUsuario
    {
        private ConexionAccess conexion;

        public ServicioUsuario()
        {
            conexion = new ConexionAccess();
        }

        public Usuario Autenticar(string nombre_Usuario, string clave)
        {
            try
            {
                conexion.AbrirConeccin();
                string query = "SELECT * FROM Usuarios WHERE Nombre = @Nombre AND Clave = @Clave";

                using (OleDbCommand cmd = new OleDbCommand(query, conexion.Obtener())) {
                    cmd.Parameters.AddWithValue("@Nombre", nombre_Usuario);
                    cmd.Parameters.AddWithValue("@Clave", clave);

                    using(OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Clave = reader["Clave"].ToString(),
                                Rol = reader["Rol"].ToString()
                            };
                        }
                    }
                }
            } catch (Exception ex){
                MessageBox.Show("Error al autenticar: " + ex);
                }
            finally {
                conexion.CerrarConexion();
            }

            return null;
        }
    }
}
