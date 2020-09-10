namespace NominaTCG
{
    partial class frmTransferenciaBanco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferenciaBanco));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMessage = new System.Windows.Forms.ToolTip(this.components);
            this.txtRol = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.tabAdmin = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.btnSearchPeriodo = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Label5 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.btnSearchEmpleado = new System.Windows.Forms.Button();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.txtFechaFin = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnSearchRol = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtFechaIni = new System.Windows.Forms.TextBox();
            this.txtReproceso = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboBanco = new System.Windows.Forms.ComboBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNewSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblTitulo = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
            this.tabAdmin.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            // ErrProv
            // 
            this.ErrProv.ContainerControl = this;
            // 
            // ttMessage
            // 
            this.ttMessage.Popup += new System.Windows.Forms.PopupEventHandler(this.ttMessage_Popup);
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(106, 63);
            this.txtRol.MaxLength = 50;
            this.txtRol.Name = "txtRol";
            this.txtRol.ReadOnly = true;
            this.txtRol.Size = new System.Drawing.Size(121, 20);
            this.txtRol.TabIndex = 0;
            this.txtRol.TextChanged += new System.EventHandler(this.txtRol_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(28, 66);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(23, 13);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Rol";
            this.Label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(28, 88);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(59, 13);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Reproceso";
            this.Label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(28, 109);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(65, 13);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Fecha Inicio";
            this.Label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.tabPage2);
            this.tabAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAdmin.Location = new System.Drawing.Point(0, 28);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(462, 371);
            this.tabAdmin.TabIndex = 2;
            this.tabAdmin.SelectedIndexChanged += new System.EventHandler(this.tabAdmin_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(454, 345);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Administración";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtRol);
            this.groupBox3.Controls.Add(this.txtEmpleado);
            this.groupBox3.Controls.Add(this.btnSearchPeriodo);
            this.groupBox3.Controls.Add(this.Label5);
            this.groupBox3.Controls.Add(this.Label10);
            this.groupBox3.Controls.Add(this.btnSearchEmpleado);
            this.groupBox3.Controls.Add(this.txtPeriodo);
            this.groupBox3.Controls.Add(this.txtFechaFin);
            this.groupBox3.Controls.Add(this.Label6);
            this.groupBox3.Controls.Add(this.btnSearchRol);
            this.groupBox3.Controls.Add(this.Label4);
            this.groupBox3.Controls.Add(this.txtFechaIni);
            this.groupBox3.Controls.Add(this.Label3);
            this.groupBox3.Controls.Add(this.Label1);
            this.groupBox3.Controls.Add(this.txtReproceso);
            this.groupBox3.Controls.Add(this.Label2);
            this.groupBox3.Location = new System.Drawing.Point(27, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(399, 180);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parámetros";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(106, 147);
            this.txtEmpleado.MaxLength = 10;
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(239, 20);
            this.txtEmpleado.TabIndex = 4;
            this.txtEmpleado.TextChanged += new System.EventHandler(this.txtEmpleado_TextChanged);
            // 
            // btnSearchPeriodo
            // 
            this.btnSearchPeriodo.ImageIndex = 5;
            this.btnSearchPeriodo.ImageList = this.imageList1;
            this.btnSearchPeriodo.Location = new System.Drawing.Point(228, 29);
            this.btnSearchPeriodo.Name = "btnSearchPeriodo";
            this.btnSearchPeriodo.Size = new System.Drawing.Size(31, 23);
            this.btnSearchPeriodo.TabIndex = 37;
            this.btnSearchPeriodo.UseVisualStyleBackColor = true;
            this.btnSearchPeriodo.Click += new System.EventHandler(this.btnSearchPeriodo_Click);
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
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(28, 150);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(54, 13);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "Empleado";
            this.Label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(28, 51);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(202, 13);
            this.Label10.TabIndex = 24;
            this.Label10.Text = "-----------------------------------------------------------------";
            this.Label10.Click += new System.EventHandler(this.Label10_Click);
            // 
            // btnSearchEmpleado
            // 
            this.btnSearchEmpleado.ImageIndex = 5;
            this.btnSearchEmpleado.ImageList = this.imageList1;
            this.btnSearchEmpleado.Location = new System.Drawing.Point(346, 145);
            this.btnSearchEmpleado.Name = "btnSearchEmpleado";
            this.btnSearchEmpleado.Size = new System.Drawing.Size(31, 23);
            this.btnSearchEmpleado.TabIndex = 36;
            this.btnSearchEmpleado.UseVisualStyleBackColor = true;
            this.btnSearchEmpleado.Click += new System.EventHandler(this.btnSearchEmpleado_Click);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(106, 31);
            this.txtPeriodo.MaxLength = 50;
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.ReadOnly = true;
            this.txtPeriodo.Size = new System.Drawing.Size(121, 20);
            this.txtPeriodo.TabIndex = 5;
            this.txtPeriodo.TextChanged += new System.EventHandler(this.txtPeriodo_TextChanged);
            // 
            // txtFechaFin
            // 
            this.txtFechaFin.Location = new System.Drawing.Point(106, 126);
            this.txtFechaFin.MaxLength = 150;
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.ReadOnly = true;
            this.txtFechaFin.Size = new System.Drawing.Size(121, 20);
            this.txtFechaFin.TabIndex = 3;
            this.txtFechaFin.TextChanged += new System.EventHandler(this.txtFechaFin_TextChanged);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(28, 34);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(45, 13);
            this.Label6.TabIndex = 5;
            this.Label6.Text = "Período";
            this.Label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // btnSearchRol
            // 
            this.btnSearchRol.ImageIndex = 5;
            this.btnSearchRol.ImageList = this.imageList1;
            this.btnSearchRol.Location = new System.Drawing.Point(228, 62);
            this.btnSearchRol.Name = "btnSearchRol";
            this.btnSearchRol.Size = new System.Drawing.Size(31, 23);
            this.btnSearchRol.TabIndex = 35;
            this.btnSearchRol.UseVisualStyleBackColor = true;
            this.btnSearchRol.Click += new System.EventHandler(this.btnSearchRol_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(28, 130);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(54, 13);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Fecha Fin";
            this.Label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // txtFechaIni
            // 
            this.txtFechaIni.Location = new System.Drawing.Point(106, 105);
            this.txtFechaIni.MaxLength = 13;
            this.txtFechaIni.Name = "txtFechaIni";
            this.txtFechaIni.ReadOnly = true;
            this.txtFechaIni.Size = new System.Drawing.Size(121, 20);
            this.txtFechaIni.TabIndex = 2;
            this.txtFechaIni.TextChanged += new System.EventHandler(this.txtFechaIni_TextChanged);
            // 
            // txtReproceso
            // 
            this.txtReproceso.Location = new System.Drawing.Point(106, 84);
            this.txtReproceso.MaxLength = 100;
            this.txtReproceso.Name = "txtReproceso";
            this.txtReproceso.ReadOnly = true;
            this.txtReproceso.Size = new System.Drawing.Size(121, 20);
            this.txtReproceso.TabIndex = 1;
            this.txtReproceso.TextChanged += new System.EventHandler(this.txtReproceso_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboBanco);
            this.groupBox2.Controls.Add(this.Label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cboTipo);
            this.groupBox2.Location = new System.Drawing.Point(27, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 63);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Documento";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // cboBanco
            // 
            this.cboBanco.FormattingEnabled = true;
            this.cboBanco.Items.AddRange(new object[] {
            "Pichincha",
            "Internacional"});
            this.cboBanco.Location = new System.Drawing.Point(72, 23);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Size = new System.Drawing.Size(121, 21);
            this.cboBanco.TabIndex = 8;
            this.cboBanco.SelectedIndexChanged += new System.EventHandler(this.cboBanco_SelectedIndexChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(28, 26);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(38, 13);
            this.Label9.TabIndex = 13;
            this.Label9.Text = "Banco";
            this.Label9.Click += new System.EventHandler(this.Label9_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Tipo";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Pago Quincena",
            "Pago Fin de Mes",
            "Pago Décimo Tercero",
            "Pago Décimo Cuarto"});
            this.cboTipo.Location = new System.Drawing.Point(252, 23);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(130, 21);
            this.cboTipo.TabIndex = 8;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnNewSave);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 285);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 57);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageKey = "btnCancel.png";
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(226, 18);
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
            this.btnExit.ImageIndex = 10;
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(403, 18);
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
            this.btnNewSave.Location = new System.Drawing.Point(137, 18);
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
            this.btnBack.ImageIndex = 11;
            this.btnBack.ImageList = this.imageList1;
            this.btnBack.Location = new System.Drawing.Point(9, 18);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(39, 29);
            this.btnBack.TabIndex = 31;
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Navy;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(462, 28);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Transferencias Bancarias";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmTransferenciaBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 399);
            this.Controls.Add(this.tabAdmin);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmTransferenciaBanco";
            this.Text = "Transferencias Bancarias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTransferenciaBanco_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            this.tabAdmin.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ErrorProvider ErrProv;
        private System.Windows.Forms.ToolTip ttMessage;
        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSearchRol;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNewSave;
        private System.Windows.Forms.Button btnBack;
        internal System.Windows.Forms.TextBox txtRol;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cboBanco;
        internal System.Windows.Forms.TextBox txtReproceso;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txtFechaIni;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtFechaFin;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtPeriodo;
        internal System.Windows.Forms.TextBox txtEmpleado;
        internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSearchPeriodo;
        private System.Windows.Forms.Button btnSearchEmpleado;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Button btnDelete;
    }
}