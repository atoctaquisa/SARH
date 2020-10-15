namespace NominaTCG
{
    partial class frmDetalleDecimoTercero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleDecimoTercero));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnEditCancel = new System.Windows.Forms.Button();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNewSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtDecimo = new System.Windows.Forms.TextBox();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TER_FEC_INI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TER_FEC_FIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TER_FEC_REG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDataDT = new System.Windows.Forms.DataGridView();
            this.NUM_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEG_ROL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TER_VAL_VALOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TER_VAL_VALOR_TER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabAdmin = new System.Windows.Forms.TabControl();
            this.ttMessage = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDT)).BeginInit();
            this.tabAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // ErrProv
            // 
            this.ErrProv.ContainerControl = this;
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
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Navy;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(546, 28);
            this.lblTitulo.TabIndex = 41;
            this.lblTitulo.Text = "Detalle Décimo Tercero";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(362, 304);
            this.txtValor.Name = "txtValor";
            this.txtValor.ReadOnly = true;
            this.txtValor.Size = new System.Drawing.Size(72, 20);
            this.txtValor.TabIndex = 35;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDecimo
            // 
            this.txtDecimo.Location = new System.Drawing.Point(456, 304);
            this.txtDecimo.Name = "txtDecimo";
            this.txtDecimo.ReadOnly = true;
            this.txtDecimo.Size = new System.Drawing.Size(72, 20);
            this.txtDecimo.TabIndex = 35;
            this.txtDecimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.groupBox1.Location = new System.Drawing.Point(3, 335);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 57);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtValor);
            this.tabPage2.Controls.Add(this.txtDecimo);
            this.tabPage2.Controls.Add(this.lblTotalRecord);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.dgvData);
            this.tabPage2.Controls.Add(this.dgvDataDT);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(538, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Administración";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(322, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Total:";
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NUM,
            this.TER_FEC_INI,
            this.TER_FEC_FIN,
            this.TER_FEC_REG});
            this.dgvData.Location = new System.Drawing.Point(6, 6);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(523, 95);
            this.dgvData.TabIndex = 1;
            // 
            // NUM
            // 
            this.NUM.DataPropertyName = "NUM";
            this.NUM.HeaderText = "Num";
            this.NUM.Name = "NUM";
            // 
            // TER_FEC_INI
            // 
            this.TER_FEC_INI.DataPropertyName = "TER_FEC_INI";
            this.TER_FEC_INI.HeaderText = "Fecha Inicia";
            this.TER_FEC_INI.Name = "TER_FEC_INI";
            // 
            // TER_FEC_FIN
            // 
            this.TER_FEC_FIN.DataPropertyName = "TER_FEC_FIN";
            this.TER_FEC_FIN.HeaderText = "Fecha Fin";
            this.TER_FEC_FIN.Name = "TER_FEC_FIN";
            // 
            // TER_FEC_REG
            // 
            this.TER_FEC_REG.DataPropertyName = "TER_FEC_REG";
            this.TER_FEC_REG.HeaderText = "Fecha Registra";
            this.TER_FEC_REG.Name = "TER_FEC_REG";
            // 
            // dgvDataDT
            // 
            this.dgvDataDT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataDT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NUM_DT,
            this.MES,
            this.SEG_ROL_ID,
            this.TER_VAL_VALOR,
            this.TER_VAL_VALOR_TER});
            this.dgvDataDT.Location = new System.Drawing.Point(6, 119);
            this.dgvDataDT.Name = "dgvDataDT";
            this.dgvDataDT.Size = new System.Drawing.Size(523, 183);
            this.dgvDataDT.TabIndex = 1;
            // 
            // NUM_DT
            // 
            this.NUM_DT.DataPropertyName = "NUM";
            this.NUM_DT.HeaderText = "Num";
            this.NUM_DT.Name = "NUM_DT";
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
            this.SEG_ROL_ID.HeaderText = "Período";
            this.SEG_ROL_ID.Name = "SEG_ROL_ID";
            // 
            // TER_VAL_VALOR
            // 
            this.TER_VAL_VALOR.DataPropertyName = "TER_VAL_VALOR";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TER_VAL_VALOR.DefaultCellStyle = dataGridViewCellStyle1;
            this.TER_VAL_VALOR.HeaderText = "Valor";
            this.TER_VAL_VALOR.Name = "TER_VAL_VALOR";
            // 
            // TER_VAL_VALOR_TER
            // 
            this.TER_VAL_VALOR_TER.DataPropertyName = "TER_VAL_VALOR_TER";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TER_VAL_VALOR_TER.DefaultCellStyle = dataGridViewCellStyle2;
            this.TER_VAL_VALOR_TER.HeaderText = "Valor Décimo";
            this.TER_VAL_VALOR_TER.Name = "TER_VAL_VALOR_TER";
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.tabPage2);
            this.tabAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAdmin.Location = new System.Drawing.Point(0, 0);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(546, 421);
            this.tabAdmin.TabIndex = 42;
            // 
            // frmDetalleDecimoTercero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 421);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.tabAdmin);
            this.Name = "frmDetalleDecimoTercero";
            this.Text = "frmDetalleDecimoTercero";
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDT)).EndInit();
            this.tabAdmin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider ErrProv;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtDecimo;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEditCancel;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNewSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridView dgvDataDT;
        private System.Windows.Forms.ToolTip ttMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TER_FEC_INI;
        private System.Windows.Forms.DataGridViewTextBoxColumn TER_FEC_FIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TER_FEC_REG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUM_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MES;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEG_ROL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TER_VAL_VALOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn TER_VAL_VALOR_TER;
    }
}