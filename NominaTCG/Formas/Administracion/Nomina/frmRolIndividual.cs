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
using System.Security;
using System.Security.Permissions;

namespace NominaTCG
{
    public partial class frmRolIndividual : Form
    {
        private LocalController LocalBO { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }
        private SolicitudController SolicitudBO { get; set; }
        private ReportDataController ReportBO { get; set; }
        private ContratoController ContratoBO { get; set; }

        private Microsoft.Reporting.WinForms.ReportViewer RptViewer;
        private static PermissionSet permissions;
        private static string pdfPath = @"c:\" ;//Properties.Settings.Default.pathPDF;

        #region Instancia / Constructor
        private static frmRolIndividual _instancia;
        public static frmRolIndividual Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmRolIndividual();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmRolIndividual()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            LocalBO = LocalController.Instancia;
            ContratoBO = ContratoController.Instancia;
            dgvData.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(222)))));            
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.RowHeadersVisible = false;
            dgvData.ReadOnly = true;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.DataSource = ContratoBO.ListaPeriodo("PREPO");
            cboCadena.DataSource = LocalBO.ListaCadena();
            cboCadena.DisplayMember = "CAD_NOMBRE";
            cboCadena.ValueMember = "CAD_ID";
            cboCadena.SelectedIndex = -1;            
            Design.vPeridoRol(dgvData);
            
        }
        
        #endregion

        private void frmRolIndividual_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;            
        }

        private void btnCadena_Click(object sender, EventArgs e)
        {
            
        }       

        private void btnDetalleRol_Click(object sender, EventArgs e)
        {
            string path;
            //path = @"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\Formas\Reportes\Rol.rdlc";
            path = Catalogo.PathReport + "Rol.rdlc"; //System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\Rol.rdlc";
            LocalReport report = new LocalReport();
            //report.ReportPath = path + @"\RolIndividual.rdlc";
            ReportBO = ReportDataController.Instancia;
            string rolID = dgvData.Rows[dgvData.CurrentRow.Index].Cells["SEG_ROL_ID"].Value.ToString();
            string reproID = dgvData.Rows[dgvData.CurrentRow.Index].Cells["SEG_ROL_REPRO"].Value.ToString();
            DataTable dtConsulta = ReportBO.RolIndividual(rolID, reproID, EmpleadoBO.Empleado.empId.ToString(), LocalBO.Local.LocalID.ToString(), cboCadena.SelectedValue == null ? "" : cboCadena.SelectedValue.ToString());
            //DataTable dtConsultaSub = ReportBO.RolIndividualSub("1");
            ReportDataSource data = new ReportDataSource("DataSet1", dtConsulta);
            //ReportDataSource dataSub = new ReportDataSource("DataSet1", dtConsultaSub);
            //ReportParameter[] param = new ReportParameter[1];
            frmViewReport frm = new frmViewReport(data, path,null,string.Empty);
            frm.Show();
            ClearControl();


            //--------------------------------------
            permissions = new PermissionSet(PermissionState.Unrestricted);
            RptViewer = new ReportViewer();
            RptViewer.LocalReport.SetBasePermissionsForSandboxAppDomain(permissions);
            RptViewer.LocalReport.DataSources.Clear();
            string pdfName = "C:\\Test.pdf";//codigoDocumento + ".pdf";
            string rptName = "1791997891001Retencion.rdlc";


            try
            {
                //Save on local path
                RptViewer.LocalReport.ReportPath = path;
                string dominio = AppDomain.CurrentDomain.DynamicDirectory;

                RptViewer.LocalReport.Refresh();
                Byte[] reportE = RptViewer.LocalReport.Render("PDF");
                System.IO.FileStream fs = System.IO.File.Create(pdfPath + "\\" + pdfName);
                fs.Write(reportE, 0, reportE.Length);
                fs.Close();
                //response.pathArchivoPDF = pdfName;
                //create = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" XXXXXXXXXXXXXXXXXXXXXXXXXXXXX ");
                Console.WriteLine(ex.HResult);
                Console.WriteLine(" XXXXXXXXXXXXXXXXXXXXXXXXXXXXX ");
                string error = ex.Message;
                string trace = ex.StackTrace;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    error = error + " --- " + ex.Message;
                    trace = trace + " --- " + ex.StackTrace;
                }

                //response.result = "ERROR";
                //response.resultData = "CREACION DEL PDF --- " + error + " --- " + trace;
                //Console.WriteLine(response.resultData);
                //count += 1;
            }

            //_reportViewer.LocalReport.DataSources.Clear();
            //var departmentsModels = new ReportDataSource() { Name = "Department_DS", Value = departments };
            //_reportViewer.LocalReport.DataSources.Add(departmentsModels);
            //var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
            //var MainPage = path + @"\subreportDemo\MainReport.rdlc";
            //_reportViewer.LocalReport.ReportPath = MainPage;
            //_reportViewer.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
            //_reportViewer.LocalReport.EnableExternalImages = true;
            //_reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            //_reportViewer.Refresh();
            //_reportViewer.RefreshReport();

            //string path;
            //path = @"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\Reportes\Report1.rdlc";
            ////System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            //LocalReport report = new LocalReport();
            ////report.ReportPath = path + @"\RolIndividual.rdlc";
            //ReportBO = ReportDataController.Instancia;
            //string rolID = dgvData.Rows[dgvData.CurrentRow.Index].Cells["SEG_ROL_ID"].Value.ToString();
            //string reproID = dgvData.Rows[dgvData.CurrentRow.Index].Cells["SEG_ROL_REPRO"].Value.ToString();
            //DataTable dtConsulta = ReportBO.Liquidacion("200612315233", "590");
            //frmViewReport frm = new frmViewReport(dtConsulta, new ReportDataSource("impLiquidacionDT", dtConsulta), path);
            //frm.Show();
            //ClearControl();

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
            txtEmpleado.Text = EmpleadoBO.Empleado.empNombre;            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void ClearControl()
        {
            EmpleadoBO.Empleado = new DatEmp();
            LocalBO.Local = new LocalEntity();
            txtEmpleado.Text = string.Empty;
            txtLocal.Text = string.Empty;
            cboCadena.SelectedIndex = -1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void txtLocal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
