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
    public partial class frmPrestamoDescuento : Form
    {
        #region Properties
        private EmpleadoController EmpleadoBO { get; set; }
        private CuentaController CuentaBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        private Acction StateButton { get; set; }
        #endregion

        #region Methods
        private void AssignData(string empID)
        {
            if (empID.Equals("E"))
            {
                txtCodigo.Text = EmpleadoBO.Empleado.empId.ToString();
                txtEmpleado.Text = EmpleadoBO.Empleado.empNombre;
            }
            else
            {
                txtCodigo.Text = EmpleadoBO.Prestamo.empID == 0 ? "" : EmpleadoBO.Prestamo.empID.ToString();
                txtCuenta.Text = EmpleadoBO.Prestamo.rolId == 0 ? "" : EmpleadoBO.Prestamo.rolId.ToString();
                txtPeriodo.Text = EmpleadoBO.Prestamo.rolIdGen == 0 ? "" : EmpleadoBO.Prestamo.rolIdGen.ToString();
                txtPlazo.Text = EmpleadoBO.Prestamo.presPlazo == 0 ? "" : EmpleadoBO.Prestamo.presPlazo.ToString();
                txtValor.Text = EmpleadoBO.Prestamo.presValor == 0 ? "" : EmpleadoBO.Prestamo.presValor.ToString();
                txtObservacion.Text = EmpleadoBO.Prestamo.presObservacion == null ? "" : EmpleadoBO.Prestamo.presObservacion.ToString();
                txtEmpleado.Text = EmpleadoBO.Prestamo.empleado == null ? "" : EmpleadoBO.Prestamo.empleado.ToString();
                dgvData.DataSource = EmpleadoBO.ListaTablaAmortizacion(EmpleadoBO.Prestamo);
                lblTotalRecord.Text = "Total Registros: " + ((DataTable)dgvData.DataSource).Rows.Count;
                Totales();
            }
        }
        #endregion

        #region Instancia / Constructor
        private static frmPrestamoDescuento _instancia;
        public static frmPrestamoDescuento Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmPrestamoDescuento();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmPrestamoDescuento()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            CuentaBO = CuentaController.Instancia;
            ContratoBO = ContratoController.Instancia;
            //dgvData.AutoGenerateColumns = false;
            Design.StyleGridForm(dgvData);
            StateButton = Acction.Listar;
        }

        #endregion

        private void frmPrestamoDescuento_FormClosing(object sender, FormClosingEventArgs e)
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
            if (StateButton.Equals(Acction.New))
            {
                var frm = new frmEmpleadoLista();
                Design.frmDialog(frm, "Empleados");
                AssignData("E");

                btnCuenta.Select();

            }
            else
            {
                var frm = new frmListaPrestamos();
                Design.frmDialog(frm, "Préstamos");
                AssignData("P");
                btnCuenta.Select();
            }
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {

                EmpleadoBO.Prestamo.empID = Convert.ToDecimal(txtCodigo.Text);
                EmpleadoBO.Prestamo.empleado = txtEmpleado.Text;
                EmpleadoBO.Prestamo.presPlazo = Convert.ToDecimal(txtPlazo.Text);
                EmpleadoBO.Prestamo.presValor = Convert.ToDecimal(txtValor.Text);
                EmpleadoBO.Prestamo.presObservacion = txtObservacion.Text;
                if (EmpleadoBO.ExisteRol(EmpleadoBO.Prestamo).Equals(1))
                {
                    //if (EmpleadoBO.ExistePrestamo(EmpleadoBO.Prestamo).Equals(0))
                    //{
                        StateButton = Acction.Save;
                        EmpleadoBO.RegistraTablaPrestamo(EmpleadoBO.Prestamo);
                        AssignData("P");
                        Design.ControlsNew(this.btnEditCancel, this.btnNewSave);
                    //}
                    //else
                    //    Utility.MensajeError("Acción Fallida..!! Ya cuenta con un crédito para este período");
                }
                else
                    Utility.MensajeError("Acción Fallida..!! El empleado no cuenta con un rol activo");


                //EmpleadoBO.RegistraPrestamoEmpleado(EmpleadoBO.Prestamo);
                //EmpleadoBO.GeneraTablaAmortizacion(EmpleadoBO.Prestamo);

            }






        }

        private void Totales()
        {
            double egreso = 0;
            double ingreso = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells["DET_PRES_VALOR"].Value != null)
                {
                    ingreso += Convert.ToDouble(row.Cells["DET_PRES_VALOR_PAG"].Value);
                    egreso += Convert.ToDouble(row.Cells["DET_PRES_VALOR"].Value);

                }
            }
            lblCredito.Text = "Valor Crédito: $" + egreso.ToString();
            lblPagado.Text = "Valor Pagado: $" + ingreso.ToString();
            //txtRercibe.Text = (ingreso - egreso).ToString();
        }

        private bool ValidaDatos()
        {
            int ban = 1;
            ErrProv.Clear();
            if (txtCuenta.Text.Equals(string.Empty))
                ErrProv.SetError(txtCuenta, (ban++).ToString() + ": Seleccione la cuenta respectiva");
            if (txtEmpleado.Text.Equals(string.Empty))
                ErrProv.SetError(txtEmpleado, (ban++).ToString() + ": Seleccione el nombre del empleado");
            if (txtValor.Text.Equals(string.Empty))
                ErrProv.SetError(txtValor, (ban++).ToString() + ": Ingrese el valor del crédito");
            if (txtPlazo.Text.Equals(string.Empty))
                ErrProv.SetError(txtPlazo, (ban++).ToString() + ": Ingrese el plazo del crédito");

            if (ban > 1)
                return false;
            else
                return true;
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (this.btnEditCancel.Text == "&Nuevo")
            {
                StateButton = Acction.New;
                Design.ControlsNew(this.btnEditCancel, this.btnNewSave);
                ClearControl();
                txtValor.Enabled = true;
                txtPlazo.Enabled = true;
                txtObservacion.Enabled = true;
                btnCuenta.Enabled = true;
                btnSearch.Select();

            }
            else
            {
                StateButton = Acction.Cancel;
                Design.ControlsNew(this.btnEditCancel, this.btnNewSave);
                ClearControl();
            }

            //StateButton = Acction.New;
            //ClearControl();
            //txtValor.Enabled = true;
            //txtPlazo.Enabled = true;
            //txtObservacion.Enabled = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void ClearControl()
        {
            txtCodigo.Text = string.Empty;
            txtCuenta.Text = string.Empty;
            txtPeriodo.Text = string.Empty;
            txtPlazo.Text = string.Empty;
            txtValor.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            txtEmpleado.Text = string.Empty;
            dgvData.DataSource = null;
            EmpleadoBO.Prestamo = new db.DatPrestamo();
        }

        private void btnCuenta_Click(object sender, EventArgs e)
        {
            var frm = new frmCuentaLista(new string[] { "PrestamoCuenta" });
            Design.frmDialog(frm, "Lista de Cuentas");
            txtCuenta.Text = CuentaBO.Cuenta.Cuenta;
            EmpleadoBO.Prestamo.rolId = CuentaBO.Cuenta.CuentaID;
            txtValor.Select();

        }

        private void btnPeriodo_Click(object sender, EventArgs e)
        {
            var frm = new frmPeridoRolLista("PeridoRolCorto");
            Design.frmDialog(frm, "Períodos");
            txtPeriodo.Text = ContratoBO.RolSeg.segRolId.ToString();
            EmpleadoBO.Prestamo.rolIdGen = ContratoBO.RolSeg.segRolId;
            EmpleadoBO.Prestamo.rolRepro = ContratoBO.RolSeg.segRolRepro;
        }


        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyQuantity(sender, e);
        }

        private void txtPlazo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }

    }
}
