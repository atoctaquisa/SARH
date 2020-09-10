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
    public partial class frmContratoFin : Form
    {
        
        private ContratoController CatalogoBO { get; set; }
        #region Instancia / Constructor
        private static frmContratoFin _instancia;
        public static frmContratoFin Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmContratoFin();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmContratoFin()
        {
            InitializeComponent();
            InitializeControls();
        }
        #endregion

        private void LoadData()
        {
            dgvDatos.DataSource = CatalogoBO.ListarContratoFin();
            Design.vContratoFin(dgvDatos);
            lblTotalRecord.Text = "Total Registros:" + dgvDatos.RowCount.ToString();
        }
        private void InitializeControls()
        {
            //btnAccion = 0;
            CatalogoBO = new ContratoController();
            LoadData();            
        }
        private void frmContratoFin_FormClosing(object sender, FormClosingEventArgs e)
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
                    if (CatalogoBO.RegistraContratoFin(0, row["CON_CAU_CAUSA"].ToString(), row["CON_CAU_ABREV"].ToString(), 0).Equals(0))
                        numReg++;
                }
            }

            getCambios = datos.GetChanges(DataRowState.Modified);

            if (getCambios != null)
            {
                //int numReg = 0;
                foreach (DataRow row in getCambios.Rows)
                {
                    if (CatalogoBO.RegistraContratoFin(Convert.ToInt32(row["CON_CAU_ID"]), row["CON_CAU_CAUSA"].ToString(), row["CON_CAU_ABREV"].ToString(), 1).Equals(0))
                        numReg++;
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

        private void btnExist_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }
    }
}
