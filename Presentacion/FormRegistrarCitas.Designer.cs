
namespace Presentacion
{
    partial class FormRegistrarCitas
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
            this.dtHora = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSede = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMetodoPago = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbContacto = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbFecha = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtHora
            // 
            this.dtHora.AllowDrop = true;
            this.dtHora.CustomFormat = "HH:mm ";
            this.dtHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHora.Location = new System.Drawing.Point(257, 256);
            this.dtHora.Name = "dtHora";
            this.dtHora.Size = new System.Drawing.Size(286, 20);
            this.dtHora.TabIndex = 81;
            this.dtHora.Value = new System.DateTime(2024, 1, 1, 0, 1, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(127, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 16);
            this.label5.TabIndex = 80;
            this.label5.Text = "Hora de Inicio:";
            // 
            // cbSede
            // 
            this.cbSede.FormattingEnabled = true;
            this.cbSede.Items.AddRange(new object[] {
            "Av. Primavera 1676, Surco",
            "Av. Alfredo Benavides 2197, Miraflores",
            "Calle Porta 194, Miraflores",
            "Javier Prado Este 5295, La Molina",
            "Av. Arenales 2211, Lince",
            "CC San Felipe, Tda. 67, Int. 79 Residencial San Felipe",
            "Av.Los conquistadores #133, San Isidro"});
            this.cbSede.Location = new System.Drawing.Point(187, 217);
            this.cbSede.Name = "cbSede";
            this.cbSede.Size = new System.Drawing.Size(356, 21);
            this.cbSede.TabIndex = 79;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(127, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 78;
            this.label4.Text = "Sede:";
            // 
            // cbMetodoPago
            // 
            this.cbMetodoPago.FormattingEnabled = true;
            this.cbMetodoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta de crédito/débito",
            "Yape",
            "Plin"});
            this.cbMetodoPago.Location = new System.Drawing.Point(257, 349);
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Size = new System.Drawing.Size(285, 21);
            this.cbMetodoPago.TabIndex = 77;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(120, 349);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 16);
            this.label12.TabIndex = 76;
            this.label12.Text = "Metodo de pago:";
            // 
            // cbContacto
            // 
            this.cbContacto.FormattingEnabled = true;
            this.cbContacto.Items.AddRange(new object[] {
            "Teléfono",
            "Email"});
            this.cbContacto.Location = new System.Drawing.Point(257, 296);
            this.cbContacto.Name = "cbContacto";
            this.cbContacto.Size = new System.Drawing.Size(285, 21);
            this.cbContacto.TabIndex = 75;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(77, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.TabIndex = 74;
            this.label11.Text = "PASO 1:";
            // 
            // cbFecha
            // 
            this.cbFecha.CustomFormat = "dd/MM/yy";
            this.cbFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cbFecha.Location = new System.Drawing.Point(249, 181);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(294, 20);
            this.cbFecha.TabIndex = 73;
            this.cbFecha.Value = new System.DateTime(2024, 1, 1, 0, 1, 0, 0);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(574, 271);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 23);
            this.btnCancelar.TabIndex = 72;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.Location = new System.Drawing.Point(574, 219);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(111, 23);
            this.btnContinuar.TabIndex = 71;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(97, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 16);
            this.label3.TabIndex = 70;
            this.label3.Text = "Metodo de contacto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(127, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 69;
            this.label2.Text = "Fecha:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(77, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 20);
            this.label6.TabIndex = 68;
            this.label6.Text = "Ingrese los siguientes datos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(327, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 29);
            this.label1.TabIndex = 67;
            this.label1.Text = "Registro de nuevas Citas:";
            // 
            // FormRegistrarCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 435);
            this.Controls.Add(this.dtHora);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbSede);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbMetodoPago);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbContacto);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbFecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "FormRegistrarCitas";
            this.Text = "FormRegistrarCitas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtHora;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSede;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMetodoPago;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbContacto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker cbFecha;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
    }
}