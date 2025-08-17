namespace Getion_de_Pasientes_de_Consultorio_Medico.Formularios
{
    partial class FrmMedico
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminarMedico = new System.Windows.Forms.Button();
            this.btnBuscarMedico = new System.Windows.Forms.Button();
            this.btnGuardadMedico = new System.Windows.Forms.Button();
            this.txtEmailMedico = new System.Windows.Forms.TextBox();
            this.txtTelefonoMedico = new System.Windows.Forms.TextBox();
            this.txtEspecialidadMedico = new System.Windows.Forms.TextBox();
            this.txtApellidoMedico = new System.Windows.Forms.TextBox();
            this.txtNombreMedico = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdMedico = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEliminarMedico);
            this.groupBox1.Controls.Add(this.btnBuscarMedico);
            this.groupBox1.Controls.Add(this.btnGuardadMedico);
            this.groupBox1.Controls.Add(this.txtEmailMedico);
            this.groupBox1.Controls.Add(this.txtTelefonoMedico);
            this.groupBox1.Controls.Add(this.txtEspecialidadMedico);
            this.groupBox1.Controls.Add(this.txtApellidoMedico);
            this.groupBox1.Controls.Add(this.txtNombreMedico);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIdMedico);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 283);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro de Medicos";
            // 
            // btnEliminarMedico
            // 
            this.btnEliminarMedico.Location = new System.Drawing.Point(50, 254);
            this.btnEliminarMedico.Name = "btnEliminarMedico";
            this.btnEliminarMedico.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarMedico.TabIndex = 15;
            this.btnEliminarMedico.Text = "Elimnar";
            this.btnEliminarMedico.UseVisualStyleBackColor = true;
            this.btnEliminarMedico.Click += new System.EventHandler(this.btnEliminarMedico_Click);
            // 
            // btnBuscarMedico
            // 
            this.btnBuscarMedico.Location = new System.Drawing.Point(92, 219);
            this.btnBuscarMedico.Name = "btnBuscarMedico";
            this.btnBuscarMedico.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarMedico.TabIndex = 14;
            this.btnBuscarMedico.Text = "Buscar";
            this.btnBuscarMedico.UseVisualStyleBackColor = true;
            this.btnBuscarMedico.Click += new System.EventHandler(this.btnBuscarMedico_Click);
            // 
            // btnGuardadMedico
            // 
            this.btnGuardadMedico.Location = new System.Drawing.Point(9, 219);
            this.btnGuardadMedico.Name = "btnGuardadMedico";
            this.btnGuardadMedico.Size = new System.Drawing.Size(75, 23);
            this.btnGuardadMedico.TabIndex = 13;
            this.btnGuardadMedico.Text = "Guardar";
            this.btnGuardadMedico.UseVisualStyleBackColor = true;
            this.btnGuardadMedico.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEmailMedico
            // 
            this.txtEmailMedico.Location = new System.Drawing.Point(50, 179);
            this.txtEmailMedico.Name = "txtEmailMedico";
            this.txtEmailMedico.Size = new System.Drawing.Size(117, 20);
            this.txtEmailMedico.TabIndex = 12;
            // 
            // txtTelefonoMedico
            // 
            this.txtTelefonoMedico.Location = new System.Drawing.Point(67, 153);
            this.txtTelefonoMedico.Name = "txtTelefonoMedico";
            this.txtTelefonoMedico.Size = new System.Drawing.Size(100, 20);
            this.txtTelefonoMedico.TabIndex = 11;
            // 
            // txtEspecialidadMedico
            // 
            this.txtEspecialidadMedico.Location = new System.Drawing.Point(85, 121);
            this.txtEspecialidadMedico.Name = "txtEspecialidadMedico";
            this.txtEspecialidadMedico.Size = new System.Drawing.Size(82, 20);
            this.txtEspecialidadMedico.TabIndex = 10;
            this.txtEspecialidadMedico.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txtApellidoMedico
            // 
            this.txtApellidoMedico.Location = new System.Drawing.Point(62, 91);
            this.txtApellidoMedico.Name = "txtApellidoMedico";
            this.txtApellidoMedico.Size = new System.Drawing.Size(105, 20);
            this.txtApellidoMedico.TabIndex = 9;
            // 
            // txtNombreMedico
            // 
            this.txtNombreMedico.Location = new System.Drawing.Point(62, 58);
            this.txtNombreMedico.Name = "txtNombreMedico";
            this.txtNombreMedico.Size = new System.Drawing.Size(105, 20);
            this.txtNombreMedico.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Email: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Telefono: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Especialidad: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Apellido: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre: ";
            // 
            // txtIdMedico
            // 
            this.txtIdMedico.Location = new System.Drawing.Point(34, 27);
            this.txtIdMedico.Name = "txtIdMedico";
            this.txtIdMedico.Size = new System.Drawing.Size(133, 20);
            this.txtIdMedico.TabIndex = 2;
            // 
            // FrmMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 307);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMedico";
            this.Text = "Medico";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEmailMedico;
        private System.Windows.Forms.TextBox txtTelefonoMedico;
        private System.Windows.Forms.TextBox txtEspecialidadMedico;
        private System.Windows.Forms.TextBox txtApellidoMedico;
        private System.Windows.Forms.TextBox txtNombreMedico;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdMedico;
        private System.Windows.Forms.Button btnEliminarMedico;
        private System.Windows.Forms.Button btnBuscarMedico;
        private System.Windows.Forms.Button btnGuardadMedico;
    }
}