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
    public partial class frmResumenRol : Form, IFrmResumenRol
    {
        #region Variables
        //int _reproceso;

        string _cuentaNom;
        string _cuentaID;
        string _peridoID;
        #endregion

        #region Properties
        private EmpleadoController EmpleadoBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        private Acction StateButton { get; set; }
        #endregion

        #region Instancia / Constructor
        private static frmResumenRol _instancia;
        public static frmResumenRol Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmResumenRol();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmResumenRol()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            ContratoBO = ContratoController.Instancia;
            dgvData.AutoGenerateColumns = false;
            ClearControls("A");
        }
        #endregion

        #region Methodos


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
                txtFechaSalida.Text = info.Rows[0]["EMP_FEC_SALIDA"].ToString()==""  ? "No Asignada" : Convert.ToDateTime(info.Rows[0]["EMP_FEC_SALIDA"].ToString()).ToShortDateString();
                txtFechaContrato.Text = Convert.ToDateTime(info.Rows[0]["EMP_CON_FEC_CONTRATO"].ToString()).ToShortDateString();
                txtFehaMedico.Text = info.Rows[0]["AFILIACION"].ToString();
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
                //txtCodigoRol.Text = datos.Rows[0]["ROL_DIA_TRA"].ToString();
                chkQuincena.Checked = (datos.Rows[0]["ROL_PAG_QUIN"].ToString().Equals("1") ? true : false);
                chkRol.Checked = (datos.Rows[0]["ROL_PAGADO"].ToString().Equals("1") ? true : false);
                chkRolReten.Checked = (datos.Rows[0]["ROL_RETENIDO"].ToString().Equals("1") ? true : false);
                txtDiaTrabajo.Text = datos.Rows[0]["ROL_DIA_TRA"].ToString();
                txtDiaDescuento.Text = datos.Rows[0]["ROL_DIA_DESC"].ToString();
                dgvData.DataSource = ContratoBO.ListarRolDetalle(txtCodigo.Text, Convert.ToInt32(txtPeriodo.Text), Convert.ToInt32(txtReproceso.Text));
                txtCodigoRol.Text = EmpleadoBO.CargoEmpleadoRol(txtCodigo.Text, txtPeriodo.Text, txtReproceso.Text);
                lblEstadoRol.Text = ContratoBO.EstadoRol(txtPeriodo.Text, txtReproceso.Text);
                lblMesRol.Text = "Mes de: " + ContratoBO.MesRol(txtPeriodo.Text);
                Totales();
            }
        }

        //private void SelectRol()
        //{
        //    if (!_peridoID.Equals(string.Empty))
        //    {
        //        ClearControls("S");
        //        _reproceso = ContratoBO.NumeroProcesoEmp(Convert.ToInt32(_peridoID), txtCodigo.Text);

        //        if (_reproceso > 1)
        //            txtReproceso.Text = (_reproceso - 1).ToString();
        //        else
        //            txtReproceso.Text = _reproceso.ToString();

        //        DataTable datos = new DataTable();
        //        datos = ContratoBO.ListarRol(txtCodigo.Text, Convert.ToInt32(_peridoID), Convert.ToInt32(txtReproceso.Text));
        //        txtPeriodo.Text = _peridoID;
        //        if (datos.Rows.Count > 0)
        //        {
        //            //txtCodigoRol.Text = datos.Rows[0]["ROL_DIA_TRA"].ToString();
        //            chkQuincena.Checked = (datos.Rows[0]["ROL_PAG_QUIN"].ToString().Equals("1") ? true : false);
        //            chkRol.Checked = (datos.Rows[0]["ROL_PAGADO"].ToString().Equals("1") ? true : false);
        //            chkRolReten.Checked = (datos.Rows[0]["ROL_RETENIDO"].ToString().Equals("1") ? true : false);
        //            txtDiaTrabajo.Text = datos.Rows[0]["ROL_DIA_TRA"].ToString();
        //            txtDiaDescuento.Text = datos.Rows[0]["ROL_DIA_DESC"].ToString();
        //            dgvData.DataSource = ContratoBO.ListarRolDetalle(txtCodigo.Text, Convert.ToInt32(txtPeriodo.Text), Convert.ToInt32(txtReproceso.Text));
        //            txtCodigoRol.Text = EmpleadoBO.CargoEmpleadoRol(txtCodigo.Text, txtPeriodo.Text, txtReproceso.Text);
        //            lblEstadoRol.Text = ContratoBO.EstadoRol(txtPeriodo.Text, txtReproceso.Text);
        //            lblMesRol.Text = "Mes de: " + ContratoBO.MesRol(txtPeriodo.Text);
        //            Totales();
        //        }
        //    }
        //    else
        //    {
        //        txtReproceso.Text = string.Empty;
        //        _reproceso = 0;
        //        _peridoID = string.Empty;
        //        txtPeriodo.Text = string.Empty;
        //        dgvData.DataSource = null;
        //        txtCodigoRol.Text = string.Empty;
        //        txtDiaTrabajo.Text = string.Empty;
        //        txtDiaDescuento.Text = string.Empty;
        //        lblEstadoRol.Text = "...";
        //        lblMesRol.Text = "...";
        //        txtIngreso.Text = string.Empty;
        //        txtEgreso.Text = string.Empty;
        //        txtRercibe.Text = string.Empty;
        //    }
        //}


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
                    foreach (DataGridViewRow item in dgvData.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            if (item.Cells["Cuenta"].Value.Equals(DBNull.Value) | Convert.ToInt16(item.Cells["Cuenta"].Value) == 0)
                                item.Cells["Cuenta"].ErrorText = (ban++).ToString() + ": Seleccione una cuenta";
                            if (item.Cells["Valor"].Value.Equals(DBNull.Value) | Convert.ToInt16(item.Cells["Cuenta"].Value) == 0)
                                item.Cells["Valor"].ErrorText = (ban++).ToString() + ": Ingrese el valor";
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
            btnModificar.Enabled = !stdo;
            foreach (DataGridViewColumn item in dgvData.Columns)
            {
                if (item.Name == "Valor" | item.Name == "btnCuenta")
                    item.ReadOnly = !stdo;
                else
                    item.ReadOnly = true;
            }
            dgvData.AllowUserToAddRows = stdo;

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
            }
            if (seg.Equals("A") | seg.Equals("S"))
            {
                txtPeriodo.Text = string.Empty;
                txtReproceso.Text = string.Empty;
                txtCodigoRol.Text = string.Empty;
                chkQuincena.Checked = false;
                chkRol.Checked = false;
                txtDiaTrabajo.Text = string.Empty;
                txtDiaDescuento.Text = string.Empty;
                dgvData.DataSource = null;
                txtEgreso.Text = string.Empty;
                txtIngreso.Text = string.Empty;
                txtRercibe.Text = string.Empty;
            }
        }

        private void Totales()
        {
            double egreso = 0;
            double ingreso = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells["NOMBRE"].Value != null)
                {
                    if (row.Cells["NOMBRE"].Value.ToString().Substring(0, 1).Equals("I"))
                        ingreso += Convert.ToDouble(row.Cells["Valor"].Value);
                    else
                        egreso += Convert.ToDouble(row.Cells["Valor"].Value);
                }
            }
            txtEgreso.Text = egreso.ToString();
            txtIngreso.Text = ingreso.ToString();
            txtRercibe.Text = (ingreso - egreso).ToString();
        }

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

        private void TotalSalary()
        {
            double ingreso = 0;
            double egreso = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells["Nombre"].Value != null)
                    {
                        if (row.Cells["Nombre"].Value.ToString().Contains("Ingreso"))
                            ingreso += row.Cells["Valor"].Value==DBNull.Value ?0: Convert.ToDouble(row.Cells["Valor"].Value);
                        else
                            egreso += row.Cells["Valor"].Value==DBNull.Value ?0: Convert.ToDouble(row.Cells["Valor"].Value);
                    }
                }
            }
            txtIngreso.Text = ingreso.ToString();
            txtEgreso.Text = egreso.ToString();
            txtRercibe.Text = (ingreso - egreso).ToString();
        }


        #endregion

        private void frmResumenRol_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            //AssignData();
        }        

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Equals(string.Empty))
                return;

            //_reproceso = 0;
            _peridoID = string.Empty;
            var frm = new frmListaEmergente("Períodos ", "PeriodoRol");
            Design.frmDialog(frm,"Períodos");
            txtPeriodo.Text = _peridoID;
            if (!txtPeriodo.Text.Equals(string.Empty))
                SelectRol("Periodo");
            //txtPeriodo.Text = EmpleadoBO.Empleado.empId.ToString();
        }        

        private void bntProvision_Click(object sender, EventArgs e)
        {
            //_reproceso = 0;
            var frm = new frmListaEmergente("Proviciones ", "Proviciones");
            frm.ShowDialog(this);

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if ((dgvData.Columns[e.ColumnIndex].GetType()).ToString() == "System.Windows.Forms.DataGridViewButtonColumn")
            {
                if (StateButton.Equals(Acction.Edit))
                {
                    var frm = new frmListaEmergente("Cuentas ", "Cuentas");
                    frm.ShowDialog(this);
                    //Utility.MensajeOK(_cuentaID.ToString());
                    if (_cuentaID!=null)
                    {
                        foreach (DataGridViewRow row in dgvData.Rows)
                        {
                            if (row.Index != e.RowIndex && row.Cells["Cuenta"].Value != null)
                            {
                                if (_cuentaID == (row.Cells["Cuenta"]).FormattedValue.ToString())
                                {
                                    Utility.MensajeInfo("Error..!! Ya se encuentra adicionada esta cuenta");
                                    _cuentaID = null;
                                    return;
                                }
                            }
                        }
                        dgvData.Rows[e.RowIndex].Cells["Cuenta"].Value = Convert.ToInt32(_cuentaID);
                        dgvData.Rows[e.RowIndex].Cells["Nombre"].Value = _cuentaNom;
                        _cuentaID = null;
                    }
                }
            }
        }
        
        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (this.btnNewSave.Text != "&Nuevo")
            {
                if (ValidaDatos())
                {
                    DataTable datos = (DataTable)dgvData.DataSource;
                    DataTable getDataMod = datos.GetChanges(DataRowState.Modified);
                    DataTable getDataAdd = datos.GetChanges(DataRowState.Added);
                    DataTable getDataDel = datos.GetChanges(DataRowState.Deleted);

                    if (getDataAdd != null | getDataMod != null | getDataDel != null)
                    {
                        if (Utility.MensajeQuestion("¿Está seguro que desea registrar los cambios?") == System.Windows.Forms.DialogResult.Yes)
                        {
                            //decimal rolID = 0;
                            //decimal detRolID = 0;

                            if (getDataMod != null)
                            {

                                foreach (DataRow row in getDataMod.Rows)
                                {
                                    db.DetRolEntity campo = new db.DetRolEntity();
                                    campo.rolId = Convert.ToInt32(row["ROL_ID"]);
                                    campo.empId = txtCodigo.Text;
                                    campo.rolIdGen = Convert.ToInt32(txtPeriodo.Text);
                                    campo.detRolId = txtPeriodo.Text + txtCodigo.Text;
                                    campo.detRolValor = Convert.ToDouble(row["DET_ROL_VALOR"]);                                    
                                    campo.detRolFecha = DateTime.Now;
                                    campo.rolRepro = Convert.ToInt32(txtReproceso.Text);
                                    ContratoBO.ActualizaDetalleRol(campo);                                   
                                }                               

                            }

                            if (getDataAdd != null)
                            {
                                //detRolID = 0;
                                //rolID = 0;
                                List<db.DetRolEntity> detalleRol = new List<db.DetRolEntity>();
                                foreach (DataRow row in getDataAdd.Rows)
                                {
                                    db.DetRolEntity campo = new db.DetRolEntity();
                                    campo.rolId = Convert.ToInt32(row["ROL_ID"]);
                                    campo.empId = txtCodigo.Text;
                                    campo.rolIdGen = Convert.ToInt32(txtPeriodo.Text);
                                    campo.detRolId = txtPeriodo.Text + txtCodigo.Text;
                                    campo.detRolValor = Convert.ToDouble(row["DET_ROL_VALOR"]);
                                    campo.detRolFecha = DateTime.Now;
                                    campo.rolRepro = Convert.ToInt32(txtReproceso.Text);
                                    detalleRol.Add(campo);
                                }
                                ContratoBO.RegistraDetalleRol(detalleRol);                                
                            }

                            if (getDataDel != null)
                            {
                                //detRolID = 0;
                                //rolID = 0;
                                foreach (DataRow row in getDataDel.Rows)
                                {
                                    db.DetRolEntity campo = new db.DetRolEntity();
                                    campo.rolId = Convert.ToInt32(row["ROL_ID", DataRowVersion.Original]);
                                    campo.empId = row["EMP_ID", DataRowVersion.Original].ToString();
                                    campo.rolIdGen = Convert.ToInt32(row["ROL_ID_GEN", DataRowVersion.Original]);
                                    campo.detRolId = row["DET_ROL_ID", DataRowVersion.Original].ToString();
                                    //campo.detRolValor = Convert.ToDouble(row["DET_ROL_VALOR"]);                                    
                                    campo.rolRepro = Convert.ToInt32(row["ROL_REPRO", DataRowVersion.Original]);
                                    ContratoBO.EliminaDetalleRol(campo);
                                }                                
                            }
                            SelectRol("Periodo");
                            Utility.MensajeOK("Información Reagistrada..!!");
                        }
                    }
                    //-------------------------------------------------------------------------------------------------
                    //-------------------------------------------------------------------------------------------------
                    //List<db.DetRolEntity> detalleRol = new List<db.DetRolEntity>();
                    //foreach (DataGridViewRow item in dgvData.Rows)
                    //{
                    //    if (!item.IsNewRow)
                    //    {

                    //        db.DetRolEntity campo = new db.DetRolEntity();
                    //        campo.rolId = Convert.ToInt32(item.Cells["Cuenta"].Value);
                    //        campo.empId = txtCodigo.Text;
                    //        campo.rolIdGen = Convert.ToInt32(txtPeriodo.Text);
                    //        campo.detRolId = txtPeriodo.Text + txtCodigo.Text;
                    //        campo.detRolValor = Convert.ToDouble(item.Cells["Valor"].Value);
                    //        campo.detRolFecha = DateTime.Now;
                    //        campo.rolRepro = Convert.ToInt32(txtReproceso.Text);
                    //        detalleRol.Add(campo);
                    //    }
                    //}
                    //ContratoBO.EliminaDetalleRol(txtCodigo.Text, txtPeriodo.Text, txtReproceso.Text);
                    //if (ContratoBO.RegistraDetalleRol(detalleRol).Equals(1))
                    //{
                    //    SelectRol("Periodo");
                    //    Utility.MensajeOK("Los cambios fueron almacenados");
                    //};
                }
                else
                    return;

                Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
                ActiveControls(false);
            }
            BlockButton();

        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (this.btnEditCancel.Text != "&Cancelar")
            {
                if (txtCargo.Text.Equals(string.Empty) | txtPeriodo.Text.Equals(string.Empty))
                    return;
                if (!ValidaDatosEdit())
                    return;

                StateButton = Acction.Edit;
                ActiveControls(true);
                //txtReproceso.Text = (Convert.ToInt16(txtReproceso.Text) + 1).ToString();

                ////if (ContratoBO.VerificaRol(txtCodigo.Text, txtPeriodo.Text, txtReproceso.Text) == 1)
                ////{
                ////    dgvData.DataSource = ContratoBO.ListarRolDetalle(txtCodigo.Text, Convert.ToInt32(txtPeriodo.Text), Convert.ToInt32(txtReproceso.Text));
                ////    Totales();
                ////}
                ////else
                ////{
                ////    dgvData.DataSource = ContratoBO.ListarRolDetalle(txtCodigo.Text, Convert.ToInt32(txtPeriodo.Text), Convert.ToInt32(txtReproceso.Text));
                ////    Totales();
 
                ////}
                //dgvData.DataSource = ContratoBO.ListarRolDetalle(txtCodigo.Text, Convert.ToInt32(txtPeriodo.Text), Convert.ToInt32(txtReproceso.Text));
                SelectRol("Edicion");
                Totales();
            }
            else
            {

                StateButton = Acction.Cancel;
                ActiveControls(false);
                //txtReproceso.Text = (Convert.ToInt16(txtReproceso.Text) - 1).ToString();
                SelectRol("Periodo");
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
                if (dgvData.CurrentRow!=null)                    
                    dgvData.Rows.RemoveAt(dgvData.CurrentRow.Index);
                TotalSalary();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var frm = new frmEmpleadoLista();
            frm.ShowDialog();
            AssignData(EmpleadoBO.Empleado.empId.ToString());
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string nameColumn = dgvData.Columns[e.ColumnIndex].Name;
            if (nameColumn == "Valor" | nameColumn == "Cuenta")
            {
                TotalSalary();
            }
            dgvData.Rows[e.RowIndex].ErrorText = String.Empty;
            //dgvData.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
        }

        
        private void dgvData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //if (dgvData.IsCurrentCellDirty)
            //    dgvData.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int index = dgvData.CurrentCell.ColumnIndex;
            if (dgvData.Columns[index].Name == "Valor")
            {
                DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;
                dText.KeyPress -= new KeyPressEventHandler(dText_KeyPress);
                dText.KeyPress += new KeyPressEventHandler(dText_KeyPress);
            }
        }

        void dText_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Utility.OnlyDigit(e);
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

       
    }
}
