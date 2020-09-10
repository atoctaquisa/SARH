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
    public partial class frmActuarial : Form
    {
        private ReportDataController ReportBO { get; set; }
              

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
        }
        #endregion
              

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //rptLiquidacion rpt = new rptLiquidacion();
            //rpt.SetDataSource(ReportBO.Liquidacion("200612315233", "590"));
            //cryLiquidacion.ReportSource = rpt;

        }

        private void frmActuarial_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        

    }
}
