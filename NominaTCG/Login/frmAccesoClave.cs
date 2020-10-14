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
    public partial class frmAccesoClave : Form
    {
        private SistemaController SistemaBO { get; set; }

        public frmAccesoClave()
        {
            InitializeComponent();
            SistemaBO = SistemaController.Instancia;
            cboUsuario.DataSource= SistemaBO.Usuario();
            cboUsuario.DisplayMember = SistemaBO.Usuario().Columns["NOMBRE"].ColumnName;
            cboUsuario.ValueMember = SistemaBO.Usuario().Columns["CODIGO"].ColumnName;
        }

        private void btnSingIn_Click(object sender, EventArgs e)
        {

            if (txtPass.Text == SistemaBO.Usuario().Rows[cboUsuario.SelectedIndex]["USROPASS"].ToString())
            {
                Catalogo.UserSystem = SistemaBO.Usuario().Rows[cboUsuario.SelectedIndex]["CODIGO"].ToString();
                Catalogo.UserName = SistemaBO.Usuario().Rows[cboUsuario.SelectedIndex]["NOMBRE"].ToString();
                Catalogo.UserRole = SistemaBO.Usuario().Rows[cboUsuario.SelectedIndex]["TPUSCDGO"].ToString();
                Catalogo.UserProfile = SistemaBO.Usuario().Rows[cboUsuario.SelectedIndex]["TPUSDSCR"].ToString();
                Catalogo.ServerData = SistemaBO.ServerData();
                this.Close();

            }
            else
                Utility.MensajeError("Contraseña Incorrecta");
        }

        private void btnSingOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //btnSingIn.Select();
                btnSingIn_Click(sender,e);
            }
        }
    }
}
