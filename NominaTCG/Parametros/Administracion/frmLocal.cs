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
    public partial class frmLocal : Form
    {
        #region Variables
        
        #endregion

        #region Properties
        private LocalController LocalBO { get; set; }
        private CatalogoController CatalogoBO { get; set; }
        private Acction StateButton { get; set; }
        private SistemaController SistemaBO { get; set; }
        private DataView LocalView { get; set; }
        #endregion

        #region Methods

        private void Ciudad()
        {
            if (StateButton == Acction.New || StateButton == Acction.Edit)
            {
                var frm = new frmListaEmergente("Ciudad", "Ciudad");
                Design.frmDialog(frm,"Lista de Ciudades");
                txtCiudad.Text = LocalBO.Local.Ciudad;
                txtAbrev.Text = LocalBO.Local.Abrev;
            }
        }

        private void Provincia()
        {
            if (StateButton == Acction.New || StateButton == Acction.Edit)
            {
                var frm = new frmListaEmergente("Provincia", "Provincia");
                Design.frmDialog(frm, "Lista de Provincias");
                txtProvincia.Text = LocalBO.Local.Provincia;
            }
        }

        private void LoadControls()
        {
            if (LocalBO.Local.Nombre == null)
                return;

            txtCodigo.Text = LocalBO.Local.LocalID.ToString();
            cboEstado.SelectedValue = LocalBO.Local.Estado;
            cboPagoServicio.SelectedValue = LocalBO.Local.PagoServicio;
            txtNombre.Text = LocalBO.Local.Nombre;
            txtDireccion.Text = LocalBO.Local.Direccion;
            txtRuc.Text = LocalBO.Local.Ruc;
            txtCodIESS.Text = LocalBO.Local.CodIESS;
            txtTelefono.Text = LocalBO.Local.Telefono;
            txtProvincia.Text = LocalBO.Local.Provincia;
            txtCiudad.Text = LocalBO.Local.Ciudad;
            txtAbrev.Text = LocalBO.Local.Abrev;
        }

        private void AssignControls(int index)
        {
            DataTable data = new DataTable();
            data = LocalBO.Lista(index.ToString());
            if (data.Rows.Count > 0)
            {
                LocalBO.Local.LocalID = Convert.ToInt16(data.Rows[0]["CODIGO"].ToString());
                LocalBO.Local.Nombre = data.Rows[0]["NOMBRE"].ToString();
                LocalBO.Local.Direccion = data.Rows[0]["DIRECCION"].ToString();
                LocalBO.Local.Ruc = data.Rows[0]["RUC"].ToString();
                LocalBO.Local.CodIESS=data.Rows[0]["LOC_COD_IESS"].ToString();
                LocalBO.Local.Telefono = data.Rows[0]["TELEFONO"].ToString();
                LocalBO.Local.PagoServicio=Convert.ToInt16(data.Rows[0]["LOC_PAG_SERVICIO"].ToString());
                LocalBO.Local.Provincia = data.Rows[0]["PROVINCIA"].ToString();
                LocalBO.Local.Abrev = data.Rows[0]["ABRV"].ToString();
                LocalBO.Local.Ciudad = data.Rows[0]["CIUDAD"].ToString();
                LocalBO.Local.Estado=Convert.ToInt16(data.Rows[0]["LOC_ESTADO"].ToString());
                LoadControls();
            }            
        }

        private void AssignData()
        {
            LocalBO.Local.LocalID = txtCodigo.Text.Equals(string.Empty )? 0: Convert.ToInt16(txtCodigo.Text);
            LocalBO.Local.Nombre = txtNombre.Text;
            LocalBO.Local.Direccion = txtDireccion.Text;
            LocalBO.Local.Ruc = txtRuc.Text;
            LocalBO.Local.CodIESS = txtCodIESS.Text;
            LocalBO.Local.Telefono = txtTelefono.Text;
            LocalBO.Local.PagoServicio = Convert.ToInt32(cboPagoServicio.SelectedValue);
            LocalBO.Local.Provincia = txtProvincia.Text;
            LocalBO.Local.Abrev = txtAbrev.Text;
            LocalBO.Local.Ciudad = txtCiudad.Text;
            LocalBO.Local.Estado = Convert.ToInt32(cboEstado.SelectedValue);
        }

        private bool ValidateControls()
        {
            ErrProv.Clear();

            if (txtNombre.Text == string.Empty)
            {
                ErrProv.SetError(txtNombre, "El Nombre es requerido");
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
            if (txtCodIESS.Text == string.Empty)
            {
                ErrProv.SetError(txtCodIESS, "El Código para IESS es requerido");
                return false;
            }
            if (txtTelefono.Text == string.Empty)
            {
                ErrProv.SetError(txtTelefono, "El Teléfono para IESS es requerido");
                return false;
            }
            if (txtProvincia.Text == string.Empty)
            {
                ErrProv.SetError(txtProvincia, "La Provincia es requerido");
                return false;
            }
            if (txtCiudad.Text == string.Empty)
            {
                ErrProv.SetError(txtCiudad, "La Ciudad es requerido");
                return false;
            }

            return true;
        }

        private void InitializeControls()
        {
            
            StateButton = Acction.Cancel;
            LocalBO = LocalController.Instancia;
            LocalView = new DataView(LocalBO.Lista());            
            cboEstado.DataSource = Catalogo.Estado();
            cboEstado.DisplayMember = "Nombre";
            cboEstado.ValueMember = "ID";
            cboPagoServicio.DataSource = Catalogo.Condicional();
            cboPagoServicio.DisplayMember = "Nombre";
            cboPagoServicio.ValueMember = "ID";
            ActiveControls(false);            
        }

        private void ActiveControls(bool stdo)
        {
            ErrProv.Clear();
            txtCodigo.Enabled = false;
            cboEstado.Enabled = stdo;
            cboPagoServicio.Enabled = stdo;
            txtNombre.Enabled = stdo;
            txtDireccion.Enabled = stdo;
            txtRuc.Enabled = stdo;
            txtCodIESS.Enabled = stdo;
            txtTelefono.Enabled = stdo;
            txtAbrev.Enabled = stdo;
            txtCiudad.ReadOnly = true;
            txtProvincia.ReadOnly = true;
            btnSearch.Enabled = !stdo;
            txtNombre.Focus();
        }

        private void ClearControls()
        {
            txtCodigo.Text = string.Empty;
            cboEstado.SelectedValue = -1;
            cboPagoServicio.SelectedValue = -1;
            txtNombre.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtRuc.Text = string.Empty;
            txtCodIESS.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtProvincia.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtAbrev.Text = string.Empty;
        }
        #endregion

        #region Constructor
        private static frmLocal _instancia;
        public static frmLocal Instancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmLocal();
            }
            return _instancia;
        }

        public frmLocal()
        {
            InitializeComponent();
            InitializeControls();
        }
        #endregion

        private void frmLocal_Load(object sender, EventArgs e)
        {
            Design.Controls(this.btnNewSave, this.btnEditCancel, this.btnDelete);
        }

        private void frmLocal_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void txtCiudad_DoubleClick(object sender, EventArgs e)
        {
            Ciudad();
        }        

        private void txtProvincia_DoubleClick(object sender, EventArgs e)
        {
            Provincia();            
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
                        respAction = LocalBO.AddNew(LocalBO.Local);

                    if (StateButton == Acction.Edit)
                        respAction = LocalBO.Update(LocalBO.Local);

                    if (respAction.Equals(0))
                        Utility.MensajeError("Acción Fallida..!!");
                    else
                    {
                        Utility.MensajeOK("Acción Exitosa..!!");
                        ActiveControls(false);
                        ClearControls();
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
            if (txtCodigo.Text != string.Empty)
            {
                if (Utility.MensajeQuestion("Desea Eliminar definitivamente el registro?")== DialogResult.Yes)
                {
                    int respAction = 0;
                    respAction = LocalBO.Delete(Convert.ToInt16(txtCodigo.Text));

                    if (respAction.Equals(0))
                        Utility.MensajeError("Acción Fallida..!!");
                    else
                    {
                        Utility.MensajeOK("Acción Exitosa..!!" + respAction.ToString());
                        ActiveControls(false);
                        ClearControls();                        
                        InitializeControls();
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyTextAndDigit(e);
        }

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }

        private void txtCodIESS_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }

        private void txtAbrev_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyText(e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var frm = new frmLocalLista();            
            Design.frmDialog(frm,"Lista de Locales");
            AssignControls(LocalBO.Local.LocalID);
        }

        private void txtProvincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Provincia();
            }               
        }       

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Ciudad();
            }      
        }


    }
}
