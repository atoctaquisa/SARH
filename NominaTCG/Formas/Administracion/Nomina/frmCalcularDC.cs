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
    public partial class frmCalcularDC : Form
    {
        #region Instancia / Constructor
        private static frmCalcularDC _instancia;
        public static frmCalcularDC Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmCalcularDC();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmCalcularDC()
        {
            InitializeComponent();
        }
        
        #endregion

        private void frmCalcularDC_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }
        
    }
}
