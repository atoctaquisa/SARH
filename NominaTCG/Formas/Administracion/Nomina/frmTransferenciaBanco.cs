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
using System.IO;
namespace NominaTCG
{
    public partial class frmTransferenciaBanco : Form
    {
        private ContratoController ContratoBO { get; set; }
        private EmpleadoController EmpleadoBO { get; set; }
        private SistemaController SistemaBO { get; set; }
        private string empID { get; set; }
        private string procesoID { get; set; }
        private string anioINI { get; set; }
        private string anioFIN { get; set; }
        //private string empID { get; set; }
        #region Instancia / Constructor
        private static frmTransferenciaBanco _instancia;
        public static frmTransferenciaBanco Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmTransferenciaBanco();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmTransferenciaBanco()
        {
            InitializeComponent();
            ContratoBO = ContratoController.Instancia;
            EmpleadoBO = EmpleadoController.Instancia;
            SistemaBO = SistemaController.Instancia;
            IniciaControl();
        }

        private void IniciaControl()
        {
            cboBanco.SelectedIndex = -1;
            cboTipo.SelectedIndex = -1;

            empID = string.Empty;
            procesoID = string.Empty;
            anioINI = string.Empty;
            anioFIN = string.Empty;
            txtRol.Text = string.Empty;
            txtReproceso.Text = string.Empty;
            txtFechaIni.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
            txtEmpleado.Text = string.Empty;
            txtPeriodo.Text = string.Empty;

            //cboTipoPago.Enabled = false;
            txtRol.Enabled = false;
            txtReproceso.Enabled = false;
            txtFechaIni.Enabled = false;
            txtFechaFin.Enabled = false;
            txtEmpleado.Enabled = false;
            btnSearchRol.Enabled = false;
            btnSearchEmpleado.Enabled = false;
            txtPeriodo.Enabled = false;
            btnSearchPeriodo.Enabled = false;
            ErrProv.Clear();
        }

        #endregion

        private void frmTransferenciaBanco_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;

        }

        private void btnSearchEmpleado_Click(object sender, EventArgs e)
        {
            var frm = new frmEmpleadoLista();
            frm.ShowDialog();
            txtEmpleado.Text = EmpleadoBO.Empleado.empNombre == null ? string.Empty : EmpleadoBO.Empleado.empNombre.ToString();
            empID = EmpleadoBO.Empleado.empId.ToString();
        }

        private void btnSearchPeriodo_Click(object sender, EventArgs e)
        {
            string tipo = string.Empty;

            if (cboTipo.Text.Equals("Pago Décimo Tercero"))
                tipo = "DT";
            if (cboTipo.Text.Equals("Pago Décimo Cuarto"))
                tipo = "DC";

            var frm = new fmrPeriodoLista(tipo);
            Design.frmDialog(frm, "Períodos Vigentes");

            txtPeriodo.Text = ContratoBO.RolSeg.segRolObs;
            procesoID = ContratoBO.RolSeg.segRolId.ToString();
            anioINI = ContratoBO.RolSeg.segRolRepro.ToString();
            anioFIN = ContratoBO.RolSeg.segEstQuin.ToString();

        }

        private void btnSearchRol_Click(object sender, EventArgs e)
        {
            var frm = new frmPeridoRolLista("PeridoRolCompleto");
            Design.frmDialog(frm, "Lista de Roles");
            txtRol.Text = ContratoBO.RolSeg.segRolId.ToString();
            txtReproceso.Text = ContratoBO.RolSeg.segRolRepro.ToString();
            txtFechaIni.Text = ContratoBO.RolSeg.rolFechaIni.ToString();
            txtFechaFin.Text = ContratoBO.RolSeg.rolFechaFin.ToString();

        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.Text.Equals("Pago Quincena") | cboTipo.Text.Equals("Pago Fin de Mes"))
            {
                //cboTipoPago.Enabled = true;
                txtRol.Enabled = true;
                txtReproceso.Enabled = true;
                txtFechaIni.Enabled = true;
                txtFechaFin.Enabled = true;
                txtEmpleado.Enabled = true;
                btnSearchRol.Enabled = true;
                btnSearchEmpleado.Enabled = true;

                txtPeriodo.Enabled = false;
                btnSearchPeriodo.Enabled = false;
            }
            else
            {
                //cboTipoPago.Enabled = false;
                txtRol.Enabled = false;
                txtReproceso.Enabled = false;
                txtFechaIni.Enabled = false;
                txtFechaFin.Enabled = false;
                txtEmpleado.Enabled = false;
                btnSearchRol.Enabled = false;
                btnSearchEmpleado.Enabled = false;

                txtPeriodo.Enabled = true;
                btnSearchPeriodo.Enabled = true;
            }
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            int tipoID;
            int ban = 1;

            if (txtPeriodo.Enabled)
            {
                if (txtPeriodo.Text.Equals(string.Empty) | procesoID.Equals("0"))
                    ErrProv.SetError(txtPeriodo, (ban++) + ": Seleccione un período");
                if (cboBanco.Text.Equals(string.Empty))
                    ErrProv.SetError(cboBanco, (ban++) + ": Seleccione el banco");
                if (ban > 1)
                    return;
            }
            else
            {
                if (txtRol.Text.Equals(string.Empty) | txtRol.Text.Equals("0"))
                    ErrProv.SetError(txtRol, (ban++) + ": Seleccione un rol");
                if (cboBanco.Text.Equals(string.Empty))
                    ErrProv.SetError(cboBanco, (ban++) + ": Seleccione el banco");
                if (ban > 1)
                    return;
            }

            ErrProv.Clear();

            switch (cboTipo.Text)
            {
                case "Pago Fin de Mes":
                    tipoID = 1;
                    break;
                case "Pago Quincena":
                    tipoID = 2;
                    break;
                case "Pago Décimo Tercero":
                    tipoID = 3;
                    break;
                case "Pago Décimo Cuarto":
                    tipoID = 4;
                    break;
                default:
                    tipoID = 0;
                    break;
            }


            DataTable empresa = EmpleadoBO.TransferenciaBancaria(txtRol.Text, txtReproceso.Text, empID, tipoID.ToString());
            foreach (DataRow emp in empresa.Rows)
            {
                if (tipoID == 1 | tipoID == 2)
                {
                    DataTable datos = EmpleadoBO.TransferenciaBancaria(emp["PAT_ID"].ToString());
                    string nameFile = emp["RAZON"].ToString() + cboTipo.Text.ToUpper().Replace(" ", string.Empty) + "-" + Convert.ToDateTime(txtFechaIni.Text).Month + Convert.ToDateTime(txtFechaIni.Text).Year + ".txt";
                    if (datos.Rows.Count > 0)
                    {
                        string path = ReadPath(emp["RAZON"].ToString()) + nameFile;
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
                        {
                            //Console.OutputEncoding = Encoding.ASCII;
                            foreach (DataRow row in datos.Rows)
                            {
                                file.WriteLine(row["DATOS"]);
                            }
                        }
                    }
                }
                if (tipoID == 3 | tipoID == 4)
                {
                    DataTable datos = EmpleadoBO.TransferenciaBancariaDecimo(procesoID, anioINI, anioFIN, emp["PAT_ID"].ToString(), tipoID.ToString());
                    string nameFile = emp["RAZON"].ToString() + cboTipo.Text.ToUpper().Replace(" ", string.Empty) + "-" + anioINI + anioFIN + ".txt";
                    if (datos.Rows.Count > 0)
                    {
                        string path = ReadPath(emp["RAZON"].ToString()) + nameFile;
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
                        {
                            //Console.OutputEncoding = Encoding.ASCII;
                            foreach (DataRow row in datos.Rows)
                            {
                                file.WriteLine(row["DATOS"]);
                            }
                        }
                    }
                }

            }

            Utility.MensajeInfo("Archivos generados exitosamente.!!");
            IniciaControl();

        }

        private string ReadPath(string empresa)
        {
            //string path = @"C:\Transferencia\"; 
            string path = SistemaBO.Path("61") + empresa + @"\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            IniciaControl();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Close();
        }
    }
}
