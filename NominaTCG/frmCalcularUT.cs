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
    public partial class frmCalcularUT : Form
    {
        private ReportDataController ReportBO { get; set; }
        private PatronoController PatronoBO { get; set; }

        #region Instancia / Constructor
        private static frmCalcularUT _instancia;
        public static frmCalcularUT Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmCalcularUT();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmCalcularUT()
        {
            InitializeComponent();
            ReportBO = ReportDataController.Instancia;
            PatronoBO = PatronoController.Instancia;
            cboPatrono.DataSource = PatronoBO.Listar();
            cboPatrono.DisplayMember = "PAT_RAZ_SOCIAL";
            cboPatrono.ValueMember = "PAT_ID";
            cboPatrono.SelectedIndex = -1;
        }

        #endregion

        private void ClearControl()
        {
            //EmpleadoBO.Empleado = new DatEmp();
            //LocalBO.Local = new LocalEntity();
            //txtEmpleado.Text = string.Empty;
            //txtLocal.Text = string.Empty;
            txtPerido.Text = string.Empty;
            cboPatrono.SelectedIndex = -1;
            cboTipo.SelectedIndex = 0;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string path;
            LocalReport report = new LocalReport();
            ReportBO = ReportDataController.Instancia;
            string param = string.Empty;

            if (!txtPerido.Text.Equals(""))
                param += " AND VAC_PER_DADO ='" + txtPerido.Text + "'";

            if (!cboPatrono.Text.Equals(""))
                param += " AND V.PAT_ID=" + cboPatrono.SelectedValue.ToString();


            DataTable dtConsulta = ReportBO.CargaFamiliar(param);
            frmViewReport frm;
            if (cboTipo.Text.Equals("Consolidado"))
            {
                path = Catalogo.PathReport + "CargaFami.rdlc";
                frm = new frmViewReport(new ReportDataSource("CargaFami", dtConsulta), path, null, "");
            }
            else
            {
                path = Catalogo.PathReport + "CargaFami.rdlc";
                frm = new frmViewReport(new ReportDataSource("CargaFami", dtConsulta), path, null, "");
            }
            frm.Show();
            ClearControl();
        }
    }
}
