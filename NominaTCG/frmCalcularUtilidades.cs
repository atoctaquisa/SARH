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
    public partial class frmCalcularUtilidades : Form
    {
        #region Instancia / Constructor
        private static frmCalcularUtilidades _instancia;
        public static frmCalcularUtilidades Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmCalcularUtilidades();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmCalcularUtilidades()
        {
            InitializeComponent();
        }
        
        #endregion

        private void frmCalcularUtilidades_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }
    }
}
