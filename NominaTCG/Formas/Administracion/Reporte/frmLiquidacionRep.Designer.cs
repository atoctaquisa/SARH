namespace NominaTCG
{
    partial class frmLiquidacionRep
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
            this.crvLiquidacion = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvLiquidacion
            // 
            this.crvLiquidacion.ActiveViewIndex = -1;
            this.crvLiquidacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvLiquidacion.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvLiquidacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvLiquidacion.Location = new System.Drawing.Point(0, 0);
            this.crvLiquidacion.Name = "crvLiquidacion";
            this.crvLiquidacion.Size = new System.Drawing.Size(800, 510);
            this.crvLiquidacion.TabIndex = 0;
            this.crvLiquidacion.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmLiquidacionRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.crvLiquidacion);
            this.Name = "frmLiquidacionRep";
            this.Text = "frmLiquidacionRep";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvLiquidacion;
    }
}