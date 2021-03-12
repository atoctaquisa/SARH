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
    public partial class frmRolNegativoRep : Form
    {
        private ContratoController ContratoBO { get; set; }
        private ReportDataController ReportBO { get; set; }

        #region Instancia / Constructor
        private static frmRolNegativoRep _instancia;
        public static frmRolNegativoRep Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmRolNegativoRep();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmRolNegativoRep()
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
            var frm = new frmPeridoRolLista("PeridoRolCompletoA");
            Design.frmDialog(frm, "Lista de Roles");
            txtRol.Text = ContratoBO.RolSeg.segRolId.ToString();
            txtReproceso.Text = ContratoBO.RolSeg.segRolRepro.ToString();
            txtFechaIni.Text = ContratoBO.RolSeg.rolFechaIni.ToString();
            txtFechaFin.Text = ContratoBO.RolSeg.rolFechaFin.ToString();
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            string path;
            path = Catalogo.PathReport;
            //path = @"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\Formas\Reportes\Contabilidad.rdlc";
            //path = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\Contabilidad.rdlc";           

            ReportBO = ReportDataController.Instancia;
            
                path += "RolNegativo.rdlc";
            DataTable dtConsulta = ReportBO.RolNegativo(txtRol.Text, txtReproceso.Text);
            frmViewReport frm = new frmViewReport(new ReportDataSource("RolNegativo", dtConsulta), path, null, string.Empty);
            frm.Show();
            ClearControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void frmRolNegativoRep_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }
    }
}
