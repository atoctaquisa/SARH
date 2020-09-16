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
    public partial class frmQuincena : Form
    {
        private ContratoController ContratoBO { get; set; }

        #region Instancia / Constructor
        private static frmQuincena _instancia;
        public static frmQuincena Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmQuincena();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmQuincena()
        {
            InitializeComponent();
            ContratoBO = ContratoController.Instancia;
            //ttMessage.SetToolTip(btnNewSave, "Abrir/Cerrar Período");
            //ttMessage.SetToolTip(btnEditCancel, "Generar/Reprocesar Roles");
            //LoadData();
            //MensajePeriodo();
        }

        //private void LoadData()
        //{
        //    PeriodoView = new DataView(ContratoBO.ListaPeriodo("P"));
        //    dgvData.DataSource = PeriodoView;
        //    Design.vPeriodo(dgvData);
        //}
        #endregion

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (!ContratoBO.VerificaQuincena().Equals(0))
            {
                if (DialogResult.Yes == Utility.MensajeQuestion("¿Esta seguro que desea cargar Quincenas?"))
                {
                    if (ContratoBO.CargaQuincena().Equals(1))
                        Utility.MensajeOK("Quincenas cargadas..!!");
                    else
                        Utility.MensajeError("Acción Fallida..!! Debe abrir un Período");
                }
            }
            else
                Utility.MensajeInfo("Acción Fallida..!! Carga de Quincena Deshabilitada ");

        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void frmQuincena_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }
    }
}
