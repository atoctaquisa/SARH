using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;
using System.Windows.Forms;
using db=Entity;


namespace BusinessLogic
{
    public class LocalController
    {

        #region Propiedades        
        public LocalRepository LocalDA { get; set; }
        public db.LocalEntity Local { get; set; }
        public DataTable filterData { get; set; }
        #endregion

        #region Instancia
        private static LocalController _instancia;
        public static LocalController Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new LocalController();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public LocalController()
        {
            LocalDA = LocalRepository.Instancia;
            Local = new db.LocalEntity();
        }
        #endregion

        public int Update(db.LocalEntity local)
        {
            return LocalDA.Update(local);

        }
        public int Delete(int localID)
        {
            return LocalDA.Delete(localID);
        }
        public int AddNew(db.LocalEntity local)
        {
            return LocalDA.AddNew(local);
            
        }
        public void FormatGrid(DataGridView datos)
        {
            filterData = new DataTable();            
            filterData.Columns.Add("ID");
            filterData.Columns.Add("Nombre");
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;
                if(item.Name.Equals("LOC_NOMBRE"))
                {
                    item.HeaderText = "Nombre";                                 
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("LOC_DIR"))
                {
                    item.HeaderText = "Dirección";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("LOC_TELF"))
                {
                    item.HeaderText = "Teléfono";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("LOC_PROVINCIA"))
                {
                    item.HeaderText = "Provincia";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("LOC_CIUDAD"))
                {
                    item.HeaderText = "Ciudad";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("LOC_ESTADO"))
                {
                    item.HeaderText = "Estado";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("LOC_PAG_SERVICIO"))
                {
                    item.HeaderText = "Pago Serv.";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("LOC_RUC"))
                {
                    item.HeaderText = "Ruc";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("LOC_FEC_CREA"))
                {
                    item.HeaderText = "Fecha Creación";
                    item.Visible = true;                    
                }
                if (item.Name.Equals("LOC_COD_IESS"))
                {
                    item.HeaderText = "Código IESS";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                
            }
            
        }

        public DataTable ClienteLista()
        {
            return LocalDA.ClienteLista();
        }

        public DataTable Lista()
        {
            return LocalDA.Lista();
        }
        public DataTable ListaCadena()
        {
            return LocalDA.ListaCadena();
        }
        public DataTable Lista(string idLocal)
        {
            return LocalDA.Lista(idLocal);
        }
        
        public List<db.LocalEntity> Listar()
        {
            return LocalDA.Listar();
        }

        
        
        public void NuevoLocal()
        {
            Local = new db.LocalEntity();
            //Local.Estado = 1;
            //Local.FechaCrea = Convert.ToDateTime(SistemaController.Instancia.FechaCentral());
        }



        
    }
}
