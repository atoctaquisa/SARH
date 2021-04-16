using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using db=Entity;

namespace NominaTCG
{
    public partial class frmDiscapacidad : Form
    {
        #region Instancia / Constructor
        //private static frmDiscapacidad _instancia;
        //public static frmDiscapacidad Instancia
        //{
        //    get
        //    {
        //        if (_instancia == null)
        //            _instancia = new frmDiscapacidad("");
        //        return _instancia;
        //    }
        //    set
        //    {
        //        _instancia = value;
        //    }
        //}

        public frmDiscapacidad(string empID)
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            dgvDatos.AutoGenerateColumns = false;
            EmpID = empID;//201908004
            dgvDatos.DataSource = EmpleadoBO.ListaEmpleadoDiscapacidad(EmpID,"");
            TIP_ID.DataSource = EmpleadoBO.ListaDiscapacidad();
            TIP_ID.DisplayMember = "DSCP_TIP_DSC";
            TIP_ID.ValueMember = "DSCP_TIP_ID";
        }
       
        #endregion
        
        #region Properties
        private EmpleadoController EmpleadoBO { get; set ; }        
        private Acction StateButton { get; set; }
        private string EmpID { get; set; }
        
        #endregion

        #region Methods
        private void ActiveControls(Boolean state)
        {
            dgvDatos.Enabled = state;
            btnNewSave.Enabled = state;
            btnDelete.Enabled = state;
        }
        private bool Validatingx()
        {
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                if (!item.IsNewRow)
                {
                    if (item.Cells["TIP_ID"].Value == DBNull.Value)
                    {
                        dgvDatos.Rows[item.Index].ErrorText = "Los datos son requeridos";
                        return false;
                    }

                }
            }
            return true;
        }
        private void AsssingData()        {            

            DataTable data = (DataTable)dgvDatos.DataSource;//new DataTable();
            DataTable dataChange = new DataTable();
            //data = (DataTable)dgvDatos.DataSource;
            EmpleadoBO.Discapicidad = new db.DiscapacidaEmpleadodEntity();
            dataChange = data.GetChanges(DataRowState.Added);            
            if (dataChange != null)
            {
                foreach (DataRow row in dataChange.Rows)
                {                    
                    EmpleadoBO.Discapicidad.EMP_ID = Convert.ToInt64(EmpID); 
                    EmpleadoBO.Discapicidad.DSCP_NUM = row["DSCP_NUM"].ToString();
                    EmpleadoBO.Discapicidad.DSCP_PRCT = Convert.ToInt32(row["DSCP_PRCT"].ToString());
                    EmpleadoBO.Discapicidad.DSCP_TIP_ID = Convert.ToInt32(row["DSCP_TIP_ID"].ToString());
                    EmpleadoBO.Discapicidad.DSCP_DSC = row["DSCP_DSC"].ToString();
                    EmpleadoBO.RegistarDiscapacidad(EmpleadoBO.Discapicidad, "I");
                }
            }
            dataChange = data.GetChanges(DataRowState.Modified);
            if (dataChange != null)
            {
                foreach (DataRow row in dataChange.Rows)
                {
                    EmpleadoBO.Discapicidad.DSCP_ID = Convert.ToInt32(row["DSCP_ID"].ToString());
                    EmpleadoBO.Discapicidad.EMP_ID = Convert.ToInt64(EmpID);
                    EmpleadoBO.Discapicidad.DSCP_NUM = row["DSCP_NUM"].ToString();
                    EmpleadoBO.Discapicidad.DSCP_PRCT = Convert.ToInt32(row["DSCP_PRCT"].ToString());
                    EmpleadoBO.Discapicidad.DSCP_TIP_ID = Convert.ToInt32(row["DSCP_TIP_ID"].ToString());
                    EmpleadoBO.Discapicidad.DSCP_DSC = row["DSCP_DSC"].ToString();
                    EmpleadoBO.RegistarDiscapacidad(EmpleadoBO.Discapicidad, "U");
                }
            }
            dataChange = data.GetChanges(DataRowState.Deleted);
            if (dataChange != null)
            {
                foreach (DataRow row in dataChange.Rows)
                {
                    EmpleadoBO.Discapicidad.DSCP_ID = Convert.ToInt32(row["DSCP_ID",DataRowVersion.Original].ToString());
                    EmpleadoBO.Discapicidad.EMP_ID = Convert.ToInt64(EmpID);
                    EmpleadoBO.RegistarDiscapacidad(EmpleadoBO.Discapicidad, "D");
                }
            }

            dgvDatos.DataSource = EmpleadoBO.ListaEmpleadoDiscapacidad(EmpID,"");
            Utility.MensajeInfo("Datos Actualizados");

        }
        #endregion

        private void frmDiscapacidad_Load(object sender, EventArgs e)
        {
            ActiveControls(false);
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (Validatingx())
            {
                AsssingData();
                ActiveControls(false);
                Design.ControlsEdit(this.btnEditCancel, this.btnNewSave);
            }
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (this.btnEditCancel.Text == "&Editar")
            {
                StateButton = Acction.Edit;
                ActiveControls(true);
            }
            else
            {
                StateButton = Acction.Cancel;                
                ActiveControls(false);
                if (dgvDatos.DataSource != null)
                    ((DataTable)dgvDatos.DataSource).Rows.Clear();
            }
            Design.ControlsEdit(this.btnEditCancel, this.btnNewSave);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (StateButton.Equals(Acction.Edit))
            {
                dgvDatos.Rows.RemoveAt(dgvDatos.CurrentRow.Index);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //_instancia = null;
            this.Close();
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //dgvDatos.Rows[e.RowIndex].ErrorText = string.Empty;
            int index = dgvDatos.CurrentCell.ColumnIndex;
            if (dgvDatos.Columns[index].Name == "NUM" | dgvDatos.Columns[index].Name == "PRCT")
            {
                dText.KeyPress -= new KeyPressEventHandler(dText_KeyPress);
            }
        }

        DataGridViewTextBoxEditingControl dText;
        private void dgvDatos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int index = dgvDatos.CurrentCell.ColumnIndex;
            if (dgvDatos.Columns[index].Name == "NUM" | dgvDatos.Columns[index].Name == "PRCT")
            {
                dText = (DataGridViewTextBoxEditingControl)e.Control;
                //dText.KeyPress -= new KeyPressEventHandler(dText_KeyPress);
                dText.KeyPress += new KeyPressEventHandler(dText_KeyPress);
                
            }
        }

        void dText_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Utility.OnlyDigit(e);
            ////int index = dgvDatos.CurrentCell.ColumnIndex;
            ////if (dgvDatos.Columns[index].Name == "NUM" | dgvDatos.Columns[index].Name == "PRCT")
            ////{

            ////}
            //if (!(Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar)))
            //    e.Handled = true;
            //else
            //    e.Handled = false;
        }
    }
}
