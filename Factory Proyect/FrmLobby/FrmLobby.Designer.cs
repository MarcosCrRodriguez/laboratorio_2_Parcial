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
            lblLobby = new Label();
            txtPassword = new TextBox();
            cboxCargo = new ComboBox();
            BtnIngresar = new Button();
            lblFactory = new Label();
            groupBox2 = new GroupBox();
            pctBoxNo = new PictureBox();
            pctBoxVisible = new PictureBox();
            groupBox3 = new GroupBox();
            txtCodigo = new TextBox();
            BtnRegistrar = new Button();
            groupbox4 = new GroupBox();
            lblMessage = new Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctBoxNo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctBoxVisible).BeginInit();
            groupBox3.SuspendLayout();
            groupbox4.SuspendLayout();
            SuspendLayout();
            // 
            // lblLobby
            // 
            lblLobby.AutoSize = true;
            lblLobby.BackColor = Color.Transparent;
            lblLobby.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblLobby.ForeColor = SystemColors.ButtonHighlight;
            lblLobby.Location = new Point(45, 18);
            lblLobby.Name = "lblLobby";
            lblLobby.Size = new Size(207, 40);
            lblLobby.TabIndex = 2;
            lblLobby.Text = "Lobby - Login";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(87, 33);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(146, 29);
            txtPassword.TabIndex = 5;
            // 
            // cboxCargo
            // 
            cboxCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxCargo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboxCargo.FormattingEnabled = true;
            cboxCargo.Location = new Point(18, 33);
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
            BtnIngresar.Location = new Point(365, 246);
            BtnIngresar.Name = "BtnIngresar";
            BtnIngresar.Size = new Size(120, 55);
            BtnIngresar.TabIndex = 10;
            BtnIngresar.Text = "Ingresar al sistema";
            BtnIngresar.UseVisualStyleBackColor = false;
            BtnIngresar.Click += BtnIngresar_Click;
            // 
            // lblFactory
            // 
            lblFactory.AutoSize = true;
            lblFactory.BackColor = Color.Transparent;
            lblFactory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblFactory.ForeColor = Color.Coral;
            lblFactory.Location = new Point(76, 271);
            lblFactory.Name = "lblFactory";
            lblFactory.Size = new Size(87, 21);
            lblFactory.TabIndex = 15;
            lblFactory.Text = "Factory.IO";
            lblFactory.TextAlign = ContentAlignment.TopCenter;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(pctBoxNo);
            groupBox2.Controls.Add(pctBoxVisible);
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(239, 79);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(246, 78);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Password";
            // 
            // pctBoxNo
            // 
            pctBoxNo.Image = (Image)resources.GetObject("pctBoxNo.Image");
            pctBoxNo.Location = new Point(16, 24);
            pctBoxNo.Name = "pctBoxNo";
            pctBoxNo.Size = new Size(56, 48);
            pctBoxNo.SizeMode = PictureBoxSizeMode.StretchImage;
            pctBoxNo.TabIndex = 7;
            pctBoxNo.TabStop = false;
            pctBoxNo.Click += pctBoxNo_Click;
            // 
            // pctBoxVisible
            // 
            pctBoxVisible.Image = (Image)resources.GetObject("pctBoxVisible.Image");
            pctBoxVisible.Location = new Point(16, 24);
            pctBoxVisible.Name = "pctBoxVisible";
            pctBoxVisible.Size = new Size(56, 48);
            pctBoxVisible.SizeMode = PictureBoxSizeMode.StretchImage;
            pctBoxVisible.TabIndex = 6;
            pctBoxVisible.TabStop = false;
            pctBoxVisible.Click += pctBoxVisible_Click;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(txtCodigo);
            groupBox3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            groupBox3.ForeColor = SystemColors.ButtonHighlight;
            groupBox3.Location = new Point(27, 79);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(177, 78);
            groupBox3.TabIndex = 18;
            groupBox3.TabStop = false;
            groupBox3.Text = "Código Usuario";
            // 
            // txtCodigo
            // 
            txtCodigo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCodigo.Location = new Point(18, 33);
            txtCodigo.Multiline = true;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(146, 29);
            txtCodigo.TabIndex = 0;
            // 
            // BtnRegistrar
            // 
            BtnRegistrar.BackColor = Color.DarkGray;
            BtnRegistrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnRegistrar.Location = new Point(229, 246);
            BtnRegistrar.Name = "BtnRegistrar";
            BtnRegistrar.Size = new Size(111, 55);
            BtnRegistrar.TabIndex = 15;
            BtnRegistrar.Text = "Registrar";
            BtnRegistrar.UseVisualStyleBackColor = false;
            BtnRegistrar.Click += BtnRegistrar_Click;
            // 
            // groupbox4
            // 
            groupbox4.BackColor = Color.Transparent;
            groupbox4.Controls.Add(cboxCargo);
            groupbox4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupbox4.ForeColor = SystemColors.ButtonHighlight;
            groupbox4.Location = new Point(27, 172);
            groupbox4.Name = "groupbox4";
            groupbox4.Size = new Size(177, 79);
            groupbox4.TabIndex = 19;
            groupbox4.TabStop = false;
            groupbox4.Text = "Cargo";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.ForeColor = SystemColors.ButtonHighlight;
            lblMessage.Location = new Point(239, 172);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(198, 17);
            lblMessage.TabIndex = 20;
            lblMessage.Text = "Esperando el ingreso de datos...";
            // 
            // FrmLobby
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PapayaWhip;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(510, 321);
            Controls.Add(lblMessage);
            Controls.Add(groupbox4);
            Controls.Add(BtnRegistrar);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(lblFactory);
            Controls.Add(BtnIngresar);
            Controls.Add(lblLobby);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLobby";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lobby";
            FormClosing += FrmLobby_FormClosing;
            Load += FrmLobby_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctBoxNo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctBoxVisible).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupbox4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblLobby;
        private TextBox txtPassword;
        private ComboBox cboxCargo;
        private Button BtnIngresar;
        private Label lblFactory;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox txtCodigo;
        private Button BtnRegistrar;
        private GroupBox groupbox4;
        private Label lblMessage;
        private PictureBox pctBoxVisible;
        private PictureBox pctBoxNo;
    }
}