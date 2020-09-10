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
    public partial class frmRolIndividual : Form
    {
        private LocalController LocalBO { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }
        private SolicitudController SolicitudBO { get; set; }
        private ReportDataController ReportBO { get; set; }
        private ContratoController ContratoBO { get; set; }

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
            path = @"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\Reportes\Rol.rdlc";
            //System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            LocalReport report = new LocalReport();
            //report.ReportPath = path + @"\RolIndividual.rdlc";
            ReportBO = ReportDataController.Instancia;
            string rolID = dgvData.Rows[dgvData.CurrentRow.Index].Cells["SEG_ROL_ID"].Value.ToString();
            string reproID = dgvData.Rows[dgvData.CurrentRow.Index].Cells["SEG_ROL_REPRO"].Value.ToString();
            DataTable dtConsulta = ReportBO.RolIndividual(rolID, reproID, EmpleadoBO.Empleado.empId.ToString(), LocalBO.Local.LocalID.ToString(), cboCadena.SelectedValue == null ? "" : cboCadena.SelectedValue.ToString());
            frmViewReport frm = new frmViewReport(dtConsulta, new ReportDataSource("DataSet1", dtConsulta), path);
            frm.Show();
            ClearControl();

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

       
    }
}
