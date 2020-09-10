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
    public partial class frmContrato : Form
    {
  
        private ContratoController ContratoBO { get; set; }        

        #region Instancia / Constructor
        private static frmContrato _instancia;
        public static frmContrato Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmContrato();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmContrato()
        {
            InitializeComponent();
            InitializeControls();
        }
        #endregion


        private void LoadData()
        {            
            dgvDatos.DataSource = ContratoBO.ListarContrato();
            Design.vContrato(dgvDatos);
            lblTotalRecord.Text = "Total Registros:" + dgvDatos.RowCount.ToString();
        }

        private void InitializeControls()
        {            
            ContratoBO = new ContratoController();
            dgvDatos.ReadOnly = true;
            LoadData();
        }

        private void frmContrato_Load(object sender, EventArgs e)
        {

        }
        private void frmContrato_FormClosing(object sender, FormClosingEventArgs e)
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
                    if (ContratoBO.RegistraContratoTipo(0, row["TIPO"].ToString(), row["DESCRIPCION"].ToString(), 0).Equals(0))
                        numReg++;
                }
            }

            getCambios = datos.GetChanges(DataRowState.Modified);

            if (getCambios != null)
            {
                //int numReg = 0;
                foreach (DataRow row in getCambios.Rows)
                {
                    if (ContratoBO.RegistraContratoTipo(Convert.ToInt32(row["ID"]), row["TIPO"].ToString(), row["DESCRIPCION"].ToString(), 1).Equals(0))
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

            //if (getCambios != null)
            //{
            //    int numReg = 0;
                
            //    foreach (DataRow row in getCambios.Rows)
            //    {
            //        if (ContratoBO.RegistraContratoTipo(Convert.ToInt32(row["ID"]), row["TIPO"].ToString(), row["DESCRIPCION"].ToString(),1).Equals(1))
            //            numReg++;
            //    }

            //    if (numReg > 0)
            //    {
            //        Utility.MensajeOK("Se actualizó: " + numReg.ToString() + " registros..!!");
            //        Design.ControlsSave(this.btnEditCancel, this.btnNewSave);
            //        dgvDatos.ReadOnly = true;
            //        LoadData();
            //    }
            //}
           
        }

        private void dgvDatos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =
           dgvDatos.Columns[e.ColumnIndex].HeaderText;

           // // Abort validation if cell is not in the CompanyName column.
           // if (!headerText.Equals("CompanyName")) return;
            if (e.ColumnIndex == -1 | e.RowIndex == -1)
                return;
            if (!dgvDatos.Rows[e.RowIndex].IsNewRow)
            {
                if (dgvDatos.Columns[e.ColumnIndex].Name == "TIPO")
                {

                    if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        dgvDatos.Rows[e.RowIndex].ErrorText =
                            "El campo es requerido";
                        e.Cancel = true;
                    }
                }
            }
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvDatos.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dgvDatos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDatos.IsCurrentCellDirty)
            {
                dgvDatos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }               
        
    }
}
