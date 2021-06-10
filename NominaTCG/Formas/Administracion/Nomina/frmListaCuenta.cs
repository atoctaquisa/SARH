using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entity;
using BusinessLogic;

namespace NominaTCG
{
    public partial class frmListaCuenta : Form
    {
        #region Variables        
        #endregion

        private DataView auxView { get; set; }
        private CuentaController CuentaBO { get; set; }

        public frmListaCuenta(int tipo)
        {
            InitializeComponent();
            CuentaBO = CuentaController.Instancia;
            auxView = new DataView(CuentaBO.ListaCuenta(tipo));
            dgvData.DataSource = auxView;
            Design.EmgPeriodoUnico(dgvData);
        }

        private void AssignControl(int index)
        {
            CuentaBO.Cuenta.Cuenta = dgvData.Rows[index].Cells["CUENTA"].Value.ToString();
            CuentaBO.Cuenta.CuentaID = Convert.ToInt16(dgvData.Rows[index].Cells["ROL_ID"].Value);
        }

            private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            auxView.RowFilter = "CUENTA LIKE '%" + txtFiltro.Text + "%'";
            dgvData.DataSource = auxView;
            lblTotalRecord.Text = "Total Registros: " + auxView.Count.ToString();
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Down)
            {
                dgvData.Select();
                if (dgvData.Rows.Count > 1)
                    dgvData.CurrentCell = dgvData.Rows[1].Cells[0];
            }
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                dgvData.Select();
        }

        private void frmListaCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            else
            {
                AssignControl(e.RowIndex);
                this.Close();
            }
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    foreach (DataGridViewCell cell in dgvData.SelectedCells)
                    {
                        if (cell.Selected)
                        {
                            AssignControl(cell.RowIndex);
                            this.Close();
                        }
                    }
                    break;
                case Keys.Down:
                    break;
                default:
                    break;
            }
        }
    }
}
