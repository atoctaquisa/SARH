using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using DataAccess;
using db=Entity;

namespace BusinessLogic
{
    public class EscalafonController
    {
        #region Properties
        public DataTable filterData { get; set; }
        public db.EscalafonEntity Escalafon { get; set; }
        #endregion
        private EscalafonRepository EscalafonAD { get; set; }

        #region Instancia / Constructor
        private static EscalafonController _instancia;
        public static EscalafonController Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new EscalafonController();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        private EscalafonController()
        {
            EscalafonAD = EscalafonRepository.Instancia;
            Escalafon = new db.EscalafonEntity();
            
        }

        #endregion

        #region Methods

        public int Delete(int escalafonID)
        {
            return EscalafonAD.Delete(escalafonID);
        }
        public int AddNew(db.EscalafonEntity escalafon)
        {
            return EscalafonAD.AddNew(escalafon);

        }

        public int Update(db.EscalafonEntity escalafon)
        {
            return EscalafonAD.Update(escalafon);
        }

        public void FormatGrid(DataGridView datos)
        {
            filterData = new DataTable();
            filterData.Columns.Add("ID");
            filterData.Columns.Add("Nombre");
            
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;
                if (item.Name.Equals("ESC_CARGOMB")) 
                {
                    item.HeaderText = "Cargo Nombre";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("ESC_CARGOIESS")) 
                {
                    item.HeaderText = "Cargo IIESS";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("ESC_ABRE"))
                {
                    item.HeaderText = "Abreviatura";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("ESC_CODIESS"))
                {
                    item.HeaderText = "Código IIESS";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("ESC_SAL_UNIFICADO"))
                {
                    item.HeaderText = "RBU";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("ESC_ADI_MB"))
                {
                    item.HeaderText = "Sobretiempo";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("ESC_COD_ACT_SEC"))
                {
                    item.HeaderText = "Actividad";
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

        public DataTable Cargo()
        {
            return EscalafonAD.Cargo();
        }

        public DataTable ListarEscalafon()
        {
            return EscalafonAD.ListarEscalafon();
        }
        public DataTable ListarGrupo()
        {
            return EscalafonAD.ListarGrupo();
        }
        public DataTable ListarSubGrupo()
        {
            return EscalafonAD.ListarSubGrupo();
        }
        #endregion
    }
}
