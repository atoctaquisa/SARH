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
//using System.Linq;
namespace NominaTCG
{
    public partial class frmLiquidacionRep : Form
    {
        private ReportDataController ReportBO { get; set; }
        public frmLiquidacionRep(string empId, string diaID)
        {
            InitializeComponent();
            ReportBO = ReportDataController.Instancia;
            rptLiquidacion rpt = new rptLiquidacion();
            DataTable data = ReportBO.Liquidacion(empId);
            DataTable dataDT = ReportBO.LiquidacionDT(empId, diaID);
            DataView v = new DataView(dataDT);
            DataView vDT = new DataView(dataDT);
            v.RowFilter = "IMP_LIQ_GRU_ID = 99 ";
            vDT.RowFilter ="IMP_LIQ_GRU_ID NOT IN(99)";
            rpt.SetDataSource(vDT);
          
            rpt.SetParameterValue("P_CI", data.Rows[0]["EMP_CI"].ToString());
            rpt.SetParameterValue("P_NOMBRE", data.Rows[0]["NOMBRE"].ToString());
            rpt.SetParameterValue("P_CARGO", data.Rows[0]["ESC_CARGOMB"].ToString());
            rpt.SetParameterValue("P_LOCAL", data.Rows[0]["LOC_NOMBRE"].ToString());
            rpt.SetParameterValue("P_SALIDA", data.Rows[0]["SALIDA"].ToString());
            rpt.SetParameterValue("P_INGRESO", data.Rows[0]["INGRESO"].ToString());
            //rpt.SetParameterValue("P_PATRONO", (from myRow in dataDT.AsEnumerable()
            //                                    where myRow.Field<string>("IMP_LIQ_GRU_NOM") == "Patrono"
            //                                    select myRow.Field<string>("IMP_LIQ_DES")).FirstOrDefault());
            //rpt.SetParameterValue("P_RBU", (from myRow in dataDT.AsEnumerable()
            //                                    where myRow.Field<string>("IMP_LIQ_GRU_NOM") == "Sueldo"
            //                                select myRow.Field<string>("IMP_LIQ_DES")).FirstOrDefault());
            //rpt.SetParameterValue("P_TOTAL", (from myRow in dataDT.AsEnumerable()
            //                                    where myRow.Field<string>("IMP_LIQ_GRU_NOM") == "Total Sueldo"
            //                                  select myRow.Field<string>("IMP_LIQ_DES")).FirstOrDefault());
            //rpt.SetParameterValue("P_OBSERVACION", (from myRow in dataDT.AsEnumerable()
            //                                    where myRow.Field<string>("IMP_LIQ_GRU_NOM") == "Observación"
            //                                        select myRow.Field<string>("IMP_LIQ_DES")).FirstOrDefault());
            //rpt.SetParameterValue("P_VESTIMENTA", (from myRow in dataDT.AsEnumerable()
            //                                    where myRow.Field<string>("IMP_LIQ_GRU_NOM") == "Vestimenta"
            //                                       select myRow.Field<string>("IMP_LIQ_DES")).FirstOrDefault());
            //rpt.SetParameterValue("P_CAUSA", (from myRow in dataDT.AsEnumerable()
            //                                    where myRow.Field<string>("IMP_LIQ_GRU_NOM") == "Causa"
            //                                  select myRow.Field<string>("IMP_LIQ_DES")).FirstOrDefault());
            //rpt.SetParameterValue("P_FIRMA", (from myRow in dataDT.AsEnumerable()
            //                                    where myRow.Field<string>("IMP_LIQ_GRU_NOM") == "Firma"
            //                                  select myRow.Field<string>("IMP_LIQ_DES")).FirstOrDefault());
            //rpt.SetParameterValue("P_BONO", (from myRow in dataDT.AsEnumerable()
            //                                    where myRow.Field<string>("IMP_LIQ_GRU_NOM") == "Bono"
            //                                 select myRow.Field<string>("IMP_LIQ_DES")).FirstOrDefault());
            //rpt.SetParameterValue("P_RAZON", (from myRow in dataDT.AsEnumerable()
            //                                 where myRow.Field<string>("IMP_LIQ_GRU_NOM") == "Razón"
            //                                  select myRow.Field<string>("IMP_LIQ_DES")).FirstOrDefault());
            //rpt.SetParameterValue("P_CONTRATO", (from myRow in dataDT.AsEnumerable()
            //                                 where myRow.Field<string>("IMP_LIQ_GRU_NOM") == "Contrato"
            //                                     select myRow.Field<string>("IMP_LIQ_DES")).FirstOrDefault());

            crvLiquidacion.ReportSource = rpt;
        }
    }
}
