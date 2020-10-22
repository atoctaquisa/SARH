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
using CrystalDecisions.CrystalReports.Engine;
using System.Text.RegularExpressions;

namespace NominaTCG
{
    public partial class frmAsiento : Form
    {
        private string _diaID;
        private string _cliID;
        private string _percID;
        private string _patID;
        private ContratoController ContratoBO { get; set; }
        private CuentaController CuentaBO { get; set; }
        private Acction StateButton { get; set; }
        #region Methods

        private void ActiveControls(bool stdo)
        {
            ErrProv.Clear();
            foreach (DataGridViewColumn item in dgvData.Columns)
            {
                if (item.Name == "ROL_LIQ_VALOR")
                    item.ReadOnly = !stdo;
                else
                    item.ReadOnly = true;

            }
            dgvData.AllowUserToAddRows = stdo;

        }

        private void TotalSalary()
        {
            double ingreso = 0;
            double egreso = 0;
            double diferencia = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells["Cuenta"].Value != null)
                    {
                        ingreso += row.Cells["DEBE"].Value == DBNull.Value ? 0 : Convert.ToDouble(row.Cells["DEBE"].Value);
                        egreso += row.Cells["HABER"].Value == DBNull.Value ? 0 : Convert.ToDouble(row.Cells["HABER"].Value);
                    }
                }
            }
            txtIngreso.Text = ingreso.ToString();
            txtEgreso.Text = egreso.ToString();
            diferencia = Math.Round(ingreso - egreso, 2);
            txtRercibe.Text = diferencia.ToString();
        }
        #endregion
        public frmAsiento(string diaID, string cliID, string percID, string patID)
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            dgvData.AllowUserToAddRows = false;
            ContratoBO = ContratoController.Instancia;
            CuentaBO = CuentaController.Instancia;
            _diaID = diaID;
            _cliID = cliID;
            _percID = percID;
            _patID = patID;
            DataSet datos = ContratoBO.AsientoLiquidacion(_diaID, _cliID, _percID, _patID);
            if (datos.Tables[0].Rows.Count > 0)
            {
                txtDiario.Text = datos.Tables[0].Rows[0]["DIA_ID"].ToString();
                txtFecha.Text = datos.Tables[0].Rows[0]["DIA_FEC_DIARIO"].ToString();
                txtTipo.Text = datos.Tables[0].Rows[0]["TIPO"].ToString();
                txtNombre.Text = datos.Tables[0].Rows[0]["NOMBRE"].ToString();
                txtLugar.Text = datos.Tables[0].Rows[0]["LOCAL"].ToString();
                txtObservacion.Text = datos.Tables[0].Rows[0]["DIA_OBS"].ToString();
                txtPeriodo.Text = datos.Tables[0].Rows[0]["PERIODO"].ToString();
                txtDia.Text = datos.Tables[0].Rows[0]["DIA_DIA"].ToString();
                txtEstado.Text = datos.Tables[0].Rows[0]["ESTADO"].ToString();
                txtFechaReg.Text = datos.Tables[0].Rows[0]["DIA_FEC_REG"].ToString();
                txtUsuarioReg.Text = datos.Tables[0].Rows[0]["DIA_RESP"].ToString();
                txtFechaMod.Text = datos.Tables[0].Rows[0]["DIA_FEC_MOD"].ToString();
                txtUsuarioMod.Text = datos.Tables[0].Rows[0]["USU_MODIF"].ToString();
                dgvData.DataSource = datos.Tables[1];
                TotalSalary();
            }

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (!txtEstado.Text.Equals("Procesado"))
            {
                if (txtRercibe.Text.Equals("0"))
                {
                    if (ContratoBO.VerificaPeridoDiario(_percID).Equals(0))
                    {
                        if (Utility.MensajeQuestion("¿Está seguro de querer procesar?") == DialogResult.Yes)
                        {
                            ContratoBO.ProcesaDiario(_percID, _diaID);
                        }
                    }
                    else
                        Utility.MensajeError("El período para esta fecha ya esta cerrado");
                }
            }
            else
                Utility.MensajeInfo("Este diario ya fue procesado");
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {

            if (btnEditCancel.Text.Equals("&Editar"))
            {
                StateButton = Acction.Edit;
                ActiveControls(true);
            }
            else
            {
                StateButton = Acction.Cancel;
                ActiveControls(false);
            }

            Design.ControlsEdit(this.btnEditCancel, this.btnNewSave);

        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (btnNewSave.Text.Equals("&Guardar"))
            {
                StateButton = Acction.Save;
                DataTable datos = (DataTable)dgvData.DataSource;
                DataTable getDataMod = datos.GetChanges(DataRowState.Modified);
                DataTable getDataAdd = datos.GetChanges(DataRowState.Added);
                DataTable getDataDel = datos.GetChanges(DataRowState.Deleted);

                if (getDataAdd != null | getDataMod != null | getDataDel != null)
                {
                    if (Utility.MensajeQuestion("¿Está seguro que desea registrar los cambios?") == System.Windows.Forms.DialogResult.Yes)
                    {
                        List<db.DatDetRolLiq> datosIngreso;
                        if (getDataMod != null)
                        {
                            datosIngreso = new List<db.DatDetRolLiq>();
                            foreach (DataRow row in getDataMod.Rows)
                            {
                                db.DatDetRolLiq liq = new db.DatDetRolLiq();
                                liq.empId = Convert.ToInt64(row["EMP_ID"]);
                                liq.rolLiqFecReg = DateTime.Now;
                                liq.rolId = Convert.ToInt64(row["ROL_ID"]);
                                liq.rolLiqId = Convert.ToInt64(row["ROL_LIQ_ID"]);
                                liq.rolLiqValor = Convert.ToDecimal(row["ROL_LIQ_VALOR"]);
                                liq.segRolId = Convert.ToInt32(row["SEG_ROL_ID"]);
                                liq.segRolRepro = Convert.ToInt32(row["SEG_ROL_REPRO"]);
                                datosIngreso.Add(liq);

                            }
                            ContratoBO.ActualizaDetalleIngreso(datosIngreso);
                        }

                        if (getDataAdd != null)
                        {
                            datosIngreso = new List<db.DatDetRolLiq>();
                            foreach (DataRow row in getDataAdd.Rows)
                            {
                                db.DatDetRolLiq liq = new db.DatDetRolLiq();
                                //liq.empId = Convert.ToInt64(empleadoID);
                                //liq.rolLiqFecReg = DateTime.Now;
                                //liq.rolId = Convert.ToInt64(row["ROL_ID"]);
                                ////liq.rolLiqId = Convert.ToInt64(row["ROL_LIQ_ID"]);
                                //liq.rolLiqValor = Convert.ToDecimal(row["ROL_LIQ_VALOR"]);
                                //liq.segRolId = Convert.ToInt32(periodoID);
                                //liq.segRolRepro = Convert.ToInt16(reprocesoID);
                                datosIngreso.Add(liq);
                            }
                            ContratoBO.RegistraDetalleIngreso(datosIngreso);
                        }

                        if (getDataDel != null)
                        {
                            datosIngreso = new List<db.DatDetRolLiq>();
                            foreach (DataRow row in getDataDel.Rows)
                            {
                                db.DatDetRolLiq liq = new db.DatDetRolLiq();
                                liq.empId = Convert.ToInt64(row["EMP_ID", DataRowVersion.Original]);
                                liq.rolLiqFecReg = DateTime.Now;
                                liq.rolId = Convert.ToInt64(row["ROL_ID", DataRowVersion.Original]);
                                liq.rolLiqId = Convert.ToInt64(row["ROL_LIQ_ID", DataRowVersion.Original]);
                                liq.rolLiqValor = Convert.ToDecimal(row["ROL_LIQ_VALOR", DataRowVersion.Original]);
                                liq.segRolId = Convert.ToInt32(row["SEG_ROL_ID", DataRowVersion.Original]);
                                liq.segRolRepro = Convert.ToInt32(row["SEG_ROL_REPRO", DataRowVersion.Original]);
                                datosIngreso.Add(liq);
                            }
                            ContratoBO.EliminaDetalleIngreso(datosIngreso);
                        }
                        //ContratoBO.ActualizaDetalleIngreso(empleadoID, liquidacionID, Convert.ToDecimal(txtIngreso.Text), Convert.ToDecimal(txtEgreso.Text));
                        //dgvData.DataSource = ContratoBO.DetalleIngreso(empleadoID, periodoID, reprocesoID);
                        Utility.MensajeOK("Información Reagistrada..!!");
                    }
                }


                ActiveControls(false);
                Design.ControlsSave(this.btnEditCancel, this.btnNewSave);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //_instancia = null;
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!txtDiario.Text.Equals(string.Empty) & !_cliID.Equals(string.Empty))
            {
                //rptAsientoLiquidacion asiento = new rptAsientoLiquidacion();                
                //asiento.SetDataSource(dgvData.DataSource);
                ReportDocument document = new ReportDocument();
                document.Load(@"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\rptAsientoLiquidacion.rpt");
                DataSet datos = ContratoBO.AsientoLiquidacion(_diaID, _cliID, _percID, _patID);
                document.SetDataSource(datos.Tables[1]);
                document.SetParameterValue("P_EMPRESA", datos.Tables[0].Rows[0]["PATRONO"].ToString());
                document.SetParameterValue("P_PERIODO", txtPeriodo.Text);
                document.SetParameterValue("P_FECHA", txtFecha.Text);
                document.SetParameterValue("P_OBSERVACION", txtObservacion.Text);
                document.SetParameterValue("P_CI", Regex.Replace(txtObservacion.Text, @"\D", ""));
                document.SetParameterValue("P_DIARIO", txtDiario.Text);
                document.SetParameterValue("P_ESTADO", txtEstado.Text);





                frmView frm = new frmView(document);
                frm.Show();//Design.frmDialog(frm,"Reporte");
                //frmLiquidacionRep frm = new frmLiquidacionRep(_cliID, txtDia.Text);
                //Design.frmDialog(frm, "Impresión de Asiento");
            }
            else
                Utility.MensajeInfo("Primero debe procesar el diario");
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string nameColumn = dgvData.Columns[e.ColumnIndex].Name;
            if (nameColumn == "DEBE" | nameColumn == "HABER")
            {
                TotalSalary();
            }
            dgvData.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if ((dgvData.Columns[e.ColumnIndex].GetType()).ToString() == "System.Windows.Forms.DataGridViewButtonColumn")
            {
                if (StateButton.Equals(Acction.Edit))
                {
                    CuentaBO.Cuenta = new db.RolEntity();
                    var frm = new frmListaCuentaAsiento();
                    Design.frmDialog(frm, "Cuentas");

                    if (CuentaBO.Cuenta.Cuenta != null)
                    {
                        foreach (DataGridViewRow row in dgvData.Rows)
                        {
                            if (row.Index != e.RowIndex && row.Cells["Cuenta"].Value != null)
                            {
                                if (CuentaBO.Cuenta.Cuenta == (row.Cells["Cuenta"]).FormattedValue.ToString())
                                {
                                    Utility.MensajeInfo("Error..!! Ya se encuentra adicionada esta cuenta");
                                    return;
                                }
                            }
                        }
                        dgvData.Rows[e.RowIndex].Cells["Cuenta"].Value = Convert.ToInt32(CuentaBO.Cuenta.CuentaID);
                        dgvData.Rows[e.RowIndex].Cells["Nombre"].Value = CuentaBO.Cuenta.Cuenta;
                    }
                }
            }
        }
    }
}
