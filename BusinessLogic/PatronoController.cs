using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;
using DataAccess;
using System.Windows.Forms;
using db=Entity;
namespace BusinessLogic
{
    
    public class PatronoController
    {
        #region Properties
        public PatronoRepository EmpresaDA { get; set; }
        public db.PatronoEntity Empresa { get; set; }
        public DataTable filterData { get; set; }
        #endregion

        #region Instancia
        private static PatronoController _instancia;
        public static PatronoController Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new PatronoController();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        private PatronoController()
        {
            EmpresaDA = PatronoRepository.Instancia;
            Empresa = new db.PatronoEntity();
        }
        #endregion

        //private PatronoRepository PatronoAD { get; set; }
        //public List<PatronoEntity> Listar(string prm)
        //{
        //    return PatronoAD.Listar(prm);
        //}        
        public DataTable Listar(string idEmpresa)
        {
            return EmpresaDA.Listar(idEmpresa);
        }
        public DataTable Listar()
        {
            return EmpresaDA.Listar();
        }

        public int Update(db.PatronoEntity empresa)
        {
            return EmpresaDA.Update(empresa);

        }
        public int Delete(int empresaID)
        {
            return EmpresaDA.Delete(empresaID);
        }
        public int AddNew(db.PatronoEntity empresa)
        {
            return EmpresaDA.AddNew(empresa);

        }

        public void FormatGrid(DataGridView datos)
        {
            filterData = new DataTable();
            filterData.Columns.Add("ID");
            filterData.Columns.Add("Nombre");
            foreach (DataGridViewColumn item in datos.Columns)
            {
                item.Visible = false;
                if (item.Name.Equals("PAT_REP_LEGAL"))
                {
                    item.HeaderText = "Rep. Legal";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("PAT_DIR"))
                {
                    item.HeaderText = "Dirección";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("PAT_TELF"))
                {
                    item.HeaderText = "Teléfono";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("PAT_RAZ_SOCIAL"))
                {
                    item.HeaderText = "Razón Social";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("PAT_OBS"))
                {
                    item.HeaderText = "Observación";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("PAT_ESTADO"))
                {
                    item.HeaderText = "Estado";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                if (item.Name.Equals("PAT_NUM_RUC"))
                {
                    item.HeaderText = "Ruc";
                    item.Visible = true;
                    filterData.Rows.Add(item.Name, item.HeaderText);
                }
                
               
            }

        }
    }
}
