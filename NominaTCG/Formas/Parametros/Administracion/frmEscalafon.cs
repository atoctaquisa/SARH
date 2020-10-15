using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entity;
using BusinessLogic;
namespace NominaTCG
{
    public partial class frmEscalafon : Form
    {
        #region Variables

        #endregion

        #region Properties
        private EscalafonController EscalafonBO { get; set; }
        private CatalogoController CatalogoBO { get; set; }
        private Acction StateButton { get; set; }
        private DataView EscalafonView { get; set; }
        private int idEscalafon { get; set; }
        #endregion

        #region Methods

        private void AssignControls(int index)
        {
            idEscalafon = Convert.ToInt16(dgvData.Rows[index].Cells["ESC_ID"].Value.ToString());
            txtCargo.Text = dgvData.Rows[index].Cells["ESC_CARGOMB"].Value.ToString();
            txtCargoIESS.Text = dgvData.Rows[index].Cells["ESC_CARGOIESS"].Value.ToString();
            txtCodIESSS.Text = dgvData.Rows[index].Cells["ESC_CODIESS"].Value.ToString();
            txtRUB.Text = dgvData.Rows[index].Cells["ESC_SAL_UNIFICADO"].Value.ToString();
            txtSobreTiempo.Text = dgvData.Rows[index].Cells["ESC_ADI_MB"].Value.ToString();
            txtActividad.Text = dgvData.Rows[index].Cells["ESC_COD_ACT_SEC"].Value.ToString();
            chkEstado.Checked = Convert.ToBoolean(dgvData.Rows[index].Cells["ESC_ESTADO"].Value);
            txtAbrev.Text = dgvData.Rows[index].Cells["ESC_ABRE"].Value.ToString();
        }

        private void InitializeControls()
        {
            ttMessage.SetToolTip(cboEstado, "Seleccione el criterio por el cual desea buscar");
            StateButton = Acction.Cancel;
            EscalafonBO = EscalafonController.Instancia;
            EscalafonView = new DataView(EscalafonBO.ListarEscalafon());
            dgvData.DataSource = EscalafonView;
            Design.vEscalafon(dgvData);
            cboEstado.DataSource = Catalogo.Estado();
            cboEstado.DisplayMember = "Nombre";
            cboEstado.ValueMember = "ID";
            cboGrupo.DataSource = EscalafonBO.ListarGrupo();
            cboGrupo.DisplayMember = "ESC_GRU_NOMBRE";
            cboGrupo.ValueMember = "ESC_GRU_ID";
            cboSubGrupo.DataSource = EscalafonBO.ListarSubGrupo();
            cboSubGrupo.DisplayMember = "ESC_GRU_NOMBRE";
            cboSubGrupo.ValueMember = "ESC_GRU_ID";
            ActiveControls(false);
        }

        private void ActiveControls(bool stdo)
        {
            ErrProv.Clear();
            txtCargo.Enabled = stdo;
            txtCargoIESS.Enabled = stdo;
            txtAbrev.Enabled = stdo;
            txtCodIESSS.Enabled = stdo;
            txtRUB.Enabled = stdo;
            txtSobreTiempo.Enabled = stdo;
            chkEstado.Enabled = stdo;
            txtActividad.Enabled = stdo;
        }

        private void ClearControls()
        {
            txtCargo.Text = string.Empty;
            txtCargoIESS.Text = string.Empty;
            txtAbrev.Text = string.Empty;
            txtCodIESSS.Text = string.Empty;
            txtRUB.Text = string.Empty;
            txtSobreTiempo.Text = string.Empty;
            txtActividad.Text = string.Empty;
            idEscalafon = 0;
        }

        private void AssignData()
        {
            EscalafonBO.Escalafon.EscID = idEscalafon;
            EscalafonBO.Escalafon.EscGruID = Convert.ToInt32(cboSubGrupo.SelectedValue);
            EscalafonBO.Escalafon.Cargo = txtCargo.Text;
            EscalafonBO.Escalafon.CategoriaIESS = txtCargoIESS.Text;
            EscalafonBO.Escalafon.CodIESS = txtCodIESSS.Text;
            EscalafonBO.Escalafon.SalarioUnifi = Convert.ToDouble(txtRUB.Text);
            EscalafonBO.Escalafon.AdiBono = txtSobreTiempo.Text==""?0: Convert.ToDouble(txtSobreTiempo.Text);
            EscalafonBO.Escalafon.CodActSec = txtActividad.Text;
            EscalafonBO.Escalafon.Estado = Convert.ToInt16(chkEstado.Checked);
            EscalafonBO.Escalafon.Abrev = txtAbrev.Text;
        }

        private bool ValidateControls()
        {
            ErrProv.Clear();

            if (txtCargo.Text == string.Empty)
            {
                ErrProv.SetError(txtCargo, "El Nombre es requerido");
                return false;
            }
            if (txtCargoIESS.Text == string.Empty)
            {
                ErrProv.SetError(txtCargoIESS, "La Dirección es requerido");
                return false;
            }
            if (txtAbrev.Text == string.Empty)
            {
                ErrProv.SetError(txtAbrev, "Ingrese la abreviación");
                return false;
            }
            return true;
        }

        #endregion

        #region Constructor
        private static frmEscalafon _instancia;
        public static frmEscalafon Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmEscalafon();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmEscalafon()
        {
            InitializeComponent();
            InitializeControls();
        }
        #endregion

        private void frmEscalafon_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void frmEscalafon_Load(object sender, EventArgs e)
        {
            Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
        }

        private void cboSubGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {

            string val = cboSubGrupo.SelectedValue.ToString().Equals("System.Data.DataRowView") ? "0" : cboSubGrupo.SelectedValue.ToString();
            string val0 = cboEstado.SelectedValue.ToString().Equals("System.Data.DataRowView") ? "0" : cboEstado.SelectedValue.ToString();

            EscalafonView.RowFilter = "ESC_GRU_ID=" + Convert.ToInt64(val) + " AND ESC_ESTADO=" + val0;
            dgvData.DataSource = EscalafonView;
            Design.vEscalafon(dgvData);
            lblTotalRecord.Text = "Total Registros: " + EscalafonView.Count.ToString();

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

                if (ValidateControls())
                {
                    AssignData();

                    int respAction = 0;
                    if (StateButton == Acction.New)
                        respAction = EscalafonBO.AddNew(EscalafonBO.Escalafon);

                    if (StateButton == Acction.Edit)
                        respAction = EscalafonBO.Update(EscalafonBO.Escalafon);

                    if (respAction.Equals(0))
                        Utility.MensajeError("Acción Fallida..!!");
                    else
                    {
                        Utility.MensajeOK("Acción Exitosa..!!" + respAction.ToString());
                        ActiveControls(false);
                        ClearControls();
                        InitializeControls();
                        Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
                    }
                }
            }
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {

            if (this.btnEditCancel.Text != "&Cancelar")
            {
                StateButton = Acction.Edit;
                ActiveControls(true);
            }
            else
            {
                ClearControls();
                StateButton = Acction.Cancel;
                InitializeControls();
            }

            Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (Utility.MensajeQuestion("¿Realmente desea eliminar el registro?") == DialogResult.Yes)
            {
                int respAction = 0;
                respAction = EscalafonBO.Delete(idEscalafon);

                if (respAction.Equals(0))
                    Utility.MensajeError("Acción Fallida..!!");
                else
                {
                    Utility.MensajeOK("Acción Exitosa..!!" + respAction.ToString());
                    ActiveControls(false);
                    ClearControls();
                    InitializeControls();
                    Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
                }
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
            }
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
                        }
                    }
                    break;
                case Keys.Down:
                    break;
                default:
                    break;
            }
        }

        private void dgvData_CurrentCellChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewCell item in dgvData.SelectedCells)
            {
                if (item.Selected)
                {
                    AssignControls(item.RowIndex);
                }
            }
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubGrupo.DataSource == null | cboEstado.DataSource == null)
                return;
            string val = cboSubGrupo.SelectedValue.ToString().Equals(null) ? "0" : cboSubGrupo.SelectedValue.ToString();
            string val0 = cboEstado.SelectedValue.ToString().Equals("System.Data.DataRowView") ? "0" : cboEstado.SelectedValue.ToString();
            EscalafonView.RowFilter = "ESC_GRU_ID=" + Convert.ToInt64(val) + " AND ESC_ESTADO=" + val0;
            dgvData.DataSource = EscalafonView;
            Design.vEscalafon(dgvData);
            lblTotalRecord.Text = "Total Registros: " + EscalafonView.Count.ToString();
        }

        private void txtCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyTextAndDigit(e);
        }

        private void txtCargoIESS_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyTextAndDigit(e);
        }

        private void txtAbrev_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyText(e);
        }

        private void txtCodIESSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }

        private void txtRUB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }

        private void txtSobreTiempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }

        private void txtActividad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyText(e);
        }

    }
}
