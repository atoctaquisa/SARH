namespace NominaTCG
{
    partial class frmJornada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJornada));
            this.tabAdmin = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnPeriodo = new System.Windows.Forms.Button();
            this.txtDiaTrabajo = new System.Windows.Forms.TextBox();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtReproceso = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiaDescon = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFechaContrato = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAfiliado = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPuesto = new System.Windows.Forms.TextBox();
            this.txtFechaIngreso = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvFaltas = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMP_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROL_ID_GEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROL_REPRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIA_FEC_NOVEDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIA_FEC_INGRESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIA_PERMISOJUST = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DIA_PERMISOINJUST = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DIA_FALTAJUSTIFI = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DIA_FALTAINJUSTI = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DIA_OTRODESCUN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DIA_OTRODESCNADA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEditCancel = new System.Windows.Forms.Button();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNewSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.ttMessage = new System.Windows.Forms.ToolTip(this.components);
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabAdmin.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaltas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
            this.SuspendLayout();
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.tabPage1);
            this.tabAdmin.Controls.Add(this.tabPage2);
            this.tabAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAdmin.Location = new System.Drawing.Point(0, 28);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(784, 533);
            this.tabAdmin.TabIndex = 34;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.txtSearch);
            this.tabPage1.Controls.Add(this.cboFilter);
            this.tabPage1.Controls.Add(this.dgvData);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 507);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos Generales";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Filtrar por:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(243, 34);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(274, 20);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cboFilter
            // 
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Location = new System.Drawing.Point(68, 33);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(154, 21);
            this.cboFilter.TabIndex = 7;
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvData.Location = new System.Drawing.Point(3, 78);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(770, 369);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvData_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalRecord);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 447);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(770, 57);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Location = new System.Drawing.Point(641, 27);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(81, 13);
            this.lblTotalRecord.TabIndex = 4;
            this.lblTotalRecord.Text = "Total Registros:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.dgvFaltas);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 507);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Administración";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnPeriodo);
            this.groupBox4.Controls.Add(this.txtDiaTrabajo);
            this.groupBox4.Controls.Add(this.txtPeriodo);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtReproceso);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtDiaDescon);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(29, 122);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(713, 71);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Rol:";
            // 
            // btnPeriodo
            // 
            this.btnPeriodo.Location = new System.Drawing.Point(235, 19);
            this.btnPeriodo.Name = "btnPeriodo";
            this.btnPeriodo.Size = new System.Drawing.Size(33, 23);
            this.btnPeriodo.TabIndex = 2;
            this.btnPeriodo.Text = "...";
            this.btnPeriodo.UseVisualStyleBackColor = true;
            this.btnPeriodo.Click += new System.EventHandler(this.btnPeriodo_Click);
            // 
            // txtDiaTrabajo
            // 
            this.txtDiaTrabajo.Location = new System.Drawing.Point(552, 20);
            this.txtDiaTrabajo.Name = "txtDiaTrabajo";
            this.txtDiaTrabajo.ReadOnly = true;
            this.txtDiaTrabajo.Size = new System.Drawing.Size(100, 20);
            this.txtDiaTrabajo.TabIndex = 0;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(135, 20);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.ReadOnly = true;
            this.txtPeriodo.Size = new System.Drawing.Size(100, 20);
            this.txtPeriodo.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(450, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Días a Descontar";
            // 
            // txtReproceso
            // 
            this.txtReproceso.Location = new System.Drawing.Point(135, 41);
            this.txtReproceso.Name = "txtReproceso";
            this.txtReproceso.ReadOnly = true;
            this.txtReproceso.Size = new System.Drawing.Size(100, 20);
            this.txtReproceso.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Reproceso";
            // 
            // txtDiaDescon
            // 
            this.txtDiaDescon.Location = new System.Drawing.Point(552, 41);
            this.txtDiaDescon.Name = "txtDiaDescon";
            this.txtDiaDescon.ReadOnly = true;
            this.txtDiaDescon.Size = new System.Drawing.Size(100, 20);
            this.txtDiaDescon.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(450, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Días Trabajados";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Período";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtCodigo);
            this.groupBox3.Controls.Add(this.txtCargo);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtFechaContrato);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtAfiliado);
            this.groupBox3.Controls.Add(this.txtNombre);
            this.groupBox3.Controls.Add(this.txtPuesto);
            this.groupBox3.Controls.Add(this.txtFechaIngreso);
            this.groupBox3.Controls.Add(this.txtEstado);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(28, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(713, 115);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Empleado:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(454, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(205, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "------------------------------------------------------------------";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(139, 21);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(101, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(139, 63);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.ReadOnly = true;
            this.txtCargo.Size = new System.Drawing.Size(268, 20);
            this.txtCargo.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(454, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Afiliado Humana";
            // 
            // txtFechaContrato
            // 
            this.txtFechaContrato.Location = new System.Drawing.Point(556, 63);
            this.txtFechaContrato.Name = "txtFechaContrato";
            this.txtFechaContrato.ReadOnly = true;
            this.txtFechaContrato.Size = new System.Drawing.Size(100, 20);
            this.txtFechaContrato.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Estado";
            // 
            // txtAfiliado
            // 
            this.txtAfiliado.Location = new System.Drawing.Point(556, 84);
            this.txtAfiliado.Name = "txtAfiliado";
            this.txtAfiliado.ReadOnly = true;
            this.txtAfiliado.Size = new System.Drawing.Size(100, 20);
            this.txtAfiliado.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(139, 42);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(268, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // txtPuesto
            // 
            this.txtPuesto.Location = new System.Drawing.Point(139, 84);
            this.txtPuesto.Name = "txtPuesto";
            this.txtPuesto.ReadOnly = true;
            this.txtPuesto.Size = new System.Drawing.Size(268, 20);
            this.txtPuesto.TabIndex = 0;
            // 
            // txtFechaIngreso
            // 
            this.txtFechaIngreso.Location = new System.Drawing.Point(556, 21);
            this.txtFechaIngreso.Name = "txtFechaIngreso";
            this.txtFechaIngreso.ReadOnly = true;
            this.txtFechaIngreso.Size = new System.Drawing.Size(100, 20);
            this.txtFechaIngreso.TabIndex = 0;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(307, 19);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(100, 20);
            this.txtEstado.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Fecha Contrato";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cargo Actual";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(48, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Empleado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Código";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fecha Ingreso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lugar de Trabajo";
            // 
            // dgvFaltas
            // 
            this.dgvFaltas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaltas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.EMP_ID,
            this.ROL_ID_GEN,
            this.ROL_REPRO,
            this.DIA_FEC_NOVEDAD,
            this.DIA_FEC_INGRESO,
            this.DIA_PERMISOJUST,
            this.DIA_PERMISOINJUST,
            this.DIA_FALTAJUSTIFI,
            this.DIA_FALTAINJUSTI,
            this.DIA_OTRODESCUN,
            this.DIA_OTRODESCNADA,
            this.Observacion});
            this.dgvFaltas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvFaltas.Location = new System.Drawing.Point(3, 213);
            this.dgvFaltas.Name = "dgvFaltas";
            this.dgvFaltas.Size = new System.Drawing.Size(770, 234);
            this.dgvFaltas.TabIndex = 2;
            this.dgvFaltas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaltas_CellContentClick);
            this.dgvFaltas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaltas_CellEndEdit);
            this.dgvFaltas.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvFaltas_CurrentCellDirtyStateChanged);
            this.dgvFaltas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvFaltas_DataError);
            // 
            // Num
            // 
            this.Num.DataPropertyName = "DIA_ID";
            this.Num.HeaderText = "Número";
            this.Num.Name = "Num";
            this.Num.Width = 50;
            // 
            // EMP_ID
            // 
            this.EMP_ID.DataPropertyName = "EMP_ID";
            this.EMP_ID.HeaderText = "EMP_ID";
            this.EMP_ID.Name = "EMP_ID";
            this.EMP_ID.Visible = false;
            // 
            // ROL_ID_GEN
            // 
            this.ROL_ID_GEN.DataPropertyName = "ROL_ID_GEN";
            this.ROL_ID_GEN.HeaderText = "ROL_ID_GEN";
            this.ROL_ID_GEN.Name = "ROL_ID_GEN";
            this.ROL_ID_GEN.Visible = false;
            // 
            // ROL_REPRO
            // 
            this.ROL_REPRO.DataPropertyName = "ROL_REPRO";
            this.ROL_REPRO.HeaderText = "ROL_REPRO";
            this.ROL_REPRO.Name = "ROL_REPRO";
            this.ROL_REPRO.Visible = false;
            // 
            // DIA_FEC_NOVEDAD
            // 
            this.DIA_FEC_NOVEDAD.DataPropertyName = "DIA_FEC_NOVEDAD";
            this.DIA_FEC_NOVEDAD.HeaderText = "Fecha Novedad";
            this.DIA_FEC_NOVEDAD.Name = "DIA_FEC_NOVEDAD";
            // 
            // DIA_FEC_INGRESO
            // 
            this.DIA_FEC_INGRESO.DataPropertyName = "DIA_FEC_INGRESO";
            this.DIA_FEC_INGRESO.HeaderText = "Fecha Registro";
            this.DIA_FEC_INGRESO.Name = "DIA_FEC_INGRESO";
            // 
            // DIA_PERMISOJUST
            // 
            this.DIA_PERMISOJUST.DataPropertyName = "DIA_PERMISOJUST";
            this.DIA_PERMISOJUST.FalseValue = "0";
            this.DIA_PERMISOJUST.HeaderText = "Permiso (No-Desc)";
            this.DIA_PERMISOJUST.Name = "DIA_PERMISOJUST";
            this.DIA_PERMISOJUST.TrueValue = "1";
            this.DIA_PERMISOJUST.Width = 60;
            // 
            // DIA_PERMISOINJUST
            // 
            this.DIA_PERMISOINJUST.DataPropertyName = "DIA_PERMISOINJUST";
            this.DIA_PERMISOINJUST.FalseValue = "0";
            this.DIA_PERMISOINJUST.HeaderText = "Permiso (1-Día)";
            this.DIA_PERMISOINJUST.Name = "DIA_PERMISOINJUST";
            this.DIA_PERMISOINJUST.TrueValue = "1";
            this.DIA_PERMISOINJUST.Width = 60;
            // 
            // DIA_FALTAJUSTIFI
            // 
            this.DIA_FALTAJUSTIFI.DataPropertyName = "DIA_FALTAJUSTIFI";
            this.DIA_FALTAJUSTIFI.FalseValue = "0";
            this.DIA_FALTAJUSTIFI.HeaderText = "Justificada (No-Desc)";
            this.DIA_FALTAJUSTIFI.Name = "DIA_FALTAJUSTIFI";
            this.DIA_FALTAJUSTIFI.TrueValue = "1";
            this.DIA_FALTAJUSTIFI.Width = 60;
            // 
            // DIA_FALTAINJUSTI
            // 
            this.DIA_FALTAINJUSTI.DataPropertyName = "DIA_FALTAINJUSTI";
            this.DIA_FALTAINJUSTI.FalseValue = "0";
            this.DIA_FALTAINJUSTI.HeaderText = "Injustificada (2-Días)";
            this.DIA_FALTAINJUSTI.Name = "DIA_FALTAINJUSTI";
            this.DIA_FALTAINJUSTI.TrueValue = "1";
            this.DIA_FALTAINJUSTI.Width = 60;
            // 
            // DIA_OTRODESCUN
            // 
            this.DIA_OTRODESCUN.DataPropertyName = "DIA_OTRODESCUN";
            this.DIA_OTRODESCUN.FalseValue = "0";
            this.DIA_OTRODESCUN.HeaderText = "Otros (1-Día)";
            this.DIA_OTRODESCUN.Name = "DIA_OTRODESCUN";
            this.DIA_OTRODESCUN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DIA_OTRODESCUN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DIA_OTRODESCUN.TrueValue = "1";
            this.DIA_OTRODESCUN.Width = 70;
            // 
            // DIA_OTRODESCNADA
            // 
            this.DIA_OTRODESCNADA.DataPropertyName = "DIA_OTRODESCNADA";
            this.DIA_OTRODESCNADA.FalseValue = "0";
            this.DIA_OTRODESCNADA.HeaderText = "Otros (No-Desc)";
            this.DIA_OTRODESCNADA.Name = "DIA_OTRODESCNADA";
            this.DIA_OTRODESCNADA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DIA_OTRODESCNADA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DIA_OTRODESCNADA.TrueValue = "1";
            this.DIA_OTRODESCNADA.Width = 75;
            // 
            // Observacion
            // 
            this.Observacion.DataPropertyName = "DIA_OBS";
            this.Observacion.HeaderText = "Observación";
            this.Observacion.Name = "Observacion";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditCancel);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnNewSave);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 447);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(770, 57);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // btnEditCancel
            // 
            this.btnEditCancel.ImageKey = "btnEdit.png";
            this.btnEditCancel.ImageList = this.imgList;
            this.btnEditCancel.Location = new System.Drawing.Point(348, 19);
            this.btnEditCancel.Name = "btnEditCancel";
            this.btnEditCancel.Size = new System.Drawing.Size(89, 29);
            this.btnEditCancel.TabIndex = 31;
            this.btnEditCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditCancel.UseVisualStyleBackColor = true;
            this.btnEditCancel.Click += new System.EventHandler(this.btnEditCancel_Click);
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
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.ImageIndex = 11;
            this.btnExit.ImageList = this.imgList;
            this.btnExit.Location = new System.Drawing.Point(718, 19);
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
            this.btnNewSave.ImageIndex = 0;
            this.btnNewSave.ImageList = this.imgList;
            this.btnNewSave.Location = new System.Drawing.Point(259, 19);
            this.btnNewSave.Name = "btnNewSave";
            this.btnNewSave.Size = new System.Drawing.Size(89, 29);
            this.btnNewSave.TabIndex = 31;
            this.btnNewSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewSave.UseVisualStyleBackColor = true;
            this.btnNewSave.Click += new System.EventHandler(this.btnNewSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageKey = "btnDelete.png";
            this.btnDelete.ImageList = this.imgList;
            this.btnDelete.Location = new System.Drawing.Point(437, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(83, 29);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBack
            // 
            this.btnBack.ImageIndex = 10;
            this.btnBack.ImageList = this.imgList;
            this.btnBack.Location = new System.Drawing.Point(9, 19);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(45, 29);
            this.btnBack.TabIndex = 31;
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Navy;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(784, 28);
            this.lblTitulo.TabIndex = 32;
            this.lblTitulo.Text = "Jornada / Días No Trabajados";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrProv
            // 
            this.ErrProv.ContainerControl = this;
            // 
            // frmJornada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabAdmin);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmJornada";
            this.Text = "Días no Trabajados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmJornada_FormClosing);
            this.Load += new System.EventHandler(this.frmJornada_Load);
            this.tabAdmin.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaltas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvFaltas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiaDescon;
        private System.Windows.Forms.TextBox txtReproceso;
        private System.Windows.Forms.TextBox txtDiaTrabajo;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtFechaIngreso;
        private System.Windows.Forms.TextBox txtPuesto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtAfiliado;
        private System.Windows.Forms.TextBox txtFechaContrato;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEditCancel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNewSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ToolTip ttMessage;
        private System.Windows.Forms.ErrorProvider ErrProv;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnPeriodo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMP_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL_ID_GEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL_REPRO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIA_FEC_NOVEDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIA_FEC_INGRESO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DIA_PERMISOJUST;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DIA_PERMISOINJUST;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DIA_FALTAJUSTIFI;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DIA_FALTAINJUSTI;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DIA_OTRODESCUN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DIA_OTRODESCNADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacion;
    }
}