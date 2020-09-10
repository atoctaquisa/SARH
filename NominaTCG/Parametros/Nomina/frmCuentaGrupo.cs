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
    public partial class frmCuentaGrupo : Form
    {
        private CuentaController GrupoCuentaBO { get; set; }
        

        #region Instancia / Constructor
        private static frmCuentaGrupo _instancia;
        public static frmCuentaGrupo Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmCuentaGrupo();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmCuentaGrupo()
        {
            InitializeComponent();
            InitializeControls();
        }
        #endregion
        public void InitializeControls()
        {
            GrupoCuentaBO = CuentaController.Instancia;
            dgvDatos.ReadOnly = true;
            LoadData();
            
        }
        private void LoadData()
        {
            dgvDatos.DataSource = GrupoCuentaBO.ListaGrupoCuentas();
            lblTotalRecord.Text = "Total Registros:" + dgvDatos.RowCount.ToString();
            Design.vContrato(dgvDatos);
        }
        private void frmCuentaGrupo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (btnEditCancel.Text.Equals("&Editar"))
                dgvDatos.ReadOnly = false;
            else
            {
                dgvDatos.ReadOnly = true;
                LoadData();
            }

            Design.ControlsEdit(this.btnEditCancel, this.btnNewSave);
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            DataTable datos = (DataTable)dgvDatos.DataSource;
            DataTable getCambios = datos.GetChanges(DataRowState.Added);
            int numReg = 0;
            if (getCambios != null)
            {
                foreach (DataRow row in getCambios.Rows)
                {
                    GrupoCuentaBO.RegistraGrupoCuenta(Convert.ToInt32(row["GRU_VAR_ROL_ID"]), row["GRU_VAR_ROL_NOMBRE"].ToString(), "I");                    
                }
            }

            getCambios = datos.GetChanges(DataRowState.Modified);

            if (getCambios != null)
            {
                foreach (DataRow row in getCambios.Rows)
                {
                    GrupoCuentaBO.RegistraGrupoCuenta(Convert.ToInt32(row["GRU_VAR_ROL_ID"]), row["GRU_VAR_ROL_NOMBRE"].ToString(), "U");
                }
            }

            if (numReg == 0)
            {
                Utility.MensajeOK("Se actualizó: " + numReg.ToString() + " registros..!!");
                Design.ControlsSave(this.btnEditCancel, this.btnNewSave);
                dgvDatos.ReadOnly = true;

                LoadData();
            }
        }
    }
}
