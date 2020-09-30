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
using System.Threading;

namespace NominaTCG
{
    public partial class frmHuella : Form
    {
        private EmpleadoController EmpleadoBO { get; set; }
        private SistemaController SistemaBO { get; set; }
        string _empID;
        public frmHuella(string empID)
        {
            InitializeComponent();
            _empID = empID;
            mHabilita(true);
            dIzquierda(false);
            dDerecha(false);
            btnIzquierdaG.Visible = false;
            btnDerechaG.Visible = false;
            EmpleadoBO = EmpleadoController.Instancia;
            SistemaBO = SistemaController.Instancia;
        }

        private void mHabilita(bool param)
        {
            btnIzquierda.Enabled = param;
            btnDerecha.Enabled = param;
        }
        private void dIzquierda(bool param)
        {
            btnI1.Visible = param;
            btnI2.Visible = param;
            btnI3.Visible = param;
            btnI4.Visible = param;
            btnI5.Visible = param;
        }

        private void dDerecha(bool param)
        {
            btnD1.Visible = param;
            btnD2.Visible = param;
            btnD3.Visible = param;
            btnD4.Visible = param;
            btnD5.Visible = param;
        }

        private void capturaHuella(string idMano, string idDedo)
        {
            Utility.MensajeInfo("Coloque su dedo en el dispositivo Biométrico");
            string huellaEmp = SistemaBO.CapturaHuella();          
            Utility.MensajeInfo("Coloque nuevamente su Dedo");
            if (SistemaBO.ComparaHuella(huellaEmp, SistemaBO.CapturaHuella()).Equals(1))
            {
                if (Utility.MensajeQuestion("Desea Registrar la huella capturada") == DialogResult.Yes)
                {
                    string obsID;
                    if (idMano.Equals("D"))
                        obsID = "Mano Derecha - " + idDedo;
                    else
                        obsID = "Mano Izquierda - " + idDedo;

                    SistemaBO.RegistraHuella(_empID, huellaEmp, obsID);
                    Utility.MensajeInfo("Huella Registrada..!!");
                    mHabilita(true);
                    dIzquierda(false);
                    dDerecha(false);
                    btnIzquierdaG.Visible = false;
                    btnDerechaG.Visible = false;
                }

            }
            else
                Utility.MensajeError("La Huella no es igual");
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            mHabilita(false);
            dDerecha(true);
        }
        private void btnD1_Click(object sender, EventArgs e)
        {
            capturaHuella("D", "1: Pulgar");
        }

        private void btnD2_Click(object sender, EventArgs e)
        {
            capturaHuella("D", "2: Indice");
        }

        private void btnD3_Click(object sender, EventArgs e)
        {
            capturaHuella("D", "3: Medio");
        }

        private void btnD4_Click(object sender, EventArgs e)
        {
            capturaHuella("D", "4: Anular");
        }

        private void btnD5_Click(object sender, EventArgs e)
        {
            capturaHuella("D", "5: Menique");
        }

        private void btnDerechaG_Click(object sender, EventArgs e)
        {
            btnNewSave_Click(sender, e);
        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            mHabilita(false);
            dIzquierda(true);
        }

        private void btnI1_Click(object sender, EventArgs e)
        {
            capturaHuella("I", "1: Pulgar");
        }

        private void btnI2_Click(object sender, EventArgs e)
        {
            capturaHuella("I", "2: Indice");
        }

        private void btnI3_Click(object sender, EventArgs e)
        {
            capturaHuella("I", "3: Medio");
        }

        private void btnI4_Click(object sender, EventArgs e)
        {
            capturaHuella("I", "4: Anular");
        }

        private void btnI5_Click(object sender, EventArgs e)
        {
            capturaHuella("I", "5: Menique");
        }

        private void btnIzquierdaG_Click(object sender, EventArgs e)
        {
            btnNewSave_Click(sender, e);
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
           
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            btnIzquierdaG.Visible = true;
            btnDerechaG.Visible = true;
            mHabilita(false);
            dDerecha(false);
            dIzquierda(false);
        }
    }
}
