using System;
using Microsoft.Reporting.WinForms;
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
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;


namespace NominaTCG
{
    public partial class frmVacacionesSolicitud : Form
    {
        private SolicitudController SolicitudBO { get; set; }
        private ReportDataController ReportBO { get; set; }
        private string EmpID { get; set; }

        public frmVacacionesSolicitud(string empID, string idSolicitud)
        {
            InitializeComponent();
            dgvDatos.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 7);
            dgvDatos.AutoGenerateColumns = false;
            SolicitudBO = SolicitudController.Instancia;
            ReportBO = new ReportDataController();
            EmpID = empID;
            dgvDatos.DataSource = SolicitudBO.ListaSolicitudVacacion(EmpID, idSolicitud);            
        }

        private void frmVacacionesSolicitud_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == -1 | e.RowIndex == -1)
                return;
            else
            {
                if (e.ColumnIndex == 8)
                {
                    string path;
                    path = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);                   
                    LocalReport report = new LocalReport();
                    report.ReportPath = path + @"\SolicitudVacacion.rdlc";
                    report.DataSources.Add(
                       new ReportDataSource("DataSet1", ReportBO.SolicitudVacacion(EmpID, dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString())));
                    PrintReport prt = new PrintReport();
                    prt.Export(report);
                }
            }
        }

        private void frmVacacionesSolicitud_Load(object sender, EventArgs e)
        {
            //Design.vSolicitudVacacion(dgvDatos);
        }
    }
}
