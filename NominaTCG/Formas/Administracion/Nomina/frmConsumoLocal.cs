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
using db = Entity;
namespace NominaTCG
{
    public partial class frmConsumoLocal : Form, IFrmConsumoLocal
    {
        #region Instancia / Constructor
        private static frmConsumoLocal _instancia;
        public static frmConsumoLocal Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmConsumoLocal();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmConsumoLocal()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;            
        }
        
        #endregion

        #region Variables
        string _peridoID;
        #endregion

        #region Properties
        private EmpleadoController EmpleadoBO { get; set; }
        #endregion
        

        #region Methods
        public void getPeriodoID(string idCodigo)
        {
           _peridoID = idCodigo;
        }
        #endregion

        private void btnConsultar_Click(object sender, EventArgs e)
        {
             
            _peridoID = string.Empty;
            var frm = new frmListaEmergente("Períodos ", "ConsumoLocal");
            frm.ShowDialog(this);

            if (!_peridoID.Equals(string.Empty))
            {
                txtPeriodo.Text = _peridoID;
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (!txtPeriodo.Text.Equals(string.Empty))
            {
                if (DialogResult.Yes == Utility.MensajeQuestion("¿Esta seguro que desea cargar los consumos en locales?"))
                {
                    if (EmpleadoBO.CargaConsumoLocal(txtPeriodo.Text).Equals(1))
                        Utility.MensajeOK("Proceso Existoso..!!");
                    else
                        Utility.MensajeError("Proceso Fallido..!!");
                }
            }
            else
                Utility.MensajeInfo("Seleccione el Período..!!");

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void frmConsumoLocal_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }
    }
}
