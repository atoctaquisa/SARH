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
using db = Entity;

namespace NominaTCG
{
    public partial class frmDetalleDecimoTercero : Form
    {
        private ContratoController ContratoBO { get; set; }
        public frmDetalleDecimoTercero(string empID, string perID )
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            dgvDataDT.AutoGenerateColumns = false;
            ContratoBO = ContratoController.Instancia;
            dgvData.AllowUserToAddRows = false;
            dgvDataDT.AllowUserToAddRows = false;            
            dgvData.DataSource = ContratoBO.DetalleDecimoTercero(empID, perID).Tables[0];
            dgvDataDT.DataSource = ContratoBO.DetalleDecimoTercero(empID, perID).Tables[1];
            TotalSalary();
        }

        private void TotalSalary()
        {
            double ingreso = 0;
            double egreso = 0;
            foreach (DataGridViewRow row in dgvDataDT.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells["TER_VAL_VALOR"].Value != null)
                    {                       
                            ingreso += row.Cells["TER_VAL_VALOR"].Value == DBNull.Value ? 0 : Convert.ToDouble(row.Cells["TER_VAL_VALOR"].Value);
                        
                    }
                    if (row.Cells["TER_VAL_VALOR_TER"].Value != null)
                    {
                        egreso += row.Cells["TER_VAL_VALOR_TER"].Value == DBNull.Value ? 0 : Convert.ToDouble(row.Cells["TER_VAL_VALOR_TER"].Value);

                    }
                }
            }
            txtValor.Text = ingreso.ToString();
            txtDecimo.Text = egreso.ToString();            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //_instancia = null;
            this.Close();
        }
    }
}
