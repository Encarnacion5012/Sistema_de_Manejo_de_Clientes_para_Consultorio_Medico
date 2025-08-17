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
    public class ServicioCitas
    {
        public static void Insertar(ModeloCita cita)
        {
            ConexionAccess conexionAccess = new ConexionAccess();
            OleDbConnection conexion = conexionAccess.Obtener();

            string query = "INSERT INTO Citas ([Id-Paciente], [Id-Medico], Motivo, Estado, Fecha_Hora) VALUES (?, ?, ?, ?, ?)";
            OleDbCommand comando = new OleDbCommand(query, conexion);

            comando.Parameters.AddWithValue("?", cita.idPaciente);
            comando.Parameters.AddWithValue("?", cita.idMedico);
            comando.Parameters.AddWithValue("?", cita.Motivo);
            comando.Parameters.AddWithValue("?", cita.EstadoCita);
            comando.Parameters.AddWithValue("?", cita.FechaHora);

            try
            {
                conexionAccess.AbrirConeccin();
                comando.ExecuteNonQuery();

                comando.CommandText = "SELECT @@IDENTITY";
                comando.Parameters.Clear();
                int nuevoId = Convert.ToInt32(comando.ExecuteScalar());
                MessageBox.Show("Cita registrada con ID: " + nuevoId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar cita: " + ex.Message);
            }
            finally
            {
                conexionAccess.CerrarConexion();
            }
        }

        public static ModeloCita BuscarPorId(int id)
        {
            ConexionAccess conexionAccess = new ConexionAccess();
            OleDbConnection conexion = conexionAccess.Obtener();

            string query = "SELECT * FROM Citas WHERE Id=?";
            OleDbCommand comando = new OleDbCommand(query, conexion);
            comando.Parameters.AddWithValue("?", id);

            try
            {
                conexionAccess.AbrirConeccin();
                OleDbDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    return new ModeloCita
                    {
                        id = Convert.ToInt32(reader["Id"]),
                        idPaciente = Convert.ToInt32(reader["Id-Paciente"]),
                        idMedico = Convert.ToInt32(reader["Id-Medico"]),
                        Motivo = reader["Motivo"].ToString(),
                        EstadoCita = reader["Estado"].ToString(),
                        FechaHora = Convert.ToDateTime(reader["Fecha_Hora"])
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cita: " + ex.Message);
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

            string query = "DELETE FROM Citas WHERE Id=?";
            OleDbCommand comando = new OleDbCommand(query, conexion);
            comando.Parameters.AddWithValue("?", id);

            try
            {
                conexionAccess.AbrirConeccin();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cita eliminada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar cita: " + ex.Message);
            }
            finally
            {
                conexionAccess.CerrarConexion();
            }
        }

        public static void Editar(ModeloCita cita)
        {
            ConexionAccess conexionAccess = new ConexionAccess();
            OleDbConnection conexion = conexionAccess.Obtener();

            string query = @"UPDATE Citas SET [Id-Paciente]=?, [Id-Medico]=?, Motivo=?, Estado=?, Fecha_Hora=? WHERE Id=?";
            OleDbCommand comando = new OleDbCommand(query, conexion);

            comando.Parameters.AddWithValue("?", cita.idPaciente);
            comando.Parameters.AddWithValue("?", cita.idMedico);
            comando.Parameters.AddWithValue("?", cita.Motivo);
            comando.Parameters.AddWithValue("?", cita.EstadoCita);
            comando.Parameters.AddWithValue("?", cita.FechaHora);
            comando.Parameters.AddWithValue("?", cita.id);

            try
            {
                conexionAccess.AbrirConeccin();
                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                    MessageBox.Show("Cita actualizada correctamente");
                else
                    MessageBox.Show("No se encontró la cita a actualizar");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar cita: " + ex.Message);
            }
            finally
            {
                conexionAccess.CerrarConexion();
            }
        }

    }
}
