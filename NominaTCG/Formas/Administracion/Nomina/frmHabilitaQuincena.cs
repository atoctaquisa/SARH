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
    public partial class frmHabilitaQuincena : Form
    {

        #region Properties
        private ContratoController ContratoBO { get; set; }
        #endregion

        #region Metodos

        #endregion

        #region Instancia / Constructor
        private static frmHabilitaQuincena _instancia;
        public static frmHabilitaQuincena Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmHabilitaQuincena();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmHabilitaQuincena()
        {
            InitializeComponent();
            ContratoBO = ContratoController.Instancia;
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.ReadOnly = true;
            LoadData();
        }

        private void LoadData()
        {
            dgvDatos.DataSource = ContratoBO.ListaPeriodo("PQ");
            lblTotalRecord.Text = "Total Registros:" + dgvDatos.RowCount.ToString();
        }
        #endregion

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (btnEditCancel.Text.Equals("&Editar"))
            {
                dgvDatos.ReadOnly = false;
                foreach (DataGridViewColumn item in dgvDatos.Columns)
                {
                    string i = item.GetType().ToString();
                    if (item.GetType().Equals(typeof(DataGridViewCheckBoxColumn)))
                    {
                        DataGridViewCheckBoxColumn check = (DataGridViewCheckBoxColumn)item;
                        check.ReadOnly = false;                     
                    }
                    else
                        item.ReadOnly = true;
                }
            }

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
            DataTable getCambios = datos.GetChanges(DataRowState.Modified);
            if (getCambios != null)
            {
                int numReg = 0;
                foreach (DataRow row in getCambios.Rows)
                {
                    if (ContratoBO.HabilitaQuincena(Convert.ToInt16(row["SEG_ROL_ID"]), Convert.ToInt16(row["SEG_ROL_REPRO"]), Convert.ToInt16(row["SEG_EST_QUIN"])).Equals(1))
                        numReg++;
                }

                if (numReg > 0)
                {
                    Utility.MensajeOK("Se actualizó: Nº " + numReg.ToString() + " registros..!!");
                    Design.ControlsSave(this.btnEditCancel, this.btnNewSave);
                    dgvDatos.ReadOnly = true;
                    LoadData();
                }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void frmHabilitaQuincena_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }
    }
}
