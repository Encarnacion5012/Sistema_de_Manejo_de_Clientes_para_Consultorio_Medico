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
    public class ServicioPacientes
    {
        public static void Insertar(ModeloPacientes paciente)
        {
            ConexionAccess conexcionAccess = new ConexionAccess();
            OleDbConnection conexion = conexcionAccess.Obtener();

            string query = "INSERT INTO Paciente (Nombre_Completo, Fecha_nac, Direccion, Telefono) VALUES (?, ?, ?, ?)";
            OleDbCommand comando = new OleDbCommand(query, conexion);
            comando.Parameters.AddWithValue("?", paciente.NombreCompleto);
            comando.Parameters.AddWithValue("?", paciente.Fecha_Nac);
            comando.Parameters.AddWithValue("?", paciente.Direccion);
            comando.Parameters.AddWithValue("?", paciente.Telefono);

            try
            {
                conexcionAccess.AbrirConeccin();
                comando.ExecuteNonQuery();
                comando.CommandText = "SELECT @@IDENTITY";
                comando.Parameters.Clear();
                int nuevoId = Convert.ToInt32(comando.ExecuteScalar());
                MessageBox.Show("Paciente registrado con ID: " + nuevoId);
            }
            catch (Exception ex) {
                MessageBox.Show("Error al registrar paciente: " + ex);
            }
            finally
            {
                conexcionAccess.CerrarConexion();
            }

        }

        public static void actualizar(ModeloPacientes paciente) {
            ConexionAccess conexcionAccess = new ConexionAccess();
            OleDbConnection conexion = conexcionAccess.Obtener();
            string query = "UPDATE Paciente SET Nombre_Completo=?, Fecha_nac=?, Direccion=?, Telefono=? WHERE Id=?";
            OleDbCommand comando = new OleDbCommand(query, conexion);
            comando.Parameters.AddWithValue("?", paciente.NombreCompleto);
            comando.Parameters.AddWithValue("?", paciente.Fecha_Nac);
            comando.Parameters.AddWithValue("?", paciente.Direccion);
            comando.Parameters.AddWithValue("?", paciente.Telefono);
            comando.Parameters.AddWithValue("?", paciente.Id);
            try
            {
                conexcionAccess.AbrirConeccin();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar paciente: " + ex.Message);
            }
            finally
            {
                conexcionAccess.CerrarConexion();
            }
        }

        public static ModeloPacientes BuscarPorId(int id)
        {
            ConexionAccess conexionAccess = new ConexionAccess();
            OleDbConnection conexion = conexionAccess.Obtener();
            string query = "SELECT * FROM Paciente WHERE Id=?";
            OleDbCommand comando = new OleDbCommand(query, conexion);
            comando.Parameters.AddWithValue("?", id);
            try
            {
                conexionAccess.AbrirConeccin();
                OleDbDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    return new ModeloPacientes
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        NombreCompleto = reader["Nombre_Completo"].ToString(),
                        Fecha_Nac = Convert.ToDateTime(reader["Fecha_nac"]),
                        Direccion = reader["Direccion"].ToString(),
                        Telefono = reader["Telefono"].ToString()
                    };

                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error al buscar el paciente: " + ex);
            }
            finally
            {
                conexionAccess.CerrarConexion();
            }
            return null;
    }

        public static void Eliminar(int id) 
        {
            ConexionAccess conexionAccess = new ConexionAccess();
            OleDbConnection conexion = conexionAccess.Obtener();
            string query = "DELETE FROM Paciente WHERE Id=?";
            OleDbCommand comando = new OleDbCommand(query, conexion);
            comando.Parameters.AddWithValue("?", id);

            try
            {
                conexionAccess.AbrirConeccin();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar paciente: " + ex.Message);
            }
            finally
            {
                conexionAccess.CerrarConexion();
            }
        }
        public static List<ModeloPacientes> ObtenerTodos()
        {
            var lista = new List<ModeloPacientes>();

            ConexionAccess conexionAccess = new ConexionAccess();
            OleDbConnection conexion = conexionAccess.Obtener();

            // Ajusta los nombres de columnas EXACTAMENTE como están en tu tabla Paciente
            string query = "SELECT Id, Nombre_Completo, Fecha_nac, Direccion, Telefono FROM Paciente";
            OleDbCommand comando = new OleDbCommand(query, conexion);

            try
            {
                conexionAccess.AbrirConeccin();
                using (OleDbDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var paciente = new ModeloPacientes
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            NombreCompleto = reader["Nombre_Completo"]?.ToString(),
                            Fecha_Nac = Convert.ToDateTime(reader["Fecha_nac"]),
                            Direccion = reader["Direccion"]?.ToString(),
                            Telefono = reader["Telefono"]?.ToString()
                        };
                        lista.Add(paciente);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener pacientes: " + ex.Message);
            }
            finally
            {
                conexionAccess.CerrarConexion();
            }

            return lista;
        }

    } 
}
