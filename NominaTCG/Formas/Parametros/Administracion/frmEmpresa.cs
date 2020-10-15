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
    public partial class frmEmpresa : Form
    {
        #region Variables
        
        #endregion

        #region Properties
        private PatronoController EmpresaBO { get; set; }
        private Acction StateButton { get; set; }
        private DataView EmpresaView { get; set; }
        private int PatID { get; set; }
        #endregion

        #region Methods
       
        private void AssignControls(int index)
        {
            DataTable data = new DataTable();
            data = EmpresaBO.Listar(index.ToString());
            if (data.Rows.Count > 0)
            {
                EmpresaBO.Empresa.PatronoID = Convert.ToInt32(data.Rows[0]["PAT_ID"].ToString());
                EmpresaBO.Empresa.RazonSocial = data.Rows[0]["PAT_RAZ_SOCIAL"].ToString();
                EmpresaBO.Empresa.Actividad = data.Rows[0]["PAT_ACTIVIDAD"].ToString();
                EmpresaBO.Empresa.Ruc = data.Rows[0]["PAT_NUM_RUC"].ToString();
                EmpresaBO.Empresa.Direccion = data.Rows[0]["PAT_DIR"].ToString();
                EmpresaBO.Empresa.Telefono = data.Rows[0]["PAT_TELF"].ToString();
                EmpresaBO.Empresa.RepLegal = data.Rows[0]["PAT_REP_LEGAL"].ToString();
                EmpresaBO.Empresa.RucContador = data.Rows[0]["PAT_RUC_CONTADOR"].ToString();
                EmpresaBO.Empresa.Observacion = data.Rows[0]["PAT_OBS"].ToString();
                EmpresaBO.Empresa.Estado = Convert.ToUInt16(data.Rows[0]["PAT_ESTADO"].ToString());
                LoadControls();
            }            
        }
        private void LoadControls()
        {
            //PatID = Convert.ToInt32(dgvData.Rows[index].Cells["PAT_ID"].Value.ToString());
            txtRazonSocial.Text = EmpresaBO.Empresa.RazonSocial;
            txtActividad.Text = EmpresaBO.Empresa.Actividad;
            txtRuc.Text = EmpresaBO.Empresa.Ruc;
            txtDireccion.Text = EmpresaBO.Empresa.Direccion;
            txtTelefono.Text = EmpresaBO.Empresa.Telefono;
            txtRepLegal.Text = EmpresaBO.Empresa.RepLegal;
            txtCedula.Text = EmpresaBO.Empresa.RucContador;
            txtObservacion.Text = EmpresaBO.Empresa.Observacion;
            cboEstado.SelectedValue = EmpresaBO.Empresa.Estado;
        }

        private void AssignData()
        {
            //EmpresaBO.Empresa.PatronoID = PatID;
            EmpresaBO.Empresa.RazonSocial = txtRazonSocial.Text;
            EmpresaBO.Empresa.Actividad = txtActividad.Text;
            EmpresaBO.Empresa.Ruc = txtRuc.Text;
            EmpresaBO.Empresa.Direccion = txtDireccion.Text;
            EmpresaBO.Empresa.Telefono = txtTelefono.Text;
            EmpresaBO.Empresa.RepLegal = txtRepLegal.Text;
            EmpresaBO.Empresa.RucContador = txtCedula.Text;
            EmpresaBO.Empresa.Observacion = txtObservacion.Text;
            EmpresaBO.Empresa.Estado = Convert.ToInt32(cboEstado.SelectedValue);

        }

        private bool ValidateControls()
        {
            ErrProv.Clear();

            if (txtRazonSocial.Text == string.Empty)
            {
                ErrProv.SetError(txtRazonSocial, "El Nombre de la empresa es requerido");
                return false;
            }
            if (txtDireccion.Text == string.Empty)
            {
                ErrProv.SetError(txtDireccion, "La Dirección es requerido");
                return false;
            }
            if (txtRuc.Text == string.Empty)
            {
                ErrProv.SetError(txtRuc, "El RUC es requerido");
                return false;
            }
            if (txtRepLegal.Text == string.Empty)
            {
                ErrProv.SetError(txtRepLegal, "El Nombre del representante legal es requerido");
                return false;
            }
            if (txtTelefono.Text == string.Empty)
            {
                ErrProv.SetError(txtTelefono, "El Teléfono para IESS es requerido");
                return false;
            }
            //if (txtCedula.Text == string.Empty)
            //{
            //    ErrProv.SetError(txtCedula, "La Provincia es requerido");
            //    return false;
            //}
            //if (txtActividad.Text == string.Empty)
            //{
            //    ErrProv.SetError(txtActividad, "La Ciudad es requerido");
            //    return false;
            //}

            return true;
        }

        private void InitializeControls()
        {            
            StateButton = Acction.Cancel;            
            EmpresaBO = PatronoController.Instancia;
            EmpresaView = new DataView(EmpresaBO.Listar());            
            cboEstado.DataSource = Catalogo.Estado();
            cboEstado.DisplayMember = "Nombre";
            cboEstado.ValueMember = "ID";            
            ActiveControls(false);
            AssignControls(0);
        }

        private void ActiveControls(bool stdo)
        {
            ErrProv.Clear();
            txtRazonSocial.Enabled = stdo;
            cboEstado.Enabled = stdo;
            txtActividad.Enabled = stdo;
            txtDireccion.Enabled = stdo;
            txtRuc.Enabled = stdo;
            txtTelefono.Enabled = stdo;
            txtRepLegal.Enabled = stdo;
            txtCedula.Enabled = stdo;
            txtObservacion.Enabled = stdo;
        }

        private void ClearControls()
        {
            //PatID = 0;
            cboEstado.SelectedValue = -1;
            //cboPagoServicio.SelectedValue = -1;
            txtRazonSocial.Text = string.Empty;
            txtActividad.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtRuc.Text = string.Empty;
            txtRepLegal.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            
        }

        #endregion

        #region Instancia / Constructor
        private static frmEmpresa _instancia;
        public static frmEmpresa Instancia()
        {
            if (_instancia == null)
                _instancia = new frmEmpresa();
            return _instancia;
        }

        public frmEmpresa()
        {
            InitializeComponent();
            InitializeControls();

        }
        #endregion

        private void frmEmpresa_Load(object sender, EventArgs e)
        {
            Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
        }

        private void frmEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
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
                    if (StateButton == Acction.New)
                        respAction = EmpresaBO.AddNew(EmpresaBO.Empresa);

                    if (StateButton == Acction.Edit)
                        respAction = EmpresaBO.Update(EmpresaBO.Empresa);

                    if (respAction.Equals(0))
                        Utility.MensajeError("Acción Fallida..!!");
                    else
                    {
                        Utility.MensajeOK("Acción Exitosa..!!");
                        ActiveControls(false);
                        ClearControls();
                        InitializeControls();
                        Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
                        AssignControls(respAction);
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
            if (!PatID.Equals(0))
            {
                if (Utility.MensajeQuestion("¿Realmente desea eliminar el registro?") == DialogResult.Yes)
                {
                    int respAction = 0;
                    respAction = EmpresaBO.Delete(PatID);

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

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabAdmin.SelectTab(0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmEmpresaLista frm = new frmEmpresaLista();
            Design.frmDialog(frm, "Lista de Empresas");
            AssignControls(EmpresaBO.Empresa.PatronoID);
        }

        private void txtActividad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyTextAndDigit(e);
        }

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyTextAndDigit(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }

        private void txtRepLegal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyText(e);
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }

        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyTextAndDigit(e);
        }
    }
}
