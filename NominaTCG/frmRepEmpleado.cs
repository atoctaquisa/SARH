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
    public partial class frmRepEmpleado : Form
    {
        ReportDataController reportBO { get; set; }
        #region Instancia / Constructor
        private static frmRepEmpleado _instancia;
        public static frmRepEmpleado Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmRepEmpleado();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmRepEmpleado()
        {
            InitializeComponent();
            reportBO = ReportDataController.Instancia;
        }
        #endregion


        private void btnConsultar_Click(object sender, EventArgs e)
        {
             dgvData.DataSource = reportBO.DetalleEmpleado("");
        }

        private void frmRepEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }


        //SELECT ROWNUM                             NUM,
        //                                           LOC_CIUDAD_ABREV CIUDAD,
        //                                           LOC_NOMBRE LOCAL,
        //                                           NOMBRE EMPLEADO,
        //                                           ESC_ABRE CARGO,
        //                                           LAB_FEC_INGRESO INGRESO,
        //                                           EMP_CON_FEC_CONTRATO CONTRATO,
        //                                           TIPO_CONTRATO,
        //                                           PATRONO,
        //                                           LAB_FEC_CAMB_ESC ULTM_ASC,
        //                                           EMP_FEC_SALIDAREAL SALIDA_REAL,
        //                                           EMP_CI CEDULA,
        //                                           EMP_FEC_NAC FECHA_NACIMIENTO,
        //                                           EMP_DIREC DIRECCION,
        //                                           EMP_BARRIO BARRIO,
        //                                           (SELECT EMP_SEC_NOMBRE
        //                                              FROM DESARROLLO.DAT_EMP_SEC
        //                                             WHERE EMP_SEC_ID = V.EMP_SEC)    SECTOR,
        //                                           EMP_TELEFONO TELEFONO,
        //                                           DECODE(EMP_EST_CIVIL, 'S', 'Soltero', 'C', 'Casado', 'U', 'Unión Libre', 'Se', 'Separado', 'D', 'Divorciado', 'V', 'Viudo') ESTADO_CIVIL,
        //                                           DECODE(EMP_SEXO,1,'Hombre',0,'Mujer') SEXO,
        //                                           EMP_CUENTA CUENTA,
        //                                           DECODE(EMP_DISCAPACIDAD, 0, 'No', 1, 'Si') DISCAPACIDAD,
        //                                           EMP_MAIL_PER CORREO_PERSONAL,
        //                                           EMP_MAIL CORREO_EMPRESARIAL
        //                                      FROM DESARROLLO.V_DETALLE_EMP V
    }
}
