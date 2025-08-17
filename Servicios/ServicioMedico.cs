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
    public class ServicioMedico
    {
        public static void Insertar(ModeloMedico medico)
        {
            ConexionAccess conexionAccess = new ConexionAccess();
            OleDbConnection conexion = conexionAccess.Obtener();

            string query = "INSERT INTO Medico (Nombre, Apellido, Especialidad, Telefono, Email) VALUES (?, ?, ?, ?, ?)";
            OleDbCommand comando = new OleDbCommand(query, conexion);
            comando.Parameters.AddWithValue("?", medico.Nombre);
            comando.Parameters.AddWithValue("?", medico.Apellido);
            comando.Parameters.AddWithValue("?", medico.Especialidad);
            comando.Parameters.AddWithValue("?", medico.Telefono);
            comando.Parameters.AddWithValue("?", medico.Email);
            try
            {
                conexionAccess.AbrirConeccin();
                comando.ExecuteNonQuery();

                comando.CommandText = "SELECT @@IDENTITY";
                comando.Parameters.Clear();
                int nuevoId = Convert.ToInt32(comando.ExecuteScalar());
                MessageBox.Show("Médico registrado con ID: " + nuevoId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar médico: " + ex.Message);
            }
            finally
            {
                conexionAccess.CerrarConexion();
            }
        }

       

        public static ModeloMedico BuscarPorId(int id)
        {
            ConexionAccess conexionAccess = new ConexionAccess();
            OleDbConnection conexion = conexionAccess.Obtener();

            string query = "SELECT * FROM Medico WHERE Id=?";
            OleDbCommand comando = new OleDbCommand(query, conexion);
            comando.Parameters.AddWithValue("?", id);

            try
            {
                conexionAccess.AbrirConeccin();
                OleDbDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    return new ModeloMedico
                    {
                        id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Especialidad = reader["Especialidad"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar médico: " + ex.Message);
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

            string query = "DELETE FROM Medico WHERE Id=?";
            OleDbCommand comando = new OleDbCommand(query, conexion);
            comando.Parameters.AddWithValue("?", id);

            try
            {
                conexionAccess.AbrirConeccin();
                comando.ExecuteNonQuery();
                MessageBox.Show("Médico eliminado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar médico: " + ex.Message);
            }
            finally
            {
                conexionAccess.CerrarConexion();
            }
        }

        public static List<ModeloMedico> ObtenerTodos()
        {
            var lista = new List<ModeloMedico>();

            ConexionAccess conexionAccess = new ConexionAccess();
            OleDbConnection conexion = conexionAccess.Obtener();

            string query = "SELECT Id, Nombre, Apellido, Especialidad, Telefono, Email FROM Medico";
            OleDbCommand comando = new OleDbCommand(query, conexion);

            try
            {
                conexionAccess.AbrirConeccin(); // mismo nombre que ya usas
                using (OleDbDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var medico = new ModeloMedico
                        {
                            // OJO: usa "id" o "Id" según tu modelo. Aquí muestro ambas opciones:
                            // Id = Convert.ToInt32(reader["Id"]),
                            id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"]?.ToString(),
                            Apellido = reader["Apellido"]?.ToString(),
                            Especialidad = reader["Especialidad"]?.ToString(),
                            Telefono = reader["Telefono"]?.ToString(),
                            Email = reader["Email"]?.ToString()
                        };
                        lista.Add(medico);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener médicos: " + ex.Message);
            }
            finally
            {
                conexionAccess.CerrarConexion();
            }

            return lista;
        }
    }
}