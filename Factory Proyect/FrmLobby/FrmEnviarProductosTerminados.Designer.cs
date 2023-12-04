namespace FrmLobby
{
    partial class FrmEnviarProductosTerminados
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
            lblExportacion = new Label();
            gBoxProductosTerminados = new GroupBox();
            lblCabinet = new Label();
            lblRam = new Label();
            lblMotherboard = new Label();
            lblVideoCard = new Label();
            txtCabinet = new TextBox();
            txtRam = new TextBox();
            txtMotherboard = new TextBox();
            txtVideoCard = new TextBox();
            lblID = new Label();
            txtIDProducto = new TextBox();
            lblMaterialesEnviar = new Label();
            txtMaterialSet = new TextBox();
            lblCantidadEnviar = new Label();
            numCantAgregar = new NumericUpDown();
            BtnLoad = new Button();
            BtnBackWindow = new Button();
            lblFactory = new Label();
            lblMessage = new Label();
            lblHelp = new Label();
            gBoxProductosTerminados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantAgregar).BeginInit();
            SuspendLayout();
            // 
            // lblExportacion
            // 
            lblExportacion.AutoSize = true;
            lblExportacion.BackColor = Color.Transparent;
            lblExportacion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblExportacion.ForeColor = SystemColors.ButtonHighlight;
            lblExportacion.Location = new Point(12, 9);
            lblExportacion.Name = "lblExportacion";
            lblExportacion.Size = new Size(206, 21);
            lblExportacion.TabIndex = 0;
            lblExportacion.Text = "Exportación de Productos";
            // 
            // gBoxProductosTerminados
            // 
            gBoxProductosTerminados.BackColor = Color.Transparent;
            gBoxProductosTerminados.Controls.Add(lblCabinet);
            gBoxProductosTerminados.Controls.Add(lblRam);
            gBoxProductosTerminados.Controls.Add(lblMotherboard);
            gBoxProductosTerminados.Controls.Add(lblVideoCard);
            gBoxProductosTerminados.Controls.Add(txtCabinet);
            gBoxProductosTerminados.Controls.Add(txtRam);
            gBoxProductosTerminados.Controls.Add(txtMotherboard);
            gBoxProductosTerminados.Controls.Add(txtVideoCard);
            gBoxProductosTerminados.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            gBoxProductosTerminados.ForeColor = SystemColors.ButtonHighlight;
            gBoxProductosTerminados.Location = new Point(18, 46);
            gBoxProductosTerminados.Name = "gBoxProductosTerminados";
            gBoxProductosTerminados.Size = new Size(374, 116);
            gBoxProductosTerminados.TabIndex = 1;
            gBoxProductosTerminados.TabStop = false;
            gBoxProductosTerminados.Text = "Productos Terminados";
            // 
            // lblCabinet
            // 
            lblCabinet.AutoSize = true;
            lblCabinet.Location = new Point(199, 77);
            lblCabinet.Name = "lblCabinet";
            lblCabinet.Size = new Size(49, 15);
            lblCabinet.TabIndex = 7;
            lblCabinet.Text = "Cabinet";
            lblCabinet.Click += lblCabinet_Click;
            // 
            // lblRam
            // 
            lblRam.AutoSize = true;
            lblRam.Location = new Point(26, 77);
            lblRam.Name = "lblRam";
            lblRam.Size = new Size(32, 15);
            lblRam.TabIndex = 6;
            lblRam.Text = "Ram";
            lblRam.Click += lblRam_Click;
            // 
            // lblMotherboard
            // 
            lblMotherboard.AutoSize = true;
            lblMotherboard.Location = new Point(182, 28);
            lblMotherboard.Name = "lblMotherboard";
            lblMotherboard.Size = new Size(79, 15);
            lblMotherboard.TabIndex = 5;
            lblMotherboard.Text = "Motherboard";
            lblMotherboard.Click += lblMotherboard_Click;
            // 
            // lblVideoCard
            // 
            lblVideoCard.AutoSize = true;
            lblVideoCard.Location = new Point(6, 28);
            lblVideoCard.Name = "lblVideoCard";
            lblVideoCard.Size = new Size(68, 15);
            lblVideoCard.TabIndex = 4;
            lblVideoCard.Text = "Video Card";
            lblVideoCard.Click += lblVideoCard_Click;
            // 
            // txtCabinet
            // 
            txtCabinet.Location = new Point(265, 74);
            txtCabinet.Name = "txtCabinet";
            txtCabinet.Size = new Size(100, 24);
            txtCabinet.TabIndex = 3;
            // 
            // txtRam
            // 
            txtRam.Location = new Point(76, 74);
            txtRam.Name = "txtRam";
            txtRam.Size = new Size(100, 24);
            txtRam.TabIndex = 2;
            // 
            // txtMotherboard
            // 
            txtMotherboard.Location = new Point(265, 25);
            txtMotherboard.Name = "txtMotherboard";
            txtMotherboard.Size = new Size(100, 24);
            txtMotherboard.TabIndex = 1;
            // 
            // txtVideoCard
            // 
            txtVideoCard.Location = new Point(76, 25);
            txtVideoCard.Name = "txtVideoCard";
            txtVideoCard.Size = new Size(100, 24);
            txtVideoCard.TabIndex = 0;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.BackColor = Color.Transparent;
            lblID.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblID.ForeColor = SystemColors.ButtonHighlight;
            lblID.Location = new Point(418, 21);
            lblID.Name = "lblID";
            lblID.Size = new Size(95, 19);
            lblID.TabIndex = 60;
            lblID.Text = "ID Productos";
            // 
            // txtIDProducto
            // 
            txtIDProducto.Location = new Point(401, 46);
            txtIDProducto.Name = "txtIDProducto";
            txtIDProducto.Size = new Size(132, 23);
            txtIDProducto.TabIndex = 61;
            // 
            // lblMaterialesEnviar
            // 
            lblMaterialesEnviar.AutoSize = true;
            lblMaterialesEnviar.BackColor = Color.Transparent;
            lblMaterialesEnviar.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblMaterialesEnviar.ForeColor = SystemColors.ButtonHighlight;
            lblMaterialesEnviar.Location = new Point(401, 86);
            lblMaterialesEnviar.Name = "lblMaterialesEnviar";
            lblMaterialesEnviar.Size = new Size(123, 19);
            lblMaterialesEnviar.TabIndex = 62;
            lblMaterialesEnviar.Text = "Material a enviar";
            // 
            // txtMaterialSet
            // 
            txtMaterialSet.Location = new Point(401, 108);
            txtMaterialSet.Name = "txtMaterialSet";
            txtMaterialSet.Size = new Size(132, 23);
            txtMaterialSet.TabIndex = 63;
            // 
            // lblCantidadEnviar
            // 
            lblCantidadEnviar.AutoSize = true;
            lblCantidadEnviar.BackColor = Color.Transparent;
            lblCantidadEnviar.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblCantidadEnviar.ForeColor = SystemColors.ButtonHighlight;
            lblCantidadEnviar.Location = new Point(401, 143);
            lblCantidadEnviar.Name = "lblCantidadEnviar";
            lblCantidadEnviar.Size = new Size(127, 19);
            lblCantidadEnviar.TabIndex = 64;
            lblCantidadEnviar.Text = "Cantidad a enviar";
            // 
            // numCantAgregar
            // 
            numCantAgregar.Location = new Point(401, 165);
            numCantAgregar.Maximum = new decimal(new int[] { 45000, 0, 0, 0 });
            numCantAgregar.Name = "numCantAgregar";
            numCantAgregar.Size = new Size(132, 23);
            numCantAgregar.TabIndex = 65;
            // 
            // BtnLoad
            // 
            BtnLoad.BackColor = Color.MediumSeaGreen;
            BtnLoad.Location = new Point(408, 203);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(116, 34);
            BtnLoad.TabIndex = 66;
            BtnLoad.Text = "Enviar Materiales";
            BtnLoad.UseVisualStyleBackColor = false;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // BtnBackWindow
            // 
            BtnBackWindow.BackColor = Color.BurlyWood;
            BtnBackWindow.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnBackWindow.Location = new Point(18, 179);
            BtnBackWindow.Name = "BtnBackWindow";
            BtnBackWindow.Size = new Size(115, 58);
            BtnBackWindow.TabIndex = 67;
            BtnBackWindow.Text = "Back to Menu";
            BtnBackWindow.UseVisualStyleBackColor = false;
            BtnBackWindow.Click += BtnBackWindow_Click;
            // 
            // lblFactory
            // 
            lblFactory.AutoSize = true;
            lblFactory.BackColor = Color.Transparent;
            lblFactory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblFactory.ForeColor = Color.Coral;
            lblFactory.Location = new Point(283, 19);
            lblFactory.Name = "lblFactory";
            lblFactory.Size = new Size(87, 21);
            lblFactory.TabIndex = 68;
            lblFactory.Text = "Factory.IO";
            lblFactory.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblMessage.ForeColor = SystemColors.ButtonHighlight;
            lblMessage.Location = new Point(139, 171);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(198, 17);
            lblMessage.TabIndex = 69;
            lblMessage.Text = "Esperando el ingreso de datos...";
            // 
            // lblHelp
            // 
            lblHelp.AutoSize = true;
            lblHelp.BackColor = Color.Transparent;
            lblHelp.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblHelp.ForeColor = SystemColors.ButtonHighlight;
            lblHelp.Location = new Point(519, 9);
            lblHelp.Name = "lblHelp";
            lblHelp.Size = new Size(25, 19);
            lblHelp.TabIndex = 70;
            lblHelp.Text = "(?)";
            // 
            // FrmEnviarProductosTerminados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RoyalBlue;
            ClientSize = new Size(547, 248);
            ControlBox = false;
            Controls.Add(lblHelp);
            Controls.Add(lblMessage);
            Controls.Add(lblFactory);
            Controls.Add(BtnBackWindow);
            Controls.Add(BtnLoad);
            Controls.Add(numCantAgregar);
            Controls.Add(lblCantidadEnviar);
            Controls.Add(txtMaterialSet);
            Controls.Add(lblMaterialesEnviar);
            Controls.Add(txtIDProducto);
            Controls.Add(lblID);
            Controls.Add(gBoxProductosTerminados);
            Controls.Add(lblExportacion);
            Name = "FrmEnviarProductosTerminados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Exportacion de Productos Terminados";
            Load += FrmEnviarProductosTerminados_Load;
            gBoxProductosTerminados.ResumeLayout(false);
            gBoxProductosTerminados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantAgregar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblExportacion;
        private GroupBox gBoxProductosTerminados;
        private Label lblCabinet;
        private Label lblRam;
        private Label lblMotherboard;
        private Label lblVideoCard;
        private TextBox txtCabinet;
        private TextBox txtRam;
        private TextBox txtMotherboard;
        private TextBox txtVideoCard;
        private Label lblID;
        private TextBox txtIDProducto;
        private Label lblMaterialesEnviar;
        private TextBox txtMaterialSet;
        private Label lblCantidadEnviar;
        private NumericUpDown numCantAgregar;
        private Button BtnLoad;
        private Button BtnBackWindow;
        private Label lblFactory;
        private Label lblMessage;
        private Label lblHelp;
    }
}