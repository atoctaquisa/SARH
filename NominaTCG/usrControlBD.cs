using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NominaTCG
{
    public partial class usrControlBD : UserControl
    {
        private enum Estado
        {
            Nuevo,
            Editar,
            Eliminar,
            Cancelar,
            Guardar            
        }

        public string BotonSTD
        { get; set; }


        private void ControlClic(Estado btn)
        {
            
            switch (btn)
            {
                case Estado.Nuevo:
                     btnNewSave.ImageIndex = 4;
                     btnEditCancel.ImageIndex = 1;
                    break;
                case Estado.Editar:
                    btnNewSave.ImageIndex = 4;
                     btnEditCancel.ImageIndex = 1;
                    break;
                case Estado.Eliminar:
                    break;
                case Estado.Cancelar:
                    btnNewSave.ImageIndex = 0;
                     btnEditCancel.ImageIndex = 2;
                     BotonSTD = Estado.Cancelar.ToString();
                    break;
                case Estado.Guardar:
                    btnNewSave.ImageIndex = 4;
                     btnEditCancel.ImageIndex = 1;
                    break;
                default:
                    break;
            }
        }

        public usrControlBD()
        {
            InitializeComponent();
        }

        

        private void usrControlBD_Load(object sender, EventArgs e)
        {
            //btnNewSave.ImageIndex = 0;            
            //btnEditCancel.ImageIndex = 2;
            //btnDelete.ImageIndex = 1;    
            ControlClic(Estado.Cancelar);
            
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            //btnNewSave.ImageIndex = 1;
            //btnEditCancel.ImageIndex = 3;
            
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            //btnNewSave.ImageIndex = 0;
            //btnEditCancel.ImageIndex = 2;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void usrControlBD_Click(object sender, EventArgs e)
        {

        }
    }
}
