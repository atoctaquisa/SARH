using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BusinessLogic;

namespace NominaTCG
{
    public partial class frmFaltanteCajaDT : Form
    {
        private EmpleadoController EmpleadoBO { get; set; }
        public frmFaltanteCajaDT(string perID, string patID)
        {
            InitializeComponent();
            EmpleadoBO = EmpleadoController.Instancia;
            VerFaltante(perID ,patID);
        }
        private void VerFaltante(string perID, string patID)
        {
            dgvData.DataSource = EmpleadoBO.CargaFaltanteCaja(perID , patID, 0);
            //TotalSalary();

            double contar = dgvData.Rows.Cast<DataGridViewRow>()
                     .Where(r => r.Selected)
                     .Sum(r => Convert.ToDouble(r.Cells["VALOR"].Value));
        }

        private void dgvData_Click(object sender, EventArgs e)
        {
            double contar = dgvData.Rows.Cast<DataGridViewRow>()
                    .Where(r => r.Cells["VALOR"].Selected)
                    .Sum(r => Convert.ToDouble(r.Cells["VALOR"].Value));
            lblTotal.Text ="Valor: "+ contar.ToString();

            contar = dgvData.Rows.Cast<DataGridViewRow>()
                    .Where(r => r.Cells["VALOR"].Selected)
                    .Count();
            lblRegistro.Text = "Registros: " + contar.ToString();
        }     
    }
}
