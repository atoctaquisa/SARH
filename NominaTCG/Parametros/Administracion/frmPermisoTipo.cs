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
    public partial class frmPermisoTipo : Form
    {
        private ContratoController ContratoBO { get; set; }   

        #region Instancia / Constructor
        private static frmPermisoTipo _instancia;
        public static frmPermisoTipo Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmPermisoTipo();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        
        #endregion

        public frmPermisoTipo()
        {
            InitializeComponent();
            InitializeControls();
        }
        private void LoadData()
        {
            

            //
            // bindeo los datos de los productos a la grilla
            //
            //dgvDatos.AutoGenerateColumns = false;
            


            dgvDatos.DataSource = ContratoBO.ListarPermisoTipo();
            lblTotalRecord.Text = "Total Registros:" + dgvDatos.RowCount.ToString();
            Design.vContrato(dgvDatos);            
        }

        private void InitializeControls()
        {       

            ContratoBO = new ContratoController();
            dgvDatos.AutoGenerateColumns = false;            
            TIP_TIPO.DataSource = ContratoBO.ListarTipo();
            TIP_TIPO.DisplayMember = "TIP_NOMBRE";
            TIP_TIPO.ValueMember = "TIP_TIPO";
            dgvDatos.ReadOnly = true;
            LoadData();
            

            
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
                    if (ContratoBO.RegistraPermisoTipo(0, row["TIP_NOMBRE"].ToString(), row["TIP_OBS"].ToString(), Convert.ToInt32(row["TIP_TIPO"]), 0).Equals(0))
                        numReg++;
                }
            }

            getCambios = datos.GetChanges(DataRowState.Modified);

            if (getCambios != null)
            {                
                foreach (DataRow row in getCambios.Rows)
                {
                    if (ContratoBO.RegistraPermisoTipo(Convert.ToInt32(row["TIP_ID"]), row["TIP_NOMBRE"].ToString(), row["TIP_OBS"].ToString(), Convert.ToInt32(row["TIP_TIPO"]), 1).Equals(0))
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

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvDatos.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }
    }
}
