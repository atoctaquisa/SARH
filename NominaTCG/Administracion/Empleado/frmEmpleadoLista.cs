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
            //IFrmResumenRol frm = frmResumenRol.Instancia as IFrmResumenRol;
            //if (frm != null)
            //{
            //    string idCodigo = dgvData.Rows[index].Cells["EMP_ID"].Value.ToString();
            //    frm.getEmpleadoID(idCodigo);
            
            EmpleadoBO.Empleado.empId = Convert.ToInt64(dgvData.Rows[index].Cells["EMP_ID"].Value.ToString());
            //EmpleadoBO.Empleado.empCi = dgvData.Rows[index].Cells["EMP_CI"].Value.ToString();
            EmpleadoBO.Empleado.empNombre = dgvData.Rows[index].Cells["NOMBRE"].Value.ToString();
            //EmpleadoBO.Empleado.empApellido = dgvData.Rows[index].Cells["EMP_APELLIDO"].Value.ToString();
            //EmpleadoBO.Empleado.empNumIess = dgvData.Rows[index].Cells["EMP_NUM_IESS"].Value.ToString();
            //EmpleadoBO.Empleado.empCuenta = dgvData.Rows[index].Cells["EMP_CUENTA"].Value.ToString();
            //EmpleadoBO.Empleado.empPasaporte = dgvData.Rows[index].Cells["EMP_PASAPORTE"].Value.ToString();
            //EmpleadoBO.Empleado.empPagFonRes = Convert.ToInt32(dgvData.Rows[index].Cells["EMP_PAG_FON_RES"].Value.ToString());
            //EmpleadoBO.Empleado.empTipoCnta = Convert.ToInt32(dgvData.Rows[index].Cells["EMP_TIPO_CNTA"].Value.ToString());
            //EmpleadoBO.Empleado.empNumConadis = dgvData.Rows[index].Cells["EMP_NUM_CONADIS"].Value.ToString();
            //EmpleadoBO.Empleado.empPagDecTer = Convert.ToInt32(dgvData.Rows[index].Cells["EMP_PAG_DEC_TER"].Value.ToString());
            //EmpleadoBO.Empleado.empPagDecCua = Convert.ToInt32(dgvData.Rows[index].Cells["EMP_PAG_DEC_CUA"].Value.ToString());
            //EmpleadoBO.Empleado.empBarrio = dgvData.Rows[index].Cells["EMP_BARRIO"].Value.ToString();
            //EmpleadoBO.Empleado.empDirec = dgvData.Rows[index].Cells["EMP_DIREC"].Value.ToString();
            //EmpleadoBO.Empleado.empTelefono = dgvData.Rows[index].Cells["EMP_TELEFONO"].Value.ToString();
            //EmpleadoBO.Empleado.empSecId = Convert.ToInt32(dgvData.Rows[index].Cells["EMP_SEC_ID"].Value.ToString());
            //EmpleadoBO.Empleado.empDireNumero = dgvData.Rows[index].Cells["EMP_DIRE_NUMERO"].Value.ToString();
            //EmpleadoBO.Empleado.empTelefono2 = dgvData.Rows[index].Cells["EMP_TELEFONO2"].Value.ToString();
            //EmpleadoBO.Empleado.empLugNac = dgvData.Rows[index].Cells["EMP_LUG_NAC"].Value.ToString();
            //EmpleadoBO.Empleado.empFecNac = Convert.ToDateTime(dgvData.Rows[index].Cells["EMP_FEC_NAC"].Value.ToString());
            //EmpleadoBO.Empleado.empSexo = Convert.ToInt32(dgvData.Rows[index].Cells["EMP_SEXO"].Value.ToString());
            //EmpleadoBO.Empleado.empEdu = dgvData.Rows[index].Cells["EMP_EDU"].Value.ToString();
            //EmpleadoBO.Empleado.empFecSeg = dgvData.Rows[index].Cells["EMP_FEC_SEG"].Value.ToString();
            //EmpleadoBO.Empleado.empEstCivil = dgvData.Rows[index].Cells["EMP_EST_CIVIL"].Value.ToString();
            //EmpleadoBO.Empleado.empTipSangre = dgvData.Rows[index].Cells["EMP_TIP_SANGRE"].Value.ToString();
            //DateTime dateResult;
            //EmpleadoBO.Empleado.empFecSalidareal = DateTime.TryParse(dgvData.Rows[index].Cells["EMP_FEC_SALIDAREAL"].Value.ToString(), out dateResult) ? dateResult : Convert.ToDateTime("01/01/9999");
            //EmpleadoBO.Empleado.labFecIngreso = DateTime.TryParse(dgvData.Rows[index].Cells["LAB_FEC_INGRESO"].Value.ToString(), out dateResult) ? dateResult : Convert.ToDateTime("01/01/9999");
            //EmpleadoBO.Empleado.empFecSalida = DateTime.TryParse(dgvData.Rows[index].Cells["EMP_FEC_SALIDA"].Value.ToString(), out dateResult) ? dateResult : Convert.ToDateTime("01/01/9999");
            //EmpleadoBO.Empleado.empFecReg = DateTime.TryParse(dgvData.Rows[index].Cells["EMP_FEC_REG"].Value.ToString(), out dateResult) ? dateResult : Convert.ToDateTime("01/01/9999");
            //EmpleadoBO.Empleado.empFecMod = DateTime.TryParse(dgvData.Rows[index].Cells["EMP_FEC_MOD"].Value.ToString(), out dateResult) ? dateResult : Convert.ToDateTime("01/01/9999");
            //EmpleadoBO.Empleado.empDiscapacidad = Convert.ToInt32(dgvData.Rows[index].Cells["EMP_DISCAPACIDAD"].Value.ToString());
            //EmpleadoBO.Empleado.empMail = dgvData.Rows[index].Cells["EMP_MAIL"].Value.ToString();
            //}
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
