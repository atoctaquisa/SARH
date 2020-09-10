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
    public partial class frmDeduccionGastos : Form
    {
        private EmpleadoController EmpleadoBO { get; set; }
        private int? patID { get; set; }

        #region Methods
        private bool ValidaDatos()
        {
            int ban = 1;
            foreach (DataGridViewRow item in dgvData.Rows)
            {
                if (!item.IsNewRow)
                {
                    if (!item.Cells["PROY_VALOR"].Value.Equals(DBNull.Value))
                    {
                        decimal valor = Convert.ToDecimal(item.Cells["PROY_VALOR"].Value);
                        decimal valorMax = Convert.ToDecimal(item.Cells["PROY_LIM"].Value);
                        decimal valorMin = Convert.ToDecimal(item.Cells["MAXLIM"].Value);

                        if (valor > valorMax)
                            item.Cells["PROY_VALOR"].ErrorText = (ban++).ToString() + " :El valor no debe ser superior al valor máximo";
                        else
                            item.Cells["PROY_VALOR"].ErrorText = string.Empty;
                    }
                }
            }

            if (ban > 1)
                return false;
            else
                return true;
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
                patID = Convert.ToInt16(info.Rows[0]["PAT_ID"].ToString());
                txtEstado.Text = info.Rows[0]["ESTADO"].ToString();
                txtFechaSalida.Text = info.Rows[0]["EMP_FEC_SALIDA"].ToString().Equals(string.Empty) ? "No Asignada" : Convert.ToDateTime(info.Rows[0]["EMP_FEC_SALIDA"].ToString()).ToShortDateString();
                txtFechaContrato.Text = Convert.ToDateTime(info.Rows[0]["EMP_CON_FEC_CONTRATO"].ToString()).ToShortDateString();
            }

        }

        private void ClearControls()
        {
            ErrProv.Clear();
            txtAnio.Text = string.Empty;
            lblProyectado.Text = "Proyectado: $0";
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCargo.Text = string.Empty;
            txtTrabajo.Text = string.Empty;
            txtFechaIngreso.Text = string.Empty;
            txtPatrono.Text = string.Empty;
            patID = dbType.intNull;
            txtEstado.Text = string.Empty;
            txtFechaSalida.Text = string.Empty;
            txtFechaContrato.Text = string.Empty;
            dgvData.DataSource = null;
        }

        void dText_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Utility.OnlyQuantity(sender, e);
        }

        private void TotalProyeccion()
        {
            double ingreso = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                    ingreso += row.Cells["PROY_VALOR"].Value == DBNull.Value ? 0 : Convert.ToDouble(row.Cells["PROY_VALOR"].Value);
            }
            lblProyectado.Text = "Proyectado: $"+ingreso.ToString();
        }

        #endregion

        #region Instancia / Constructor
        private static frmDeduccionGastos _instancia;
        public static frmDeduccionGastos Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmDeduccionGastos();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmDeduccionGastos()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            dgvData.ReadOnly = true;
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(222)))));
            //Design.StyleGridForm(dgvData);
        }

        #endregion
        
        private void frmDeduccionGastos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClearControls();
            var frm = new frmEmpleadoLista();
            Design.frmDialog(frm, "Lista de Empleados");
            AssignData(EmpleadoBO.Empleado.empId.ToString());
            txtAnio.Select();
        }       

        private void btnSearchYear_Click(object sender, EventArgs e)
        {
            int ban =1;
            if (txtNombre.Text == string.Empty)
                ErrProv.SetError(txtNombre, (ban++)+": Seleccione el empleado");
            
            if (txtAnio.Text == string.Empty)
                ErrProv.SetError(txtAnio, (ban++)+": Ingrese el año a Deducir");

            if (ban > 1)
                return;

            ErrProv.Clear();
            dgvData.DataSource = EmpleadoBO.ListaProyeccionGasto(txtCodigo.Text, txtAnio.Text, patID.ToString());
            Design.vDeduccionGasto(dgvData);
            TotalProyeccion();
            btnEditCancel.Enabled = true;
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
                dgvData.ReadOnly = false;
                btnSearch.Enabled = false;
                btnSearchYear.Enabled = false;
                txtAnio.Enabled = false;
            }
                
            else
            {
                dgvData.ReadOnly = true;
                btnSearch.Enabled = true;
                btnSearchYear.Enabled = true;
                txtAnio.Enabled = true;
                btnSearchYear_Click(sender, e);
                ClearControls();
            }
            Design.ControlsEdit(this.btnEditCancel, this.btnNewSave);
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            DataTable datos = (DataTable)dgvData.DataSource;
            DataTable getCambios = datos.GetChanges(DataRowState.Modified);
            if (getCambios != null)
            {
                if (ValidaDatos())
                {
                    dgvData.ReadOnly = true;
                    btnSearch.Enabled = true;
                    btnSearchYear.Enabled = true;
                    txtAnio.Enabled = true;
                    EmpleadoBO.ActualizaProyeccionGasto(getCambios);
                    Utility.MensajeOK("Cambios Registrados..!!");
                    btnSearchYear_Click(sender, e);
                }                
            }
        }

        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int index = dgvData.CurrentCell.ColumnIndex;
            if (dgvData.Columns[index].Name == "PROY_VALOR")
            {
                DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;
                dText.KeyPress -= new KeyPressEventHandler(dText_KeyPress);
                dText.KeyPress += new KeyPressEventHandler(dText_KeyPress);
            }
        }      

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string nameColumn = dgvData.Columns[e.ColumnIndex].Name;
            if (nameColumn == "PROY_VALOR")
            {
                TotalProyeccion();
            }
            dgvData.Rows[e.RowIndex].ErrorText = String.Empty;
        }        

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnSearchYear_Click(sender, e);
        }
       
    }
}
