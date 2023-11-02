namespace FrmLobby
{
    partial class FormularioRegistro
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
            txtBoxNombre = new TextBox();
            txtBoxApellido = new TextBox();
            groupBox1 = new GroupBox();
            label8 = new Label();
            txtBoxEdad = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            numAnio = new NumericUpDown();
            numMes = new NumericUpDown();
            numDia = new NumericUpDown();
            groupBox3 = new GroupBox();
            label9 = new Label();
            txtBoxDNI = new TextBox();
            label11 = new Label();
            label12 = new Label();
            txtBoxEmail = new TextBox();
            txtBoxTelefono = new TextBox();
            groupBox4 = new GroupBox();
            label7 = new Label();
            txtBoxDireccion = new TextBox();
            BtnRegistrar = new Button();
            BtnHardcodear = new Button();
            lblFactory = new Label();
            BtnBackToLobby = new Button();
            groupBox5 = new GroupBox();
            label10 = new Label();
            cboxCargo = new ComboBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDia).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // txtBoxNombre
            // 
            txtBoxNombre.Location = new Point(73, 28);
            txtBoxNombre.Name = "txtBoxNombre";
            txtBoxNombre.Size = new Size(100, 25);
            txtBoxNombre.TabIndex = 0;
            // 
            // txtBoxApellido
            // 
            txtBoxApellido.Location = new Point(73, 69);
            txtBoxApellido.Name = "txtBoxApellido";
            txtBoxApellido.Size = new Size(100, 25);
            txtBoxApellido.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtBoxEdad);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtBoxNombre);
            groupBox1.Controls.Add(txtBoxApellido);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.ForeColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(12, 62);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(186, 151);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Personales";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 113);
            label8.Name = "label8";
            label8.Size = new Size(39, 19);
            label8.TabIndex = 8;
            label8.Text = "Edad";
            // 
            // txtBoxEdad
            // 
            txtBoxEdad.Location = new Point(73, 110);
            txtBoxEdad.Name = "txtBoxEdad";
            txtBoxEdad.Size = new Size(100, 25);
            txtBoxEdad.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 71);
            label2.Name = "label2";
            label2.Size = new Size(58, 19);
            label2.TabIndex = 4;
            label2.Text = "Apellido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 31);
            label1.Name = "label1";
            label1.Size = new Size(59, 19);
            label1.TabIndex = 3;
            label1.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(12, 21);
            label3.Name = "label3";
            label3.Size = new Size(160, 25);
            label3.TabIndex = 5;
            label3.Text = "Registro Usuario";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(numAnio);
            groupBox2.Controls.Add(numMes);
            groupBox2.Controls.Add(numDia);
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(218, 21);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(175, 151);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Fecha Nacimiento";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 113);
            label6.Name = "label6";
            label6.Size = new Size(34, 19);
            label6.TabIndex = 6;
            label6.Text = "Año";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 71);
            label5.Name = "label5";
            label5.Size = new Size(35, 19);
            label5.TabIndex = 5;
            label5.Text = "Mes";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 30);
            label4.Name = "label4";
            label4.Size = new Size(29, 19);
            label4.TabIndex = 4;
            label4.Text = "Día";
            // 
            // numAnio
            // 
            numAnio.Location = new Point(60, 111);
            numAnio.Name = "numAnio";
            numAnio.Size = new Size(99, 25);
            numAnio.TabIndex = 2;
            // 
            // numMes
            // 
            numMes.Location = new Point(60, 69);
            numMes.Name = "numMes";
            numMes.Size = new Size(99, 25);
            numMes.TabIndex = 1;
            // 
            // numDia
            // 
            numDia.Location = new Point(60, 28);
            numDia.Name = "numDia";
            numDia.Size = new Size(99, 25);
            numDia.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(txtBoxDNI);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(txtBoxEmail);
            groupBox3.Controls.Add(txtBoxTelefono);
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox3.ForeColor = SystemColors.ButtonHighlight;
            groupBox3.Location = new Point(12, 219);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(186, 147);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Informacion Usuario";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(25, 113);
            label9.Name = "label9";
            label9.Size = new Size(33, 19);
            label9.TabIndex = 8;
            label9.Text = "DNI";
            // 
            // txtBoxDNI
            // 
            txtBoxDNI.Location = new Point(73, 110);
            txtBoxDNI.Name = "txtBoxDNI";
            txtBoxDNI.Size = new Size(100, 25);
            txtBoxDNI.TabIndex = 5;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(9, 72);
            label11.Name = "label11";
            label11.Size = new Size(60, 19);
            label11.TabIndex = 4;
            label11.Text = "Telefono";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(22, 31);
            label12.Name = "label12";
            label12.Size = new Size(41, 19);
            label12.TabIndex = 3;
            label12.Text = "Email";
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.Location = new Point(73, 28);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.Size = new Size(100, 25);
            txtBoxEmail.TabIndex = 0;
            // 
            // txtBoxTelefono
            // 
            txtBoxTelefono.Location = new Point(73, 69);
            txtBoxTelefono.Name = "txtBoxTelefono";
            txtBoxTelefono.Size = new Size(100, 25);
            txtBoxTelefono.TabIndex = 1;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.Transparent;
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(txtBoxDireccion);
            groupBox4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox4.ForeColor = SystemColors.ButtonHighlight;
            groupBox4.Location = new Point(218, 178);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(175, 77);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "Direccion";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 35);
            label7.Name = "label7";
            label7.Size = new Size(65, 19);
            label7.TabIndex = 9;
            label7.Text = "Dirección";
            // 
            // txtBoxDireccion
            // 
            txtBoxDireccion.Location = new Point(71, 32);
            txtBoxDireccion.Name = "txtBoxDireccion";
            txtBoxDireccion.Size = new Size(89, 25);
            txtBoxDireccion.TabIndex = 9;
            // 
            // BtnRegistrar
            // 
            BtnRegistrar.BackColor = Color.LimeGreen;
            BtnRegistrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnRegistrar.Location = new Point(257, 378);
            BtnRegistrar.Name = "BtnRegistrar";
            BtnRegistrar.Size = new Size(136, 52);
            BtnRegistrar.TabIndex = 13;
            BtnRegistrar.Text = "Registrar";
            BtnRegistrar.UseVisualStyleBackColor = false;
            BtnRegistrar.Click += BtnRegistrar_Click;
            // 
            // BtnHardcodear
            // 
            BtnHardcodear.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            BtnHardcodear.Location = new Point(154, 386);
            BtnHardcodear.Name = "BtnHardcodear";
            BtnHardcodear.Size = new Size(97, 38);
            BtnHardcodear.TabIndex = 14;
            BtnHardcodear.Text = "Hardcodear";
            BtnHardcodear.UseVisualStyleBackColor = true;
            BtnHardcodear.Click += BtnHardcodear_Click;
            // 
            // lblFactory
            // 
            lblFactory.AutoSize = true;
            lblFactory.BackColor = Color.Transparent;
            lblFactory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblFactory.ForeColor = Color.Coral;
            lblFactory.Location = new Point(289, 345);
            lblFactory.Name = "lblFactory";
            lblFactory.Size = new Size(87, 21);
            lblFactory.TabIndex = 16;
            lblFactory.Text = "Factory.IO";
            lblFactory.TextAlign = ContentAlignment.TopCenter;
            // 
            // BtnBackToLobby
            // 
            BtnBackToLobby.BackColor = Color.LightSalmon;
            BtnBackToLobby.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnBackToLobby.Location = new Point(12, 379);
            BtnBackToLobby.Name = "BtnBackToLobby";
            BtnBackToLobby.Size = new Size(136, 52);
            BtnBackToLobby.TabIndex = 17;
            BtnBackToLobby.Text = "Back tu Lobby";
            BtnBackToLobby.UseVisualStyleBackColor = false;
            BtnBackToLobby.Click += BtnBackToLobby_Click;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.Transparent;
            groupBox5.Controls.Add(cboxCargo);
            groupBox5.Controls.Add(label10);
            groupBox5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox5.ForeColor = SystemColors.ButtonHighlight;
            groupBox5.Location = new Point(218, 261);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(175, 77);
            groupBox5.TabIndex = 11;
            groupBox5.TabStop = false;
            groupBox5.Text = "Cargo";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 35);
            label10.Name = "label10";
            label10.Size = new Size(51, 19);
            label10.TabIndex = 9;
            label10.Text = "Puesto";
            // 
            // cboxCargo
            // 
            cboxCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxCargo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboxCargo.FormattingEnabled = true;
            cboxCargo.Location = new Point(60, 32);
            cboxCargo.Name = "cboxCargo";
            cboxCargo.Size = new Size(100, 25);
            cboxCargo.TabIndex = 10;
            // 
            // FormularioRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.design_in_the_concept_of_electronic_circuit_boards_vector;
            ClientSize = new Size(405, 442);
            Controls.Add(groupBox5);
            Controls.Add(BtnBackToLobby);
            Controls.Add(lblFactory);
            Controls.Add(BtnHardcodear);
            Controls.Add(BtnRegistrar);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormularioRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmRegistro";
            Load += FormularioRegistro_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMes).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDia).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxNombre;
        private TextBox txtBoxApellido;
        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Label label3;
        private GroupBox groupBox2;
        private Label label8;
        private TextBox txtBoxEdad;
        private Label label6;
        private Label label5;
        private Label label4;
        private NumericUpDown numAnio;
        private NumericUpDown numMes;
        private NumericUpDown numDia;
        private GroupBox groupBox3;
        private Label label9;
        private TextBox txtBoxDNI;
        private Label label11;
        private Label label12;
        private TextBox txtBoxEmail;
        private TextBox txtBoxTelefono;
        private GroupBox groupBox4;
        private Label label7;
        private TextBox txtBoxDireccion;
        private Button BtnRegistrar;
        private Button BtnHardcodear;
        private Label lblFactory;
        private Button BtnBackToLobby;
        private GroupBox groupBox5;
        private Label label10;
        private ComboBox cboxCargo;
    }
}