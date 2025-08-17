using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using Getion_de_Pasientes_de_Consultorio_Medico.Modelos;

namespace Getion_de_Pasientes_de_Consultorio_Medico.Servicios
{
    public class ServicioDiagnostico
    {
        public static void Insertar(ModeloDiagnostico d)
        {
            var conexionAccess = new ConexionAccess();
            var conexion = conexionAccess.Obtener();

            string sql = "INSERT INTO Diagnosticos ([id-Paciente], [id-Medico], Sintomas, Diagnostico, Tratamiento, Fecha_Consulta) " +
                         "VALUES (?, ?, ?, ?, ?, ?)";

            using (var cmd = new OleDbCommand(sql, conexion))
            {
                // El orden debe coincidir con los ? del SQL
                cmd.Parameters.Add("idPaciente", OleDbType.Integer).Value = d.idPaciente;
                cmd.Parameters.Add("idMedico", OleDbType.Integer).Value = d.idMedico;
                // Sintomas es Memo/Long Text en Access
                cmd.Parameters.Add("Sintomas", OleDbType.LongVarWChar).Value = d.Sintomas ?? string.Empty;
                cmd.Parameters.Add("Diagnostico", OleDbType.VarWChar).Value = d.Diagnostico ?? string.Empty;
                cmd.Parameters.Add("Tratamiento", OleDbType.VarWChar).Value = d.Tratamiento ?? string.Empty;
                cmd.Parameters.Add("Fecha_Consulta", OleDbType.Date).Value = d.FechaCita;

                try
                {
                    conexionAccess.AbrirConeccin();
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT @@IDENTITY";
                    cmd.Parameters.Clear();
                    int nuevoId = Convert.ToInt32(cmd.ExecuteScalar());
                    MessageBox.Show("Diagnóstico registrado con ID: " + nuevoId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar diagnóstico: " + ex.Message);
                }
                finally
                {
                    conexionAccess.CerrarConexion();
                }
            }
        }

        public static ModeloDiagnostico BuscarPorId(int id)
        {
            var conexionAccess = new ConexionAccess();
            var conexion = conexionAccess.Obtener();

            string sql = "SELECT * FROM Diagnosticos WHERE Id=?";
            using (var cmd = new OleDbCommand(sql, conexion))
            {
                cmd.Parameters.Add("Id", OleDbType.Integer).Value = id;

                try
                {
                    conexionAccess.AbrirConeccin();
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            return new ModeloDiagnostico
                            {
                                id = Convert.ToInt32(r["Id"]),
                                idPaciente = Convert.ToInt32(r["id-Paciente"]),
                                idMedico = Convert.ToInt32(r["id-Medico"]),
                                Sintomas = r["Sintomas"]?.ToString(),
                                Diagnostico = r["Diagnostico"]?.ToString(),
                                Tratamiento = r["Tratamiento"]?.ToString(),
                                FechaCita = Convert.ToDateTime(r["Fecha_Consulta"])
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar diagnóstico: " + ex.Message);
                }
                finally
                {
                    conexionAccess.CerrarConexion();
                }
            }
            return null;
        }

        public static void Editar(ModeloDiagnostico d)
        {
            var conexionAccess = new ConexionAccess();
            var conexion = conexionAccess.Obtener();

            string sql = "UPDATE Diagnosticos " +
                         "SET [id-Paciente]=?, [id-Medico]=?, Sintomas=?, Diagnostico=?, Tratamiento=?, Fecha_Consulta=? " +
                         "WHERE Id=?";

            using (var cmd = new OleDbCommand(sql, conexion))
            {
                cmd.Parameters.Add("idPaciente", OleDbType.Integer).Value = d.idPaciente;
                cmd.Parameters.Add("idMedico", OleDbType.Integer).Value = d.idMedico;
                cmd.Parameters.Add("Sintomas", OleDbType.LongVarWChar).Value = d.Sintomas ?? string.Empty;
                cmd.Parameters.Add("Diagnostico", OleDbType.VarWChar).Value = d.Diagnostico ?? string.Empty;
                cmd.Parameters.Add("Tratamiento", OleDbType.VarWChar).Value = d.Tratamiento ?? string.Empty;
                cmd.Parameters.Add("Fecha_Consulta", OleDbType.Date).Value = d.FechaCita;
                cmd.Parameters.Add("Id", OleDbType.Integer).Value = d.id;

                try
                {
                    conexionAccess.AbrirConeccin();
                    int n = cmd.ExecuteNonQuery();
                    if (n > 0) MessageBox.Show("Diagnóstico actualizado correctamente");
                    else MessageBox.Show("No se encontró el diagnóstico a actualizar");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar diagnóstico: " + ex.Message);
                }
                finally
                {
                    conexionAccess.CerrarConexion();
                }
            }
        }

        public static List<ModeloDiagnostico> ObtenerTodos()
        {
            var lista = new List<ModeloDiagnostico>();
            var conexionAccess = new ConexionAccess();
            var conexion = conexionAccess.Obtener();

            string sql = "SELECT Id, [id-Paciente], [id-Medico], Sintomas, Diagnostico, Tratamiento, Fecha_Consulta FROM Diagnosticos";

            using (var cmd = new OleDbCommand(sql, conexion))
            {
                try
                {
                    conexionAccess.AbrirConeccin();
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            lista.Add(new ModeloDiagnostico
                            {
                                id = Convert.ToInt32(r["Id"]),
                                idPaciente = Convert.ToInt32(r["id-Paciente"]),
                                idMedico = Convert.ToInt32(r["id-Medico"]),
                                Sintomas = r["Sintomas"]?.ToString(),
                                Diagnostico = r["Diagnostico"]?.ToString(),
                                Tratamiento = r["Tratamiento"]?.ToString(),
                                FechaCita = Convert.ToDateTime(r["Fecha_Consulta"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener diagnósticos: " + ex.Message);
                }
                finally
                {
                    conexionAccess.CerrarConexion();
                }
            }
            return lista;
        }
    }
}
