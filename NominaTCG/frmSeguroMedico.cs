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
    public partial class frmSeguroMedico : Form
    {
        #region Instancia / Constructor
        private static frmSeguroMedico _instancia;
        public static frmSeguroMedico Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmSeguroMedico();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmSeguroMedico()
        {
            InitializeComponent();
        }
        
        #endregion

        private void frmSeguroMedico_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
            
        }
    }
}
