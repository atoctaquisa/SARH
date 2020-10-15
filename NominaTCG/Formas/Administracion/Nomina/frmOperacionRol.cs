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
    public partial class frmOperacionRol : Form, IFrmOperacionRol
    {
        #region Variables
        string _cuentaNom;
        string _cuentaID;
        string _peridoID;
        #endregion

        #region Properties
        private EmpleadoController EmpleadoBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        private string localID { get; set; }
        private Acction StateButton { get; set; }

        #endregion

        #region Instancia / Constructor
        private static frmOperacionRol _instancia;
        public static frmOperacionRol Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmOperacionRol();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmOperacionRol()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            ContratoBO = ContratoController.Instancia;
            dgvData.AutoGenerateColumns = false;
            dgvCuenta.AutoGenerateColumns = false;
            dgvData.ReadOnly = true;
            ClearControls("A");
        }
        #endregion

        #region Methodos

        public void getCuentaNom(string nomCuenta)
        {
            _cuentaNom = nomCuenta;
        }

        public void getCuentaID(string idCuenta)
        {
            _cuentaID = idCuenta;
        }

        public void getEmpleadoID(string idCodigo)
        {
            txtCodigo.Text = idCodigo;
        }

        public void getPeriodoID(string idCodigo)
        {
            _peridoID = idCodigo;
        }

        void dText_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Utility.OnlyQuantity(sender, e);
        }

        private void RolCuenta(int item)
        {
            dgvCuenta.DataSource = ContratoBO.ListarRolDetalleCuenta(txtCodigo.Text, txtPeriodo.Text, txtReproceso.Text, dgvData.Rows[item].Cells["Cuenta"].Value.ToString());
        }

        private void BlockButton()
        {
            if (this.btnNewSave.Text == "&Nuevo")
                btnNewSave.Enabled = false;
            else
                btnNewSave.Enabled = true;

        }

        private void ActiveControls(bool stdo)
        {
            ErrProv.Clear();
            btnSearch.Enabled = !stdo;
            btnConfiguracion.Enabled = !stdo;
            foreach (DataGridViewColumn item in dgvCuenta.Columns)
            {
                if (item.Name == "ESP_VALOR" | item.Name == "ESP_OBS")
                    item.ReadOnly = !stdo;
                else
                    item.ReadOnly = true;
            }
            dgvCuenta.AllowUserToAddRows = stdo;

        }

        private void ClearControls(string seg)
        {
            if (seg.Equals("A"))
            {
                txtCodigo.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtCargo.Text = string.Empty;
                txtTrabajo.Text = string.Empty;
                txtFechaIngreso.Text = string.Empty;
                txtPatrono.Text = string.Empty;
                txtEstado.Text = string.Empty;
                txtFechaSalida.Text = string.Empty;
                txtFechaContrato.Text = string.Empty;
                txtFehaMedico.Text = string.Empty;
                txtTotal.Text = "0";
            }
            if (seg.Equals("A") | seg.Equals("S"))
            {
                txtPeriodo.Text = string.Empty;
                txtReproceso.Text = string.Empty;
                dgvData.DataSource = null;
                dgvCuenta.DataSource = null;
            }
        }

        private void TotalCuenta()
        {
            double egreso = 0;
            foreach (DataGridViewRow row in dgvCuenta.Rows)
            {
                if (row.Cells["ESP_VALOR"].Value != null)
                {
                    egreso += row.Cells["ESP_VALOR"].Value == DBNull.Value ? 0 : Convert.ToDouble(row.Cells["ESP_VALOR"].Value);
                }
            }
            txtTotal.Text = egreso.ToString();
        }

        private void AssignData(string empID)
        {
            DataTable info = EmpleadoBO.ListaEmpleadoDT(empID);
            if (info.Rows.Count > 0)
            {
                txtCodigo.Text = info.Rows[0]["EMP_ID"].ToString();
                txtNombre.Text = info.Rows[0]["NOMBRE"].ToString();
                txtCargo.Text = info.Rows[0]["ESC_CARGOMB"].ToString();
                txtTrabajo.Text = info.Rows[0]["LOC_NOMBRE"].ToString();
                txtFechaIngreso.Text = Convert.ToDateTime(info.Rows[0]["LAB_FEC_INGRESO"].ToString()).ToShortDateString();
                txtPatrono.Text = info.Rows[0]["PATRONO"].ToString();
                txtEstado.Text = info.Rows[0]["ESTADO"].ToString();
                txtFechaSalida.Text = info.Rows[0]["EMP_FEC_SALIDA"].ToString().Equals(string.Empty) ? "No Asignada" : Convert.ToDateTime(info.Rows[0]["EMP_FEC_SALIDA"].ToString()).ToShortDateString();
                txtFechaContrato.Text = Convert.ToDateTime(info.Rows[0]["EMP_CON_FEC_CONTRATO"].ToString()).ToShortDateString();
                txtFehaMedico.Text = info.Rows[0]["AFILIACION"].ToString();
                localID = info.Rows[0]["LOC_ID"].ToString();
                ClearControls("S");
            }
        }

        private void SelectRol(string tipoConsulta)
        {

            if (tipoConsulta.Equals("Periodo"))
                txtReproceso.Text = (ContratoBO.NumeroProcesoEmp(Convert.ToInt32(txtPeriodo.Text), txtCodigo.Text) - 1).ToString();
            if (tipoConsulta.Equals("Reproceso"))
                txtReproceso.Text = ContratoBO.RolSeg.segRolRepro.ToString();
            if (tipoConsulta.Equals("Edicion"))
                txtReproceso.Text = ContratoBO.NumeroProcesoEmp(Convert.ToInt32(txtPeriodo.Text), txtCodigo.Text).ToString();

            DataTable datos = new DataTable();
            datos = ContratoBO.ListarRol(txtCodigo.Text, Convert.ToInt32(txtPeriodo.Text), Convert.ToInt32(txtReproceso.Text));
            if (datos.Rows.Count > 0)
            {
                dgvData.DataSource = ContratoBO.ListarRolDetalle(txtCodigo.Text, Convert.ToInt32(txtPeriodo.Text), Convert.ToInt32(txtReproceso.Text), "");
                if (((DataTable)dgvData.DataSource).Rows.Count > 0)
                {
                    RolCuenta(0);
                }
                lblTotalRegistro.Text = "Nº Registros " + ((DataTable)dgvData.DataSource).Rows.Count;
            }
        }

        private bool ValidaDatosEdit()
        {
            int ban = 1;
            int proceso = ContratoBO.VerificaPeriodo(Convert.ToInt16(txtPeriodo.Text), Convert.ToInt16(txtReproceso.Text), "");
            if (proceso == 0)
            {
                proceso = ContratoBO.VerificaPeriodo(Convert.ToInt16(txtPeriodo.Text), Convert.ToInt16(txtReproceso.Text));
                if (proceso == 0)
                {
                    Utility.MensajeInfo((ban++) + ": Acción Fallida..!! Primero de debe procesar el rol " + txtPeriodo.Text);
                }
            }
            else
                Utility.MensajeInfo((ban++) + ": Acción Fallida..!! El período ya se encuentra cerrado");

            if (ban.Equals(1))
                return true;
            else
                return false;
        }

        private bool ValidaDatos()
        {

            int ban = 1;
            int proceso = ContratoBO.VerificaPeriodo(Convert.ToInt16(txtPeriodo.Text), Convert.ToInt16(txtReproceso.Text), "");
            if (proceso == 0)
            {
                proceso = ContratoBO.VerificaPeriodo(Convert.ToInt16(txtPeriodo.Text), Convert.ToInt16(txtReproceso.Text));
                if (proceso > 0)
                {
                    foreach (DataGridViewRow item in dgvCuenta.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            if (item.Cells["ESP_VALOR"].Value.Equals(DBNull.Value) | Convert.ToInt16(item.Cells["ESP_VALOR"].Value) == 0)
                                item.Cells["ESP_VALOR"].ErrorText = (ban++).ToString() + ": Ingrese el valor";
                        }
                    }
                }
                else
                {
                    Utility.MensajeInfo((ban++) + ": Acción Fallida..!! Primero de debe procesar el rol " + txtPeriodo.Text);
                }
            }
            else
                Utility.MensajeInfo((ban++) + ": Acción Fallida..!! El período ya se encuentra cerrado");

            if (ban.Equals(1))
                return true;
            else
                return false;
        }

        #endregion

        private void frmOperacionRol_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Equals(string.Empty))
                return;

            _peridoID = string.Empty;
            var frm = new frmListaEmergente("Períodos ", "PeriodoRolCuenta");
            Design.frmDialog(frm, "");
            txtPeriodo.Text = _peridoID;
            if (!txtPeriodo.Text.Equals(string.Empty))
                SelectRol("Periodo");
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (this.btnNewSave.Text != "&Nuevo")
            {
                if (ValidaDatos())
                {
                    DataTable datos = (DataTable)dgvCuenta.DataSource;
                    DataTable getDataMod = datos.GetChanges(DataRowState.Modified);
                    DataTable getDataAdd = datos.GetChanges(DataRowState.Added);
                    DataTable getDataDel = datos.GetChanges(DataRowState.Deleted);

                    if (getDataAdd != null | getDataMod != null | getDataDel != null)
                    {
                        if (Utility.MensajeQuestion("¿Está seguro que desea registrar los cambios?") == System.Windows.Forms.DialogResult.Yes)
                        {
                            decimal rolID = 0;
                            decimal detRolID = 0;

                            if (getDataMod != null)
                            {

                                foreach (DataRow row in getDataMod.Rows)
                                {
                                    db.DetRolEspEntity campo = new db.DetRolEspEntity();
                                    campo.rolId = rolID = Convert.ToInt64(row["ROL_ID"]);
                                    campo.empId = Convert.ToInt64(row["EMP_ID"]);
                                    campo.rolIdGen = Convert.ToInt64(row["ROL_ID_GEN"]);
                                    campo.detRolId = detRolID = Convert.ToInt64(row["DET_ROL_ID"]);
                                    campo.espId = Convert.ToInt64(row["ESP_ID"]);
                                    campo.espValor = Convert.ToInt64(row["ESP_VALOR"]);
                                    campo.espObs = row["ESP_OBS"].ToString();
                                    campo.rolRepro = Convert.ToInt64(row["ROL_REPRO"]);
                                    campo.espAudit = "Test de actualización";
                                    ContratoBO.ActualizaDetalleRol_ES(campo);
                                }
                                ActualizaDetalle(rolID, detRolID);

                            }

                            if (getDataAdd != null)
                            {
                                detRolID = 0;
                                rolID = 0;
                                foreach (DataRow row in getDataAdd.Rows)
                                {
                                    db.DetRolEspEntity campo = new db.DetRolEspEntity();
                                    campo.rolId = rolID = Convert.ToInt64(row["ROL_ID"]);
                                    campo.empId = Convert.ToInt64(txtCodigo.Text);
                                    campo.rolIdGen = Convert.ToInt64(txtPeriodo.Text);
                                    campo.detRolId = detRolID = Convert.ToInt64(row["DET_ROL_ID"]);
                                    //campo.espId = Convert.ToInt64(row["ESP_ID"]);
                                    campo.locId = Convert.ToDecimal(localID);
                                    campo.espValor = Convert.ToInt64(row["ESP_VALOR"]);
                                    campo.espObs = row["ESP_OBS"].ToString();
                                    campo.rolRepro = Convert.ToInt64(txtReproceso.Text);
                                    campo.espAudit = "Test de actualización";
                                    ContratoBO.RegistraDetalleRol_ES(campo);
                                }
                                ActualizaDetalle(rolID, detRolID);
                            }

                            if (getDataDel != null)
                            {
                                detRolID = 0;
                                rolID = 0;
                                foreach (DataRow row in getDataDel.Rows)
                                {
                                    db.DetRolEspEntity campo = new db.DetRolEspEntity();
                                    campo.rolId = rolID = Convert.ToInt64(row["ROL_ID", DataRowVersion.Original]);
                                    campo.empId = Convert.ToInt64(txtCodigo.Text);
                                    campo.rolIdGen = Convert.ToInt64(txtPeriodo.Text);
                                    campo.detRolId = detRolID = Convert.ToInt64(row["DET_ROL_ID", DataRowVersion.Original]);
                                    campo.espId = Convert.ToInt64(row["ESP_ID", DataRowVersion.Original]);
                                    campo.locId = Convert.ToDecimal(localID);
                                    campo.espValor = Convert.ToInt64(row["ESP_VALOR", DataRowVersion.Original]);
                                    campo.espObs = row["ESP_OBS", DataRowVersion.Original].ToString();
                                    campo.rolRepro = Convert.ToInt64(txtReproceso.Text);
                                    campo.espAudit = "Test de actualización";
                                    ContratoBO.EliminaDetalleRol_ES(campo);
                                }
                                ActualizaDetalle(rolID, detRolID);
                            }

                            SelectRol("Periodo");
                            Utility.MensajeOK("Información Reagistrada..!!");
                        }
                    }
                }
                else
                    return;

                Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
                ActiveControls(false);
            }
            BlockButton();
        }

        private void ActualizaDetalle(decimal rolID, decimal detRolID)
        {
            db.DetRolEntity item = new db.DetRolEntity();
            item.empId = txtCodigo.Text;
            item.rolIdGen = Convert.ToInt32(txtPeriodo.Text);
            item.rolRepro = Convert.ToInt32(txtReproceso.Text);
            item.rolId = Convert.ToInt32(rolID);
            item.detRolId = detRolID.ToString();
            item.detRolValor = Convert.ToDouble(txtTotal.Text);
            ContratoBO.ActualizaDetalleRol(item);
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (this.btnEditCancel.Text != "&Cancelar")
            {
                if (txtCargo.Text.Equals(string.Empty) | txtPeriodo.Text.Equals(string.Empty))
                    return;

                if (ValidaDatosEdit())
                {
                    StateButton = Acction.Edit;
                    ActiveControls(true);
                    SelectRol("Edicion");
                    foreach (DataGridViewCell item in dgvData.SelectedCells)
                    {
                        if (item.Selected)
                        {
                            RolCuenta(item.RowIndex);
                            TotalCuenta();
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                StateButton = Acction.Cancel;
                ActiveControls(false);
                SelectRol("Periodo");
                TotalCuenta();
            }

            Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
            BlockButton();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void frmResumenRol_Load(object sender, EventArgs e)
        {
            Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
            BlockButton();
            ActiveControls(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (StateButton.Equals(Acction.Edit))
            {
                if (dgvCuenta.CurrentRow != null)
                {
                    dgvCuenta.Rows.RemoveAt(dgvCuenta.CurrentRow.Index);
                    TotalCuenta();
                }


            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var frm = new frmEmpleadoLista();
            frm.ShowDialog();
            AssignData(EmpleadoBO.Empleado.empId.ToString());
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!txtPeriodo.Text.Equals(string.Empty))
            {
                ErrProv.Clear();
                frmListaReproceso frm = new frmListaReproceso(new string[] { txtPeriodo.Text });
                Design.frmDialog(frm, "Número");
                txtReproceso.Text = ContratoBO.RolSeg.segRolRepro.ToString();
                SelectRol("Reproceso");
            }
            else
                ErrProv.SetError(btnConfiguracion, "Seleccione un período primero");
        }

        private void dgvData_CurrentCellChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewCell item in dgvData.SelectedCells)
            {
                if (item.Selected)
                {
                    RolCuenta(item.RowIndex);
                    TotalCuenta();
                }
            }
        }

        private void dgvCuenta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string nameColumn = dgvCuenta.Columns[e.ColumnIndex].Name;
            if (nameColumn == "ESP_VALOR" )
            {
                foreach (DataGridViewCell item in dgvData.SelectedCells)
                {
                    if (item.Selected)
                    {
                        dgvCuenta.Rows[e.RowIndex].Cells["ROL_ID"].Value = dgvData.Rows[item.RowIndex].Cells["Cuenta"].Value;
                        dgvCuenta.Rows[e.RowIndex].Cells["DET_ROL_ID"].Value = dgvData.Rows[item.RowIndex].Cells["DDET_ROL_ID"].Value;
                    }
                }
                TotalCuenta();
            }
        }

        private void dgvCuenta_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int index = dgvCuenta.CurrentCell.ColumnIndex;
            if (dgvCuenta.Columns[index].Name == "ESP_VALOR")
            {
                DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;
                dText.KeyPress -= new KeyPressEventHandler(dText_KeyPress);
                dText.KeyPress += new KeyPressEventHandler(dText_KeyPress);
            }
        }

        private void dgvCuenta_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            //dgvCuenta.DataError += dgvCuenta_DataError;
            //var exType = e.Exception.GetType().ToString();

            //if (exType == "System.FormatException")
            //{
            //    Utility.MensajeError("Ingresa el valor");
            //}
        }




       


    }
}
