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
    public partial class frmListaPrestamos : Form
    {
         private EmpleadoController EmpleadoBO { get; set; }
        private DataView EmpleadoView { get; set; }

        public frmListaPrestamos()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            EmpleadoBO.Empleado = new db.DatEmp();
            LoadData();
        }

         private void AssignControl(int index)
        {   
            EmpleadoBO.Prestamo.empID = Convert.ToInt64(dgvData.Rows[index].Cells["EMP_ID"].Value.ToString());
            EmpleadoBO.Prestamo.rolId = Convert.ToInt64(dgvData.Rows[index].Cells["ROL_ID"].Value.ToString());
            EmpleadoBO.Prestamo.rolIdGen = Convert.ToInt64(dgvData.Rows[index].Cells["ROL_ID_GEN"].Value.ToString());
            EmpleadoBO.Prestamo.rolRepro = Convert.ToInt64(dgvData.Rows[index].Cells["ROL_REPRO"].Value.ToString());
            EmpleadoBO.Prestamo.presPlazo = Convert.ToInt64(dgvData.Rows[index].Cells["PRES_PLAZO"].Value.ToString());
            EmpleadoBO.Prestamo.presValor = Convert.ToInt64(dgvData.Rows[index].Cells["PRES_VALOR"].Value.ToString());
            EmpleadoBO.Prestamo.presObservacion = dgvData.Rows[index].Cells["PRES_OBSERVACION"].Value.ToString();
            EmpleadoBO.Prestamo.empleado = dgvData.Rows[index].Cells["EMPLEADO"].Value.ToString();
            
            
        }
        private void LoadData()
        {            
            EmpleadoView = new DataView(EmpleadoBO.ListaPrestamoEmpleado());
            if (EmpleadoView.Table != null)
            {
                EmpleadoView.Sort = "EMPLEADO ASC";
                dgvData.DataSource = EmpleadoView;
                Design.vPrestamoEmpleado(dgvData);
                DataGridViewRow row = dgvData.Rows[1];
                //dgvData.Columns[0].Width = 100;
                row.Height = 150;
                cboFilter.DataSource = Design.filterData;
                cboFilter.DisplayMember = "Nombre";
                cboFilter.ValueMember = "ID";
                cboFilter.SelectedValue = "EMPLEADO";                
                lblTotalRecord.Text = "Total Registros: " + EmpleadoView.Count.ToString();
                txtSearch.Select();
            }
            else
            {
                Utility.MensajeError("¡No existe registros!");
            }
        }

        private void frmListaPrestamos_KeyPress(object sender, KeyPressEventArgs e)
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
            EmpleadoView.RowFilter = "Convert("+cboFilter.SelectedValue+ ",'System.String') LIKE '%" + txtSearch.Text + "%'";
            dgvData.DataSource = EmpleadoView;
            lblTotalRecord.Text = "Total Registros: " + EmpleadoView.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyTextAndDigit(e);
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
        
    }
}
