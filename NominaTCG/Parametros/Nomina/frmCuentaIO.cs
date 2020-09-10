using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using db = Entity;
using BusinessLogic;

namespace NominaTCG
{
    public partial class frmCuentaIO : Form
    {
        private CuentaController CuentaBO { get; set; }

        #region Instancia / Constructor
        private static frmCuentaIO _instancia;
        private Int32 rolID { get; set; }
        public static frmCuentaIO Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmCuentaIO();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmCuentaIO()
        {
            InitializeComponent();
            InitializeControls();
        }
        #endregion

        private void LoadData()
        {
            DataTable datos = new DataTable();
            dgvDatos.DataSource = CuentaBO.ListaCuentaIO();
            datos = (DataTable)dgvDatos.DataSource;
            if (datos.Rows.Count > 0)
            {
                rolID = Convert.ToInt16(datos.Rows[0]["ROL_ID"]);
                dgvDatosDT.DataSource = CuentaBO.ListaProvisionRol(rolID);
                lblTotalRecordDT.Text = "Total Registros:" + dgvDatosDT.RowCount.ToString();
            }            
            lblTotalRecord.Text = "Total Registros:" + dgvDatos.RowCount.ToString();
        }

        public void InitializeControls()
        {
            CuentaBO = CuentaController.Instancia;
            dgvDatos.AutoGenerateColumns = false;
            dgvDatosDT.AutoGenerateColumns = false;
            dgvDatos.ReadOnly = true;
            dgvDatosDT.ReadOnly = true;
            GRU_VAR_ROL_ID.DataSource = CuentaBO.ListaGrupoCuentas();
            GRU_VAR_ROL_ID.DisplayMember = "GRU_VAR_ROL_NOMBRE";
            GRU_VAR_ROL_ID.ValueMember = "GRU_VAR_ROL_ID";

            CUE_PROV_ID.DataSource = CuentaBO.ListaCuentaProvision();
            CUE_PROV_ID.DisplayMember = "CUE_PROV_NOMBRE";
            CUE_PROV_ID.ValueMember = "CUE_PROV_ID";

            LoadData();
        }

        private void frmCuentaIO_FormClosing(object sender, FormClosingEventArgs e)
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
            if (btnEditCancel.Text.Equals("&Editar"))
            {
                dgvDatos.ReadOnly = false;
                dgvDatosDT.ReadOnly = false;
            }

            else
            {
                dgvDatos.ReadOnly = true;
                dgvDatosDT.ReadOnly = false;
                LoadData();
            }

            Design.ControlsEdit(this.btnEditCancel, this.btnNewSave);
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            //CheckChange();
            Design.ControlsSave(this.btnEditCancel, this.btnNewSave);
            dgvDatos.ReadOnly = true;
            dgvDatosDT.ReadOnly = true;            
            LoadData();
        }


        private void SaveChangeRows(bool op, DataRowState stateRows, string tipoSQL)
        {

            DataTable datos = (DataTable)dgvDatos.DataSource;
            DataTable getCambios = datos.GetChanges(stateRows);
            DataTable datoDT = (DataTable)dgvDatosDT.DataSource;
            DataTable getCambioDT = datoDT.GetChanges(stateRows);
            if (getCambios != null)
            {
                foreach (DataRow row in getCambios.Rows)
                {
                    db.RolEntity cuenta = new db.RolEntity();
                    cuenta.RodID = Convert.ToInt16(row["ROL_ID"]);
                    cuenta.Cuenta = row["ROL_CUENTA"].ToString();
                    cuenta.SubCuenta = row["ROL_SUBCUENTA"].ToString();
                    cuenta.OrdImp = Convert.ToInt16(row["ROL_ORD_IMP"].ToString());
                    cuenta.Estado = row["ROL_ESTADO"].ToString() == "" ? 0 : Convert.ToInt16(row["ROL_ESTADO"].ToString());
                    cuenta.RolLocal = row["ROL_APA_LOCAL"].ToString() == "" ? dbType.intNull : Convert.ToInt16(row["ROL_APA_LOCAL"].ToString());
                    cuenta.GrupoRolID = row["GRU_VAR_ROL_ID"].ToString() == "" ? dbType.intNull : Convert.ToInt16(row["GRU_VAR_ROL_ID"].ToString());
                    CuentaBO.RegistraCuenta(cuenta, tipoSQL);
                }
            }
            if (getCambioDT != null)
            {

                foreach (DataRow item in getCambioDT.Rows)
                {
                    db.DatProvisionRol provision = new db.DatProvisionRol();
                    provision.rolId = Convert.ToInt16(item["ROL_ID"]);
                    provision.cueProvId = Convert.ToInt16(item["CUE_PROV_ID"]);
                    provision.cueProvId_Temp = Convert.ToInt16(item["CUE_PROV_ID", DataRowVersion.Original]);
                    provision.provRolEstado = item["PROV_ROL_ESTADO"].ToString() == "" ? 0 : Convert.ToInt16(item["PROV_ROL_ESTADO"]);
                    CuentaBO.RegistraProvision(provision, tipoSQL);
                }
            }

            if (op)
            {
                SaveChangeRows(false, DataRowState.Modified, "U");
            }
        }

        private void dgvDatos_CurrentCellChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewCell item in dgvDatos.SelectedCells)
            {
                if (item.Selected)
                {
                    if (dgvDatos.Rows[item.RowIndex].Cells["ROL_ID"].Value != DBNull.Value)
                    {
                        rolID = Convert.ToInt32(dgvDatos.Rows[item.RowIndex].Cells["ROL_ID"].Value);
                        dgvDatosDT.DataSource = CuentaBO.ListaProvisionRol(Convert.ToInt16(dgvDatos.Rows[item.RowIndex].Cells["ROL_ID"].Value));
                    }
                }
            }
        }

        private void CheckChange()
        {
            if (ValidateGrid())
            {
                if (Utility.MensajeQuestion("¿Desea Guardar Cambios?") == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveChangeRows(true, DataRowState.Added, "I");
                    //ban = false;
                    ((DataTable)dgvDatosDT.DataSource).AcceptChanges();
                    ((DataTable)dgvDatos.DataSource).AcceptChanges();
                    LoadData();
                }
                else
                {
                    //((DataTable)dgvDatosDT.DataSource).RejectChanges();
                    ((DataTable)dgvDatos.DataSource).RejectChanges();

                }
            }
        }

        private bool ValidateGrid()
        {
            DataTable datos = (DataTable)dgvDatos.DataSource;
            DataTable datoDT = (DataTable)dgvDatosDT.DataSource;
            DataTable getCambios = datos.GetChanges(DataRowState.Added);
            DataTable getCambioDT = datoDT.GetChanges(DataRowState.Added);
            if (getCambios != null | getCambioDT != null)
                return true;
            else
            {
                getCambios = datos.GetChanges(DataRowState.Modified);
                getCambioDT = datoDT.GetChanges(DataRowState.Modified);
                if (getCambios != null | getCambioDT != null)
                    return true;

            }
            return false;
        }
        
        private void dgvDatosDT_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["ROL_ID_DT"].Value = rolID;
        }

        private void dgvDatos_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
           // if(ban)
                CheckChange();
        }


    }
}
