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
using System.Threading;


namespace NominaTCG
{
    public partial class frmValorFijo : Form
    {

        private CuentaController CuentaBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        private Acction StateButton { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }


        #region Instancia / Constructor
        private static frmValorFijo _instancia;
        public static frmValorFijo Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmValorFijo();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmValorFijo()
        {
            InitializeComponent();
            CuentaBO = CuentaController.Instancia;            
            ContratoBO = ContratoController.Instancia;            
            EmpleadoBO = EmpleadoController.Instancia;

            
            dgvValor.AutoGenerateColumns = false;
            cboCuenta.DataSource = CuentaBO.ListaCuentasGen();
            cboCuenta.DisplayMember = "CUENTA";
            cboCuenta.ValueMember = "ROL_ID";            
            dgvValor.DataSource = ContratoBO.RubroAdicionalGen(cboCuenta.SelectedValue.ToString());            
            ActiveControls(false);
            dgvValor.ReadOnly = false;
            btnEditCancel.Enabled = true;
        }

        #endregion

        private bool ValidaDatos()
        {
            int ban = 1;
            foreach (DataGridViewRow item in dgvValor .Rows)
            {
                if (!item.IsNewRow)
                {
                    if (item.Cells["EMP_ID"].Value.Equals(DBNull.Value))
                        item.Cells["EMP_ID"].ErrorText = (ban++).ToString() + " :Seleccione al Empleado";
                    else
                        item.Cells["EMP_ID"].ErrorText = string.Empty;
                }
            }

            if (ban > 1)
                return false;
            else
                return true;
        }
       
        private void RegistarData()
        {
            Int64 resp = 0;
            DataTable data = new DataTable();
            DataTable dataChange = new DataTable();
            data = (DataTable)dgvValor.DataSource;
            dataChange = null;
            if (data != null)
                dataChange = data.GetChanges(DataRowState.Deleted);
            if (dataChange != null)
            {
                foreach (DataRow row in dataChange.Rows)
                {
                    resp = ContratoBO.EliminaValorFijo(row["EMP_ID", DataRowVersion.Original].ToString(), Convert.ToInt32(row["ROL_ID", DataRowVersion.Original].ToString()));
                }
            }
            dataChange = null;
            if (data != null)
                dataChange = data.GetChanges(DataRowState.Added);
            if (dataChange != null)
            {
                foreach (DataRow row in dataChange.Rows)
                {
                    ContratoBO.ValorFijo.rolId = Convert.ToInt32(row["ROL_ID"].ToString());
                    ContratoBO.ValorFijo.fijValor = Utility.IsNumeric((row["FIJ_VALOR"].ToString())) == true ? Convert.ToDecimal(row["FIJ_VALOR"].ToString()):0;                    
                    if (row["FIJ_ESTADO"].Equals(DBNull.Value))
                        ContratoBO.ValorFijo.fijEstado = 0;
                    else
                        ContratoBO.ValorFijo.fijEstado = Convert.ToInt16(row["FIJ_ESTADO"].ToString());
                    ContratoBO.ValorFijo.empId = Convert.ToDecimal(row["EMP_ID"].ToString());
                    resp = ContratoBO.RegistrarValorFijo(ContratoBO.ValorFijo);
                }
            }
            dataChange = null;
            if (data != null)
                dataChange = data.GetChanges(DataRowState.Modified);
            if (dataChange != null)
            {
                foreach (DataRow row in dataChange.Rows)
                {
                    ContratoBO.ValorFijo.rolId = Convert.ToInt32(row["ROL_ID"].ToString());
                    int auxRolID = Convert.ToInt32(row["ROL_ID", DataRowVersion.Original].ToString());
                    ContratoBO.ValorFijo.fijValor =  Utility.IsNumeric((row["FIJ_VALOR"].ToString()))==true? Convert.ToDecimal(row["FIJ_VALOR"].ToString()):0;                    
                    if (row["FIJ_ESTADO"].Equals(DBNull.Value))
                        ContratoBO.ValorFijo.fijEstado = 0;
                    else
                        ContratoBO.ValorFijo.fijEstado = Convert.ToInt16(row["FIJ_ESTADO"].ToString());
                    ContratoBO.ValorFijo.empId = Convert.ToDecimal(row["EMP_ID"].ToString());
                    resp = ContratoBO.ActualizarValorFijo(ContratoBO.ValorFijo, auxRolID);
                }
            }
        }

        private void ActiveControls(bool stdo)
        {
            ErrProv.Clear();
            foreach (DataGridViewColumn item in dgvValor.Columns)
            {
                if (item.Name == "FIJ_VALOR" | item.Name == "FIJ_ESTADO" | item.Name == "btnEmpleado")
                    item.ReadOnly = !stdo;
                else
                    item.ReadOnly = true;
            }
            dgvValor.AllowUserToAddRows = stdo;
        }

        private void cboCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCuenta.SelectedValue.ToString().Equals("System.Data.DataRowView"))
                return;
            dgvValor.DataSource = ContratoBO.RubroAdicionalGen(cboCuenta.SelectedValue.ToString());
        }

        private void frmValorFijo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (this.btnEditCancel.Text == "&Editar")
            {
                StateButton = Acction.Edit;
                Design.ControlsEdit(this.btnEditCancel, this.btnNewSave);
                ActiveControls(true); 
                btnNewSave.Enabled = true;
                btnDelete.Enabled = true;
                cboCuenta.Enabled = false;
            }
            else
            {
                StateButton = Acction.Cancel;
                Design.ControlsEdit(this.btnEditCancel, this.btnNewSave);
                ActiveControls(false);
                cboCuenta.Enabled = true;
                btnNewSave.Enabled = false;
                btnDelete.Enabled = false;                
            }
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
                DataTable datos = (DataTable)dgvValor.DataSource;
                DataTable getDataAdd = datos.GetChanges(DataRowState.Added);
                DataTable getDataMod = datos.GetChanges(DataRowState.Modified);
                DataTable getDataDel = datos.GetChanges(DataRowState.Deleted);
                if (getDataAdd != null | getDataMod != null | getDataDel != null)
                {
                    if (Utility.MensajeQuestion("¿Está seguro que desea cargar los valores?") == System.Windows.Forms.DialogResult.Yes)
                    {  
                        RegistarData();
                        Design.ControlsEdit(this.btnEditCancel, this.btnNewSave);
                        dgvValor.DataSource = ContratoBO.RubroAdicionalGen(cboCuenta.SelectedValue.ToString());
                        Utility.MensajeOK("Información Reagistrada..!!");
                        ActiveControls(false);
                        btnEditCancel.Enabled = true;
                        cboCuenta.Enabled = true;
                        btnNewSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (StateButton.Equals(Acction.Edit))
            {
                dgvValor.Rows.RemoveAt(dgvValor.CurrentRow.Index);                                
            }
        }

        private void dgvValor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if ((dgvValor.Columns[e.ColumnIndex].GetType()).ToString() == "System.Windows.Forms.DataGridViewButtonColumn")
            {
                if (StateButton.Equals(Acction.Edit))
                {
                    var frm = new frmEmpleadoLista();
                    frm.ShowDialog();
                    DataTable info = EmpleadoBO.ListaEmpleadoDT(EmpleadoBO.Empleado.empId.ToString());
                    if (info.Rows.Count > 0)
                    {

                        foreach (DataGridViewRow row in dgvValor.Rows)
                        {
                            if (row.Index != e.RowIndex && row.Cells["EMP_CI"].Value != null)
                            {
                                if (info.Rows[0]["EMP_CI"].ToString() == (row.Cells["EMP_CI"]).FormattedValue.ToString())
                                {
                                    Utility.MensajeInfo("Error..!! El Empleado ya se encuentra agregado");                                    
                                    return;
                                }
                            }
                        }

                        dgvValor.Rows[e.RowIndex].Cells["EMP_CI"].Value = info.Rows[0]["EMP_CI"].ToString();
                        dgvValor.Rows[e.RowIndex].Cells["NOMBRE"].Value = info.Rows[0]["NOMBRE"].ToString();
                        dgvValor.Rows[e.RowIndex].Cells["EMP_ID"].Value = info.Rows[0]["EMP_ID"].ToString();
                        dgvValor.Rows[e.RowIndex].Cells["FIJ_VALOR"].Value = 0;
                        dgvValor.Rows[e.RowIndex].Cells["FIJ_ESTADO"].Value = 1;
                        dgvValor.Rows[e.RowIndex].Cells["ROL_ID"].Value = cboCuenta.SelectedValue;
                    }
                }
            }
        }

        private void dgvValor_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int index = dgvValor.CurrentCell.ColumnIndex;
            if (dgvValor.Columns[index].Name == "FIJ_VALOR")
            {
                DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;
                dText.KeyPress -= new KeyPressEventHandler(dText_KeyPress);
                dText.KeyPress += new KeyPressEventHandler(dText_KeyPress);
            }
        }
        void dText_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Utility.OnlyQuantity(sender, e);
        }
    }
}
