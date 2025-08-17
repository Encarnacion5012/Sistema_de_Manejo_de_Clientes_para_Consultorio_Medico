namespace Getion_de_Pasientes_de_Consultorio_Medico.Formularios
{
    partial class FrmLogin
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
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.TxtClave = new System.Windows.Forms.TextBox();
            this.Labe2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIniciarSecion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicio de secion";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(104, 57);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(211, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // TxtClave
            // 
            this.TxtClave.Location = new System.Drawing.Point(116, 98);
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.Size = new System.Drawing.Size(199, 20);
            this.TxtClave.TabIndex = 2;
            // 
            // Labe2
            // 
            this.Labe2.AutoSize = true;
            this.Labe2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Labe2.Location = new System.Drawing.Point(31, 55);
            this.Labe2.Name = "Labe2";
            this.Labe2.Size = new System.Drawing.Size(72, 18);
            this.Labe2.TabIndex = 3;
            this.Labe2.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña: ";
            // 
            // btnIniciarSecion
            // 
            this.btnIniciarSecion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSecion.Location = new System.Drawing.Point(121, 138);
            this.btnIniciarSecion.Name = "btnIniciarSecion";
            this.btnIniciarSecion.Size = new System.Drawing.Size(146, 38);
            this.btnIniciarSecion.TabIndex = 5;
            this.btnIniciarSecion.Text = "Iniciar Secion";
            this.btnIniciarSecion.UseVisualStyleBackColor = true;
            this.btnIniciarSecion.Click += new System.EventHandler(this.btnIniciarSecion_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 199);
            this.Controls.Add(this.btnIniciarSecion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Labe2);
            this.Controls.Add(this.TxtClave);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label1);
            this.Name = "FrmLogin";
            this.Text = "Inicar secion";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox TxtClave;
        private System.Windows.Forms.Label Labe2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIniciarSecion;
    }
}