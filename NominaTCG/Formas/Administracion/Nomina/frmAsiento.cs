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
        private LocalController LocalBO { get; set; }

        private Acction StateButton { get; set; }
        #region Methods

        private void ActiveControls(bool stdo)
        {
            ErrProv.Clear();
            foreach (DataGridViewColumn item in dgvData.Columns)
            {
                if (item.Name == "DEBE" | item.Name == "HABER")
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
            LocalBO = LocalController.Instancia;
            _diaID = diaID;
            _cliID = cliID;
            _percID = percID;
            _patID = patID;
            LoadData();
        }

        private void LoadData()
        {
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
                if (txtEstado.Text.Equals("Procesado"))
                {
                    Utility.MensajeInfo("No se puede realizar ninguana modificación");
                    return;
                }

                StateButton = Acction.Edit;
                ActiveControls(true);
            }
            else
            {
                StateButton = Acction.Cancel;
                LoadData();
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
                        List<db.DatDetDiario> diarioDT;
                        if (getDataMod != null)
                        {
                            diarioDT = new List<db.DatDetDiario>();
                            foreach (DataRow row in getDataMod.Rows)
                            {
                                db.DatDetDiario dat = new db.DatDetDiario();
                                dat.cueId = Convert.ToInt64(row["CUE_ID"]);
                                dat.cueId_ = Convert.ToInt64(row["CUE_ID", DataRowVersion.Original]);
                                dat.percId = Convert.ToInt64(_percID) ;
                                dat.diaId = Convert.ToInt64(_diaID);
                                dat.cliId = Convert.ToInt32(row["CLI_ID"]);
                                dat.cliId_ = Convert.ToInt32(row["CLI_ID",DataRowVersion.Original]);
                                dat.detDiaDb = row["DET_DIA_DB"] == DBNull.Value ? 0 : Convert.ToDecimal(row["DET_DIA_DB"]);
                                dat.detDiaHb = row["DET_DIA_HB"] == DBNull.Value ? 0 : Convert.ToDecimal(row["DET_DIA_HB"]);
                                //dat.detDiaFecReg 
                                //dat.detDiaFecMod                                
                                dat.detDiaCliSeg = Convert.ToInt64(_cliID); 
                                dat.patId = Convert.ToInt64(_patID);
                                dat.detId = Convert.ToInt64(row["DET_ID"]);
                                //dat.ordImp
                                //dat.usuCrea
                                dat.usuModif = Catalogo.UserName;
                                //dat.anioPerc
                                dat.detObser = txtObservacion.Text;
                                diarioDT.Add(dat);
                            }
                            ContratoBO.ActualizaDetalleDiario(diarioDT,"U");
                        }

                        if (getDataAdd != null)
                        {
                            diarioDT = new List<db.DatDetDiario>();
                            foreach (DataRow row in getDataAdd.Rows)
                            {
                                db.DatDetDiario dat = new db.DatDetDiario();
                                dat.cueId = Convert.ToInt64(row["CUE_ID"]);
                                //dat.cueId_ = Convert.ToInt64(row["CUE_ID", DataRowVersion.Original]);
                                dat.percId = Convert.ToInt64(_percID);
                                dat.diaId = Convert.ToInt64(_diaID);
                                dat.cliId = Convert.ToInt32(row["CLI_ID"]);
                                //dat.cliId_ = Convert.ToInt32(row["CLI_ID", DataRowVersion.Original]);
                                dat.detDiaDb = row["DET_DIA_DB"]== DBNull.Value ? 0 : Convert.ToDecimal(row["DET_DIA_DB"]);
                                dat.detDiaHb = row["DET_DIA_HB"] == DBNull.Value ? 0 : Convert.ToDecimal(row["DET_DIA_HB"]);
                                //dat.detDiaFecReg 
                                //dat.detDiaFecMod                                
                                dat.detDiaCliSeg = Convert.ToInt64(_cliID);
                                dat.patId = Convert.ToInt64(_patID);
                                //dat.detId = Convert.ToInt64(row["DET_ID"]);
                                //dat.ordImp
                                dat.usuCrea = Catalogo.UserName;
                                //dat.usuModif = Catalogo.UserName;
                                //dat.anioPerc
                                dat.detObser = txtObservacion.Text;
                                diarioDT.Add(dat);
                            }
                            ContratoBO.ActualizaDetalleDiario(diarioDT,"I");
                        }

                        if (getDataDel != null)
                        {
                            diarioDT = new List<db.DatDetDiario>();
                            foreach (DataRow row in getDataDel.Rows)
                            {
                                db.DatDetDiario dat = new db.DatDetDiario();                                
                                dat.cueId = Convert.ToInt64(row["CUE_ID", DataRowVersion.Original]);
                                dat.percId = Convert.ToInt64(_percID);
                                dat.diaId = Convert.ToInt64(_diaID);                                
                                dat.cliId = Convert.ToInt32(row["CLI_ID", DataRowVersion.Original]);                                
                                dat.patId = Convert.ToInt64(_patID);
                                dat.detId = Convert.ToInt64(row["DET_ID", DataRowVersion.Original]);                               
                                diarioDT.Add(dat);
                            }
                            ContratoBO.ActualizaDetalleDiario(diarioDT,"D");
                        }
                        //ContratoBO.ActualizaDetalleIngreso(empleadoID, liquidacionID, Convert.ToDecimal(txtIngreso.Text), Convert.ToDecimal(txtEgreso.Text));
                        //dgvData.DataSource = ContratoBO.DetalleIngreso(empleadoID, periodoID, reprocesoID);
                        LoadData();
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
                NominaTCG.Formas.Reportes.rptAsientoLiquidacion rpt = new NominaTCG.Formas.Reportes.rptAsientoLiquidacion();
                //asiento.SetDataSource(dgvData.DataSource);
                //ReportDocument document = new ReportDocument();
                //document.Load(@"C:\Users\Alvaro\Documents\Visual Studio 2013\Projects\NominaTCG\NominaTCG\rptAsientoLiquidacion.rpt");
                DataSet datos = ContratoBO.AsientoLiquidacion(_diaID, _cliID, _percID, _patID);
                rpt.SetDataSource(datos.Tables[1]);
                rpt.SetParameterValue("P_EMPRESA", datos.Tables[0].Rows[0]["PATRONO"].ToString());
                rpt.SetParameterValue("P_PERIODO", txtPeriodo.Text);
                rpt.SetParameterValue("P_FECHA", txtFecha.Text);
                rpt.SetParameterValue("P_OBSERVACION", txtObservacion.Text);
                rpt.SetParameterValue("P_CI", Regex.Replace(txtObservacion.Text, @"\D", ""));
                rpt.SetParameterValue("P_DIARIO", txtDiario.Text);
                rpt.SetParameterValue("P_ESTADO", txtEstado.Text);
                frmView frm = new frmView(rpt);
                frm.Show();//Design.frmDialog(frm,"Reporte");
                //frmLiquidacionRep frm = new frmLiquidacionRep(_cliID, txtDia.Text);
                //Design.frmDialog(frm, "Impresión de Asiento");
            }
            else
                Utility.MensajeInfo("Primero debe procesar el diario");
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvData.Rows[e.RowIndex].ErrorText = string.Empty;
            //int index = dgvData.CurrentCell.ColumnIndex;
            //if (dgvData.Columns[index].Name == "DEBE"| dgvData.Columns[index].Name == "HABER")
            //{
            //    dText.KeyPress -= new KeyPressEventHandler(dText_KeyPress);
            //}

            string nameColumn = dgvData.Columns[e.ColumnIndex].Name;
            if (nameColumn == "DEBE" | nameColumn == "HABER")
            {
                dText.KeyPress -= new KeyPressEventHandler(dText_KeyPress);
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

                    if (dgvData.Columns[e.ColumnIndex].Name.Equals("LOCAL_ID"))
                    {
                        LocalBO.Local = new db.LocalEntity();
                        var frmC = new frmClienteLista();
                        Design.frmDialog(frmC, "Local");
                        if (LocalBO.Local.Nombre != null)
                        {
                            dgvData.Rows[e.RowIndex].Cells["LOCAL"].Value = LocalBO.Local.Nombre;
                            dgvData.Rows[e.RowIndex].Cells["CLI_ID"].Value = LocalBO.Local.LocalID;
                        }
                    }
                    else
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
                            dgvData.Rows[e.RowIndex].Cells["Cuenta"].Value = Convert.ToInt64(CuentaBO.Cuenta.CuentaID);
                            dgvData.Rows[e.RowIndex].Cells["Nombre"].Value = CuentaBO.Cuenta.Cuenta;
                        }
                    }

                    
                }
            }
        }

        void dText_KeyPress(object sender, KeyPressEventArgs e)
        {
            int index = dgvData.CurrentCell.ColumnIndex;
            if (dgvData.Columns[index].Name == "HABER" | dgvData.Columns[index].Name == "DEBE")
            {
                TextBox txt = (TextBox)sender;
                Utility.OnlyQuantity(txt, e);
            }
        }
        DataGridViewTextBoxEditingControl dText;
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType().Name.Equals("DataGridViewTextBoxEditingControl"))
            {
                dText = (DataGridViewTextBoxEditingControl)e.Control;
                dText.KeyPress += new KeyPressEventHandler(dText_KeyPress);
            }
        }
    }
}
