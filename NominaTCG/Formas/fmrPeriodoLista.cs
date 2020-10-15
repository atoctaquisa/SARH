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
    public partial class fmrPeriodoLista : Form
    {
        private ContratoController ContratoBO { get; set; }
        private DataView peridoRolView { get; set; }
        private string tipoRol { get; set; }
        public fmrPeriodoLista(string tipo)
        {
            InitializeComponent();
            ContratoBO = ContratoController.Instancia;
            tipoRol = tipo;
            LoadData();
        }

        private void AssignControl(int index)
        {
            if (tipoRol == "DC" | tipoRol == "DT")
            {
                
                ContratoBO.RolSeg.segRolObs = dgvData.Rows[index].Cells["PERIODO"].Value.ToString();
                ContratoBO.RolSeg.segRolId = Convert.ToInt64(dgvData.Rows[index].Cells["PROCESO"].Value.ToString());
                ContratoBO.RolSeg.segRolRepro = Convert.ToInt64(dgvData.Rows[index].Cells["DEC_ANO_INI"].Value.ToString());
                ContratoBO.RolSeg.segEstQuin = Convert.ToInt64(dgvData.Rows[index].Cells["DEC_ANO_FIN"].Value.ToString());
            }
            else
            {
                ContratoBO.RolSeg.segRolId = Convert.ToInt64(dgvData.Rows[index].Cells["SEG_ROL_ID"].Value.ToString());
                ContratoBO.RolSeg.segRolRepro = Convert.ToInt64(dgvData.Rows[index].Cells["SEG_ROL_REPRO"].Value.ToString());
            }
        }

        private void LoadData()
        {
            peridoRolView = new DataView(ContratoBO.ListaPeriodoDecimo(tipoRol));
            if (peridoRolView.Table != null)
            {
                ///peridoRolView.Sort = "SEG_ROL_ID DESC";
                dgvData.DataSource = peridoRolView;
                if (tipoRol == "DC" | tipoRol == "DT")
                {
                    Design.vPeriodoDecimo(dgvData);
                }
                //if (tipoRol.Equals("DT"))
                //    Design.vPeridoRolCorto(dgvData);
                //if (tipoRol.Equals("DC"))
                //    Design.vPeridoRol(dgvData);
                //DataGridViewRow row = dgvData.Rows[1];
                //row.Height = 150;
                cboFilter.DataSource = Design.filterData;
                cboFilter.DisplayMember = "Nombre";
                cboFilter.ValueMember = "ID";
                lblTotalRecord.Text = "Total Registros: " + peridoRolView.Count.ToString();
                txtSearch.Select();
            }
            else
            {
                Utility.MensajeError("¡No existe registros!");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            peridoRolView.RowFilter = "Convert(" + cboFilter.SelectedValue + ",'System.String') LIKE '%" + txtSearch.Text + "%'";
            dgvData.DataSource = peridoRolView;
            lblTotalRecord.Text = "Total Registros: " + peridoRolView.Count.ToString();
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

        private void fmrPeriodoLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyTextAndDigit(e);
        }
    }
}
