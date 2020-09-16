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
    public partial class frmPagoQuincena : Form
    {
        private LocalController LocalBO { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }        
        private ReportDataController ReportBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        private PatronoController PatronoBO { get; set; }

        #region Instancia / Constructor
        private static frmPagoQuincena _instancia;
        public static frmPagoQuincena Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmPagoQuincena();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmPagoQuincena()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            LocalBO = LocalController.Instancia;
            ReportBO = ReportDataController.Instancia;
            ContratoBO = ContratoController.Instancia;
            PatronoBO = PatronoController.Instancia;
            cboPatrono.DataSource = PatronoBO.Listar();
            cboPatrono.DisplayMember = "PAT_RAZ_SOCIAL";
            cboPatrono.ValueMember = "PAT_ID";
            cboPatrono.SelectedIndex = -1;
        }
        
        #endregion

        private void ClearControl()
        {
            EmpleadoBO.Empleado = new DatEmp();
            LocalBO.Local = new LocalEntity();
            txtEmpleado.Text = string.Empty;
            txtLocal.Text = string.Empty;
            txtPerido.Text = string.Empty; 
            cboPatrono.SelectedIndex = -1;
        }

        private void frmPagoQuincena_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string path;
            path = //@"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\Reportes\PagoQuincena.rdlc";
            System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName)+ @"\PagoQuincena.rdlc";
            LocalReport report = new LocalReport();
            //report.ReportPath = path + @"\RolIndividual.rdlc";
            ReportBO = ReportDataController.Instancia;
            
            DataTable dtConsulta = ReportBO.PagoQuincena(ContratoBO.RolSeg.segRolId.ToString(),
                ContratoBO.RolSeg.segRolRepro.ToString(),
                cboPatrono.SelectedValue == null ? "" : cboPatrono.SelectedValue.ToString(), 
                LocalBO.Local.LocalID == 0 ? "": LocalBO.Local.LocalID.ToString(),
                EmpleadoBO.Empleado.empId ==0 ? "": EmpleadoBO.Empleado.empId.ToString() );
            frmViewReport frm = new frmViewReport(dtConsulta, new ReportDataSource("PagoQuincena", dtConsulta), path);
            frm.Show();
            ClearControl();
        }

        private void btnPerido_Click(object sender, EventArgs e)
        {
            var frm = new frmPeridoRolLista("PeridoRolCorto");//"PeridoRolCompleto");
            Design.frmDialog(frm, "Lista de Roles");
            txtPerido.Text = ContratoBO.RolSeg.segRolId.ToString();
            //txtReproceso.Text = ContratoBO.RolSeg.segRolRepro.ToString();
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            var frm = new frmLocalLista();
            Design.frmDialog(frm, "Lista de Locales");
            LocalBO.Lista();
            txtLocal.Text = LocalBO.Local.Nombre;
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            var frm = new frmEmpleadoLista();
            frm.ShowDialog();
            txtEmpleado.Text = EmpleadoBO.Empleado.empNombre == null ? string.Empty : EmpleadoBO.Empleado.empNombre.ToString();
            //empID = EmpleadoBO.Empleado.empId.ToString();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEmpleado.Text = string.Empty;
            txtLocal.Text = string.Empty;
            txtPerido.Text = string.Empty;
            cboPatrono.SelectedIndex = -1;
            EmpleadoBO.Empleado = new DatEmp();
            ContratoBO.RolSeg = new DatRolSeg();
            LocalBO.Local = new LocalEntity();

        }

        private void frmPagoQuincena_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

       
       
    }
}
