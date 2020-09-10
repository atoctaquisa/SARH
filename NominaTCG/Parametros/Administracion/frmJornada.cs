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
    public partial class frmJornada : Form, IFrmJornada
    {
        #region Variables
        int _reproceso;
        #endregion
        #region Properties
        private DataView EmpleadoView { get; set; }
        private Acction StateButton { get; set; }
        //private SistemaController SistemaBO { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }
        private ContratoController ContratoBO { get; set; }

        #endregion
        #region Instancia / Constructor
        private static frmJornada _instancia;
        public static frmJornada Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmJornada();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmJornada()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            ContratoBO = ContratoController.Instancia;
            //dgvData.AutoGenerateColumns = false;
            dgvFaltas.AutoGenerateColumns = false;
            InitializeControls();
            ActiveControls(false);
        }
        #endregion



        #region Methods
        private int RegisterData()
        {
            int resp = 0;
            DataTable data = null;
            DataTable dataChange = null;
            data = (DataTable)dgvFaltas.DataSource;
            dataChange = data.GetChanges(DataRowState.Added);
            if (dataChange != null)
            {
                foreach (DataRow row in dataChange.Rows)
                {
                    //ContratoBO.FaltaEmp.FaltaID = Convert.ToInt16(row["DIA_ID"].ToString());
                    ContratoBO.FaltaEmp.EmpID = Convert.ToInt64(txtCodigo.Text);
                    ContratoBO.FaltaEmp.RolID = Convert.ToInt16(txtPeriodo.Text);
                    ContratoBO.FaltaEmp.RolRepro = _reproceso; //Convert.ToInt16(txtReproceso.Text);
                    ContratoBO.FaltaEmp.FaltaJus = Convert.ToInt16(row["DIA_FALTAJUSTIFI"].ToString());
                    ContratoBO.FaltaEmp.FaltaNoJus = Convert.ToInt16(row["DIA_FALTAINJUSTI"].ToString());
                    ContratoBO.FaltaEmp.PermiJus = Convert.ToInt16(row["DIA_PERMISOJUST"].ToString());
                    ContratoBO.FaltaEmp.PermiNoJus = Convert.ToInt16(row["DIA_PERMISOINJUST"].ToString());
                    ContratoBO.FaltaEmp.FechaNovedad = Convert.ToDateTime(row["DIA_FEC_NOVEDAD"].ToString());
                    ContratoBO.FaltaEmp.Observ = row["DIA_OBS"].ToString();
                    ContratoBO.FaltaEmp.OtroJus = Convert.ToInt16(row["DIA_OTRODESCUN"].ToString());
                    ContratoBO.FaltaEmp.OtrpNoJus = Convert.ToInt16(row["DIA_OTRODESCNADA"].ToString());
                    resp = ContratoBO.RegistrarFaltaEmpleado(ContratoBO.FaltaEmp);
                }
            }
            dataChange = null;
            dataChange = data.GetChanges(DataRowState.Modified);
            if (dataChange != null)
            {
                foreach (DataRow row in dataChange.Rows)
                {
                    ContratoBO.FaltaEmp.FaltaID = Convert.ToInt64(row["DIA_ID"].ToString());
                    ContratoBO.FaltaEmp.EmpID = Convert.ToInt64(row["EMP_ID"].ToString());
                    ContratoBO.FaltaEmp.RolID = Convert.ToInt32(row["ROL_ID_GEN"].ToString());
                    ContratoBO.FaltaEmp.RolRepro = _reproceso;//Convert.ToInt32(row["ROL_REPRO"].ToString());
                    ContratoBO.FaltaEmp.FaltaJus = Convert.ToInt16(row["DIA_FALTAJUSTIFI"].ToString());
                    ContratoBO.FaltaEmp.FaltaNoJus = Convert.ToInt16(row["DIA_FALTAINJUSTI"].ToString());
                    ContratoBO.FaltaEmp.PermiJus = Convert.ToInt16(row["DIA_PERMISOJUST"].ToString());
                    ContratoBO.FaltaEmp.PermiNoJus = Convert.ToInt16(row["DIA_PERMISOINJUST"].ToString());
                    ContratoBO.FaltaEmp.FechaNovedad = Convert.ToDateTime(row["DIA_FEC_NOVEDAD"].ToString());
                    ContratoBO.FaltaEmp.Observ = row["DIA_OBS"].ToString();
                    ContratoBO.FaltaEmp.OtroJus = Convert.ToInt16(row["DIA_OTRODESCUN"].ToString());
                    ContratoBO.FaltaEmp.OtrpNoJus = Convert.ToInt16(row["DIA_OTRODESCNADA"].ToString());
                    resp = ContratoBO.ActualizarFaltaEmpleado(ContratoBO.FaltaEmp);
                }

            }
            return resp;
        }
        public bool ValidateControls()
        {
            int cnt = 1;
            ErrProv.Clear();
            //string sms = "El campo es requerido";

            foreach (DataGridViewRow item in dgvFaltas.Rows)
            {
                if (!item.IsNewRow)
                {
                    //if ((item.Cells["DIA_FEC_NOVEDAD"].Value == DBNull.Value || item.Cells["DIA_FEC_NOVEDAD"].Value == string.Empty)
                    //    )
                    //{
                    //    dgvFaltas.Rows[item.Index].ErrorText = sms;
                    //    cnt++;
                    //}
                }

            }


            if (cnt.Equals(1))
                return true;
            else
                return false;
        }
        public void ClearControls()
        {
            txtPeriodo.Text = string.Empty;
            txtReproceso.Text = string.Empty;
            dgvFaltas.EndEdit();
            dgvFaltas.Refresh();
            //dgvFaltas.Rows.Clear();
        }
        public void ActiveControls(bool estadoControl)
        {
            //txtPeriodo.Enabled = estadoControl;
            //txtReproceso.Enabled = estadoControl;
            dgvFaltas.ReadOnly = !estadoControl;
            btnPeriodo.Enabled = !estadoControl;
        }

        public void getPeriodoID(string text)
        {
            txtPeriodo.Text = text;
        }

        private void InitializeControls()
        {

            EmpleadoView = new DataView(EmpleadoBO.ListaEmpleadoDetalle());
            dgvData.DataSource = EmpleadoView;
            Design.vEmpleadoDT(dgvData);
            cboFilter.DataSource = Design.filterData;
            cboFilter.DisplayMember = "Nombre";
            cboFilter.ValueMember = "ID";
            lblTotalRecord.Text = "Total Registros: " + EmpleadoView.Count.ToString();

        }
        #endregion

        private void frmJornada_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void frmJornada_Load(object sender, EventArgs e)
        {
            Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
        }

        private void AssignControls(int index)
        {

            txtCodigo.Text = dgvData.Rows[index].Cells["EMP_ID"].Value.ToString();
            txtNombre.Text = dgvData.Rows[index].Cells["NOMBRE"].Value.ToString();
            txtCargo.Text = dgvData.Rows[index].Cells["ESC_CARGOMB"].Value.ToString();
            txtPuesto.Text = dgvData.Rows[index].Cells["LOC_NOMBRE"].Value.ToString();
            txtFechaIngreso.Text = Convert.ToDateTime(dgvData.Rows[index].Cells["LAB_FEC_INGRESO"].Value).ToShortDateString();
            txtEstado.Text = dgvData.Rows[index].Cells["ESTADO"].Value.ToString();
            txtFechaContrato.Text = Convert.ToDateTime(dgvData.Rows[index].Cells["EMP_CON_FEC_CONTRATO"].Value).ToShortDateString();
            txtAfiliado.Text = (dgvData.Rows[index].Cells["EMP_AFIL_HUMANA"].Value).Equals(1) ? "Si" : "No";

        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (this.btnNewSave.Text == "&Nuevo")
            {
                //if (txtCodigo.Text == string.Empty | txtPeriodo.Text == string.Empty)
                //{
                //    Utility.MensajeInfo("Primero seleccione al Empleado y el Período..!!");
                //    return;
                //}
                //StateButton = Acction.New;
                //ActiveControls(true);
                //ClearControls();
                //Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
                dgvFaltas.DataSource = ContratoBO.ListarFaltas(txtCodigo.Text, txtPeriodo.Text, txtReproceso.Text);
            }
            else
            {
                if (ValidateControls())
                {
                    int respAction = 0;
                    respAction = RegisterData();
                    if (respAction.Equals(0))
                        Utility.MensajeError("Acción Fallida..!!");
                    else
                    {
                        dgvFaltas.DataSource = ContratoBO.ListarFaltas(txtCodigo.Text, txtPeriodo.Text, _reproceso.ToString());
                        Utility.MensajeOK("Acción Exitosa..!!" + respAction.ToString());
                        ActiveControls(false);
                        Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
                    }
                }
            }

        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (this.btnEditCancel.Text != "&Cancelar")
            {
                if (txtCodigo.Text == string.Empty)
                {
                    Utility.MensajeInfo("Seleccione primero un Empleado");
                    return;
                }
                if (txtPeriodo.Text == string.Empty | txtReproceso.Text == string.Empty)
                {
                    ErrProv.SetError(txtPeriodo, "El campo es obligatorio..!");
                    ErrProv.SetError(txtReproceso, "El campo es obligatorio..!");
                    return;
                }
                
                ErrProv.Clear();
                StateButton = Acction.Edit;
                ActiveControls(true);
                txtReproceso.Text = _reproceso.ToString();
                txtDiaDescon.Text = "0";
                txtDiaTrabajo.Text = "0";
                dgvFaltas.DataSource = ContratoBO.ListarFaltas(txtCodigo.Text, txtPeriodo.Text, _reproceso.ToString());
            }
            else
            {
                
                ClearControls();
                StateButton = Acction.Cancel;
                //InitializeControls();
                ActiveControls(false);
                dgvFaltas.DataSource = ContratoBO.ListarFaltas(txtCodigo.Text, txtPeriodo.Text, txtReproceso.Text);
            }


            Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabAdmin.SelectTab(0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    foreach (DataGridViewCell cell in dgvData.SelectedCells)
                    {
                        if (cell.Selected)
                        {
                            AssignControls(cell.RowIndex);
                            tabAdmin.SelectTab(1);
                        }
                    }
                    break;
                case Keys.Down:
                    break;
                default:
                    break;
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            else
            {
                AssignControls(e.RowIndex);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            else
            {
                AssignControls(e.RowIndex);
                tabAdmin.SelectTab(1);
            }

        }

        private void btnPeriodo_Click(object sender, EventArgs e)
        {
            _reproceso = 0;
            var frm = new frmListaEmergente("Períodos ", "Periodo");
            frm.ShowDialog(this);
            if (!txtPeriodo.Text.Equals(string.Empty))
            {
                _reproceso = ContratoBO.NumeroProceso(Convert.ToInt32(txtPeriodo.Text), "ProcesoRol");
                if (_reproceso > 1)
                    txtReproceso.Text = (_reproceso - 1).ToString();
                else
                    txtReproceso.Text = _reproceso.ToString();

                DataTable datos = new DataTable();
                datos = ContratoBO.ListarRol(txtCodigo.Text, Convert.ToInt32(txtPeriodo.Text), Convert.ToInt32(txtReproceso.Text));
                if (datos.Rows.Count > 0)
                {
                    txtDiaTrabajo.Text = datos.Rows[0]["ROL_DIA_TRA"].ToString();
                    txtDiaDescon.Text = datos.Rows[0]["ROL_DIA_DESC"].ToString();
                    dgvFaltas.DataSource = ContratoBO.ListarFaltas(txtCodigo.Text, txtPeriodo.Text, txtReproceso.Text);
                }
            }
        }

        private void dgvFaltas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvFaltas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvFaltas.IsCurrentCellDirty)
                dgvFaltas.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvFaltas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvFaltas.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dgvFaltas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if ((dgvFaltas.Columns[e.ColumnIndex].GetType()).ToString() == "System.Windows.Forms.DataGridViewCheckBoxColumn")
            {
                DataGridViewCheckBoxCell checkSelec = (DataGridViewCheckBoxCell)dgvFaltas.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (checkSelec.Value != null && (sender == checkSelec) == false)
                {
                    foreach (DataGridViewColumn item in dgvFaltas.Columns)
                    {
                        if (item.GetType().ToString() == "System.Windows.Forms.DataGridViewCheckBoxColumn")
                        {
                            if (dgvFaltas.Columns[e.ColumnIndex].Name != item.Name)
                            {
                                dgvFaltas.Rows[e.RowIndex].Cells[item.Name].Value = checkSelec.Value.Equals(1) ? 1 : 0;
                            }
                        }

                    }
                }
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            EmpleadoView.RowFilter = cboFilter.SelectedValue + " LIKE '%" + txtSearch.Text + "%'";
            dgvData.DataSource = EmpleadoView;
            lblTotalRecord.Text = "Total Registros: " + EmpleadoView.Count.ToString();
        }
    }    
}
