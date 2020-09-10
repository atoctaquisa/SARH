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
    public partial class frmValorUtilidad : Form
    {
        #region Instancia / Constructor
        private static frmValorUtilidad _instancia;
        public static frmValorUtilidad Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmValorUtilidad();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmValorUtilidad()
        {
            InitializeComponent();
        }
        
        #endregion

        private void frmValorUtilidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;            
        }
    }
}
