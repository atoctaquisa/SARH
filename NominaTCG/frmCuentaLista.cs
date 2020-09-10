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
    public partial class frmCuentaLista : Form
    {

        #region Propiedades        
        public CuentaController CuentaBO { get; set; }
        private DataView CuentaView { get; set; }
        private string[] frmParam;
        #endregion

        #region Métodos
        private void LoadData()
        {
            CuentaView = new DataView(CuentaBO.ListaCuentas(frmParam));
            if (CuentaView.Table != null)
            {
                CuentaView.Sort = "CUENTA ASC";
                dgvData.DataSource = CuentaView;
                Design.vCuentaIO(dgvData);
                DataGridViewRow row = dgvData.Rows[1];
                
                row.Height = 150;
                cboFilter.DataSource = Design.filterData;
                cboFilter.DisplayMember = "Nombre";
                cboFilter.ValueMember = "ID";
                cboFilter.SelectedValue = "CUENTA";
                lblTotalRecord.Text = "Total Registros: " + CuentaView.Count.ToString();
                txtSearch.Select();
            }
            else
            {
                Utility.MensajeError("¡No existe registros!");
            }
        }

        private void AssignControl(int index)
        {
            CuentaBO.Cuenta.CuentaID = Convert.ToInt16(dgvData.Rows[index].Cells["ROL_ID"].Value.ToString());
            CuentaBO.Cuenta.Cuenta = dgvData.Rows[index].Cells["CUENTA"].Value.ToString();
        }
        #endregion

       #region Instancia / Constructor
        //private static frmCuentaLista _instancia;
        //public static frmCuentaLista Instancia
        //{
        //    get
        //    {
        //        if (_instancia == null)
        //            _instancia = new frmCuentaLista(string [] param);
        //        return _instancia;
        //    }
        //    set
        //    {
        //        _instancia = value;
        //    }
        //}

        public frmCuentaLista(string [] param)
        {
            InitializeComponent();
            CuentaBO = CuentaController.Instancia;
            CuentaBO.Cuenta = new RolEntity();
            frmParam = param;
            LoadData();
        }
        #endregion

        private void frmCuentaLista_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Instancia = null;
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
            if (e.KeyCode == Keys.Enter)
            {
                foreach (DataGridViewCell item in dgvData.SelectedCells)
                {
                    if (item.Selected)
                        dgvData_CellDoubleClick(this, new DataGridViewCellEventArgs(item.ColumnIndex, item.RowIndex));
                }
            }
            if (e.KeyCode == Keys.Back)
                txtSearch.Select();
        }

        private void frmCuentaLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CuentaView.RowFilter = "Convert(" + cboFilter.SelectedValue + ",'System.String') LIKE '%" + txtSearch.Text + "%'";
            dgvData.DataSource = CuentaView;
            lblTotalRecord.Text = "Total Registros: " + CuentaView.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyTextAndDigit(e);
            if (e.KeyChar == (char)Keys.Enter)
                dgvData.Select();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Down)
            {
                dgvData.Select();
                if (dgvData.Rows.Count > 1)
                    dgvData.CurrentCell = dgvData.Rows[1].Cells[0];
            }
        }
    }
}
