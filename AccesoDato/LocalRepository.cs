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
    public class LocalRepository
    {
        #region StatementSQL
        private static string sqlLocalDelete = "DELETE DESARROLLO.DAT_LOC WHERE LOC_ID=:LOC_ID";
        private static string sqlClienteLista = @"SELECT DESARROLLO.PK_TRANS_CONT.F_BUSCA_NOM_LOC (CLI_ID) AS CLI_NOMBRE, CLI_ID
                                                  FROM DESARROLLO.DAT_CLIENTE
                                                 WHERE CLI_ESTADO = 1 AND CLI_TIPO IS NOT NULL ";
        private static string sqlLocalLista = @"SELECT LOC_ID , LOC_RUC, LOC_NOMBRE , LOC_DIR , LOC_TELF , LOC_PROVINCIA , LOC_CIUDAD , 
                                             DECODE(LOC_ESTADO,1,'ACTIVA','INACTIVA') ESTADO, LOC_PAG_SERVICIO, LOC_PART_ROL,  LOC_FEC_CREA, LOC_FEC_MOD, 
                                             LOC_PROV_SEDE PROVINCIA, LOC_CIU_SEDE, LOC_DIR_SEDE, LOC_COD_IESS, GRU_LOC_ID, LOC_REGIMEN, 
                                             LOC_CIUDAD_ABREV, GRU_LOC_NOM_ID, LOC_SIGLA, LOC_SIGLA_DIR, LOC_PUNT_BONO, LOC_NUMERO, 
                                             CAD_ID, MBA_ID, LOC_MAIL, NTFC_ANLD, LOC_TIPO_CONT, LOC_SEG_MED 
                                             FROM DESARROLLO.DAT_LOC ORDER BY LOC_NOMBRE ASC";
        private static string sqlLocal = @"SELECT LOC_ID CODIGO, LOC_RUC RUC, LOC_NOMBRE NOMBRE, LOC_DIR DIRECCION, LOC_TELF TELEFONO, LOC_PROVINCIA PROVINCIA, LOC_CIUDAD CIUDAD, 
                                             DECODE(LOC_ESTADO,1,'ACTIVA','INACTIVA') ESTADO,LOC_ESTADO, LOC_PAG_SERVICIO, LOC_PART_ROL,  LOC_FEC_CREA, LOC_FEC_MOD, 
                                             LOC_PROV_SEDE, LOC_CIU_SEDE, LOC_DIR_SEDE, LOC_COD_IESS, GRU_LOC_ID, LOC_REGIMEN, 
                                             LOC_CIUDAD_ABREV ABRV, GRU_LOC_NOM_ID, LOC_SIGLA, LOC_SIGLA_DIR, LOC_PUNT_BONO, LOC_NUMERO, 
                                             CAD_ID, MBA_ID, LOC_MAIL, NTFC_ANLD, LOC_TIPO_CONT, LOC_SEG_MED 
                                             FROM DESARROLLO.DAT_LOC WHERE LOC_ID=:idLocal";
        private static string sqlCadena = @"
SELECT CAD_ID,
       CAD_NOMBRE,
       FECHACREA,
       FECHAACT,
       CAD_ESTADO,
       CADENA,
       EMPRESA_JDE,
       CC_JDE
  FROM DESARROLLO.DAT_CADENA WHERE CAD_ESTADO=1";
//        private static string sqlLocalInsert = @"INSERT INTO DESARROLLO.DAT_LOC 
//                                            (LOC_ID,LOC_NOMBRE,LOC_DIR,LOC_TELF,LOC_PROVINCIA,LOC_CIUDAD,LOC_ESTADO,LOC_PAG_SERVICIO,
//                                            LOC_PART_ROL,LOC_RUC,LOC_FEC_CREA,LOC_FEC_MOD,LOC_PROV_SEDE,LOC_CIU_SEDE,
//                                            LOC_DIR_SEDE,LOC_COD_IESS,GRU_LOC_ID,LOC_REGIMEN,LOC_CIUDAD_ABREV,GRU_LOC_NOM_ID,
//                                            LOC_SIGLA,LOC_SIGLA_DIR,LOC_PUNT_BONO,LOC_NUMERO,CAD_ID,MBA_ID,LOC_MAIL,NTFC_ANLD,
//                                            LOC_TIPO_CONT,LOC_SEG_MED)
//     VALUES (:LOC_ID,:LOC_NOMBRE,:LOC_DIR,:LOC_TELF,:LOC_PROVINCIA,:LOC_CIUDAD,:LOC_ESTADO,:LOC_PAG_SERVICIO,:LOC_PART_ROL,
//             :LOC_RUC,:LOC_FEC_CREA,:LOC_FEC_MOD,:LOC_PROV_SEDE,:LOC_CIU_SEDE,:LOC_DIR_SEDE,:LOC_COD_IESS,:GRU_LOC_ID,:LOC_REGIMEN,
//             :LOC_CIUDAD_ABREV,:GRU_LOC_NOM_ID,:LOC_SIGLA,:LOC_SIGLA_DIR,:LOC_PUNT_BONO,:LOC_NUMERO,:CAD_ID,:MBA_ID,:LOC_MAIL,
//             :NTFC_ANLD,:LOC_TIPO_CONT,:LOC_SEG_MED) ";

        private static string sqlLocalInsert = @"INSERT INTO DESARROLLO.DAT_LOC (LOC_ID,
                                                                                LOC_NOMBRE,
                                                                                LOC_DIR,
                                                                                LOC_TELF,
                                                                                LOC_PROVINCIA,
                                                                                LOC_CIUDAD,
                                                                                LOC_ESTADO,
                                                                                LOC_PAG_SERVICIO,
                                                                                LOC_RUC,
                                                                                LOC_FEC_CREA,
                                                                                LOC_COD_IESS,
                                                                                LOC_CIUDAD_ABREV
                                                                                )
                                                     VALUES (:LOC_ID,
                                                             :LOC_NOMBRE,
                                                             :LOC_DIR,
                                                             :LOC_TELF,
                                                             :LOC_PROVINCIA,
                                                             :LOC_CIUDAD,
                                                             :LOC_ESTADO,
                                                             :LOC_PAG_SERVICIO,             
                                                             :LOC_RUC,
                                                             SYSDATE,
                                                             :LOC_COD_IESS,             
                                                             :LOC_CIUDAD_ABREV
                                                             ) ";

        private static string sqlLocalCodigo = "SELECT NVL(MAX(LOC_ID),0)+1 FROM DESARROLLO.DAT_LOC";

        private static string sqlLocalUpdate = @"UPDATE DESARROLLO.DAT_LOC SET 
                                                             LOC_NOMBRE = :LOC_NOMBRE, 
                                                             LOC_DIR=:LOC_DIR,
                                                             LOC_TELF=:LOC_TELF,
                                                             LOC_PROVINCIA=:LOC_PROVINCIA,
                                                             LOC_CIUDAD=:LOC_CIUDAD,
                                                             LOC_ESTADO=:LOC_ESTADO,
                                                             LOC_PAG_SERVICIO=:LOC_PAG_SERVICIO,             
                                                             LOC_RUC=:LOC_RUC,
                                                             LOC_FEC_MOD=SYSDATE,
                                                             LOC_COD_IESS=:LOC_COD_IESS,             
                                                             LOC_CIUDAD_ABREV=:LOC_CIUDAD_ABREV
                                                             --LOC_SEG_MED=:LOC_SEG_MED
                                                             WHERE LOC_ID = :LOC_ID";
        #endregion

        #region Instancia / Constructor
        private static LocalRepository _instancia;
        public static LocalRepository Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new LocalRepository();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }

        }

        private LocalRepository()
        {
            db = ConnectionDDBB.Instancia;
        }


        #endregion

        private ConnectionDDBB db { get; set; }

        public int Delete(int localID)
        {
            OracleParameter[] rmp = new OracleParameter[]
                {                    
                    new OracleParameter(":LOC_ID", localID)
                };
                return db.ExecQuery(sqlLocalDelete, rmp);
        }

        public int AddNew(LocalEntity local)
        {
            int pkCode = 0;
            OracleParameter[] rmp = new OracleParameter[]
                {                    
                    new OracleParameter(":LOC_ID", pkCode=LocalGeneraCodigo()),
                    new OracleParameter(":LOC_NOMBRE", local.Nombre),
                    new OracleParameter(":LOC_DIR", local.Direccion),
                    new OracleParameter(":LOC_TELF", local.Telefono),
                    new OracleParameter(":LOC_PROVINCIA", local.Provincia),
                    new OracleParameter(":LOC_CIUDAD", local.Ciudad),
                    new OracleParameter(":LOC_ESTADO", local.Estado),
                    new OracleParameter(":LOC_PAG_SERVICIO", local.PagoServicio),
                    //new OracleParameter(":LOC_PART_ROL", local.Nombre),
                    new OracleParameter(":LOC_RUC", local.Ruc),
                    //new OracleParameter(":LOC_FEC_CREA",),
                    //new OracleParameter(":LOC_FEC_MOD", local.Nombre),
                    //new OracleParameter(":LOC_PROV_SEDE", local.Nombre),
                    //new OracleParameter(":LOC_CIU_SEDE", local.Nombre),
                    //new OracleParameter(":LOC_DIR_SEDE", local.Nombre),
                    new OracleParameter(":LOC_COD_IESS", local.CodIESS),
                    //new OracleParameter(":GRU_LOC_ID", local.Nombre),
                    //new OracleParameter(":LOC_REGIMEN", local.Nombre),
                    new OracleParameter(":LOC_CIUDAD_ABREV", local.Abrev)
                    //new OracleParameter(":GRU_LOC_NOM_ID", local.Nombre),
                    //new OracleParameter(":LOC_SIGLA", local.Abrev),
                    //new OracleParameter(":LOC_SIGLA_DIR", local.Nombre),
                    //new OracleParameter(":LOC_PUNT_BONO", local.Nombre),
                    //new OracleParameter(":LOC_NUMERO", local.Nombre),
                    //new OracleParameter(":CAD_ID,", local.Nombre),
                    //new OracleParameter(":MBA_ID", local.Nombre),
                    //new OracleParameter(":LOC_MAIL", local.Nombre),
                    //new OracleParameter(":NTFC_ANLD", local.Nombre),
                    //new OracleParameter(":LOC_TIPO_CONT", local.Nombre),
                    //new OracleParameter(":LOC_SEG_MED", local.Nombre),
                    
                    
                };
            
            if (db.ExecQuery(sqlLocalInsert, rmp).Equals(1))
                return pkCode;
            else
                return 0;
            //return db.ExecQuery(sqlLocalInsert, rmp);
 
        }
        private int LocalGeneraCodigo()
        {
            return db.GetEntero(sqlLocalCodigo);
        }
        public int Update(LocalEntity local)
        {
            //ConnectionDDBB db = new ConnectionDDBB();
            OracleParameter[] rmp = new OracleParameter[]
                {
                    
                    new OracleParameter(":LOC_NOMBRE", local.Nombre),
                    new OracleParameter(":LOC_DIR", local.Direccion),
                    new OracleParameter(":LOC_TELF", local.Telefono),
                    new OracleParameter(":LOC_PROVINCIA", local.Provincia),
                    new OracleParameter(":LOC_CIUDAD", local.Ciudad),
                    new OracleParameter(":LOC_ESTADO", local.Estado),
                    new OracleParameter(":LOC_PAG_SERVICIO", local.PagoServicio),
                    //new OracleParameter(":LOC_PART_ROL", local.part),
                    new OracleParameter(":LOC_RUC", local.Ruc),
                    //new OracleParameter(":LOC_FEC_CREA", local.Nombre),
                    //new OracleParameter(":LOC_FEC_MOD", local.Nombre),
                    //new OracleParameter(":LOC_PROV_SEDE", local.),
                    //new OracleParameter(":LOC_CIU_SEDE", local.Nombre),
                    //new OracleParameter(":LOC_DIR_SEDE", local.Nombre),
                    new OracleParameter(":LOC_COD_IESS", local.CodIESS),
                    //new OracleParameter(":GRU_LOC_ID", local.),
                    //new OracleParameter(":LOC_REGIMEN", local.),
                    new OracleParameter(":LOC_CIUDAD_ABREV", local.Abrev),
                    //new OracleParameter(":GRU_LOC_NOM_ID", local.Nombre),
                    //new OracleParameter(":LOC_SIGLA", local.Nombre),
                    //new OracleParameter(":LOC_SIGLA_DIR", local.Nombre),
                    //new OracleParameter(":LOC_PUNT_BONO", local.Nombre),
                    //new OracleParameter(":LOC_NUMERO", local.Nombre),
                    //new OracleParameter(":CAD_ID", local.Nombre),
                    //new OracleParameter(":MBA_ID", local.Nombre),
                    //new OracleParameter(":LOC_MAIL", local.Nombre),
                    //new OracleParameter(":NTFC_ANLD", local.Nombre),
                    //new OracleParameter(":LOC_TIPO_CONT", local.Nombre),
                    //new OracleParameter(":LOC_SEG_MED", local.SeguroM),
                    new OracleParameter(":LOC_ID", local.LocalID)
                };

            if (db.ExecQuery(sqlLocalUpdate, rmp).Equals(1))
                return local.LocalID;
            else
                return 0;
        }

        public DataTable Lista(string idLocal)
        {

            DataTable datos = new DataTable();
            OracleParameter[] prm = new OracleParameter[]
                {
                    
                    new OracleParameter(":idLocal", idLocal)
                };
            datos = db.GetData(sqlLocal, prm);
            return datos;
        }

        public DataTable ClienteLista()
        {
            DataTable datos = new DataTable();
            datos = db.GetData(sqlClienteLista);
            return datos;
        }
        public DataTable Lista()
        {
            DataTable datos = new DataTable();
            datos = db.GetData(sqlLocalLista);
            return datos;
        }

        public DataTable ListaCadena()
        {
            DataTable datos = new DataTable();
            datos = db.GetData(sqlCadena);
            return datos;
        }

        public List<LocalEntity> Listar()
        {

            List<LocalEntity> lis = new List<LocalEntity>();
            //ConnectionDDBB db = new ConnectionDDBB();
            var reader = db.ExecuteSelect(sqlLocalLista);
            while (reader.Read())
            {
                lis.Add(ConvertLocal(reader));
            }
            return lis;
        }
        private LocalEntity ConvertLocal(IDataReader reader)
        {
            LocalEntity item = new LocalEntity();
            item.LocalID = Convert.ToInt32(reader["LOC_ID"]);
            item.Nombre = Convert.ToString(reader["LOC_NOMBRE"]);
            item.Direccion = Convert.ToString(reader["LOC_DIR"]);
            item.Telefono = Convert.ToString(reader["LOC_TELF"]);
            item.Provincia = Convert.ToString(reader["LOC_PROVINCIA"]);
            item.Ciudad = Convert.ToString(reader["LOC_CIUDAD"]);
            item.Estado = Convert.ToInt32(reader["LOC_ESTADO"]);
            item.PagoServicio = Convert.ToInt32(reader["LOC_PAG_SERVICIO"]);
            item.Ruc = Convert.ToString(reader["LOC_RUC"]);
            item.CodIESS = Convert.ToString(reader["LOC_COD_IESS"]);
            item.Abrev = Convert.ToString(reader["LOC_CIUDAD_ABREV"]);
            return item;
        }
    }
}
