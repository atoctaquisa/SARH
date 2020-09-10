using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;
namespace DataAccess
{
    public class CatalogoRepository
    {

        #region StatementSQL
        private static string sqlListaProvincia = "SELECT PROVIN_ID, PROVIN_NOMBRE, PROVIN_COD_SRI FROM DESARROLLO.DAT_PROVINCIAS ORDER BY 2";
        private static string sqlListaCiudad = "SELECT CIU_ID, CIU_NOMBRE, CIU_ABREV, CIU_REGIMEN FROM DESARROLLO.DAT_CIUDAD ORDER BY 2";
        #endregion        
        
        #region Properties
        private ConnectionDDBB db { get; set; }
        #endregion        

        #region Instancia / Constructor
        private static CatalogoRepository _instancia;
        public static CatalogoRepository Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CatalogoRepository();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }

        }

        private CatalogoRepository()
        {
            db = ConnectionDDBB.Instancia;
        }


        #endregion

        //public List<ProvinciaEntity> ListaProvincia()
        //{
        //    List<ProvinciaEntity> lis = new List<ProvinciaEntity>();
        //    ConnectionDDBB db = new ConnectionDDBB();
        //    var reader = db.ExecuteSelect(sqlListaProvincia);
        //    while (reader.Read())
        //    {
        //        lis.Add(ConvertLocal(reader));
        //    }
        //    return lis;
        //}

        public DataTable ListaProvincia()
        {
            DataTable datos = new DataTable();
            datos = db.GetData(sqlListaProvincia);
            return datos;
        }

        //private ProvinciaEntity ConvertLocal(IDataReader reader)
        //{
        //    ProvinciaEntity item = new ProvinciaEntity();
        //    item.ProvinciaID = Convert.ToInt32(reader["PROVIN_ID"]);
        //    item.Nombre = Convert.ToString(reader["PROVIN_NOMBRE"]);
        //    item.CodSRI = Convert.ToString(reader["PROVIN_COD_SRI"]);            
        //    return item;
        //}


        public DataTable ListaCiudad()
        {
            DataTable datos = new DataTable();
            datos = db.GetData(sqlListaCiudad);
            return datos;
        }

        //public List<CiudadEntity> ListaCiudad()
        //{
        //    List<CiudadEntity> lis = new List<CiudadEntity>();
        //    ConnectionDDBB db = new ConnectionDDBB();
        //    var reader = db.ExecuteSelect(sqlListaCiudad);
        //    while (reader.Read())
        //    {
        //        lis.Add(ConvertCiudad(reader));
        //    }
        //    return lis;
        //}

        //private CiudadEntity ConvertCiudad(IDataReader reader)
        //{
        //    CiudadEntity item = new CiudadEntity();
        //    item.CiudadID = Convert.ToInt32(reader["CIU_ID"]);
        //    item.Nombre = Convert.ToString(reader["CIU_NOMBRE"]);
        //    item.Abrev = Convert.ToString(reader["CIU_ABREV"]);
        //    item.Regimen = Convert.ToString(reader["CIU_REGIMEN"]);
        //    return item;
        //}
    }
}
