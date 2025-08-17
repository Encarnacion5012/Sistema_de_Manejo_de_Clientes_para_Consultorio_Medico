using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Getion_de_Pasientes_de_Consultorio_Medico.Modelos;
using Getion_de_Pasientes_de_Consultorio_Medico.Servicios;
using Getion_de_Pasientes_de_Consultorio_Medico.Utilidades;

namespace Getion_de_Pasientes_de_Consultorio_Medico.Formularios
{
    public partial class FrmCitas : Form
    {
        public FrmCitas()
        {
            InitializeComponent();
            this.Load += FrmCitas_Load;

        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnGuardarCitas_Click(object sender, EventArgs e)
        {
            var cita = new ModeloCita
            {
                idPaciente = (int)cmbIdPacienteCitas.SelectedValue,
                idMedico = (int)cmbIdMedicoCitas.SelectedValue,
                Motivo = txtMotivoCitas.Text.Trim(),
                EstadoCita = cmbEstadoCita.Text,
                FechaHora = dptFechaHoraCita.Value
            };

            ServicioCitas.Insertar(cita);

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
        }

        private void btnEditarCitas_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdCitas.Text, out int id))
            {
                var cita = new ModeloCita
                {
                    id = id,
                    idPaciente = (int)cmbIdPacienteCitas.SelectedValue,
                    idMedico = (int)cmbIdMedicoCitas.SelectedValue,
                    Motivo = txtMotivoCitas.Text.Trim(),
                    EstadoCita = cmbEstadoCita.Text,
                    FechaHora = dptFechaHoraCita.Value
                };

                ServicioCitas.Editar(cita);
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido para editar");
            }
        }

        private void btnBuscarCitas_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdCitas.Text, out int id))
            {
                var cita = ServicioCitas.BuscarPorId(id);

                if (cita != null)
                {
                    cmbIdPacienteCitas.SelectedValue = cita.idPaciente;
                    cmbIdMedicoCitas.SelectedValue = cita.idMedico;
                    txtMotivoCitas.Text = cita.Motivo;
                    cmbEstadoCita.Text = cita.EstadoCita;
                    dptFechaHoraCita.Value = cita.FechaHora;
                }
                else
                {
                    MessageBox.Show("Cita no encontrada");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido para buscar");
            }
        }

        private void btnEliminarCitas_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdCitas.Text, out int id))
            {
                var confirmar = MessageBox.Show(
                    "¿Seguro que desea eliminar esta cita?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmar == DialogResult.Yes)
                {
                    ServicioCitas.Eliminar(id);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido para eliminar");
            }
        }

        private void FrmCitas_Load(object sender, EventArgs e)
        {

            var pacientes = ServicioPacientes.ObtenerTodos();
            cmbIdPacienteCitas.DataSource = pacientes;
            cmbIdPacienteCitas.ValueMember = "Id";
            cmbIdPacienteCitas.DisplayMember = "NombreCompleto";
            cmbIdPacienteCitas.SelectedIndex = -1; 

            var medicos = ServicioMedico.ObtenerTodos();
            cmbIdMedicoCitas.DataSource = medicos;
            cmbIdMedicoCitas.ValueMember = "Id";
            cmbIdMedicoCitas.DisplayMember = "Nombre";
            cmbIdMedicoCitas.SelectedIndex = -1;



            cmbEstadoCita.Items.AddRange(new string[] { "Pendiente", "Completada", "Cancelada" });
            ConfigurarDiseñoCitas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarCampos limpiar = new LimpiarCampos();
            limpiar.limpiarCampos(this);
        }
        private void ConfigurarDiseñoCitas()
        {
            

            this.SuspendLayout();

            this.Text = "Gestión de Citas";
            this.BackColor = Color.FromArgb(240, 245, 249);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(860, 560);

            // Contenedor con scroll para evitar cortes si la ventana es pequeña
            var scrollHost = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(12)
            };

            // Layout principal
            var layoutMain = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 1,
                RowCount = 2,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Grupo de datos autoajustable
            var grpDatos = new GroupBox
            {
                Text = "Datos de la cita",
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(12),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.DimGray
            };

            // Tabla de campos
            var tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 2,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160)); // ancho etiquetas
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));  // campo ocupa el resto

            // 6 filas con alturas consistentes para evitar solapes
            for (int i = 0; i < 6; i++)
                tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

            // Estilos de controles existentes (del diseñador)
            txtIdCitas.Dock = DockStyle.Fill;
            cmbIdPacienteCitas.Dock = DockStyle.Fill;
            cmbIdMedicoCitas.Dock = DockStyle.Fill;
            txtMotivoCitas.Dock = DockStyle.Fill;
            cmbEstadoCita.Dock = DockStyle.Fill;
            dptFechaHoraCita.Dock = DockStyle.Fill;
            dptFechaHoraCita.Format = DateTimePickerFormat.Custom;
            dptFechaHoraCita.CustomFormat = "dd/MM/yyyy HH:mm";

            // Opcional: ayuda para nombres largos en combos
            cmbIdPacienteCitas.DropDownWidth = 320;
            cmbIdMedicoCitas.DropDownWidth = 320;
            cmbIdPacienteCitas.IntegralHeight = false;
            cmbIdMedicoCitas.IntegralHeight = false;

            // Etiquetas
            var lblId = new Label { Text = "Id:", AutoSize = true, Anchor = AnchorStyles.Left };
            var lblPac = new Label { Text = "Id-Paciente:", AutoSize = true, Anchor = AnchorStyles.Left };
            var lblMed = new Label { Text = "Id-Médico:", AutoSize = true, Anchor = AnchorStyles.Left };
            var lblMotivo = new Label { Text = "Motivo:", AutoSize = true, Anchor = AnchorStyles.Left };
            var lblEstado = new Label { Text = "Estado de la cita:", AutoSize = true, Anchor = AnchorStyles.Left };
            var lblFecha = new Label { Text = "Fecha y hora:", AutoSize = true, Anchor = AnchorStyles.Left };

            // Margen uniforme
            var m = new Padding(4, 6, 4, 6);
            lblId.Margin = lblPac.Margin = lblMed.Margin = lblMotivo.Margin = lblEstado.Margin = lblFecha.Margin = m;
            txtIdCitas.Margin = cmbIdPacienteCitas.Margin = cmbIdMedicoCitas.Margin = txtMotivoCitas.Margin = cmbEstadoCita.Margin = dptFechaHoraCita.Margin = m;

            // Agregar controles a la tabla
            tbl.Controls.Add(lblId, 0, 0); tbl.Controls.Add(txtIdCitas, 1, 0);
            tbl.Controls.Add(lblPac, 0, 1); tbl.Controls.Add(cmbIdPacienteCitas, 1, 1);
            tbl.Controls.Add(lblMed, 0, 2); tbl.Controls.Add(cmbIdMedicoCitas, 1, 2);
            tbl.Controls.Add(lblMotivo, 0, 3); tbl.Controls.Add(txtMotivoCitas, 1, 3);
            tbl.Controls.Add(lblEstado, 0, 4); tbl.Controls.Add(cmbEstadoCita, 1, 4);
            tbl.Controls.Add(lblFecha, 0, 5); tbl.Controls.Add(dptFechaHoraCita, 1, 5);

            grpDatos.Controls.Add(tbl);

            // Panel de botones autoajustable
            var panelBotones = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true, // permite salto de línea si el ancho es menor
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(0),
                Margin = new Padding(0, 12, 0, 0)
            };

            EstilizarBoton(btnGuardarCitas, "Guardar", Color.SeaGreen);
            EstilizarBoton(btnEditarCitas, "Editar", Color.DarkOrange);
            EstilizarBoton(btnBuscarCitas, "Buscar", Color.SteelBlue);
            EstilizarBoton(btnEliminarCitas, "Eliminar", Color.Firebrick);
            EstilizarBoton(btnLiampiar, "Limpiar", Color.Gray);

            panelBotones.Controls.AddRange(new Control[] {
        btnGuardarCitas, btnEditarCitas, btnBuscarCitas, btnEliminarCitas, btnLiampiar
    });

            // Componer layout
            layoutMain.Controls.Add(grpDatos, 0, 0);
            layoutMain.Controls.Add(panelBotones, 0, 1);

            // Montar en el scroll host
            scrollHost.Controls.Add(layoutMain);

            // Reemplazar contenido del formulario
            this.Controls.Clear();
            this.Controls.Add(scrollHost);

            this.ResumeLayout(true);
        }

        private void EstilizarBoton(Button btn, string texto, Color color)
        {
            btn.Text = texto;
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Width = 120;
            btn.Height = 40;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Margin = new Padding(6);

            btn.MouseEnter += (s, e) => ((Button)s).BackColor = ControlPaint.Light(color);
            btn.MouseLeave += (s, e) => ((Button)s).BackColor = color;
        }

    }
}