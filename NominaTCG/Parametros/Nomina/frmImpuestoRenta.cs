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
    public partial class frmImpuestoRenta : Form
    {
        private ImpuestoController ImpuestoRentaBO { get; set; }

        #region Instancia / Constructor
        private static frmImpuestoRenta _instancia;
        public static frmImpuestoRenta Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmImpuestoRenta();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmImpuestoRenta()
        {
            InitializeComponent();
            InitializeControls();
        }
        #endregion
        public void InitializeControls()
        {
            ImpuestoRentaBO = ImpuestoController.Instancia;
            dgvDatos.ReadOnly = true;
            LoadData();
        }

        private void LoadData()
        {
            dgvDatos.DataSource = ImpuestoRentaBO.ListaImpuestoRenta();
            lblTotalRecord.Text = "Total Registros:" + dgvDatos.RowCount.ToString();
            Design.vContrato(dgvDatos);
        }

        private void frmImpuestoRenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
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
                    ValAdiRen impRenta = new ValAdiRen();
                    impRenta.adiRenId = 0;//Convert.ToInt32(row["ADI_REN_ID"]);
                    impRenta.adiRenFracBas = Convert.ToInt32(row["ADI_REN_FRAC_BAS"]);
                    impRenta.adiRenExes = Convert.ToInt32(row["ADI_REN_EXES"]);
                    impRenta.adiRenImp = Convert.ToInt32(row["ADI_REN_IMP"]);
                    impRenta.adiRenPor = Convert.ToInt32(row["ADI_REN_POR"]);
                    ImpuestoRentaBO.RegistraImpuestoRenta(impRenta, "I");
                    
                    //if (ImpuestoRentaBO.RegistraPermisoTipo(0, row["TIP_NOMBRE"].ToString(), row["TIP_OBS"].ToString(), Convert.ToInt32(row["TIP_TIPO"]), 0).Equals(0))
                    //    numReg++;
                }
            }

            getCambios = datos.GetChanges(DataRowState.Modified);

            if (getCambios != null)
            {
                foreach (DataRow row in getCambios.Rows)
                {
                    ValAdiRen impRenta = new ValAdiRen();
                    impRenta.adiRenId = Convert.ToInt32(row["ADI_REN_ID"]);
                    impRenta.adiRenFracBas = row["ADI_REN_FRAC_BAS"].ToString()!=""?Convert.ToInt32(row["ADI_REN_FRAC_BAS"]): dbType.intNull;
                    impRenta.adiRenExes = row["ADI_REN_EXES"].ToString()!=""? Convert.ToInt32(row["ADI_REN_EXES"]): dbType.intNull;
                    impRenta.adiRenImp = row["ADI_REN_IMP"].ToString()!=""?Convert.ToInt32(row["ADI_REN_IMP"]): dbType.intNull;
                    impRenta.adiRenPor = row["ADI_REN_POR"].ToString() != "" ? Convert.ToInt32(row["ADI_REN_POR"]) : dbType.intNull;
                    ImpuestoRentaBO.RegistraImpuestoRenta(impRenta, "U");
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }
    }
}
