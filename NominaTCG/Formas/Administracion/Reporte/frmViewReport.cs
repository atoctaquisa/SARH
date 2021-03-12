using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using BusinessLogic;

namespace NominaTCG
{
    public partial class frmViewReport : Form
    {
        
        private ReportDataSource _reporte;
        private ReportParameter[] _param;        
        private string _path;
        private string _nameSubRep;
        public frmViewReport(ReportDataSource reporte, string path, ReportParameter[] param,string nameSubRep)
        {
            InitializeComponent();            
            _reporte = reporte;            
            _path = path;            
            _param = param;
            _nameSubRep = nameSubRep;
        }
        void callSubReport(object sender, SubreportProcessingEventArgs e)
        {            
            ReportDataController rp = new ReportDataController();
            if (_nameSubRep.Equals("ActuarialSalida"))
            {
                string cedula = e.Parameters["CI"].Values[0].ToString();
                DataTable dt =  rp.ActurialEmpresaSalida(cedula);
                ReportDataSource rdt = new ReportDataSource(_nameSubRep, dt);
                e.DataSources.Add(rdt);
            }

            if (_nameSubRep.Equals("VacacionSub"))
            {
                string empID = e.Parameters["EMPID"].Values[0].ToString();
                string vacID = e.Parameters["VACID"].Values[0].ToString();

                DataTable dt = rp.VacacionSub(empID, vacID);
                ReportDataSource rdt = new ReportDataSource(_nameSubRep, dt);
                e.DataSources.Add(rdt);
            }
        }
        private void frmViewReport_Load(object sender, EventArgs e)
        {
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;            
            this.reportViewer1.LocalReport.ReportPath =_path;           
           
           
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(_reporte);
            if (_param != null)
                this.reportViewer1.LocalReport.SetParameters(_param);
            if (!_nameSubRep.Equals(""))
                this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(callSubReport);

            this.reportViewer1.RefreshReport();            

        }
    }
}
