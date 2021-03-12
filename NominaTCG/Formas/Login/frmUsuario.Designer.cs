namespace NominaTCG
{
    partial class frmUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuario));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMessage = new System.Windows.Forms.ToolTip(this.components);
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tabAdmin = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboPerfil = new System.Windows.Forms.ComboBox();
            this.txtContraseniaConf = new System.Windows.Forms.TextBox();
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEditCancel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNewSave = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
            this.tabAdmin.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.lblTitulo.Size = new System.Drawing.Size(569, 28);
            this.lblTitulo.TabIndex = 38;
            this.lblTitulo.Text = "Usuarios";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrProv
            // 
            this.ErrProv.ContainerControl = this;
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
            this.tabAdmin.Location = new System.Drawing.Point(0, 0);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(569, 237);
            this.tabAdmin.TabIndex = 39;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSearch);
            this.tabPage2.Controls.Add(this.cboPerfil);
            this.tabPage2.Controls.Add(this.txtContraseniaConf);
            this.tabPage2.Controls.Add(this.txtCodigo);
            this.tabPage2.Controls.Add(this.txtContrasenia);
            this.tabPage2.Controls.Add(this.txtNombre);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.lblTotalRecord);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(561, 211);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Administración";
            // 
            // btnSearch
            // 
            this.btnSearch.ImageIndex = 5;
            this.btnSearch.ImageList = this.imgList;
            this.btnSearch.Location = new System.Drawing.Point(381, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(31, 23);
            this.btnSearch.TabIndex = 41;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboPerfil
            // 
            this.cboPerfil.FormattingEnabled = true;
            this.cboPerfil.Location = new System.Drawing.Point(262, 71);
            this.cboPerfil.Name = "cboPerfil";
            this.cboPerfil.Size = new System.Drawing.Size(150, 21);
            this.cboPerfil.TabIndex = 37;
            // 
            // txtContraseniaConf
            // 
            this.txtContraseniaConf.Location = new System.Drawing.Point(262, 114);
            this.txtContraseniaConf.Name = "txtContraseniaConf";
            this.txtContraseniaConf.Size = new System.Drawing.Size(150, 20);
            this.txtContraseniaConf.TabIndex = 36;
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Location = new System.Drawing.Point(262, 93);
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.Size = new System.Drawing.Size(150, 20);
            this.txtContrasenia.TabIndex = 36;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(262, 50);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(150, 20);
            this.txtNombre.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Perfil";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Contraseña Confirmar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Nombre";
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Location = new System.Drawing.Point(443, 426);
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
            this.groupBox2.Location = new System.Drawing.Point(3, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(555, 57);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            // 
            // btnEditCancel
            // 
            this.btnEditCancel.ImageKey = "btnEdit.png";
            this.btnEditCancel.ImageList = this.imgList;
            this.btnEditCancel.Location = new System.Drawing.Point(187, 19);
            this.btnEditCancel.Name = "btnEditCancel";
            this.btnEditCancel.Size = new System.Drawing.Size(89, 29);
            this.btnEditCancel.TabIndex = 31;
            this.btnEditCancel.Text = "&Editar";
            this.btnEditCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditCancel.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.ImageIndex = 11;
            this.btnExit.ImageList = this.imgList;
            this.btnExit.Location = new System.Drawing.Point(501, 19);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 29);
            this.btnExit.TabIndex = 31;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnNewSave
            // 
            this.btnNewSave.Enabled = false;
            this.btnNewSave.ImageIndex = 2;
            this.btnNewSave.ImageList = this.imgList;
            this.btnNewSave.Location = new System.Drawing.Point(276, 19);
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
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(262, 29);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(116, 20);
            this.txtCodigo.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Código";
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 237);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.tabAdmin);
            this.Name = "frmUsuario";
            this.Text = "frmUsuario";
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            this.tabAdmin.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ErrorProvider ErrProv;
        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEditCancel;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNewSave;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip ttMessage;
        private System.Windows.Forms.ComboBox cboPerfil;
        private System.Windows.Forms.TextBox txtContraseniaConf;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label5;
    }
}