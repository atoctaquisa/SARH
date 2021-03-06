﻿namespace NominaTCG
{
    partial class frmDetalleContabilidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleContabilidad));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNewSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtFechaFin = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtFechaIni = new System.Windows.Forms.TextBox();
            this.txtReproceso = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.pFechaFin = new System.Windows.Forms.DateTimePicker();
            this.pFechaIni = new System.Windows.Forms.DateTimePicker();
            this.cboPatrono = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.btnLocal = new System.Windows.Forms.Button();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSearchRol = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtPeriodo = new System.Windows.Forms.RadioButton();
            this.rbtFecha = new System.Windows.Forms.RadioButton();
            this.tabAdmin = new System.Windows.Forms.TabControl();
            this.ttMessage = new System.Windows.Forms.ToolTip(this.components);
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "btnNew.png");
            this.imageList1.Images.SetKeyName(1, "btnEdit.png");
            this.imageList1.Images.SetKeyName(2, "btnSave.png");
            this.imageList1.Images.SetKeyName(3, "btnCancel.png");
            this.imageList1.Images.SetKeyName(4, "btnDelete.png");
            this.imageList1.Images.SetKeyName(5, "btnFind.png");
            this.imageList1.Images.SetKeyName(6, "btnPrinter.png");
            this.imageList1.Images.SetKeyName(7, "btnUpdate.png");
            this.imageList1.Images.SetKeyName(8, "btnReport.png");
            this.imageList1.Images.SetKeyName(9, "btnProcesar.png");
            this.imageList1.Images.SetKeyName(10, "btnOut.png");
            this.imageList1.Images.SetKeyName(11, "btnIn.png");
            this.imageList1.Images.SetKeyName(12, "btnDoor.png");
            this.imageList1.Images.SetKeyName(13, "btnOpen.png");
            this.imageList1.Images.SetKeyName(14, "btnFirst.png");
            this.imageList1.Images.SetKeyName(15, "btnLast.png");
            this.imageList1.Images.SetKeyName(16, "btnNext.png");
            this.imageList1.Images.SetKeyName(17, "btnPrevious.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnNewSave);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 57);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageKey = "btnCancel.png";
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(315, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(83, 29);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "&Cancelar";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.ImageIndex = 11;
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(563, 18);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 29);
            this.btnExit.TabIndex = 31;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNewSave
            // 
            this.btnNewSave.ImageIndex = 8;
            this.btnNewSave.ImageList = this.imageList1;
            this.btnNewSave.Location = new System.Drawing.Point(226, 18);
            this.btnNewSave.Name = "btnNewSave";
            this.btnNewSave.Size = new System.Drawing.Size(89, 29);
            this.btnNewSave.TabIndex = 31;
            this.btnNewSave.Text = "&Generar";
            this.btnNewSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewSave.UseVisualStyleBackColor = true;
            this.btnNewSave.Click += new System.EventHandler(this.btnNewSave_Click);
            // 
            // btnBack
            // 
            this.btnBack.ImageIndex = 10;
            this.btnBack.ImageList = this.imageList1;
            this.btnBack.Location = new System.Drawing.Point(9, 18);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(39, 29);
            this.btnBack.TabIndex = 31;
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(118, 18);
            this.txtRol.MaxLength = 50;
            this.txtRol.Name = "txtRol";
            this.txtRol.ReadOnly = true;
            this.txtRol.Size = new System.Drawing.Size(121, 20);
            this.txtRol.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtFechaFin
            // 
            this.txtFechaFin.Location = new System.Drawing.Point(118, 81);
            this.txtFechaFin.MaxLength = 150;
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.ReadOnly = true;
            this.txtFechaFin.Size = new System.Drawing.Size(121, 20);
            this.txtFechaFin.TabIndex = 3;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(40, 85);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(54, 13);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Fecha Fin";
            // 
            // txtFechaIni
            // 
            this.txtFechaIni.Location = new System.Drawing.Point(118, 60);
            this.txtFechaIni.MaxLength = 13;
            this.txtFechaIni.Name = "txtFechaIni";
            this.txtFechaIni.ReadOnly = true;
            this.txtFechaIni.Size = new System.Drawing.Size(121, 20);
            this.txtFechaIni.TabIndex = 2;
            // 
            // txtReproceso
            // 
            this.txtReproceso.Location = new System.Drawing.Point(118, 39);
            this.txtReproceso.MaxLength = 100;
            this.txtReproceso.Name = "txtReproceso";
            this.txtReproceso.ReadOnly = true;
            this.txtReproceso.Size = new System.Drawing.Size(121, 20);
            this.txtReproceso.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Navy;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(626, 28);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Contabilidad - Empresa - Local";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboTipo);
            this.groupBox3.Controls.Add(this.pFechaFin);
            this.groupBox3.Controls.Add(this.pFechaIni);
            this.groupBox3.Controls.Add(this.cboPatrono);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtLocal);
            this.groupBox3.Controls.Add(this.btnLocal);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtRol);
            this.groupBox3.Controls.Add(this.txtFechaFin);
            this.groupBox3.Controls.Add(this.btnSearchRol);
            this.groupBox3.Controls.Add(this.Label4);
            this.groupBox3.Controls.Add(this.txtFechaIni);
            this.groupBox3.Controls.Add(this.Label3);
            this.groupBox3.Controls.Add(this.Label1);
            this.groupBox3.Controls.Add(this.txtReproceso);
            this.groupBox3.Controls.Add(this.Label2);
            this.groupBox3.Location = new System.Drawing.Point(29, 86);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(557, 135);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parámetros";
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Consolidado",
            "Detallado"});
            this.cboTipo.Location = new System.Drawing.Point(118, 102);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(121, 21);
            this.cboTipo.TabIndex = 36;
            // 
            // pFechaFin
            // 
            this.pFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pFechaFin.Location = new System.Drawing.Point(371, 40);
            this.pFechaFin.Name = "pFechaFin";
            this.pFechaFin.Size = new System.Drawing.Size(121, 20);
            this.pFechaFin.TabIndex = 39;
            // 
            // pFechaIni
            // 
            this.pFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pFechaIni.Location = new System.Drawing.Point(371, 19);
            this.pFechaIni.Name = "pFechaIni";
            this.pFechaIni.Size = new System.Drawing.Size(121, 20);
            this.pFechaIni.TabIndex = 37;
            // 
            // cboPatrono
            // 
            this.cboPatrono.FormattingEnabled = true;
            this.cboPatrono.Location = new System.Drawing.Point(371, 61);
            this.cboPatrono.Name = "cboPatrono";
            this.cboPatrono.Size = new System.Drawing.Size(121, 21);
            this.cboPatrono.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Reporte";
            // 
            // txtLocal
            // 
            this.txtLocal.Location = new System.Drawing.Point(371, 83);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.ReadOnly = true;
            this.txtLocal.Size = new System.Drawing.Size(121, 20);
            this.txtLocal.TabIndex = 43;
            this.txtLocal.Visible = false;
            // 
            // btnLocal
            // 
            this.btnLocal.ImageIndex = 5;
            this.btnLocal.ImageList = this.imgList;
            this.btnLocal.Location = new System.Drawing.Point(493, 81);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(37, 23);
            this.btnLocal.TabIndex = 44;
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Visible = false;
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
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Patrono";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(293, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Local";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Fecha Fin";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(293, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Fecha Inicio";
            // 
            // btnSearchRol
            // 
            this.btnSearchRol.ImageIndex = 5;
            this.btnSearchRol.ImageList = this.imageList1;
            this.btnSearchRol.Location = new System.Drawing.Point(240, 17);
            this.btnSearchRol.Name = "btnSearchRol";
            this.btnSearchRol.Size = new System.Drawing.Size(31, 23);
            this.btnSearchRol.TabIndex = 35;
            this.btnSearchRol.UseVisualStyleBackColor = true;
            this.btnSearchRol.Click += new System.EventHandler(this.btnSearchRol_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(40, 64);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(65, 13);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Fecha Inicio";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(40, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(23, 13);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Rol";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(40, 43);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(59, 13);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Reproceso";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(618, 295);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Administración";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtPeriodo);
            this.groupBox2.Controls.Add(this.rbtFecha);
            this.groupBox2.Location = new System.Drawing.Point(12, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(595, 57);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtrar por";
            // 
            // rbtPeriodo
            // 
            this.rbtPeriodo.AutoSize = true;
            this.rbtPeriodo.Checked = true;
            this.rbtPeriodo.Location = new System.Drawing.Point(61, 23);
            this.rbtPeriodo.Name = "rbtPeriodo";
            this.rbtPeriodo.Size = new System.Drawing.Size(82, 17);
            this.rbtPeriodo.TabIndex = 45;
            this.rbtPeriodo.TabStop = true;
            this.rbtPeriodo.Text = "Por Período";
            this.rbtPeriodo.UseVisualStyleBackColor = true;
            this.rbtPeriodo.CheckedChanged += new System.EventHandler(this.rbtPeriodo_CheckedChanged);
            // 
            // rbtFecha
            // 
            this.rbtFecha.AutoSize = true;
            this.rbtFecha.Location = new System.Drawing.Point(177, 23);
            this.rbtFecha.Name = "rbtFecha";
            this.rbtFecha.Size = new System.Drawing.Size(74, 17);
            this.rbtFecha.TabIndex = 46;
            this.rbtFecha.Text = "Por Fecha";
            this.rbtFecha.UseVisualStyleBackColor = true;
            this.rbtFecha.CheckedChanged += new System.EventHandler(this.rbtFecha_CheckedChanged);
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.tabPage2);
            this.tabAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAdmin.Location = new System.Drawing.Point(0, 28);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(626, 321);
            this.tabAdmin.TabIndex = 4;
            // 
            // ErrProv
            // 
            this.ErrProv.ContainerControl = this;
            // 
            // frmDetalleContabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 349);
            this.Controls.Add(this.tabAdmin);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmDetalleContabilidad";
            this.Text = "Reporte Contabilidad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDetalleContabilidad_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNewSave;
        private System.Windows.Forms.Button btnBack;
        internal System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.TextBox txtFechaFin;
        private System.Windows.Forms.Button btnSearchRol;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtFechaIni;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtReproceso;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ToolTip ttMessage;
        private System.Windows.Forms.ErrorProvider ErrProv;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ComboBox cboTipo;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker pFechaFin;
        private System.Windows.Forms.DateTimePicker pFechaIni;
        private System.Windows.Forms.ComboBox cboPatrono;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbtFecha;
        private System.Windows.Forms.RadioButton rbtPeriodo;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}