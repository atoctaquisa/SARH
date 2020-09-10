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
    public partial class frmCalcularLiquidacion : Form
    {

        private EmpleadoController EmpleadoBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        private Acction StateButton { get; set; }
        #region Methods
        private void ActiveControls(bool stdo)
        {
            ErrProv.Clear();
            btnSearch.Enabled = !stdo;
            txtObservacion.Enabled = stdo;
            foreach (DataGridViewColumn item in dgvDataDT.Columns)
            {
                if (item.Name == "DET_LIQ_VALOR" | item.Name == "btnDetalle" | item.Name == "DET_LIQ_OBS")
                    item.ReadOnly = !stdo;
                else
                    item.ReadOnly = true;
            }
        }
        private void TotalSalary()
        {
            double ingreso = 0;
            double egreso = 0;
            foreach (DataGridViewRow row in dgvDataDT.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells["RUB_LIQ_ID"].Value != null)
                    {
                        if (Convert.ToInt16(row.Cells["RUB_LIQ_ID"].Value) <= 4 | Convert.ToInt16(row.Cells["RUB_LIQ_ID"].Value) >= 6)
                            ingreso += row.Cells["DET_LIQ_VALOR"].Value == DBNull.Value ? 0 : Convert.ToDouble(row.Cells["DET_LIQ_VALOR"].Value);
                        else
                            egreso += row.Cells["DET_LIQ_VALOR"].Value == DBNull.Value ? 0 : Convert.ToDouble(row.Cells["DET_LIQ_VALOR"].Value);
                    }
                }
            }
            txtIngreso.Text = ingreso.ToString();
            txtEgreso.Text = egreso.ToString();
            txtRercibe.Text = (ingreso - egreso).ToString();
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
                txtFechaSalida.Text = info.Rows[0]["EMP_FEC_SALIDA"].ToString().Equals("") ? "No Asignada" : Convert.ToDateTime(info.Rows[0]["EMP_FEC_SALIDA"].ToString()).ToShortDateString();
                txtFechaContrato.Text = Convert.ToDateTime(info.Rows[0]["EMP_CON_FEC_CONTRATO"].ToString()).ToShortDateString();
                txtTipo.Text = info.Rows[0]["LAB_TIPO_EMP"].ToString() == "0" ? "Nomina" : info.Rows[0]["LAB_TIPO_EMP"].ToString() == "1" ? "Serv. Prof" : "Desconocido";
                DataTable infLQ = ContratoBO.FinContratoEmpleado(txtCodigo.Text);
                txtRazon.Text = infLQ.Rows[0]["RAZON"].ToString();
                txtCausa.Text = infLQ.Rows[0]["CAUSA"].ToString();
                txtContrato.Text = info.Rows[0]["TIPO_CONTRATO"].ToString();
                txtObservacion.Text = infLQ.Rows[0]["EMP_CON_OBS"].ToString();
                lblEstadoRol.Text = infLQ.Rows[0]["EMP_CON_ID"].ToString();
                AssignDataDT();

                //ClearControls("S");
            }
        }

        private void AssignDataDT()
        {
            dgvData.DataSource = ContratoBO.LiquidacionEmpleado(txtCodigo.Text);
            if (((DataTable)dgvData.DataSource).Rows.Count > 0)
            {
                txtAsiento.Text = dgvData.Rows[0].Cells["DIA_ID"].Value.ToString();
                dgvDataDT.DataSource = ContratoBO.LiquidacionEmpleadoDT(txtCodigo.Text, dgvData.Rows[0].Cells["LIQ_ID"].Value.ToString());
                TotalSalary();
            }
            else
                dgvDataDT.DataSource = null;
        }
        #endregion

        #region Instancia / Constructor
        private static frmCalcularLiquidacion _instancia;
        public static frmCalcularLiquidacion Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmCalcularLiquidacion();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmCalcularLiquidacion()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            ContratoBO = ContratoController.Instancia;
            dgvData.AutoGenerateColumns = false;
            dgvDataDT.AutoGenerateColumns = false;
            dgvData.AllowUserToAddRows = false;
            dgvDataDT.AllowUserToAddRows = false;
            StateButton = Acction.Cancel;
            ActiveControls(false);
        }

        #endregion

        private void frmCalcularLiquidacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var frm = new frmEmpleadoLista();
            frm.ShowDialog();
            AssignData(EmpleadoBO.Empleado.empId.ToString());
        }

        private void dgvDataDT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if ((dgvDataDT.Columns[e.ColumnIndex].GetType()).ToString() == "System.Windows.Forms.DataGridViewButtonColumn")
            {
                //if (StateButton.Equals(Acction.Edit))
                //{

                int tipo = Convert.ToInt16(dgvDataDT.Rows[e.RowIndex].Cells["RUB_LIQ_ID"].Value);

                if (tipo.Equals(1))
                {
                    var frm = new frmDetalleIngreso(txtCodigo.Text, dgvDataDT.Rows[e.RowIndex].Cells["DET_LIQ_REF"].Value.ToString(), dgvDataDT.Rows[e.RowIndex].Cells["LIQ_ID_DT"].Value.ToString(), StateButton);
                    Design.frmDialog(frm, txtNombre.Text);
                    AssignDataDT();

                }
                if (tipo.Equals(2) | tipo.Equals(6))
                {
                    var frm = new frmDetalleDecimoTercero(txtCodigo.Text, dgvDataDT.Rows[e.RowIndex].Cells["DET_LIQ_REF"].Value.ToString());
                    Design.frmDialog(frm, txtNombre.Text);
                }
                if (tipo.Equals(3) | tipo.Equals(7))
                {
                    //var frm = new frmDetalleDecimoTercero();
                    //frm.ShowDialog(this);
                }
                if (tipo.Equals(4) | tipo.Equals(8))
                {
                    var frm = new frmDetalleVacacion(txtCodigo.Text, dgvDataDT.Rows[e.RowIndex].Cells["DET_LIQ_REF"].Value.ToString());
                    Design.frmDialog(frm, txtNombre.Text);
                }
                if (tipo.Equals(5))
                {
                    var frm = new frmDetalleIngreso(txtCodigo.Text, dgvDataDT.Rows[e.RowIndex].Cells["DET_LIQ_REF"].Value.ToString(), dgvDataDT.Rows[e.RowIndex].Cells["LIQ_ID_DT"].Value.ToString(), StateButton);
                    Design.frmDialog(frm, txtNombre.Text);
                    AssignDataDT();
                }
                //}
            }
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (StateButton.Equals(Acction.Cancel) | StateButton.Equals(Acction.Save))
            {
                ActiveControls(true);
                StateButton = Acction.Edit;
            }
            else
            {
                ActiveControls(false);
                StateButton = Acction.Cancel;
            }

            Design.ControlsEdit(this.btnEditCancel, this.btnNewSave);
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            StateButton = Acction.Save;
            ContratoBO.FinContratoEmpleado(txtCodigo.Text, txtObservacion.Text, lblEstadoRol.Text);
            DataTable datos = (DataTable)dgvDataDT.DataSource;
            DataTable getDataMod = datos.GetChanges(DataRowState.Modified);
            if (getDataMod != null)
            {

                foreach (DataRow row in getDataMod.Rows)
                {
                    db.DatDetLiq campo = new db.DatDetLiq();
                    campo.empId = Convert.ToInt64(txtCodigo.Text);
                    campo.liqId = Convert.ToInt32(row["LIQ_ID"]);
                    campo.rubLiqId = Convert.ToInt32(row["RUB_LIQ_ID"]);
                    campo.detLiqRef = Convert.ToInt32(row["DET_LIQ_REF"]);
                    campo.detLiqValor = Convert.ToDecimal(row["DET_LIQ_VALOR"]);
                    campo.detLiqObs = row["DET_LIQ_OBS"].ToString();
                    ContratoBO.FinContratoEmpleadoDT(campo);
                }
            }
            AssignData(txtCodigo.Text);
            ActiveControls(false);
            Design.ControlsSave(this.btnEditCancel, this.btnNewSave);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!Utility.isDate(txtFechaSalida.Text))
            {
                ErrProv.SetError(txtFechaSalida, "El empleado debe tener una fecha de salida");
            }
            else
            {                
                if (ContratoBO.ValidaLiquidacion(txtCodigo.Text, txtFechaContrato.Text) == 0)
                {
                    //int esMotorista= ContratoBO.EmpleadoEsMotorista(txtCodigo.Text);
                    string tipoContrato = ContratoBO.TipoContrato(txtCodigo.Text);
                    //int esContratoHoraGeneral = ContratoBO.ContratoHoraGeneral(txtCodigo.Text);

                    if (Utility.MensajeQuestion("¿Desea calcular la liquidación para este empleado?'") == DialogResult.Yes)
                    {
                        int provID = 1;
                        if (tipoContrato.Contains("HORA") & tipoContrato.Contains("GENE"))
                        {
                            if (Utility.MensajeQuestion("¿Desea Pagar Provisiones?'") != DialogResult.OK)
                            {
                                provID = 0;
                            }
                        }
                        ContratoBO.CalculaLiquidacion(txtCodigo.Text, rbtSi.Checked == true ? 1 : 2, provID);
                        AssignData(txtCodigo.Text);
                    }

                }
                else
                    Utility.MensajeInfo("La liquidación para este empleado ya fué calculada");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ////rpt.SetDataSource(ReportBO.Liquidacion("200612315233", "590"));
            ////cryLiquidacion.ReportSource = rpt;
            //frmLiquidacionRep frm = new frmLiquidacionRep("200612315233", "590");
            //Design.frmDialog(frm,"Reporte de Liquidación");
            if (!txtCodigo.Text.Equals(string.Empty))
            {
                foreach (DataGridViewCell item in dgvData.SelectedCells)
                {
                    if (item.Selected)
                    {
                        string liqID = dgvData.Rows[item.RowIndex].Cells["LIQ_ID"].Value.ToString();
                        frmLiquidacionRep frm = new frmLiquidacionRep(txtCodigo.Text, liqID);
                        Design.frmDialog(frm, "Reporte de Liquidación");
                    }
                }
            }

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            ContratoBO.GeneraAsientoLiquidacion(txtCodigo.Text);
        }

        private void txtAsiento_DoubleClick(object sender, EventArgs e)
        {
            if (!txtAsiento.Text.Equals(string.Empty))
            {
                frmAsiento frm = new frmAsiento(txtAsiento.Text, dgvData.Rows[0].Cells["CLI_ID"].Value.ToString(), dgvData.Rows[0].Cells["PERC_ID"].Value.ToString(), "1");
                Design.frmDialog(frm, "Asiento Nómina");
            }
        }

        private void dgvDataDT_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string nameColumn = dgvDataDT.Columns[e.ColumnIndex].Name;
            if (nameColumn == "DET_LIQ_VALOR")
            {
                TotalSalary();
            }
            dgvDataDT.Rows[e.RowIndex].ErrorText = String.Empty;
        }        
    }
}