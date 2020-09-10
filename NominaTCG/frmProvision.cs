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
    public partial class frmProvision : Form
    {
        #region Instancia / Constructor
        private static frmProvision _instancia;
        public static frmProvision Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmProvision();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        public frmProvision()
        {
            InitializeComponent();
        }
        
        #endregion
        
    }
}
