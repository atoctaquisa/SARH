namespace NominaTCG
{
    partial class frmVacacionesSolicitud
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVacacionesSolicitud));
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.SOLVAC_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLVAC_FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLVAC_DESDE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLVAC_HASTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLVAC_INCORPORACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLVAC_OBSERVACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imprimir = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(222)))));
            this.dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SOLVAC_ID,
            this.Estado,
            this.SOLVAC_FECHA,
            this.Dias,
            this.SOLVAC_DESDE,
            this.SOLVAC_HASTA,
            this.SOLVAC_INCORPORACION,
            this.SOLVAC_OBSERVACION,
            this.Imprimir});
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.Location = new System.Drawing.Point(0, 0);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.Size = new System.Drawing.Size(784, 311);
            this.dgvDatos.TabIndex = 0;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            // 
            // SOLVAC_ID
            // 
            this.SOLVAC_ID.DataPropertyName = "SOLVAC_ID";
            this.SOLVAC_ID.HeaderText = "#";
            this.SOLVAC_ID.Name = "SOLVAC_ID";
            this.SOLVAC_ID.Width = 50;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "ESTADO";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Width = 80;
            // 
            // SOLVAC_FECHA
            // 
            this.SOLVAC_FECHA.DataPropertyName = "SOLVAC_FECHA";
            this.SOLVAC_FECHA.HeaderText = "Solicitud";
            this.SOLVAC_FECHA.Name = "SOLVAC_FECHA";
            this.SOLVAC_FECHA.Width = 80;
            // 
            // Dias
            // 
            this.Dias.DataPropertyName = "DIAS";
            this.Dias.HeaderText = "Días";
            this.Dias.Name = "Dias";
            this.Dias.Width = 50;
            // 
            // SOLVAC_DESDE
            // 
            this.SOLVAC_DESDE.DataPropertyName = "SOLVAC_DESDE";
            this.SOLVAC_DESDE.HeaderText = "Desde";
            this.SOLVAC_DESDE.Name = "SOLVAC_DESDE";
            this.SOLVAC_DESDE.Width = 70;
            // 
            // SOLVAC_HASTA
            // 
            this.SOLVAC_HASTA.DataPropertyName = "SOLVAC_HASTA";
            this.SOLVAC_HASTA.HeaderText = "Hasta";
            this.SOLVAC_HASTA.Name = "SOLVAC_HASTA";
            this.SOLVAC_HASTA.Width = 70;
            // 
            // SOLVAC_INCORPORACION
            // 
            this.SOLVAC_INCORPORACION.DataPropertyName = "SOLVAC_INCORPORACION";
            this.SOLVAC_INCORPORACION.HeaderText = "Ingresa";
            this.SOLVAC_INCORPORACION.Name = "SOLVAC_INCORPORACION";
            this.SOLVAC_INCORPORACION.Width = 70;
            // 
            // SOLVAC_OBSERVACION
            // 
            this.SOLVAC_OBSERVACION.DataPropertyName = "SOLVAC_OBSERVACION";
            this.SOLVAC_OBSERVACION.HeaderText = "Observación";
            this.SOLVAC_OBSERVACION.Name = "SOLVAC_OBSERVACION";
            this.SOLVAC_OBSERVACION.Width = 170;
            // 
            // Imprimir
            // 
            this.Imprimir.HeaderText = "";
            this.Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("Imprimir.Image")));
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Width = 40;
            // 
            // frmVacacionesSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 311);
            this.Controls.Add(this.dgvDatos);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVacacionesSolicitud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Solicitudes Generadas";
            this.Load += new System.EventHandler(this.frmVacacionesSolicitud_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmVacacionesSolicitud_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLVAC_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLVAC_FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dias;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLVAC_DESDE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLVAC_HASTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLVAC_INCORPORACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLVAC_OBSERVACION;
        private System.Windows.Forms.DataGridViewImageColumn Imprimir;
    }
}