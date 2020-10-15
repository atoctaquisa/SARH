using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BusinessLogic;

namespace NominaTCG
{
    public partial class frmIngresoValorGrupo : Form
    {
        #region Properties
        private PatronoController PatronoBO { get; set; }
        private LocalController LocalBO { get; set; }
        private CuentaController CuentaBO { get; set; }
        private EscalafonController EscalafonBO { get; set; }
        private ContratoController ContraroBO { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }
        private Acction StateButton { get; set; }
        private ValorGrupo valGrupo { get; set; }
        #endregion

        #region Instancia / Constructor
        private static frmIngresoValorGrupo _instancia;
        public static frmIngresoValorGrupo Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmIngresoValorGrupo();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmIngresoValorGrupo()
        {
            InitializeComponent();
            Design.StyleGridForm(this.dgvData);
            PatronoBO = PatronoController.Instancia;
            LocalBO = LocalController.Instancia;
            CuentaBO = CuentaController.Instancia;
            EscalafonBO = EscalafonController.Instancia;
            ContraroBO = ContratoController.Instancia;
            valGrupo = new ValorGrupo();
            EmpleadoBO = EmpleadoController.Instancia;

            cboPatrono.DataSource = PatronoBO.Listar();
            cboPatrono.DisplayMember = "PAT_RAZ_SOCIAL";
            cboPatrono.ValueMember = "PAT_ID";
            cboPatrono.SelectedIndex = -1;
            dgvData.ReadOnly = false;
            //Design.vValorGrupo(dgvData);
            ActiveControls(false);

        }

        #endregion

        #region Methods
        private void ActiveControls(bool stdo)
        {
            ErrProv.Clear();
            foreach (DataGridViewColumn item in dgvData.Columns)
            {
                if (item.Name == "VALOR" | item.Name == "CANTIDAD" | item.Name == "btnEmpleado")
                    item.ReadOnly = !stdo;
                else
                    item.ReadOnly = true;
            }
            dgvData.AllowUserToAddRows = stdo;
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void frmIngresoValorGrupo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnCuenta_Click(object sender, EventArgs e)
        {
            var frm = new frmCuentaLista( new string[] {"ValorGrupo"});
            Design.frmDialog(frm, "Lista de Cuentas");
            txtCuenta.Text = CuentaBO.Cuenta.Cuenta;
            valGrupo.cuentaID = CuentaBO.Cuenta.CuentaID;
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            var frm = new frmLocalLista();            
            Design.frmDialog(frm,"Lista de Locales");
            txtLocal.Text = LocalBO.Local.Nombre;
            valGrupo.localID = LocalBO.Local.LocalID == 0 ? (decimal?)null : LocalBO.Local.LocalID;
        }

        private void btnCargo_Click(object sender, EventArgs e)
        {
            var frm = new frmCargoLista();
            Design.frmDialog(frm, "Lista de Cargos");
            txtCargo.Text = EscalafonBO.Escalafon.Cargo;
            valGrupo.cargoID = EscalafonBO.Escalafon.EscID == 0 ? (decimal?)null : EscalafonBO.Escalafon.EscID;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            valGrupo.patID = (cboPatrono.SelectedValue == null) ? dbType.intNull : Convert.ToInt16(cboPatrono.SelectedValue);
            dgvData.DataSource = ContraroBO.ValorGrupoRol(valGrupo);
            lblTotalRecord.Text = "Total Registros:" + dgvData.RowCount.ToString();
            
            btnEditCancel.Enabled = true;
            btnClear.Enabled = true;

            //btnDelete.Enabled = true;
            //btnNewSave.Enabled = true;
            //btnSearch.Enabled = true;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            valGrupo = new ValorGrupo();
            cboPatrono.SelectedValue = -1;
            txtCargo.Text = string.Empty;
            txtCuenta.Text = string.Empty;
            txtLocal.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtNombre.Text = string.Empty;
            
            dgvData.DataSource = null;

            btnEditCancel.Enabled = false;
            btnClear.Enabled = false;
            cboPatrono.Enabled = true;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if ((dgvData.Columns[e.ColumnIndex].GetType()).ToString() == "System.Windows.Forms.DataGridViewButtonColumn")
            {
                if (StateButton.Equals(Acction.Edit))
                {
                    var frm = new frmEmpleadoLista();
                    frm.ShowDialog();
                    DataTable info = EmpleadoBO.ListaEmpleadoDT(EmpleadoBO.Empleado.empId.ToString());
                    if (info.Rows.Count > 0)
                    {
                        dgvData.Rows[e.RowIndex].Cells["PATRONO"].Value = info.Rows[0]["PATRONO"].ToString();
                        dgvData.Rows[e.RowIndex].Cells["NOMBRE"].Value = info.Rows[0]["NOMBRE"].ToString();
                        dgvData.Rows[e.RowIndex].Cells["EMP_ID"].Value = info.Rows[0]["EMP_ID"].ToString();
                        dgvData.Rows[e.RowIndex].Cells["CANTIDAD"].Value = 0;
                        dgvData.Rows[e.RowIndex].Cells["VALOR"].Value = 0;
                        dgvData.Rows[e.RowIndex].Cells["LOC_ID"].Value = info.Rows[0]["LOC_ID"].ToString();
                    }
                }
            }
        }

        private bool ValidaDatos()
        {
            int ban = 1;
            if (txtCuenta.Text == string.Empty)
                ErrProv.SetError(txtCuenta, (ban++).ToString() + " :Debe selecccionar una cuenta a la que se cargará el valor");
            
            foreach (DataGridViewRow item in dgvData.Rows)
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

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
                DataTable datos = (DataTable)dgvData.DataSource;
                DataTable getDataAdd = datos.GetChanges(DataRowState.Added);
                DataTable getDataMod = datos.GetChanges(DataRowState.Modified);
                if (getDataAdd != null | getDataMod != null)
                {
                    if (Utility.MensajeQuestion("¿Está seguro que desea cargar los valores?") == System.Windows.Forms.DialogResult.Yes)
                    {
                        CargarValores(getDataAdd);                        
                        CargarValores(getDataMod);
                        Design.ControlsEdit(this.btnEditCancel, this.btnNewSave);
                        Utility.MensajeOK("Información Reagistrada..!!");
                        ActiveControls(false);
                        btnClear_Click(sender, e);
                        btnSearch.Enabled = true;
                        btnEditCancel.Enabled = false;
                        btnNewSave.Enabled = false;
                        btnDelete.Enabled = false;
                        cboPatrono.Enabled = true;

                    }
                }
            }            

        }

        private void CargarValores(DataTable getCambios)
        {
            if (getCambios != null)
            {
                foreach (DataRow row in getCambios.Rows)
                {
                    ValorGrupo valor = new ValorGrupo();
                    
                        valor.empID = Convert.ToInt64(row["EMP_ID"]);
                        valor.localID = Convert.ToInt32(row["LOC_ID"]);
                        //valor.cantidad = Convert.ToInt32(row["CANTIDAD"]);
                        valor.valor = Convert.ToInt32(row["VALOR"]);
                        valor.cuentaID = valGrupo.cuentaID;
                        try
                        {
                            ContraroBO.RegistraValorGrupoRol(valor);
                        }
                        catch (Exception e)
                        {
                            Logger.ErrorLog.ErrorRoutine(false, e);
                        }
                    
                }
            }
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (this.btnEditCancel.Text == "&Editar")
            {
                StateButton = Acction.Edit;
                Design.ControlsEdit(this.btnEditCancel, this.btnNewSave);
                ActiveControls(true);

                btnSearch.Enabled = false;
                btnClear.Enabled = false;
                cboPatrono.Enabled = false;

                btnNewSave.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                StateButton = Acction.Cancel;
                Design.ControlsEdit(this.btnEditCancel, this.btnNewSave);
                ActiveControls(false);
                btnEditCancel.Enabled = false;
                btnNewSave.Enabled = false;
                btnDelete.Enabled = false;
                btnSearch.Enabled = true;
                cboPatrono.Enabled = true;
                btnClear_Click(sender,e);
                //btnClear.Enabled = false;

            }
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string nameColumn = dgvData.Columns[e.ColumnIndex].Name;
            if (nameColumn == "CANTIDAD" | nameColumn == "VALOR")
            {
                TotalSalary();
            }
            dgvData.Rows[e.RowIndex].ErrorText = String.Empty;
        }
        private void TotalSalary()
        {
            double ingreso = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                    ingreso += row.Cells["VALOR"].Value == DBNull.Value ? 0 : Convert.ToDouble(row.Cells["VALOR"].Value);
            }
            txtTotal.Text = ingreso.ToString();

        }

        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int index = dgvData.CurrentCell.ColumnIndex;
            if (dgvData.Columns[index].Name == "VALOR" | dgvData.Columns[index].Name == "CANTIDAD")
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (StateButton.Equals(Acction.Edit))
            {
                dgvData.Rows.RemoveAt(dgvData.CurrentRow.Index);
                TotalSalary();
                lblTotalRecord.Text = "Total Registros:" + dgvData.RowCount.ToString();
            }
        }

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            var frm = new frmEmpleadoLista();
            Design.frmDialog(frm, "Lista de Empleados");
            valGrupo.empID = EmpleadoBO.Empleado.empId==0 ? (decimal?)null :EmpleadoBO.Empleado.empId;
            txtNombre.Text = EmpleadoBO.Empleado.empNombre;
        }
        
    }
}
