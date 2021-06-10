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
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;

namespace NominaTCG
{
    public partial class frmCargaAsiento : Form
    {

        private PatronoController PatronoBO { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        double _Egreso;
        #region Instancia / Constructor
        private static frmCargaAsiento _instancia;
        public static frmCargaAsiento Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmCargaAsiento();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmCargaAsiento()
        {
            InitializeComponent();
            ContratoBO = ContratoController.Instancia;
            //ReportBO = ReportDataController.Instancia;
            //LocalBO = LocalController.Instancia;
            PatronoBO = PatronoController.Instancia;
            EmpleadoBO = EmpleadoController.Instancia;
        }
        #endregion

        private void frmCargaAsiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (!txtPeriodo.Text.Equals(string.Empty))
            {
                if (EmpleadoBO.VerificaAsientoRol(txtPeriodo.Text, ContratoBO.RolSeg.segRolRepro.ToString(), 0).Equals( 0))
                {
                    if (DialogResult.Yes == Utility.MensajeQuestion("¿Esta seguro que desea generar asientos de NOMINA?"))
                    {                       
                        if (EmpleadoBO.GeneraAsientoRol(txtPeriodo.Text, "", 0).Equals(1))
                        {
                            ConsultaAsientoRol();
                            Utility.MensajeOK("Proceso Existoso..!!");
                        }
                        else
                        {
                            dgvData.DataSource = null;
                            Utility.MensajeError("Proceso Fallido..!!");
                        }                            
                    }
                }
                else
                {
                    ConsultaAsientoRol();
                    Utility.MensajeInfo("Ya se encuentran generados los asientos para este Período");
                }
                    
                
            }
            else
                Utility.MensajeInfo("Seleccione el Período..!!");
           
        }
        private void TotalSalary()
        {

            _Egreso = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells["DIFERENCIA"].Value != null)
                    {
                        _Egreso += row.Cells["DIFERENCIA"].Value == DBNull.Value ? 0 : Convert.ToDouble(row.Cells["DIFERENCIA"].Value);
                    }
                }
            }

            lblTotal.Text = "Total Diferencia: " + _Egreso.ToString();

        }
        private void ConsultaAsientoRol()
        {
            dgvData.DataSource = EmpleadoBO.ConsultaAsientoRol(txtPeriodo.Text, "", 1);
            TotalSalary();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var frm = new frmPeridoRolLista("PeridoRolCorto");//"PeridoRolCompleto");
            Design.frmDialog(frm, "Lista de Roles");
            txtPeriodo.Text = ContratoBO.RolSeg.segRolId.ToString();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (EmpleadoBO.VerificaAsientoRol(txtPeriodo.Text, ContratoBO.RolSeg.segRolRepro.ToString(), 1).Equals(1))
            {
                if (_Egreso != 0)
                {
                    if (DialogResult.Yes == Utility.MensajeQuestion("Existen Diferencias.!! ¿Desea continuar con la carga?"))
                    {
                        CargarAsientosJDE();
                    }
                }
                else
                {
                    CargarAsientosJDE();
                }

            }
            else
                Utility.MensajeError("Accción Fallida!! Los asientos ya fueron cargados..!!");
        }

        private void CargarAsientosJDE()
        {
            if (DialogResult.Yes == Utility.MensajeQuestion("¿Esta seguro que desea cargar asientos a JDE?"))
            {
                if (EmpleadoBO.GeneraAsientoRol(txtPeriodo.Text, "", 1).Equals(1))
                {
                    //ConsultaAsientoRol();
                    Utility.MensajeOK("Proceso Existoso..!!");
                }
                else
                {
                    //dgvData.DataSource = null;
                    Utility.MensajeError("Proceso Fallido..!!");
                }

            }
        }
    }
}
