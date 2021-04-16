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
    public partial class frmDetalleVacacion : Form
    {
        private ContratoController ContratoBO { get; set; }
        string _EMPID;
        string _REF;
        public frmDetalleVacacion(string empID, string codRef)
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            dgvDataDT.AutoGenerateColumns = false;
            dgvData.AllowUserToAddRows = false;
            dgvDataDT.AllowUserToAddRows = false;
            ContratoBO = ContratoController.Instancia;
            _EMPID = empID;
            _REF = codRef;
            //dgvData.DataSource = ContratoBO.DetalleDecimoTercero(empID, perID);
            //DataSet data = ContratoBO.DetalleVacacion(empID, codRef);
            dgvData.DataSource = ContratoBO.DetalleVacacionCab(empID, codRef);//data.Tables[0];
            ListarDetalle();
            //dgvDataDT.DataSource = ContratoBO.DetalleVacacion(empID, codRef).Tables[1];
            
        }

        private void TotalSalary()
        {
            double ingreso = 0;
            double egreso = 0;
            foreach (DataGridViewRow row in dgvDataDT.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells["VAC_VAL_VALOR"].Value != null)
                    {
                        ingreso += row.Cells["VAC_VAL_VALOR"].Value == DBNull.Value ? 0 : Convert.ToDouble(row.Cells["VAC_VAL_VALOR"].Value);

                    }
                    if (row.Cells["VAC_VAL_VALOR_VAC"].Value != null)
                    {
                        egreso += row.Cells["VAC_VAL_VALOR_VAC"].Value == DBNull.Value ? 0 : Convert.ToDouble(row.Cells["VAC_VAL_VALOR_VAC"].Value);

                    }
                }
            }
            txtSueldo.Text = ingreso.ToString();
            txtValor.Text = egreso.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //_instancia = null;
            this.Close();
        }

        private void dgvData_CurrentCellChanged(object sender, EventArgs e)
        {
            ListarDetalle();
        }

        private void ListarDetalle()
        {
            foreach (DataGridViewCell item in dgvData.SelectedCells)
            {
                if (item.Selected)
                {
                    dgvDataDT.DataSource = ContratoBO.DetalleVacacionDT(_EMPID, _REF, dgvData.Rows[item.RowIndex].Cells["VAC_PER_ID"].Value.ToString());

                }
            }
            TotalSalary();
        }
    }
}
