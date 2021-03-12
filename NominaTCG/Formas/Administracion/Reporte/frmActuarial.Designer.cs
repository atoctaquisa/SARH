namespace NominaTCG
{
    partial class frmActuarial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActuarial));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.dgvSueldo = new System.Windows.Forms.DataGridView();
            this.dgvIngreso = new System.Windows.Forms.DataGridView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMessage = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNewSave = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnEditCancel = new System.Windows.Forms.Button();
            this.lblData = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSueldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngreso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.lblTitulo.Size = new System.Drawing.Size(926, 28);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Reporte Actuarial";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(3, 47);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.Size = new System.Drawing.Size(911, 197);
            this.dgvData.TabIndex = 7;
            this.dgvData.CurrentCellChanged += new System.EventHandler(this.dgvData_CurrentCellChanged);
            // 
            // dgvSueldo
            // 
            this.dgvSueldo.AllowUserToAddRows = false;
            this.dgvSueldo.AllowUserToDeleteRows = false;
            this.dgvSueldo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSueldo.Location = new System.Drawing.Point(3, 265);
            this.dgvSueldo.Name = "dgvSueldo";
            this.dgvSueldo.RowHeadersVisible = false;
            this.dgvSueldo.Size = new System.Drawing.Size(489, 162);
            this.dgvSueldo.TabIndex = 7;
            // 
            // dgvIngreso
            // 
            this.dgvIngreso.AllowUserToAddRows = false;
            this.dgvIngreso.AllowUserToDeleteRows = false;
            this.dgvIngreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngreso.Location = new System.Drawing.Point(526, 265);
            this.dgvIngreso.Name = "dgvIngreso";
            this.dgvIngreso.RowHeadersVisible = false;
            this.dgvIngreso.Size = new System.Drawing.Size(388, 162);
            this.dgvIngreso.TabIndex = 7;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEditCancel);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnNewSave);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 433);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(926, 57);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.ImageIndex = 11;
            this.btnExit.ImageList = this.imgList;
            this.btnExit.Location = new System.Drawing.Point(875, 16);
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
            this.btnNewSave.ImageIndex = 9;
            this.btnNewSave.ImageList = this.imgList;
            this.btnNewSave.Location = new System.Drawing.Point(506, 16);
            this.btnNewSave.Name = "btnNewSave";
            this.btnNewSave.Size = new System.Drawing.Size(89, 29);
            this.btnNewSave.TabIndex = 31;
            this.btnNewSave.Text = "&Calcular";
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
            // btnEditCancel
            // 
            this.btnEditCancel.ImageKey = "btnReport.png";
            this.btnEditCancel.ImageList = this.imgList;
            this.btnEditCancel.Location = new System.Drawing.Point(417, 16);
            this.btnEditCancel.Name = "btnEditCancel";
            this.btnEditCancel.Size = new System.Drawing.Size(89, 29);
            this.btnEditCancel.TabIndex = 31;
            this.btnEditCancel.Text = "&Exportar";
            this.btnEditCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditCancel.UseVisualStyleBackColor = true;
            this.btnEditCancel.Click += new System.EventHandler(this.btnEditCancel_Click);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(816, 31);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(85, 13);
            this.lblData.TabIndex = 35;
            this.lblData.Text = "Total Registro: 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Rubros Percibidos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(523, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Ingresos - Salida";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Lista de Empleados";
            // 
            // frmActuarial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 490);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvIngreso);
            this.Controls.Add(this.dgvSueldo);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmActuarial";
            this.Text = "Reporte Acturarial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmActuarial_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSueldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngreso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridView dgvSueldo;
        private System.Windows.Forms.DataGridView dgvIngreso;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ErrorProvider ErrProv;
        private System.Windows.Forms.ToolTip ttMessage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEditCancel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNewSave;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}