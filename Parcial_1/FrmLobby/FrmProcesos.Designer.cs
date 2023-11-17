namespace FrmLobby
{
    partial class FrmProcesos
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
            progressBarSoldado = new ProgressBar();
            lblSoldado = new Label();
            progressBarEnsamblado = new ProgressBar();
            lblEnsamblado = new Label();
            lblConectado = new Label();
            progressBarConectado = new ProgressBar();
            gboxProduccion = new GroupBox();
            lblTitulo = new Label();
            gboxProcesoFinal = new GroupBox();
            progressBarEmpaquetado = new ProgressBar();
            lblProcesoFinal = new Label();
            gboxProduccion.SuspendLayout();
            gboxProcesoFinal.SuspendLayout();
            SuspendLayout();
            // 
            // progressBarSoldado
            // 
            progressBarSoldado.Location = new Point(17, 56);
            progressBarSoldado.Name = "progressBarSoldado";
            progressBarSoldado.Size = new Size(645, 23);
            progressBarSoldado.TabIndex = 0;
            // 
            // lblSoldado
            // 
            lblSoldado.AutoSize = true;
            lblSoldado.Location = new Point(17, 28);
            lblSoldado.Name = "lblSoldado";
            lblSoldado.Size = new Size(63, 15);
            lblSoldado.TabIndex = 1;
            lblSoldado.Text = "lblSoldado";
            // 
            // progressBarEnsamblado
            // 
            progressBarEnsamblado.Location = new Point(17, 119);
            progressBarEnsamblado.Name = "progressBarEnsamblado";
            progressBarEnsamblado.Size = new Size(645, 23);
            progressBarEnsamblado.TabIndex = 2;
            // 
            // lblEnsamblado
            // 
            lblEnsamblado.AutoSize = true;
            lblEnsamblado.Location = new Point(17, 92);
            lblEnsamblado.Name = "lblEnsamblado";
            lblEnsamblado.Size = new Size(85, 15);
            lblEnsamblado.TabIndex = 3;
            lblEnsamblado.Text = "lblEnsamblado";
            // 
            // lblConectado
            // 
            lblConectado.AutoSize = true;
            lblConectado.Location = new Point(17, 155);
            lblConectado.Name = "lblConectado";
            lblConectado.Size = new Size(78, 15);
            lblConectado.TabIndex = 4;
            lblConectado.Text = "lblConectado";
            // 
            // progressBarConectado
            // 
            progressBarConectado.Location = new Point(17, 182);
            progressBarConectado.Name = "progressBarConectado";
            progressBarConectado.Size = new Size(645, 23);
            progressBarConectado.TabIndex = 5;
            // 
            // gboxProduccion
            // 
            gboxProduccion.BackColor = Color.Transparent;
            gboxProduccion.Controls.Add(lblSoldado);
            gboxProduccion.Controls.Add(progressBarConectado);
            gboxProduccion.Controls.Add(progressBarSoldado);
            gboxProduccion.Controls.Add(lblConectado);
            gboxProduccion.Controls.Add(lblEnsamblado);
            gboxProduccion.Controls.Add(progressBarEnsamblado);
            gboxProduccion.ForeColor = SystemColors.ButtonHighlight;
            gboxProduccion.Location = new Point(12, 59);
            gboxProduccion.Name = "gboxProduccion";
            gboxProduccion.Size = new Size(676, 226);
            gboxProduccion.TabIndex = 6;
            gboxProduccion.TabStop = false;
            gboxProduccion.Text = "Produccion";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = SystemColors.ButtonHighlight;
            lblTitulo.Location = new Point(12, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(87, 25);
            lblTitulo.TabIndex = 6;
            lblTitulo.Text = "Procesos";
            // 
            // gboxProcesoFinal
            // 
            gboxProcesoFinal.BackColor = Color.Transparent;
            gboxProcesoFinal.Controls.Add(progressBarEmpaquetado);
            gboxProcesoFinal.Controls.Add(lblProcesoFinal);
            gboxProcesoFinal.ForeColor = SystemColors.ButtonHighlight;
            gboxProcesoFinal.Location = new Point(12, 304);
            gboxProcesoFinal.Name = "gboxProcesoFinal";
            gboxProcesoFinal.Size = new Size(676, 98);
            gboxProcesoFinal.TabIndex = 7;
            gboxProcesoFinal.TabStop = false;
            gboxProcesoFinal.Text = "Proceso final";
            // 
            // progressBarEmpaquetado
            // 
            progressBarEmpaquetado.Location = new Point(17, 56);
            progressBarEmpaquetado.Name = "progressBarEmpaquetado";
            progressBarEmpaquetado.Size = new Size(645, 23);
            progressBarEmpaquetado.TabIndex = 6;
            // 
            // lblProcesoFinal
            // 
            lblProcesoFinal.AutoSize = true;
            lblProcesoFinal.Location = new Point(17, 28);
            lblProcesoFinal.Name = "lblProcesoFinal";
            lblProcesoFinal.Size = new Size(87, 15);
            lblProcesoFinal.TabIndex = 6;
            lblProcesoFinal.Text = "lblProcesoFinal";
            // 
            // FrmProcesos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(701, 422);
            ControlBox = false;
            Controls.Add(gboxProcesoFinal);
            Controls.Add(lblTitulo);
            Controls.Add(gboxProduccion);
            Name = "FrmProcesos";
            Text = "FrmProcesos";
            Load += FrmProcesos_Load;
            gboxProduccion.ResumeLayout(false);
            gboxProduccion.PerformLayout();
            gboxProcesoFinal.ResumeLayout(false);
            gboxProcesoFinal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBarSoldado;
        private Label lblSoldado;
        private ProgressBar progressBarEnsamblado;
        private Label lblEnsamblado;
        private Label lblConectado;
        private ProgressBar progressBarConectado;
        private GroupBox gboxProduccion;
        private Label lblTitulo;
        private GroupBox gboxProcesoFinal;
        private Label lblProcesoFinal;
        private ProgressBar progressBarEmpaquetado;
    }
}