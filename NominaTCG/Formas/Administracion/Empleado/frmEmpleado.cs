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
using System.Threading;

namespace NominaTCG
{
    public partial class frmEmpleado : Form
    {
        #region Instancia / Constructor
        private static frmEmpleado _instancia;
        public static frmEmpleado Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmEmpleado();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmEmpleado()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            UbicacionBO = UbicacionController.Instancia;
            ContratoBO = ContratoController.Instancia;
            PatronoBO = PatronoController.Instancia;
            LocalBO = LocalController.Instancia;
            EscalafonBO = EscalafonController.Instancia;
            CuentaBO = CuentaController.Instancia;
            dgvValor.AutoGenerateColumns = false;
            SistemaBO = SistemaController.Instancia;
            LoadComboBox();
        }
        #endregion

        #region Properties
        private EmpleadoController EmpleadoBO { get; set; }
        private UbicacionController UbicacionBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        private PatronoController PatronoBO { get; set; }
        private LocalController LocalBO { get; set; }
        private EscalafonController EscalafonBO { get; set; }
        private CuentaController CuentaBO { get; set; }
        private Acction StateButton { get; set; }
        private SistemaController SistemaBO { get; set; }
        private string EmpNewID { get; set; }
        #endregion

        #region Methods
        private void LoadComboBox()
        {
            //Datos Personales
            cboPerDiscapacidad.DataSource = Entity.Catalogo.RespCorta();
            cboPerDiscapacidad.DisplayMember = "Nombre";
            cboPerDiscapacidad.ValueMember = "ID";
            cboPerFondoReserva.DataSource = Entity.Catalogo.RespCorta();
            cboPerFondoReserva.DisplayMember = "Nombre";
            cboPerFondoReserva.ValueMember = "ID";
            cboPerTipoCuenta.DataSource = Entity.Catalogo.TipoCuenta();
            cboPerTipoCuenta.DisplayMember = "Nombre";
            cboPerTipoCuenta.ValueMember = "ID";
            cboPerDecimoTercero.DataSource = Entity.Catalogo.RespCorta();
            cboPerDecimoTercero.DisplayMember = "Nombre";
            cboPerDecimoTercero.ValueMember = "ID";
            cboPerDecimoCuarto.DataSource = Entity.Catalogo.RespCorta();
            cboPerDecimoCuarto.DisplayMember = "Nombre";
            cboPerDecimoCuarto.ValueMember = "ID";
            cboPerSector.DataSource = UbicacionBO.Sector();
            cboPerSector.DisplayMember = "Nombre";
            cboPerSector.ValueMember = "ID";
            cboPerSexo.DataSource = Entity.Catalogo.Sexo();
            cboPerSexo.DisplayMember = "Nombre";
            cboPerSexo.ValueMember = "ID";
            cboPerEstadoCivil.DataSource = Entity.Catalogo.EstadoCivil();
            cboPerEstadoCivil.DisplayMember = "Nombre";
            cboPerEstadoCivil.ValueMember = "ID";
            cboPerEducacion.DataSource = Entity.Catalogo.NivelEducacion();
            cboPerEducacion.DisplayMember = "Nombre";
            cboPerEducacion.ValueMember = "ID";
            //Datos Contratos
            cboConRazon.DataSource = Entity.Catalogo.TipoActitud();
            cboConRazon.DisplayMember = "Nombre";
            cboConRazon.ValueMember = "ID";
            cboConCausaFin.DataSource = ContratoBO.ListarContratoFin();
            cboConCausaFin.DisplayMember = "CON_CAU_CAUSA";
            cboConCausaFin.ValueMember = "CON_CAU_ID";
            cboConContrato.DataSource = ContratoBO.ListarContrato();
            cboConContrato.DisplayMember = "CON_NOMBRE";
            cboConContrato.ValueMember = "CON_ID";
            cboConPatrono.DataSource = PatronoBO.Listar();
            cboConPatrono.DisplayMember = "PAT_RAZ_SOCIAL";
            cboConPatrono.ValueMember = "PAT_ID";
            cboConFirma.DataSource = Entity.Catalogo.RespCorta();
            cboConFirma.DisplayMember = "Nombre";
            cboConFirma.ValueMember = "ID";
            //Datos Laborales
            cboLabLocal.DataSource = LocalBO.Lista();
            cboLabLocal.DisplayMember = "LOC_NOMBRE";
            cboLabLocal.ValueMember = "LOC_ID";
            cboLabCargo.DataSource = EscalafonBO.Cargo();
            cboLabCargo.DisplayMember = "ESC_CARGOMB";
            cboLabCargo.ValueMember = "ESC_ID";
            cboLabEstado.DataSource = Entity.Catalogo.EstadoLaboral();
            cboLabEstado.DisplayMember = "Nombre";
            cboLabEstado.ValueMember = "ID";
            cboLabTipoPago.DataSource = Entity.Catalogo.PagoServicio();
            cboLabTipoPago.DisplayMember = "Nombre";
            cboLabTipoPago.ValueMember = "ID";
            //Datos Familiares
            EMP_FAM_PARENT.DataSource = Entity.Catalogo.Parentesco();
            EMP_FAM_PARENT.DisplayMember = "Nombre";
            EMP_FAM_PARENT.ValueMember = "ID";
            //Datos Fijos
            ROL_ID.DataSource = CuentaBO.ListaCuentas();
            ROL_ID.DisplayMember = "CUENTA";
            ROL_ID.ValueMember = "ROL_ID";
        }

        private void LoadControls()
        {
            if (EmpleadoBO.Empleado.empNombre == null)
                return;
            //Datos Personales
            txtCodigo.Text = EmpleadoBO.Empleado.empId.ToString();
            txtNombre.Text = EmpleadoBO.Empleado.empNombre;
            txtApellido.Text = EmpleadoBO.Empleado.empApellido;
            txtPerCedula.Text = EmpleadoBO.Empleado.empCi;
            txtPerNumIESS.Text = EmpleadoBO.Empleado.empNumIess;
            txtPerCuentaBanco.Text = EmpleadoBO.Empleado.empCuenta;
            cboPerDiscapacidad.SelectedValue = EmpleadoBO.Empleado.empDiscapacidad;
            txtPerCorreo.Text = EmpleadoBO.Empleado.empMail;
            txtPerCorreoPer.Text = EmpleadoBO.Empleado.empMailPer;
            txtPerPasaporte.Text = EmpleadoBO.Empleado.empPasaporte;
            cboPerFondoReserva.SelectedValue = EmpleadoBO.Empleado.empPagFonRes;
            cboPerTipoCuenta.SelectedValue = EmpleadoBO.Empleado.empTipoCnta;
            txtPerNumIdentificacion.Text = EmpleadoBO.Empleado.empNumConadis;
            cboPerDecimoTercero.SelectedValue = EmpleadoBO.Empleado.empPagDecTer;
            cboPerDecimoCuarto.SelectedValue = EmpleadoBO.Empleado.empPagDecCua;
            txtPerBarrio.Text = EmpleadoBO.Empleado.empBarrio;
            txtPerDireccion.Text = EmpleadoBO.Empleado.empDirec;
            txtPerTelefono.Text = EmpleadoBO.Empleado.empTelefono;
            cboPerSector.SelectedValue = EmpleadoBO.Empleado.empSecId;
            txtPerNumero.Text = EmpleadoBO.Empleado.empDireNumero;
            txtPerTelefonoSeg.Text = EmpleadoBO.Empleado.empTelefono2;
            txtPerLugarNac.Text = EmpleadoBO.Empleado.empLugNac;
            pPerFechaNac.Text = EmpleadoBO.Empleado.empFecNac.ToString();
            cboPerSexo.SelectedValue = EmpleadoBO.Empleado.empSexo;
            cboPerEducacion.SelectedValue = EmpleadoBO.Empleado.empEdu;
            txtPerActualizaciones.Text = EmpleadoBO.Empleado.empFecSeg;
            cboPerEstadoCivil.SelectedValue = EmpleadoBO.Empleado.empEstCivil;
            txtPerTipoSangre.Text = EmpleadoBO.Empleado.empTipSangre;
            txtPerLabFecIng.Text = EmpleadoBO.Empleado.labFecIngreso.Value.ToString("dd/MM/yyyy");
            pPerFechaIngreso.Text = EmpleadoBO.Empleado.labFecIngreso.ToString();
            //txtPerFechaSalidaR.Text = EmpleadoBO.Empleado.empFecSalidareal.Value.ToString("dd/MM/yyyy");
            mtxtFechaSalida.Text = EmpleadoBO.Empleado.empFecSalidareal.Equals(null) ? "" : EmpleadoBO.Empleado.empFecSalidareal.Value.ToString("dd/MM/yyyy");//.ToString("dd/MM/yyyy");
            txtPerFechaSalidaDif.Text = EmpleadoBO.Empleado.empFecSalida.Equals(null) ? "" : EmpleadoBO.Empleado.empFecSalida.Value.ToString("dd/MM/yyyy");
            DataTable datoAuxiliar = new DataTable();
            datoAuxiliar = EmpleadoBO.ListaEmpleadoDT(txtCodigo.Text);
            if (datoAuxiliar.Rows.Count > 0)
            {
                txtPatrono.Text = datoAuxiliar.Rows[0]["PATRONO"].ToString();
                txtCargo.Text = datoAuxiliar.Rows[0]["ESC_CARGOMB"].ToString();
                txtLugarTrabajo.Text = datoAuxiliar.Rows[0]["LOC_NOMBRE"].ToString();
            }
            //txtPerFechaRegSis.Text = EmpleadoBO.Empleado.empFecReg.ToString();
            //txtPerFechaModSis.Text = EmpleadoBO.Empleado.empFecMod.ToString();

            //Datos Contrato            
            cboConContrato.SelectedValue = ContratoBO.EmpleadoContrato.conId;
            cboConPatrono.SelectedValue = ContratoBO.EmpleadoContrato.patId;
            cboConRazon.SelectedValue = (ContratoBO.EmpleadoContrato.empConRazonSale == null) ? "" : ContratoBO.EmpleadoContrato.empConRazonSale;
            cboConFirma.SelectedValue = (ContratoBO.EmpleadoContrato.empConFirmRenu == null) ? -1 : ContratoBO.EmpleadoContrato.empConFirmRenu;
            mtxtConFechaLiquidacion.Text = ContratoBO.EmpleadoContrato.empConFecLiqui == null ? "" : ContratoBO.EmpleadoContrato.empConFecLiqui.Value.ToString("dd/MM/yyyy");
            //cboConFirma.SelectedValue = ContratoBO.EmpleadoContrato.empConFirmLiqui;
            mtxtConFechaContrato.Text = ContratoBO.EmpleadoContrato.empConFecContrato == null ? "" : ContratoBO.EmpleadoContrato.empConFecContrato.Value.ToString("dd/MM/yyyy");//ContratoBO.EmpleadoContrato.empConFecContrato.ToString("dd/MM/yyyy");
            txtConObservacion.Text = ContratoBO.EmpleadoContrato.empConObs;
            cboConCausaFin.SelectedValue = (ContratoBO.EmpleadoContrato.conCauId == null) ? -1 : ContratoBO.EmpleadoContrato.conCauId;
            txtConFechaIng.Text = ContratoBO.EmpleadoContrato.empConFecReg.ToString();
            txtConFechaMod.Text = ContratoBO.EmpleadoContrato.empConFecMod.ToString();

            //Datos Laborales

            cboLabLocal.SelectedValue = ContratoBO.Laboral.locId;
            cboLabCargo.SelectedValue = ContratoBO.Laboral.escId;
            mtxtLabFecha.Text = ContratoBO.Laboral.labFecCambEsc == null ? "" : ContratoBO.Laboral.labFecCambEsc.Value.ToString("dd/MM/yyyy");
            //ContratoBO.Laboral.labSueldoBono;
            txtLabObservacion.Text = ContratoBO.Laboral.labObs;
            txtLabFechaReg.Text = ContratoBO.Laboral.labFecReg.ToString("dd/MM/yyyy");
            txtLabFechaMod.Text = ContratoBO.Laboral.labFecMod.ToString();//.ToString("dd/MM/yyyy");
            txtLabObservacionSis.Text = ContratoBO.Laboral.labFecObsSis;
            cboLabEstado.SelectedValue = ContratoBO.Laboral.labEstado;
            cboLabTipoPago.SelectedValue = ContratoBO.Laboral.labTipoEmp;
            txtLabRBU.Text = ContratoBO.Laboral.labRbu.ToString();
            //ContratoBO.Laboral.labVest
            //ContratoBO.Laboral.labBono
            txtLabQuincena.Text = ContratoBO.Laboral.labQuincena.ToString();

            //Datos Familiares
            dgvFamiliar.DataSource = EmpleadoBO.Familiares(txtCodigo.Text);

            //Datos Fijos
            dgvValor.DataSource = ContratoBO.RubroAdicional(txtCodigo.Text);
        }
        private void ActiveControls(bool stateControl, int tabID)
        {
            //Dato Personales
            btnSearch.Enabled = !stateControl;
            //btnListaDiscapacidad.ReadOnly = stateControl;
            chkPasaporte.Enabled = stateControl;
            chkPasaporte.Checked = false;
            txtApellido.ReadOnly = !stateControl;
            txtNombre.ReadOnly = !stateControl;
            //txtPerLabFecIng.ReadOnly = estadoControl;
            txtPerCedula.ReadOnly = !stateControl;
            txtPerPasaporte.ReadOnly = !stateControl;
            txtPerNumIESS.ReadOnly = !stateControl;
            cboPerFondoReserva.Enabled = stateControl;
            txtPerCuentaBanco.Enabled = stateControl;
            cboPerTipoCuenta.Enabled = stateControl;
            //cboPerDiscapacidad.ReadOnly = stateControl;
            txtPerNumIdentificacion.ReadOnly = !stateControl;
            txtPerCorreo.ReadOnly = !stateControl;
            txtPerCorreoPer.ReadOnly = !stateControl;
            //cboPerAfiliacion.ReadOnly = estadoControl;
            //txtPerAfiliacionDesde.ReadOnly = estadoControl;
            cboPerDecimoTercero.Enabled = stateControl;
            cboPerDecimoCuarto.Enabled = stateControl;
            txtPerBarrio.ReadOnly = !stateControl;
            cboPerSector.Enabled = stateControl;
            txtPerDireccion.ReadOnly = !stateControl;
            txtPerNumero.ReadOnly = !stateControl;
            txtPerTelefono.ReadOnly = !stateControl;
            txtPerTelefonoSeg.ReadOnly = !stateControl;
            txtPerLugarNac.ReadOnly = !stateControl;
            pPerFechaNac.Enabled = stateControl;
            pPerFechaIngreso.Enabled = stateControl;
            cboPerEstadoCivil.Enabled = stateControl;
            cboPerSexo.Enabled = stateControl;
            txtPerTipoSangre.ReadOnly = !stateControl;
            cboPerEducacion.Enabled = stateControl;
            //txtPerFechaSalidaR.ReadOnly = stateControl;
            //mtxtFechaSalida.ReadOnly = stateControl;
            //btnReingreso.ReadOnly = stateControl;
            //Datos Contrato
            mtxtConFechaLiquidacion.ReadOnly = !stateControl;
            mtxtConFechaContrato.ReadOnly = !stateControl;
            cboConRazon.Enabled = stateControl;
            cboConCausaFin.Enabled = stateControl;
            txtConObservacion.ReadOnly = !stateControl;
            cboConContrato.Enabled = stateControl;
            cboConPatrono.Enabled = stateControl;
            cboConFirma.Enabled = stateControl;

            //Datos Laborales
            mtxtLabFecha.ReadOnly = !stateControl;
            cboLabLocal.Enabled = stateControl;
            cboLabCargo.Enabled = stateControl;
            txtLabRBU.ReadOnly = !stateControl;
            txtLabQuincena.ReadOnly = !stateControl;
            cboLabEstado.Enabled = stateControl;
            cboLabTipoPago.Enabled = stateControl;
            txtLabObservacion.ReadOnly = !stateControl;
            txtLabObservacionSis.ReadOnly = !stateControl;

            //Datos Familiar
            dgvFamiliar.ReadOnly = !stateControl;

            //Datos Fijos
            dgvValor.ReadOnly = !stateControl;

        }

        //private void ActiveControls(bool stateControl, int tabID)
        //{
        //    //Dato Personales
        //    btnSearch.Enabled = !stateControl;
        //    //btnListaDiscapacidad.Enabled = stateControl;
        //    txtApellido.ReadOnly = stateControl;
        //    txtNombre.Enabled = stateControl;
        //    //txtPerLabFecIng.Enabled = estadoControl;
        //    txtPerCedula.Enabled = stateControl;
        //    txtPerPasaporte.Enabled = stateControl;
        //    txtPerNumIESS.Enabled = stateControl;
        //    cboPerFondoReserva.Enabled = stateControl;
        //    txtPerCuentaBanco.Enabled = stateControl;
        //    cboPerTipoCuenta.Enabled = stateControl;
        //    //cboPerDiscapacidad.Enabled = stateControl;
        //    txtPerNumIdentificacion.Enabled = stateControl;
        //    txtPerCorreo.Enabled = stateControl;
        //    txtPerCorreoPer.Enabled = stateControl;
        //    //cboPerAfiliacion.Enabled = estadoControl;
        //    //txtPerAfiliacionDesde.Enabled = estadoControl;
        //    cboPerDecimoTercero.Enabled = stateControl;
        //    cboPerDecimoCuarto.Enabled = stateControl;
        //    txtPerBarrio.Enabled = stateControl;
        //    cboPerSector.Enabled = stateControl;
        //    txtPerDireccion.Enabled = stateControl;
        //    txtPerNumero.Enabled = stateControl;
        //    txtPerTelefono.Enabled = stateControl;
        //    txtPerTelefonoSeg.Enabled = stateControl;
        //    txtPerLugarNac.Enabled = stateControl;
        //    pPerFechaNac.Enabled = stateControl;
        //    pPerFechaIngreso.Enabled = stateControl;
        //    cboPerEstadoCivil.Enabled = stateControl;
        //    cboPerSexo.Enabled = stateControl;
        //    txtPerTipoSangre.Enabled = stateControl;
        //    cboPerEducacion.Enabled = stateControl;
        //    //txtPerFechaSalidaR.Enabled = stateControl;
        //    //mtxtFechaSalida.Enabled = stateControl;
        //    //btnReingreso.Enabled = stateControl;
        //    //Datos Contrato
        //    mtxtConFechaLiquidacion.Enabled = stateControl;
        //    mtxtConFechaContrato.Enabled = stateControl;
        //    cboConRazon.Enabled = stateControl;
        //    cboConCausaFin.Enabled = stateControl;
        //    txtConObservacion.Enabled = stateControl;
        //    cboConContrato.Enabled = stateControl;
        //    cboConPatrono.Enabled = stateControl;
        //    cboConFirma.Enabled = stateControl;

        //    //Datos Laborales
        //    mtxtLabFecha.Enabled = stateControl;
        //    cboLabLocal.Enabled = stateControl;
        //    cboLabCargo.Enabled = stateControl;
        //    txtLabRBU.Enabled = stateControl;
        //    txtLabQuincena.Enabled = stateControl;
        //    cboLabEstado.Enabled = stateControl;
        //    cboLabTipoPago.Enabled = stateControl;
        //    txtLabObservacion.Enabled = stateControl;
        //    txtLabObservacionSis.Enabled = stateControl;

        //    //Datos Familiar
        //    dgvFamiliar.Enabled = stateControl;

        //    //Datos Fijos
        //    dgvValor.Enabled = stateControl;

        //}

        private void ClearControls(int tabID)
        {
            //Info. Principal
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtPerCedula.Text = string.Empty;
            txtPerNumIESS.Text = string.Empty;
            txtPerCuentaBanco.Text = string.Empty;
            cboPerDiscapacidad.SelectedValue = 0;
            txtPerCorreo.Text = string.Empty;
            txtPerCorreoPer.Text = string.Empty;
            txtPerPasaporte.Text = string.Empty;
            cboPerFondoReserva.SelectedValue = -1;
            cboPerTipoCuenta.SelectedValue = -1;
            txtPerNumIdentificacion.Text = string.Empty;
            cboPerDecimoTercero.SelectedValue = -1;
            cboPerDecimoCuarto.SelectedValue = -1;
            txtPerBarrio.Text = string.Empty;
            txtPerDireccion.Text = string.Empty;
            txtPerTelefono.Text = string.Empty;
            cboPerSector.SelectedValue = -1;
            txtPerNumero.Text = string.Empty;
            txtPerTelefonoSeg.Text = string.Empty;
            txtPerLugarNac.Text = string.Empty;
            pPerFechaNac.Text = string.Empty;
            pPerFechaIngreso.Text = string.Empty;
            cboPerSexo.SelectedValue = -1;
            cboPerEducacion.SelectedValue = -1;
            txtPerActualizaciones.Text = string.Empty;
            cboPerEstadoCivil.SelectedValue = -1;
            txtPerTipoSangre.Text = string.Empty;
            txtPerLabFecIng.Text = string.Empty;
            txtPerFechaSalidaDif.Text = string.Empty;
            txtLugarTrabajo.Text = string.Empty;
            txtPatrono.Text = string.Empty;
            txtCargo.Text = string.Empty;
            //txtPerFechaSalidaR.Text = string.Empty;
            mtxtFechaSalida.Text = string.Empty;
            txtPerFechaSalidaDif.Text = string.Empty;
            //Datos Contrato            
            mtxtConFechaContrato.Text = string.Empty;
            mtxtConFechaLiquidacion.Text = string.Empty;
            cboConRazon.SelectedValue = -1;
            cboConFirma.SelectedValue = -1;
            cboConCausaFin.SelectedValue = -1;
            txtConObservacion.Text = string.Empty;
            cboConContrato.SelectedValue = -1;
            cboConPatrono.SelectedValue = -1;
            txtConFechaIng.Text = string.Empty;
            txtConFechaMod.Text = string.Empty;
            //Datos Laborales
            mtxtLabFecha.Text = string.Empty;
            cboLabLocal.SelectedIndex = -1;
            cboLabCargo.SelectedIndex = -1;
            cboLabEstado.SelectedIndex = -1;
            cboLabTipoPago.SelectedIndex = -1;
            txtLabRBU.Text = string.Empty;
            txtLabQuincena.Text = string.Empty;
            txtLabObservacion.Text = string.Empty;
            txtLabObservacionSis.Text = string.Empty;
            txtLabFechaReg.Text = string.Empty;
            txtLabFechaMod.Text = string.Empty;
            //Datos Familiares   
            if (dgvFamiliar.DataSource != null)
                ((DataTable)dgvFamiliar.DataSource).Rows.Clear();
            //Datos Fijos
            if (dgvValor.DataSource != null)
                ((DataTable)dgvValor.DataSource).Rows.Clear();
            ErrProv.Clear();
        }

        private bool ValidateControls(int tabID)
        {
            ErrProv.Clear();
            string sms = "El campo es requerido";
            int cnt = 1;

            #region Datos Personales
            if (txtNombre.Text == string.Empty)
            {
                ErrProv.SetError(txtNombre, sms);
                cnt++;
            }
            if (txtApellido.Text == string.Empty)
            {
                ErrProv.SetError(txtApellido, sms);
                cnt++;
            }
            if (txtPerCedula.Text == string.Empty)
            {
                ErrProv.SetError(txtPerCedula, sms);
                cnt++;
            }
            else
            {
                if (!chkPasaporte.Checked)
                {
                    if (EmpleadoBO.ValidaCeldula(txtPerCedula.Text) == 0)
                    {
                        ErrProv.SetError(txtPerCedula, "Número de cédula incorrecta.!!");
                        cnt++;
                    }
                }
            }
            //if (txtPerNumIESS.Text == string.Empty)
            //{
            //    ErrProv.SetError(txtPerNumIESS, sms);
            //    cnt++;
            //}
            if (txtPerCuentaBanco.Text == string.Empty)
            {
                ErrProv.SetError(txtPerCuentaBanco, sms);
                cnt++;
            }
            if (cboPerDiscapacidad.Text == string.Empty)
            {
                ErrProv.SetError(cboPerDiscapacidad, sms);
                cnt++;
            }
            //if (cboPerDiscapacidad.Text.Equals("Si"))
            //{
            //    if (txtPerNumIdentificacion.Text == string.Empty)
            //    {
            //        ErrProv.SetError(txtPerNumIdentificacion, sms);
            //        cnt++;
            //    }
            //}
            //else
            //    txtPerNumIdentificacion.Text = string.Empty;

            if (txtPerCorreoPer.Text == string.Empty)
            {
                ErrProv.SetError(txtPerCorreoPer, sms);
                cnt++;
            }
            if (cboPerFondoReserva.Text == string.Empty)
            {
                ErrProv.SetError(cboPerFondoReserva, sms);
                cnt++;
            }

            if (cboPerTipoCuenta.Text == string.Empty)
            {
                ErrProv.SetError(cboPerTipoCuenta, sms);
                cnt++;
            }

            if (cboPerDecimoTercero.Text == string.Empty)
            {
                ErrProv.SetError(cboPerDecimoTercero, sms);
                cnt++;
            }
            if (cboPerDecimoCuarto.Text == string.Empty)
            {
                ErrProv.SetError(cboPerDecimoCuarto, sms);
                cnt++;
            }

            if (txtPerBarrio.Text == string.Empty)
            {
                ErrProv.SetError(txtPerBarrio, sms);
                cnt++;
            }
            if (txtPerDireccion.Text == string.Empty)
            {
                ErrProv.SetError(txtPerDireccion, sms);
                cnt++;
            }
            if (cboPerSector.Text == string.Empty)
            {
                ErrProv.SetError(cboPerSector, sms);
                cnt++;
            }
            if (txtPerNumero.Text == string.Empty)
            {
                ErrProv.SetError(txtPerNumero, sms);
                cnt++;
            }
            if (txtPerTelefono.Text == string.Empty)
            {
                ErrProv.SetError(txtPerTelefono, sms);
                cnt++;
            }

            if (txtPerLugarNac.Text == string.Empty)
            {
                ErrProv.SetError(txtPerLugarNac, sms);
                cnt++;
            }
            if (pPerFechaNac.Text == string.Empty)
            {
                ErrProv.SetError(pPerFechaNac, sms);
                cnt++;
            }
            if (cboPerSexo.Text == string.Empty)
            {
                ErrProv.SetError(cboPerSexo, sms);
                cnt++;
            }
            if (cboPerEducacion.Text == string.Empty)
            {
                ErrProv.SetError(cboPerEducacion, sms);
                cnt++;
            }
            if (cboPerEstadoCivil.Text == string.Empty)
            {
                ErrProv.SetError(cboPerEstadoCivil, sms);
                cnt++;
            }
            if (txtPerTipoSangre.Text == string.Empty)
            {
                ErrProv.SetError(txtPerTipoSangre, sms);
                cnt++;
            }

            if (mtxtFechaSalida.Text != "01/01/9999" & mtxtFechaSalida.Text != "  /  /")
            {
                if (Utility.isDate(mtxtFechaSalida.Text))
                {
                    if (Convert.ToDateTime(mtxtFechaSalida.Text).Date > DateTime.Now.Date || Convert.ToDateTime(mtxtFechaSalida.Text).Date < pPerFechaIngreso.Value.Date)
                    {
                        ErrProv.SetError(mtxtFechaSalida, "La fecha de salida no puede ser mayor a la fecha actual ni mejor a la de ingreso");
                        cnt++;
                    }
                }
                else
                {
                    ErrProv.SetError(mtxtFechaSalida, "Ingrese una fecha válida (dd/mm/yyyy)");
                    cnt++;
                }
            }


            if (!cnt.Equals(1))
            {
                tabInformacion.SelectedIndex = 0;
                return false;
            }
            #endregion

            #region Datos Contrato
            if (mtxtConFechaContrato.Text == string.Empty)
            {
                ErrProv.SetError(mtxtConFechaContrato, sms);
                cnt++;
            }
            if (cboConContrato.Text == string.Empty)
            {
                ErrProv.SetError(cboConContrato, sms);
                cnt++;
            }
            if (cboConPatrono.Text == string.Empty)
            {
                ErrProv.SetError(cboConPatrono, sms);
                cnt++;
            }
            if (mtxtConFechaContrato.Text != "01/01/9999" & mtxtConFechaContrato.Text != "  /  /")
            {
                if (!Utility.isDate(mtxtConFechaContrato.Text))
                {
                    ErrProv.SetError(mtxtConFechaContrato, "Ingrese una fecha válidad (dd/mm/yyyy)");
                    cnt++;
                }
            }
            if (mtxtConFechaLiquidacion.Text != "01/01/9999" & mtxtConFechaLiquidacion.Text != "  /  /")
            {
                if (!Utility.isDate(mtxtConFechaLiquidacion.Text))
                {
                    ErrProv.SetError(mtxtConFechaLiquidacion, "Ingrese una fecha válidad (dd/mm/yyyy)");
                    cnt++;
                }
            }

            if (!cnt.Equals(1))
            {
                tabInformacion.SelectedIndex = 1;
                return false;
            }
            #endregion

            #region Datos Laborales
            if (cboLabLocal.Text == string.Empty)
            {
                ErrProv.SetError(cboLabLocal, sms);
                cnt++;
            }
            if (cboLabCargo.Text == string.Empty)
            {
                ErrProv.SetError(cboLabCargo, sms);
                cnt++;
            }
            if (txtLabRBU.Text == string.Empty)
            {
                ErrProv.SetError(txtLabRBU, sms);
                cnt++;
            }
            //if (txtLabQuincena.Text == string.Empty)
            //{
            //    ErrProv.SetError(txtLabQuincena, sms);
            //    cnt++;
            //}
            if (cboLabEstado.Text == string.Empty)
            {
                ErrProv.SetError(cboLabEstado, sms);
                cnt++;
            }
            if (cboLabTipoPago.Text == string.Empty)
            {
                ErrProv.SetError(cboLabTipoPago, sms);
                cnt++;
            }

            if (mtxtLabFecha.Text != "01/01/9999" & mtxtLabFecha.Text != "  /  /")
            {
                if (!Utility.isDate(mtxtLabFecha.Text))
                {
                    ErrProv.SetError(mtxtLabFecha, "Ingrese una fecha válidad (dd/mm/yyyy)");
                    cnt++;
                }
            }


            if (!cnt.Equals(1))
            {
                tabInformacion.SelectedIndex = 2;
                return false;
            }
            #endregion

            switch (tabID)
            {
                case 2:

                    break;
                    //case 3://Datos Familiares
                    //    foreach (DataGridViewRow item in dgvFamiliar.Rows)
                    //    {
                    //        if (!item.IsNewRow)
                    //        {
                    //            if ((item.Cells["EMP_FAM_NOMBRE"].Value == DBNull.Value || item.Cells["EMP_FAM_NOMBRE"].Value == string.Empty)
                    //                | (item.Cells["EMP_FAM_FEC_NAC"].Value == DBNull.Value || item.Cells["EMP_FAM_FEC_NAC"].Value == string.Empty)
                    //                | (item.Cells["EMP_FAM_PARENT"].Value == DBNull.Value || item.Cells["EMP_FAM_PARENT"].Value == string.Empty)
                    //                //| (item.Cells["EMP_FAM_OCUP"].Value == DBNull.Value || item.Cells["EMP_FAM_OCUP"].Value == string.Empty)
                    //                )
                    //            {
                    //                dgvFamiliar.Rows[item.Index].ErrorText = "Los datos son requeridos";
                    //                cnt++;
                    //            }
                    //        }

                    //    }
                    //    break;

                    //case 4://Datos Fijos
                    //    foreach (DataGridViewRow item in dgvValor.Rows)
                    //    {
                    //        if (!item.IsNewRow)
                    //        {
                    //            if ((item.Cells["ROL_ID"].Value == null) | (item.Cells["FIJ_VALOR"].Value == null || item.Cells["FIJ_VALOR"].Value.ToString() == string.Empty))
                    //            {
                    //                dgvValor.Rows[item.Index].ErrorText = "Los datos son requeridos";
                    //                cnt++;
                    //            }
                    //        }
                    //    }

                    //    break;
            }
            if (cnt.Equals(1))
                return true;
            else
            {
                tabInformacion.SelectedIndex = tabID;
                return false;
            }

        }
        private Int64 RegisterReEntry(string idEmp)
        {
            Int64 resp = 0;
            //Datos Empleado
            EmpleadoBO.Empleado.empId = (txtCodigo.Text == string.Empty) ? 0 : Convert.ToInt64(txtCodigo.Text);
            EmpleadoBO.Empleado.empNombre = txtNombre.Text.ToUpper();
            EmpleadoBO.Empleado.empDirec = txtPerDireccion.Text.ToUpper();
            EmpleadoBO.Empleado.empTelefono = txtPerTelefono.Text;
            EmpleadoBO.Empleado.empLugNac = txtPerLugarNac.Text.ToUpper();
            EmpleadoBO.Empleado.labFecIngreso = DateTime.Now;
            EmpleadoBO.Empleado.empFecNac = pPerFechaNac.Value;
            EmpleadoBO.Empleado.empCi = txtPerCedula.Text;
            EmpleadoBO.Empleado.empNumIess = txtPerNumIESS.Text == "" ? "0" : txtPerNumIESS.Text;
            EmpleadoBO.Empleado.empEstCivil = cboPerEstadoCivil.SelectedValue.ToString();
            EmpleadoBO.Empleado.empNumHijos = 0;
            EmpleadoBO.Empleado.empCuenta = txtPerCuentaBanco.Text;
            EmpleadoBO.Empleado.empApellido = txtApellido.Text.ToUpper();
            EmpleadoBO.Empleado.empAfilHumana = 0;
            EmpleadoBO.Empleado.empTelefono2 = txtPerTelefonoSeg.Text;
            EmpleadoBO.Empleado.empTipoCnta = Convert.ToInt32(cboPerTipoCuenta.SelectedValue);
            EmpleadoBO.Empleado.empSexo = Convert.ToInt32(cboPerSexo.SelectedValue);
            EmpleadoBO.Empleado.empSecId = Convert.ToInt32(cboPerSector.SelectedValue);
            EmpleadoBO.Empleado.empBarrio = txtPerBarrio.Text.ToUpper();
            EmpleadoBO.Empleado.empEdu = cboPerEducacion.SelectedValue.ToString();
            EmpleadoBO.Empleado.empDireNumero = txtPerNumero.Text;
            EmpleadoBO.Empleado.empTipSangre = txtPerTipoSangre.Text;
            EmpleadoBO.Empleado.empDiscapacidad = Convert.ToInt32(cboPerDiscapacidad.SelectedValue);
            EmpleadoBO.Empleado.empNumConadis = txtPerNumIdentificacion.Text;
            EmpleadoBO.Empleado.empAfiFarma = 0;
            EmpleadoBO.Empleado.empAfiFarmaFec = dbType.dateNull;
            EmpleadoBO.Empleado.empPagFonRes = Convert.ToInt32(cboPerFondoReserva.SelectedValue);
            EmpleadoBO.Empleado.empPasaporte = txtPerPasaporte.Text;
            EmpleadoBO.Empleado.empMail = txtPerCorreo.Text;
            EmpleadoBO.Empleado.empMailPer = txtPerCorreoPer.Text;
            EmpleadoBO.Empleado.empPagDecTer = Convert.ToInt32(cboPerDecimoTercero.SelectedValue);
            EmpleadoBO.Empleado.empPagDecCua = Convert.ToInt32(cboPerDecimoCuarto.SelectedValue);
            EmpleadoBO.Empleado.empDependientes = 0;
            resp = EmpleadoBO.RegistarEmpleado(EmpleadoBO.Empleado, "I");
            //Datos de Contrato
            ContratoBO.EmpleadoContrato.empId = Convert.ToInt64(resp);
            ContratoBO.EmpleadoContrato.empConId = 1;
            ContratoBO.EmpleadoContrato.conId = Convert.ToInt32(cboConContrato.SelectedValue);
            ContratoBO.EmpleadoContrato.patId = Convert.ToInt32(cboConPatrono.SelectedValue);
            ContratoBO.EmpleadoContrato.empConRazonSale = string.Empty;
            ContratoBO.EmpleadoContrato.empConFirmRenu = dbType.intNull;
            ContratoBO.EmpleadoContrato.empConFecLiqui = dbType.dateNull;
            ContratoBO.EmpleadoContrato.empConFirmLiqui = dbType.intNull;
            ContratoBO.EmpleadoContrato.empConFecContrato = DateTime.Now;
            ContratoBO.EmpleadoContrato.empConObs = string.Empty;
            ContratoBO.EmpleadoContrato.conCauId = dbType.intNull;
            ContratoBO.RegistraContrato(ContratoBO.EmpleadoContrato, "I");
            //Datos Laborales 
            ContratoBO.Laboral.empId = Convert.ToInt64(resp);
            ContratoBO.Laboral.labId = 2;
            ContratoBO.Laboral.locId = Convert.ToInt32(cboLabLocal.SelectedValue);
            ContratoBO.Laboral.escId = Convert.ToInt32(cboLabCargo.SelectedValue);
            ContratoBO.Laboral.labFecCambEsc = Convert.ToDateTime(mtxtLabFecha.Text);
            ContratoBO.Laboral.labSueldoBono = 0;
            ContratoBO.Laboral.labObs = string.Empty;
            ContratoBO.Laboral.labFecReg = DateTime.Now;
            ContratoBO.Laboral.labFecMod = dbType.dateNull;
            ContratoBO.Laboral.labFecObsSis = string.Empty;
            ContratoBO.Laboral.labEstado = 1;
            ContratoBO.Laboral.labTipoEmp = Convert.ToInt32(cboLabTipoPago.SelectedValue);
            ContratoBO.Laboral.labRbu = Convert.ToInt32(txtLabRBU.Text);
            ContratoBO.Laboral.labVest = 0;
            ContratoBO.Laboral.labBono = 0;
            ContratoBO.Laboral.labQuincena = txtLabQuincena.Text == "" ? 0 : Convert.ToInt32(txtLabQuincena.Text);
            ContratoBO.RegistrarInfoLaboral(ContratoBO.Laboral);
            //Datos Familiares           
            //resp = InfoAdditional(resp);
            DataTable data;
            DataTable dataChange;
            resp = UpdateDataEmp(Convert.ToInt64(idEmp), out data, out dataChange);

            return resp;
        }
        //private Int64 RegisterData(string idEmp)
        //{
        //    Int64 resp = 0;
        //    //Datos de Contrato
        //    ContratoBO.EmpleadoContrato.empId = Convert.ToInt64(idEmp);
        //    ContratoBO.EmpleadoContrato.empConId = 1;
        //    ContratoBO.EmpleadoContrato.conId = Convert.ToInt32(cboConContrato.SelectedValue);
        //    ContratoBO.EmpleadoContrato.patId = Convert.ToInt32(cboConPatrono.SelectedValue);
        //    ContratoBO.EmpleadoContrato.empConRazonSale = (cboConRazon.SelectedValue == null) ? "" : cboConRazon.SelectedValue.ToString();
        //    ContratoBO.EmpleadoContrato.empConFirmRenu = (cboConFirma.SelectedValue == null) ? dbType.intNull : Convert.ToUInt16(cboConFirma.SelectedValue);//Convert.ToInt32(cboConFirma.SelectedValue);
        //    ContratoBO.EmpleadoContrato.empConFecLiqui = DateTime.TryParse(mtxtConFechaLiquidacion.Text, out dbType.dateResult) ? dbType.dateResult : dbType.dateNull;
        //    ContratoBO.EmpleadoContrato.empConFirmLiqui = (cboConFirma.SelectedValue == null) ? dbType.intNull : Convert.ToUInt16(cboConFirma.SelectedValue); //d .ToString();
        //    ContratoBO.EmpleadoContrato.empConFecContrato = DateTime.TryParse(mtxtConFechaContrato.Text, out dbType.dateResult) ? dbType.dateResult : dbType.dateNull;  //Convert.ToDateTime(mtxtConFechaContrato.Text);
        //    ContratoBO.EmpleadoContrato.empConObs = txtConObservacion.Text;
        //    ContratoBO.EmpleadoContrato.conCauId = (cboConCausaFin.SelectedValue == null) ? dbType.intNull : Convert.ToInt32(cboConCausaFin.SelectedValue);
        //    resp = ContratoBO.RegistraContrato(ContratoBO.EmpleadoContrato, "I");
        //    //Datos Laborales 
        //    ContratoBO.Laboral.empId = Convert.ToInt64(idEmp);
        //    ContratoBO.Laboral.labId = 2;
        //    ContratoBO.Laboral.locId = Convert.ToInt32(cboLabLocal.SelectedValue);
        //    ContratoBO.Laboral.escId = Convert.ToInt32(cboLabCargo.SelectedValue);
        //    ContratoBO.Laboral.labFecCambEsc = Convert.ToDateTime(mtxtLabFecha.Text);
        //    ContratoBO.Laboral.labSueldoBono = 0;
        //    ContratoBO.Laboral.labObs = txtLabObservacion.Text;
        //    ContratoBO.Laboral.labFecReg = DateTime.Now;
        //    ContratoBO.Laboral.labFecMod = null;
        //    ContratoBO.Laboral.labFecObsSis = "";
        //    ContratoBO.Laboral.labEstado = Convert.ToInt32(cboLabEstado.SelectedValue);
        //    ContratoBO.Laboral.labTipoEmp = Convert.ToInt32(cboLabTipoPago.SelectedValue);
        //    ContratoBO.Laboral.labRbu = Convert.ToInt32(txtLabRBU.Text);
        //    ContratoBO.Laboral.labVest = 0;
        //    ContratoBO.Laboral.labBono = 0;
        //    ContratoBO.Laboral.labQuincena = txtLabQuincena.Text == "" ? 0 : Convert.ToInt32(txtLabQuincena.Text);
        //    resp = ContratoBO.RegistrarInfoLaboral(ContratoBO.Laboral);
        //    //Datos Familiares
        //    //resp = InfoAdditional(Convert.ToInt64(idEmp));
        //    DataTable data;
        //    DataTable dataChange;
        //    resp = UpdateDataEmp(Convert.ToInt64(idEmp), out data, out dataChange);
        //    return resp;
        //}

        //private long InfoAdditional(long resp)
        //{
        //    DataTable data;
        //    DataTable dataChange;
        //    data = new DataTable();
        //    dataChange = new DataTable();
        //    data = (DataTable)dgvFamiliar.DataSource;
        //    dataChange = null;
        //    dataChange = data.GetChanges(DataRowState.Deleted);
        //    if (dataChange != null)
        //    {
        //        foreach (DataRow row in dataChange.Rows)
        //        {
        //            EmpleadoBO.EliminaFamiliar(txtCodigo.Text, row["EMP_FAM_ID", DataRowVersion.Original].ToString());
        //        }
        //    }
        //    dataChange = null;
        //    dataChange = data.GetChanges(DataRowState.Added);
        //    if (dataChange != null)
        //    {
        //        foreach (DataRow row in dataChange.Rows)
        //        {
        //            EmpleadoBO.Familia.empFamNombre = row["EMP_FAM_NOMBRE"].ToString();
        //            EmpleadoBO.Familia.empFamFecNac = Convert.ToDateTime(row["EMP_FAM_FEC_NAC"].ToString());
        //            EmpleadoBO.Familia.empFamParent = row["EMP_FAM_PARENT"].ToString();
        //            EmpleadoBO.Familia.empFamOcup = row["EMP_FAM_OCUP"].ToString();
        //            EmpleadoBO.Familia.empFamTelfRef = row["EMP_FAM_TELF_REF"].ToString();
        //            if (row["EMP_FAM_DISC"].Equals(DBNull.Value))
        //                EmpleadoBO.Familia.empFamDisc = 0;
        //            else
        //                EmpleadoBO.Familia.empFamDisc = Convert.ToInt16(row["EMP_FAM_DISC"].ToString());
        //            EmpleadoBO.Familia.empId = Convert.ToDecimal(txtCodigo.Text);
        //            EmpleadoBO.Familia.empFamId = EmpleadoBO.Familiares(txtCodigo.Text).Rows.Count + 1;
        //            resp = EmpleadoBO.RegistarFamiliar(EmpleadoBO.Familia);
        //        }
        //    }
        //    dataChange = null;
        //    dataChange = data.GetChanges(DataRowState.Modified);
        //    if (dataChange != null)
        //    {
        //        foreach (DataRow row in dataChange.Rows)
        //        {
        //            EmpleadoBO.Familia.empFamNombre = row["EMP_FAM_NOMBRE"].ToString();
        //            EmpleadoBO.Familia.empFamFecNac = Convert.ToDateTime(row["EMP_FAM_FEC_NAC"].ToString());
        //            EmpleadoBO.Familia.empFamParent = row["EMP_FAM_PARENT"].ToString();
        //            EmpleadoBO.Familia.empFamOcup = row["EMP_FAM_OCUP"].ToString();
        //            EmpleadoBO.Familia.empFamTelfRef = row["EMP_FAM_TELF_REF"].ToString();
        //            if (row["EMP_FAM_DISC"].Equals(DBNull.Value))
        //                EmpleadoBO.Familia.empFamDisc = 0;
        //            else
        //                EmpleadoBO.Familia.empFamDisc = Convert.ToInt16(row["EMP_FAM_DISC"].ToString());
        //            EmpleadoBO.Familia.empId = Convert.ToDecimal(txtCodigo.Text);
        //            EmpleadoBO.Familia.empFamId = Convert.ToInt32(row["EMP_FAM_ID"].ToString());
        //            resp = EmpleadoBO.ActualizarFamiliar(EmpleadoBO.Familia);
        //        }
        //    }



        //    //Valores Fijos
        //    data = new DataTable();
        //    dataChange = new DataTable();
        //    data = (DataTable)dgvValor.DataSource;

        //    dataChange = data.GetChanges(DataRowState.Deleted);
        //    if (dataChange != null)
        //    {
        //        foreach (DataRow row in dataChange.Rows)
        //        {
        //            resp = ContratoBO.EliminaValorFijo(txtCodigo.Text, Convert.ToInt32(row["ROL_ID", DataRowVersion.Original].ToString()));
        //        }
        //    }
        //    dataChange = null;
        //    dataChange = data.GetChanges(DataRowState.Added);
        //    if (dataChange != null)
        //    {
        //        foreach (DataRow row in dataChange.Rows)
        //        {
        //            ContratoBO.ValorFijo.rolId = Convert.ToInt32(row["ROL_ID"].ToString());
        //            ContratoBO.ValorFijo.fijValor = Convert.ToInt32(row["FIJ_VALOR"].ToString());
        //            //ContratoBO.ValorFijo.fijEstado = Convert.ToInt16(row["FIJ_ESTADO"].Equals(DBNull.Value));//(row["FIJ_ESTADO"].Equals(DBNull.Value)) ? 0 : 1;
        //            if (row["FIJ_ESTADO"].Equals(DBNull.Value))
        //                ContratoBO.ValorFijo.fijEstado = 0;
        //            else
        //                ContratoBO.ValorFijo.fijEstado = Convert.ToInt16(row["FIJ_ESTADO"].ToString());
        //            ContratoBO.ValorFijo.empId = Convert.ToDecimal(txtCodigo.Text);
        //            resp = ContratoBO.RegistrarValorFijo(ContratoBO.ValorFijo);
        //        }
        //    }
        //    dataChange = null;
        //    dataChange = data.GetChanges(DataRowState.Modified);
        //    if (dataChange != null)
        //    {
        //        foreach (DataRow row in dataChange.Rows)
        //        {
        //            ContratoBO.ValorFijo.rolId = Convert.ToInt32(row["ROL_ID"].ToString());
        //            int auxRolID = Convert.ToInt32(row["ROL_ID", DataRowVersion.Original].ToString());
        //            ContratoBO.ValorFijo.fijValor = Convert.ToInt32(row["FIJ_VALOR"].ToString());
        //            //ContratoBO.ValorFijo.fijEstado = Convert.ToInt16(row["FIJ_ESTADO"].ToString());
        //            if (row["FIJ_ESTADO"].Equals(DBNull.Value))
        //                ContratoBO.ValorFijo.fijEstado = 0;
        //            else
        //                ContratoBO.ValorFijo.fijEstado = Convert.ToInt16(row["FIJ_ESTADO"].ToString());
        //            ContratoBO.ValorFijo.empId = Convert.ToDecimal(txtCodigo.Text);
        //            resp = ContratoBO.ActualizarValorFijo(ContratoBO.ValorFijo, auxRolID);
        //        }
        //    }



        //    return resp;
        //}

        private Int64 RegisterData(int tabID, string tipo)
        {
            Int64 resp = 0;
            DataTable data;
            DataTable dataChange;
            Int64 codigoEMP = 0;

            //Datos Personales
            EmpleadoBO.Empleado.empId = (txtCodigo.Text == string.Empty) ? 0 : Convert.ToInt64(txtCodigo.Text);
            EmpleadoBO.Empleado.empNombre = txtNombre.Text.ToUpper();
            EmpleadoBO.Empleado.empDirec = txtPerDireccion.Text.ToUpper();
            EmpleadoBO.Empleado.empTelefono = txtPerTelefono.Text;
            EmpleadoBO.Empleado.empLugNac = txtPerLugarNac.Text.ToUpper();
            EmpleadoBO.Empleado.labFecIngreso = pPerFechaIngreso.Value;
            EmpleadoBO.Empleado.empFecNac = pPerFechaNac.Value;
            EmpleadoBO.Empleado.empCi = txtPerCedula.Text;
            EmpleadoBO.Empleado.empNumIess = txtPerNumIESS.Text == "" ? "0" : txtPerNumIESS.Text;
            EmpleadoBO.Empleado.empEstCivil = cboPerEstadoCivil.SelectedValue.ToString();
            EmpleadoBO.Empleado.empNumHijos = 0;
            EmpleadoBO.Empleado.empCuenta = txtPerCuentaBanco.Text;
            EmpleadoBO.Empleado.empApellido = txtApellido.Text.ToUpper();
            EmpleadoBO.Empleado.empAfilHumana = 0;
            EmpleadoBO.Empleado.empTelefono2 = txtPerTelefonoSeg.Text;
            EmpleadoBO.Empleado.empTipoCnta = Convert.ToInt32(cboPerTipoCuenta.SelectedValue);
            EmpleadoBO.Empleado.empSexo = Convert.ToInt32(cboPerSexo.SelectedValue);
            EmpleadoBO.Empleado.empSecId = Convert.ToInt32(cboPerSector.SelectedValue);
            EmpleadoBO.Empleado.empBarrio = txtPerBarrio.Text.ToUpper();
            EmpleadoBO.Empleado.empEdu = cboPerEducacion.SelectedValue.ToString();
            EmpleadoBO.Empleado.empDireNumero = txtPerNumero.Text;
            EmpleadoBO.Empleado.empTipSangre = txtPerTipoSangre.Text;
            EmpleadoBO.Empleado.empDiscapacidad = Convert.ToInt32(cboPerDiscapacidad.SelectedValue);
            EmpleadoBO.Empleado.empNumConadis = txtPerNumIdentificacion.Text;
            EmpleadoBO.Empleado.empAfiFarma = 0;
            EmpleadoBO.Empleado.empAfiFarmaFec = dbType.dateNull;
            EmpleadoBO.Empleado.empPagFonRes = Convert.ToInt32(cboPerFondoReserva.SelectedValue);
            EmpleadoBO.Empleado.empPasaporte = txtPerPasaporte.Text;
            EmpleadoBO.Empleado.empMail = txtPerCorreo.Text;
            EmpleadoBO.Empleado.empMailPer = txtPerCorreoPer.Text;
            EmpleadoBO.Empleado.empPagDecTer = Convert.ToInt32(cboPerDecimoTercero.SelectedValue);
            EmpleadoBO.Empleado.empPagDecCua = Convert.ToInt32(cboPerDecimoCuarto.SelectedValue);
            EmpleadoBO.Empleado.empDependientes = 0;
            codigoEMP = resp = EmpleadoBO.RegistarEmpleado(EmpleadoBO.Empleado, tipo);

            //2. Datos Laborales
            ContratoBO.Laboral.empId = Convert.ToInt64(codigoEMP);
            //ContratoBO.Laboral.labId = 2;
            ContratoBO.Laboral.locId = Convert.ToInt32(cboLabLocal.SelectedValue);
            ContratoBO.Laboral.escId = Convert.ToInt32(cboLabCargo.SelectedValue);
            ContratoBO.Laboral.labFecCambEsc = Convert.ToDateTime(mtxtLabFecha.Text);
            ContratoBO.Laboral.labSueldoBono = 0;
            ContratoBO.Laboral.labObs = txtLabObservacion.Text;
            ContratoBO.Laboral.labFecReg = DateTime.Now;
            ContratoBO.Laboral.labFecMod = null;
            ContratoBO.Laboral.labFecObsSis = "";
            ContratoBO.Laboral.labEstado = Convert.ToInt32(cboLabEstado.SelectedValue);
            ContratoBO.Laboral.labTipoEmp = Convert.ToInt32(cboLabTipoPago.SelectedValue);
            ContratoBO.Laboral.labRbu = Convert.ToDecimal(txtLabRBU.Text);
            ContratoBO.Laboral.labVest = 0;
            ContratoBO.Laboral.labBono = 0;
            ContratoBO.Laboral.labQuincena = txtLabQuincena.Text == "" ? 0 : Convert.ToInt32(txtLabQuincena.Text);
            resp = ContratoBO.RegistrarInfoLaboral(ContratoBO.Laboral);

            //Datos de Contrato                   
            ContratoBO.EmpleadoContrato.empId = Convert.ToInt64(codigoEMP);
            //ContratoBO.EmpleadoContrato.empConId = 1;
            ContratoBO.EmpleadoContrato.conId = Convert.ToInt32(cboConContrato.SelectedValue);
            ContratoBO.EmpleadoContrato.patId = Convert.ToInt32(cboConPatrono.SelectedValue);
            ContratoBO.EmpleadoContrato.empConRazonSale = (cboConRazon.SelectedValue == null) ? "" : cboConRazon.SelectedValue.ToString();
            ContratoBO.EmpleadoContrato.empConFirmRenu = (cboConFirma.SelectedValue == null) ? dbType.intNull : Convert.ToUInt16(cboConFirma.SelectedValue); //Convert.ToInt32(cboConFirma.SelectedValue);
            ContratoBO.EmpleadoContrato.empConFecLiqui = DateTime.TryParse(mtxtConFechaLiquidacion.Text, out dbType.dateResult) ? dbType.dateResult : dbType.dateNull;
            ContratoBO.EmpleadoContrato.empConFirmLiqui = (cboConFirma.SelectedValue == null) ? dbType.intNull : Convert.ToUInt16(cboConFirma.SelectedValue);//dbType.intNull;//cboConFirma.SelectedValue.ToString();
            ContratoBO.EmpleadoContrato.empConFecContrato = Convert.ToDateTime(mtxtConFechaContrato.Text);
            ContratoBO.EmpleadoContrato.empConObs = txtConObservacion.Text;
            ContratoBO.EmpleadoContrato.conCauId = (cboConCausaFin.SelectedValue == null) ? dbType.intNull : Convert.ToInt32(cboConCausaFin.SelectedValue);
            resp = ContratoBO.RegistraContrato(ContratoBO.EmpleadoContrato, tipo);


            //3. Datos Familiares
            if (tabID.Equals(1))
                resp = UpdateDataEmp(codigoEMP, out data);
            else
                resp = UpdateDataEmp(codigoEMP, out data, out dataChange);


            //4. Valores Fijos
            //resp = UpdateDataEmp(resp, out data, out dataChange);


            //switch (tabID)
            //{
            //    case 0://Datos Personales
            //        EmpleadoBO.Empleado.empId = (txtCodigo.Text == string.Empty) ? 0 : Convert.ToInt64(txtCodigo.Text);
            //        EmpleadoBO.Empleado.empNombre = txtNombre.Text.ToUpper();
            //        EmpleadoBO.Empleado.empDirec = txtPerDireccion.Text.ToUpper();
            //        EmpleadoBO.Empleado.empTelefono = txtPerTelefono.Text;
            //        EmpleadoBO.Empleado.empLugNac = txtPerLugarNac.Text.ToUpper();
            //        EmpleadoBO.Empleado.labFecIngreso = pPerFechaIngreso.Value;
            //        EmpleadoBO.Empleado.empFecNac = pPerFechaNac.Value;
            //        EmpleadoBO.Empleado.empCi = txtPerCedula.Text;
            //        EmpleadoBO.Empleado.empNumIess = txtPerNumIESS.Text==""?"0": txtPerNumIESS.Text;
            //        EmpleadoBO.Empleado.empEstCivil = cboPerEstadoCivil.SelectedValue.ToString();
            //        EmpleadoBO.Empleado.empNumHijos = 0;
            //        EmpleadoBO.Empleado.empCuenta = txtPerCuentaBanco.Text;
            //        EmpleadoBO.Empleado.empApellido = txtApellido.Text.ToUpper();
            //        EmpleadoBO.Empleado.empAfilHumana = 0;
            //        EmpleadoBO.Empleado.empTelefono2 = txtPerTelefonoSeg.Text;
            //        EmpleadoBO.Empleado.empTipoCnta = Convert.ToInt32(cboPerTipoCuenta.SelectedValue);
            //        EmpleadoBO.Empleado.empSexo = Convert.ToInt32(cboPerSexo.SelectedValue);
            //        EmpleadoBO.Empleado.empSecId = Convert.ToInt32(cboPerSector.SelectedValue);
            //        EmpleadoBO.Empleado.empBarrio = txtPerBarrio.Text.ToUpper();
            //        EmpleadoBO.Empleado.empEdu = cboPerEducacion.SelectedValue.ToString();
            //        EmpleadoBO.Empleado.empDireNumero = txtPerNumero.Text;
            //        EmpleadoBO.Empleado.empTipSangre = txtPerTipoSangre.Text;
            //        EmpleadoBO.Empleado.empDiscapacidad = Convert.ToInt32(cboPerDiscapacidad.SelectedValue);
            //        EmpleadoBO.Empleado.empNumConadis = txtPerNumIdentificacion.Text;
            //        EmpleadoBO.Empleado.empAfiFarma = 0;
            //        EmpleadoBO.Empleado.empAfiFarmaFec = dbType.dateNull;
            //        EmpleadoBO.Empleado.empPagFonRes = Convert.ToInt32(cboPerFondoReserva.SelectedValue);
            //        EmpleadoBO.Empleado.empPasaporte = txtPerPasaporte.Text;
            //        EmpleadoBO.Empleado.empMail = txtPerCorreo.Text;
            //        EmpleadoBO.Empleado.empMailPer = txtPerCorreoPer.Text;
            //        EmpleadoBO.Empleado.empPagDecTer = Convert.ToInt32(cboPerDecimoTercero.SelectedValue);
            //        EmpleadoBO.Empleado.empPagDecCua = Convert.ToInt32(cboPerDecimoCuarto.SelectedValue);
            //        EmpleadoBO.Empleado.empDependientes = 0;
            //        resp = EmpleadoBO.RegistarEmpleado(EmpleadoBO.Empleado, tipo);
            //        break;
            //    case 1://Datos de Contrato                   
            //        ContratoBO.EmpleadoContrato.empId = Convert.ToInt64(txtCodigo.Text);
            //        ContratoBO.EmpleadoContrato.empConId = 1;
            //        ContratoBO.EmpleadoContrato.conId = Convert.ToInt32(cboConContrato.SelectedValue);
            //        ContratoBO.EmpleadoContrato.patId = Convert.ToInt32(cboConPatrono.SelectedValue);
            //        ContratoBO.EmpleadoContrato.empConRazonSale = (cboConRazon.SelectedValue == null) ? "" : cboConRazon.SelectedValue.ToString();
            //        ContratoBO.EmpleadoContrato.empConFirmRenu = (cboConFirma.SelectedValue == null) ? dbType.intNull : Convert.ToUInt16(cboConFirma.SelectedValue); //Convert.ToInt32(cboConFirma.SelectedValue);
            //        ContratoBO.EmpleadoContrato.empConFecLiqui = DateTime.TryParse(mtxtConFechaLiquidacion.Text, out dbType.dateResult) ? dbType.dateResult : dbType.dateNull;
            //        ContratoBO.EmpleadoContrato.empConFirmLiqui = (cboConFirma.SelectedValue == null) ? dbType.intNull : Convert.ToUInt16(cboConFirma.SelectedValue);//dbType.intNull;//cboConFirma.SelectedValue.ToString();
            //        ContratoBO.EmpleadoContrato.empConFecContrato = Convert.ToDateTime(mtxtConFechaContrato.Text);
            //        ContratoBO.EmpleadoContrato.empConObs = txtConObservacion.Text;
            //        ContratoBO.EmpleadoContrato.conCauId = (cboConCausaFin.SelectedValue == null) ? dbType.intNull : Convert.ToInt32(cboConCausaFin.SelectedValue);
            //        resp = ContratoBO.RegistraContrato(ContratoBO.EmpleadoContrato, tipo);
            //        break;
            //    case 2://Datos Laborales
            //        ContratoBO.Laboral.empId = Convert.ToInt64(txtCodigo.Text);
            //        ContratoBO.Laboral.labId = 2;
            //        ContratoBO.Laboral.locId = Convert.ToInt32(cboLabLocal.SelectedValue);
            //        ContratoBO.Laboral.escId = Convert.ToInt32(cboLabCargo.SelectedValue);
            //        ContratoBO.Laboral.labFecCambEsc = Convert.ToDateTime(mtxtLabFecha.Text);
            //        ContratoBO.Laboral.labSueldoBono = 0;
            //        ContratoBO.Laboral.labObs = txtLabObservacion.Text;
            //        ContratoBO.Laboral.labFecReg = DateTime.Now;
            //        ContratoBO.Laboral.labFecMod = null;
            //        ContratoBO.Laboral.labFecObsSis = "";
            //        ContratoBO.Laboral.labEstado = Convert.ToInt32(cboLabEstado.SelectedValue);
            //        ContratoBO.Laboral.labTipoEmp = Convert.ToInt32(cboLabTipoPago.SelectedValue);
            //        ContratoBO.Laboral.labRbu = Convert.ToDecimal(txtLabRBU.Text);
            //        ContratoBO.Laboral.labVest = 0;
            //        ContratoBO.Laboral.labBono = 0;
            //        ContratoBO.Laboral.labQuincena = txtLabQuincena.Text==""? 0 : Convert.ToInt32(txtLabQuincena.Text);
            //        resp = ContratoBO.RegistrarInfoLaboral(ContratoBO.Laboral);
            //        break;
            //    case 3://Datos Familiares
            //        resp = UpdateDataEmp(resp, out data, out dataChange);
            //        break;

            //    case 4://Valores Fijos
            //        resp = UpdateDataEmp(resp, out data, out dataChange);                    
            //        break;               
            //}

            return codigoEMP; //resp;
        }

        private long UpdateDataEmp(long codigoEMP, out DataTable data)
        {
            long resp = 0;
            data = new DataTable();
            data = (DataTable)dgvFamiliar.DataSource;
            if (data != null)
            {
                foreach (DataRow row in data.Rows)
                {
                    EmpleadoBO.Familia.empFamNombre = row["EMP_FAM_NOMBRE"].ToString();
                    EmpleadoBO.Familia.empFamFecNac = Convert.ToDateTime(row["EMP_FAM_FEC_NAC"].ToString());
                    EmpleadoBO.Familia.empFamParent = row["EMP_FAM_PARENT"].ToString();
                    EmpleadoBO.Familia.empFamOcup = row["EMP_FAM_OCUP"].ToString();
                    EmpleadoBO.Familia.empFamTelfRef = row["EMP_FAM_TELF_REF"].ToString();
                    if (row["EMP_FAM_DISC"].Equals(DBNull.Value))
                        EmpleadoBO.Familia.empFamDisc = 0;
                    else
                        EmpleadoBO.Familia.empFamDisc = Convert.ToInt16(row["EMP_FAM_DISC"].ToString());
                    EmpleadoBO.Familia.empId = Convert.ToDecimal(codigoEMP);
                    EmpleadoBO.Familia.empFamId = EmpleadoBO.Familiares(codigoEMP.ToString()).Rows.Count + 1;
                    resp = EmpleadoBO.RegistarFamiliar(EmpleadoBO.Familia);
                }
            }
            ////////////////////////////////////////////
            data = new DataTable();
            data = (DataTable)dgvValor.DataSource;
            if (data != null)
            {
                foreach (DataRow row in data.Rows)
                {
                    ContratoBO.ValorFijo.rolId = Convert.ToInt32(row["ROL_ID"].ToString());
                    ContratoBO.ValorFijo.fijValor = Convert.ToInt32(row["FIJ_VALOR"].ToString());
                    //ContratoBO.ValorFijo.fijEstado = Convert.ToInt16(row["FIJ_ESTADO"].Equals(DBNull.Value));//(row["FIJ_ESTADO"].Equals(DBNull.Value)) ? 0 : 1;
                    if (row["FIJ_ESTADO"].Equals(DBNull.Value))
                        ContratoBO.ValorFijo.fijEstado = 0;
                    else
                        ContratoBO.ValorFijo.fijEstado = Convert.ToInt16(row["FIJ_ESTADO"].ToString());
                    ContratoBO.ValorFijo.empId = Convert.ToDecimal(codigoEMP);
                    resp = ContratoBO.RegistrarValorFijo(ContratoBO.ValorFijo);
                }
            }
            return resp;
        }

        private long UpdateDataEmp(long codigoEMP, out DataTable data, out DataTable dataChange)
        {
            long resp = 0;
            data = new DataTable();
            dataChange = new DataTable();
            data = (DataTable)dgvFamiliar.DataSource;
            dataChange = null;
            if (data != null)
                dataChange = data.GetChanges(DataRowState.Deleted);
            if (dataChange != null)
            {
                foreach (DataRow row in dataChange.Rows)
                {
                    EmpleadoBO.EliminaFamiliar(codigoEMP.ToString(), row["EMP_FAM_ID", DataRowVersion.Original].ToString());
                }
            }
            dataChange = null;
            if (data != null)
                dataChange = data.GetChanges(DataRowState.Added);
            if (dataChange != null)
            {
                foreach (DataRow row in dataChange.Rows)
                {
                    EmpleadoBO.Familia.empFamNombre = row["EMP_FAM_NOMBRE"].ToString();
                    EmpleadoBO.Familia.empFamFecNac = Convert.ToDateTime(row["EMP_FAM_FEC_NAC"].ToString());
                    EmpleadoBO.Familia.empFamParent = row["EMP_FAM_PARENT"].ToString();
                    EmpleadoBO.Familia.empFamOcup = row["EMP_FAM_OCUP"].ToString();
                    EmpleadoBO.Familia.empFamTelfRef = row["EMP_FAM_TELF_REF"].ToString();
                    if (row["EMP_FAM_DISC"].Equals(DBNull.Value))
                        EmpleadoBO.Familia.empFamDisc = 0;
                    else
                        EmpleadoBO.Familia.empFamDisc = Convert.ToInt16(row["EMP_FAM_DISC"].ToString());
                    EmpleadoBO.Familia.empId = Convert.ToDecimal(codigoEMP);
                    EmpleadoBO.Familia.empFamId = EmpleadoBO.Familiares(codigoEMP.ToString()).Rows.Count + 1;
                    resp = EmpleadoBO.RegistarFamiliar(EmpleadoBO.Familia);
                }
            }
            dataChange = null;
            if (data != null)
                dataChange = data.GetChanges(DataRowState.Modified);
            if (dataChange != null)
            {
                foreach (DataRow row in dataChange.Rows)
                {
                    EmpleadoBO.Familia.empFamNombre = row["EMP_FAM_NOMBRE"].ToString();
                    EmpleadoBO.Familia.empFamFecNac = Convert.ToDateTime(row["EMP_FAM_FEC_NAC"].ToString());
                    EmpleadoBO.Familia.empFamParent = row["EMP_FAM_PARENT"].ToString();
                    EmpleadoBO.Familia.empFamOcup = row["EMP_FAM_OCUP"].ToString();
                    EmpleadoBO.Familia.empFamTelfRef = row["EMP_FAM_TELF_REF"].ToString();
                    if (row["EMP_FAM_DISC"].Equals(DBNull.Value))
                        EmpleadoBO.Familia.empFamDisc = 0;
                    else
                        EmpleadoBO.Familia.empFamDisc = Convert.ToInt16(row["EMP_FAM_DISC"].ToString());
                    EmpleadoBO.Familia.empId = Convert.ToDecimal(codigoEMP);
                    EmpleadoBO.Familia.empFamId = Convert.ToInt32(row["EMP_FAM_ID"].ToString());
                    resp = EmpleadoBO.ActualizarFamiliar(EmpleadoBO.Familia);
                }

            }


            ////////////////////////////////////////////
            data = new DataTable();
            dataChange = new DataTable();
            data = (DataTable)dgvValor.DataSource;
            dataChange = null;
            if (data != null)
                dataChange = data.GetChanges(DataRowState.Deleted);
            if (dataChange != null)
            {
                foreach (DataRow row in dataChange.Rows)
                {
                    resp = ContratoBO.EliminaValorFijo(codigoEMP.ToString(), Convert.ToInt32(row["ROL_ID", DataRowVersion.Original].ToString()));
                }
            }
            dataChange = null;
            if (data != null)
                dataChange = data.GetChanges(DataRowState.Added);
            if (dataChange != null)
            {
                foreach (DataRow row in dataChange.Rows)
                {
                    ContratoBO.ValorFijo.rolId = Convert.ToInt32(row["ROL_ID"].ToString());
                    ContratoBO.ValorFijo.fijValor = Convert.ToDecimal(row["FIJ_VALOR"].ToString());
                    //ContratoBO.ValorFijo.fijEstado = Convert.ToInt16(row["FIJ_ESTADO"].Equals(DBNull.Value));//(row["FIJ_ESTADO"].Equals(DBNull.Value)) ? 0 : 1;
                    if (row["FIJ_ESTADO"].Equals(DBNull.Value))
                        ContratoBO.ValorFijo.fijEstado = 0;
                    else
                        ContratoBO.ValorFijo.fijEstado = Convert.ToInt16(row["FIJ_ESTADO"].ToString());
                    ContratoBO.ValorFijo.empId = Convert.ToDecimal(codigoEMP);
                    resp = ContratoBO.RegistrarValorFijo(ContratoBO.ValorFijo);
                }
            }
            dataChange = null;
            if (data != null)
                dataChange = data.GetChanges(DataRowState.Modified);
            if (dataChange != null)
            {
                foreach (DataRow row in dataChange.Rows)
                {
                    ContratoBO.ValorFijo.rolId = Convert.ToInt32(row["ROL_ID"].ToString());
                    int auxRolID = Convert.ToInt32(row["ROL_ID", DataRowVersion.Original].ToString());
                    ContratoBO.ValorFijo.fijValor = Convert.ToDecimal(row["FIJ_VALOR"].ToString());
                    //ContratoBO.ValorFijo.fijEstado = Convert.ToInt16(row["FIJ_ESTADO"].ToString());
                    if (row["FIJ_ESTADO"].Equals(DBNull.Value))
                        ContratoBO.ValorFijo.fijEstado = 0;
                    else
                        ContratoBO.ValorFijo.fijEstado = Convert.ToInt16(row["FIJ_ESTADO"].ToString());
                    ContratoBO.ValorFijo.empId = Convert.ToDecimal(codigoEMP.ToString());
                    resp = ContratoBO.ActualizarValorFijo(ContratoBO.ValorFijo, auxRolID);
                }
            }
            return resp;
        }

        private void AssignData(string idRecord)
        {
            DataTable data = new DataTable();
            data = EmpleadoBO.ListaEmpleado(idRecord);
            if (data.Rows.Count > 0)
            {
                EmpleadoBO.Empleado = new Entity.DatEmp();
                EmpleadoBO.Empleado.empId = Convert.ToInt64(data.Rows[0]["EMP_ID"].ToString());
                EmpleadoBO.Empleado.empCi = data.Rows[0]["EMP_CI"].ToString();
                EmpleadoBO.Empleado.empNombre = data.Rows[0]["EMP_NOMBRE"].ToString();
                EmpleadoBO.Empleado.empApellido = data.Rows[0]["EMP_APELLIDO"].ToString();
                EmpleadoBO.Empleado.empNumIess = data.Rows[0]["EMP_NUM_IESS"].ToString();
                EmpleadoBO.Empleado.empCuenta = data.Rows[0]["EMP_CUENTA"].ToString();
                EmpleadoBO.Empleado.empPasaporte = data.Rows[0]["EMP_PASAPORTE"].ToString();
                EmpleadoBO.Empleado.empPagFonRes = Convert.ToInt32(data.Rows[0]["EMP_PAG_FON_RES"].ToString());
                EmpleadoBO.Empleado.empTipoCnta = Convert.ToInt32(data.Rows[0]["EMP_TIPO_CNTA"].ToString());
                EmpleadoBO.Empleado.empNumConadis = data.Rows[0]["EMP_NUM_CONADIS"].ToString();
                EmpleadoBO.Empleado.empPagDecTer = Convert.ToInt32(data.Rows[0]["EMP_PAG_DEC_TER"].ToString());
                EmpleadoBO.Empleado.empPagDecCua = Convert.ToInt32(data.Rows[0]["EMP_PAG_DEC_CUA"].ToString());
                EmpleadoBO.Empleado.empBarrio = data.Rows[0]["EMP_BARRIO"].ToString();
                EmpleadoBO.Empleado.empDirec = data.Rows[0]["EMP_DIREC"].ToString();
                EmpleadoBO.Empleado.empTelefono = data.Rows[0]["EMP_TELEFONO"].ToString();
                EmpleadoBO.Empleado.empSecId = (data.Rows[0]["EMP_SEC_ID"] == DBNull.Value ? -1 : Convert.ToInt32(data.Rows[0]["EMP_SEC_ID"].ToString()));
                EmpleadoBO.Empleado.empDireNumero = data.Rows[0]["EMP_DIRE_NUMERO"].ToString();
                EmpleadoBO.Empleado.empTelefono2 = data.Rows[0]["EMP_TELEFONO2"].ToString();
                EmpleadoBO.Empleado.empLugNac = data.Rows[0]["EMP_LUG_NAC"].ToString();
                EmpleadoBO.Empleado.empFecNac = Convert.ToDateTime(data.Rows[0]["EMP_FEC_NAC"].ToString());
                EmpleadoBO.Empleado.empSexo = Convert.ToInt32(data.Rows[0]["EMP_SEXO"].ToString());
                EmpleadoBO.Empleado.empEdu = data.Rows[0]["EMP_EDU"].ToString();
                EmpleadoBO.Empleado.empFecSeg = data.Rows[0]["EMP_FEC_SEG"].ToString();
                EmpleadoBO.Empleado.empEstCivil = data.Rows[0]["EMP_EST_CIVIL"].ToString();
                EmpleadoBO.Empleado.empTipSangre = data.Rows[0]["EMP_TIP_SANGRE"].ToString();
                DateTime dateResult;
                EmpleadoBO.Empleado.empFecSalidareal = DateTime.TryParse(data.Rows[0]["EMP_FEC_SALIDAREAL"].ToString(), out dateResult) ? dateResult : dbType.dateNull;//Convert.ToDateTime("01/01/9999");
                EmpleadoBO.Empleado.labFecIngreso = DateTime.TryParse(data.Rows[0]["LAB_FEC_INGRESO"].ToString(), out dateResult) ? dateResult : dbType.dateNull;//Convert.ToDateTime("01/01/9999");
                EmpleadoBO.Empleado.empFecSalida = DateTime.TryParse(data.Rows[0]["EMP_FEC_SALIDA"].ToString(), out dateResult) ? dateResult : dbType.dateNull; //Convert.ToDateTime("01/01/9999");
                EmpleadoBO.Empleado.empFecReg = DateTime.TryParse(data.Rows[0]["EMP_FEC_REG"].ToString(), out dateResult) ? dateResult : Convert.ToDateTime("01/01/9999");
                EmpleadoBO.Empleado.empFecMod = DateTime.TryParse(data.Rows[0]["EMP_FEC_MOD"].ToString(), out dateResult) ? dateResult : Convert.ToDateTime("01/01/9999");
                EmpleadoBO.Empleado.empDiscapacidad = Convert.ToInt32(data.Rows[0]["EMP_DISCAPACIDAD"].ToString());
                EmpleadoBO.Empleado.empMail = data.Rows[0]["EMP_MAIL"].ToString();
                EmpleadoBO.Empleado.empMailPer = data.Rows[0]["EMP_MAIL_PER"].ToString();
            }
            //Datos Contrato
            DataTable Contrato = new DataTable();
            Contrato = ContratoBO.ContratoEmpleado(idRecord);
            if (Contrato.Rows.Count > 0)
            {
                ContratoBO.EmpleadoContrato = new Entity.DatEmpCon();
                ContratoBO.EmpleadoContrato.empId = EmpleadoBO.Empleado.empId;
                ContratoBO.EmpleadoContrato.empConId = Convert.ToInt16(Contrato.Rows[0]["EMP_CON_ID"]);
                ContratoBO.EmpleadoContrato.conId = Contrato.Rows[0]["CON_ID"] == DBNull.Value ? -1 : Convert.ToInt32(Contrato.Rows[0]["CON_ID"].ToString());
                ContratoBO.EmpleadoContrato.patId = Contrato.Rows[0]["PAT_ID"] == DBNull.Value ? -1 : Convert.ToInt32(Contrato.Rows[0]["PAT_ID"].ToString());
                ContratoBO.EmpleadoContrato.empConRazonSale = Contrato.Rows[0]["EMP_CON_RAZON_SALE"].ToString();
                ContratoBO.EmpleadoContrato.empConFirmRenu = Contrato.Rows[0]["EMP_CON_FIRM_RENU"] == DBNull.Value ? -1 : Convert.ToInt32(Contrato.Rows[0]["EMP_CON_FIRM_RENU"].ToString());
                DateTime dateResult;
                ContratoBO.EmpleadoContrato.empConFecLiqui = DateTime.TryParse(Contrato.Rows[0]["EMP_CON_FEC_LIQUI"].ToString(), out dateResult) ? dateResult : dbType.dateNull;
                ContratoBO.EmpleadoContrato.empConFirmLiqui = Contrato.Rows[0]["EMP_CON_FIRM_LIQUI"] == DBNull.Value ? dbType.intNull : Convert.ToInt32(Contrato.Rows[0]["EMP_CON_FIRM_LIQUI"]);
                ContratoBO.EmpleadoContrato.empConFecContrato = DateTime.TryParse(Contrato.Rows[0]["EMP_CON_FEC_CONTRATO"].ToString(), out dateResult) ? dateResult : Convert.ToDateTime("01/01/9999");
                ContratoBO.EmpleadoContrato.empConObs = Contrato.Rows[0]["EMP_CON_OBS"].ToString();
                ContratoBO.EmpleadoContrato.conCauId = Contrato.Rows[0]["CON_CAU_ID"] == DBNull.Value ? -1 : Convert.ToInt32(Contrato.Rows[0]["CON_CAU_ID"]);
                ContratoBO.EmpleadoContrato.empConFecReg = DateTime.TryParse(Contrato.Rows[0]["EMP_CON_FEC_REG"].ToString(), out dateResult) ? dateResult : Convert.ToDateTime("01/01/9999");
                ContratoBO.EmpleadoContrato.empConFecMod = DateTime.TryParse(Contrato.Rows[0]["EMP_CON_FEC_MOD"].ToString(), out dateResult) ? dateResult : Convert.ToDateTime("01/01/9999");
            }

            //Datos Laborales
            DataTable InfoLaboral = new DataTable();
            InfoLaboral = ContratoBO.InfoLaboral(idRecord);
            if (InfoLaboral.Rows.Count != 0)
            {
                ContratoBO.Laboral = new Entity.DatLab();
                ContratoBO.Laboral.empId = EmpleadoBO.Empleado.empId;
                ContratoBO.Laboral.labId = Convert.ToInt32(InfoLaboral.Rows[0]["LAB_ID"]);
                ContratoBO.Laboral.locId = Convert.ToInt32(InfoLaboral.Rows[0]["LOC_ID"]);
                ContratoBO.Laboral.escId = Convert.ToInt32(InfoLaboral.Rows[0]["ESC_ID"]);
                DateTime dateResult;
                ContratoBO.Laboral.labFecCambEsc = DateTime.TryParse(InfoLaboral.Rows[0]["LAB_FEC_CAMB_ESC"].ToString(), out dateResult) ? dateResult : dbType.dateNull; ;
                ContratoBO.Laboral.labSueldoBono = InfoLaboral.Rows[0]["LAB_SUELDO_BONO"] == DBNull.Value ? 0 : Convert.ToDecimal(InfoLaboral.Rows[0]["LAB_SUELDO_BONO"]);
                ContratoBO.Laboral.labObs = InfoLaboral.Rows[0]["LAB_OBS"].ToString();
                ContratoBO.Laboral.labFecReg = DateTime.TryParse(InfoLaboral.Rows[0]["LAB_FEC_REG"].ToString(), out dateResult) ? dateResult : Convert.ToDateTime("01/01/9999");
                ContratoBO.Laboral.labFecMod = DateTime.TryParse(InfoLaboral.Rows[0]["LAB_FEC_MOD"].ToString(), out dateResult) ? dateResult : Convert.ToDateTime("01/01/9999");
                ContratoBO.Laboral.labFecObsSis = InfoLaboral.Rows[0]["LAB_FEC_OBS_SIS"].ToString();
                ContratoBO.Laboral.labEstado = Convert.ToInt32(InfoLaboral.Rows[0]["LAB_ESTADO"]);
                ContratoBO.Laboral.labTipoEmp = Convert.ToInt32(InfoLaboral.Rows[0]["LAB_TIPO_EMP"]);
                ContratoBO.Laboral.labRbu = Convert.ToDecimal(InfoLaboral.Rows[0]["LAB_RBU"]);
                ContratoBO.Laboral.labVest = Convert.ToDecimal(InfoLaboral.Rows[0]["LAB_VEST"]);
                ContratoBO.Laboral.labBono = Convert.ToDecimal(InfoLaboral.Rows[0]["LAB_BONO"]);
                ContratoBO.Laboral.labQuincena = Convert.ToDecimal(InfoLaboral.Rows[0]["LAB_QUINCENA"]);
            }

            LoadControls();
        }

        private void CorrerProceso()
        {
            //Hacer que se tarde 10000 milisegundos (10 segundos) 
            Thread.Sleep(10000);
            MessageBox.Show("Proceso finalizado");
        }

        #endregion

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            ClearControls(tabInformacion.SelectedIndex);
            ActiveControls(false, tabInformacion.SelectedIndex);
            Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
        }

        private void frmEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;

        }
        private void btnListaDiscapacidad_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Equals(string.Empty))
                return;

            frmDiscapacidad frm = new frmDiscapacidad(txtCodigo.Text);
            Design.frmDialog(frm, "Discapacitación");
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            var frm = new frmEmpleadoLista();
            frm.ShowDialog();
            AssignData(EmpleadoBO.Empleado.empId.ToString());

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabAdmin.SelectTab(0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {

            if (this.btnNewSave.Text == "&Nuevo")
            {
                StateButton = Acction.New;
                ClearControls(tabInformacion.SelectedIndex);
                ActiveControls(true, tabInformacion.SelectedIndex);
                tabInformacion.SelectedIndex = 0;
                txtNombre.Focus();
            }
            else
            {
                if (ValidateControls(tabInformacion.SelectedIndex))
                {

                    Int64 idRecord = 0;
                    EmpNewID = string.Empty;
                    if (StateButton == Acction.New)
                    {
                        int numIngreso = 0;
                        numIngreso = EmpleadoBO.ValidaEmpleadoEmpresa(txtPerCedula.Text);
                        if (numIngreso == 0)
                        {
                            DataTable empEmpresa = new DataTable();
                            empEmpresa = EmpleadoBO.ListaEmpleadoCI(txtPerCedula.Text);
                            numIngreso = EmpleadoBO.ValidaEmpleadoSalidaEmpresa(txtPerCedula.Text, cboConPatrono.SelectedValue.ToString());
                            if (numIngreso == 0)
                            {
                                numIngreso = EmpleadoBO.ValidaEmpleadoEmpresa(txtPerCedula.Text, cboConPatrono.SelectedValue.ToString());
                                if (numIngreso > 1)
                                {
                                    Utility.MensajeError("No es posible registrar más de dos ingresos!!");
                                    return;
                                }
                                else
                                {
                                    if (EmpleadoBO.ValidaEmpleadoActivo(txtPerCedula.Text, cboConPatrono.SelectedValue.ToString()).Equals(0))
                                    {
                                        string[] fecha = EmpleadoBO.ValidaFechaIngreso(txtCodigo.Text);

                                        if (!(Convert.ToDateTime(pPerFechaIngreso.Value.ToShortDateString()).Date >= Convert.ToDateTime(fecha[0].ToString()).Date & Convert.ToDateTime(pPerFechaIngreso.Value.ToShortDateString()).Date <= Convert.ToDateTime(fecha[1].ToString()).Date))
                                        {
                                            tabInformacion.SelectedIndex = 0;
                                            ErrProv.SetError(pPerFechaIngreso, "La fecha de ingreso debe estar entre: " + fecha[0].ToString() + " - " + fecha[1].ToString());
                                            return;
                                        }
                                        else
                                        {
                                            ErrProv.Clear();
                                            idRecord = RegisterData(0, "I");
                                            if (idRecord != 0)
                                            {
                                                EmpNewID = idRecord.ToString();
                                                //idRecord = RegisterData(idRecord.ToString());
                                                AssignData(EmpNewID);
                                                StateButton = Acction.Save;
                                                ActiveControls(false, tabInformacion.SelectedIndex);
                                                Utility.MensajeInfo("Registro Exitoso!!");
                                            }
                                            else
                                            {
                                                Utility.MensajeError("Error al registrar la información!!");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Utility.MensajeError("El empleado ya se encuentra registrado en estado ACTIVO!!");
                                        return;

                                    }
                                }
                            }
                            else
                            {
                                Utility.MensajeError("El Empleado ya se encuentra registrado en esta empresa en estado ACTIVO..!!");
                                ErrProv.SetError(cboConPatrono, "Verifique la empresa)");
                                tabInformacion.SelectedIndex = 1;
                                return;
                            }
                        }
                        else
                        {
                            Utility.MensajeError("Ya existe un registro de esta cédula!!");
                        }

                    }

                    if (StateButton == Acction.Edit)
                    {
                        idRecord = RegisterData(tabInformacion.SelectedIndex, "U");
                        EmpNewID = txtCodigo.Text;
                        AssignData(EmpNewID);
                        StateButton = Acction.Save;
                        ActiveControls(false, tabInformacion.SelectedIndex);
                        Utility.MensajeInfo("Registro Exitoso!!");
                    }
                }
                else
                    return;
            }
            Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (this.btnEditCancel.Text == "&Editar")
            {
                StateButton = Acction.Edit;
                ActiveControls(true, tabInformacion.SelectedIndex);
                pPerFechaIngreso.Enabled = false;
            }
            else
            {
                StateButton = Acction.Cancel;
                ClearControls(tabInformacion.SelectedIndex);
                ActiveControls(false, tabInformacion.SelectedIndex);
            }
            Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == Utility.MensajeQuestion("¿Desea Eliminar al empleado?"))
            {
                EmpleadoBO.DeleteEmpleado(txtCodigo.Text);
            }
        }

        private void btnNotifica_Click(object sender, EventArgs e)
        {
            if (!txtCodigo.Text.Equals(string.Empty))
            {
                DataTable data = new DataTable();
                data = EmpleadoBO.ListaEmpleado(txtCodigo.Text);
                if (Utility.isDate(data.Rows[0]["EMP_FEC_SALIDAREAL"].ToString()) & Utility.isDate(data.Rows[0]["EMP_FEC_SALIDA"].ToString()))
                {
                    if (txtPerCorreoPer.Text != string.Empty)
                    {
                        if (DialogResult.Yes == Utility.MensajeQuestion("¿Desea enviar notificación de Liquidación?"))
                        {

                            object[,] emailVars = new object[,] { { "[@apellido]" , txtApellido.Text.ToUpper() },
                                                              { "[@nombre]" , txtNombre.Text.ToUpper() }                                                };
                            string message = SistemaBO.emailMessage("LIQUIDACION", emailVars);

                            if (SistemaBO.sendEmail(txtPerCorreoPer.Text, "Notificación de proceso de Liquidación", message))
                                Utility.MensajeOK("Notificación Enviada..!!");
                            else
                                Utility.MensajeError("Notificación Fallida..!!");
                        }
                    }
                    else
                        Utility.MensajeInfo("Verifique el correo electrónico del Empleado.");
                }
                else
                    Utility.MensajeInfo("El empleado no tiene registrada una fecha de salida.");
            }
        }

        private void btnReingreso_Click(object sender, EventArgs e)
        {
            if (!txtCodigo.Text.Equals(string.Empty))
            {
                DataTable data = new DataTable();
                string empID = txtCodigo.Text;
                data = EmpleadoBO.ListaEmpleado(empID);
                if (data.Rows.Count > 0)
                {
                    if (Utility.isDate(data.Rows[0]["EMP_FEC_SALIDAREAL"].ToString()) | Utility.isDate(data.Rows[0]["EMP_FEC_SALIDA"].ToString()))
                    {

                        if (btnReingreso.Text == "&Reingreso")
                        {
                            ActiveControls(true, tabInformacion.SelectedIndex);
                            btnNewSave.Visible = false;
                            btnEditCancel.Visible = false;
                            txtPerCedula.ReadOnly = true;
                            //Datos Contrato            
                            mtxtConFechaContrato.Text = string.Empty;
                            mtxtConFechaLiquidacion.Text = string.Empty;
                            mtxtFechaSalida.Text = string.Empty;
                            txtPerFechaSalidaDif.Text = string.Empty;
                            cboConRazon.SelectedValue = -1;
                            cboConFirma.SelectedValue = -1;
                            cboConCausaFin.SelectedValue = -1;
                            txtConObservacion.Text = string.Empty;
                            cboConContrato.SelectedValue = -1;
                            cboConPatrono.SelectedValue = -1;
                            txtConFechaIng.Text = string.Empty;
                            txtConFechaMod.Text = string.Empty;
                            //Datos Laborales
                            mtxtLabFecha.Text = string.Empty;
                            cboLabLocal.SelectedIndex = -1;
                            cboLabCargo.SelectedIndex = -1;
                            cboLabEstado.SelectedIndex = -1;
                            cboLabTipoPago.SelectedIndex = -1;
                            txtLabRBU.Text = string.Empty;
                            txtLabQuincena.Text = string.Empty;
                            txtLabObservacion.Text = string.Empty;
                            txtLabObservacionSis.Text = string.Empty;
                            txtLabFechaReg.Text = string.Empty;
                            txtLabFechaMod.Text = string.Empty;
                            btnReingreso.Text = "&Aceptar";
                            this.btnReingreso.ImageIndex = 21;
                        }
                        else
                        {
                            if (ValidateControls(tabInformacion.SelectedIndex))
                            {
                                int numIngreso = EmpleadoBO.ValidaEmpleadoEmpresa(txtPerCedula.Text, cboConPatrono.SelectedValue.ToString());
                                if (numIngreso > 1)
                                {
                                    Utility.MensajeError("No es posible registrar al empleado, ya tiene " + numIngreso.ToString() + " reingresos en la misma empresa!!");
                                    return;
                                }
                                else
                                {
                                    if (EmpleadoBO.ValidaEmpleadoActivo(txtPerCedula.Text, cboConPatrono.SelectedValue.ToString()).Equals(0))
                                    {
                                        EmpNewID = string.Empty;

                                        if (ValidateControls(tabInformacion.SelectedIndex))
                                        {
                                            if (DialogResult.Yes == Utility.MensajeQuestion("¿Desea registrar el reingreso del empleado?"))
                                            {
                                                EmpNewID = RegisterData(1, "I").ToString();
                                                EmpleadoBO.RegistraReingreso(data.Rows[0]["EMP_CI"].ToString(), EmpNewID, empID, Catalogo.UserName);
                                                ClearControls(tabInformacion.SelectedIndex);
                                                AssignData(EmpNewID);
                                                Utility.MensajeOK("El reingreso fue exitoso el código asignado es: " + EmpNewID);
                                            }
                                            else
                                            {
                                                AssignData(txtCodigo.Text);
                                            }
                                            btnReingreso.Text = "&Reingreso";
                                            this.btnReingreso.ImageIndex = 18;
                                            ActiveControls(false, tabInformacion.SelectedIndex);
                                            btnNewSave.Visible = true;
                                            btnEditCancel.Visible = true;
                                        }
                                    }
                                    else
                                    {
                                        Utility.MensajeError("¡Error! El empleado ya se encuentra registrado en estado activo");
                                    }
                                }
                            }
                        }

                    }
                    else
                        ErrProv.SetError(txtCodigo, "El empleado debe tener una fecha de salida o liquidación de la empresa..!!");
                }
                else
                {
                    Utility.MensajeInfo("Seleccione primero un empleado.!!");
                }

            }

        }

        private void dgvFamiliar_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvFamiliar.IsCurrentCellDirty)
            {
                dgvFamiliar.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvFamiliar_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (DialogResult.No == Utility.MensajeQuestion("¿Esta seguro de eliminar el registro?"))
            {
                e.Cancel = true;
            }
        }

        private void dgvFamiliar_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //e.Cancel = true;
        }

        private void dgvFamiliar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvFamiliar.Rows[e.RowIndex].ErrorText = string.Empty;
            if (dgvFamiliar.Columns[e.ColumnIndex].Name == "EMP_FAM_FEC_NAC" & dgvFamiliar.Rows[e.RowIndex].Cells["EMP_FAM_FEC_NAC"].Value != null)
            {
                string fecha = dgvFamiliar.Rows[e.RowIndex].Cells["EMP_FAM_FEC_NAC"].Value.ToString();
                fecha = fecha.Replace(".", "/");
                fecha = fecha.Replace("-", "/");
            }
            if (dgvFamiliar.Columns[e.ColumnIndex].Name == "EMP_FAM_FEC_NAC")
            {
                if (Utility.isDate(dgvFamiliar.Rows[e.RowIndex].Cells["EMP_FAM_FEC_NAC"].Value.ToString()))
                    dgvFamiliar.Rows[e.RowIndex].Cells["Edad"].Value = CalcularEdad(Convert.ToDateTime(dgvFamiliar.Rows[e.RowIndex].Cells["EMP_FAM_FEC_NAC"].Value), DateTime.Now);
            }
        }
        public string CalcularEdad(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;
            int mth = now.Month - birthDate.Month;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
            {
                age--;
                mth = 12 - Math.Abs(mth);
            }

            return age + " anios " + Math.Abs(mth) + " meses";
        }

        private void dgvFamiliar_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!dgvFamiliar.Rows[e.RowIndex].IsNewRow)
            {
                if (dgvFamiliar.Columns[e.ColumnIndex].Name == "EMP_FAM_FEC_NAC")
                {
                    if (!Utility.isDate(e.FormattedValue.ToString()))
                    {
                        dgvFamiliar.Rows[e.RowIndex].ErrorText = "El formato de la fecha debe ser (dd/mm/yyyy)";
                        e.Cancel = true;
                    }
                    else
                    {
                        if (Convert.ToDateTime(e.FormattedValue.ToString()).Date > DateTime.Now.Date)
                        {
                            dgvFamiliar.Rows[e.RowIndex].ErrorText = "La Fecha no puede ser mayor a la vigente";
                            e.Cancel = true;
                        }
                    }
                }
            }
        }


        private void txtPerCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }

        private void txtPerCuentaBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }

        private void txtPerCorreo_Validating(object sender, CancelEventArgs e)
        {
            //if (!Utility.IsValidEmail(txtPerCorreo.Text))
            //{
            //    ErrProv.SetError(txtPerCorreo, "Correo Inválido");
            //    e.Cancel = true;
            //}
            //else
            //    ErrProv.Clear();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyText(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyText(e);
        }

        private void txtPerPasaporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyTextAndDigit(e);
        }

        private void txtPerNumIESS_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyTextAndDigit(e);
        }

        private void txtPerBarrio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyTextAndDigit(e);
        }

        private void txtPerDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyTextDigitDash(e);
        }

        private void txtPerTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }

        private void txtPerTelefonoSeg_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }

        private void txtPerLugarNac_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyText(e);
        }

        private void txtPerNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyTextDigitDash(e);
        }

        private void txtLabRBU_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyQuantity(sender, e);
        }

        private void txtLabQuincena_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyQuantity(sender, e);
        }

        private void dgvValor_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvValor.IsCurrentCellDirty)
            {
                dgvValor.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvValor_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == -1 | e.RowIndex == -1)
                return;

            if (!dgvValor.Rows[e.RowIndex].IsNewRow)
            {
                if (dgvValor.Columns[e.ColumnIndex].Name == "ROL_ID")
                {
                    foreach (DataGridViewRow row in dgvValor.Rows)
                    {
                        if (row.Index != e.RowIndex && row.Cells["ROL_ID"].Value != null)
                        {
                            if (e.FormattedValue.ToString() == ((DataGridViewComboBoxCell)row.Cells["ROL_ID"]).FormattedValue.ToString())
                            {
                                dgvValor.Rows[e.RowIndex].ErrorText = "Ya existe la cuenta";
                                e.Cancel = true;
                                return;
                            }
                        }

                    }
                }
            }
        }

        private void dgvValor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvValor.Rows[e.RowIndex].ErrorText = string.Empty;
            int index = dgvValor.CurrentCell.ColumnIndex;
            if (dgvValor.Columns[index].Name == "FIJ_VALOR")
            {
                dText.KeyPress -= new KeyPressEventHandler(dText_KeyPress);
            }
        }
        DataGridViewTextBoxEditingControl dText;
        private void dgvValor_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType().Name.Equals("DataGridViewTextBoxEditingControl"))
            {
                dText = (DataGridViewTextBoxEditingControl)e.Control;
                dText.KeyPress += new KeyPressEventHandler(dText_KeyPress);
            }
        }

        void dText_KeyPress(object sender, KeyPressEventArgs e)
        {
            int index = dgvValor.CurrentCell.ColumnIndex;
            if (dgvValor.Columns[index].Name == "FIJ_VALOR")
            {
                TextBox txt = (TextBox)sender;
                Utility.OnlyQuantity(txt, e);
            }
        }

        private void txtPerCorreoPer_Validating(object sender, CancelEventArgs e)
        {
            if (!Utility.IsValidEmail(txtPerCorreoPer.Text))
            {
                ErrProv.SetError(txtPerCorreoPer, "Correo Inválido");
                e.Cancel = true;
            }
            else
                ErrProv.Clear();
        }

        private void btnHuella_Click(object sender, EventArgs e)
        {
            if (!txtCodigo.Text.Equals(""))
            {
                frmHuella frm = new frmHuella(txtCodigo.Text);
                Design.frmDialog(frm, "Captura de Huella: " + txtApellido.Text + " " + txtNombre.Text);
            }
        }

        private void dgvValor_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (DialogResult.No == Utility.MensajeQuestion("¿Esta seguro de eliminar el registro?"))
            {
                e.Cancel = true;
            }
        }

        private void dgvValor_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //e.Cancel = true;
        }

        private void frmEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.F5))
                AssignData(EmpleadoBO.Empleado.empId.ToString());
        }      

        private void txtPerCedula_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;//& !btnReingreso.Text.Equals("&Aceptar")
            if ((StateButton == Acction.New & txtPerCedula.ReadOnly.Equals(false) ) && !ExisteEmpleado(txtPerCedula.Text, out errorMsg))
            {
                e.Cancel = true;
                txtPerCedula.Select(0, txtPerCedula.Text.Length);
                this.ErrProv.SetError(txtPerCedula, errorMsg);
            }
            else
            {
                this.ErrProv.Clear();
            }

        }
        public bool ExisteEmpleado(string emailAddress, out string errorMessage)
        {
            if (emailAddress.Length == 0)
            {
                errorMessage = "Identificación inválida";
                return false;
            }

            int cont = EmpleadoBO.ValidaEmpleadoEmpresa(txtPerCedula.Text);
            if (cont == 0)
            {
                errorMessage = string.Empty ;
                return true;
            }
            
            errorMessage = "Ya existe un registro con esta cédula";
            return false;
        }

        private void chkPasaporte_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkPasaporte.Checked)
            //{
            //    txtPerCedula.Enabled = false ;
            //    txtPerPasaporte.Enabled = true;
            //}                
            //else
            //{
            //    txtPerCedula.Enabled = true ;
            //    txtPerPasaporte.Enabled = false;
            //}
        }
    }
}
