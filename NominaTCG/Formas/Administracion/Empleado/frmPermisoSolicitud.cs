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
    public partial class frmPermisoSolicitud : Form
    {
        #region Variables

        #endregion

        #region Instancia / Constructor
        private static frmPermisoSolicitud _instancia;
        public static frmPermisoSolicitud Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmPermisoSolicitud();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        private void InitializeControls()
        {
            EmpleadoView = new DataView(EmpleadoBO.ListaEmpleadoDetalle());
            dgvData.DataSource = EmpleadoView;
            Design.vEmpleadoDT(dgvData);
            cboFilter.DataSource = Design.filterData;
            cboFilter.DisplayMember = "Nombre";
            cboFilter.ValueMember = "ID";
            cboTipo.DataSource = ContratoBO.ListarPermisoTipo();
            cboTipo.DisplayMember = "Nombre";
            cboTipo.ValueMember = "ID";
            lblTotalRecord.Text = "Total Registros: " + EmpleadoView.Count.ToString();
            pFechaInicio.Value = DateTime.Now;
            pFechaFin.Value = DateTime.Now;
        }
        #endregion

        #region Methods
        private void AssignData()
        {
            ContratoBO.Permiso.tipID = Convert.ToInt16(cboTipo.SelectedValue);
            ContratoBO.Permiso.perDia = Convert.ToUInt16(txtDia.Text);
            ContratoBO.Permiso.perDia = Convert.ToUInt16(txtDia.Text);
            ContratoBO.Permiso.perFecIni = pFechaInicio.Value;
            ContratoBO.Permiso.perFecFin = pFechaFin.Value;
            ContratoBO.Permiso.perHorIni = txtHoraInicio.Text;
            ContratoBO.Permiso.perHorFin = txtHoraFin.Text;
            ContratoBO.Permiso.perDia = Convert.ToUInt16(txtDia.Text);
            ContratoBO.Permiso.perNumHor = Convert.ToUInt16(txtHora.Text);
            ContratoBO.Permiso.perNumMin = Convert.ToUInt16(txtMinuto.Text);
            ContratoBO.Permiso.perObs = txtObservacion.Text;
        }
        private void ActiveControls(bool stdo)
        {
            ErrProv.Clear();            
            cboTipo.Enabled = stdo;
            pFechaInicio.Enabled = stdo;
            pFechaFin.Enabled = stdo;
            txtHoraInicio.Enabled = stdo;
            txtHoraFin.Enabled = stdo;            
            txtObservacion.Enabled = stdo;
        }
        private void ClearControls()
        {            
            cboTipo.SelectedValue = -1;
            pFechaInicio.Value = DateTime.Now;
            pFechaFin.Value = DateTime.Now;
            txtHoraInicio.Text = "0000";
            txtHoraFin.Text = "0000";
            txtDia.Text = "0";
            txtHora.Text = "0";
            txtMinuto.Text = "0";
            txtFechaReg.Text = string.Empty;
            txtResponsable.Text = string.Empty;
            txtObservacion.Text = string.Empty;
        }
        public frmPermisoSolicitud()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            ContratoBO = ContratoController.Instancia;            
            InitializeControls();            
        }
        private void AssignControls(int index)
        {
            ContratoBO.Permiso.empID = txtCodigo.Text = dgvData.Rows[index].Cells["EMP_ID"].Value.ToString();
            ContratoBO.Permiso.locID = Convert.ToInt16(dgvData.Rows[index].Cells["LOC_ID"].Value);
            ContratoBO.Permiso.escID = Convert.ToInt16(dgvData.Rows[index].Cells["ESC_ID"].Value);
            ContratoBO.Permiso.perRes = "SISTEMAS";
            txtEmpleado.Text = dgvData.Rows[index].Cells["NOMBRE"].Value.ToString();
            txtPatrono.Text = dgvData.Rows[index].Cells["PATRONO"].Value.ToString();
            txtCargo.Text = dgvData.Rows[index].Cells["ESC_CARGOMB"].Value.ToString();
            txtLugar.Text = dgvData.Rows[index].Cells["LOC_NOMBRE"].Value.ToString();
            txtFechaIng.Text = Convert.ToDateTime(dgvData.Rows[index].Cells["LAB_FEC_INGRESO"].Value).ToShortDateString();
            txtEstado.Text = dgvData.Rows[index].Cells["ESTADO"].Value.ToString();
            txtFechaContrato.Text = Convert.ToDateTime(dgvData.Rows[index].Cells["EMP_CON_FEC_CONTRATO"].Value).ToShortDateString();
        }
        private bool ValidateControls()
        {
            ErrProv.Clear();

            if (pFechaFin.Value < pFechaInicio.Value)
            {
                ErrProv.SetError(pFechaFin, "La fecha final no puede ser menor a la inicial");
                return false;
            }
            if (Convert.ToUInt16(txtHora.Text) < 0)
            {
                ErrProv.SetError(txtHora, "No se puede registrar horas negativas");
                return false;
            }

            if (Convert.ToUInt16(txtMinuto.Text) < 0)
            {
                ErrProv.SetError(txtMinuto, "No se puede registrar minutos negativos");
                return false;
            }
            
            return true;
        }
        private void CalcularHoras()
        {
            string cadenaAux1 = txtHoraInicio.Text;
            string cadenaAux2 = txtHoraFin.Text;
            string minIni = cadenaAux1.Substring(0, cadenaAux1.IndexOf(":")).ToString();
            string minFin = cadenaAux2.Substring(0, cadenaAux2.IndexOf(":")).ToString();
            string segIni = cadenaAux1.Substring(cadenaAux1.IndexOf(":") + 1, cadenaAux1.Length - cadenaAux1.IndexOf(":") - 1);
            string segFin = cadenaAux2.Substring(cadenaAux2.IndexOf(":") + 1, cadenaAux2.Length - cadenaAux2.IndexOf(":") - 1);
            var horaIni = DateTime.Parse(pFechaInicio.Text + " " + (minIni.Equals(string.Empty) ? "00" : minIni) + ":" + (segIni.Equals(string.Empty) ? "00" : segIni) + ":00");
            var horaFin = DateTime.Parse(pFechaFin.Text + " " + (minFin.Equals(string.Empty) ? "00" : minFin) + ":" + (segFin.Equals(string.Empty) ? "00" : segFin) + ":00");
            txtDia.Text = (horaFin - horaIni).Days.ToString();
            txtHora.Text = (horaFin - horaIni).Hours.ToString();
            txtMinuto.Text = (horaFin - horaIni).Minutes.ToString();
        }
        #endregion

        #region Properties
        private DataView EmpleadoView { get; set; }
        private Acction StateButton { get; set; }        
        private EmpleadoController EmpleadoBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        #endregion

        private void frmPermisoSolicitud_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void frmPermisoSolicitud_Load(object sender, EventArgs e)
        {
            Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (this.btnNewSave.Text == "&Nuevo")
            {
                StateButton = Acction.New;
                ActiveControls(true);
                ClearControls();
                Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
            }
            else
            {
                AssignData();
                if (ValidateControls())
                {
                    int respAction = 0;
                    //if (StateButton == Acction.New)
                    //if (StateButton == Acction.Edit)
                    //    //respAction = LocalBO.Update(LocalBO.Local);
                    respAction = ContratoBO.RegistraPermisoEmpleado(ContratoBO.Permiso);
                    if (respAction.Equals(0))
                        Utility.MensajeError("Acción Fallida..!!");
                    else
                    {
                        Utility.MensajeOK("Acción Exitosa..!!" + respAction.ToString());
                        ActiveControls(false);
                        ClearControls();
                        Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
                    }
                }
            }
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {            
            //if (this.btnEditCancel.Text != "&Cancelar")
            //{
            //    StateButton = Acction.Edit;
            //    ActiveControls(true);
            //}
            //else
            //{

            //    ClearControls();
            //    StateButton = Acction.Cancel;
            //    InitializeControls();
            //}
            //Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
        }        

        private void btnDelete_Click(object sender, EventArgs e)
        {

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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            EmpleadoView.RowFilter = cboFilter.SelectedValue + " LIKE '%" + txtSearch.Text + "%'";
            dgvData.DataSource = EmpleadoView;
            lblTotalRecord.Text = "Total Registros: " + EmpleadoView.Count.ToString();
        }

        private void pFechaInicio_ValueChanged(object sender, EventArgs e)
        {         
            CalcularHoras();
        }

        private void pFechaFin_ValueChanged(object sender, EventArgs e)
        {         
            CalcularHoras();
        }        

        private void txtHoraInicio_TextChanged(object sender, EventArgs e)
        {
            CalcularHoras();
        }

        private void txtHoraFin_TextChanged(object sender, EventArgs e)
        {
            CalcularHoras();
        }

        private void txtHoraInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }

        private void txtHoraFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }



    }
}
