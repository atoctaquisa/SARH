namespace NominaTCG
{
    partial class frmRolIndividual
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRolIndividual));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDetalleRol = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.ttMessage = new System.Windows.Forms.ToolTip(this.components);
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.btnEmpleado = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.btnLocal = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCadena = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnDetalleRol);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 301);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 57);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.ImageIndex = 11;
            this.btnBack.ImageList = this.imgList;
            this.btnBack.Location = new System.Drawing.Point(12, 16);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(39, 29);
            this.btnBack.TabIndex = 56;
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "btnNew.png");
            this.imgList.Images.SetKeyName(1, "btnEdit.png");
            this.imgList.Images.SetKeyName(2, "btnSave.png");
            this.imgList.Images.SetKeyName(3, "btnCancel.png");
            this.imgList.Images.SetKeyName(4, "btnDelete.png");
            this.imgList.Images.SetKeyName(5, "btnFind.png");
            this.imgList.Images.SetKeyName(6, "btnPrinter.png");
            this.imgList.Images.SetKeyName(7, "btnUpdate.png");
            this.imgList.Images.SetKeyName(8, "btnReport.png");
            this.imgList.Images.SetKeyName(9, "btnProcesar.png");
            this.imgList.Images.SetKeyName(10, "btnOut.png");
            this.imgList.Images.SetKeyName(11, "btnIn.png");
            this.imgList.Images.SetKeyName(12, "btnDoor.png");
            this.imgList.Images.SetKeyName(13, "btnOpen.png");
            this.imgList.Images.SetKeyName(14, "btnFirst.png");
            this.imgList.Images.SetKeyName(15, "btnLast.png");
            this.imgList.Images.SetKeyName(16, "btnNext.png");
            this.imgList.Images.SetKeyName(17, "btnPrevious.png");
            this.imgList.Images.SetKeyName(18, "btnGenRol.png");
            this.imgList.Images.SetKeyName(19, "btnOpenPer.png");
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.ImageIndex = 10;
            this.btnExit.ImageList = this.imgList;
            this.btnExit.Location = new System.Drawing.Point(438, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 29);
            this.btnExit.TabIndex = 55;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDetalleRol
            // 
            this.btnDetalleRol.ImageIndex = 6;
            this.btnDetalleRol.ImageList = this.imgList;
            this.btnDetalleRol.Location = new System.Drawing.Point(152, 16);
            this.btnDetalleRol.Name = "btnDetalleRol";
            this.btnDetalleRol.Size = new System.Drawing.Size(89, 29);
            this.btnDetalleRol.TabIndex = 54;
            this.btnDetalleRol.Text = "&Detalle Rol";
            this.btnDetalleRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetalleRol.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDetalleRol.UseVisualStyleBackColor = true;
            this.btnDetalleRol.Click += new System.EventHandler(this.btnDetalleRol_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageKey = "btnCancel.png";
            this.btnCancel.ImageList = this.imgList;
            this.btnCancel.Location = new System.Drawing.Point(241, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 29);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "&Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Navy;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(489, 28);
            this.lblTitulo.TabIndex = 45;
            this.lblTitulo.Text = "Impresiones de Reportes";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrProv
            // 
            this.ErrProv.ContainerControl = this;
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(154, 76);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(178, 20);
            this.txtEmpleado.TabIndex = 47;
            this.txtEmpleado.TextChanged += new System.EventHandler(this.txtEmpleado_TextChanged);
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.ImageIndex = 5;
            this.btnEmpleado.ImageList = this.imgList;
            this.btnEmpleado.Location = new System.Drawing.Point(333, 75);
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.Size = new System.Drawing.Size(37, 23);
            this.btnEmpleado.TabIndex = 49;
            this.btnEmpleado.UseVisualStyleBackColor = true;
            this.btnEmpleado.Click += new System.EventHandler(this.btnEmpleado_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(72, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "Empleado";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Cadena";
            this.label1.Visible = false;
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 107);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(465, 183);
            this.dgvData.TabIndex = 53;
            // 
            // txtLocal
            // 
            this.txtLocal.Location = new System.Drawing.Point(154, 53);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.ReadOnly = true;
            this.txtLocal.Size = new System.Drawing.Size(178, 20);
            this.txtLocal.TabIndex = 54;
            this.txtLocal.TextChanged += new System.EventHandler(this.txtLocal_TextChanged);
            // 
            // btnLocal
            // 
            this.btnLocal.ImageIndex = 5;
            this.btnLocal.ImageList = this.imgList;
            this.btnLocal.Location = new System.Drawing.Point(333, 52);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(37, 23);
            this.btnLocal.TabIndex = 56;
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Local";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cboCadena
            // 
            this.cboCadena.FormattingEnabled = true;
            this.cboCadena.Location = new System.Drawing.Point(155, 31);
            this.cboCadena.Name = "cboCadena";
            this.cboCadena.Size = new System.Drawing.Size(178, 21);
            this.cboCadena.TabIndex = 57;
            this.cboCadena.Visible = false;
            // 
            // frmRolIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 358);
            this.Controls.Add(this.cboCadena);
            this.Controls.Add(this.txtLocal);
            this.Controls.Add(this.btnLocal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtEmpleado);
            this.Controls.Add(this.btnEmpleado);
            this.Controls.Add(this.label12);
            this.Name = "frmRolIndividual";
            this.Text = "Reporte de Rol Individual";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRolIndividual_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ToolTip ttMessage;
        private System.Windows.Forms.ErrorProvider ErrProv;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.Button btnEmpleado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnDetalleRol;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCadena;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBack;
    }
}