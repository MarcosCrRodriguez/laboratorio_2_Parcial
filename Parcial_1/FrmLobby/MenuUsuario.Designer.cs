namespace FrmLobby
{
    partial class MenuUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuUsuario));
            BtnVideoCard = new Button();
            BtnMotherboard = new Button();
            BtnRam = new Button();
            BtnCabinet = new Button();
            lblVideo = new Label();
            lblMoth = new Label();
            lblRam = new Label();
            lblCabinet = new Label();
            gboxUsuario = new GroupBox();
            txtNombre = new TextBox();
            BtnRegistro = new Button();
            BtnBackSu = new Button();
            BtnConfig = new Button();
            gboxSectores = new GroupBox();
            label16 = new Label();
            txtBoxCantCabinet = new TextBox();
            txtBoxCantRam = new TextBox();
            txtBoxCantMotherboard = new TextBox();
            txtBoxCantVideoCard = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            gboxMateriales = new GroupBox();
            BtnReStock = new Button();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label5 = new Label();
            label7 = new Label();
            label6 = new Label();
            txtVentilador = new TextBox();
            txtCondensador = new TextBox();
            txtFibtaVidrio = new TextBox();
            txtEngranajeHierro = new TextBox();
            txtBaraHierro = new TextBox();
            txtCableRojo = new TextBox();
            txtCableVerde = new TextBox();
            txtBarraPlastica = new TextBox();
            txtUniProcesamiento = new TextBox();
            txtCircuitoElectAv = new TextBox();
            txtCircuitoElect = new TextBox();
            lblFactory = new Label();
            gboxUsuario.SuspendLayout();
            gboxSectores.SuspendLayout();
            gboxMateriales.SuspendLayout();
            SuspendLayout();
            // 
            // BtnVideoCard
            // 
            BtnVideoCard.BackColor = Color.Gray;
            BtnVideoCard.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnVideoCard.Location = new Point(167, 52);
            BtnVideoCard.Name = "BtnVideoCard";
            BtnVideoCard.Size = new Size(88, 46);
            BtnVideoCard.TabIndex = 7;
            BtnVideoCard.Text = "------>";
            BtnVideoCard.UseVisualStyleBackColor = false;
            BtnVideoCard.Click += BtnVideoCard_Click;
            // 
            // BtnMotherboard
            // 
            BtnMotherboard.BackColor = Color.Gray;
            BtnMotherboard.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnMotherboard.Location = new Point(167, 118);
            BtnMotherboard.Name = "BtnMotherboard";
            BtnMotherboard.Size = new Size(88, 46);
            BtnMotherboard.TabIndex = 8;
            BtnMotherboard.Text = "------>";
            BtnMotherboard.UseVisualStyleBackColor = false;
            BtnMotherboard.Click += BtnMotherboard_Click;
            // 
            // BtnRam
            // 
            BtnRam.BackColor = Color.Gray;
            BtnRam.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnRam.ImageAlign = ContentAlignment.MiddleRight;
            BtnRam.Location = new Point(167, 189);
            BtnRam.Name = "BtnRam";
            BtnRam.Size = new Size(88, 46);
            BtnRam.TabIndex = 9;
            BtnRam.Text = "------>";
            BtnRam.UseVisualStyleBackColor = false;
            BtnRam.Click += BtnRam_Click;
            // 
            // BtnCabinet
            // 
            BtnCabinet.BackColor = Color.Gray;
            BtnCabinet.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnCabinet.Location = new Point(167, 258);
            BtnCabinet.Name = "BtnCabinet";
            BtnCabinet.Size = new Size(88, 46);
            BtnCabinet.TabIndex = 10;
            BtnCabinet.Text = "------>";
            BtnCabinet.UseVisualStyleBackColor = false;
            BtnCabinet.Click += BtnCabinet_Click;
            // 
            // lblVideo
            // 
            lblVideo.AutoSize = true;
            lblVideo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblVideo.Location = new Point(6, 33);
            lblVideo.Name = "lblVideo";
            lblVideo.Size = new Size(107, 25);
            lblVideo.TabIndex = 11;
            lblVideo.Text = "Video Card";
            lblVideo.Click += LblVideo_Click;
            // 
            // lblMoth
            // 
            lblMoth.AutoSize = true;
            lblMoth.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblMoth.Location = new Point(6, 106);
            lblMoth.Name = "lblMoth";
            lblMoth.Size = new Size(125, 25);
            lblMoth.TabIndex = 12;
            lblMoth.Text = "Motherboard";
            lblMoth.Click += LblMoth_Click;
            // 
            // lblRam
            // 
            lblRam.AutoSize = true;
            lblRam.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblRam.Location = new Point(6, 174);
            lblRam.Name = "lblRam";
            lblRam.Size = new Size(52, 25);
            lblRam.TabIndex = 13;
            lblRam.Text = "Ram";
            lblRam.Click += LblRam_Click;
            // 
            // lblCabinet
            // 
            lblCabinet.AutoSize = true;
            lblCabinet.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblCabinet.Location = new Point(6, 243);
            lblCabinet.Name = "lblCabinet";
            lblCabinet.Size = new Size(79, 25);
            lblCabinet.TabIndex = 14;
            lblCabinet.Text = "Cabinet";
            lblCabinet.Click += LblCabinet_Click;
            // 
            // gboxUsuario
            // 
            gboxUsuario.BackColor = Color.Transparent;
            gboxUsuario.Controls.Add(txtNombre);
            gboxUsuario.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            gboxUsuario.ForeColor = SystemColors.ButtonHighlight;
            gboxUsuario.Location = new Point(12, 12);
            gboxUsuario.Name = "gboxUsuario";
            gboxUsuario.Size = new Size(203, 78);
            gboxUsuario.TabIndex = 17;
            gboxUsuario.TabStop = false;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(15, 29);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(166, 29);
            txtNombre.TabIndex = 14;
            // 
            // BtnRegistro
            // 
            BtnRegistro.BackColor = Color.Bisque;
            BtnRegistro.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnRegistro.Location = new Point(388, 368);
            BtnRegistro.Name = "BtnRegistro";
            BtnRegistro.Size = new Size(149, 47);
            BtnRegistro.TabIndex = 18;
            BtnRegistro.Text = "Registro operarios";
            BtnRegistro.UseVisualStyleBackColor = false;
            BtnRegistro.Click += BtnRegistro_Click;
            // 
            // BtnBackSu
            // 
            BtnBackSu.BackColor = Color.BurlyWood;
            BtnBackSu.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnBackSu.Location = new Point(565, 361);
            BtnBackSu.Name = "BtnBackSu";
            BtnBackSu.Size = new Size(127, 58);
            BtnBackSu.TabIndex = 19;
            BtnBackSu.Text = "Back to Login";
            BtnBackSu.UseVisualStyleBackColor = false;
            BtnBackSu.Click += BtnBackSu_Click_1;
            // 
            // BtnConfig
            // 
            BtnConfig.BackColor = SystemColors.ActiveCaption;
            BtnConfig.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnConfig.Location = new Point(12, 350);
            BtnConfig.Name = "BtnConfig";
            BtnConfig.Size = new Size(106, 69);
            BtnConfig.TabIndex = 20;
            BtnConfig.Text = "Configuration personal data";
            BtnConfig.UseVisualStyleBackColor = false;
            BtnConfig.Click += BtnConfig_Click_1;
            // 
            // gboxSectores
            // 
            gboxSectores.BackColor = Color.Transparent;
            gboxSectores.Controls.Add(label16);
            gboxSectores.Controls.Add(txtBoxCantCabinet);
            gboxSectores.Controls.Add(txtBoxCantRam);
            gboxSectores.Controls.Add(txtBoxCantMotherboard);
            gboxSectores.Controls.Add(txtBoxCantVideoCard);
            gboxSectores.Controls.Add(label4);
            gboxSectores.Controls.Add(label3);
            gboxSectores.Controls.Add(label2);
            gboxSectores.Controls.Add(label1);
            gboxSectores.Controls.Add(BtnVideoCard);
            gboxSectores.Controls.Add(lblVideo);
            gboxSectores.Controls.Add(BtnMotherboard);
            gboxSectores.Controls.Add(lblMoth);
            gboxSectores.Controls.Add(BtnRam);
            gboxSectores.Controls.Add(lblCabinet);
            gboxSectores.Controls.Add(lblRam);
            gboxSectores.Controls.Add(BtnCabinet);
            gboxSectores.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            gboxSectores.ForeColor = SystemColors.ButtonHighlight;
            gboxSectores.Location = new Point(424, 12);
            gboxSectores.Name = "gboxSectores";
            gboxSectores.Size = new Size(268, 332);
            gboxSectores.TabIndex = 21;
            gboxSectores.TabStop = false;
            gboxSectores.Text = "Sectores Trabajo";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(176, 25);
            label16.Name = "label16";
            label16.Size = new Size(69, 21);
            label16.TabIndex = 23;
            label16.Text = "Ingresar";
            // 
            // txtBoxCantCabinet
            // 
            txtBoxCantCabinet.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            txtBoxCantCabinet.Location = new Point(106, 271);
            txtBoxCantCabinet.Name = "txtBoxCantCabinet";
            txtBoxCantCabinet.Size = new Size(55, 27);
            txtBoxCantCabinet.TabIndex = 22;
            // 
            // txtBoxCantRam
            // 
            txtBoxCantRam.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            txtBoxCantRam.Location = new Point(106, 202);
            txtBoxCantRam.Name = "txtBoxCantRam";
            txtBoxCantRam.Size = new Size(55, 27);
            txtBoxCantRam.TabIndex = 21;
            // 
            // txtBoxCantMotherboard
            // 
            txtBoxCantMotherboard.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            txtBoxCantMotherboard.Location = new Point(106, 131);
            txtBoxCantMotherboard.Name = "txtBoxCantMotherboard";
            txtBoxCantMotherboard.Size = new Size(55, 27);
            txtBoxCantMotherboard.TabIndex = 20;
            // 
            // txtBoxCantVideoCard
            // 
            txtBoxCantVideoCard.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            txtBoxCantVideoCard.Location = new Point(106, 65);
            txtBoxCantVideoCard.Name = "txtBoxCantVideoCard";
            txtBoxCantVideoCard.Size = new Size(55, 27);
            txtBoxCantVideoCard.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 273);
            label4.Name = "label4";
            label4.Size = new Size(94, 21);
            label4.TabIndex = 18;
            label4.Text = "cantidad ->";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 204);
            label3.Name = "label3";
            label3.Size = new Size(94, 21);
            label3.TabIndex = 17;
            label3.Text = "cantidad ->";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 133);
            label2.Name = "label2";
            label2.Size = new Size(94, 21);
            label2.TabIndex = 16;
            label2.Text = "cantidad ->";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 67);
            label1.Name = "label1";
            label1.Size = new Size(94, 21);
            label1.TabIndex = 15;
            label1.Text = "cantidad ->";
            // 
            // gboxMateriales
            // 
            gboxMateriales.BackColor = Color.Transparent;
            gboxMateriales.Controls.Add(BtnReStock);
            gboxMateriales.Controls.Add(label15);
            gboxMateriales.Controls.Add(label14);
            gboxMateriales.Controls.Add(label13);
            gboxMateriales.Controls.Add(label12);
            gboxMateriales.Controls.Add(label11);
            gboxMateriales.Controls.Add(label10);
            gboxMateriales.Controls.Add(label9);
            gboxMateriales.Controls.Add(label8);
            gboxMateriales.Controls.Add(label5);
            gboxMateriales.Controls.Add(label7);
            gboxMateriales.Controls.Add(label6);
            gboxMateriales.Controls.Add(txtVentilador);
            gboxMateriales.Controls.Add(txtCondensador);
            gboxMateriales.Controls.Add(txtFibtaVidrio);
            gboxMateriales.Controls.Add(txtEngranajeHierro);
            gboxMateriales.Controls.Add(txtBaraHierro);
            gboxMateriales.Controls.Add(txtCableRojo);
            gboxMateriales.Controls.Add(txtCableVerde);
            gboxMateriales.Controls.Add(txtBarraPlastica);
            gboxMateriales.Controls.Add(txtUniProcesamiento);
            gboxMateriales.Controls.Add(txtCircuitoElectAv);
            gboxMateriales.Controls.Add(txtCircuitoElect);
            gboxMateriales.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            gboxMateriales.ForeColor = SystemColors.ButtonHighlight;
            gboxMateriales.Location = new Point(15, 96);
            gboxMateriales.Name = "gboxMateriales";
            gboxMateriales.Size = new Size(392, 248);
            gboxMateriales.TabIndex = 24;
            gboxMateriales.TabStop = false;
            gboxMateriales.Text = "Cantidad Materiales";
            // 
            // BtnReStock
            // 
            BtnReStock.BackColor = Color.Gray;
            BtnReStock.Location = new Point(240, 210);
            BtnReStock.Name = "BtnReStock";
            BtnReStock.Size = new Size(121, 25);
            BtnReStock.TabIndex = 25;
            BtnReStock.Text = "-- Re Stock --";
            BtnReStock.UseVisualStyleBackColor = false;
            BtnReStock.Click += BtnReStock_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(226, 179);
            label15.Name = "label15";
            label15.Size = new Size(64, 15);
            label15.TabIndex = 35;
            label15.Text = "Ventilador";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(210, 139);
            label14.Name = "label14";
            label14.Size = new Size(80, 15);
            label14.TabIndex = 34;
            label14.Text = "Condensador";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(219, 101);
            label13.Name = "label13";
            label13.Size = new Size(71, 15);
            label13.TabIndex = 33;
            label13.Text = "Fibra Vidrio";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(190, 63);
            label12.Name = "label12";
            label12.Size = new Size(100, 15);
            label12.TabIndex = 32;
            label12.Text = "Engranaje Hierro";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(219, 25);
            label11.Name = "label11";
            label11.Size = new Size(71, 15);
            label11.TabIndex = 31;
            label11.Text = "Bara Hierro";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(35, 214);
            label10.Name = "label10";
            label10.Size = new Size(65, 15);
            label10.TabIndex = 30;
            label10.Text = "Cable Rojo";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(27, 176);
            label9.Name = "label9";
            label9.Size = new Size(73, 15);
            label9.TabIndex = 29;
            label9.Text = "Cable Verde";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 139);
            label8.Name = "label8";
            label8.Size = new Size(82, 15);
            label8.TabIndex = 28;
            label8.Text = "Barra Plascito";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 25);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 27;
            label5.Text = "Circuito Elect";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 101);
            label7.Name = "label7";
            label7.Size = new Size(92, 15);
            label7.TabIndex = 26;
            label7.Text = "U Procesaminto";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 63);
            label6.Name = "label6";
            label6.Size = new Size(93, 15);
            label6.TabIndex = 25;
            label6.Text = "Circuito Elect Av";
            // 
            // txtVentilador
            // 
            txtVentilador.Location = new Point(296, 173);
            txtVentilador.Name = "txtVentilador";
            txtVentilador.Size = new Size(81, 24);
            txtVentilador.TabIndex = 10;
            // 
            // txtCondensador
            // 
            txtCondensador.Location = new Point(296, 136);
            txtCondensador.Name = "txtCondensador";
            txtCondensador.Size = new Size(81, 24);
            txtCondensador.TabIndex = 9;
            // 
            // txtFibtaVidrio
            // 
            txtFibtaVidrio.Location = new Point(296, 98);
            txtFibtaVidrio.Name = "txtFibtaVidrio";
            txtFibtaVidrio.Size = new Size(81, 24);
            txtFibtaVidrio.TabIndex = 8;
            // 
            // txtEngranajeHierro
            // 
            txtEngranajeHierro.Location = new Point(296, 60);
            txtEngranajeHierro.Name = "txtEngranajeHierro";
            txtEngranajeHierro.Size = new Size(81, 24);
            txtEngranajeHierro.TabIndex = 7;
            // 
            // txtBaraHierro
            // 
            txtBaraHierro.Location = new Point(296, 22);
            txtBaraHierro.Name = "txtBaraHierro";
            txtBaraHierro.Size = new Size(81, 24);
            txtBaraHierro.TabIndex = 6;
            // 
            // txtCableRojo
            // 
            txtCableRojo.Location = new Point(106, 211);
            txtCableRojo.Name = "txtCableRojo";
            txtCableRojo.Size = new Size(81, 24);
            txtCableRojo.TabIndex = 5;
            // 
            // txtCableVerde
            // 
            txtCableVerde.Location = new Point(106, 173);
            txtCableVerde.Name = "txtCableVerde";
            txtCableVerde.Size = new Size(81, 24);
            txtCableVerde.TabIndex = 4;
            // 
            // txtBarraPlastica
            // 
            txtBarraPlastica.Location = new Point(106, 136);
            txtBarraPlastica.Name = "txtBarraPlastica";
            txtBarraPlastica.Size = new Size(81, 24);
            txtBarraPlastica.TabIndex = 3;
            // 
            // txtUniProcesamiento
            // 
            txtUniProcesamiento.Location = new Point(106, 98);
            txtUniProcesamiento.Name = "txtUniProcesamiento";
            txtUniProcesamiento.Size = new Size(81, 24);
            txtUniProcesamiento.TabIndex = 2;
            // 
            // txtCircuitoElectAv
            // 
            txtCircuitoElectAv.Location = new Point(106, 60);
            txtCircuitoElectAv.Name = "txtCircuitoElectAv";
            txtCircuitoElectAv.Size = new Size(81, 24);
            txtCircuitoElectAv.TabIndex = 1;
            // 
            // txtCircuitoElect
            // 
            txtCircuitoElect.Location = new Point(106, 22);
            txtCircuitoElect.Name = "txtCircuitoElect";
            txtCircuitoElect.Size = new Size(81, 24);
            txtCircuitoElect.TabIndex = 0;
            // 
            // lblFactory
            // 
            lblFactory.AutoSize = true;
            lblFactory.BackColor = Color.Transparent;
            lblFactory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblFactory.ForeColor = Color.Coral;
            lblFactory.Location = new Point(280, 41);
            lblFactory.Name = "lblFactory";
            lblFactory.Size = new Size(87, 21);
            lblFactory.TabIndex = 25;
            lblFactory.Text = "Factory.IO";
            lblFactory.TextAlign = ContentAlignment.TopCenter;
            // 
            // MenuUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(704, 431);
            ControlBox = false;
            Controls.Add(lblFactory);
            Controls.Add(gboxMateriales);
            Controls.Add(gboxSectores);
            Controls.Add(BtnConfig);
            Controls.Add(BtnBackSu);
            Controls.Add(BtnRegistro);
            Controls.Add(gboxUsuario);
            MaximizeBox = false;
            Name = "MenuUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Usuario";
            Load += MenuSu_Load;
            gboxUsuario.ResumeLayout(false);
            gboxUsuario.PerformLayout();
            gboxSectores.ResumeLayout(false);
            gboxSectores.PerformLayout();
            gboxMateriales.ResumeLayout(false);
            gboxMateriales.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BtnVideoCard;
        private Button BtnMotherboard;
        private Button BtnRam;
        private Button BtnCabinet;
        private Label lblVideo;
        private Label lblMoth;
        private Label lblRam;
        private Label lblCabinet;
        private GroupBox gboxUsuario;
        private TextBox txtNombre;
        private Button BtnRegistro;
        private Button BtnBackSu;
        private Button BtnConfig;
        private GroupBox gboxSectores;
        private GroupBox gboxMateriales;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label5;
        private Label label7;
        private Label label6;
        private TextBox txtVentilador;
        private TextBox txtCondensador;
        private TextBox txtFibtaVidrio;
        private TextBox txtEngranajeHierro;
        private TextBox txtBaraHierro;
        private TextBox txtCableRojo;
        private TextBox txtCableVerde;
        private TextBox txtBarraPlastica;
        private TextBox txtUniProcesamiento;
        private TextBox txtCircuitoElectAv;
        private TextBox txtCircuitoElect;
        private Button BtnReStock;
        private Label lblFactory;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtBoxCantCabinet;
        private TextBox txtBoxCantRam;
        private TextBox txtBoxCantMotherboard;
        private TextBox txtBoxCantVideoCard;
        private Label label16;
    }
}