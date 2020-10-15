namespace NominaTCG
{
    partial class frmDetalleVacacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleVacacion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ttMessage = new System.Windows.Forms.ToolTip(this.components);
            this.tabAdmin = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSueldo = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEditCancel = new System.Windows.Forms.Button();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNewSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.VAC_PER_VAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAC_PER_FEC_INI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAC_PER_FEC_FIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAC_DIAS_CAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDataDT = new System.Windows.Forms.DataGridView();
            this.NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEG_ROL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAC_VAL_DIAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAC_VAL_VALOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAC_VAL_VALOR_VAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabAdmin.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
            this.SuspendLayout();
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.tabPage2);
            this.tabAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAdmin.Location = new System.Drawing.Point(0, 28);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(545, 422);
            this.tabAdmin.TabIndex = 40;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtSueldo);
            this.tabPage2.Controls.Add(this.txtValor);
            this.tabPage2.Controls.Add(this.lblTotalRecord);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.dgvData);
            this.tabPage2.Controls.Add(this.dgvDataDT);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(537, 396);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Administración";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(327, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Total:";
            // 
            // txtSueldo
            // 
            this.txtSueldo.Location = new System.Drawing.Point(371, 308);
            this.txtSueldo.Name = "txtSueldo";
            this.txtSueldo.ReadOnly = true;
            this.txtSueldo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSueldo.Size = new System.Drawing.Size(72, 20);
            this.txtSueldo.TabIndex = 35;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(449, 308);
            this.txtValor.Name = "txtValor";
            this.txtValor.ReadOnly = true;
            this.txtValor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValor.Size = new System.Drawing.Size(80, 20);
            this.txtValor.TabIndex = 35;
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Location = new System.Drawing.Point(634, 431);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(81, 13);
            this.lblTotalRecord.TabIndex = 34;
            this.lblTotalRecord.Text = "Total Registros:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditCancel);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnNewSave);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 336);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 57);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // btnEditCancel
            // 
            this.btnEditCancel.ImageKey = "btnEdit.png";
            this.btnEditCancel.ImageList = this.imgList;
            this.btnEditCancel.Location = new System.Drawing.Point(180, 19);
            this.btnEditCancel.Name = "btnEditCancel";
            this.btnEditCancel.Size = new System.Drawing.Size(89, 29);
            this.btnEditCancel.TabIndex = 31;
            this.btnEditCancel.Text = "&Editar";
            this.btnEditCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditCancel.UseVisualStyleBackColor = true;
            this.btnEditCancel.Visible = false;
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
            this.btnExit.ImageIndex = 10;
            this.btnExit.ImageList = this.imgList;
            this.btnExit.Location = new System.Drawing.Point(486, 19);
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
            this.btnNewSave.Location = new System.Drawing.Point(269, 19);
            this.btnNewSave.Name = "btnNewSave";
            this.btnNewSave.Size = new System.Drawing.Size(89, 29);
            this.btnNewSave.TabIndex = 31;
            this.btnNewSave.Text = "&Guardar";
            this.btnNewSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewSave.UseVisualStyleBackColor = true;
            this.btnNewSave.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.ImageIndex = 11;
            this.btnBack.ImageList = this.imgList;
            this.btnBack.Location = new System.Drawing.Point(9, 19);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(45, 29);
            this.btnBack.TabIndex = 31;
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VAC_PER_VAC,
            this.VAC_PER_FEC_INI,
            this.VAC_PER_FEC_FIN,
            this.VAC_DIAS_CAL});
            this.dgvData.Location = new System.Drawing.Point(6, 6);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(523, 95);
            this.dgvData.TabIndex = 1;
            // 
            // VAC_PER_VAC
            // 
            this.VAC_PER_VAC.DataPropertyName = "VAC_PER_VAC";
            this.VAC_PER_VAC.HeaderText = "Período";
            this.VAC_PER_VAC.Name = "VAC_PER_VAC";
            // 
            // VAC_PER_FEC_INI
            // 
            this.VAC_PER_FEC_INI.DataPropertyName = "VAC_PER_FEC_INI";
            this.VAC_PER_FEC_INI.HeaderText = "Fecha Inicio";
            this.VAC_PER_FEC_INI.Name = "VAC_PER_FEC_INI";
            // 
            // VAC_PER_FEC_FIN
            // 
            this.VAC_PER_FEC_FIN.DataPropertyName = "VAC_PER_FEC_FIN";
            this.VAC_PER_FEC_FIN.HeaderText = "Fecha Fin";
            this.VAC_PER_FEC_FIN.Name = "VAC_PER_FEC_FIN";
            // 
            // VAC_DIAS_CAL
            // 
            this.VAC_DIAS_CAL.DataPropertyName = "VAC_DIAS_CAL";
            this.VAC_DIAS_CAL.HeaderText = "Día Calculado";
            this.VAC_DIAS_CAL.Name = "VAC_DIAS_CAL";
            // 
            // dgvDataDT
            // 
            this.dgvDataDT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataDT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NUM,
            this.MES,
            this.SEG_ROL_ID,
            this.VAC_VAL_DIAS,
            this.VAC_VAL_VALOR,
            this.VAC_VAL_VALOR_VAC});
            this.dgvDataDT.Location = new System.Drawing.Point(6, 119);
            this.dgvDataDT.Name = "dgvDataDT";
            this.dgvDataDT.Size = new System.Drawing.Size(523, 183);
            this.dgvDataDT.TabIndex = 1;
            // 
            // NUM
            // 
            this.NUM.DataPropertyName = "NUM";
            this.NUM.HeaderText = "Num";
            this.NUM.Name = "NUM";
            // 
            // MES
            // 
            this.MES.DataPropertyName = "MES";
            this.MES.HeaderText = "Mes";
            this.MES.Name = "MES";
            // 
            // SEG_ROL_ID
            // 
            this.SEG_ROL_ID.DataPropertyName = "SEG_ROL_ID";
            this.SEG_ROL_ID.HeaderText = "Perído";
            this.SEG_ROL_ID.Name = "SEG_ROL_ID";
            // 
            // VAC_VAL_DIAS
            // 
            this.VAC_VAL_DIAS.DataPropertyName = "VAC_VAL_DIAS";
            this.VAC_VAL_DIAS.HeaderText = "Días Lab.";
            this.VAC_VAL_DIAS.Name = "VAC_VAL_DIAS";
            // 
            // VAC_VAL_VALOR
            // 
            this.VAC_VAL_VALOR.DataPropertyName = "VAC_VAL_VALOR";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VAC_VAL_VALOR.DefaultCellStyle = dataGridViewCellStyle1;
            this.VAC_VAL_VALOR.HeaderText = "Sueldo";
            this.VAC_VAL_VALOR.Name = "VAC_VAL_VALOR";
            // 
            // VAC_VAL_VALOR_VAC
            // 
            this.VAC_VAL_VALOR_VAC.DataPropertyName = "VAC_VAL_VALOR_VAC";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VAC_VAL_VALOR_VAC.DefaultCellStyle = dataGridViewCellStyle2;
            this.VAC_VAL_VALOR_VAC.HeaderText = "Valor";
            this.VAC_VAL_VALOR_VAC.Name = "VAC_VAL_VALOR_VAC";
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Navy;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(545, 28);
            this.lblTitulo.TabIndex = 39;
            this.lblTitulo.Text = "Detalle Vacaciones";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrProv
            // 
            this.ErrProv.ContainerControl = this;
            // 
            // frmDetalleVacacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 450);
            this.Controls.Add(this.tabAdmin);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmDetalleVacacion";
            this.Text = "Detalle Vacaciones";
            this.tabAdmin.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip ttMessage;
        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEditCancel;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNewSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvDataDT;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ErrorProvider ErrProv;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAC_PER_VAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAC_PER_FEC_INI;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAC_PER_FEC_FIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAC_DIAS_CAL;
        private System.Windows.Forms.TextBox txtSueldo;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MES;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEG_ROL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAC_VAL_DIAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAC_VAL_VALOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAC_VAL_VALOR_VAC;
    }
}