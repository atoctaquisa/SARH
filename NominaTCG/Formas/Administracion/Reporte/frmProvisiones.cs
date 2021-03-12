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
    public partial class frmProvisiones : Form
    {
        private ContratoController ContratoBO { get; set; }
        private ReportDataController ReportBO { get; set; }
        private LocalController LocalBO { get; set; }
        private PatronoController PatronoBO { get; set; }

        #region Instancia / Constructor
        private static frmProvisiones _instancia;
        public static frmProvisiones Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmProvisiones();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmProvisiones()
        {
            InitializeComponent();
            ContratoBO = ContratoController.Instancia;
            ReportBO = ReportDataController.Instancia;
            LocalBO = LocalController.Instancia;
            PatronoBO = PatronoController.Instancia;
            cboPatrono.DataSource = PatronoBO.Listar();
            cboPatrono.DisplayMember = "PAT_RAZ_SOCIAL";
            cboPatrono.ValueMember = "PAT_ID";
            cboPatrono.SelectedIndex = -1;

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

        private void frmProvisiones_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
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

        private void btnLocal_Click(object sender, EventArgs e)
        {
            var frm = new frmLocalLista();
            Design.frmDialog(frm, "Lista de Locales");
            LocalBO.Lista();
            txtLocal.Text = LocalBO.Local.Nombre;
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            string path;
            //path = @"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\Formas\Reportes\Provision.rdlc";
            //path = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName)+ @"\PagoQuincena.rdlc";
            path = Catalogo.PathReport + "Provision.rdlc";
            LocalReport report = new LocalReport();            
            ReportBO = ReportDataController.Instancia;
            if (ValidaForm())
            {
                DataTable dtConsulta = ReportBO.Provision(pFechaIni.Value.ToString(),pFechaFin.Value.ToString(),
                    cboPatrono.SelectedValue == null ? "" : cboPatrono.SelectedValue.ToString(),
                    LocalBO.Local.LocalID == 0 ? "" : LocalBO.Local.LocalID.ToString(), "");                
                frmViewReport frm = new frmViewReport(new ReportDataSource("Provision", dtConsulta), path, null, string.Empty);
                frm.Show();
            }
        }
        string _Filter;
        private bool ValidaForm()
        {
           if(!string.IsNullOrEmpty( txtLocal.Text))
            {
                _Filter += txtLocal.Text;
            }
            if (!string.IsNullOrEmpty(cboPatrono.Text))
            {
                _Filter += cboPatrono.Text;
            }
            return true;
        }
    }
}
