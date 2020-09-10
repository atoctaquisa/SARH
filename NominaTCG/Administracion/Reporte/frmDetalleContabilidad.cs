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
            
        }        
        #endregion

        private void ClearControl()
        {
            txtFechaFin.Text = string.Empty;
            txtFechaIni.Text = string.Empty;
            txtReproceso.Text = string.Empty;
            txtRol.Text = string.Empty;
            ContratoBO.RolSeg = new DatRolSeg();
        }


        private void btnSearchRol_Click(object sender, EventArgs e)
        {
            var frm = new frmPeridoRolLista("PeridoRolCompleto");
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
            path = @"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\Reportes\Contabilidad.rdlc";
            //System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            LocalReport report = new LocalReport();
            //report.ReportPath = path + @"\RolIndividual.rdlc";
            ReportBO = ReportDataController.Instancia;

            DataTable dtConsulta = ReportBO.DetalleContabilidad(txtRol.Text, txtReproceso.Text);
            frmViewReport frm = new frmViewReport(dtConsulta, new ReportDataSource("DataSet1", dtConsulta), path);
            frm.Show();
            ClearControl();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }
    }
}
