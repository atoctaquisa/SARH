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

namespace NominaTCG
{
    public partial class frmCertificadoRep : Form
    {
        private ReportDataController ReportBO { get; set; }
        public frmCertificadoRep(string empID)
        {
            InitializeComponent();
            ReportBO = ReportDataController.Instancia;
            //ContratoBO = ContratoController.Instancia;
            //EmpleadoBO = EmpleadoController.Instancia;
            NominaTCG.Formas.Reportes.CertificadoAct rpt = new NominaTCG.Formas.Reportes.CertificadoAct();
            DataTable data = ReportBO.Certificado(empID,"");
            //DataTable dataDT = ReportBO.LiquidacionDT(empId, diaID);
            //DataTable info = EmpleadoBO.ListaEmpleadoDT(empId);
            //DataTable infLQ = ContratoBO.FinContratoEmpleado(empId);
            //DataTable param = ReportBO.LiquidacionParamReport(empId, perID, reproID).Tables[0];
            rpt.SetDataSource(data);
            //rpt.SetParameterValue("P_CI", data.Rows[0]["EMP_CI"].ToString());
            //rpt.SetParameterValue("P_NOMBRE", data.Rows[0]["NOMBRE"].ToString());
            //rpt.SetParameterValue("P_CARGO", data.Rows[0]["ESC_CARGOMB"].ToString());
            //rpt.SetParameterValue("P_LOCAL", data.Rows[0]["LOC_NOMBRE"].ToString());
            //rpt.SetParameterValue("P_SALIDA", data.Rows[0]["SALIDA"].ToString());
            //rpt.SetParameterValue("P_INGRESO", data.Rows[0]["INGRESO"].ToString());
            //rpt.SetParameterValue("P_PATRONO", info.Rows[0]["PATRONO"].ToString());
            //rpt.SetParameterValue("P_RBU", info.Rows[0]["RBU"].ToString());
            //foreach (DataRow row in dataDT.Rows)
            //{
            //    if (row["IMP_LIQ_GRU_NOM"].Equals("TOTAL A RECIBIR"))
            //        rpt.SetParameterValue("P_TOTAL", row["IMP_LIQ_VALOR"]);
            //}
            //rpt.SetParameterValue("P_OBSERVACION", infLQ.Rows[0]["EMP_CON_OBS"].ToString());
            //rpt.SetParameterValue("P_VESTIMENTA", param.Rows.Count > 0 ? param.Rows[0]["ESC_VEST"].ToString() : "0");
            //rpt.SetParameterValue("P_CAUSA", infLQ.Rows[0]["CAUSA"].ToString());
            //rpt.SetParameterValue("P_FIRMA", infLQ.Rows[0]["FIRMA"].ToString());
            //rpt.SetParameterValue("P_BONO", param.Rows.Count > 0 ? param.Rows[0]["ESC_ADI_BON_PRO"].ToString() : "0");
            //rpt.SetParameterValue("P_RAZON", infLQ.Rows[0]["RAZON"].ToString());
            //rpt.SetParameterValue("P_CONTRATO", info.Rows[0]["TIPO_CONTRATO"].ToString());
            crvCertificado.ReportSource = rpt;
        }
    }
}
