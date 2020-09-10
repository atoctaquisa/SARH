using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;
using System.Data;
using Oracle.DataAccess.Client;

namespace DataAccess
{
    public class UbicacionRepository
    {
        #region SentenciasSQL
        private static string sqlListaSector = @"SELECT EMP_SEC_ID ID, EMP_SEC_NOMBRE Nombre FROM DESARROLLO.dat_emp_sec ORDER BY EMP_SEC_NOMBRE";
        
        #endregion

        #region Instancia / Constructor
        private static UbicacionRepository _instancia;
        public static UbicacionRepository Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new UbicacionRepository();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }

        }

        private UbicacionRepository()
        {
            db = ConnectionDDBB.Instancia;
        }


        #endregion

        private ConnectionDDBB db { get; set; }

        public DataTable listaSector()
        {
            return db.GetData(sqlListaSector);            
        }
    }
}
