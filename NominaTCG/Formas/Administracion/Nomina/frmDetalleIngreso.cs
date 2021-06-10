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
    public partial class frmDetalleIngreso : Form
    {
        private ContratoController ContratoBO { get; set; }
        private CuentaController CuentaBO { get; set; }
        private Acction respEdit { get; set; }
        private Acction StateButton { get; set; }
        private string empleadoID { get; set; }
        private string periodoID { get; set; }
        private string liquidacionID { get; set; }
        private string reprocesoID { get; set; }
        private int  tipoIng { get; set; }

        #region Methods
        private void TotalSalary()
        {
            double ingreso = 0;
            double egreso = 0;
            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells["Cuenta"].Value != null)
                    {
                        if (row.Cells["Cuenta"].Value.ToString().Contains("Ingreso"))
                            ingreso += row.Cells["ROL_LIQ_VALOR"].Value == DBNull.Value ? 0 : Convert.ToDouble(row.Cells["ROL_LIQ_VALOR"].Value);
                        else
                            egreso += row.Cells["ROL_LIQ_VALOR"].Value == DBNull.Value ? 0 : Convert.ToDouble(row.Cells["ROL_LIQ_VALOR"].Value);
                    }
                }
            }
            txtIngreso.Text = ingreso.ToString();
            txtEgreso.Text = egreso.ToString();
            txtRercibe.Text = (ingreso - egreso).ToString();
        }
        #endregion

        private void ActiveControls(bool stdo)
        {
            ErrProv.Clear();
            foreach (DataGridViewColumn item in dgvDatos.Columns)
            {
                if (item.Name == "ROL_LIQ_VALOR")
                    item.ReadOnly = !stdo;
                else
                    item.ReadOnly = true;

            }
            dgvDatos.AllowUserToAddRows = stdo;

        }

        public frmDetalleIngreso(string empID, string perID, string liqID, Acction stado,int tipo)
        {
            InitializeComponent();
            dgvDatos.AutoGenerateColumns = false;
            ContratoBO = ContratoController.Instancia;
            CuentaBO = CuentaController.Instancia;
            StateButton = Acction.Save;
            respEdit = stado;
            empleadoID = empID;
            periodoID = perID;
            liquidacionID = liqID;
            tipoIng = tipo;
            reprocesoID = ContratoBO.GetReproceso(empID, perID).ToString();
            dgvDatos.DataSource = ContratoBO.DetalleIngreso(empleadoID, periodoID, reprocesoID, tipoIng);
            TotalSalary();

        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (respEdit.Equals(Acction.Edit))
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
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (respEdit.Equals(Acction.Edit))
            {
                if ((dgvDatos.Columns[e.ColumnIndex].GetType()).ToString() == "System.Windows.Forms.DataGridViewButtonColumn")
                {
                    if (StateButton.Equals(Acction.Edit))
                    {
                        CuentaBO.Cuenta = new db.RolEntity();
                        var frm = new frmListaCuenta(tipoIng);
                        Design.frmDialog(frm, "Cuentas");

                        if (CuentaBO.Cuenta.Cuenta != null)
                        {
                            foreach (DataGridViewRow row in dgvDatos.Rows)
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
                            dgvDatos.Rows[e.RowIndex].Cells["ROL_ID"].Value = Convert.ToInt32(CuentaBO.Cuenta.CuentaID);
                            dgvDatos.Rows[e.RowIndex].Cells["Cuenta"].Value = CuentaBO.Cuenta.Cuenta;
                        }
                    }
                }
            }
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (btnNewSave.Text.Equals("&Guardar"))
            {
                StateButton = Acction.Save;
                DataTable datos = (DataTable)dgvDatos.DataSource;
                DataTable getDataMod = datos.GetChanges(DataRowState.Modified);
                DataTable getDataAdd = datos.GetChanges(DataRowState.Added);
                DataTable getDataDel = datos.GetChanges(DataRowState.Deleted);

                if (getDataAdd != null | getDataMod != null | getDataDel != null)
                {
                    if (Utility.MensajeQuestion("¿Está seguro que desea registrar los cambios?") == System.Windows.Forms.DialogResult.Yes)
                    {
                        int ban = 0;
                        List<db.DatDetRolLiq> datosIngreso;
                        if (getDataMod != null)
                        {
                            ban++;
                            datosIngreso = new List<db.DatDetRolLiq>();
                            foreach (DataRow row in getDataMod.Rows)
                            {
                                db.DatDetRolLiq liq = new db.DatDetRolLiq();
                                liq.empId = Convert.ToInt64(row["EMP_ID"]);
                                liq.rolLiqFecReg = DateTime.Now;
                                liq.rolId = Convert.ToInt64(row["ROL_ID"]); 
                                liq.rolIdOrg = Convert.ToInt64(row["ROL_ID", DataRowVersion.Original]); 
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
                            ban++;
                            datosIngreso = new List<db.DatDetRolLiq>();
                            foreach (DataRow row in getDataAdd.Rows)
                            {
                                db.DatDetRolLiq liq = new db.DatDetRolLiq();
                                liq.empId = Convert.ToInt64(empleadoID);
                                liq.rolLiqFecReg = DateTime.Now;
                                liq.rolId = Convert.ToInt64(row["ROL_ID"]);
                                //liq.rolLiqId = Convert.ToInt64(row["ROL_LIQ_ID"]);
                                liq.rolLiqValor = Convert.ToDecimal(row["ROL_LIQ_VALOR"]);
                                liq.segRolId = Convert.ToInt32(periodoID);
                                liq.segRolRepro = Convert.ToInt16(reprocesoID);
                                datosIngreso.Add(liq);
                            }
                            ContratoBO.RegistraDetalleIngreso(datosIngreso);
                        }

                        if (getDataDel != null)
                        {
                            ban++;
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
                        double sueldo=0;
                        foreach (DataGridViewRow row in dgvDatos.Rows)
                        {
                            if (row.Cells["ROL_ID"].Value != null)
                            {
                                if (10300 == Convert.ToInt16((row.Cells["ROL_ID"]).FormattedValue))
                                {
                                    sueldo = Convert.ToDouble((row.Cells["ROL_LIQ_VALOR"]).FormattedValue);
                                }
                            }

                        }

                            if (ban > 0 & tipoIng.Equals(1) & sueldo > 0)
                        {
                            db.DatDetRolLiq liq = new db.DatDetRolLiq();
                            liq.empId = Convert.ToInt64(dgvDatos.Rows[0].Cells["EMP_ID"].Value.ToString());
                            liq.segRolId = Convert.ToInt32(dgvDatos.Rows[0].Cells["SEG_ROL_ID"].Value.ToString());
                            liq.segRolRepro = Convert.ToInt32(dgvDatos.Rows[0].Cells["SEG_ROL_REPRO"].Value.ToString());
                            ContratoBO.RevDetalleIngreso(liq);
                        }
                        else
                        {
                            ContratoBO.ActualizaDetalleIngreso(empleadoID, liquidacionID, Convert.ToDecimal(txtIngreso.Text), Convert.ToDecimal(txtEgreso.Text), tipoIng);
                        }

                        dgvDatos.DataSource = ContratoBO.DetalleIngreso(empleadoID, periodoID, reprocesoID, tipoIng);
                        TotalSalary();
                        Utility.MensajeOK("Información Reagistrada..!!");
                    }

                    //if (Utility.MensajeQuestion("¿Está seguro que desea registrar los cambios?") == System.Windows.Forms.DialogResult.Yes)
                    //{
                    //    //ContratoBO.RevLiquidacion(empleadoID);
                    //    List<db.DatDetRolLiq> datosIngreso;
                    //    datosIngreso = new List<db.DatDetRolLiq>();

                    //    foreach (DataGridViewRow dgvRenglon in dgvDatos.Rows)
                    //    {

                    //        if (dgvRenglon.Cells["EMP_ID"].Value != null)
                    //        {
                    //            db.DatDetRolLiq liq = new db.DatDetRolLiq();
                    //            liq.empId = Convert.ToInt64(dgvRenglon.Cells["EMP_ID"].Value.ToString());                                
                    //            liq.rolId = Convert.ToInt64(dgvRenglon.Cells["ROL_ID"].Value.ToString());                                
                    //            liq.rolLiqValor = Convert.ToDecimal(dgvRenglon.Cells["ROL_LIQ_VALOR"].Value.ToString());
                    //            liq.segRolId = Convert.ToInt32(dgvRenglon.Cells["SEG_ROL_ID"].Value.ToString());
                    //            liq.segRolRepro = Convert.ToInt32(dgvRenglon.Cells["SEG_ROL_REPRO"].Value.ToString());
                    //            datosIngreso.Add(liq);
                    //        }
                    //    }
                    //    ContratoBO.ActualizaDetalleIngreso

                    //    Utility.MensajeOK("Información Reagistrada..!!");
                    //}
                }


                ActiveControls(false);
                Design.ControlsSave(this.btnEditCancel, this.btnNewSave);
            }
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string nameColumn = dgvDatos.Columns[e.ColumnIndex].Name;
            if (nameColumn == "ROL_LIQ_VALOR" | nameColumn == "Cuenta")
            {
                TotalSalary();
            }
            dgvDatos.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void frmDetalleIngreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //_instancia = null;
            this.Close();
        }

        private void frmDetalleIngreso_Load(object sender, EventArgs e)
        {
            ActiveControls(false);
            btnEditCancel_Click(sender, e);
        }       

        private void dgvDatos_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            TotalSalary();
        }
    }
}
