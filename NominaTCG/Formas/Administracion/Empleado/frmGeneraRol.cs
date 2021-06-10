using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security;
using System.Security.Permissions;
using Microsoft.Reporting;
using System.IO;

using BusinessLogic;
using db = Entity;

using Microsoft.Reporting.WinForms;
using System.Web;





namespace NominaTCG
{
    public partial class frmGeneraRol : Form
    {
        private EmpleadoController EmpleadoBO { get; set; }
        private static string pdfPath;// = Properties.Settings.Default.pathPDF;
        private static PermissionSet permissions;
        private Microsoft.Reporting.WinForms.ReportViewer RptViewer;
        private sarh_response response;
        private ReportDataController ReportBO { get; set; }
        private ContratoController ContratoBO { get; set; }


        #region Variables
        string _peridoID;
        #endregion

        #region Instancia / Constructor
        private static frmGeneraRol _instancia;
        public static frmGeneraRol Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmGeneraRol();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmGeneraRol()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;                        
            ReportBO = ReportDataController.Instancia;
            ContratoBO = ContratoController.Instancia;
        }

        #endregion

        private string ReadPath(string empresa)
        {
            //string path = @"C:\Transferencia\"; 
            string path = "";//SistemaBO.Path("61") + empresa + @"\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        private sarh_response createRetencionPdf(string fileName)
        {
            string rolID = ContratoBO.RolSeg.segRolId.ToString();//"107";//dgvData.Rows[dgvData.CurrentRow.Index].Cells["SEG_ROL_ID"].Value.ToString();
            string reproID = ContratoBO.RolSeg.segRolRepro.ToString();// dgvData.Rows[dgvData.CurrentRow.Index].Cells["SEG_ROL_REPRO"].Value.ToString();
            DataTable dtConsulta = ReportBO.RolIndividual(rolID, reproID, "", "", "");
            DataTable dtResultado = new DataTable();
            string rptName = "RolV.rdlc";
            dtResultado.Columns.Add("DETALLE", typeof(string));

            foreach (DataRow emp in dtConsulta.Rows)
            {
                string pdfName = ContratoBO.RolSeg.segRolId.ToString()+"_"+emp["EMP_ID"].ToString() + ".pdf";
                dtResultado.Clear();
                DataRow resultRow = dtResultado.NewRow();
                resultRow["DETALLE"] = emp["DETALLE"].ToString();
                dtResultado.Rows.Add(resultRow);

                response = new sarh_response();
                permissions = new PermissionSet(PermissionState.Unrestricted);
                Microsoft.Reporting.WinForms.ReportDataSource infoData;
                RptViewer = new ReportViewer();
                RptViewer.LocalReport.SetBasePermissionsForSandboxAppDomain(permissions);
                RptViewer.LocalReport.DataSources.Clear();

                infoData = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dtResultado);
                RptViewer.LocalReport.DataSources.Add(infoData);

                bool create = true;
                int count = 0;

                try
                {
                    pdfPath = Catalogo.PathDirReportPDF;
                    RptViewer.LocalReport.ReportPath = Catalogo.PathReport + rptName;
                    string dominio = AppDomain.CurrentDomain.DynamicDirectory;

                    RptViewer.LocalReport.Refresh();
                    var deviceInfo = @"<DeviceInfo>
                    <EmbedFonts>None</EmbedFonts>
                   </DeviceInfo>";

                    byte[] reporte = RptViewer.LocalReport.Render("PDF", deviceInfo);
                    //Byte[] reporte = RptViewer.LocalReport.Render("PDF");
                    System.IO.FileStream fs = System.IO.File.Create(pdfPath + "\\" + pdfName);
                    fs.Write(reporte, 0, reporte.Length);
                    fs.Close();
                    response.pathArchivoPDF = pdfName;
                    create = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Error:  ");
                    Console.WriteLine(e.HResult);
                    Console.WriteLine(" Error ");
                    string error = e.Message;
                    string trace = e.StackTrace;
                    while (e.InnerException != null)
                    {
                        e = e.InnerException;
                        error = error + " --- " + e.Message;
                        trace = trace + " --- " + e.StackTrace;
                    }

                    response.result = "ERROR";
                    response.resultData = "CREACION DEL PDF --- " + error + " --- " + trace;
                    Console.WriteLine(response.resultData);
                    count += 1;
                }

                RptViewer.Dispose();
            }
            return response;
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var frm = new frmPeridoRolLista("PeridoRolCorto");//"PeridoRolCompleto");
            Design.frmDialog(frm, "Lista de Roles");
            txtPeriodo.Text = ContratoBO.RolSeg.segRolId.ToString();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (txtPeriodo.Text.Equals(string.Empty))
            {
                Utility.MensajeInfo("Debe indicar el período generar.!!");
                return;
            }
                
            if (Utility.MensajeQuestion("Esta seguro que desea generar los roles a PDF: ") == DialogResult.Yes)
            {
                if(createRetencionPdf("Test").result.Equals("OK"))
                    Utility.MensajeInfo("Procesos Finalizado");
                else
                    Utility.MensajeInfo("Procesos Fallido");
            }
                            
        }

        private void frmGeneraRol_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPeriodo.Text = string.Empty;
        }
    }

    public class sarh_response
    {
        public string result { get; set; }

        public string resultData { get; set; }
        public string autorizacion { get; set; }
        public string fechaAutorizacion { get; set; }
        public string pathArchivo { get; set; }
        public string pathArchivoPDF { get; set; }
        public string archivo { get; set; }

        public sarh_response()
        {
            result = "OK";
        }
    }
}
