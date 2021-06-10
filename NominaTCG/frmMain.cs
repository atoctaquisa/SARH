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
    public partial class frmMain : Form
    {
        #region Variables
        bool _closeWindows = true;
        #endregion

        #region Properties
        private SistemaController SistemaBO { get; set; }
        #endregion

        #region Methods
        private bool stateMenu(string mnuCode)
        {
            return SistemaBO.StateMenu(Catalogo.CodeSystem, mnuCode,Catalogo.UserRole);
        }

        private void recordLevel(ToolStripItemCollection subMenu)
        {
            foreach (object item in subMenu)
            {
                ToolStripMenuItem itemAux = item as ToolStripMenuItem;
                if (itemAux!=null)
                {       
                    if (itemAux.DropDownItems.Count > 0)
                    {
                        itemAux.Enabled = stateMenu(itemAux.Tag.ToString());
                        recordLevel(itemAux.DropDownItems);
                    }
                    else
                        itemAux.Enabled = stateMenu(itemAux.Tag.ToString());
                }
            }
        }
        #endregion
                
        #region Constructor
        public frmMain()
        {
            InitializeComponent();
            SistemaBO = SistemaController.Instancia;
            Catalogo.CodeSystem = SistemaBO.CodeSystem();
            frmAccesoClave frm = new frmAccesoClave();
            frm.ShowDialog();
            tssUsuario.Text = "Usuario: " + Catalogo.UserName;
            tssPerfil.Text = "Perfil: " + Catalogo.UserProfile;
            toolVs.Text = "vs: "+System.IO.File.GetLastWriteTime(Application.ExecutablePath).ToShortDateString().Replace("/",".");
            toolServer.Text = Catalogo.ServerData;
        }       
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem mnu in mnuMain.Items)
            {
                if (mnu.DropDownItems.Count > 0)
                {
                    mnu.Visible = stateMenu(mnu.Tag.ToString());
                    recordLevel(mnu.DropDownItems);
                }
                else
                    mnu.Visible = stateMenu(mnu.Tag.ToString());
            }
        }

        private void mnuLocal_Click(object sender, EventArgs e)
        {
            var frm = frmLocal.Instancia();            
            frm.MdiParent = this;                        
            Design.frmShow(frm);
        }
        
        private void mnuEmpresa_Click(object sender, EventArgs e)
        {
            var frm = frmEmpresa.Instancia();
            frm.MdiParent = this;            
            Design.frmShow(frm);
        }

        private void mnuInformacionEmp_Click(object sender, EventArgs e)
        {
            var frm = frmEmpleado.Instancia;
            frm.MdiParent = this;            
            Design.frmShow(frm);

        }

        private void mnuEscalafon_Click(object sender, EventArgs e)
        {
            var frm = frmEscalafon.Instancia;
            frm.MdiParent = this;            
            Design.frmShow(frm);
        }

        private void mnuContrato_Click(object sender, EventArgs e)
        {
            var frm = frmContrato.Instancia;
            frm.MdiParent = this;            
            Design.frmShow(frm);
        }

        private void mnuCuentaIO_Click(object sender, EventArgs e)
        {
            var frm = frmCuentaIO.Instancia;
            frm.MdiParent = this;            
            Design.frmShow(frm);
        }

        private void mnuImpuestoRenta_Click(object sender, EventArgs e)
        {
            var frm = frmImpuestoRenta.Instancia;
            frm.MdiParent = this;            
            Design.frmShow(frm);
        }

        private void mnuValorAdicional_Click(object sender, EventArgs e)
        {
            var frm = frmValorAdicional.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuGrupoCuenta_Click(object sender, EventArgs e)
        {
            var frm = frmCuentaGrupo.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuJornada_Click(object sender, EventArgs e)
        {
            var frm = frmJornada.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }        

        private void mnuPeriodo_Click(object sender, EventArgs e)
        {
            var frm = frmPeriodo.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuQuincena_Click(object sender, EventArgs e)
        {
            var frm = frmHabilitaQuincena.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);        
        }

        private void mnuResumenRol_Click(object sender, EventArgs e)
        {
            var frm = frmResumenRol.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuSubirQuincena_Click(object sender, EventArgs e)
        {
            var frm = frmQuincena.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuSubirConsumo_Click(object sender, EventArgs e)
        {
            var frm = frmConsumoLocal.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuResumenRol_Click_1(object sender, EventArgs e)
        {
            var frm = frmResumenRol.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuAprobacion_Click(object sender, EventArgs e)
        {
            var frm = frmVacacionesAprobacion.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuVacaciones_Click(object sender, EventArgs e)
        {
            var frm = frmVacaciones.Instancia;
            frm.MdiParent = this;            
            Design.frmShow(frm);
        }        
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_closeWindows)
            {
                if (Utility.MensajeQuestion("¿Desea salir del Aplicativo?") == DialogResult.No)
                    e.Cancel = true;
                else
                {
                    _closeWindows = false;
                    Application.Exit();
                }
            }
        }

        private void mnuOperacionRol_Click(object sender, EventArgs e)
        {
            var frm = frmOperacionRol.Instancia;
            frm.MdiParent = this;            
            Design.frmShow(frm);
        }

        private void mnuActuarial_Click(object sender, EventArgs e)
        {
            var frm = frmActuarial.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuContratoTipo_Click(object sender, EventArgs e)
        {
            var frm = frmContrato.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuContratoFinaliza_Click(object sender, EventArgs e)
        {
            var frm = frmContratoFin.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuPermisoTipo_Click(object sender, EventArgs e)
        {
            var frm = frmPermisoTipo.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuGestionPermiso_Click(object sender, EventArgs e)
        {
            var frm = frmGestionPermiso.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuValorGrupo_Click(object sender, EventArgs e)
        {
            var frm = frmIngresoValorGrupo.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuPrestamo_Click(object sender, EventArgs e)
        {
            var frm = frmPrestamoDescuento.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuValorDeduccion_Click(object sender, EventArgs e)
        {
            var frm = frmDeduccionGastos.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuTransferencias_Click(object sender, EventArgs e)
        {
            var frm = frmTransferenciaBanco.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuRolIndividual_Click(object sender, EventArgs e)
        {
            var frm = frmRolIndividual.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuCalculoDT_Click(object sender, EventArgs e)
        {
            var frm = frmCalcularDT.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuCalculoDC_Click(object sender, EventArgs e)
        {
            var frm = frmCalcularDC.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuCalculoLiquidacion_Click(object sender, EventArgs e)
        {
            var frm = frmCalcularLiquidacion.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuCalculoUtilidad_Click(object sender, EventArgs e)
        {
            var frm = frmCalcularUT.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }
    

        private void mnuValorUtilidad_Click(object sender, EventArgs e)
        {
            //var frm = frmValorUtilidad.Instancia;
            //frm.MdiParent = this;
            //Design.frmShow(frm);
        }

        private void mnuMaternidad_Click(object sender, EventArgs e)
        {
            var frm = frmMaternidad.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuDatosIESS_Click(object sender, EventArgs e)
        {
            var frm = frmDatosIESS.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuPagoQuincena_Click(object sender, EventArgs e)
        {
            var frm = frmPagoQuincena.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuDetalleContabilidad_Click(object sender, EventArgs e)
        {
            var frm = frmDetalleContabilidad.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuProvisiones_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("http://192.168.1.116:9502/analytics/saw.dll?bipublisherEntry&Action=open&itemType=.xdo&bipPath=%2FInformes%20Recursos%20Humanos%2FProvisiones.xdo&path=%2Fshared%2FInformes%20Recursos%20Humanos%2FProvisiones.xdo");
            var frm = frmProvisiones.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuPrestamos_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("http://192.168.1.116:9502/analytics/saw.dll?bipublisherEntry&Action=edit&itemType=.xdo&bipPath=%2FInformes%20Recursos%20Humanos%2FPrestamos.xdo&path=%2Fshared%2FInformes%20Recursos%20Humanos%2FPrestamos.xdo");
            var frm = frmRepPrestamo.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuRolNegativo_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("http://192.168.1.116:9502/analytics/saw.dll?bipublisherEntry&Action=open&itemType=.xdo&bipPath=%2FInformes%20Recursos%20Humanos%2FProvisiones.xdo&path=%2Fshared%2FInformes%20Recursos%20Humanos%2FProvisiones.xdo");
            var frm = frmRolNegativoRep.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuIngresoEgreso_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://192.168.1.116:9502/analytics/saw.dll?bipublisherEntry&Action=open&itemType=.xdo&bipPath=%2FInformes%20Recursos%20Humanos%2FIngresoEgresoEmpleado.xdo&path=%2Fshared%2FInformes%20Recursos%20Humanos%2FIngresoEgresoEmpleado.xdo");
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuInformacion_Click(object sender, EventArgs e)
        {
            var frm = frmRepEmpleado.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuVacacionRep_Click(object sender, EventArgs e)
        {
            var frm = frmVacacionRep.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuCertificado_Click(object sender, EventArgs e)
        {
            var frm = frmCertificado.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuValorFijo_Click(object sender, EventArgs e)
        {
            var frm = frmValorFijo.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuRolPago_Click(object sender, EventArgs e)
        {
            var frm = frmGeneraRol.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void subirFaltantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = frmCargaFaltante.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);
        }

        private void mnuSubirAsiento_Click(object sender, EventArgs e)
        {
            var frm = frmCargaAsiento.Instancia;
            frm.MdiParent = this;
            Design.frmShow(frm);

        }
      
    }
}
