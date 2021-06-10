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
    public partial class frmCargaFaltante : Form
    {
        
        private PatronoController PatronoBO { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }
        private ContratoController ContratoBO { get; set; }
        #region Instancia / Constructor
        private static frmCargaFaltante _instancia;
        public static frmCargaFaltante Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmCargaFaltante();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmCargaFaltante()
        {
            InitializeComponent();
            ContratoBO = ContratoController.Instancia;
            //ReportBO = ReportDataController.Instancia;
            //LocalBO = LocalController.Instancia;
            PatronoBO = PatronoController.Instancia;
            EmpleadoBO = EmpleadoController.Instancia;
            cboPatrono.DataSource = PatronoBO.Listar();
            cboPatrono.DisplayMember = "PAT_RAZ_SOCIAL";
            cboPatrono.ValueMember = "PAT_ID";
            cboPatrono.SelectedIndex = -1;

        }
        #endregion

        private void TotalSalary()
        {
            
            double egreso = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells["VALOR"].Value != null)
                    {   
                            egreso += row.Cells["VALOR"].Value == DBNull.Value ? 0 : Convert.ToDouble(row.Cells["VALOR"].Value);
                    }
                }
            }
           
            lblTotal.Text= "Total: "+egreso.ToString();
            
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var frm = new frmPeridoRolLista("PeridoRolCorto");//"PeridoRolCompleto");
            Design.frmDialog(frm, "Lista de Roles");
            txtPeriodo.Text = ContratoBO.RolSeg.segRolId.ToString();
        }

        private void cboPatrono_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPatrono.SelectedValue == null || cboPatrono.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            VerFaltante();
        }

        private void VerFaltante()
        {
            dgvData.DataSource = EmpleadoBO.CargaFaltanteCaja(txtPeriodo.Text, cboPatrono.SelectedValue.ToString(), 1);
            TotalSalary();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void frmCargaFaltante_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (!txtPeriodo.Text.Equals(string.Empty) && ((DataTable)dgvData.DataSource).Rows.Count>0)
            {
                if (DialogResult.Yes == Utility.MensajeQuestion("¿Esta seguro que desea cargar los faltantes de caja a NOMINA?"))
                {
                    if (EmpleadoBO.ProcesaFaltanteCaja(txtPeriodo.Text, cboPatrono.SelectedValue.ToString()).Equals(1))
                    {
                        VerFaltante();
                        Utility.MensajeOK("Proceso Existoso..!!");
                    }
                        
                    else
                        Utility.MensajeError("Proceso Fallido..!!");
                }
            }
            else
                Utility.MensajeInfo("Seleccione el Período..!!");
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 | e.RowIndex == -1)
                return;

            if (dgvData.Columns[e.ColumnIndex].Name == "LOCAL")
            {
                frmFaltanteCajaDT fmr = new frmFaltanteCajaDT(txtPeriodo.Text, cboPatrono.SelectedValue.ToString());
                fmr.ShowDialog();
            }
        }
    }
}
