﻿namespace NominaTCG
{
    partial class frmCargaAsiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaAsiento));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnBack = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.ttMessage = new System.Windows.Forms.ToolTip(this.components);
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.btnGenerar);
            this.groupBox1.Controls.Add(this.btnProcesar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 393);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 57);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.ImageIndex = 10;
            this.btnExit.ImageList = this.imgList;
            this.btnExit.Location = new System.Drawing.Point(591, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 29);
            this.btnExit.TabIndex = 1;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.imgList.Images.SetKeyName(18, "btnGenRol.png");
            this.imgList.Images.SetKeyName(19, "btnOpenPer.png");
            // 
            // btnBack
            // 
            this.btnBack.ImageIndex = 11;
            this.btnBack.ImageList = this.imgList;
            this.btnBack.Location = new System.Drawing.Point(10, 14);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(39, 29);
            this.btnBack.TabIndex = 0;
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnProcesar
            // 
            this.btnProcesar.ImageIndex = 9;
            this.btnProcesar.ImageList = this.imgList;
            this.btnProcesar.Location = new System.Drawing.Point(242, 16);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(89, 29);
            this.btnProcesar.TabIndex = 2;
            this.btnProcesar.Text = "&Generar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Navy;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(642, 28);
            this.lblTitulo.TabIndex = 13;
            this.lblTitulo.Text = "Carga Asientos Contables";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrProv
            // 
            this.ErrProv.ContainerControl = this;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(507, 377);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(85, 13);
            this.lblTotal.TabIndex = 19;
            this.lblTotal.Text = "Total Diferencia:";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 70);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.Size = new System.Drawing.Size(618, 304);
            this.dgvData.TabIndex = 18;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(239, 41);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.ReadOnly = true;
            this.txtPeriodo.Size = new System.Drawing.Size(178, 20);
            this.txtPeriodo.TabIndex = 15;
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageIndex = 5;
            this.btnConsultar.ImageList = this.imgList;
            this.btnConsultar.Location = new System.Drawing.Point(418, 40);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(37, 23);
            this.btnConsultar.TabIndex = 16;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(188, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Período:";
            // 
            // btnGenerar
            // 
            this.btnGenerar.ImageIndex = 18;
            this.btnGenerar.ImageList = this.imgList;
            this.btnGenerar.Location = new System.Drawing.Point(331, 16);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(89, 29);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "&Cargar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // frmCargaAsiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.label12);
            this.Name = "frmCargaAsiento";
            this.Text = "Carga de Asientos Nomina JDE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargaAsiento_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ToolTip ttMessage;
        private System.Windows.Forms.ErrorProvider ErrProv;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnGenerar;
    }
}