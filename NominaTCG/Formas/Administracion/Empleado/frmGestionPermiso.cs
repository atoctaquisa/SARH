using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NominaTCG
{
    public partial class frmGestionPermiso : Form
    {
        #region Instancia / Constructor
        private static frmGestionPermiso _instancia;
        public static frmGestionPermiso Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmGestionPermiso();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmGestionPermiso()
        {
            InitializeComponent();
        }
        
        #endregion

        private void frmGestionPermiso_FormClosing(object sender, FormClosingEventArgs e)
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
