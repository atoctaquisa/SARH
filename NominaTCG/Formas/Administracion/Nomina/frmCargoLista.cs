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
    public partial class frmCargoLista : Form
    {

        #region Propiedades
        
        public EscalafonController  CargosBO { get; set; }
        private DataView LocalView { get; set; }
        #endregion

        #region Métodos
        private void LoadData()
        {
            LocalView = new DataView(CargosBO.ListarEscalafon());
            if (LocalView.Table != null)
            {
                LocalView.Sort = "ESC_CARGOMB ASC";
                dgvData.DataSource = LocalView;
                Design.vEscalafon(dgvData);
                DataGridViewRow row = dgvData.Rows[1];
                //dgvData.Columns[0].Width = 100;
                row.Height = 150;
                cboFilter.DataSource = Design.filterData;
                cboFilter.DisplayMember = "Nombre";
                cboFilter.ValueMember = "ID";
                cboFilter.SelectedValue = "ESC_CARGOMB";
                lblTotalRecord.Text = "Total Registros: " + LocalView.Count.ToString();
                txtSearch.Select();
            }
            else
            {
                Utility.MensajeError("¡No existe registros!");
            }
        }

        private void AssignControl(int index)
        {
            CargosBO.Escalafon.EscID = Convert.ToInt16(dgvData.Rows[index].Cells["ESC_ID"].Value.ToString());
            CargosBO.Escalafon.Cargo = dgvData.Rows[index].Cells["ESC_CARGOMB"].Value.ToString();
        }
        #endregion

       #region Instancia / Constructor
        private static frmCargoLista _instancia;
        public static frmCargoLista Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmCargoLista();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmCargoLista()
        {
            InitializeComponent();
            CargosBO = EscalafonController.Instancia;            
            LoadData();
        }
        #endregion

        private void frmCargoLista_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
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

        private void frmCargoLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LocalView.RowFilter = "Convert(" + cboFilter.SelectedValue + ",'System.String') LIKE '%" + txtSearch.Text + "%'";
            dgvData.DataSource = LocalView;
            lblTotalRecord.Text = "Total Registros: " + LocalView.Count.ToString();
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
