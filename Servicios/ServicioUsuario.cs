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

        public static void Insertar(Usuario usuario)
        {
            ConexionAccess conexcionAccess = new ConexionAccess();
            OleDbConnection conexion = conexcionAccess.Obtener();

            string query = "INSERT INTO Usuarios (Nombre, Clave, Rol) VALUES (?, ?, ?)";
            OleDbCommand comando = new OleDbCommand(query, conexion);
            comando.Parameters.AddWithValue("?", usuario.Nombre);
            comando.Parameters.AddWithValue("?", usuario.Clave);
            comando.Parameters.AddWithValue("?", usuario.Rol);
            try
            {
                conexcionAccess.AbrirConeccin();
                comando.ExecuteNonQuery();
                comando.CommandText = "SELECT @@IDENTITY";
                comando.Parameters.Clear();
                int nuevoId = Convert.ToInt32(comando.ExecuteScalar());
                MessageBox.Show("Usuario registrado con ID: " + nuevoId);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar paciente: " + ex);
            }
            finally
            {
                conexcionAccess.CerrarConexion();

            }
        }

             public static void actualizar(Usuario usuario)
             {
            ConexionAccess conexcionAccess = new ConexionAccess();
            OleDbConnection conexion = conexcionAccess.Obtener();
            string query = "UPDATE Usuarios SET Nombre=?, Clave=?, Rol=? WHERE Id=?";
            OleDbCommand comando = new OleDbCommand(query, conexion);
            comando.Parameters.AddWithValue("?", usuario.Nombre);
            comando.Parameters.AddWithValue("?", usuario.Clave);
            comando.Parameters.AddWithValue("?", usuario.Rol);
            comando.Parameters.AddWithValue("?", usuario.Id);
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

        public static Usuario BuscarPorId(int id)
        {
            ConexionAccess conexionAccess = new ConexionAccess();
            OleDbConnection conexion = conexionAccess.Obtener();
            string query = "SELECT * FROM Usuarios WHERE Id=?";
            OleDbCommand comando = new OleDbCommand(query, conexion);
            comando.Parameters.AddWithValue("?", id);

            try
            {
                conexionAccess.AbrirConeccin();
                OleDbDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    return new Usuario
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Clave = reader["Clave"].ToString(),
                        Rol = reader["Rol"].ToString(),
                      
                    };

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el usuario: " + ex);
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
            string query = "DELETE FROM Usuarios WHERE Id=?";
            OleDbCommand comando = new OleDbCommand(query, conexion);
            comando.Parameters.AddWithValue("?", id);
            try
            {
                conexionAccess.AbrirConeccin();
                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario Eliminado Corecctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar Usuario: " + ex.Message);
            }
            finally
            {
                conexionAccess.CerrarConexion();
            }
        }
    }

    }


    

