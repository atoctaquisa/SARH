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
    public partial class frmListaEmergente : Form
    {

        #region Variables
        string _monLista;
        string _where;
        #endregion

        #region Properties
        private CatalogoController catalogoBO { get; set; }
        private LocalController localBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        private CuentaController CuentaBO { get; set; }
        private DataView auxView { get; set; }
        #endregion

        #region Methods
        private void AssignControl(int index)
        {            
            switch (_monLista)
            {
                case "Provincia":
                    localBO.Local.Provincia = dgvData.Rows[index].Cells[1].Value.ToString();
                    break;
                case "Ciudad":
                    localBO.Local.Ciudad = dgvData.Rows[index].Cells[1].Value.ToString();
                    localBO.Local.Abrev = dgvData.Rows[index].Cells[2].Value.ToString();
                    localBO.Local.Regimen = dgvData.Rows[index].Cells[3].Value.ToString();
                    break;
                case "Periodo":
                    IFrmJornada frmJ = frmJornada.Instancia as IFrmJornada;                    
                    if(frmJ != null)
                    {
                        string idPeriodo = dgvData.Rows[index].Cells["SEG_ROL_ID"].Value.ToString();                        
                        frmJ.getPeriodoID(idPeriodo);
                    }
                    break;
                case "PeriodoRol":
                    IFrmResumenRol frmR = frmResumenRol.Instancia as IFrmResumenRol;
                    if (frmR != null)
                    {
                        string idPeriodo = dgvData.Rows[index].Cells["SEG_ROL_ID"].Value.ToString();
                        frmR.getPeriodoID(idPeriodo);
                    }
                    break;
                case "PeriodoRolCuenta":
                    IFrmOperacionRol frmRC = frmOperacionRol.Instancia as IFrmOperacionRol;
                    if (frmRC != null)
                    {
                        string idPeriodo = dgvData.Rows[index].Cells["SEG_ROL_ID"].Value.ToString();
                        frmRC.getPeriodoID(idPeriodo);
                    }
                    break;
                case "Cuentas":
                    IFrmResumenRol frmRR = frmResumenRol.Instancia as IFrmResumenRol;
                    if (frmRR != null)
                    {
                        string nomCuenta = dgvData.Rows[index].Cells["CUENTA"].Value.ToString();
                        string idCuenta = dgvData.Rows[index].Cells["ROL_ID"].Value.ToString();
                        frmRR.getCuentaID(idCuenta);
                        frmRR.getCuentaNom(nomCuenta);

                    }
                    break;
                case "ConsumoLocal":
                    IFrmConsumoLocal frmC = frmConsumoLocal.Instancia as IFrmConsumoLocal;
                    if (frmC != null)
                    {
                        string idPeriodo = dgvData.Rows[index].Cells["SEG_ROL_ID"].Value.ToString();
                        frmC.getPeriodoID(idPeriodo);
                    }
                    break;
            }
        }
        #endregion

        #region Constructor
        public frmListaEmergente(String titulo, string NomLista)
        {
            _monLista = NomLista;
            localBO = LocalController.Instancia;
            ContratoBO = ContratoController.Instancia;
            CuentaBO = CuentaController.Instancia;
            InitializeComponent();
            InitializeControl();
            lblTitulo.Text = titulo;//catalogoBO.forma.Titulo;
            txtFiltro.Focus();
        }

        public void InitializeControl()
        {
            switch (_monLista)
            {
                case "Provincia":
                    _where = "PROVIN_NOMBRE";
                    catalogoBO = new CatalogoController();
                    auxView = new DataView(catalogoBO.ListaProvincia());
                    dgvData.DataSource = auxView;
                    break;
                case "Ciudad":
                    _where = "CIU_NOMBRE";
                    catalogoBO = new CatalogoController();
                    auxView = new DataView(catalogoBO.ListaCiudad());
                    dgvData.DataSource = auxView;
                    break;
                case "PeriodoRol":
                case "PeriodoRolCuenta":
                case "ConsumoLocal":
                case "Periodo":
                    _where = "Convert(SEG_ROL_ID,'System.String')";
                    ContratoBO = new ContratoController();
                    auxView = new DataView(ContratoBO.ListaPeriodo("PU"));
                    dgvData.DataSource = auxView;
                    Design.EmgPeriodoUnico(dgvData);
                    break;

                case "Cuentas":
                    _where = "CUENTA";
                    CuentaBO = new CuentaController();
                    auxView = new DataView(CuentaBO.ListaCuentas());
                    dgvData.DataSource = auxView;
                    Design.EmgPeriodoUnico(dgvData);
                    break; 

            }
            //dgvData.Columns[0].Visible = false;

        }
        #endregion


        private void dgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    foreach (DataGridViewCell cell in dgvData.SelectedCells)
                    {
                        if (cell.Selected)
                        {
                            AssignControl(cell.RowIndex);
                            this.Close();
                        }
                    }
                    break;
                case Keys.Down:
                    break;
                default:
                    break;
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            else
            {
                AssignControl(e.RowIndex);
                this.Close();
            }

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

            auxView.RowFilter = _where + " LIKE '%" + txtFiltro.Text + "%'";
            dgvData.DataSource = auxView;
            lblTotalRecord.Text = "Total Registros: " + auxView.Count.ToString();
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Down)
            {
                dgvData.Select();
                if (dgvData.Rows.Count > 1)
                    dgvData.CurrentCell = dgvData.Rows[1].Cells[0];
            }
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                dgvData.Select();
        }

        private void frmListaEmergente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }
    }
}
