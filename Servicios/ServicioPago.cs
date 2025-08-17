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
    class ServicioPago
    {
        public static void Insertar(ModeloPagos p)
        {
            var conexionAccess = new ConexionAccess();
            using (var conexion = conexionAccess.Obtener())
            {
                // Importante: OleDb usa el ORDEN de los ?, no los nombres
                string sql = "INSERT INTO Pagos ([Id-Paciente], Fecha_Pago, Monto, Metodo_Pago) VALUES (?, ?, ?, ?)";

                using (var cmd = new OleDbCommand(sql, conexion))
                {
                    // El primer Add corresponde al primer ?, o sea [Id-Paciente]
                    cmd.Parameters.Add("IdPaciente", OleDbType.Integer).Value = p.idPacien;
                    cmd.Parameters.Add("FechaPago", OleDbType.Date).Value = p.FechaPago;
                    cmd.Parameters.Add("Monto", OleDbType.Currency).Value = p.Monto;
                    cmd.Parameters.Add("MetodoPago", OleDbType.VarWChar).Value = p.MetodoPago ?? string.Empty;

                    try
                    {
                        conexionAccess.AbrirConeccin();
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT @@IDENTITY";
                        cmd.Parameters.Clear();
                        int nuevoId = Convert.ToInt32(cmd.ExecuteScalar());
                        MessageBox.Show("Pago registrado con ID: " + nuevoId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al registrar pago: " + ex.Message);
                    }
                    finally
                    {
                        conexionAccess.CerrarConexion();
                    }
                }
            }
        }
    }
}
