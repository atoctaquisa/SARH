using System;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace NominaTCG
{
    public class Design
    {
        public static void StyleGridForm(DataGridView datos)
        {
            datos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(222)))));
            datos.AutoGenerateColumns = false;
            datos.AllowUserToAddRows = false;
            datos.AllowUserToDeleteRows = false;
            datos.ReadOnly = true;
            //datos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        
        private static void StyleGridDialog(DataGridView datos)
        {
            datos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(222)))));
            datos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            datos.RowHeadersVisible = false;
            datos.AutoGenerateColumns = false; 
            datos.AllowUserToAddRows = false;
            datos.AllowUserToDeleteRows = false;
            datos.ReadOnly = true;
            //datos.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7);
            datos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static void vDeduccionGasto(DataGridView datos)
        {
            //datos.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
            //datos.RowHeadersVisible = false;
            //datos.AllowUserToAddRows = false;            
            //StyleGridForm(datos);
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;

                if (item.Name.Equals("ANIO"))
                {
                    item.Width = 50;
                    item.Visible = true;
                    item.HeaderText = "Año";
                    //item.DisplayIndex = 0;                    
                }
                if (item.Name.Equals("CONCEPTO"))
                {
                    item.Width = 200;
                    item.Visible = true;
                    //item.DisplayIndex = 1; 
                    item.HeaderText = "Concepto";
                    
                }
                if (item.Name.Equals("PROY_VALOR"))
                {
                    item.Width = 70;
                    item.Visible = true;
                    //item.DisplayIndex = 2; 
                    item.HeaderText = "Valor";                    
                }                
                //if (item.Name.Equals("MAXLIM"))
                //{
                //    item.Width = 70;
                //    item.Visible = true;
                //    //item.DisplayIndex = 3; 
                //    item.HeaderText = "Valor Mínimo";
                //}
                if (item.Name.Equals("PROY_LIM"))
                {
                    item.Width = 70;
                    item.Visible = true;
                    //item.DisplayIndex = 4; 
                    item.HeaderText = "Valor Máximo";
                }
                if (item.Name.Equals("FECHACRE"))
                {
                    item.Width = 115;
                    item.Visible = true;
                    item.HeaderText = "F. Creación";                    
                }                
            }
        }

        public static DataTable filterData { get; set; }

        public static void vValorGrupo(DataGridView datos)
        {
            datos.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
        }

        public static void vContratoFin(DataGridView datos)
        {
            datos.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
            datos.AutoGenerateColumns = false;            
            datos.RowHeadersVisible = false;            
        }

        public static void vAccidenteEnfMat(DataGridView datos)
        {
            datos.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
            StyleGridDialog(datos);
            filterData = new DataTable();
            filterData.Columns.Add("ID");
            filterData.Columns.Add("Nombre");
            datos.RowHeadersVisible = false;

   //         EMP_ID, ROL_ID_GEN, ROL_REPRO, 
   //IESS_FECHAINICIO, IESS_FECHAFIN, IESS_FECHAINGRESO, 
   //IESS_FECHAMODIF, IESS_TIPO, IESS_OBSERVACION, 
   //DIAS_25, DIAS_100
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;

                if (item.Name.Equals("IESS_FECHAINICIO"))
                {
                    item.Visible = true;
                    item.HeaderText = "Fecha Inicio";
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }

                if (item.Name.Equals("IESS_FECHAFIN"))
                {
                    item.Visible = true;
                    item.HeaderText = "Fecha Fin";
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("IESS_TIPO"))
                {
                    item.Visible = true;
                    item.HeaderText = "Tipo";
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("IESS_OBSERVACION"))
                {
                    item.Visible = true;
                    item.HeaderText = "Observación";
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }               
            }
        }

        public static void vCuentaIO(DataGridView datos)
        {
            datos.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
            StyleGridDialog(datos);            
            filterData = new DataTable();
            filterData.Columns.Add("ID");
            filterData.Columns.Add("Nombre");
            datos.RowHeadersVisible = false;           
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;

                if (item.Name.Equals("CUENTA"))
                {                    
                    item.Visible = true;
                    item.HeaderText = "Cuenta";
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }

                if (item.Name.Equals("ROL_ID"))
                {                 
                    item.Visible = true;
                    item.HeaderText = "Código";
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
            }
        }

       

        public static void vContrato(DataGridView datos)
        {
            datos.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);            
            datos.RowHeadersVisible = false;            
        }
        public static void vEscalafon(DataGridView datos)
        {
            StyleGridDialog(datos);
            
            filterData = new DataTable();
            filterData.Columns.Add("ID");
            filterData.Columns.Add("Nombre");
            
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;

                if (item.Name.Equals("ESC_ID"))
                {
                    item.Width = 20;
                    item.Visible = true;
                    item.HeaderText = "ID";
                }

                if (item.Name.Equals("ESC_CARGOMB"))
                {
                    item.Width = 120;
                    item.Visible = true;
                    item.HeaderText = "Cargo MB";
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("ESC_CARGOIESS"))
                {
                    item.Width = 100;
                    item.Visible = true;
                    item.HeaderText = "Cargo IESS";
                }

                if (item.Name.Equals("ESC_ABRE"))
                {
                    item.Width = 180;
                    item.Visible = true;
                    item.HeaderText = "Abrev";
                }

                if (item.Name.Equals("ESC_CODIESS"))
                {
                    item.Width = 200;
                    item.Visible = true;
                    item.HeaderText = "Código IESS";
                }

                if (item.Name.Equals("ESC_SAL_UNIFICADO"))
                {
                    item.Visible = true;
                    item.HeaderText = "RBU";
                }
                if (item.Name.Equals("ESC_ADI_MB"))
                {
                    item.Visible = true;
                    item.HeaderText = "Sobretmp";
                }

                if (item.Name.Equals("ESC_COD_ACT_SEC"))
                {
                    item.Visible = true;
                    item.HeaderText = "Actv. Sector";
                }

                if (item.Name.Equals("ESTADO"))
                {
                    item.Visible = true;
                    item.HeaderText = "Estado";
                }   
            }
        }
        public static void vLocales(DataGridView datos)
        {
            StyleGridDialog(datos);
            filterData = new DataTable();
            filterData.Columns.Add("ID");
            filterData.Columns.Add("Nombre");
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;
                if (item.Name.Equals("LOC_ID"))
                {
                    item.HeaderText = "Código";
                    item.Width = 60;
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }

                if (item.Name.Equals("LOC_NOMBRE"))
                {
                    item.Width = 180;
                    item.Visible = true;
                    item.HeaderText = "Local";
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }

                if (item.Name.Equals("LOC_DIR"))
                {
                    item.HeaderText = "Dirección";
                    item.Width = 200;
                    item.Visible = true;
                }


                if (item.Name.Equals("ESTADO"))
                {
                    item.HeaderText = "Estado";
                    item.Visible = true;
                }

                if (item.Name.Equals("LOC_RUC"))
                {
                    item.HeaderText = "RUC";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }

            }
        }

        public static void vEmpresa(DataGridView datos)
        {
            filterData = new DataTable();
            filterData.Columns.Add("ID");
            filterData.Columns.Add("Nombre");
            datos.RowHeadersVisible = false;
            datos.AllowUserToAddRows = false;
            datos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;
                if (item.Name.Equals("PAT_NUM_RUC"))
                {
                    item.Width = 120;
                    item.Visible = true;
                    item.HeaderText = "Ruc";
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("PAT_REP_LEGAL"))
                {
                    item.Width = 100;
                    item.Visible = true;
                    item.HeaderText = "Rep. Legal";
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }

                if (item.Name.Equals("PAT_RAZ_SOCIAL"))
                {
                    item.Width = 180;
                    item.Visible = true;
                    item.HeaderText = "Razón Social";
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }

                if (item.Name.Equals("PAT_DIR"))
                {
                    item.Width = 200;
                    item.Visible = true;
                    item.HeaderText = "Dirección";
                }


                if (item.Name.Equals("ESTADO"))
                {
                    item.Visible = true;
                    item.HeaderText = "Estado";
                }

                if (item.Name.Equals("PAT_TELF"))
                {
                    item.Visible = true;
                    item.HeaderText = "Teléfono";
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }

            }
        }

        public static void vSolicitudVacacion(DataGridView datos)
        {

            foreach (DataGridViewRow item in datos.Rows)
            {

                switch (item.Cells["ESTADO"].Value.ToString())
                {
                    case "GENERADO":
                        datos.Rows[item.Index].DefaultCellStyle.BackColor = Color.PeachPuff;
                        break;
                    case "PENDIENTE":
                        datos.Rows[item.Index].DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                    case "APROBADO":
                        datos.Rows[item.Index].DefaultCellStyle.BackColor = Color.Gold;
                        break;
                    case "PROCESADO":
                        datos.Rows[item.Index].DefaultCellStyle.BackColor = Color.LawnGreen;
                        break;
                    case "NEGADO":
                        datos.Rows[item.Index].DefaultCellStyle.BackColor = Color.OrangeRed;
                        break;
                }
            }
        }

        public static void vPeridoVacacion(DataGridView datos)
        {

            foreach (DataGridViewRow item in datos.Rows)
            {
                if (Convert.ToInt16(item.Cells["DiaPend"].Value) > 0)
                    datos.Rows[item.Index].DefaultCellStyle.BackColor = Color.LightGreen;

            }
        }

        public static void vVacacionDT(DataGridView datos)
        {

            foreach (DataGridViewRow item in datos.Rows)
            {
                if (Convert.ToInt16(item.Cells["FIN"].Value) == 1)
                    datos.Rows[item.Index].DefaultCellStyle.BackColor = Color.LightYellow;

            }
        }

        public static void EmgPeriodoUnico(DataGridView datos)
        {
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;

                if (item.Name.Equals("SEG_ROL_ID"))
                {
                    item.HeaderText = "ID Rol";
                    item.Visible = true;                    
                }
                if (item.Name.Equals("PERIODO"))
                {
                    item.HeaderText = "Período";
                    item.Visible = true;                    
                }
            }
        }
        public static void EmgCuentaAsiento(DataGridView datos)
        {
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;                
                if (item.Name.Equals("CUE_ID"))
                {
                    item.HeaderText = "Cuentas";
                    item.Visible = true;
                }
                if (item.Name.Equals("CUE_NOMBRE"))
                {
                    item.HeaderText = "Descripción";
                    item.Visible = true;
                }
            }
        }

        public static void vPeriodoDecimo(DataGridView datos)
        {

            filterData = new DataTable();
            filterData.Columns.Add("ID");
            filterData.Columns.Add("Nombre");
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;
                if (item.Name.Equals("PERIODO"))
                {
                    item.HeaderText = "Período";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("FECHA"))
                {
                    item.HeaderText = "Fecha";
                    item.Visible = true;
                    //filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("PROCESO"))
                {
                    item.HeaderText = "Proceso";
                    item.Visible = true;
                    //filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("DEC_ANO_INI"))
                {
                    item.HeaderText = "Año Inicio";
                    item.Visible = true;
                    //filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("DEC_ANO_FIN"))
                {
                    item.HeaderText = "Año Fin";
                    item.Visible = true;
                    //filterData.Rows.Add(item.Name, item.HeaderText);
                }
            }

        }
        public static void vPeridoRol(DataGridView datos)
        {
            filterData = new DataTable();
            filterData.Columns.Add("ID");
            filterData.Columns.Add("Nombre");
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;
                if (item.Name.Equals("SEG_ROL_ID"))
                {
                    item.HeaderText = "ID Rol";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("ROL_FECHA_INI"))
                {
                    item.HeaderText = "Fecha Inicia";
                    item.Visible = true;                    
                }
                if (item.Name.Equals("ROL_FECHA_FIN"))
                {
                    item.HeaderText = "Fecha Fin";
                    item.Visible = true;                    
                }
                if (item.Name.Equals("SEG_ROL_REPRO"))
                {
                    item.HeaderText = "Reproceso";
                    item.Visible = true;
                    item.DisplayIndex = 1;                    
                }
                if (item.Name.Equals("PERIODO"))
                {
                    item.HeaderText = "Período";
                    item.Visible = true;                    
                }
            }
        }

        public static void vPeridoRolCorto(DataGridView datos)
        {
            filterData = new DataTable();
            filterData.Columns.Add("ID");
            filterData.Columns.Add("Nombre");
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;
                if (item.Name.Equals("SEG_ROL_ID"))
                {
                    item.HeaderText = "ID Rol";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                
                if (item.Name.Equals("SEG_ROL_REPRO"))
                {
                    item.HeaderText = "Reproceso";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("PERIODO"))
                {
                    item.HeaderText = "Período";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
            }
        }

        public static void vPeriodo(DataGridView datos)
        {
            filterData = new DataTable();
            filterData.Columns.Add("ID");
            filterData.Columns.Add("Nombre");
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;
                if (item.Name.Equals("SEG_ROL_ID"))
                {
                    item.HeaderText = "ID Rol";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("ROL_FECHA_INI"))
                {
                    item.HeaderText = "Fecha Inicia";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("ROL_FECHA_FIN"))
                {
                    item.HeaderText = "Fecha Fin";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("TOTAL_ING"))
                {
                    item.HeaderText = "Total Ingreso";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("TOTAL_EGR"))
                {
                    item.HeaderText = "Total Egreso";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("TOTAL_TOTAL"))
                {
                    item.HeaderText = "Total";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("TOTAL_EMP"))
                {
                    item.HeaderText = "Total Empleado";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("SEG_ROL_REPRO"))
                {
                    item.HeaderText = "Reproceso";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
            }
        }

        public static void vPrestamoEmpleado(DataGridView datos)
        {
            StyleGridDialog(datos);
            filterData = new DataTable();
            filterData.Columns.Add("ID");
            filterData.Columns.Add("Nombre");
            
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;               

                if (item.Name.Equals("EMP_ID"))
                {
                    item.HeaderText = "Código";
                    item.Visible = true;
                    item.DisplayIndex = 0;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("EMPLEADO"))
                {
                    item.HeaderText = "Empleado";
                    item.Visible = true;
                    item.DisplayIndex = 1;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("PERIODO"))
                {
                    item.HeaderText = "Período";
                    item.Visible = true;
                    item.DisplayIndex = 2;
                }
                if (item.Name.Equals("CUENTA"))
                {
                    item.HeaderText = "Cuenta";
                    item.Visible = true;                    
                }

                if (item.Name.Equals("PRES_PLAZO"))
                {
                    item.HeaderText = "Plazo";
                    item.Visible = true;
                    item.DisplayIndex = 3;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("PRES_VALOR"))
                {
                    item.HeaderText = "Valor";
                    item.Visible = true;
                    item.DisplayIndex = 4;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("PRES_OBSERVACION"))
                {
                    item.HeaderText = "Descripción";
                    item.Visible = true;
                    item.DisplayIndex = 5;
                    
                }
                if (item.Name.Equals("FECHAREGISTRO"))
                {
                    item.HeaderText = "Fecha Registro";
                    item.Visible = true;
                    
                }
                if (item.Name.Equals("ESTADO"))
                {
                    item.HeaderText = "Estado";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
            }
        }

        public static void vEmpleado(DataGridView datos)
        {
            filterData = new DataTable();
            filterData.Columns.Add("ID");
            filterData.Columns.Add("Nombre");
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;               

                if (item.Name.Equals("EMP_ID"))
                {
                    item.HeaderText = "Código";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("NOMBRE"))
                {
                    item.HeaderText = "Nombres";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("ESC_CARGOMB"))
                {
                    item.HeaderText = "Cargo";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("EMP_CI"))
                {
                    item.HeaderText = "Cédula";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }

                if (item.Name.Equals("PATRONO"))
                {
                    item.HeaderText = "Patrono";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("ESTADO"))
                {
                    item.HeaderText = "Estado";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
            }
        }

        public static void vEmpleadoDT(DataGridView datos)
        {
            filterData = new DataTable();
            filterData.Columns.Add("ID");
            filterData.Columns.Add("Nombre");

            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;
                if (item.Name.Equals("EMP_ID"))
                {
                    item.HeaderText = "Código";
                    item.Visible = true;                    
                }
                if (item.Name.Equals("EMP_CI"))
                {
                    item.HeaderText = "Cédula";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("NOMBRE"))
                {
                    item.HeaderText = "Nombre";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("LAB_FEC_INGRESO"))
                {
                    item.HeaderText = "Fecha Ingreso";
                    item.Visible = true;                    
                }
                if (item.Name.Equals("ESC_CARGOMB"))
                {
                    item.HeaderText = "Cargo";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("LOC_NOMBRE"))
                {
                    item.HeaderText = "Lugar Trabajo";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }

            }
        }

        public static void ControlsSave(Button EditCancel, Button NewSave)
        {
            if (NewSave.Text == "&Guardar")
            {
                NewSave.Enabled = false;
                EditCancel.ImageIndex = 1;
                EditCancel.Text = "&Editar";
            }
        }

        public static void ControlsEdit(Button EditCancel, Button NewSave)
        {
            if (EditCancel.Text == "&Editar")
            {
                NewSave.Enabled = true;
                EditCancel.ImageIndex = 3;
                EditCancel.Text = "&Cancelar";
            }
            else
            {
                NewSave.Enabled = false;
                EditCancel.ImageIndex = 1;
                EditCancel.Text = "&Editar";
            }
        }
        public static void ControlsNew(Button EditCancel, Button NewSave)
        {
            if (EditCancel.Text == "&Nuevo")
            {
                NewSave.Enabled = true;
                EditCancel.ImageIndex = 3;
                EditCancel.Text = "&Cancelar";
            }
            else
            {
                NewSave.Enabled = false;
                EditCancel.ImageIndex = 0;
                EditCancel.Text = "&Nuevo";
            }
        }

        public static void Controls(Button NewSave, Button EditCancel, Button Delete)
        {

            if (NewSave.Text == "&Guardar" || NewSave.Text == string.Empty)
            {
                NewSave.ImageIndex = 0;
                EditCancel.ImageIndex = 1;
                NewSave.Text = "&Nuevo";
                EditCancel.Text = "&Editar";
            }
            else
            {
                NewSave.ImageIndex = 2;
                EditCancel.ImageIndex = 3;
                NewSave.Text = "&Guardar";
                EditCancel.Text = "&Cancelar";
            }

            Delete.ImageIndex = 4;
            Delete.Text = "&Elimiar";
        }

        public static void frmShow(Form frm)
        {
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.MaximizeBox = false;
            frm.Show();
            //frm.StartPosition = FormStartPosition.WindowsDefaultBounds;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Left = 0;
            frm.Top = 0;
            frm.Select();
            if (frm.WindowState.Equals(FormWindowState.Minimized))
            {
                frm.WindowState = FormWindowState.Normal;
            }
        }
        public static void frmDialog(Form frm, string titulo)        
        {
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.KeyPreview = true;
            frm.Text = titulo;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;            
            frm.ShowDialog();
            //frm.Select();      
        }       

    }

    public class PrintReport
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        public void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.25in</MarginLeft>
                <MarginRight>0.25in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;

            Print();
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }
    }
}
