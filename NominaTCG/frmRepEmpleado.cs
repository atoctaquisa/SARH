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

namespace NominaTCG
{
    public partial class frmRepEmpleado : Form
    {
        ReportDataController reportBO { get; set; }
        #region Instancia / Constructor
        private static frmRepEmpleado _instancia;
        public static frmRepEmpleado Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmRepEmpleado();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmRepEmpleado()
        {
            InitializeComponent();
            reportBO = ReportDataController.Instancia;
        }
        #endregion


        private void btnConsultar_Click(object sender, EventArgs e)
        {
             dgvData.DataSource = reportBO.DetalleEmpleado("");
        }
    }
}
