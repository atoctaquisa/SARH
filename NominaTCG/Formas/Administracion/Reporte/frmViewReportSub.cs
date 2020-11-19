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


namespace NominaTCG
{
    public partial class frmViewReportSub : Form
    {
        //private DataTable _Datos;
        private ReportDataSource _reporte;
        private ReportDataSource _reporteSub;
        private string _path;
        public frmViewReportSub(ReportDataSource reporte, ReportDataSource reporteSub, string path)
        {
            InitializeComponent();
            //_Datos = new System.Data.DataTable();
            //_Datos = datos;
            _reporte = reporte;
            _reporteSub = reporteSub;
            _path = path;
        }
        
        void a(object sender, SubreportProcessingEventArgs e)
        {
            //ObjectDataSource2.SelectParameters("Param1") = new par("Param1", DbType.Int32, e.Parameters.Item(0).Values(0))
            e.DataSources.Add(_reporteSub);
        }
        private void frmViewReport_Load(object sender, EventArgs e)
        {
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            //this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "SolicitudVacacion.rdlc";
            this.reportViewer1.LocalReport.ReportPath =_path;
            //ReportDataSource rds = new ReportDataSource("DataSet1", _Datos);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(a);
            this.reportViewer1.LocalReport.DataSources.Add(_reporte);           
            this.reportViewer1.RefreshReport();
            //this.reportViewer1.PrintDialog();

            //this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            ////this.reportViewer1.LocalReport.ReportEmbeddedResource = "SolicitudVacacion.rdlc";
            //this.reportViewer1.LocalReport.ReportPath = @"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\Reportes\SolicitudVacacion.rdlc";
            //ReportDataSource rds = new ReportDataSource("DataSet1", _Datos);
            //this.reportViewer1.LocalReport.DataSources.Clear();
            //this.reportViewer1.LocalReport.DataSources.Add(rds);
            //this.reportViewer1.RefreshReport();
            ////this.reportViewer1.PrintDialog();

        }
    }
}
