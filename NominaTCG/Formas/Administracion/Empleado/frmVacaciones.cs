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
    public partial class frmVacaciones : Form
    {

        #region Variables
        private int _diaPendiente;
        private int _cliID;
        #endregion

        #region Properties
        private DataView EmpleadoView { get; set; }
        private Acction StateButton { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        private SolicitudController SolicitudBO { get; set; }
        private SistemaController SistemaBO { get; set; }
        #endregion

        #region Metodos

        private void Notificar(string numero, string fecha)
        {
            object[,] emailVars = new object[,] { { "[@fecha]" , fecha },
                                                  { "[@periodo]" , txtPeriodo.Text },
                                                  { "[@fechaIngreso]" , pIncorpora.Value.ToShortDateString() },
                                                  { "[@fechaHasta]", pHasta.Value.ToShortDateString() },
                                                  { "[@fechaDesde]" , pDesde.Value.ToShortDateString() },
                                                  { "[@dias]" , txtDia.Text },                                                  
                                                  { "[@solicitud]" , numero },
                                                  { "[@estado]" , "Generada Exitosamente" },
                                                  { "[@razonSocial]" , txtEmpleado.Text },                                                 
                                                };

            SistemaBO.sendEmail(txtEmail.Text, "Solicitud de Vacaciones", SistemaBO.emailMessage("SOLICITUD DE VACACION", emailVars));
        }

        private void AssignControls()
        {
            DataTable datos = new DataTable();
            datos = EmpleadoBO.ListaEmpleadoDT(EmpleadoBO.Empleado.empId.ToString());
            if (datos.Rows.Count > 0)
            {

                btnNewSave.Enabled = true;
                _cliID = 0;
                _cliID = EmpleadoBO.EmpleadoLocal(datos.Rows[0]["EMP_ID"].ToString());
                ContratoBO.Vacacion.escId = Convert.ToInt16(datos.Rows[0]["ESC_ID"].ToString());
                txtCodigo.Text = datos.Rows[0]["EMP_ID"].ToString();
                txtEmpleado.Text = datos.Rows[0]["NOMBRE"].ToString();
                txtEmail.Text = datos.Rows[0]["EMP_MAIL"].ToString();
                txtPatrono.Text = datos.Rows[0]["PATRONO"].ToString();
                txtCargo.Text = datos.Rows[0]["ESC_CARGOMB"].ToString();
                txtLugar.Text = datos.Rows[0]["LOC_NOMBRE"].ToString();
                txtFechaIng.Text = Convert.ToDateTime(datos.Rows[0]["LAB_FEC_INGRESO"].ToString()).ToShortDateString();
                txtEstado.Text = datos.Rows[0]["ESTADO"].ToString();
                txtFechaContrato.Text = Convert.ToDateTime((datos.Rows[0]["EMP_CON_FEC_CONTRATO"].ToString()=="") ? "1/1/0001 0:00:00" : datos.Rows[0]["EMP_CON_FEC_CONTRATO"].ToString()).ToShortDateString();
                
                datos = ContratoBO.ListarVacacion(datos.Rows[0]["EMP_ID"].ToString(), "0", "0");
                if (datos.Rows.Count > 0)
                {
                    dgvVaciones.DataSource = datos;
                    Design.vPeridoVacacion(dgvVaciones);
                    txtPeriodo.Text = dgvVaciones.Rows[0].Cells["periodo"].Value.ToString();
                    ContratoBO.Vacacion.empID = txtCodigo.Text;
                    ContratoBO.Vacacion.vacId = Convert.ToInt16(dgvVaciones.Rows[0].Cells["CAB_VAC_ID"].Value);
                    ContratoBO.Vacacion.empConId = Convert.ToInt16(dgvVaciones.Rows[0].Cells["EMP_CON_ID"].Value);
                    dgvVacacionesDT.DataSource = ContratoBO.ListarVacacionDT(ContratoBO.Vacacion.empID,
                                                                   ContratoBO.Vacacion.vacId.ToString(),
                                                                   ContratoBO.Vacacion.empConId.ToString());
                    Design.vVacacionDT(dgvVacacionesDT);
                }
                else
                {
                    dgvVaciones.DataSource = null;
                    dgvVacacionesDT.DataSource = null;
                }

            }
            else
                ClearControls();

        }

        private void ClearControls()
        {
            dgvVacacionesDT.DataSource = null;
            dgvVaciones.DataSource = null;
            txtCodigo.Text = string.Empty;
            txtEmpleado.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPatrono.Text = string.Empty;
            txtCargo.Text = string.Empty;
            txtLugar.Text = string.Empty;
            txtFechaIng.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtFechaContrato.Text = string.Empty;
            txtPeriodo.Text = string.Empty;
            txtDia.Text = "0";
            txtObservacion.Text = string.Empty;
        }

        private void InitializeValues()
        {
            pDesde.Value = DateTime.Now;
            pHasta.Value = DateTime.Now;
            pIncorpora.Value = DateTime.Now;
        }

        private bool ValidateControls()
        {
            ErrProv.Clear();
            if (txtPeriodo.Text == "" | ContratoBO.Vacacion.vacId == 0)
            {
                ErrProv.SetError(txtPeriodo, "Seleccione un período");
                return false;
            }
            string fechaSistema = Convert.ToDateTime( SistemaBO.FechaCentral()).ToShortDateString();
            string fechaSolicitud = pDesde.Value.Date.ToShortDateString();
            string fechaSolicitudHas = pHasta.Value.Date.ToShortDateString();
            string fechaSolicitudIng = pIncorpora.Value.Date.ToShortDateString();
            if (SistemaBO.Path("81").Equals("S"))
            {
                if (Convert.ToDateTime(fechaSistema) > Convert.ToDateTime(fechaSolicitud))
                {
                    ErrProv.SetError(txtPeriodo, "No puede generar solicitudes con fechas menores a la fecha en curso " + fechaSistema);
                    return false;
                }
            }
            else
            {
                if (Utility.MensajeQuestion("¿Está seguro que desea registrar fechas menores a la actual?") == System.Windows.Forms.DialogResult.No)
                {
                    return false;
                }
            }
            if (pHasta.Value.Date < pDesde.Value.Date)
            {
                ErrProv.SetError(pHasta, "La Fecha Hasta no puede ser menor a la Fecha Desde");
                return false;
            }

            if (Convert.ToDateTime(fechaSolicitudIng) <= Convert.ToDateTime(fechaSolicitudHas))
            {
                ErrProv.SetError(pIncorpora, "La Fecha de Incorporación no puede ser menor o igual que Fecha Hasta");
                return false;
            }
            _diaPendiente = 0;
            _diaPendiente = Convert.ToInt16((pHasta.Value.Date - pDesde.Value.Date).ToString("dd")) + 1;
            if (SolicitudBO.VerificaDiasVacacion(ContratoBO.Vacacion.empID, ContratoBO.Vacacion.vacId) < _diaPendiente)
            {
                ErrProv.SetError(txtPeriodo, "Los días solicitados superan a los días disponibles");
                return false;
            }

            if (SolicitudBO.VerificaSolicitud(ContratoBO.Vacacion.empID, ContratoBO.Vacacion.vacId) > 0)
            {
                ErrProv.SetError(txtPeriodo, "Aún tiene solicitudes pendientes.!!");
                return false;
            }

            return true;
        }

        private void ActiveControls(bool stdo)
        {
            ErrProv.Clear();
            btnNewSave.Enabled = stdo;
            btnEditCancel.Enabled = stdo;
            btnSearch.Enabled = !stdo;
            txtPeriodo.Enabled = stdo;
            pDesde.Enabled = stdo;
            pHasta.Enabled = stdo;
            pIncorpora.Enabled = stdo;
            txtObservacion.Enabled = stdo;
            btnSearch.Focus();
        }

        private void InitializeControls()
        {
            dgvVaciones.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7);
            dgvVaciones.AutoGenerateColumns = false;
            dgvVacacionesDT.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7);
            dgvVacacionesDT.AutoGenerateColumns = false;
            ActiveControls(false);
        }
        #endregion

        #region Instancia / Constructor
        private static frmVacaciones _instancia;
        public static frmVacaciones Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmVacaciones();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmVacaciones()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            ContratoBO = ContratoController.Instancia;
            SolicitudBO = SolicitudController.Instancia;
            SistemaBO = SistemaController.Instancia;
            dgvVaciones.AutoGenerateColumns = false;
            dgvVacacionesDT.AutoGenerateColumns = false;
            InitializeControls();
        }
        #endregion

        private void frmVacaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            StateButton = Acction.New;
            ActiveControls(true);
            InitializeValues();
            btnNewSave.Enabled = false;
            btnSearch.Enabled = false;
            btnEditCancel.Enabled = true;
            pDesde.Select();
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {

                int conf = SolicitudBO.RegistraSolicitud(_cliID, pDesde.Value.ToShortDateString(), pHasta.Value.ToShortDateString(), pIncorpora.Value.ToShortDateString(), txtObservacion.Text,
                    ContratoBO.Vacacion.empID, Catalogo.UserSystem, ContratoBO.Vacacion.vacId, txtPeriodo.Text, _diaPendiente, 0);
                if (conf > 0)
                {
                    Notificar(conf.ToString(), DateTime.Now.ToString());
                    Utility.MensajeOK("Registro Almacenado.!!");
                    ActiveControls(false);
                    btnNewSave.Enabled = true;
                }
                else
                    Utility.MensajeError("Acción Fallida.!!");
            }

        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ActiveControls(false);
            ClearControls();
            InitializeValues();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var frm = new frmEmpleadoLista();
            EmpleadoBO.Empleado = new DatEmp();
            frm.ShowDialog();
            AssignControls();
            dgvVaciones.Select();
        }


        private void pHasta_ValueChanged(object sender, EventArgs e)
        {
            txtDia.Text = (Convert.ToInt16((pHasta.Value.Date - pDesde.Value.Date).ToString("dd")) + 1).ToString();
        }

        private void pHasta_Validating(object sender, CancelEventArgs e)
        {
            if (pHasta.Value.Date < pDesde.Value.Date)
            {
                ErrProv.SetError(pHasta, "La Fecha no puede ser menor que la Fecha Desde");
                e.Cancel = true;
            }
            else
                ErrProv.Clear();
        }

        private void dgvVaciones_CurrentCellChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewCell item in dgvVaciones.SelectedCells)
            {
                if (item.Selected)
                {
                    txtPeriodo.Text = dgvVaciones.Rows[item.RowIndex].Cells["periodo"].Value.ToString();
                    ContratoBO.Vacacion.empID = txtCodigo.Text;
                    ContratoBO.Vacacion.vacId = Convert.ToInt16(dgvVaciones.Rows[item.RowIndex].Cells["CAB_VAC_ID"].Value);
                    ContratoBO.Vacacion.empConId = Convert.ToInt16(dgvVaciones.Rows[item.RowIndex].Cells["EMP_CON_ID"].Value);
                    dgvVacacionesDT.DataSource = ContratoBO.ListarVacacionDT(ContratoBO.Vacacion.empID,
                                                                       ContratoBO.Vacacion.vacId.ToString(),
                                                                       ContratoBO.Vacacion.empConId.ToString());
                    Design.vVacacionDT(dgvVacacionesDT);
                }
            }
        }

        private void pDesde_ValueChanged(object sender, EventArgs e)
        {
            txtDia.Text = (Convert.ToInt16((pHasta.Value.Date - pDesde.Value.Date).ToString("dd")) + 1).ToString();
        }

        private void dgvVaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 | e.RowIndex == -1)
                return;

            if (dgvVaciones.Columns[e.ColumnIndex].Name == "Periodo")
            {
                frmVacacionesSolicitud fmr = new frmVacacionesSolicitud(ContratoBO.Vacacion.empID, dgvVaciones[1, e.RowIndex].Value.ToString());
                fmr.ShowDialog();
            }

        }

        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyText(e);
        }        

        private void frmVacaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.F5))
                AssignControls();
        }
    }
}