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
    public partial class frmCertificado : Form
    {
        private LocalController LocalBO { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }
        private ReportDataController ReportBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        private PatronoController PatronoBO { get; set; }


        #region Instancia / Constructor
        private static frmCertificado _instancia;
        public static frmCertificado Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmCertificado();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmCertificado()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            LocalBO = LocalController.Instancia;
            ReportBO = ReportDataController.Instancia;
            ContratoBO = ContratoController.Instancia;
            PatronoBO = PatronoController.Instancia;
            cboCertificado.DataSource = Catalogo.TipoCertificado();
            cboCertificado.DisplayMember = "Nombre";
            cboCertificado.ValueMember = "ID";
            cboCertificado.SelectedIndex = -1;
        }

        #endregion

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            var frm = new frmEmpleadoLista();
            frm.ShowDialog();
            txtEmpleado.Text = EmpleadoBO.Empleado.empNombre == null ? string.Empty : EmpleadoBO.Empleado.empNombre.ToString();
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (cboCertificado.SelectedValue == null)
                return;
            frmCertificadoRep frm = new frmCertificadoRep(EmpleadoBO.Empleado.empId.ToString(), cboCertificado.SelectedValue.ToString());
            Design.frmDialog(frm, "Reporte de Liquidación");            
        }

        private void frmCertificado_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtEmpleado.Text = string.Empty;
            cboCertificado.SelectedIndex = -1;
            EmpleadoBO.Empleado = null;                
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }
    }
}
