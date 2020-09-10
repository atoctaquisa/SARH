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
    public class EscalafonRepository
    {         
        private static string sqlEscalafonUpdate = @"UPDATE DESARROLLO.DAT_ESC
                                                    SET    --ESC_ID            = :ESC_ID,
                                                           --ESC_GRU_ID        = :ESC_GRU_ID,
                                                           ESC_CARGOMB       = :ESC_CARGOMB,
                                                           ESC_CARGOIESS     = :ESC_CARGOIESS,
                                                           ESC_CODIESS       = :ESC_CODIESS,
                                                           --ESC_PUNTAJE       = :ESC_PUNTAJE,
                                                           ESC_SAL_UNIFICADO = :ESC_SAL_UNIFICADO,
                                                           ESC_ADI_MB        = :ESC_ADI_MB,
                                                           --ESC_BON_ASIS      = :ESC_BON_ASIS,
                                                           --ESC_ALIMEN        = :ESC_ALIMEN,
                                                           --ESC_VEST          = :ESC_VEST,
                                                           --ESC_OBS_SUELDO    = :ESC_OBS_SUELDO,
                                                           ESC_COD_ACT_SEC   = :ESC_COD_ACT_SEC,
                                                           ESC_ESTADO        = :ESC_ESTADO,
                                                           ESC_FEC_MOD       = SYSDATE,
                                                           --ESC_FEC_CRE       = :ESC_FEC_CRE,
                                                           --GRU_CARG_ID       = :GRU_CARG_ID,
                                                           ESC_ABRE          = :ESC_ABRE,
                                                           --ESC_ADI_BON_PRO   = :ESC_ADI_BON_PRO,
                                                           --ESC_FUN_MIN_TRA   = :ESC_FUN_MIN_TRA,
                                                           --ESC_PUNT_UTI      = :ESC_PUNT_UTI,
                                                           --ESC_INS_ECO       = :ESC_INS_ECO,
                                                           --RBU_CONTR         = :RBU_CONTR,
                                                           --ESC_INC_VENT      = :ESC_INC_VENT,
                                                           ESC_VAL_FACT      = :ESC_VAL_FACT
                                                    WHERE  ESC_GRU_ID=:ESC_GRU_ID AND ESC_ID=:ESC_ID ";       
         
        private static string sqlEscalafonInsert = @"INSERT INTO DESARROLLO.DAT_ESC (
                                                       ESC_ID, ESC_GRU_ID, ESC_CARGOMB, 
                                                       ESC_CARGOIESS, ESC_CODIESS, 
                                                       ESC_PUNTAJE, 
                                                       ESC_SAL_UNIFICADO, 
                                                       --ESC_ADI_MB, 
                                                       ESC_BON_ASIS, 
                                                       --ESC_ALIMEN, ESC_VEST, ESC_OBS_SUELDO, 
                                                       ESC_COD_ACT_SEC, 
                                                       ESC_ESTADO, 
                                                       --ESC_FEC_MOD, 
                                                       ESC_FEC_CRE, 
                                                       GRU_CARG_ID, 
                                                       ESC_ABRE, 
                                                       --ESC_ADI_BON_PRO, 
                                                       --ESC_FUN_MIN_TRA, 
                                                       --ESC_PUNT_UTI, 
                                                       --ESC_INS_ECO, 
                                                       --RBU_CONTR, 
                                                       --ESC_INC_VENT, 
                                                       ESC_VAL_FACT) 
                                                    VALUES ( :ESC_ID,
                                                     :ESC_GRU_ID,
                                                     :ESC_CARGOMB,
                                                     :ESC_CARGOIESS,
                                                     :ESC_CODIESS,
                                                     0,--:ESC_PUNTAJE,
                                                     :ESC_SAL_UNIFICADO,
                                                     --:ESC_ADI_MB,
                                                     :ESC_BON_ASIS,
                                                     --:ESC_ALIMEN,
                                                     --:ESC_VEST,
                                                     --:ESC_OBS_SUELDO,
                                                     :ESC_COD_ACT_SEC,
                                                     :ESC_ESTADO,
                                                     --:ESC_FEC_MOD,
                                                     SYSDATE,
                                                     0,--:GRU_CARG_ID,
                                                     :ESC_ABRE,
                                                     --:ESC_ADI_BON_PRO,
                                                     --:ESC_FUN_MIN_TRA,
                                                     --:ESC_PUNT_UTI,
                                                     --:ESC_INS_ECO,
                                                     --:RBU_CONTR,
                                                     --:ESC_INC_VENT,
                                                     :ESC_VAL_FACT )";
        private static string sqlEscalafonDelete = @"DELETE DESARROLLO.DAT_ESC WHERE ESC_ID=:ESC_ID";
        private static string sqlListarGrupo = "  SELECT ESC_GRU_ID, ESC_GRU_NOMBRE, ESC_GRU_CRDT_MAX, ESC_GRU_DSCT_MAX FROM DESARROLLO.DAT_ESC_GRU WHERE ESC_GRU_ID=100000";
        private static string sqlListarSubGrupo = "  SELECT ESC_GRU_ID, ESC_GRU_NOMBRE, ESC_GRU_CRDT_MAX, ESC_GRU_DSCT_MAX FROM DESARROLLO.DAT_ESC_GRU WHERE ESC_GRU_ID !=100000";
        private static string sqlListarEscalafon = @"SELECT ESC_ID, ESC_GRU_ID, ESC_CARGOMB, ESC_CARGOIESS, ESC_ABRE,ESC_CODIESS, ESC_SAL_UNIFICADO, ESC_ADI_MB, ESC_COD_ACT_SEC, DECODE(ESC_ESTADO,1,'ACTIVO','INACTIVO')ESTADO,ESC_ESTADO, ESC_ADI_BON_PRO,
                                                           ESC_BON_ASIS, ESC_ALIMEN, ESC_VEST, ESC_OBS_SUELDO, ESC_PUNTAJE, ESC_FEC_MOD, ESC_FEC_CRE, GRU_CARG_ID,  ESC_FUN_MIN_TRA, ESC_PUNT_UTI, ESC_INS_ECO, 
                                                           RBU_CONTR, ESC_INC_VENT, ESC_VAL_FACT 
                                                    FROM DESARROLLO.DAT_ESC ORDER BY 1";
        private static string sqlCargo = @"SELECT ALL DAT_ESC.ESC_ID, DAT_ESC.ESC_CARGOMB, DAT_ESC_GRU.ESC_GRU_NOMBRE FROM desarrollo.DAT_ESC, desarrollo.DAT_ESC_GRU WHERE (DAT_ESC.ESC_GRU_ID = DAT_ESC_GRU.ESC_GRU_ID) AND DAT_ESC.esc_estado=1 order by DAT_ESC.ESC_CARGOMB ";
        //private static string sqlEmpresaCodigo = "SELECT NVL(MAX(PAT_ID),0)+1 FROM DESARROLLO.DAT_PATRONO";
        private static string sqlEscalafonCodigo = "SELECT NVL(MAX(ESC_ID),0)+1 FROM DESARROLLO.DAT_ESC";
        #region Properties
        private ConnectionDDBB db { get; set; }
        #endregion

        #region Constructor
        private static EscalafonRepository _instancia;
        public static EscalafonRepository Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new EscalafonRepository();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }

        }

        private EscalafonRepository()
        {
            db = ConnectionDDBB.Instancia;
        }


        #endregion


        private int EscalafonGeneraCodigo()
        {
            return db.GetEntero(sqlEscalafonCodigo);
        }

        public int AddNew(EscalafonEntity escalafon)
        {
            int pkCode = 0;
            OracleParameter[] rmp = new OracleParameter[]
                {
                    new OracleParameter(":ESC_ID", pkCode=EscalafonGeneraCodigo()),
                    new OracleParameter(":ESC_GRU_ID", escalafon.EscGruID),
                    new OracleParameter(":ESC_CARGOMB", escalafon.Cargo),
                    new OracleParameter(":ESC_CARGOIESS", escalafon.CategoriaIESS),
                    new OracleParameter(":ESC_CODIESS", escalafon.CodIESS),                    
                    new OracleParameter(":ESC_SAL_UNIFICADO", escalafon.SalarioUnifi),
                    new OracleParameter(":ESC_BON_ASIS", escalafon.BonoAsis),
                    new OracleParameter(":ESC_COD_ACT_SEC", escalafon.CodActSec),
                    new OracleParameter(":ESC_ESTADO", escalafon.Estado),        
                    new OracleParameter(":ESC_ABRE", escalafon.Abrev),                            
                    new OracleParameter(":ESC_VAL_FACT", escalafon.ValFact)             
                };

            if (db.ExecQuery(sqlEscalafonInsert, rmp).Equals(1))
                return pkCode;
            else
                return 0;
            //return db.ExecQuery(sqlLocalInsert, rmp);

        }

        public int Update(EscalafonEntity escalafon)
        {
            //ConnectionDDBB db = new ConnectionDDBB();
            OracleParameter[] rmp = new OracleParameter[]
                {
                    
                    new OracleParameter(":ESC_CARGOMB", escalafon.Cargo),
                    new OracleParameter(":ESC_CARGOIESS", escalafon.CategoriaIESS),
                    new OracleParameter(":ESC_CODIESS", escalafon.CodIESS),
                    ////new OracleParameter(":ESC_ALIMEN", escalafon.FechaConst),
                    new OracleParameter(":ESC_SAL_UNIFICADO", escalafon.SalarioUnifi),
                    new OracleParameter(":ESC_ADI_MB", escalafon.AdiBono),
                    //new OracleParameter(":ESC_BON_ASIS", escalafon.BonoAsis),
                    //new OracleParameter(":ESC_VEST", escalafon.Vestiment),
                    ////new OracleParameter(":ESC_OBS_SUELDO", escalafon.CodIESS),
                    new OracleParameter(":ESC_COD_ACT_SEC", escalafon.CodActSec),
                    new OracleParameter(":ESC_ESTADO", escalafon.Estado),
                    ////new OracleParameter(":ESC_FEC_MOD", escalafon.CodIESS),
                    ////new OracleParameter(":ESC_FEC_CRE", escalafon.CodIESS),
                    ////new OracleParameter(":GRU_CARG_ID", escalafon.CodIESS),
                    new OracleParameter(":ESC_ABRE", escalafon.Abrev),
                    //new OracleParameter(":ESC_ADI_BON_PRO", escalafon.AdiBono),
                    ////new OracleParameter(":ESC_FUN_MIN_TRA", escalafon.CodIESS),
                    //new OracleParameter(":ESC_PUNT_UTI", escalafon.PuntUtili),
                    ////new OracleParameter(":ESC_INS_ECO", escalafon.),
                    //new OracleParameter(":RBU_CONTR", escalafon.Rbu),
                    //new OracleParameter(":ESC_INC_VENT", 0),
                    new OracleParameter(":ESC_VAL_FACT", escalafon.ValFact),
                    new OracleParameter(":ESC_GRU_ID", escalafon.EscGruID),
                    new OracleParameter(":ESC_ID", escalafon.EscID)
                };

            if (db.ExecQuery(sqlEscalafonUpdate, rmp).Equals(1))
                return escalafon.EscID;
            else
                return 0;
        }


        public int Delete(int escalafonID)
        {
            OracleParameter[] rmp = new OracleParameter[]
                {                    
                    new OracleParameter(":ESC_ID", escalafonID)
                };
            return db.ExecQuery(sqlEscalafonDelete, rmp);
        }

        public DataTable Cargo()
        {
            return db.GetData(sqlCargo);
        }


        public DataTable ListarEscalafon()
        {
            DataTable datos = new DataTable();
            datos = db.GetData(sqlListarEscalafon);
            return datos;
        }
        public DataTable ListarGrupo()
        {
            DataTable datos = new DataTable();
            datos = db.GetData(sqlListarGrupo);
            return datos;
        }
        public DataTable ListarSubGrupo()
        {
            DataTable datos = new DataTable();
            datos = db.GetData(sqlListarSubGrupo);
            return datos;
        }
        //public List<EscalafonEntity> ListaEscalafon()
        //{
        //    List<EscalafonEntity> lis = new List<EscalafonEntity>();           
        //    var reader = db.ExecuteSelect(sqlListarEscalafon);
        //    while (reader.Read())
        //    {
        //        lis.Add(ConvertEscalafon(reader));
        //    }
        //    return lis;
        //}
        //private EscalafonEntity ConvertEscalafon(IDataReader reader)
        //{
        //    EscalafonEntity item = new EscalafonEntity();
        //    item.EscID = Convert.ToInt32(reader["ESC_ID"]);
        //    item.EscGruID = Convert.ToInt32(reader["ESC_GRU_ID"]);
        //    item.Cargo  = Convert.ToString(reader["ESC_CARGOMB"]);
        //    item.CategoriaIESS = Convert.ToString(reader["ESC_CARGOIESS"]);
        //    item.CodIESS = Convert.ToString(reader["ESC_CODIESS"]);
        //    //item.Puntaje = Convert.ToInt32(reader["ESC_PUNTAJE"]);
        //    item.SalarioUnifi = Convert.ToInt32(reader["ESC_SAL_UNIFICADO"]);
        //    item.AdiBono = Convert.ToInt32(reader["ESC_ADI_MB"]);
        //    item.BonoAsis = Convert.ToInt32(reader["ESC_BON_ASIS"]);

        //    return item;
        //}


        public List<EscalafonGrupoEntity> ListaEscalafonGrupo(bool tipo)
        {
            List<EscalafonGrupoEntity> lis = new List<EscalafonGrupoEntity>();
            if (!tipo)
                sqlListarGrupo = sqlListarSubGrupo;

            var reader = db.ExecuteSelect(sqlListarGrupo);
            while (reader.Read())
            {
                lis.Add(ConvertEscalafonGrupo(reader));
            }
            return lis;
        }
        private EscalafonGrupoEntity ConvertEscalafonGrupo(IDataReader reader)
        {
            EscalafonGrupoEntity item = new EscalafonGrupoEntity();
            item.EscGruID = Convert.ToInt32(reader["ESC_GRU_ID"]);
            item.Nombre = Convert.ToString(reader["ESC_GRU_NOMBRE"]);
            item.CredMax = Convert.ToInt32(reader["ESC_GRU_CRDT_MAX"]);
            item.DescMAx = Convert.ToInt32(reader["ESC_GRU_DSCT_MAX"]);

            return item;
        }

    }
}
