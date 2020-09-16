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
    public partial class frmEmpleadoLista : Form
    {
        private EmpleadoController EmpleadoBO { get; set; }
        private DataView EmpleadoView { get; set; }

        public frmEmpleadoLista()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            EmpleadoBO.Empleado = new db.DatEmp();
            dgvData.ReadOnly = true;
            LoadData();
        }

        private void AssignControl(int index)
        {           
            EmpleadoBO.Empleado.empId = Convert.ToInt64(dgvData.Rows[index].Cells["EMP_ID"].Value.ToString());            
            EmpleadoBO.Empleado.empNombre = dgvData.Rows[index].Cells["NOMBRE"].Value.ToString();           
        }
        private void LoadData()
        {            
            EmpleadoView = new DataView(EmpleadoBO.ListaEmpleadoDetalle());
            if (EmpleadoView.Table != null)
            {
                EmpleadoView.Sort = "Nombre ASC";
                dgvData.DataSource = EmpleadoView;
                Design.vEmpleado(dgvData);
                DataGridViewRow row = dgvData.Rows[1];
                //dgvData.Columns[0].Width = 100;
                row.Height = 150;
                cboFilter.DataSource = Design.filterData;
                cboFilter.DisplayMember = "Nombre";
                cboFilter.ValueMember = "ID";
                cboFilter.SelectedValue = "NOMBRE";
                lblTotalRecord.Text = "Total Registros: " + EmpleadoView.Count.ToString();
                txtSearch.Select();
            }
            else
            {
                Utility.MensajeError("¡No existe registros!");
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            EmpleadoView.RowFilter = "Convert(" + cboFilter.SelectedValue + ",'System.String') LIKE '%" + txtSearch.Text + "%'";
            dgvData.DataSource = EmpleadoView;
            lblTotalRecord.Text = "Total Registros: " + EmpleadoView.Count.ToString();
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

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyTextAndDigit(e);
            if (e.KeyChar == (char)Keys.Enter)
                dgvData.Select();

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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Down)
            {
                dgvData.Select();
                if (dgvData.Rows.Count > 1)
                    dgvData.CurrentCell = dgvData.Rows[1].Cells[0];
            }
        }

        private void frmEmpleadoLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }

    }
}
