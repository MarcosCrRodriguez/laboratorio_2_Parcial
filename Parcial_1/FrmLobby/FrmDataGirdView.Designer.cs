namespace FrmLobby
{
    partial class FrmDataGirdView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataGirdView));
            BtnBackMenu = new Button();
            lblRegistro = new Label();
            lblFactory = new Label();
            DtgvRegistro = new DataGridView();
            BtnRegistrar = new Button();
            BtnModificar = new Button();
            BtnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)DtgvRegistro).BeginInit();
            SuspendLayout();
            // 
            // BtnBackMenu
            // 
            BtnBackMenu.BackColor = Color.BurlyWood;
            BtnBackMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnBackMenu.ForeColor = SystemColors.ActiveCaptionText;
            BtnBackMenu.Location = new Point(1027, 315);
            BtnBackMenu.Name = "BtnBackMenu";
            BtnBackMenu.Size = new Size(119, 53);
            BtnBackMenu.TabIndex = 1;
            BtnBackMenu.Text = "Back Menu";
            BtnBackMenu.UseVisualStyleBackColor = false;
            BtnBackMenu.Click += BtnBackMenu_Click;
            // 
            // lblRegistro
            // 
            lblRegistro.AutoSize = true;
            lblRegistro.BackColor = Color.Transparent;
            lblRegistro.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblRegistro.ForeColor = SystemColors.ButtonHighlight;
            lblRegistro.Location = new Point(22, 19);
            lblRegistro.Name = "lblRegistro";
            lblRegistro.Size = new Size(249, 37);
            lblRegistro.TabIndex = 4;
            lblRegistro.Text = "Lista de Operarios";
            // 
            // lblFactory
            // 
            lblFactory.AutoSize = true;
            lblFactory.BackColor = Color.Transparent;
            lblFactory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblFactory.ForeColor = Color.Coral;
            lblFactory.Location = new Point(728, 330);
            lblFactory.Name = "lblFactory";
            lblFactory.Size = new Size(87, 21);
            lblFactory.TabIndex = 16;
            lblFactory.Text = "Factory.IO";
            lblFactory.TextAlign = ContentAlignment.TopCenter;
            // 
            // DtgvRegistro
            // 
            DtgvRegistro.AllowUserToAddRows = false;
            DtgvRegistro.AllowUserToDeleteRows = false;
            DtgvRegistro.AllowUserToResizeColumns = false;
            DtgvRegistro.AllowUserToResizeRows = false;
            DtgvRegistro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DtgvRegistro.Location = new Point(31, 73);
            DtgvRegistro.Name = "DtgvRegistro";
            DtgvRegistro.ReadOnly = true;
            DtgvRegistro.RowTemplate.Height = 25;
            DtgvRegistro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtgvRegistro.Size = new Size(1098, 218);
            DtgvRegistro.TabIndex = 17;
            // 
            // BtnRegistrar
            // 
            BtnRegistrar.BackColor = Color.LimeGreen;
            BtnRegistrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnRegistrar.ForeColor = SystemColors.ActiveCaptionText;
            BtnRegistrar.Location = new Point(22, 315);
            BtnRegistrar.Name = "BtnRegistrar";
            BtnRegistrar.Size = new Size(132, 53);
            BtnRegistrar.TabIndex = 18;
            BtnRegistrar.Text = "Registrar";
            BtnRegistrar.UseVisualStyleBackColor = false;
            BtnRegistrar.Click += BtnRegistrar_Click;
            // 
            // BtnModificar
            // 
            BtnModificar.BackColor = Color.SandyBrown;
            BtnModificar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnModificar.ForeColor = SystemColors.ActiveCaptionText;
            BtnModificar.Location = new Point(212, 315);
            BtnModificar.Name = "BtnModificar";
            BtnModificar.Size = new Size(142, 53);
            BtnModificar.TabIndex = 19;
            BtnModificar.Text = "Modificar Datos";
            BtnModificar.UseVisualStyleBackColor = false;
            BtnModificar.Click += BtnModificar_Click;
            // 
            // BtnEliminar
            // 
            BtnEliminar.BackColor = Color.Tomato;
            BtnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnEliminar.ForeColor = SystemColors.ActiveCaptionText;
            BtnEliminar.Location = new Point(415, 315);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(136, 53);
            BtnEliminar.TabIndex = 20;
            BtnEliminar.Text = "Dar Baja Usuario";
            BtnEliminar.UseVisualStyleBackColor = false;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // FrmDataGirdView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1158, 380);
            ControlBox = false;
            Controls.Add(BtnEliminar);
            Controls.Add(BtnModificar);
            Controls.Add(BtnRegistrar);
            Controls.Add(DtgvRegistro);
            Controls.Add(lblFactory);
            Controls.Add(lblRegistro);
            Controls.Add(BtnBackMenu);
            Name = "FrmDataGirdView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dtvg Registro";
            Load += FrmDataGirdView_Load;
            ((System.ComponentModel.ISupportInitialize)DtgvRegistro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BtnBackMenu;
        private Label lblRegistro;
        private Label lblFactory;
        private DataGridView DtgvRegistro;
        private Button BtnRegistrar;
        private Button BtnModificar;
        private Button BtnEliminar;
    }
}