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
        public frmCertificadoRep(string empID, string tipo)
        {
            InitializeComponent();
            ReportBO = ReportDataController.Instancia;
            DataTable data = ReportBO.Certificado(empID, "");

            //if (Convert.ToUInt16(cboCertificado.SelectedValue) == 1)
            //    nomRep = "CertificadoAct";
            //if (Convert.ToUInt16(cboCertificado.SelectedValue) == 0)
            //    nomRep = "CertificadoPas.rdlc";
            //if (Convert.ToUInt16(cboCertificado.SelectedValue) == 2)
            //    nomRep = "CertificadoCre.rdlc";

            if (tipo == "0")
            {
                NominaTCG.Formas.Reportes.CertificadoPasivo rpt = new NominaTCG.Formas.Reportes.CertificadoPasivo();
                rpt.SetDataSource(data);
                crvCertificado.ReportSource = rpt;
            }

            if (tipo == "1")
            {
                NominaTCG.Formas.Reportes.CertificadoActivo rpt = new NominaTCG.Formas.Reportes.CertificadoActivo();
                rpt.SetDataSource(data);
                crvCertificado.ReportSource = rpt;
            }
           
            if (tipo == "2")
            {
                NominaTCG.Formas.Reportes.CertificadoCredito rpt = new NominaTCG.Formas.Reportes.CertificadoCredito();
                rpt.SetDataSource(data);
                crvCertificado.ReportSource = rpt;
            }
            
        }
    }
}
