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

namespace NominaTCG
{
    public partial class frmVacacionesAprobacion : Form
    {
        #region Variables
        private DateTime? _fechaD;
        private DateTime? _fechaH;
        #endregion

        #region Properties
        private SolicitudController SolicitudBO { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }
        private SistemaController SistemaBO { get; set; }
        #endregion

        #region Instancia / Constructor
        private static frmVacacionesAprobacion _instancia;
        public static frmVacacionesAprobacion Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmVacacionesAprobacion();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmVacacionesAprobacion()
        {
            InitializeComponent();
            SolicitudBO = SolicitudController.Instancia;
            SistemaBO = SistemaController.Instancia;
            dgvVaciones.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7);
            dgvVaciones.AutoGenerateColumns = false;
            EmpleadoBO = EmpleadoController.Instancia;
            DataTable dtEstado = new DataTable();
            _fechaD = Convert.ToDateTime("1/1/0001 0:00:00");
            _fechaH = Convert.ToDateTime("1/1/0001 0:00:00");
            dtEstado.Columns.Add("ID");
            dtEstado.Columns.Add("Nombre");
            dtEstado.Rows.Add(-1, "TODO");
            dtEstado.Rows.Add(0, "GENERADO OF");
            dtEstado.Rows.Add(1, "PENDIENTE");
            dtEstado.Rows.Add(2, "APROBADO");
            dtEstado.Rows.Add(3, "PROCESADO");
            dtEstado.Rows.Add(4, "NEGADO");

            cboEstado.DataSource = dtEstado;
            cboEstado.ValueMember = "ID";
            cboEstado.DisplayMember = "Nombre";
            //cboEstado.SelectedValue = 2;
        }

        #endregion

        #region Methods
        private void Notificar(string empleado, string email, string numero, string fecha, string estado, string periodo, string desde, string hasta, string ingreso, string dias)
        {
            object[,] emailVars = new object[,] { { "[@fecha]" , fecha },
                                                  { "[@periodo]" , periodo },
                                                  { "[@fechaIngreso]" , ingreso },
                                                  { "[@fechaHasta]", hasta },
                                                  { "[@fechaDesde]" , desde },                                                  
                                                  { "[@dias]" , dias  },                                                  
                                                  { "[@solicitud]" , numero },
                                                  { "[@estado]" , estado },
                                                  { "[@razonSocial]" , empleado },                                                 
                                                };
            SistemaBO.sendEmail(/*email*/ "atoctaquisa@grupotcg.com", "Solicitud de Vacaciones", SistemaBO.emailMessage("SOLICITUD DE VACACION", emailVars));
        }
        #endregion

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            EmpleadoBO.Empleado = new Entity.DatEmp();
            var frm = new frmEmpleadoLista();
            frm.ShowDialog();
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            var frm = new frmLocalLista();
            frm.ShowDialog();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (dgvVaciones.RowCount > 0)
            {
                int cont = 0;
                foreach (DataGridViewRow item in dgvVaciones.Rows)
                {
                    if (Convert.ToInt16(item.Cells["apbr"].Value) == 1)
                        cont++;                    
                    if (Convert.ToInt16(item.Cells["Anular"].Value) == 1)
                        cont++;
                }
                if (cont == 0)
                    return;
            }
            else
                return;

            if (DialogResult.Yes == Utility.MensajeQuestion("¿Esta seguro que desea Procesar las solucitudes?"))
            {
                int cont = 0;
                foreach (DataGridViewRow item in dgvVaciones.Rows)
                {
                    if (Convert.ToInt16(item.Cells["apbr"].Value) == 1)
                    {
                        SolicitudBO.ApruebaSolicitud(item.Cells["EMP_ID"].Value.ToString(), item.Cells["SOLVAC_ID"].Value.ToString(), item.Cells["Obs"].Value.ToString());
                        Notificar(item.Cells["Empleado"].Value.ToString(),
                            EmpleadoBO.EmpleadoEmail(item.Cells["EMP_ID"].Value.ToString()),
                            item.Cells["SOLVAC_ID"].Value.ToString(),
                            item.Cells["Solicitud"].Value.ToString(),
                            "Aprobada",
                            item.Cells["Periodo"].Value.ToString(),
                            Convert.ToDateTime(item.Cells["Desde"].Value).ToShortDateString(),
                            Convert.ToDateTime(item.Cells["Hasta"].Value).ToShortDateString(),
                            Convert.ToDateTime(item.Cells["Incorpora"].Value).ToShortDateString(),
                            item.Cells["Dias"].Value.ToString()
                            );
                        cont++;
                    }
                    if (Convert.ToInt16(item.Cells["Anular"].Value) == 1)
                    {
                        Notificar(item.Cells["Empleado"].Value.ToString(),
                            EmpleadoBO.EmpleadoEmail(item.Cells["EMP_ID"].Value.ToString()),//"atoctaquisa@grupotcg.com",
                            item.Cells["SOLVAC_ID"].Value.ToString(),
                            item.Cells["Solicitud"].Value.ToString(),
                            "Negada",
                            item.Cells["Periodo"].Value.ToString(),
                            Convert.ToDateTime(item.Cells["Desde"].Value).ToShortDateString(),
                            Convert.ToDateTime(item.Cells["Hasta"].Value).ToShortDateString(),
                            Convert.ToDateTime(item.Cells["Incorpora"].Value).ToShortDateString(),
                            item.Cells["Dias"].Value.ToString()
                            );
                        SolicitudBO.AnulaSolicitud(Convert.ToInt32(item.Cells["SOLVAC_ID"].Value));
                        cont++;
                    }
                }
                if (cont > 0)
                {
                    btnFind_Click(sender, e);
                    Utility.MensajeInfo("Proceso Finalizado");
                }
            }
        }

        private void frmAprobacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvVaciones.DataSource = null;
            //cboEstado.SelectedValue = 2;
            txtCodigo.Text = string.Empty;
            txtEmpleado.Text = string.Empty;
            pDesde.Value = DateTime.Now;
            pHasta.Value = DateTime.Now;
            _fechaD = Convert.ToDateTime("1/1/0001 0:00:00");
            _fechaH = Convert.ToDateTime("1/1/0001 0:00:00");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            dgvVaciones.DataSource = SolicitudBO.ListaSolicitudVacacion(txtCodigo.Text, Convert.ToInt16(cboEstado.SelectedValue), (txtEmpleado.Text == string.Empty ? "0" : EmpleadoBO.Empleado.empId.ToString()), _fechaD.ToString(), _fechaH.ToString());
        }

        private void pDesde_ValueChanged(object sender, EventArgs e)
        {
            _fechaD = pDesde.Value;
        }

        private void pHasta_ValueChanged(object sender, EventArgs e)
        {
            _fechaH = pHasta.Value;
        }

        private void dgvVaciones_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            int nColumn = dgvVaciones.CurrentCell.ColumnIndex;
            if (nColumn == 4 | nColumn == 5)
            {
                if (dgvVaciones.IsCurrentCellDirty)
                {
                    int nIndex = dgvVaciones.CurrentCell.RowIndex;
                    int vEstado = Convert.ToInt16(dgvVaciones.Rows[nIndex].Cells["SOLVAC_ESTADO"].Value);
                    if (vEstado == 4 | vEstado == 3)
                    {
                        dgvVaciones.CancelEdit();
                    }
                    else
                    {
                        if (nColumn == 4)
                            dgvVaciones.Rows[nIndex].Cells[nColumn + 1].Value = false;

                        if (nColumn == 5)
                            dgvVaciones.Rows[nIndex].Cells[nColumn - 1].Value = false;
                    }
                    dgvVaciones.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }

            }
        }

        private void ckAnular_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkApbr_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.OnlyDigit(e);
        }
    }
}
