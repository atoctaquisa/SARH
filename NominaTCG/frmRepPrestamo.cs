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
    public partial class frmRepPrestamo : Form
    {

        private LocalController LocalBO { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }
        private ReportDataController ReportBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        private PatronoController PatronoBO { get; set; }

        #region Instancia / Constructor
        private static frmRepPrestamo _instancia;
        public static frmRepPrestamo Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmRepPrestamo();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmRepPrestamo()
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
            txtPerido.Text = string.Empty;
            cboPatrono.SelectedIndex = -1;
        }


        private void btnPerido_Click(object sender, EventArgs e)
        {
            var frm = new frmPeridoRolLista("PeridoRolCorto");//"PeridoRolCompleto");
            Design.frmDialog(frm, "Lista de Roles");
            txtPerido.Text = ContratoBO.RolSeg.segRolId.ToString();
        }

        private void frmRepPrestamo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ReportParameter[] param = null;
            string path = string.Empty; ;
            if (cboTipo.Text.Equals("") | cboTipo.Text.Equals("Consolidado"))
            {
                param = new ReportParameter[1];
                param[0] = new ReportParameter("perID", ContratoBO.RolSeg.segRolId.ToString());
                //path = @"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\Prestamo.rdlc";
                path = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\Prestamo.rdlc";
            }
            if(cboTipo.Text.Equals("Detallado"))
            {
                param = null;
                //path = @"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\PrestamoDT.rdlc";
                path = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\PrestamoDT.rdlc";
            }
            if (cboTipo.Text.Equals("Consolidado Empresa"))
            {
                param = null;
                //path = @"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\PrestamoDT.rdlc";
                path = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\PrestamoEM.rdlc";
            }

            LocalReport report = new LocalReport();
            ReportBO = ReportDataController.Instancia;
            DataTable dtConsulta = ReportBO.Prestamo(ContratoBO.RolSeg.segRolId.ToString(),
                cboEstado.Text,
                cboPatrono.SelectedValue == null ? "" : cboPatrono.SelectedValue.ToString(),
                cboTipo.Text,
                EmpleadoBO.Empleado.empId == 0 ? "" : EmpleadoBO.Empleado.empId.ToString());
            frmViewReport frm = new frmViewReport(new ReportDataSource("dsPrestamo", dtConsulta), path, param);
            frm.Show();
            ClearControl();
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            var frm = new frmEmpleadoLista();
            frm.ShowDialog();
            txtEmpleado.Text = EmpleadoBO.Empleado.empNombre == null ? string.Empty : EmpleadoBO.Empleado.empNombre.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cboTipo.SelectedIndex = -1;
            cboPatrono.SelectedIndex = -1;
            cboEstado.SelectedIndex = -1;
            txtEmpleado.Text = string.Empty;
            txtPerido.Text = string.Empty;
        }
    }
}
