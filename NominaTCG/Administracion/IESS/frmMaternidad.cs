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
using Entity;

namespace NominaTCG
{
    public partial class frmMaternidad : Form
    {
        private SolicitudController SolicitudBO { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        private Acction StateButton { get; set; }

        #region Methodos

        private bool ValidaDatos(DataTable getDataAdd, DataTable getDataDiaAdd, string tipoID)
        {
            int ban = 1;
            //if (tipoID.Equals("I"))
            //{
            //    if (getDataAdd == null)
            //         Utility.MensajeError((ban++).ToString() + "Registre las fechas del aviso");

            //    if (getDataDiaAdd != null)
            //         Utility.MensajeError((ban++).ToString() + "Registre los porcentajes de días");

            //    if (ban > 1)
            //        return false;
            //    else
            //        return true;
            //}

            if (getDataAdd != null)
            {
                foreach (DataRow row in getDataAdd.Rows)
                {
                    if (row["IESS_TIPO"].ToString().Equals(""))
                        Utility.MensajeError((ban++).ToString() + "Seleccione el tipo de aviso");

                    DateTime fechaIni = Convert.ToDateTime(row["IESS_FECHAINICIO"].ToString());
                    DateTime fechaFin = Convert.ToDateTime(row["IESS_FECHAFIN"].ToString());
                    if (fechaFin < fechaIni)
                        Utility.MensajeError((ban++).ToString() + "La Fecha Fin no pueden ser menor que la Fecha Inicial");
                }
            }
            if (getDataDiaAdd != null)
            {
                foreach (DataRow row in getDataDiaAdd.Rows)
                {
                    if (row["DIA_NUM"].ToString().Equals(""))
                        Utility.MensajeError((ban++).ToString() + "Registre el días");
                    if (row["DIA_PORC"].ToString().Equals(""))
                        Utility.MensajeError((ban++).ToString() + "Seleccione el porcentaje");
                }
            }

            //foreach (DataGridViewRow item in dgvData.Rows)
            //{
            //    if (!item.IsNewRow)
            //    {
            //        if (item.Cells["EMP_ID"].Value.Equals(DBNull.Value))
            //            item.Cells["EMP_ID"].ErrorText = (ban++).ToString() + " :Seleccione al Empleado";
            //        else
            //            item.Cells["EMP_ID"].ErrorText = string.Empty;
            //    }
            //}

            if (ban > 1)
                return false;
            else
                return true;
        }

        private void ActiveControls(bool stdo)
        {
            ErrProv.Clear();
            foreach (DataGridViewColumn item in dgvData.Columns)
            {
                if (item.Name == "perID" | item.Name == "IESS_TIPO" | item.Name == "IESS_FECHAINICIO" |
                    item.Name == "IESS_FECHAINICIO" | item.Name == "IESS_FECHAFIN" |
                    item.Name == "DIAS" | item.Name == "IESS_OBSERVACION")
                    item.ReadOnly = !stdo;
                else
                    item.ReadOnly = true;
            }

            foreach (DataGridViewColumn item in dgvDias.Columns)
            {
                if (item.Name == "Valor" | item.Name == "Porcentaje")
                    item.ReadOnly = !stdo;
                else
                    item.ReadOnly = true;
            }

            DataTable periodo = ContratoBO.ListaPeriodo("PREPO");
            string periodoActivo = periodo.Rows[0][0].ToString();

            foreach (DataGridViewRow item in dgvData.Rows)
            {
                if (!item.IsNewRow)
                {
                    if (!item.Cells["ROL_ID_GEN"].Value.ToString().Equals(periodoActivo))
                        item.ReadOnly = true;
                    else
                        item.ReadOnly = false;
                }
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
                //txtPeriodo.Text = string.Empty;
                //txtReproceso.Text = string.Empty;
                //txtCodigoRol.Text = string.Empty;
                //chkQuincena.Checked = false;
                //chkRol.Checked = false;
                //txtDiaTrabajo.Text = string.Empty;
                //txtDiaDescuento.Text = string.Empty;
                //dgvData.DataSource = null;
                //txtEgreso.Text = string.Empty;
                //txtIngreso.Text = string.Empty;
                //txtRercibe.Text = string.Empty;
            }
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
                dgvData.DataSource = SolicitudBO.ListaSolicitudAccMatEnf(txtCodigo.Text);
                if (((DataTable)dgvData.DataSource).Rows.Count > 0)
                {
                    string rolID = dgvData.Rows[0].Cells["ROL_ID_GEN"].Value.ToString();
                    string reproID = dgvData.Rows[0].Cells["ROL_REPRO"].Value.ToString();
                    dgvDias.DataSource = SolicitudBO.ListaDiaAccMatEnf(empID, rolID, reproID);

                    HabilitaDias(rolID);
                }
                else
                {
                    dgvDias.DataSource = null;
                }

                btnEditCancel.Enabled = true;
                //btnClear.Enabled = true;
                //ClearControls("S");
            }
        }

        private void HabilitaDias(string rolID)
        {
            DataTable periodo = ContratoBO.ListaPeriodo("PREPO");
            string periodoActivo = periodo.Rows[0][0].ToString();
            if(periodoActivo.Equals(rolID) | rolID =="")
            {
                //foreach (DataGridViewRow item in dgvDias.Rows)
                //{
                //    if (!item.IsNewRow)
                //    {
                //        if (item.Cells["ROL_ID_GEN_"].Value.ToString().Equals(periodoActivo))
                //            item.ReadOnly = false;
                //        else
                //            item.ReadOnly = false;
                //    }
                //}
                dgvDias.AllowUserToAddRows = true ;
                dgvDias.ReadOnly = false;
            }
            else
            {
                dgvDias.ReadOnly = true;
                dgvDias.AllowUserToAddRows = false;
            }
                
            
        }

        private void CargarValores(DataTable getCambios, DataTable getCambiosDia, string tipoID)
        {

            List<DatIessEnfermedad> iess = new List<DatIessEnfermedad>();
            List<DatIessDiaEnfe> iessDia = new List<DatIessDiaEnfe>();
            DataTable periodo = ContratoBO.ListaPeriodo("PREPO");
            if (getCambios != null)
            {
                foreach (DataRow row in getCambios.Rows)
                {
                    DatIessEnfermedad notifica = new DatIessEnfermedad();
                    notifica.empId = txtCodigo.Text;
                    notifica.rolIdGen = Convert.ToUInt32(periodo.Rows[0][0]);
                    notifica.rolRepro = Convert.ToUInt32(periodo.Rows[0][1]);
                    notifica.iessFechainicio = row["IESS_FECHAINICIO"].ToString();
                    notifica.iessFechafin = row["IESS_FECHAFIN"].ToString();
                    notifica.iessTipo = Convert.ToUInt32(row["IESS_TIPO"]);
                    notifica.iessObservacion = row["IESS_OBSERVACION"].ToString();
                    iess.Add(notifica);
                }
            }
            if (getCambiosDia != null)
            {
                foreach (DataRow row in getCambiosDia.Rows)
                {
                    DatIessDiaEnfe dias = new DatIessDiaEnfe();
                    dias.empId = txtCodigo.Text;
                    dias.rolIdGen = Convert.ToUInt32(periodo.Rows[0][0]);
                    dias.rolRepro = Convert.ToUInt32(periodo.Rows[0][1]);
                    dias.diaNum = Convert.ToUInt32(row["DIA_NUM"]);
                    dias.diaPorc = Convert.ToUInt32(row["DIA_PORC"]);
                    dias.diaId = row["DIA_ID"]==DBNull.Value?0: Convert.ToUInt32(row["DIA_ID"]);
                    iessDia.Add(dias);
                }
            }

            try
            {

                SolicitudBO.RegistraSolicitudAccMatEnf(iess, iessDia, tipoID);
            }
            catch (Exception e)
            {
                Logger.ErrorLog.ErrorRoutine(false, e);
            }

        }

        #endregion

        #region Instancia / Constructor
        private static frmMaternidad _instancia;
        public static frmMaternidad Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmMaternidad();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmMaternidad()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            dgvDias.AutoGenerateColumns = false;
            StateButton = Acction.Cancel;
            SolicitudBO = SolicitudController.Instancia;
            EmpleadoBO = EmpleadoController.Instancia;
            ContratoBO = ContratoController.Instancia;
            IESS_TIPO.DataSource = SolicitudBO.ListaTipoAccMatEnf();
            IESS_TIPO.ValueMember = "IESS_TIPO";
            IESS_TIPO.DisplayMember = "IESS_DESC";
            DataTable porcet = SolicitudBO.ListaPorcentajeAccMatEnf();
            Porcentaje.DataSource = porcet;
            Porcentaje.ValueMember = "CAT_VALOR";
            Porcentaje.DisplayMember = "CAT_VALOR";
            //Porcentaje.ValueType = typeof(string);
            ClearControls("A");
            ActiveControls(false);
            //dgvData.DataSource = SolicitudBO.ListaSolicitudAccMatEnf("");
        }

        #endregion



        private void frmMaternidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void dgvData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dgvData.Columns[e.ColumnIndex].GetType()).ToString() == "System.Windows.Forms.DataGridViewButtonColumn")
            {
                if (StateButton.Equals(Acction.Edit))
                {
                    var frm = new frmMaternidadLista();
                    Design.frmDialog(this, "Lista de Datos");
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
                dgvDias.DataSource = null;
                dgvDias.AllowUserToAddRows = false; 
            }
        }



        private void dgvData_CurrentCellChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewCell item in dgvData.SelectedCells)
            {
                if (item.Selected)
                {
                    string empID = txtCodigo.Text; //dgvData.Rows[item.RowIndex].Cells["EMP_ID"].Value.ToString();
                    if (dgvData.Rows[item.RowIndex].Cells["ROL_ID_GEN"].Value != null)
                    {
                        string rolID = dgvData.Rows[item.RowIndex].Cells["ROL_ID_GEN"].Value.ToString();
                        string reproID = dgvData.Rows[item.RowIndex].Cells["ROL_REPRO"].Value.ToString();
                        dgvDias.DataSource = SolicitudBO.ListaDiaAccMatEnf(empID, rolID, reproID);
                        HabilitaDias(rolID);
                    }
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (StateButton.Equals(Acction.Cancel))
            {
                var frm = new frmEmpleadoLista();
                frm.ShowDialog();
                AssignData(EmpleadoBO.Empleado.empId.ToString());
            }
        }

        private void dgvDias_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
                {
                    object value = dgvDias.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (!((DataGridViewComboBoxColumn)dgvDias.Columns[e.ColumnIndex]).Items.Contains(value))
                    {
                        ((DataGridViewComboBoxColumn)dgvDias.Columns[e.ColumnIndex]).Items.Add(value);
                    }
                }

                throw e.Exception;
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
                //if (rethrow)
                //{
                //    MessageBox.Show(string.Format(@"Failed to bind ComboBox. "
                //    + "Please contact support with this message:"
                //    + "\n\n" + ex.Message));
                //}
            }
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {

            DataTable datos = (DataTable)dgvData.DataSource;
            DataTable datosDia = (DataTable)dgvDias.DataSource;
            DataTable getDataAdd = datos.GetChanges(DataRowState.Added);
            DataTable getDataDiaAdd = datosDia.GetChanges(DataRowState.Added);
            DataTable getDataMod = datos.GetChanges(DataRowState.Modified);
            DataTable getDataDiaMod = datosDia.GetChanges(DataRowState.Modified);

            if (!ValidaDatos(getDataAdd, getDataDiaAdd,"I"))
                return;

            if (!ValidaDatos(getDataMod, getDataDiaMod, "U"))
                return;

            if (Utility.MensajeQuestion("¿Está seguro que desea cargar los valores?") == System.Windows.Forms.DialogResult.Yes)
            {
                CargarValores(getDataAdd, getDataDiaAdd, "I");
                CargarValores(getDataMod, getDataDiaMod, "U");
                Design.ControlsEdit(this.btnEditCancel, this.btnNewSave);
                Utility.MensajeOK("Información Reagistrada..!!");
                ActiveControls(false);
                AssignData(txtCodigo.Text);
                btnSearch.Enabled = true;
                btnEditCancel.Enabled = false;
                btnNewSave.Enabled = false;
                btnDelete.Enabled = false;
                StateButton = Acction.Cancel;
            }

        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string nameColumn = dgvData.Columns[e.ColumnIndex].Name;
            if (nameColumn == "IESS_FECHAINICIO" | nameColumn == "IESS_FECHAFIN")
            {
                DataTable periodo = ContratoBO.ListaPeriodo("PREPO");
                dgvData.Rows[e.RowIndex].Cells["PROCESO"].Value = periodo.Rows[0][0] + " - " + periodo.Rows[0][1];
                DateTime fechaFin = dgvData.Rows[e.RowIndex].Cells["IESS_FECHAFIN"].Value==DBNull.Value ? DateTime.Now : Convert.ToDateTime(dgvData.Rows[e.RowIndex].Cells["IESS_FECHAFIN"].Value);
                DateTime fechaIni = Convert.ToDateTime(dgvData.Rows[e.RowIndex].Cells["IESS_FECHAINICIO"].Value);
                dgvData.Rows[e.RowIndex].Cells["DIAS"].Value = (fechaFin - fechaIni).Days + 1;
                //var dias = (fechaFin - fechaIni).Days;
            }

            dgvData.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dgvData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (!dgvData.Rows[e.RowIndex].IsNewRow)
            {
                string nameColumn = dgvData.Columns[e.ColumnIndex].Name;
                if (nameColumn == "IESS_FECHAINICIO" | nameColumn == "IESS_FECHAFIN")
                {
                    if (!Utility.isDate(e.FormattedValue.ToString()))
                    {
                        dgvData.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo fecha";
                        e.Cancel = true;
                    }
                }
            }
        }

    }
}
