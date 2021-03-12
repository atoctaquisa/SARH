namespace NominaTCG
{
    partial class frmRolNegativoRep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRolNegativoRep));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.ttMessage = new System.Windows.Forms.ToolTip(this.components);
            this.tabAdmin = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.txtFechaFin = new System.Windows.Forms.TextBox();
            this.btnSearchRol = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Label4 = new System.Windows.Forms.Label();
            this.txtFechaIni = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtReproceso = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNewSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tabAdmin.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
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
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.tabPage2);
            this.tabAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAdmin.Location = new System.Drawing.Point(0, 28);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(447, 253);
            this.tabAdmin.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(439, 227);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Administración";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtRol);
            this.groupBox3.Controls.Add(this.txtFechaFin);
            this.groupBox3.Controls.Add(this.btnSearchRol);
            this.groupBox3.Controls.Add(this.Label4);
            this.groupBox3.Controls.Add(this.txtFechaIni);
            this.groupBox3.Controls.Add(this.Label3);
            this.groupBox3.Controls.Add(this.Label1);
            this.groupBox3.Controls.Add(this.txtReproceso);
            this.groupBox3.Controls.Add(this.Label2);
            this.groupBox3.Location = new System.Drawing.Point(17, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(399, 133);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parámetros";
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(166, 28);
            this.txtRol.MaxLength = 50;
            this.txtRol.Name = "txtRol";
            this.txtRol.ReadOnly = true;
            this.txtRol.Size = new System.Drawing.Size(121, 20);
            this.txtRol.TabIndex = 0;
            // 
            // txtFechaFin
            // 
            this.txtFechaFin.Location = new System.Drawing.Point(166, 91);
            this.txtFechaFin.MaxLength = 150;
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.ReadOnly = true;
            this.txtFechaFin.Size = new System.Drawing.Size(121, 20);
            this.txtFechaFin.TabIndex = 3;
            // 
            // btnSearchRol
            // 
            this.btnSearchRol.ImageIndex = 5;
            this.btnSearchRol.ImageList = this.imageList1;
            this.btnSearchRol.Location = new System.Drawing.Point(288, 27);
            this.btnSearchRol.Name = "btnSearchRol";
            this.btnSearchRol.Size = new System.Drawing.Size(31, 23);
            this.btnSearchRol.TabIndex = 35;
            this.btnSearchRol.UseVisualStyleBackColor = true;
            this.btnSearchRol.Click += new System.EventHandler(this.btnSearchRol_Click);
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
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(88, 95);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(54, 13);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Fecha Fin";
            // 
            // txtFechaIni
            // 
            this.txtFechaIni.Location = new System.Drawing.Point(166, 70);
            this.txtFechaIni.MaxLength = 13;
            this.txtFechaIni.Name = "txtFechaIni";
            this.txtFechaIni.ReadOnly = true;
            this.txtFechaIni.Size = new System.Drawing.Size(121, 20);
            this.txtFechaIni.TabIndex = 2;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(88, 74);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(65, 13);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Fecha Inicio";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(88, 31);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(23, 13);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Rol";
            // 
            // txtReproceso
            // 
            this.txtReproceso.Location = new System.Drawing.Point(166, 49);
            this.txtReproceso.MaxLength = 100;
            this.txtReproceso.Name = "txtReproceso";
            this.txtReproceso.ReadOnly = true;
            this.txtReproceso.Size = new System.Drawing.Size(121, 20);
            this.txtReproceso.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(88, 53);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(59, 13);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Reproceso";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnNewSave);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 57);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
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
            this.btnExit.ImageIndex = 11;
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(382, 18);
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
            // ErrProv
            // 
            this.ErrProv.ContainerControl = this;
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
            this.lblTitulo.Size = new System.Drawing.Size(447, 28);
            this.lblTitulo.TabIndex = 7;
            this.lblTitulo.Text = "Roles Negativos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmRolNegativoRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 281);
            this.Controls.Add(this.tabAdmin);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmRolNegativoRep";
            this.Text = "Rol Regativo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRolNegativoRep_FormClosing);
            this.tabAdmin.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolTip ttMessage;
        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.TextBox txtRol;
        internal System.Windows.Forms.TextBox txtFechaFin;
        private System.Windows.Forms.Button btnSearchRol;
        private System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtFechaIni;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtReproceso;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNewSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ErrorProvider ErrProv;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}