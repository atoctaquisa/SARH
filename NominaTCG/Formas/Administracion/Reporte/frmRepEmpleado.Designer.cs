namespace NominaTCG
{
    partial class frmRepEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepEmpleado));
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.cboPatrono = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFechaConIni = new System.Windows.Forms.TextBox();
            this.txtFechaConFin = new System.Windows.Forms.TextBox();
            this.txtFechaIngIni = new System.Windows.Forms.TextBox();
            this.txtFechaSalIni = new System.Windows.Forms.TextBox();
            this.txtFechaIngFin = new System.Windows.Forms.TextBox();
            this.txtFechaSalFin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMessage = new System.Windows.Forms.ToolTip(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboLabEstado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboConContrato = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDiscapacidad = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.btnLocal = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.btnEmpleado = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkCargaFa = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 159);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.Size = new System.Drawing.Size(933, 279);
            this.dgvData.TabIndex = 19;
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageIndex = 5;
            this.btnConsultar.ImageList = this.imgList;
            this.btnConsultar.Location = new System.Drawing.Point(842, 80);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(89, 29);
            this.btnConsultar.TabIndex = 16;
            this.btnConsultar.Text = "Buscar";
            this.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
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
            // cboPatrono
            // 
            this.cboPatrono.FormattingEnabled = true;
            this.cboPatrono.Location = new System.Drawing.Point(80, 106);
            this.cboPatrono.Name = "cboPatrono";
            this.cboPatrono.Size = new System.Drawing.Size(178, 21);
            this.cboPatrono.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.ImageIndex = 8;
            this.button1.ImageList = this.imgList;
            this.button1.Location = new System.Drawing.Point(842, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 29);
            this.button1.TabIndex = 17;
            this.button1.Text = "Generar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFechaConIni
            // 
            this.txtFechaConIni.Location = new System.Drawing.Point(414, 61);
            this.txtFechaConIni.Name = "txtFechaConIni";
            this.txtFechaConIni.Size = new System.Drawing.Size(67, 20);
            this.txtFechaConIni.TabIndex = 5;
            // 
            // txtFechaConFin
            // 
            this.txtFechaConFin.Location = new System.Drawing.Point(482, 61);
            this.txtFechaConFin.Name = "txtFechaConFin";
            this.txtFechaConFin.Size = new System.Drawing.Size(67, 20);
            this.txtFechaConFin.TabIndex = 6;
            // 
            // txtFechaIngIni
            // 
            this.txtFechaIngIni.Location = new System.Drawing.Point(414, 82);
            this.txtFechaIngIni.Name = "txtFechaIngIni";
            this.txtFechaIngIni.Size = new System.Drawing.Size(67, 20);
            this.txtFechaIngIni.TabIndex = 7;
            // 
            // txtFechaSalIni
            // 
            this.txtFechaSalIni.Location = new System.Drawing.Point(414, 103);
            this.txtFechaSalIni.Name = "txtFechaSalIni";
            this.txtFechaSalIni.Size = new System.Drawing.Size(67, 20);
            this.txtFechaSalIni.TabIndex = 9;
            // 
            // txtFechaIngFin
            // 
            this.txtFechaIngFin.Location = new System.Drawing.Point(482, 82);
            this.txtFechaIngFin.Name = "txtFechaIngFin";
            this.txtFechaIngFin.Size = new System.Drawing.Size(67, 20);
            this.txtFechaIngFin.TabIndex = 8;
            // 
            // txtFechaSalFin
            // 
            this.txtFechaSalFin.Location = new System.Drawing.Point(482, 103);
            this.txtFechaSalFin.Name = "txtFechaSalFin";
            this.txtFechaSalFin.Size = new System.Drawing.Size(67, 20);
            this.txtFechaSalFin.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fecha Contrato";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha Ingreso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha Salida";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Desde";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(500, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Hasta";
            // 
            // ErrProv
            // 
            this.ErrProv.ContainerControl = this;
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Navy;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(957, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Datos de Empleado";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Patrono";
            // 
            // cboLabEstado
            // 
            this.cboLabEstado.FormattingEnabled = true;
            this.cboLabEstado.Location = new System.Drawing.Point(673, 56);
            this.cboLabEstado.Name = "cboLabEstado";
            this.cboLabEstado.Size = new System.Drawing.Size(135, 21);
            this.cboLabEstado.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(577, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Estado";
            // 
            // cboConContrato
            // 
            this.cboConContrato.FormattingEnabled = true;
            this.cboConContrato.Location = new System.Drawing.Point(673, 78);
            this.cboConContrato.Name = "cboConContrato";
            this.cboConContrato.Size = new System.Drawing.Size(135, 21);
            this.cboConContrato.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(577, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Tipo Contrato";
            // 
            // cboDiscapacidad
            // 
            this.cboDiscapacidad.FormattingEnabled = true;
            this.cboDiscapacidad.Location = new System.Drawing.Point(673, 100);
            this.cboDiscapacidad.Name = "cboDiscapacidad";
            this.cboDiscapacidad.Size = new System.Drawing.Size(135, 21);
            this.cboDiscapacidad.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(577, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Discapacidad";
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(673, 122);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(135, 21);
            this.cboMes.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(577, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Mes Nacimiento";
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Location = new System.Drawing.Point(821, 441);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(81, 13);
            this.lblTotalRecord.TabIndex = 7;
            this.lblTotalRecord.Text = "Total Registros:";
            // 
            // txtLocal
            // 
            this.txtLocal.Location = new System.Drawing.Point(80, 61);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.ReadOnly = true;
            this.txtLocal.Size = new System.Drawing.Size(178, 20);
            this.txtLocal.TabIndex = 1;
            // 
            // btnLocal
            // 
            this.btnLocal.ImageIndex = 5;
            this.btnLocal.ImageList = this.imgList;
            this.btnLocal.Location = new System.Drawing.Point(259, 60);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(37, 23);
            this.btnLocal.TabIndex = 2;
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "Local";
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(80, 84);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(178, 20);
            this.txtEmpleado.TabIndex = 3;
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.ImageIndex = 5;
            this.btnEmpleado.ImageList = this.imgList;
            this.btnEmpleado.Location = new System.Drawing.Point(259, 83);
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.Size = new System.Drawing.Size(37, 23);
            this.btnEmpleado.TabIndex = 4;
            this.btnEmpleado.UseVisualStyleBackColor = true;
            this.btnEmpleado.Click += new System.EventHandler(this.btnEmpleado_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 58;
            this.label12.Text = "Empleado";
            // 
            // btnCancel
            // 
            this.btnCancel.ImageKey = "btnCancel.png";
            this.btnCancel.ImageList = this.imgList;
            this.btnCancel.Location = new System.Drawing.Point(842, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 29);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "&Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkCargaFa
            // 
            this.chkCargaFa.AutoSize = true;
            this.chkCargaFa.Location = new System.Drawing.Point(80, 133);
            this.chkCargaFa.Name = "chkCargaFa";
            this.chkCargaFa.Size = new System.Drawing.Size(127, 17);
            this.chkCargaFa.TabIndex = 62;
            this.chkCargaFa.Text = "Ver Cargas Familiares";
            this.chkCargaFa.UseVisualStyleBackColor = true;
            // 
            // frmRepEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 459);
            this.Controls.Add(this.chkCargaFa);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtLocal);
            this.Controls.Add(this.btnLocal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtEmpleado);
            this.Controls.Add(this.btnEmpleado);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblTotalRecord);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFechaSalFin);
            this.Controls.Add(this.txtFechaIngFin);
            this.Controls.Add(this.txtFechaConFin);
            this.Controls.Add(this.txtFechaSalIni);
            this.Controls.Add(this.txtFechaIngIni);
            this.Controls.Add(this.txtFechaConIni);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.cboDiscapacidad);
            this.Controls.Add(this.cboConContrato);
            this.Controls.Add(this.cboLabEstado);
            this.Controls.Add(this.cboPatrono);
            this.Controls.Add(this.dgvData);
            this.Name = "frmRepEmpleado";
            this.Text = "Datos Empleado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRepEmpleado_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.ComboBox cboPatrono;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFechaConIni;
        private System.Windows.Forms.TextBox txtFechaConFin;
        private System.Windows.Forms.TextBox txtFechaIngIni;
        private System.Windows.Forms.TextBox txtFechaSalIni;
        private System.Windows.Forms.TextBox txtFechaIngFin;
        private System.Windows.Forms.TextBox txtFechaSalFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider ErrProv;
        private System.Windows.Forms.ToolTip ttMessage;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboDiscapacidad;
        private System.Windows.Forms.ComboBox cboConContrato;
        private System.Windows.Forms.ComboBox cboLabEstado;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.Button btnEmpleado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkCargaFa;
    }
}