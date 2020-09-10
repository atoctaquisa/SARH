namespace NominaTCG
{
    partial class frmCuentaIO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuentaIO));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tabAdmin = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvDatosDT = new System.Windows.Forms.DataGridView();
            this.ROL_ID_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUE_PROV_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PROV_ROL_ESTADO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PROV_ROL_TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalRecordDT = new System.Windows.Forms.Label();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEditCancel = new System.Windows.Forms.Button();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNewSave = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.ROL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROL_CUENTA = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ROL_SUBCUENTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROL_ORD_IMP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROL_APA_LOCAL = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GRU_VAR_ROL_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ROL_ESTADO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMessage = new System.Windows.Forms.ToolTip(this.components);
            this.tabAdmin.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosDT)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
            this.SuspendLayout();
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
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Cuentas de Ingreso/Egreso";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.tabPage2);
            this.tabAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAdmin.Location = new System.Drawing.Point(0, 28);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(784, 533);
            this.tabAdmin.TabIndex = 38;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvDatosDT);
            this.tabPage2.Controls.Add(this.lblTotalRecordDT);
            this.tabPage2.Controls.Add(this.lblTotalRecord);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.dgvDatos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 507);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Administración";
            // 
            // dgvDatosDT
            // 
            this.dgvDatosDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosDT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ROL_ID_DT,
            this.CUE_PROV_ID,
            this.PROV_ROL_ESTADO,
            this.PROV_ROL_TIPO});
            this.dgvDatosDT.Location = new System.Drawing.Point(6, 263);
            this.dgvDatosDT.Name = "dgvDatosDT";
            this.dgvDatosDT.Size = new System.Drawing.Size(760, 156);
            this.dgvDatosDT.TabIndex = 35;
            this.dgvDatosDT.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvDatosDT_DefaultValuesNeeded);
            // 
            // ROL_ID_DT
            // 
            this.ROL_ID_DT.DataPropertyName = "ROL_ID";
            this.ROL_ID_DT.HeaderText = "Código";
            this.ROL_ID_DT.Name = "ROL_ID_DT";
            this.ROL_ID_DT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ROL_ID_DT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CUE_PROV_ID
            // 
            this.CUE_PROV_ID.DataPropertyName = "CUE_PROV_ID";
            this.CUE_PROV_ID.HeaderText = "Se paga en";
            this.CUE_PROV_ID.Name = "CUE_PROV_ID";
            this.CUE_PROV_ID.Width = 220;
            // 
            // PROV_ROL_ESTADO
            // 
            this.PROV_ROL_ESTADO.DataPropertyName = "PROV_ROL_ESTADO";
            this.PROV_ROL_ESTADO.FalseValue = "0";
            this.PROV_ROL_ESTADO.HeaderText = "Estado";
            this.PROV_ROL_ESTADO.Name = "PROV_ROL_ESTADO";
            this.PROV_ROL_ESTADO.TrueValue = "1";
            // 
            // PROV_ROL_TIPO
            // 
            this.PROV_ROL_TIPO.HeaderText = "PROV_ROL_TIPO";
            this.PROV_ROL_TIPO.Name = "PROV_ROL_TIPO";
            this.PROV_ROL_TIPO.Visible = false;
            // 
            // lblTotalRecordDT
            // 
            this.lblTotalRecordDT.AutoSize = true;
            this.lblTotalRecordDT.Location = new System.Drawing.Point(671, 422);
            this.lblTotalRecordDT.Name = "lblTotalRecordDT";
            this.lblTotalRecordDT.Size = new System.Drawing.Size(81, 13);
            this.lblTotalRecordDT.TabIndex = 34;
            this.lblTotalRecordDT.Text = "Total Registros:";
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Location = new System.Drawing.Point(671, 237);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(81, 13);
            this.lblTotalRecord.TabIndex = 34;
            this.lblTotalRecord.Text = "Total Registros:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEditCancel);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnNewSave);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 447);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(770, 57);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            // 
            // btnEditCancel
            // 
            this.btnEditCancel.ImageKey = "btnEdit.png";
            this.btnEditCancel.ImageList = this.imgList;
            this.btnEditCancel.Location = new System.Drawing.Point(305, 19);
            this.btnEditCancel.Name = "btnEditCancel";
            this.btnEditCancel.Size = new System.Drawing.Size(89, 29);
            this.btnEditCancel.TabIndex = 31;
            this.btnEditCancel.Text = "&Editar";
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
            this.btnExit.Location = new System.Drawing.Point(724, 19);
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
            this.btnNewSave.Enabled = false;
            this.btnNewSave.ImageIndex = 2;
            this.btnNewSave.ImageList = this.imgList;
            this.btnNewSave.Location = new System.Drawing.Point(394, 19);
            this.btnNewSave.Name = "btnNewSave";
            this.btnNewSave.Size = new System.Drawing.Size(89, 29);
            this.btnNewSave.TabIndex = 31;
            this.btnNewSave.Text = "&Guardar";
            this.btnNewSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewSave.UseVisualStyleBackColor = true;
            this.btnNewSave.Click += new System.EventHandler(this.btnNewSave_Click);
            // 
            // button4
            // 
            this.button4.ImageIndex = 10;
            this.button4.ImageList = this.imgList;
            this.button4.Location = new System.Drawing.Point(9, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(39, 29);
            this.button4.TabIndex = 31;
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ROL_ID,
            this.ROL_CUENTA,
            this.ROL_SUBCUENTA,
            this.ROL_ORD_IMP,
            this.ROL_APA_LOCAL,
            this.GRU_VAR_ROL_ID,
            this.ROL_ESTADO});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatos.Location = new System.Drawing.Point(6, 6);
            this.dgvDatos.Name = "dgvDatos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDatos.Size = new System.Drawing.Size(764, 227);
            this.dgvDatos.TabIndex = 1;
            this.dgvDatos.CurrentCellChanged += new System.EventHandler(this.dgvDatos_CurrentCellChanged);
            this.dgvDatos.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_RowValidated);
            // 
            // ROL_ID
            // 
            this.ROL_ID.DataPropertyName = "ROL_ID";
            this.ROL_ID.FillWeight = 59.30748F;
            this.ROL_ID.HeaderText = "Código";
            this.ROL_ID.Name = "ROL_ID";
            // 
            // ROL_CUENTA
            // 
            this.ROL_CUENTA.DataPropertyName = "ROL_CUENTA";
            this.ROL_CUENTA.FillWeight = 91.59047F;
            this.ROL_CUENTA.HeaderText = "Cuenta";
            this.ROL_CUENTA.Items.AddRange(new object[] {
            "Egreso",
            "Ingreso",
            "Otros"});
            this.ROL_CUENTA.Name = "ROL_CUENTA";
            this.ROL_CUENTA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ROL_CUENTA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ROL_SUBCUENTA
            // 
            this.ROL_SUBCUENTA.DataPropertyName = "ROL_SUBCUENTA";
            this.ROL_SUBCUENTA.FillWeight = 135.418F;
            this.ROL_SUBCUENTA.HeaderText = "Subcuenta";
            this.ROL_SUBCUENTA.Name = "ROL_SUBCUENTA";
            // 
            // ROL_ORD_IMP
            // 
            this.ROL_ORD_IMP.DataPropertyName = "ROL_ORD_IMP";
            this.ROL_ORD_IMP.FillWeight = 78.14212F;
            this.ROL_ORD_IMP.HeaderText = "Ord Imp";
            this.ROL_ORD_IMP.Name = "ROL_ORD_IMP";
            // 
            // ROL_APA_LOCAL
            // 
            this.ROL_APA_LOCAL.DataPropertyName = "ROL_APA_LOCAL";
            this.ROL_APA_LOCAL.FalseValue = "0";
            this.ROL_APA_LOCAL.FillWeight = 106.599F;
            this.ROL_APA_LOCAL.HeaderText = "Para Local";
            this.ROL_APA_LOCAL.Name = "ROL_APA_LOCAL";
            this.ROL_APA_LOCAL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ROL_APA_LOCAL.TrueValue = "1";
            // 
            // GRU_VAR_ROL_ID
            // 
            this.GRU_VAR_ROL_ID.DataPropertyName = "GRU_VAR_ROL_ID";
            this.GRU_VAR_ROL_ID.FillWeight = 161.633F;
            this.GRU_VAR_ROL_ID.HeaderText = "Cuentas RRHH";
            this.GRU_VAR_ROL_ID.Name = "GRU_VAR_ROL_ID";
            // 
            // ROL_ESTADO
            // 
            this.ROL_ESTADO.DataPropertyName = "ROL_ESTADO";
            this.ROL_ESTADO.FalseValue = "0";
            this.ROL_ESTADO.FillWeight = 67.30994F;
            this.ROL_ESTADO.HeaderText = "Estado";
            this.ROL_ESTADO.Name = "ROL_ESTADO";
            this.ROL_ESTADO.TrueValue = "1";
            // 
            // ErrProv
            // 
            this.ErrProv.ContainerControl = this;
            // 
            // frmCuentaIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabAdmin);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmCuentaIO";
            this.Text = "Cuentas Ingresos - Egresos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCuentaIO_FormClosing);
            this.tabAdmin.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosDT)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEditCancel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNewSave;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ErrorProvider ErrProv;
        private System.Windows.Forms.ToolTip ttMessage;
        private System.Windows.Forms.DataGridView dgvDatosDT;
        private System.Windows.Forms.Label lblTotalRecordDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL_ID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ROL_CUENTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL_SUBCUENTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL_ORD_IMP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ROL_APA_LOCAL;
        private System.Windows.Forms.DataGridViewComboBoxColumn GRU_VAR_ROL_ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ROL_ESTADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL_ID_DT;
        private System.Windows.Forms.DataGridViewComboBoxColumn CUE_PROV_ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PROV_ROL_ESTADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROV_ROL_TIPO;
    }
}