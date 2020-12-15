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
    public partial class frmDatosIESS : Form
    {
        private ContratoController ContratoBO { get; set; }
        private SistemaController SistemaBO { get; set; }

        #region Instancia / Constructor
        private static frmDatosIESS _instancia;
        public static frmDatosIESS Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmDatosIESS();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmDatosIESS()
        {
            InitializeComponent();
            ContratoBO = ContratoController.Instancia;
            SistemaBO = SistemaController.Instancia;
            cboBanco.DataSource = Catalogo.NovedadTipo();
            cboBanco.DisplayMember = "Nombre";
            cboBanco.ValueMember = "ID";
            IniciaControl();
        }

        #endregion

        private void IniciaControl()
        {
            cboBanco.SelectedIndex = -1;
            txtRol.Text = string.Empty;
            txtReproceso.Text = string.Empty;
            txtFechaIni.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
            txtEmpleado.Text = string.Empty;
            txtRol.Enabled = false;
            txtReproceso.Enabled = false;
            txtFechaIni.Enabled = false;
            txtFechaFin.Enabled = false;
            txtEmpleado.Enabled = false;
            // btnSearchRol.Enabled = false;
            btnSearchEmpleado.Enabled = false;
            ErrProv.Clear();
        }

        private void frmDatosIESS_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnSearchRol_Click(object sender, EventArgs e)
        {
            //dgvData.DataSource = ContratoBO.ListaPeriodo("PREPO");

            var frm = new frmPeridoRolLista("PeridoRolCorto");//"PeridoRolCompleto");
            Design.frmDialog(frm, "Lista de Roles");
            txtRol.Text = ContratoBO.RolSeg.segRolId.ToString();
            txtReproceso.Text = ContratoBO.RolSeg.segRolRepro.ToString();
            txtFechaIni.Text = ContratoBO.RolSeg.rolFechaIni.ToString();
            txtFechaFin.Text = ContratoBO.RolSeg.rolFechaFin.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            IniciaControl();
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (Utility.MensajeQuestion("Desea generar archivo?") == System.Windows.Forms.DialogResult.Yes)
            {
                DataTable datos = ContratoBO.GeneraDatosIESS(txtRol.Text, txtReproceso.Text, cboBanco.SelectedValue.ToString(), txtFechaIni.Text, txtFechaFin.Text);

                string nameFile = cboBanco.Text.ToString();//emp["RAZON"].ToString() + cboTipo.Text.ToUpper().Replace(" ", string.Empty) + "-" + anioINI + anioFIN + ".txt";
                string path = SistemaBO.Path("62");
                if (datos.Rows.Count > 0)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(path+ nameFile+".txt"))
                    {
                        foreach (DataRow row in datos.Rows)
                        {
                            file.WriteLine(row["Detalle"]);
                        }
                    }
                }
            }
          
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }
    }
}
