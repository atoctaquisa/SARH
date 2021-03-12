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
    public partial class frmUsuario : Form
    {
        private EmpleadoController EmpleadoBO { get; set; }
        private SistemaController SistemaBO { get; set; }


        #region Instancia / Constructor
        private static frmUsuario _instancia;
        public static frmUsuario Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmUsuario();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmUsuario()
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            SistemaBO = SistemaController.Instancia;
            LoadComboBox();
        }
        #endregion

        private void LoadComboBox()
        {
            //Datos Personales
            cboPerfil.DataSource = SistemaBO.UsuarioTipo();
            cboPerfil.DisplayMember = "TPUSDSCR";
            cboPerfil.ValueMember = "TPUSCDGO";
        }

        private void LoadControls()
        {
            if (EmpleadoBO.Empleado.empNombre == null)
                return;
            //Datos Personales
            txtCodigo.Text = EmpleadoBO.Empleado.empId.ToString();
            txtNombre.Text = EmpleadoBO.Empleado.empNombre;
            //txtApellido.Text = EmpleadoBO.Empleado.empApellido;
            //txtPerCedula.Text = EmpleadoBO.Empleado.empCi;
        }
            private void AssignData(string idRecord)
        {
            DataTable data = new DataTable();
            data = EmpleadoBO.ListaEmpleado(idRecord);
            if (data.Rows.Count > 0)
            {
                EmpleadoBO.Empleado = new Entity.DatEmp();
                EmpleadoBO.Empleado.empId = Convert.ToInt64(data.Rows[0]["EMP_ID"].ToString());
                EmpleadoBO.Empleado.empCi = data.Rows[0]["EMP_CI"].ToString();
                EmpleadoBO.Empleado.empNombre = data.Rows[0]["EMP_NOMBRE"].ToString();
                EmpleadoBO.Empleado.empApellido = data.Rows[0]["EMP_APELLIDO"].ToString();
                EmpleadoBO.Empleado.empNumIess = data.Rows[0]["EMP_NUM_IESS"].ToString();
                EmpleadoBO.Empleado.empCuenta = data.Rows[0]["EMP_CUENTA"].ToString();
                EmpleadoBO.Empleado.empPasaporte = data.Rows[0]["EMP_PASAPORTE"].ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var frm = new frmEmpleadoLista();
            frm.ShowDialog();
            AssignData(EmpleadoBO.Empleado.empId.ToString());
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            SistemaBO.RegistraUsuario(SistemaBO.usuarioDB);
        }
    }
}
