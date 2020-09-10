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
    public partial class frmPeriodo : Form
    {
        #region Variables
        private Acction StateButton { get; set; }
        private DataView PeriodoView { get; set; }
        private ContratoController ContratoBO { get; set; }
        private string AccionFormulario { get; set; }
        #endregion

        #region Metodos

        private void AssignControls(int index)
        {
            txtCodigo.Text = dgvData.Rows[index].Cells["SEG_ROL_ID"].Value.ToString();
            txtReproceso.Text = dgvData.Rows[index].Cells["SEG_ROL_REPRO"].Value.ToString();
            txtFechaIni.Text = dgvData.Rows[index].Cells["ROL_FECHA_INI"].Value.ToString();
            txtFechaFin.Text = dgvData.Rows[index].Cells["ROL_FECHA_FIN"].Value.ToString();
            txtTotalIng.Text = dgvData.Rows[index].Cells["TOTAL_ING"].Value.ToString();
            txtEgr.Text = dgvData.Rows[index].Cells["TOTAL_EGR"].Value.ToString();
            txtEntr.Text = dgvData.Rows[index].Cells["TOTAL_TOTAL"].Value.ToString();
            txtEmp.Text = dgvData.Rows[index].Cells["TOTAL_EMP"].Value.ToString();
        }
        
        private void ClearControls()
        {
            txtCodigo.Text = string.Empty;
            txtReproceso.Text = string.Empty;
            txtFechaIni.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
            txtTotalIng.Text = string.Empty;
            txtEgr.Text = string.Empty;
            txtEntr.Text = string.Empty;
            txtEmp.Text = string.Empty;
        } 
        private void MensajePeriodo()
        {
            if (ContratoBO.VerificaPeriodo().Equals(1))
                lblMessage.Text = "El período se encuentra Abierto..!!";
            else
                lblMessage.Text = "   No existen períodos Abiertos..!!";
        }

        #endregion

        #region Instancia / Constructor
        private static frmPeriodo _instancia;
        public static frmPeriodo Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmPeriodo();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmPeriodo()
        {
            InitializeComponent();
            ContratoBO = ContratoController.Instancia;                     
            ttMessage.SetToolTip(btnNewSave, "Abrir/Cerrar Período");
            ttMessage.SetToolTip(btnEditCancel, "Generar/Reprocesar Roles");
            LoadData();
            MensajePeriodo();
            dgvData.ReadOnly = true;
        }

        private void LoadData()
        {
            PeriodoView = new DataView(ContratoBO.ListaPeriodo("P"));
            dgvData.DataSource = PeriodoView;
            Design.vPeriodo(dgvData);
        }
        #endregion       

        private void frmPeriodo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            else
            {
                AssignControls(e.RowIndex);
                tabAdmin.SelectTab(1);
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            else
            {
                AssignControls(e.RowIndex);
            }
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (Validar())
                return;

            ErrProv.Clear();
            if (ContratoBO.VerificaPeriodo() != 1)
            {
                if (DialogResult.Yes == Utility.MensajeQuestion("¿Esta seguro de querer abrir un nuevo período?"))
                    if (ContratoBO.AperturaPeriodo().Equals(1))
                    {
                        Utility.MensajeOK("Período Aperturado..!!");
                        LoadData();
                        MensajePeriodo();
                    }   
                    else
                        Utility.MensajeError("Acción Fallida..!!");
            }
            else
                Utility.MensajeError("Primero debe cerrar el Período..!!");
        }

        private bool Validar()
        {
            int ban = 1;
            if (txtCodigo.Text.Equals(string.Empty))
                ErrProv.SetError(txtCodigo, (ban++)+" Seleccione el período");

            if (ban > 1)
                return true;
            else
                return false;
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {

                if (ContratoBO.VerificaPeriodo(Convert.ToInt32(txtCodigo.Text), 0, "") == 0)
                {
                    int NumProceso = ContratoBO.NumeroProceso(Convert.ToInt32(txtCodigo.Text), "ProcesoPeriodo");
                    if (NumProceso == 1)
                    {
                        if (DialogResult.Yes == Utility.MensajeQuestion("¿Esta seguro que desea generar valores iniciales para el período: " + txtCodigo.Text + " ?"))
                            if (ContratoBO.GeneraRol(Convert.ToInt32(txtCodigo.Text), NumProceso).Equals(1))
                            {
                                LoadData();
                                Utility.MensajeOK("Valores Generados..!!");
                            }
                                
                            else
                                Utility.MensajeError("Acción Fallida..!!");
                    }
                    else
                    {
                        if (DialogResult.Yes == Utility.MensajeQuestion("¿Esta seguro que desea generar el reproceso: " + NumProceso.ToString() + " para el período: " + txtCodigo.Text + " ?"))
                            if (ContratoBO.GeneraRol(Convert.ToInt32(txtCodigo.Text), NumProceso).Equals(1))
                            {
                                LoadData();
                                Utility.MensajeOK("Valores Generados..!!");                                
                            }
                                
                            else
                                Utility.MensajeError("Acción Fallida..!!");
                    }
                }
                else
                    Utility.MensajeInfo("No se puede generar ningún cambio..!!");

            }
            else
                Utility.MensajeInfo("Seleccione el período para la generación de rol..!!");
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    foreach (DataGridViewCell cell in dgvData.SelectedCells)
                    {
                        if (cell.Selected)
                        {
                            AssignControls(cell.RowIndex);
                            tabAdmin.SelectTab(1);
                        }
                    }
                    break;
                case Keys.Down:
                    break;
                default:
                    break;
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

        private void button1_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }
    }
}
