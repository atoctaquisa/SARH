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
    public partial class frmEmpresaLista : Form
    {

         #region Variables
        
        #endregion

        #region Properties        
        public PatronoController EmpresaBO { get; set; }
        private DataView EmpresaView { get; set; }
        #endregion

        #region Methods
        private void LoadData()
        {
            EmpresaView = new DataView(EmpresaBO.Listar());
            if (EmpresaView.Table != null)
            {
                EmpresaView.Sort = "PAT_RAZ_SOCIAL ASC";
                dgvData.DataSource = EmpresaView;
                Design.vEmpresa(dgvData);               
                cboFilter.DataSource = Design.filterData;
                cboFilter.DisplayMember = "Nombre";
                cboFilter.ValueMember = "ID";
                cboFilter.SelectedValue = "NOMBRE";
                lblTotalRecord.Text = "Total Registros: " + EmpresaView.Count.ToString();
                txtSearch.Select();
            }
            else
            {
                Utility.MensajeError("¡No existe registros!");
            }
        }

        private void AssignControl(int index)
        {
            EmpresaBO.Empresa.PatronoID = Convert.ToInt16(dgvData.Rows[index].Cells["PAT_ID"].Value.ToString());
        }
        #endregion

        #region Instancia / Constructor
        private static frmLocalLista _instancia;
        public static frmLocalLista Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmLocalLista();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmEmpresaLista()
        {
            InitializeComponent();
            EmpresaBO = PatronoController.Instancia;             
            LoadData();
        }
        #endregion

        private void frmEmpresaLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }

        private void frmEmpresaLista_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            EmpresaView.RowFilter = "Convert(" + cboFilter.SelectedValue + ",'System.String') LIKE '%" + txtSearch.Text + "%'";
            dgvData.DataSource = EmpresaView;
            lblTotalRecord.Text = "Total Registros: " + EmpresaView.Count.ToString();
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
                    dgvData.CurrentCell = dgvData.Rows[1].Cells[1];
            }
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

        
    }
}
