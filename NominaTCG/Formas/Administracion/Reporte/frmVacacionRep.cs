using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using Entity;

using System.Drawing.Imaging;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;

namespace NominaTCG
{
    public partial class frmVacacionRep : Form
    {
        private LocalController LocalBO { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }
        private ReportDataController ReportBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        private PatronoController PatronoBO { get; set; }

        #region Instancia / Constructor
        private static frmVacacionRep _instancia;
        public static frmVacacionRep Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmVacacionRep();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmVacacionRep()
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
            cboTipo.SelectedIndex = 0;

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
            cboTipo.SelectedIndex = 0;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string path;
            //path = @"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\Formas\Reportes\VacacionDT.rdlc";            
            LocalReport report = new LocalReport();            
            ReportBO = ReportDataController.Instancia;
            string param = string.Empty ;
            
            if (chkEstado.Checked)
               param+= " AND LAB_ESTADO = 1";
            else
                param += " AND LAB_ESTADO <> 1";

            if (chkValor.Checked)
                param += " AND CAB_VAC_DIAS_PEN > 0";           

            if (!txtPerido.Text.Equals(""))
                param += " AND VAC_PER_DADO ='"+ txtPerido.Text+"'";

            if (!cboPatrono.Text.Equals(""))
                param+= " AND V.PAT_ID="+cboPatrono.SelectedValue.ToString();

            if (!txtEmpleado.Text.Equals(""))
                param += " AND C.EMP_ID=" + EmpleadoBO.Empleado.empId;

            if(!txtLocal.Text.Equals(""))
                param += " AND V.LOC_ID ="+ LocalBO.Local.LocalID;


            DataTable dtConsulta = ReportBO.Vacacion(param);            
            frmViewReport frm;
            if (cboTipo.Text.Equals("Consolidado"))
            {
                path = Catalogo.PathReport + "Vacacion.rdlc";
                frm = new frmViewReport(new ReportDataSource("Vacacion", dtConsulta), path, null, "");
            }
            else
            {
                path = Catalogo.PathReport + "VacacionDT.rdlc";
                frm = new frmViewReport(new ReportDataSource("Vacacion", dtConsulta), path, null, "VacacionSub");
            }            
            frm.Show();
            ClearControl();
        }

        private void frmVacacionRep_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnPerido_Click(object sender, EventArgs e)
        {
            var frm = new frmPeridoRolLista("PeridoVacacion");
            Design.frmDialog(frm, "Períodos Anuales");
            txtPerido.Text = ContratoBO.RolSeg.segRolObs == null? "":ContratoBO.RolSeg.segRolObs.ToString();
            
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
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
        }
        
    }
}
