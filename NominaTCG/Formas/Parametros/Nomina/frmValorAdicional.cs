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
    public partial class frmValorAdicional : Form
    {
         private ImpuestoController ValorAdicionalBO { get; set; }
        

        #region Instancia / Constructor
        private static frmValorAdicional _instancia;
        public static frmValorAdicional Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmValorAdicional();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmValorAdicional()
        {
            InitializeComponent();
            InitializeControls();
        }
        #endregion
        
        public void InitializeControls()
        {

            ValorAdicionalBO = ImpuestoController.Instancia;
            dgvDatos.ReadOnly = true;
            LoadData();
        }

        private void LoadData()
        {
            dgvDatos.DataSource = ValorAdicionalBO.ListaValorAdicional();
            lblTotalRecord.Text = "Total Registros:" + dgvDatos.RowCount.ToString();
            //Design.vContrato(dgvDatos);
        }

        private void frmValorAdicional_FormClosing(object sender, FormClosingEventArgs e)
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
                    ValAdi valAdi = new ValAdi();
                    valAdi.adiId = Convert.ToInt32(row["ADI_ID"]);
                    valAdi.adiNombre = row["ADI_NOMBRE"].ToString();
                    valAdi.adiValor = Convert.ToInt32(row["ADI_VALOR"]);                    
                    ValorAdicionalBO.RegistraValorAdicional(valAdi, "I");                   
                }
            }

            getCambios = datos.GetChanges(DataRowState.Modified);

            if (getCambios != null)
            {
                foreach (DataRow row in getCambios.Rows)
                {
                    ValAdi valAdi = new ValAdi();
                    valAdi.adiId = Convert.ToInt32(row["ADI_ID"]);
                    valAdi.adiNombre = row["ADI_NOMBRE"].ToString();
                    valAdi.adiValor = Convert.ToInt32(row["ADI_VALOR"]); 
                    ValorAdicionalBO.RegistraValorAdicional(valAdi, "U");
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
