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
namespace NominaTCG
{
    public partial class frmListaReproceso : Form
    {
        private static string procesoID { get; set; }
        private ContratoController ContratoBO { get; set; }
        private void AssignControl(int index)
        {
            //IFrmResumenRol frm = frmResumenRol.Instancia as IFrmResumenRol;
            //if (frm != null)
            //{
            //    string idCodigo = dgvData.Rows[index].Cells["EMP_ID"].Value.ToString();
            //    frm.getEmpleadoID(idCodigo);

            //EmpleadoBO.Empleado.empId = Convert.ToInt64(dgvData.Rows[index].Cells["EMP_ID"].Value.ToString());
            //Emplea
            ContratoBO.RolSeg.segRolRepro = Convert.ToInt64(dgvData.Rows[index].Cells["SEG_ROL_REPRO"].Value.ToString());
        }

        public frmListaReproceso(string [] param)
        {
            InitializeComponent();
            ContratoBO = ContratoController.Instancia;
            procesoID = param[0];
            dgvData.DataSource = ContratoBO.ListaReproceso(procesoID);
        }

        private void frmListaReproceso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
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
            //if (e.KeyCode == Keys.Back)
            //    txtSearch.Select();
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
    }
}
