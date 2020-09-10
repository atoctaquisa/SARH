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
    public partial class frmCalcularDT : Form
    {
        #region Instancia / Constructor
        private static frmCalcularDT _instancia;
        public static frmCalcularDT Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmCalcularDT();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmCalcularDT()
        {
            InitializeComponent();
        }
        
        #endregion

        private void frmCalcularDT_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }
    }
}
