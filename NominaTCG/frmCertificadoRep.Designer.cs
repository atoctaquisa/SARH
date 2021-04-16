namespace NominaTCG
{
    partial class frmCertificadoRep
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
            this.crvCertificado = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCertificado
            // 
            this.crvCertificado.ActiveViewIndex = -1;
            this.crvCertificado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCertificado.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvCertificado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCertificado.Location = new System.Drawing.Point(0, 0);
            this.crvCertificado.Name = "crvCertificado";
            this.crvCertificado.Size = new System.Drawing.Size(800, 450);
            this.crvCertificado.TabIndex = 1;
            this.crvCertificado.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmCertificadoRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvCertificado);
            this.Name = "frmCertificadoRep";
            this.Text = "frmCertificadoRep";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCertificado;
    }
}