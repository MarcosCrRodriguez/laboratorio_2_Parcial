namespace FrmLobby
{
    partial class FrmLobby
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLobby));
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            lblLobby = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            txtPassword = new TextBox();
            lblCargo = new Label();
            lblContraseña = new Label();
            cboxCargo = new ComboBox();
            BtnIngresar = new Button();
            BtnHardcode = new Button();
            lblFactory = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(78, 24);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(146, 29);
            txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtApellido.Location = new Point(78, 81);
            txtApellido.Multiline = true;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(146, 29);
            txtApellido.TabIndex = 1;
            // 
            // lblLobby
            // 
            lblLobby.AutoSize = true;
            lblLobby.BackColor = Color.Transparent;
            lblLobby.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblLobby.ForeColor = SystemColors.ButtonHighlight;
            lblLobby.Location = new Point(27, 19);
            lblLobby.Name = "lblLobby";
            lblLobby.Size = new Size(207, 40);
            lblLobby.TabIndex = 2;
            lblLobby.Text = "Lobby - Login";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblNombre.ForeColor = SystemColors.ButtonHighlight;
            lblNombre.Location = new Point(12, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(60, 19);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.BackColor = Color.Transparent;
            lblApellido.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblApellido.ForeColor = SystemColors.ButtonHighlight;
            lblApellido.Location = new Point(11, 84);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(61, 19);
            lblApellido.TabIndex = 4;
            lblApellido.Text = "Apellido";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(101, 84);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(146, 29);
            txtPassword.TabIndex = 5;
            // 
            // lblCargo
            // 
            lblCargo.AutoSize = true;
            lblCargo.BackColor = Color.Transparent;
            lblCargo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblCargo.ForeColor = SystemColors.ButtonHighlight;
            lblCargo.Location = new Point(48, 30);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new Size(47, 19);
            lblCargo.TabIndex = 7;
            lblCargo.Text = "Cargo";
            lblCargo.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.BackColor = Color.Transparent;
            lblContraseña.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblContraseña.ForeColor = SystemColors.ButtonHighlight;
            lblContraseña.Location = new Point(14, 87);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(81, 19);
            lblContraseña.TabIndex = 8;
            lblContraseña.Text = "Contraseña";
            lblContraseña.TextAlign = ContentAlignment.TopCenter;
            // 
            // cboxCargo
            // 
            cboxCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxCargo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboxCargo.FormattingEnabled = true;
            cboxCargo.Location = new Point(101, 24);
            cboxCargo.Name = "cboxCargo";
            cboxCargo.Size = new Size(146, 29);
            cboxCargo.TabIndex = 9;
            // 
            // BtnIngresar
            // 
            BtnIngresar.BackColor = Color.LimeGreen;
            BtnIngresar.FlatAppearance.BorderColor = Color.Black;
            BtnIngresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnIngresar.ForeColor = SystemColors.ActiveCaptionText;
            BtnIngresar.Location = new Point(357, 229);
            BtnIngresar.Name = "BtnIngresar";
            BtnIngresar.Size = new Size(144, 55);
            BtnIngresar.TabIndex = 10;
            BtnIngresar.Text = "Ingresar al sistema";
            BtnIngresar.UseVisualStyleBackColor = false;
            BtnIngresar.Click += BtnIngresar_Click;
            // 
            // BtnHardcode
            // 
            BtnHardcode.BackColor = Color.RosyBrown;
            BtnHardcode.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnHardcode.Location = new Point(98, 229);
            BtnHardcode.Name = "BtnHardcode";
            BtnHardcode.Size = new Size(132, 55);
            BtnHardcode.TabIndex = 14;
            BtnHardcode.Text = "Hardcodeo";
            BtnHardcode.UseVisualStyleBackColor = false;
            BtnHardcode.Click += BtnHardcode_Click;
            // 
            // lblFactory
            // 
            lblFactory.AutoSize = true;
            lblFactory.BackColor = Color.Transparent;
            lblFactory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblFactory.ForeColor = Color.Coral;
            lblFactory.Location = new Point(252, 254);
            lblFactory.Name = "lblFactory";
            lblFactory.Size = new Size(87, 21);
            lblFactory.TabIndex = 15;
            lblFactory.Text = "Factory.IO";
            lblFactory.TextAlign = ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(lblNombre);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(lblApellido);
            groupBox1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            groupBox1.ForeColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(27, 76);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(239, 131);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Personales";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(cboxCargo);
            groupBox2.Controls.Add(lblCargo);
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Controls.Add(lblContraseña);
            groupBox2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(295, 76);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(264, 131);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Puesto";
            // 
            // FrmLobby
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PapayaWhip;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(592, 308);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblFactory);
            Controls.Add(BtnHardcode);
            Controls.Add(BtnIngresar);
            Controls.Add(lblLobby);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLobby";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lobby";
            FormClosing += FrmLobby_FormClosing;
            Load += FrmLobby_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtApellido;
        private Label lblLobby;
        private Label lblNombre;
        private Label lblApellido;
        private TextBox txtPassword;
        private Label lblCargo;
        private Label lblContraseña;
        private ComboBox cboxCargo;
        private Button BtnIngresar;
        private Button BtnHardcode;
        private Label lblFactory;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}