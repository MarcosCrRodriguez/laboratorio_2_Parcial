namespace FrmLobby
{
    partial class FrmEliminar
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            label2 = new Label();
            txtCodigoUsuario = new TextBox();
            BtnDarBaja = new Button();
            BtnBackMenu = new Button();
            lblFactory = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(160, 25);
            label1.TabIndex = 0;
            label1.Text = "Dar Baja Usuario";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(txtCodigoUsuario);
            groupBox1.Controls.Add(label2);
            groupBox1.ForeColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(12, 46);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(169, 105);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ingreso Dato";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 32);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 2;
            label2.Text = "Código Usuario";
            // 
            // txtCodigoUsuario
            // 
            txtCodigoUsuario.Location = new Point(15, 59);
            txtCodigoUsuario.Name = "txtCodigoUsuario";
            txtCodigoUsuario.Size = new Size(100, 23);
            txtCodigoUsuario.TabIndex = 2;
            // 
            // BtnDarBaja
            // 
            BtnDarBaja.BackColor = Color.Tomato;
            BtnDarBaja.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnDarBaja.ForeColor = SystemColors.ActiveCaptionText;
            BtnDarBaja.Location = new Point(12, 179);
            BtnDarBaja.Name = "BtnDarBaja";
            BtnDarBaja.Size = new Size(136, 53);
            BtnDarBaja.TabIndex = 21;
            BtnDarBaja.Text = "Dar Baja Usuario";
            BtnDarBaja.UseVisualStyleBackColor = false;
            BtnDarBaja.Click += BtnDarBaja_Click;
            // 
            // BtnBackMenu
            // 
            BtnBackMenu.BackColor = Color.BurlyWood;
            BtnBackMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnBackMenu.ForeColor = SystemColors.ActiveCaptionText;
            BtnBackMenu.Location = new Point(180, 179);
            BtnBackMenu.Name = "BtnBackMenu";
            BtnBackMenu.Size = new Size(119, 53);
            BtnBackMenu.TabIndex = 22;
            BtnBackMenu.Text = "Back Menu";
            BtnBackMenu.UseVisualStyleBackColor = false;
            BtnBackMenu.Click += BtnBackMenu_Click;
            // 
            // lblFactory
            // 
            lblFactory.AutoSize = true;
            lblFactory.BackColor = Color.Transparent;
            lblFactory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblFactory.ForeColor = Color.Coral;
            lblFactory.Location = new Point(203, 103);
            lblFactory.Name = "lblFactory";
            lblFactory.Size = new Size(87, 21);
            lblFactory.TabIndex = 23;
            lblFactory.Text = "Factory.IO";
            lblFactory.TextAlign = ContentAlignment.TopCenter;
            // 
            // FrmEliminar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.design_in_the_concept_of_electronic_circuit_boards_vector;
            ClientSize = new Size(311, 252);
            Controls.Add(lblFactory);
            Controls.Add(BtnBackMenu);
            Controls.Add(BtnDarBaja);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "FrmEliminar";
            Text = "FrmEliminar";
            Load += FrmEliminar_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtCodigoUsuario;
        private Label label2;
        private Button BtnDarBaja;
        private Button BtnBackMenu;
        private Label lblFactory;
    }
}