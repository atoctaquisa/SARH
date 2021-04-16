using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entity;
using BusinessLogic;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;


namespace NominaTCG
{
    public partial class frmDetalleContabilidad : Form
    {
        private ContratoController ContratoBO { get; set; }
        private ReportDataController ReportBO { get; set; }
        private LocalController LocalBO { get; set; }
        private PatronoController PatronoBO { get; set; }
        private SistemaController SistemaBO { get; set; }

        #region Instancia / Constructor
        private static frmDetalleContabilidad _instancia;
        public static frmDetalleContabilidad Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmDetalleContabilidad();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmDetalleContabilidad()
        {
            InitializeComponent();
            ContratoBO = ContratoController.Instancia;
            ReportBO = ReportDataController.Instancia;
            LocalBO = LocalController.Instancia;
            PatronoBO = PatronoController.Instancia;
            SistemaBO = SistemaController.Instancia;
            cboTipo.SelectedIndex = 1;
            enableControl(rbtPeriodo.Checked);
            cboPatrono.DataSource = PatronoBO.Listar();
            cboPatrono.DisplayMember = "PAT_RAZ_SOCIAL";
            cboPatrono.ValueMember = "PAT_ID";
            cboPatrono.SelectedIndex = -1;
        }
        #endregion
        private void enableControl(Boolean op)
        {

            txtFechaFin.Enabled = op;
            txtFechaIni.Enabled = op;
            txtReproceso.Enabled = op;
            txtRol.Enabled = op;
            cboTipo.Enabled = op;
            btnSearchRol.Enabled = op;

            pFechaFin.Enabled = !op;
            pFechaIni.Enabled = !op;
            cboPatrono.Enabled = !op;
            btnLocal.Enabled = !op;
            //txtLocal.Enabled = !op;

        }
        private void ClearControl()
        {
            txtFechaFin.Text = string.Empty;
            txtFechaIni.Text = string.Empty;
            txtReproceso.Text = string.Empty;
            txtRol.Text = string.Empty;
            ContratoBO.RolSeg = new DatRolSeg();
            pFechaFin.Value = DateTime.Now;
            pFechaIni.Value = DateTime.Now;
            txtLocal.Text = string.Empty;
            cboPatrono.SelectedIndex = -1;

        }

        private string ReadPath(string empresa)
        {
            //string path = @"C:\Transferencia\"; 
            string path = SistemaBO.Path("82");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }


        private void btnSearchRol_Click(object sender, EventArgs e)
        {
            var frm = new frmPeridoRolLista("PeridoRolCompletoA");
            Design.frmDialog(frm, "Lista de Roles");
            txtRol.Text = ContratoBO.RolSeg.segRolId.ToString();
            txtReproceso.Text = ContratoBO.RolSeg.segRolRepro.ToString();
            txtFechaIni.Text = ContratoBO.RolSeg.rolFechaIni.ToString();
            txtFechaFin.Text = ContratoBO.RolSeg.rolFechaFin.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            string path;
            path = Catalogo.PathReport;
            //path = @"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\Formas\Reportes\ContabilidadF.rdlc";
            //path = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\Contabilidad.rdlc";           
           
            ReportBO = ReportDataController.Instancia;
            DataTable dtConsulta;
            if (rbtPeriodo.Checked)
            {
                if (cboTipo.Text.Equals("Detallado"))
                    path += "Contabilidad.rdlc";
                else
                    path += "ContabilidadC.rdlc";
                dtConsulta = ReportBO.DetalleContabilidad(txtRol.Text, txtReproceso.Text, cboTipo.Text);
                frmViewReport frm = new frmViewReport(new ReportDataSource("DataSet1", dtConsulta), path, null, string.Empty);
                frm.Show();

            }
            else
            {
                path += "ContabilidadF.rdlc";
                dtConsulta = ReportBO.DetalleContabilidad(pFechaIni.Text, pFechaFin.Text, cboPatrono.SelectedValue == null ? "" : cboPatrono.SelectedValue.ToString(), LocalBO.Local.LocalID == 0 ? "" : LocalBO.Local.LocalID.ToString());                
                string nameFile = (pFechaIni.Text + "-" + pFechaFin.Text + ".txt").Replace("/","");
                nameFile=ReadPath("") + nameFile;
                if (dtConsulta.Rows.Count > 0)
                {
                    if (Utility.MensajeQuestion("Desea exporta a un archivo .txt") == DialogResult.Yes)
                    {

                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(nameFile))
                        {
                            foreach (DataRow row in dtConsulta.Rows)
                            {
                                file.WriteLine(row[0] + "," + row[1] + "," + row[2] + "," + row[3] + "," +
                                               row[4] + "," + row[5] + "," + row[6] + "," + row[7] + "," +
                                               row[8] + "," + row[9] + "," + row[10] + "," + row[11]);
                            }                            
                        }
                        Utility.MensajeInfo("Archivo Generado..!! " + nameFile);
                    }
                    else
                    {
                        frmViewReport frm = new frmViewReport(new ReportDataSource("DataSet1", dtConsulta), path, null, string.Empty);
                        frm.Show();

                    }
                }
                else
                    Utility.MensajeError("Los filtros establecidos no generó ningun resultado..!!");
            }

            ClearControl();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void frmDetalleContabilidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;            
        }

        private void rbtPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            enableControl(true);
        }        

        private void rbtFecha_CheckedChanged(object sender, EventArgs e)
        {
            enableControl(false);
        }
    }
}
