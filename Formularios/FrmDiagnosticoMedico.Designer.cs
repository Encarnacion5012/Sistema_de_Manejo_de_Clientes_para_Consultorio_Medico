namespace Getion_de_Pasientes_de_Consultorio_Medico.Formularios
{
    partial class FrmDiagnosticoMedico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdDiagnostico = new System.Windows.Forms.TextBox();
            this.cmbIdPacienteDiagnostico = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dptFechaConDiag = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBuscarDiagnostico = new System.Windows.Forms.Button();
            this.btnGuardarDiag = new System.Windows.Forms.Button();
            this.txtTratamientoDiagnostico = new System.Windows.Forms.TextBox();
            this.txtDiagnosticoDiag = new System.Windows.Forms.TextBox();
            this.txtSintomasDiagnostico = new System.Windows.Forms.TextBox();
            this.cmdIdMedicoDiagnostico = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id: ";
            // 
            // txtIdDiagnostico
            // 
            this.txtIdDiagnostico.Location = new System.Drawing.Point(34, 23);
            this.txtIdDiagnostico.Name = "txtIdDiagnostico";
            this.txtIdDiagnostico.Size = new System.Drawing.Size(163, 20);
            this.txtIdDiagnostico.TabIndex = 1;
            // 
            // cmbIdPacienteDiagnostico
            // 
            this.cmbIdPacienteDiagnostico.FormattingEnabled = true;
            this.cmbIdPacienteDiagnostico.Location = new System.Drawing.Point(76, 52);
            this.cmbIdPacienteDiagnostico.Name = "cmbIdPacienteDiagnostico";
            this.cmbIdPacienteDiagnostico.Size = new System.Drawing.Size(121, 21);
            this.cmbIdPacienteDiagnostico.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.dptFechaConDiag);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnBuscarDiagnostico);
            this.groupBox1.Controls.Add(this.btnGuardarDiag);
            this.groupBox1.Controls.Add(this.txtTratamientoDiagnostico);
            this.groupBox1.Controls.Add(this.txtDiagnosticoDiag);
            this.groupBox1.Controls.Add(this.txtSintomasDiagnostico);
            this.groupBox1.Controls.Add(this.cmdIdMedicoDiagnostico);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbIdPacienteDiagnostico);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIdDiagnostico);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 283);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Diagnostico";
            // 
            // dptFechaConDiag
            // 
            this.dptFechaConDiag.Location = new System.Drawing.Point(90, 222);
            this.dptFechaConDiag.Name = "dptFechaConDiag";
            this.dptFechaConDiag.Size = new System.Drawing.Size(100, 20);
            this.dptFechaConDiag.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Fecha Consulta: ";
            // 
            // btnBuscarDiagnostico
            // 
            this.btnBuscarDiagnostico.Location = new System.Drawing.Point(134, 249);
            this.btnBuscarDiagnostico.Name = "btnBuscarDiagnostico";
            this.btnBuscarDiagnostico.Size = new System.Drawing.Size(56, 23);
            this.btnBuscarDiagnostico.TabIndex = 11;
            this.btnBuscarDiagnostico.Text = "Buscar";
            this.btnBuscarDiagnostico.UseVisualStyleBackColor = true;
            this.btnBuscarDiagnostico.Click += new System.EventHandler(this.btnGuardarDiagnostico_Click);
            // 
            // btnGuardarDiag
            // 
            this.btnGuardarDiag.Location = new System.Drawing.Point(9, 249);
            this.btnGuardarDiag.Name = "btnGuardarDiag";
            this.btnGuardarDiag.Size = new System.Drawing.Size(64, 23);
            this.btnGuardarDiag.TabIndex = 10;
            this.btnGuardarDiag.Text = "Guardar";
            this.btnGuardarDiag.UseVisualStyleBackColor = true;
            this.btnGuardarDiag.Click += new System.EventHandler(this.btnGuardarDiag_Click);
            // 
            // txtTratamientoDiagnostico
            // 
            this.txtTratamientoDiagnostico.Location = new System.Drawing.Point(76, 187);
            this.txtTratamientoDiagnostico.Name = "txtTratamientoDiagnostico";
            this.txtTratamientoDiagnostico.Size = new System.Drawing.Size(121, 20);
            this.txtTratamientoDiagnostico.TabIndex = 9;
            // 
            // txtDiagnosticoDiag
            // 
            this.txtDiagnosticoDiag.Location = new System.Drawing.Point(74, 159);
            this.txtDiagnosticoDiag.Name = "txtDiagnosticoDiag";
            this.txtDiagnosticoDiag.Size = new System.Drawing.Size(123, 20);
            this.txtDiagnosticoDiag.TabIndex = 8;
            // 
            // txtSintomasDiagnostico
            // 
            this.txtSintomasDiagnostico.Location = new System.Drawing.Point(66, 123);
            this.txtSintomasDiagnostico.Name = "txtSintomasDiagnostico";
            this.txtSintomasDiagnostico.Size = new System.Drawing.Size(131, 20);
            this.txtSintomasDiagnostico.TabIndex = 7;
            // 
            // cmdIdMedicoDiagnostico
            // 
            this.cmdIdMedicoDiagnostico.FormattingEnabled = true;
            this.cmdIdMedicoDiagnostico.Location = new System.Drawing.Point(66, 87);
            this.cmdIdMedicoDiagnostico.Name = "cmdIdMedicoDiagnostico";
            this.cmdIdMedicoDiagnostico.Size = new System.Drawing.Size(131, 21);
            this.cmdIdMedicoDiagnostico.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tratamiento: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Diagnostico: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sintomas: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Id-Medico:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = " Id-Paciente:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(76, 249);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(54, 23);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FrmDiagnosticoMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 302);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmDiagnosticoMedico";
            this.Text = "Diagnostico Medico";
            this.Load += new System.EventHandler(this.FrmDiagnosticoMedico_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdDiagnostico;
        private System.Windows.Forms.ComboBox cmbIdPacienteDiagnostico;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTratamientoDiagnostico;
        private System.Windows.Forms.TextBox txtDiagnosticoDiag;
        private System.Windows.Forms.TextBox txtSintomasDiagnostico;
        private System.Windows.Forms.ComboBox cmdIdMedicoDiagnostico;
        private System.Windows.Forms.Button btnBuscarDiagnostico;
        private System.Windows.Forms.Button btnGuardarDiag;
        private System.Windows.Forms.DateTimePicker dptFechaConDiag;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLimpiar;
    }
}