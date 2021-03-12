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
using Microsoft.Reporting.WinForms;

namespace NominaTCG
{
    public partial class frmActuarial : Form
    {
        private ReportDataController ReportBO { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }


        #region Instancia / Constructor
        private static frmActuarial _instancia;
        public static frmActuarial Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmActuarial();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmActuarial()
        {
            InitializeComponent();
            InitializeControls();
           
        }
        private void InitializeControls()
        {
            ReportBO = ReportDataController.Instancia;
            EmpleadoBO = EmpleadoController.Instancia;            
        }
        #endregion
                    

        private void frmActuarial_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            DataSet dataEmp = EmpleadoBO.ActuarialEmpleado();
            dgvData.DataSource = dataEmp.Tables[0];
            lblData.Text = "Total Registro: " + dataEmp.Tables[0].Rows.Count;            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void dgvData_CurrentCellChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewCell item in dgvData.SelectedCells)
            {
                if (item.Selected)
                {
                    ViewDataEmp(item.RowIndex);                    
                }
            }
        }

        private void ViewDataEmp(int item)
        {
            DataSet data = EmpleadoBO.ActuarialEmpleado(dgvData.Rows[item].Cells["EMPID"].Value.ToString(), dgvData.Rows[item].Cells["CEDULA"].Value.ToString());
            dgvSueldo.DataSource = data.Tables[0];
            dgvIngreso.DataSource = data.Tables[1];
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            string path;
            //path = @"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\Formas\Reportes\Actuarial.rdlc";            
            path = Catalogo.PathReport + "Actuarial.rdlc";
            LocalReport report = new LocalReport();            
            ReportBO = ReportDataController.Instancia;

            DataTable dtConsulta = ReportBO.ActurialEmpresa("");            
            frmViewReport frm = new frmViewReport(new ReportDataSource("Actuarial", dtConsulta), path, null, "ActuarialSalida");
            frm.Show();
            
        }
    }
}
