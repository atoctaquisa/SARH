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
    public partial class frmMaternidadLista : Form
    {
        #region Variables

        #endregion
        #region Propiedades
        public LocalEntity Local { get; set; }
        public SolicitudController SolicitudBO { get; set; }
        private DataView LocalView { get; set; }

        #endregion

        #region Instancia / Constructor
        private static frmMaternidadLista _instancia;
        public static frmMaternidadLista Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmMaternidadLista();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmMaternidadLista()
        {
            InitializeComponent();
            SolicitudBO = SolicitudController.Instancia;
            //SolicitudBO.Local = new LocalEntity();
            LoadData();
        }
        #endregion

        #region Métodos
        private void LoadData()
        {
            LocalView = new DataView(SolicitudBO.ListaSolicitudAccMatEnf(""));
            if (LocalView.Table != null)
            {
                LocalView.Sort = "NOMBRE ASC";
                dgvData.DataSource = LocalView;
                Design.vContrato(dgvData);
                DataGridViewRow row = dgvData.Rows[0];
                //dgvData.Columns[0].Width = 100;
                row.Height = 150;
                cboFilter.DataSource = Design.filterData;
                cboFilter.DisplayMember = "Nombre";
                cboFilter.ValueMember = "ID";
                cboFilter.SelectedValue = "LOC_NOMBRE";
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
            //SolicitudBO.Local.LocalID = Convert.ToInt16(dgvData.Rows[index].Cells["LOC_ID"].Value.ToString());
            //SolicitudBO.Local.Nombre = dgvData.Rows[index].Cells["LOC_NOMBRE"].Value.ToString();
        }
        #endregion

       
        private void frmMaternidadLista_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
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

        private void frmMaternidadLista_KeyPress(object sender, KeyPressEventArgs e)
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
