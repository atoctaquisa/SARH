namespace NominaTCG
{
    partial class frmVacacionesAprobacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVacacionesAprobacion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.ttMessage = new System.Windows.Forms.ToolTip(this.components);
            this.lblTitulo = new System.Windows.Forms.Label();
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ckAnular = new System.Windows.Forms.CheckBox();
            this.chkApbr = new System.Windows.Forms.CheckBox();
            this.pHasta = new System.Windows.Forms.DateTimePicker();
            this.pDesde = new System.Windows.Forms.DateTimePicker();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.btnLocal = new System.Windows.Forms.Button();
            this.btnEmpleado = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvVaciones = new System.Windows.Forms.DataGridView();
            this.CLI_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAB_VAC_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMP_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLVAC_ESTADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apbr = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Anular = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SOLVAC_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Periodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Solicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Incorpora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabAdmin = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaciones)).BeginInit();
            this.tabAdmin.SuspendLayout();
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
            this.imgList.Images.SetKeyName(18, "btnClear.png");
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Navy;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(954, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Aprobación de Solicitudes";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrProv
            // 
            this.ErrProv.ContainerControl = this;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCancel);
            this.tabPage2.Controls.Add(this.ckAnular);
            this.tabPage2.Controls.Add(this.chkApbr);
            this.tabPage2.Controls.Add(this.pHasta);
            this.tabPage2.Controls.Add(this.pDesde);
            this.tabPage2.Controls.Add(this.cboEstado);
            this.tabPage2.Controls.Add(this.btnLocal);
            this.tabPage2.Controls.Add(this.btnEmpleado);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.txtLocal);
            this.tabPage2.Controls.Add(this.txtEmpleado);
            this.tabPage2.Controls.Add(this.txtCodigo);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dgvVaciones);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(946, 557);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Administración";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.ImageKey = "btnClear.png";
            this.btnCancel.ImageList = this.imgList;
            this.btnCancel.Location = new System.Drawing.Point(606, 56);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Limpiar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ckAnular
            // 
            this.ckAnular.AutoSize = true;
            this.ckAnular.Location = new System.Drawing.Point(49, 132);
            this.ckAnular.Name = "ckAnular";
            this.ckAnular.Size = new System.Drawing.Size(15, 14);
            this.ckAnular.TabIndex = 75;
            this.ckAnular.UseVisualStyleBackColor = true;
            this.ckAnular.CheckedChanged += new System.EventHandler(this.ckAnular_CheckedChanged);
            // 
            // chkApbr
            // 
            this.chkApbr.AutoSize = true;
            this.chkApbr.Location = new System.Drawing.Point(19, 132);
            this.chkApbr.Name = "chkApbr";
            this.chkApbr.Size = new System.Drawing.Size(15, 14);
            this.chkApbr.TabIndex = 75;
            this.chkApbr.UseVisualStyleBackColor = true;
            this.chkApbr.CheckedChanged += new System.EventHandler(this.chkApbr_CheckedChanged);
            // 
            // pHasta
            // 
            this.pHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pHasta.Location = new System.Drawing.Point(581, 30);
            this.pHasta.Name = "pHasta";
            this.pHasta.Size = new System.Drawing.Size(114, 20);
            this.pHasta.TabIndex = 11;
            this.pHasta.ValueChanged += new System.EventHandler(this.pHasta_ValueChanged);
            // 
            // pDesde
            // 
            this.pDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pDesde.Location = new System.Drawing.Point(581, 9);
            this.pDesde.Name = "pDesde";
            this.pDesde.Size = new System.Drawing.Size(114, 20);
            this.pDesde.TabIndex = 9;
            this.pDesde.ValueChanged += new System.EventHandler(this.pDesde_ValueChanged);
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(133, 74);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(121, 21);
            this.cboEstado.TabIndex = 7;
            // 
            // btnLocal
            // 
            this.btnLocal.Enabled = false;
            this.btnLocal.ImageIndex = 5;
            this.btnLocal.ImageList = this.imgList;
            this.btnLocal.Location = new System.Drawing.Point(358, 52);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(31, 23);
            this.btnLocal.TabIndex = 5;
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.ImageIndex = 5;
            this.btnEmpleado.ImageList = this.imgList;
            this.btnEmpleado.Location = new System.Drawing.Point(358, 30);
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.Size = new System.Drawing.Size(31, 23);
            this.btnEmpleado.TabIndex = 3;
            this.btnEmpleado.UseVisualStyleBackColor = true;
            this.btnEmpleado.Click += new System.EventHandler(this.btnEmpleado_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnProcess);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 503);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 51);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.ImageIndex = 10;
            this.btnExit.ImageList = this.imgList;
            this.btnExit.Location = new System.Drawing.Point(888, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 29);
            this.btnExit.TabIndex = 1;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnProcess.ImageIndex = 9;
            this.btnProcess.ImageList = this.imgList;
            this.btnProcess.Location = new System.Drawing.Point(490, 14);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(89, 29);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "&Procesar";
            this.btnProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnFind.ImageKey = "btnFind.png";
            this.btnFind.ImageList = this.imgList;
            this.btnFind.Location = new System.Drawing.Point(401, 14);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(89, 29);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "&Buscar";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnBack
            // 
            this.btnBack.ImageIndex = 11;
            this.btnBack.ImageList = this.imgList;
            this.btnBack.Location = new System.Drawing.Point(9, 14);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(39, 29);
            this.btnBack.TabIndex = 0;
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // txtLocal
            // 
            this.txtLocal.Location = new System.Drawing.Point(133, 53);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.ReadOnly = true;
            this.txtLocal.Size = new System.Drawing.Size(225, 20);
            this.txtLocal.TabIndex = 5;
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(133, 32);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(225, 20);
            this.txtEmpleado.TabIndex = 3;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(133, 11);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(121, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(494, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha Hasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(494, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha Desde";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Ngr.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Apbr.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Estado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Local";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Empleado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solicitud";
            // 
            // dgvVaciones
            // 
            this.dgvVaciones.AllowUserToAddRows = false;
            this.dgvVaciones.AllowUserToDeleteRows = false;
            this.dgvVaciones.AllowUserToResizeColumns = false;
            this.dgvVaciones.AllowUserToResizeRows = false;
            this.dgvVaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLI_ID,
            this.CAB_VAC_ID,
            this.EMP_ID,
            this.SOLVAC_ESTADO,
            this.Apbr,
            this.Anular,
            this.SOLVAC_ID,
            this.Estado,
            this.Empleado,
            this.Periodo,
            this.Solicitud,
            this.Dias,
            this.Desde,
            this.Hasta,
            this.Incorpora,
            this.Obs});
            this.dgvVaciones.Location = new System.Drawing.Point(9, 127);
            this.dgvVaciones.Name = "dgvVaciones";
            this.dgvVaciones.RowHeadersVisible = false;
            this.dgvVaciones.Size = new System.Drawing.Size(929, 376);
            this.dgvVaciones.TabIndex = 6;
            this.dgvVaciones.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvVaciones_CurrentCellDirtyStateChanged);
            // 
            // CLI_ID
            // 
            this.CLI_ID.DataPropertyName = "CLI_ID";
            this.CLI_ID.HeaderText = "CLI_ID";
            this.CLI_ID.Name = "CLI_ID";
            this.CLI_ID.Visible = false;
            // 
            // CAB_VAC_ID
            // 
            this.CAB_VAC_ID.DataPropertyName = "CAB_VAC_ID";
            this.CAB_VAC_ID.HeaderText = "CAB_VAC_ID";
            this.CAB_VAC_ID.Name = "CAB_VAC_ID";
            this.CAB_VAC_ID.Visible = false;
            // 
            // EMP_ID
            // 
            this.EMP_ID.DataPropertyName = "EMP_ID";
            this.EMP_ID.HeaderText = "EMP_ID";
            this.EMP_ID.Name = "EMP_ID";
            this.EMP_ID.Visible = false;
            // 
            // SOLVAC_ESTADO
            // 
            this.SOLVAC_ESTADO.DataPropertyName = "SOLVAC_ESTADO";
            this.SOLVAC_ESTADO.HeaderText = "SOLVAC_ESTADO";
            this.SOLVAC_ESTADO.Name = "SOLVAC_ESTADO";
            this.SOLVAC_ESTADO.Visible = false;
            // 
            // Apbr
            // 
            this.Apbr.FalseValue = "0";
            this.Apbr.HeaderText = "";
            this.Apbr.Name = "Apbr";
            this.Apbr.TrueValue = "1";
            this.Apbr.Width = 30;
            // 
            // Anular
            // 
            this.Anular.FalseValue = "0";
            this.Anular.HeaderText = "";
            this.Anular.Name = "Anular";
            this.Anular.TrueValue = "1";
            this.Anular.Width = 30;
            // 
            // SOLVAC_ID
            // 
            this.SOLVAC_ID.DataPropertyName = "SOLVAC_ID";
            this.SOLVAC_ID.HeaderText = "#";
            this.SOLVAC_ID.Name = "SOLVAC_ID";
            this.SOLVAC_ID.Width = 40;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "ESTADO";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Width = 75;
            // 
            // Empleado
            // 
            this.Empleado.DataPropertyName = "NOMBRE";
            this.Empleado.HeaderText = "Empleado";
            this.Empleado.Name = "Empleado";
            this.Empleado.Width = 175;
            // 
            // Periodo
            // 
            this.Periodo.DataPropertyName = "PERIODO";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Periodo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Periodo.HeaderText = "Período";
            this.Periodo.Name = "Periodo";
            this.Periodo.Width = 80;
            // 
            // Solicitud
            // 
            this.Solicitud.DataPropertyName = "SOLVAC_FECHA";
            this.Solicitud.HeaderText = "Solicitud";
            this.Solicitud.Name = "Solicitud";
            this.Solicitud.Width = 80;
            // 
            // Dias
            // 
            this.Dias.DataPropertyName = "DIAS";
            this.Dias.HeaderText = "Dias";
            this.Dias.Name = "Dias";
            this.Dias.Width = 45;
            // 
            // Desde
            // 
            this.Desde.DataPropertyName = "SOLVAC_DESDE";
            this.Desde.HeaderText = "Desde";
            this.Desde.Name = "Desde";
            this.Desde.Width = 75;
            // 
            // Hasta
            // 
            this.Hasta.DataPropertyName = "SOLVAC_HASTA";
            this.Hasta.HeaderText = "Hasta";
            this.Hasta.Name = "Hasta";
            this.Hasta.Width = 75;
            // 
            // Incorpora
            // 
            this.Incorpora.DataPropertyName = "SOLVAC_INCORPORACION";
            this.Incorpora.HeaderText = "Incorpora";
            this.Incorpora.Name = "Incorpora";
            this.Incorpora.Width = 75;
            // 
            // Obs
            // 
            this.Obs.DataPropertyName = "SOLVAC_OBSERVACION";
            this.Obs.HeaderText = "Observación";
            this.Obs.Name = "Obs";
            this.Obs.Width = 170;
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.tabPage2);
            this.tabAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAdmin.Location = new System.Drawing.Point(0, 28);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(954, 583);
            this.tabAdmin.TabIndex = 1;
            // 
            // frmVacacionesAprobacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 611);
            this.Controls.Add(this.tabAdmin);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmVacacionesAprobacion";
            this.Text = "Solicitud - Aprobación";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAprobacion_FormClosing);
            this.Load += new System.EventHandler(this.frmVacacionesAprobacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaciones)).EndInit();
            this.tabAdmin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolTip ttMessage;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ErrorProvider ErrProv;
        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvVaciones;
        private System.Windows.Forms.Button btnEmpleado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.DateTimePicker pHasta;
        private System.Windows.Forms.DateTimePicker pDesde;
        private System.Windows.Forms.CheckBox chkApbr;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.CheckBox ckAnular;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLI_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAB_VAC_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMP_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLVAC_ESTADO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Apbr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Anular;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLVAC_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Periodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Solicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desde;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Incorpora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Obs;
    }
}