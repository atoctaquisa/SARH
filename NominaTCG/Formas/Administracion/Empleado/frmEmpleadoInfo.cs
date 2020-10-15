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
    public partial class frmEmpleadoInfo : Form
    {
        #region Instancia / Constructor
        private static frmEmpleadoInfo _instancia;
        public static frmEmpleadoInfo Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmEmpleadoInfo();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmEmpleadoInfo()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            UbicacionBO = UbicacionController.Instancia;
            ContratoBO = ContratoController.Instancia;
            PatronoBO = PatronoController.Instancia;
            LocalBO = LocalController.Instancia;
            EscalafonBO = EscalafonController.Instancia;
            CuentaBO = CuentaController.Instancia;
            dgvFamiliar.AutoGenerateColumns = false;
            dgvValor.AutoGenerateColumns = false;
            ActiveControls(false, 0);
            CargaCombos();
            LoadData();
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
        private DataView EmpleadoView { get; set; }
        private Acction StateButton { get; set; }
        #endregion

        #region Methods

        private void AssignControls(int index)
        {
            //Info. Principal
            txtCodigo.Text = dgvData.Rows[index].Cells["EMP_ID"].Value.ToString();
            txtNombre.Text = dgvData.Rows[index].Cells["EMP_NOMBRE"].Value.ToString();
            txtApellido.Text = dgvData.Rows[index].Cells["EMP_APELLIDO"].Value.ToString();
            //Datos Personales            
            txtPerCedula.Text = dgvData.Rows[index].Cells["EMP_CI"].Value.ToString();
            txtPerNumIESS.Text = dgvData.Rows[index].Cells["EMP_NUM_IESS"].Value.ToString();
            txtPerCuentaBanco.Text = dgvData.Rows[index].Cells["EMP_CUENTA"].Value.ToString();
            cboPerDiscapacidad.SelectedValue = dgvData.Rows[index].Cells["EMP_DISCAPACIDAD"].Value.ToString();
            txtPerCorreo.Text = dgvData.Rows[index].Cells["EMP_MAIL"].Value.ToString();
            txtPerPasaporte.Text = dgvData.Rows[index].Cells["EMP_PASAPORTE"].Value.ToString();
            cboPerFondoReserva.SelectedValue = dgvData.Rows[index].Cells["EMP_PAG_FON_RES"].Value.ToString();
            cboPerTipoCuenta.SelectedValue = dgvData.Rows[index].Cells["EMP_TIPO_CNTA"].Value.ToString();
            txtPerNumIdentificacion.Text = dgvData.Rows[index].Cells["EMP_NUM_CONADIS"].Value.ToString();
            cboPerAfiliacion.SelectedValue = dgvData.Rows[index].Cells["EMP_AFIL_HUMANA"].Value.ToString();
            txtPerAfiliacionDesde.Text = dgvData.Rows[index].Cells["EMP_AFI_SEG_FEC"].Value.ToString();
            cboPerDecimoTercero.SelectedValue = dgvData.Rows[index].Cells["EMP_PAG_DEC_TER"].Value.ToString();
            cboPerDecimoCuarto.SelectedValue = dgvData.Rows[index].Cells["EMP_PAG_DEC_CUA"].Value.ToString();
            //------------------
            txtPerBarrio.Text = dgvData.Rows[index].Cells["EMP_BARRIO"].Value.ToString();
            txtPerDireccion.Text = dgvData.Rows[index].Cells["EMP_DIREC"].Value.ToString();
            txtPerTelefono.Text = dgvData.Rows[index].Cells["EMP_TELEFONO"].Value.ToString();
            cboPerSector.SelectedValue = dgvData.Rows[index].Cells["EMP_SEC_ID"].Value.ToString();
            txtPerNumero.Text = dgvData.Rows[index].Cells["EMP_DIRE_NUMERO"].Value.ToString();
            txtPerTelefonoSeg.Text = dgvData.Rows[index].Cells["EMP_TELEFONO2"].Value.ToString();
            //-------------------
            txtPerLugarNac.Text = dgvData.Rows[index].Cells["EMP_LUG_NAC"].Value.ToString();
            pPerFechaNac.Text = dgvData.Rows[index].Cells["EMP_FEC_NAC"].Value.ToString();
            cboPerSexo.SelectedValue = dgvData.Rows[index].Cells["EMP_SEXO"].Value.ToString();
            cboPerEducacion.SelectedValue = dgvData.Rows[index].Cells["EMP_EDU"].Value.ToString();
            txtPerActualizaciones.Text = dgvData.Rows[index].Cells["EMP_FEC_SEG"].Value.ToString();
            cboPerEstadoCivil.SelectedValue = dgvData.Rows[index].Cells["EMP_EST_CIVIL"].Value.ToString();
            txtPerTipoSangre.Text = dgvData.Rows[index].Cells["EMP_TIP_SANGRE"].Value.ToString();
            txtPerLabFecIng.Text = dgvData.Rows[index].Cells["LAB_FEC_INGRESO"].Value.ToString();
            txtPerFechaSalidaR.Text = dgvData.Rows[index].Cells["EMP_FEC_SALIDAREAL"].Value.ToString();
            txtPerFechaSalidaDif.Text = dgvData.Rows[index].Cells["EMP_FEC_SALIDA"].Value.ToString();
            txtPerFechaRegSis.Text = dgvData.Rows[index].Cells["EMP_FEC_REG"].Value.ToString();
            txtPerFechaModSis.Text = dgvData.Rows[index].Cells["EMP_FEC_MOD"].Value.ToString();

            if (txtCodigo.Text != String.Empty)
            {
                //Datos Contrato
                DataTable Contrato = new DataTable();
                Contrato = ContratoBO.ContratoEmpleado(txtCodigo.Text);
                if (Contrato.Rows.Count > 0)
                {
                    txtConFehaContrato.Text = Contrato.Rows[0]["EMP_CON_FEC_CONTRATO"] == DBNull.Value ? "" : Contrato.Rows[0]["EMP_CON_FEC_CONTRATO"].ToString();
                    txtConFechaLiquidacion.Text = Contrato.Rows[0]["EMP_CON_FEC_LIQUI"].ToString();
                    cboConRazon.SelectedValue = Contrato.Rows[0]["EMP_CON_RAZON_SALE"].ToString();
                    cboConFirma.SelectedValue = Contrato.Rows[0]["EMP_CON_FIRM_RENU"] == DBNull.Value ? -1 : Convert.ToInt32(Contrato.Rows[0]["EMP_CON_FIRM_RENU"].ToString());
                    cboConCausaFin.SelectedValue = Contrato.Rows[0]["CON_CAU_ID"] == DBNull.Value ? -1 : Convert.ToInt32(Contrato.Rows[0]["CON_CAU_ID"]);
                    txtConObservacion.Text = Contrato.Rows[0]["EMP_CON_OBS"].ToString();
                    cboConContrato.SelectedValue = Contrato.Rows[0]["CON_ID"] == DBNull.Value ? -1 : Convert.ToInt32(Contrato.Rows[0]["CON_ID"]);
                    cboConPatrono.SelectedValue = Contrato.Rows[0]["PAT_ID"] == DBNull.Value ? -1 : Convert.ToInt32(Contrato.Rows[0]["PAT_ID"].ToString());
                    txtConFechaIng.Text = Contrato.Rows[0]["EMP_CON_FEC_REG"].ToString();
                    txtConFechaMod.Text = Contrato.Rows[0]["EMP_CON_FEC_MOD"].ToString();
                }
                else
                {
                    NotRecordContrato();
                }
                //Datos Laborales
                DataTable InfoLaboral = new DataTable();
                InfoLaboral = ContratoBO.InfoLaboral(txtCodigo.Text);
                if (InfoLaboral.Rows.Count != 0)
                {
                    txtLabFecha.Text = InfoLaboral.Rows[0]["LAB_FEC_CAMB_ESC"].ToString();
                    cboLabLocal.SelectedValue = Convert.ToInt32(InfoLaboral.Rows[0]["LOC_ID"]);
                    cboLabCargo.SelectedValue = Convert.ToInt32(InfoLaboral.Rows[0]["ESC_ID"]);
                    cboLabEstado.SelectedValue = Convert.ToInt32(InfoLaboral.Rows[0]["LAB_ESTADO"]);
                    cboLabTipoPago.SelectedValue = Convert.ToInt32(InfoLaboral.Rows[0]["LAB_TIPO_EMP"]);
                    txtLabRBU.Text = InfoLaboral.Rows[0]["LAB_RBU"].ToString();
                    txtLabQuincena.Text = InfoLaboral.Rows[0]["LAB_QUINCENA"].ToString();
                    txtLabObservacion.Text = InfoLaboral.Rows[0]["LAB_OBS"].ToString();
                    txtLabObservacionSis.Text = InfoLaboral.Rows[0]["LAB_FEC_OBS_SIS"].ToString();
                    txtLabFechaReg.Text = InfoLaboral.Rows[0]["LAB_FEC_REG"].ToString();
                    txtLabFechaMod.Text = InfoLaboral.Rows[0]["LAB_FEC_MOD"].ToString();
                }
                else
                {
                    NotRecordLaboral();
                }
                //Datos Familiares
                DataTable Familiar = new DataTable();
                Familiar = EmpleadoBO.Familiares(txtCodigo.Text);
                dgvFamiliar.DataSource = Familiar;
                //if (Familiar.Rows.Count > 0)
                //    dgvFamiliar.DataSource = Familiar;
                //else
                //{
                //    //dgvFamiliar.DataSource = null;
                //    dgvFamiliar.Rows.Clear();
                //}

                //Datos Fijos
                DataTable ValorFijo = new DataTable();
                ValorFijo = ContratoBO.RubroAdicional(txtCodigo.Text);
                dgvValor.DataSource = ValorFijo;
                //if (ValorFijo.Rows.Count > 0)
                //    dgvValor.DataSource = ValorFijo;
                //else
                //{
                //    //dgvValor.DataSource = null;
                //    dgvValor.Rows.Clear();
                //}

            }
            else
            {
                NotRecordLaboral();
                NotRecordContrato();
                //dgvFamiliar.DataSource = null;
                //dgvValor.DataSource = null;
            }
        }

        private void NotRecordLaboral()
        {
            txtLabFecha.Text = string.Empty;
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
        }

        private void NotRecordContrato()
        {
            txtConFehaContrato.Text = string.Empty;
            txtConFechaLiquidacion.Text = string.Empty;
            cboConRazon.SelectedValue = -1;
            cboConFirma.SelectedValue = -1;
            cboConCausaFin.SelectedValue = -1;
            txtConObservacion.Text = string.Empty;
            cboConContrato.SelectedValue = -1;
            cboConPatrono.SelectedValue = -1;
            txtConFechaIng.Text = string.Empty;
            txtConFechaMod.Text = string.Empty;
        }

        private void LoadData()
        {
            EmpleadoView = new DataView(EmpleadoBO.ListaEmpleado());
            dgvData.DataSource = EmpleadoView;
            Design.vEmpleado(dgvData);
            cboFilter.DataSource = Design.filterData;
            cboFilter.DisplayMember = "Nombre";
            cboFilter.ValueMember = "ID";
            lblTotalRecord.Text = "Total Registros: " + EmpleadoView.Count.ToString();
        }

        private void CargaCombos()
        {
            cboPerDiscapacidad.DataSource = Entity.Catalogo.RespCorta();
            cboPerDiscapacidad.DisplayMember = "Nombre";
            cboPerDiscapacidad.ValueMember = "ID";
            cboPerFondoReserva.DataSource = Entity.Catalogo.RespCorta();
            cboPerFondoReserva.DisplayMember = "Nombre";
            cboPerFondoReserva.ValueMember = "ID";
            cboPerTipoCuenta.DataSource = Entity.Catalogo.TipoCuenta();
            cboPerTipoCuenta.DisplayMember = "Nombre";
            cboPerTipoCuenta.ValueMember = "ID";
            cboPerAfiliacion.DataSource = Entity.Catalogo.RespCorta();
            cboPerAfiliacion.DisplayMember = "Nombre";
            cboPerAfiliacion.ValueMember = "ID";
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
            cboConCausaFin.DataSource = ContratoBO.ListaContratoFin();
            cboConCausaFin.DisplayMember = "Causa";
            cboConCausaFin.ValueMember = "ContratoFinID";
            cboConContrato.DataSource = ContratoBO.ListaContrato();
            cboConContrato.DisplayMember = "Nombre";
            cboConContrato.ValueMember = "ContratoID";
            cboConPatrono.DataSource = PatronoBO.Listar();
            cboConPatrono.DisplayMember = "PAT_RAZ_SOCIAL";
            cboConPatrono.ValueMember = "PAT_ID";
            cboConFirma.DataSource = Entity.Catalogo.RespCorta();
            cboConFirma.DisplayMember = "Nombre";
            cboConFirma.ValueMember = "ID";
            //Datos Laborales
            cboLabLocal.DataSource = LocalBO.Listar();
            cboLabLocal.DisplayMember = "Nombre";
            cboLabLocal.ValueMember = "LocalID";
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

        private void ActiveControls(bool estadoControl, int tabID)
        {
            //switch (tabID)
            //{
            //    case 0:
            //Dato Personales
            txtApellido.Enabled = estadoControl;
            txtNombre.Enabled = estadoControl;
            txtPerLabFecIng.Enabled = estadoControl;
            txtPerCedula.Enabled = estadoControl;
            txtPerPasaporte.Enabled = estadoControl;
            txtPerNumIESS.Enabled = estadoControl;
            cboPerFondoReserva.Enabled = estadoControl;
            txtPerCuentaBanco.Enabled = estadoControl;
            cboPerTipoCuenta.Enabled = estadoControl;
            cboPerDiscapacidad.Enabled = estadoControl;
            txtPerNumIdentificacion.Enabled = estadoControl;
            txtPerCorreo.Enabled = estadoControl;
            cboPerAfiliacion.Enabled = estadoControl;
            txtPerAfiliacionDesde.Enabled = estadoControl;
            cboPerDecimoTercero.Enabled = estadoControl;
            cboPerDecimoCuarto.Enabled = estadoControl;
            //---------------------------
            txtPerBarrio.Enabled = estadoControl;
            cboPerSector.Enabled = estadoControl;
            txtPerDireccion.Enabled = estadoControl;
            txtPerNumero.Enabled = estadoControl;
            txtPerTelefono.Enabled = estadoControl;
            txtPerTelefonoSeg.Enabled = estadoControl;
            //---------------------------
            txtPerLugarNac.Enabled = estadoControl;
            pPerFechaNac.Enabled = estadoControl;
            cboPerEstadoCivil.Enabled = estadoControl;
            cboPerSexo.Enabled = estadoControl;
            txtPerTipoSangre.Enabled = estadoControl;
            cboPerEducacion.Enabled = estadoControl;
            //    break;
            //case 1:
            //Datos Contrato
            txtConFechaLiquidacion.Enabled = estadoControl;
            txtConFehaContrato.Enabled = estadoControl;
            cboConRazon.Enabled = estadoControl;
            cboConCausaFin.Enabled = estadoControl;
            txtConObservacion.Enabled = estadoControl;
            cboConContrato.Enabled = estadoControl;
            cboConPatrono.Enabled = estadoControl;
            cboConFirma.Enabled = estadoControl;
            //    break;
            //case 2:
            //Datos Laborales
            txtLabFecha.Enabled = estadoControl;
            cboLabLocal.Enabled = estadoControl;
            cboLabCargo.Enabled = estadoControl;
            txtLabRBU.Enabled = estadoControl;
            txtLabQuincena.Enabled = estadoControl;
            cboLabEstado.Enabled = estadoControl;
            cboLabTipoPago.Enabled = estadoControl;
            txtLabObservacion.Enabled = estadoControl;
            txtLabObservacionSis.Enabled = estadoControl;
            //    break;
            //case 3:
            //Datos Familiar
            dgvFamiliar.Enabled = estadoControl;
            //break;

            //case 4:
            //Datos Fijos
            dgvValor.Enabled = estadoControl;
            //break;              
            //}




        }

        private bool ValidateControls(int tabID)
        {
            ErrProv.Clear();
            string sms = "El campo es requerido";
            int cnt = 1;
            switch (tabID)
            {
                case 0://Info. Principal 
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
                    if (txtPerNumIESS.Text == string.Empty)
                    {
                        ErrProv.SetError(txtPerNumIESS, sms);
                        cnt++;
                    }
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
                    if (cboPerDiscapacidad.Text.Equals("Si"))
                    {
                        if (txtPerNumIdentificacion.Text == string.Empty)
                        {
                            ErrProv.SetError(txtPerNumIdentificacion, sms);
                            cnt++;
                        }
                    }
                    else
                        txtPerNumIdentificacion.Text = string.Empty;

                    if (txtPerCorreo.Text == string.Empty)
                    {
                        ErrProv.SetError(txtPerCorreo, sms);
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
                    if (cboPerAfiliacion.Text == string.Empty)
                    {
                        ErrProv.SetError(cboPerAfiliacion, sms);
                        cnt++;
                    }
                    if (cboPerAfiliacion.Text.Equals("Si"))
                    {
                        if (txtPerAfiliacionDesde.Text == string.Empty)
                        {
                            ErrProv.SetError(txtPerAfiliacionDesde, sms);
                            cnt++;
                        }
                    }
                    else
                        txtPerAfiliacionDesde.Text = string.Empty;

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
                    //------------------
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
                    //-------------------
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
                    if (txtPerLabFecIng.Text == string.Empty)
                    {
                        ErrProv.SetError(txtPerLabFecIng, sms);
                        cnt++;
                    }

                    break;
                case 1://Datos Contrato
                    if (txtConFehaContrato.Text == string.Empty)
                    {
                        ErrProv.SetError(txtConFehaContrato, sms);
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
                    break;
                case 2://Datos Laborales
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
                    if (txtLabQuincena.Text == string.Empty)
                    {
                        ErrProv.SetError(txtLabQuincena, sms);
                        cnt++;
                    }
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

                    break;
                case 3://Datos Familiares
                    foreach (DataGridViewRow item in dgvFamiliar.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            //if ((item.Cells["EMP_FAM_NOMBRE"].Value == DBNull.Value || item.Cells["EMP_FAM_NOMBRE"].Value == string.Empty)
                            //    | (item.Cells["EMP_FAM_FEC_NAC"].Value == DBNull.Value || item.Cells["EMP_FAM_FEC_NAC"].Value == string.Empty)
                            //    | (item.Cells["EMP_FAM_PARENT"].Value == DBNull.Value || item.Cells["EMP_FAM_PARENT"].Value == string.Empty)
                            //    //| (item.Cells["EMP_FAM_OCUP"].Value == DBNull.Value || item.Cells["EMP_FAM_OCUP"].Value == string.Empty)
                            //    )
                            //{
                            //    dgvFamiliar.Rows[item.Index].ErrorText = "Los datos son requeridos";
                            //    cnt++;
                            //}
                        }

                    }
                    break;

                case 4://Datos Fijos
                    foreach (DataGridViewRow item in dgvValor.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            if ((item.Cells["ROL_ID"].Value == null) | (item.Cells["FIJ_VALOR"].Value == null || item.Cells["FIJ_VALOR"].Value.ToString() == string.Empty))
                            {
                                dgvValor.Rows[item.Index].ErrorText = "Los datos son requeridos";
                                cnt++;
                            }
                        }
                    }

                    break;
            }
            if (cnt.Equals(1))
                return true;
            else
                return false;
        }

        private Int64 RegisterData(int tabID, string tipo)
        {
            Int64 resp = 0;
            DataTable data = null;
            DataTable dataChange = null;
            switch (tabID)
            {
                case 0://Datos Personales
                    EmpleadoBO.Empleado.empId = (txtCodigo.Text == string.Empty) ? 0 : Convert.ToInt32(txtCodigo.Text);
                    EmpleadoBO.Empleado.empNombre = txtNombre.Text;
                    EmpleadoBO.Empleado.empDirec = txtPerDireccion.Text;
                    EmpleadoBO.Empleado.empTelefono = txtPerTelefono.Text;
                    EmpleadoBO.Empleado.empLugNac = txtPerLugarNac.Text;
                    EmpleadoBO.Empleado.empFecNac = pPerFechaNac.Value;
                    EmpleadoBO.Empleado.empCi = txtPerCedula.Text;
                    EmpleadoBO.Empleado.empNumIess = txtPerNumIESS.Text;
                    EmpleadoBO.Empleado.empEstCivil = cboPerEstadoCivil.SelectedValue.ToString();
                    EmpleadoBO.Empleado.empNumHijos = 0;
                    EmpleadoBO.Empleado.labFecIngreso = Convert.ToDateTime(txtPerLabFecIng.Text);
                    EmpleadoBO.Empleado.empCuenta = txtPerCuentaBanco.Text;
                    EmpleadoBO.Empleado.empApellido = txtApellido.Text;
                    EmpleadoBO.Empleado.empAfilHumana = 0;
                    EmpleadoBO.Empleado.empTelefono2 = txtPerTelefonoSeg.Text;
                    EmpleadoBO.Empleado.empTipoCnta = Convert.ToInt32(cboPerTipoCuenta.SelectedValue);
                    EmpleadoBO.Empleado.empSexo = Convert.ToInt32(cboPerSexo.SelectedValue);
                    EmpleadoBO.Empleado.empSecId = Convert.ToInt32(cboPerSector.SelectedValue);
                    EmpleadoBO.Empleado.empBarrio = txtPerBarrio.Text;
                    EmpleadoBO.Empleado.empEdu = cboPerEducacion.SelectedValue.ToString();
                    EmpleadoBO.Empleado.empDireNumero = txtPerNumero.Text;
                    EmpleadoBO.Empleado.empTipSangre = txtPerTipoSangre.Text;
                    EmpleadoBO.Empleado.empDiscapacidad = Convert.ToInt32(cboPerDiscapacidad.SelectedValue);
                    EmpleadoBO.Empleado.empNumConadis = txtPerNumIdentificacion.Text;
                    EmpleadoBO.Empleado.empAfiFarma = Convert.ToInt32(cboPerAfiliacion.SelectedValue);
                    if (txtPerAfiliacionDesde.Text != string.Empty)
                        EmpleadoBO.Empleado.empAfiFarmaFec = Convert.ToDateTime(txtPerAfiliacionDesde.Text);
                    EmpleadoBO.Empleado.empPagFonRes = Convert.ToInt32(cboPerFondoReserva.SelectedValue);
                    EmpleadoBO.Empleado.empPasaporte = txtPerPasaporte.Text;
                    EmpleadoBO.Empleado.empMail = txtPerCorreo.Text;
                    EmpleadoBO.Empleado.empPagDecTer = Convert.ToInt32(cboPerDecimoTercero.SelectedValue);
                    EmpleadoBO.Empleado.empPagDecCua = Convert.ToInt32(cboPerDecimoCuarto.SelectedValue);
                    EmpleadoBO.Empleado.empDependientes = 0;
                    resp = EmpleadoBO.RegistarEmpleado(EmpleadoBO.Empleado, "I");
                    break;
                case 1://Datos de Contrato
                    ContratoBO.EmpleadoContrato.empId = Convert.ToInt64(txtCodigo.Text);
                    ContratoBO.EmpleadoContrato.empConId = 1;
                    ContratoBO.EmpleadoContrato.conId = Convert.ToInt32(cboConContrato.SelectedValue);
                    ContratoBO.EmpleadoContrato.patId = Convert.ToInt32(cboConPatrono.SelectedValue);

                    //ContratoBO.EmpleadoContrato.empConRazonSale = cboConRazon.SelectedValue == null ? string.Empty : cboConRazon.SelectedValue.ToString();
                    //if (Convert.ToInt32(cboConFirma.SelectedValue) != 0)
                    //    ContratoBO.EmpleadoContrato.empConFirmRenu = cboConFirma.SelectedValue.ToString();
                    //else
                    //    ContratoBO.EmpleadoContrato.empConFirmRenu = string.Empty;
                    if (txtConFechaLiquidacion.Text != string.Empty)
                        ContratoBO.EmpleadoContrato.empConFecLiqui = Convert.ToDateTime(txtConFechaLiquidacion.Text);
                    //if (Convert.ToInt32(cboConFirma.SelectedValue) != 0)
                        //ContratoBO.EmpleadoContrato.empConFirmLiqui = cboConFirma.SelectedValue.ToString();
                    //else
                    //    ContratoBO.EmpleadoContrato.empConFirmLiqui = string.Empty;


                    //contrato.empConFecLegSa=;
                    //contrato.empConFirmSalida=;
                    //contrato.empConFecMinTr=;
                    ContratoBO.EmpleadoContrato.empConFecContrato = Convert.ToDateTime(txtConFehaContrato.Text);
                    ContratoBO.EmpleadoContrato.empConObs = txtConObservacion.Text;
                    //contrato.empConFecReg=;
                    //contrato.empConFecMod=;
                    //contrato.empConCausa=;
                    //contrato.empConEstado=;
                    //if (Convert.ToInt32(cboConCausaFin.SelectedValue) != 0)
                    //    ContratoBO.EmpleadoContrato.conCauId = cboConCausaFin.SelectedValue.ToString();
                    //else
                    //    ContratoBO.EmpleadoContrato.conCauId = string.Empty;

                    if (ContratoBO.ContratoEmpleado(txtCodigo.Text).Rows.Count.Equals(0))
                        resp = ContratoBO.RegistraContrato(ContratoBO.EmpleadoContrato, "I");
                    else
                        resp = 0;
                    break;
                case 2://Datos Laborales
                    ContratoBO.Laboral.empId = Convert.ToDecimal(txtCodigo.Text);
                    ContratoBO.Laboral.labId = 2;
                    ContratoBO.Laboral.locId = Convert.ToInt32(cboLabLocal.SelectedValue);
                    ContratoBO.Laboral.escId = Convert.ToInt32(cboLabCargo.SelectedValue);
                    ContratoBO.Laboral.labSueldoBono = 0;
                    ContratoBO.Laboral.labObs = txtLabObservacion.Text;
                    ContratoBO.Laboral.labEstado = Convert.ToInt32(cboLabEstado.SelectedValue);
                    ContratoBO.Laboral.labTipoEmp = Convert.ToInt32(cboLabTipoPago.SelectedValue);
                    ContratoBO.Laboral.labRbu = Convert.ToInt32(txtLabRBU.Text);
                    ContratoBO.Laboral.labVest = 0;
                    ContratoBO.Laboral.labBono = Convert.ToInt32(0);
                    ContratoBO.Laboral.labQuincena = Convert.ToInt32(txtLabQuincena.Text);
                    if (ContratoBO.InfoLaboral(txtCodigo.Text).Rows.Count.Equals(0))
                        resp = ContratoBO.RegistrarInfoLaboral(ContratoBO.Laboral);
                    else
                        resp = 0;
                    break;
                case 3://Datos Familiares
                    data = (DataTable)dgvFamiliar.DataSource;
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
                            EmpleadoBO.Familia.empFamDisc = (row["EMP_FAM_DISC"].Equals(DBNull.Value) ? 0 : 1);
                            EmpleadoBO.Familia.empId = Convert.ToDecimal(txtCodigo.Text);
                            EmpleadoBO.Familia.empFamId = EmpleadoBO.Familiares(txtCodigo.Text).Rows.Count + 1;
                            resp = EmpleadoBO.RegistarFamiliar(EmpleadoBO.Familia);
                        }
                    }
                    dataChange = null;
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
                            EmpleadoBO.Familia.empFamDisc = (row["EMP_FAM_DISC"].Equals(DBNull.Value) ? 0 : 1);
                            EmpleadoBO.Familia.empId = Convert.ToDecimal(txtCodigo.Text);
                            EmpleadoBO.Familia.empFamId = Convert.ToInt32(row["EMP_FAM_ID"].ToString()); //EmpleadoBO.Familiares(txtCodigo.Text).Rows.Count + 1;
                            resp = EmpleadoBO.ActualizarFamiliar(EmpleadoBO.Familia);
                        }

                    }
                    break;
                case 4://Valores Fijos
                    //dgvValor.EndEdit();
                    data = (DataTable)dgvValor.DataSource;
                    
                    dataChange = data.GetChanges(DataRowState.Added);
                    if (dataChange != null)
                    {
                        foreach (DataRow row in dataChange.Rows)
                        {
                            ContratoBO.ValorFijo.rolId = Convert.ToInt32(row["ROL_ID"].ToString());                            
                            ContratoBO.ValorFijo.fijValor = Convert.ToInt32(row["FIJ_VALOR"].ToString());
                            ContratoBO.ValorFijo.fijEstado = Convert.ToInt16(row["FIJ_ESTADO"].Equals(DBNull.Value));//(row["FIJ_ESTADO"].Equals(DBNull.Value)) ? 0 : 1;
                            ContratoBO.ValorFijo.empId = Convert.ToDecimal(txtCodigo.Text);
                            resp = ContratoBO.RegistrarValorFijo(ContratoBO.ValorFijo);
                        }
                    }
                    dataChange = null;
                    dataChange = data.GetChanges(DataRowState.Modified);
                    if (dataChange != null)
                    {
                        foreach (DataRow row in dataChange.Rows)
                        {
                            ContratoBO.ValorFijo.rolId = Convert.ToInt32(row["ROL_ID"].ToString());
                            int auxRolID = Convert.ToInt32(row["ROL_ID", DataRowVersion.Original].ToString());                            
                            ContratoBO.ValorFijo.fijValor = Convert.ToInt32(row["FIJ_VALOR"].ToString());
                            ContratoBO.ValorFijo.fijEstado = Convert.ToInt16(row["FIJ_ESTADO"].ToString());
                            ContratoBO.ValorFijo.empId = Convert.ToDecimal(txtCodigo.Text);
                            resp = ContratoBO.ActualizarValorFijo(ContratoBO.ValorFijo,auxRolID);
                        }
                    }
                    break;
            }

            return resp;
        }

        private void ClearControls(int tabID)
        {
            //Info. Principal
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            //Datos Personales            
            txtPerCedula.Text = string.Empty;
            txtPerNumIESS.Text = string.Empty;
            txtPerCuentaBanco.Text = string.Empty;
            cboPerDiscapacidad.SelectedValue = -1;
            txtPerCorreo.Text = string.Empty;
            txtPerPasaporte.Text = string.Empty;
            cboPerFondoReserva.SelectedValue = -1;
            cboPerTipoCuenta.SelectedValue = -1;
            txtPerNumIdentificacion.Text = string.Empty;
            cboPerAfiliacion.SelectedValue = -1;
            txtPerAfiliacionDesde.Text = string.Empty;
            cboPerDecimoTercero.SelectedValue = -1;
            cboPerDecimoCuarto.SelectedValue = -1;
            //------------------
            txtPerBarrio.Text = string.Empty;
            txtPerDireccion.Text = string.Empty;
            txtPerTelefono.Text = string.Empty;
            cboPerSector.SelectedValue = -1;
            txtPerNumero.Text = string.Empty;
            txtPerTelefonoSeg.Text = string.Empty;
            //-------------------
            txtPerLugarNac.Text = string.Empty;
            pPerFechaNac.Text = string.Empty;
            cboPerSexo.SelectedValue = -1;
            cboPerEducacion.SelectedValue = -1;
            txtPerActualizaciones.Text = string.Empty;
            cboPerEstadoCivil.SelectedValue = -1;
            txtPerTipoSangre.Text = string.Empty;
            txtPerLabFecIng.Text = string.Empty;
            txtPerFechaSalidaR.Text = string.Empty;
            txtPerFechaSalidaDif.Text = string.Empty;
            txtPerFechaRegSis.Text = string.Empty;
            txtPerFechaModSis.Text = string.Empty;

            //Datos Contrato            
            NotRecordContrato();
            //Datos Laborales
            NotRecordLaboral();
            //Datos Familiares
            //dgvFamiliar.DataSource = null;
            dgvFamiliar.Rows.Clear();
            //Datos Fijos
            //dgvValor.DataSource = null;
            dgvValor.Rows.Clear();
        }

        #endregion
        private void frmEmpleadoInfo_Load(object sender, EventArgs e)
        {
            Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
        }

        private void frmEmpleadoInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            EmpleadoView.RowFilter = cboFilter.SelectedValue + " LIKE '%" + txtSearch.Text + "%'";
            dgvData.DataSource = EmpleadoView;
            lblTotalRecord.Text = "Total Registros: " + EmpleadoView.Count.ToString();
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    foreach (DataGridViewCell cell in dgvData.SelectedCells)
                    {
                        if (cell.Selected)
                        {
                            AssignControls(cell.RowIndex);
                            tabAdmin.SelectTab(1);
                        }
                    }
                    break;
                case Keys.Down:
                    break;
                default:
                    break;
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            else
            {

                AssignControls(e.RowIndex);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            else
            {
                AssignControls(e.RowIndex);
                tabAdmin.SelectTab(1);
            }
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (this.btnNewSave.Text == "&Nuevo")
            {
                if (!tabInformacion.SelectedIndex.Equals(0))
                {
                    if (txtCodigo.Text == string.Empty)
                    {
                        Utility.MensajeInfo("Primero ingrese los Datos Personales del Empleado..!!");
                        return;
                    }
                    else
                        return;
                }
                StateButton = Acction.New;
                ActiveControls(true, tabInformacion.SelectedIndex);
                ClearControls(tabInformacion.SelectedIndex);
                Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
            }
            else
            {
                //AssignData();
                if (ValidateControls(tabInformacion.SelectedIndex))
                {
                    Int64 respAction = 0;
                    if (StateButton == Acction.New)
                        respAction = RegisterData(tabInformacion.SelectedIndex, "N");

                    if (StateButton == Acction.Edit)
                        respAction = RegisterData(tabInformacion.SelectedIndex, "U");

                    if (respAction.Equals(0))
                        Utility.MensajeError("Acción Fallida..!!");
                    else
                    {
                        Utility.MensajeOK("Acción Exitosa..!!" + respAction.ToString());
                        ActiveControls(false, tabInformacion.SelectedIndex);
                        //ClearControls();
                        Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
                    }
                }
            }
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (this.btnEditCancel.Text != "&Cancelar")
            {
                if (txtCodigo.Text == string.Empty)
                    return;
                StateButton = Acction.Edit;
                ActiveControls(true, tabInformacion.SelectedIndex);
            }
            else
            {

                //ClearControls();
                StateButton = Acction.Cancel;
                //InitializeControls();
                ActiveControls(false, tabInformacion.SelectedIndex);
            }


            Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
        private void tabInformacion_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (btnEditCancel.Text.Equals("&Cancelar"))
                e.Cancel = true;
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

        private void dgvFamiliar_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //string headerText = dgvFamiliar.Columns[e.ColumnIndex].HeaderText;
            //if (!dgvFamiliar.Rows[e.RowIndex].IsNewRow)
            //{                
            //    if (headerText.Equals("Nombre") || headerText.Equals("Lugar Trabajo"))
            //    {
            //        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            //        {
            //            //MessageBox.Show("El dato introducido no es de tipo fecha", "Error de validación",
            //            //                MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            dgvFamiliar.Rows[e.RowIndex].ErrorText = "El campo es requerido"; //Cells[e.ColumnIndex]
            //            e.Cancel = true;
            //        }
            //    }
            //}
        }

        private void dgvFamiliar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvFamiliar.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dgvFamiliar_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvFamiliar.IsCurrentCellDirty)
                dgvFamiliar.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvFamiliar_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvValor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvValor.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dgvValor_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvValor.IsCurrentCellDirty)
                dgvValor.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvValor_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }


    }
}
