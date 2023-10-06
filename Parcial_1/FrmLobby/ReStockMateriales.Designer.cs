﻿namespace FrmLobby
{
    partial class FrmReStockMateriales
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
            gboxMateriales = new GroupBox();
            BtnHardcodeo = new Button();
            numVentilador = new NumericUpDown();
            numCondensador = new NumericUpDown();
            numFibraVidrio = new NumericUpDown();
            numEngranajeHierro = new NumericUpDown();
            numBaraHierro = new NumericUpDown();
            numCableRojo = new NumericUpDown();
            numCableVerde = new NumericUpDown();
            numBarraPlastica = new NumericUpDown();
            numUnProcesamiento = new NumericUpDown();
            numCircuitoElectAv = new NumericUpDown();
            numCircuitoElect = new NumericUpDown();
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
            BtnBackWindow = new Button();
            lblFactory = new Label();
            BtnLoad = new Button();
            gboxMateriales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numVentilador).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCondensador).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFibraVidrio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEngranajeHierro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBaraHierro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCableRojo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCableVerde).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBarraPlastica).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numUnProcesamiento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCircuitoElectAv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCircuitoElect).BeginInit();
            SuspendLayout();
            // 
            // gboxMateriales
            // 
            gboxMateriales.BackColor = Color.Transparent;
            gboxMateriales.Controls.Add(BtnHardcodeo);
            gboxMateriales.Controls.Add(numVentilador);
            gboxMateriales.Controls.Add(numCondensador);
            gboxMateriales.Controls.Add(numFibraVidrio);
            gboxMateriales.Controls.Add(numEngranajeHierro);
            gboxMateriales.Controls.Add(numBaraHierro);
            gboxMateriales.Controls.Add(numCableRojo);
            gboxMateriales.Controls.Add(numCableVerde);
            gboxMateriales.Controls.Add(numBarraPlastica);
            gboxMateriales.Controls.Add(numUnProcesamiento);
            gboxMateriales.Controls.Add(numCircuitoElectAv);
            gboxMateriales.Controls.Add(numCircuitoElect);
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
            gboxMateriales.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            gboxMateriales.ForeColor = SystemColors.ButtonHighlight;
            gboxMateriales.Location = new Point(12, 12);
            gboxMateriales.Name = "gboxMateriales";
            gboxMateriales.Size = new Size(433, 284);
            gboxMateriales.TabIndex = 24;
            gboxMateriales.TabStop = false;
            gboxMateriales.Text = "Cantidad materiales a agregar";
            // 
            // BtnHardcodeo
            // 
            BtnHardcodeo.ForeColor = Color.Gray;
            BtnHardcodeo.Location = new Point(256, 242);
            BtnHardcodeo.Name = "BtnHardcodeo";
            BtnHardcodeo.Size = new Size(119, 27);
            BtnHardcodeo.TabIndex = 46;
            BtnHardcodeo.Text = "Hardcodear";
            BtnHardcodeo.UseVisualStyleBackColor = true;
            BtnHardcodeo.Click += BtnHardcodeo_Click;
            // 
            // numVentilador
            // 
            numVentilador.Location = new Point(337, 199);
            numVentilador.Maximum = new decimal(new int[] { 45000, 0, 0, 0 });
            numVentilador.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numVentilador.Name = "numVentilador";
            numVentilador.Size = new Size(81, 25);
            numVentilador.TabIndex = 45;
            // 
            // numCondensador
            // 
            numCondensador.Location = new Point(337, 155);
            numCondensador.Maximum = new decimal(new int[] { 45000, 0, 0, 0 });
            numCondensador.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numCondensador.Name = "numCondensador";
            numCondensador.Size = new Size(81, 25);
            numCondensador.TabIndex = 44;
            // 
            // numFibraVidrio
            // 
            numFibraVidrio.Location = new Point(337, 111);
            numFibraVidrio.Maximum = new decimal(new int[] { 45000, 0, 0, 0 });
            numFibraVidrio.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numFibraVidrio.Name = "numFibraVidrio";
            numFibraVidrio.Size = new Size(81, 25);
            numFibraVidrio.TabIndex = 43;
            // 
            // numEngranajeHierro
            // 
            numEngranajeHierro.Location = new Point(337, 66);
            numEngranajeHierro.Maximum = new decimal(new int[] { 45000, 0, 0, 0 });
            numEngranajeHierro.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numEngranajeHierro.Name = "numEngranajeHierro";
            numEngranajeHierro.Size = new Size(81, 25);
            numEngranajeHierro.TabIndex = 42;
            // 
            // numBaraHierro
            // 
            numBaraHierro.Location = new Point(337, 23);
            numBaraHierro.Maximum = new decimal(new int[] { 45000, 0, 0, 0 });
            numBaraHierro.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numBaraHierro.Name = "numBaraHierro";
            numBaraHierro.Size = new Size(81, 25);
            numBaraHierro.TabIndex = 41;
            // 
            // numCableRojo
            // 
            numCableRojo.Location = new Point(124, 244);
            numCableRojo.Maximum = new decimal(new int[] { 45000, 0, 0, 0 });
            numCableRojo.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numCableRojo.Name = "numCableRojo";
            numCableRojo.Size = new Size(81, 25);
            numCableRojo.TabIndex = 40;
            // 
            // numCableVerde
            // 
            numCableVerde.Location = new Point(124, 199);
            numCableVerde.Maximum = new decimal(new int[] { 45000, 0, 0, 0 });
            numCableVerde.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numCableVerde.Name = "numCableVerde";
            numCableVerde.Size = new Size(81, 25);
            numCableVerde.TabIndex = 39;
            // 
            // numBarraPlastica
            // 
            numBarraPlastica.Location = new Point(124, 155);
            numBarraPlastica.Maximum = new decimal(new int[] { 45000, 0, 0, 0 });
            numBarraPlastica.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numBarraPlastica.Name = "numBarraPlastica";
            numBarraPlastica.Size = new Size(81, 25);
            numBarraPlastica.TabIndex = 38;
            // 
            // numUnProcesamiento
            // 
            numUnProcesamiento.Location = new Point(124, 111);
            numUnProcesamiento.Maximum = new decimal(new int[] { 45000, 0, 0, 0 });
            numUnProcesamiento.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numUnProcesamiento.Name = "numUnProcesamiento";
            numUnProcesamiento.Size = new Size(81, 25);
            numUnProcesamiento.TabIndex = 37;
            // 
            // numCircuitoElectAv
            // 
            numCircuitoElectAv.Location = new Point(124, 68);
            numCircuitoElectAv.Maximum = new decimal(new int[] { 45000, 0, 0, 0 });
            numCircuitoElectAv.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numCircuitoElectAv.Name = "numCircuitoElectAv";
            numCircuitoElectAv.Size = new Size(81, 25);
            numCircuitoElectAv.TabIndex = 36;
            // 
            // numCircuitoElect
            // 
            numCircuitoElect.Location = new Point(124, 22);
            numCircuitoElect.Maximum = new decimal(new int[] { 45000, 0, 0, 0 });
            numCircuitoElect.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numCircuitoElect.Name = "numCircuitoElect";
            numCircuitoElect.Size = new Size(81, 25);
            numCircuitoElect.TabIndex = 28;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(256, 199);
            label15.Name = "label15";
            label15.Size = new Size(75, 19);
            label15.TabIndex = 35;
            label15.Text = "Ventilador";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(239, 157);
            label14.Name = "label14";
            label14.Size = new Size(92, 19);
            label14.TabIndex = 34;
            label14.Text = "Condensador";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(248, 113);
            label13.Name = "label13";
            label13.Size = new Size(83, 19);
            label13.TabIndex = 33;
            label13.Text = "Fibra Vidrio";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(216, 68);
            label12.Name = "label12";
            label12.Size = new Size(115, 19);
            label12.TabIndex = 32;
            label12.Text = "Engranaje Hierro";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(249, 25);
            label11.Name = "label11";
            label11.Size = new Size(82, 19);
            label11.TabIndex = 31;
            label11.Text = "Bara Hierro";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(40, 246);
            label10.Name = "label10";
            label10.Size = new Size(78, 19);
            label10.TabIndex = 30;
            label10.Text = "Cable Rojo";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(33, 199);
            label9.Name = "label9";
            label9.Size = new Size(85, 19);
            label9.TabIndex = 29;
            label9.Text = "Cable Verde";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 157);
            label8.Name = "label8";
            label8.Size = new Size(97, 19);
            label8.TabIndex = 28;
            label8.Text = "Barra Plascito";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 25);
            label5.Name = "label5";
            label5.Size = new Size(91, 19);
            label5.TabIndex = 27;
            label5.Text = "Circuito Elect";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 113);
            label7.Name = "label7";
            label7.Size = new Size(108, 19);
            label7.TabIndex = 26;
            label7.Text = "U Procesaminto";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 68);
            label6.Name = "label6";
            label6.Size = new Size(111, 19);
            label6.TabIndex = 25;
            label6.Text = "Circuito Elect Av";
            // 
            // BtnBackWindow
            // 
            BtnBackWindow.BackColor = Color.BurlyWood;
            BtnBackWindow.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnBackWindow.Location = new Point(453, 237);
            BtnBackWindow.Name = "BtnBackWindow";
            BtnBackWindow.Size = new Size(127, 58);
            BtnBackWindow.TabIndex = 25;
            BtnBackWindow.Text = "Back to Window";
            BtnBackWindow.UseVisualStyleBackColor = false;
            BtnBackWindow.Click += BtnBackWindow_Click;
            // 
            // lblFactory
            // 
            lblFactory.AutoSize = true;
            lblFactory.BackColor = Color.Transparent;
            lblFactory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblFactory.ForeColor = Color.Coral;
            lblFactory.Location = new Point(478, 38);
            lblFactory.Name = "lblFactory";
            lblFactory.Size = new Size(87, 21);
            lblFactory.TabIndex = 26;
            lblFactory.Text = "Factory.IO";
            lblFactory.TextAlign = ContentAlignment.TopCenter;
            // 
            // BtnLoad
            // 
            BtnLoad.BackColor = Color.MediumSeaGreen;
            BtnLoad.Location = new Point(471, 166);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(94, 43);
            BtnLoad.TabIndex = 27;
            BtnLoad.Text = "Load Materials";
            BtnLoad.UseVisualStyleBackColor = false;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // FrmReStockMateriales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.design_in_the_concept_of_electronic_circuit_boards_background_v_1517907jpg_sw800;
            ClientSize = new Size(592, 308);
            ControlBox = false;
            Controls.Add(BtnLoad);
            Controls.Add(lblFactory);
            Controls.Add(BtnBackWindow);
            Controls.Add(gboxMateriales);
            MaximizeBox = false;
            Name = "FrmReStockMateriales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReStockMateriales";
            Load += FrmReStockMateriales_Load;
            gboxMateriales.ResumeLayout(false);
            gboxMateriales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numVentilador).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCondensador).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFibraVidrio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEngranajeHierro).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBaraHierro).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCableRojo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCableVerde).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBarraPlastica).EndInit();
            ((System.ComponentModel.ISupportInitialize)numUnProcesamiento).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCircuitoElectAv).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCircuitoElect).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private Button BtnBackWindow;
        private Label lblFactory;
        private Button BtnLoad;
        private NumericUpDown numVentilador;
        private NumericUpDown numCondensador;
        private NumericUpDown numFibraVidrio;
        private NumericUpDown numEngranajeHierro;
        private NumericUpDown numBaraHierro;
        private NumericUpDown numCableRojo;
        private NumericUpDown numCableVerde;
        private NumericUpDown numBarraPlastica;
        private NumericUpDown numUnProcesamiento;
        private NumericUpDown numCircuitoElectAv;
        private NumericUpDown numCircuitoElect;
        private Button BtnHardcodeo;
    }
}