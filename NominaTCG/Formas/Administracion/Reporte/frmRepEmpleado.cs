using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using BusinessLogic;
using Microsoft.Reporting.WinForms;

namespace NominaTCG
{
    public partial class frmRepEmpleado : Form
    {
        ReportDataController ReportBO { get; set; }
        private LocalController LocalBO { get; set; }
        private PatronoController PatronoBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }
        private DataTable _dataRep;


        private string _query;
        #region Instancia / Constructor
        private static frmRepEmpleado _instancia;

        public static frmRepEmpleado Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmRepEmpleado();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmRepEmpleado()
        {
            InitializeComponent();
            ReportBO = ReportDataController.Instancia;
            LocalBO = LocalController.Instancia;
            PatronoBO = PatronoController.Instancia;
            ContratoBO = ContratoController.Instancia;
            EmpleadoBO = EmpleadoController.Instancia;

            cboPatrono.DataSource = PatronoBO.Listar();
            cboPatrono.DisplayMember = "PAT_RAZ_SOCIAL";
            cboPatrono.ValueMember = "PAT_ID";
            cboPatrono.SelectedIndex = -1;
            cboLabEstado.DataSource = Entity.Catalogo.EstadoLaboral();
            cboLabEstado.DisplayMember = "Nombre";
            cboLabEstado.ValueMember = "ID";
            cboLabEstado.SelectedIndex = -1;
            cboConContrato.DataSource = ContratoBO.ListarContrato();
            cboConContrato.DisplayMember = "CON_NOMBRE";
            cboConContrato.ValueMember = "CON_ID";
            cboConContrato.SelectedIndex = -1;
            cboDiscapacidad.DataSource = Entity.Catalogo.RespCorta();
            cboDiscapacidad.DisplayMember = "Nombre";
            cboDiscapacidad.ValueMember = "ID";
            cboDiscapacidad.SelectedIndex = -1;
            cboMes.DataSource = Entity.Catalogo.MesAnio();
            cboMes.DisplayMember = "Nombre";
            cboMes.ValueMember = "ID";
            cboMes.SelectedIndex = -1;
        }
        #endregion
        private void ClearControl()
        {
            cboPatrono.SelectedIndex = -1;
            cboLabEstado.SelectedIndex = -1;
            cboConContrato.SelectedIndex = -1;
            cboDiscapacidad.SelectedIndex = -1;
            cboMes.SelectedIndex = -1;
            txtLocal.Text = string.Empty;
            txtEmpleado.Text = string.Empty;
            txtFechaConIni.Text = string.Empty;
            txtFechaConFin.Text = string.Empty;
            txtFechaIngFin.Text = string.Empty;
            txtFechaIngIni.Text = string.Empty;
            txtFechaSalFin.Text = string.Empty;
            txtFechaSalIni.Text = string.Empty;
            chkCargaFa.Checked = false;
        }
        private Boolean ValidaControl()
        {
            ErrProv.Clear();
            _query = string.Empty;

            if (!txtFechaConIni.Text.Equals(string.Empty) | !txtFechaConFin.Text.Equals(string.Empty))
            {
                if (Utility.IsDate(txtFechaConIni.Text) & Utility.IsDate(txtFechaConFin.Text))
                {
                    _query += " AND EMP_CON_FEC_CONTRATO BETWEEN '" + Convert.ToDateTime(txtFechaConFin.Text).ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"))
                                    + "' AND '" + Convert.ToDateTime(txtFechaConIni.Text).ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US")) + "' ";
                }
                else
                {
                    ErrProv.SetError(txtFechaConFin, "Verifique el valor de fechas");
                    return false;
                }
            }
            if (!txtFechaIngIni.Text.Equals(string.Empty) | !txtFechaIngFin.Text.Equals(string.Empty))
            {
                if (Utility.IsDate(txtFechaIngIni.Text) & Utility.IsDate(txtFechaIngFin.Text))
                {
                    _query += "AND LAB_FEC_INGRESO BETWEEN '" + Convert.ToDateTime(txtFechaIngIni.Text).ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"))
                                    + "' AND '" + Convert.ToDateTime(txtFechaIngFin.Text).ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US")) + "' ";
                }
                else
                {
                    ErrProv.SetError(txtFechaIngFin, "Verifique el valor de fechas");
                    return false;
                }
            }
            if (!txtFechaSalIni.Text.Equals(string.Empty) | !txtFechaSalFin.Text.Equals(string.Empty))
            {
                if (Utility.IsDate(txtFechaSalIni.Text) & Utility.IsDate(txtFechaSalFin.Text))
                {
                    _query += " AND EMP_FEC_SALIDAREAL BETWEEN '" + Convert.ToDateTime(txtFechaSalIni.Text).ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"))
                                    + "' AND '" + Convert.ToDateTime(txtFechaSalFin.Text).ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US")) + "' ";
                }
                else
                {
                    ErrProv.SetError(txtFechaSalFin, "Verifique el valor de fechas");
                    return false;
                }
            }
            if (!cboPatrono.Text.Equals(string.Empty))
                _query += " AND PATRONO = '" + cboPatrono.Text + "'";

            if (!cboConContrato.Text.Equals(string.Empty))
                _query += " AND TIPO_CONTRATO = '" + cboConContrato.Text + "'";

            if (!cboLabEstado.Text.Equals(string.Empty))
                _query += " AND LAB_ESTADO = " + cboLabEstado.SelectedValue;

            if (!cboDiscapacidad.Text.Equals(string.Empty))
                _query += " AND EMP_DISCAPACIDAD = " + cboDiscapacidad.SelectedValue;

            if (!cboMes.Text.Equals(string.Empty))
                _query += " AND TO_NUMBER(TO_CHAR(EMP_FEC_NAC,'MM')) = " + cboMes.SelectedValue;

            if (!txtLocal.Text.Equals(string.Empty))
                _query += " AND LOC_ID = " + LocalBO.Local.LocalID.ToString();

            if (!txtEmpleado.Text.Equals(string.Empty))
                _query += " AND EMP_ID = " + EmpleadoBO.Empleado.empId.ToString();

            return true;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (ValidaControl())
            {
                _dataRep = new DataTable();
                if (chkCargaFa.Checked)
                {
                    _dataRep = ReportBO.CargaFamiliar(_query);
                }
                else
                {
                    _dataRep = ReportBO.DetalleEmpleado(_query);
                }
                dgvData.DataSource = _dataRep;
                lblTotalRecord.Text = "Total Registros: " + _dataRep.Rows.Count.ToString();
            }

        }

        private void frmRepEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (_dataRep == null || _dataRep.Rows.Count > 0)
                btnConsultar_Click(sender, e);

            if (_dataRep.Rows.Count > 0)
            {
                string path;
                path = Catalogo.PathReport;
                frmViewReport frm;
                //path = @"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\Formas\Reportes\Empleado.rdlc";
                //path = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\Contabilidad.rdlc";            
                if (chkCargaFa.Checked)
                {
                    path = Catalogo.PathReport + "CargaFami.rdl";
                    frm = new frmViewReport(new ReportDataSource("CargaFami", _dataRep), path, null, "");
                }
                else
                {
                    path += "Empleado.rdlc";
                    frm = new frmViewReport(new ReportDataSource("DataSet1", _dataRep), path, null, string.Empty);
                    
                }
                frm.Show();
                ClearControl();
            }
            else
                Utility.MensajeInfo("No hay datos por procesar..!!");

        }
    }
}
