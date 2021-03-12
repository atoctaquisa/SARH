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
    public partial class frmPeridoRolLista : Form
    {
        
        private ContratoController ContratoBO { get; set; }
        private DataView peridoRolView { get; set; }
        private string tipoRol { get; set; }
        public frmPeridoRolLista(string tipo)
        {
            InitializeComponent();
           
            ContratoBO = ContratoController.Instancia;
            tipoRol = tipo;
            LoadData();
        }
        private void AssignControl(int index)
        {
            if (tipoRol.Equals("PeridoVacacion"))
            {
                ContratoBO.RolSeg.segRolObs = dgvData.Rows[index].Cells["SEG_ROL_ID"].Value.ToString();
                ContratoBO.RolSeg.segRolRepro = Convert.ToInt64(dgvData.Rows[index].Cells["SEG_ROL_REPRO"].Value.ToString());
            }
            else
            {
                ContratoBO.RolSeg.segRolId = Convert.ToInt64(dgvData.Rows[index].Cells["SEG_ROL_ID"].Value.ToString());
                ContratoBO.RolSeg.segRolRepro = Convert.ToInt64(dgvData.Rows[index].Cells["SEG_ROL_REPRO"].Value.ToString());
                ContratoBO.RolSeg.rolFechaIni = Convert.ToDateTime(dgvData.Rows[index].Cells["ROL_FECHA_INI"].Value.ToString());
                ContratoBO.RolSeg.rolFechaFin = dgvData.Rows[index].Cells["ROL_FECHA_FIN"].Value == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dgvData.Rows[index].Cells["ROL_FECHA_FIN"].Value.ToString());
            }
        }
        private void LoadData()
        {
            if (tipoRol.Equals("PeridoVacacion"))
            {
                dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                peridoRolView = new DataView(ContratoBO.ListaPeriodo("PV"));
            }
            if (tipoRol.Equals("PeridoRolCorto"))
                peridoRolView = new DataView(ContratoBO.ListaPeriodo("PQ"));
            if (tipoRol.Equals("PeridoRolCompleto"))
                peridoRolView = new DataView(ContratoBO.ListaPeriodo("PR"));
            if (tipoRol.Equals("PeridoRolCompletoA"))
                peridoRolView = new DataView(ContratoBO.ListaPeriodo("PRA"));
            if (peridoRolView.Table != null)
            {
                peridoRolView.Sort = "SEG_ROL_ID DESC";
                dgvData.DataSource = peridoRolView;
                if (tipoRol.Equals("PeridoRolCorto"))
                    Design.vPeridoRolCorto(dgvData);
                if (tipoRol.Equals("PeridoRolCompleto") | tipoRol.Equals("PeridoRolCompletoA"))
                    Design.vPeridoRol(dgvData);
                if (tipoRol.Equals("PeridoVacacion"))
                    Design.vPeridoVacaciones(dgvData);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            peridoRolView.RowFilter = "Convert(" + cboFilter.SelectedValue + ",'System.String') LIKE '%" + txtSearch.Text + "%'";
            dgvData.DataSource = peridoRolView;
            lblTotalRecord.Text = "Total Registros: " + peridoRolView.Count.ToString();
        }

        private void frmPeriodoRolLista_KeyPress(object sender, KeyPressEventArgs e)
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
