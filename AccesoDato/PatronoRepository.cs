using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;
using Oracle.DataAccess.Client;

namespace DataAccess
{
    public class PatronoRepository
    {
        #region StatementSQL
        private static string sqlListar = @"SELECT PAT_ID , PAT_NUM_RUC , PAT_RAZ_SOCIAL , PAT_DIR ,PAT_REP_LEGAL , PAT_OBS , PAT_TELF , PAT_ESTADO, DECODE(PAT_ESTADO,1,'ACTIVO','INACTIVO') ESTADO FROM DESARROLLO.DAT_PATRONO";
        private static string sqlListaEmpresa = @"SELECT PAT_ID, PAT_NUM_PATRONAL, PAT_REP_LEGAL, 
   PAT_DIR, PAT_RAZ_SOCIAL, PAT_FEC_CONST, 
   PAT_FEC_LIQ, PAT_OBS, PAT_NOMBRE, 
   PAT_ESTADO, PAT_PROVNOMBRE, PAT_PROVCOD, 
   PAT_CANTNOM, PAT_CANTCOD, PAT_PARRNOM, 
   PAT_PARRCOD, PAT_TELF, PAT_NUM_RUC, 
   PAT_CODSUC, PAT_ESTADO_CONTA, DIR_NUMERO, 
   PAT_ACTIVIDAD, PAT_OBS2, PAT_RUC_CONTADOR, 
   PAT_JDE FROM DESARROLLO.DAT_PATRONO WHERE PAT_ID=:idEmpresa";
        //private static string sqlListarFiltro = @"SELECT * FROM (SELECT PAT_ID, PAT_REP_LEGAL, PAT_DIR, PAT_RAZ_SOCIAL, PAT_OBS, PAT_TELF, PAT_NUM_RUC, PAT_ESTADO FROM DESARROLLO.DAT_PATRONO 
        //                                        UNION ALL SELECT 0 PAT_ID, 'TODOS' PAT_REP_LEGAL, '' PAT_DIR, 'TODOS' PAT_RAZ_SOCIAL, NULL PAT_OBS, '' PAT_TELF, '' PAT_NUM_RUC, 1 PAT_ESTADO FROM DUAL) ORDER BY DECODE(PAT_RAZ_SOCIAL,'TODOS',1),PAT_RAZ_SOCIAL";
        private static string sqlEmpresaDelete = @"DELETE DESARROLLO.DAT_PATRONO WHERE PAT_ID=:PAT_ID";
        private static string sqlEmpresaInsert = @"INSERT INTO DESARROLLO.DAT_PATRONO (PAT_ID,
                                    PAT_NUM_PATRONAL,
                                    PAT_REP_LEGAL,
                                    PAT_DIR,
                                    PAT_RAZ_SOCIAL,
                                    --PAT_FEC_CONST,
                                    --PAT_FEC_LIQ,
                                    PAT_OBS,
                                    PAT_NOMBRE,
                                    PAT_ESTADO,
                                    --PAT_PROVNOMBRE,
                                    --PAT_PROVCOD,
                                    --PAT_CANTNOM,
                                    --PAT_CANTCOD,
                                    --PAT_PARRNOM,
                                    --PAT_PARRCOD,
                                    PAT_TELF,
                                    PAT_NUM_RUC,
                                    --PAT_CODSUC,
                                    PAT_ESTADO_CONTA,
                                    --DIR_NUMERO,
                                    PAT_ACTIVIDAD,
                                    PAT_OBS2,
                                    PAT_RUC_CONTADOR)
                                    --PAT_JDE)
     VALUES ( :PAT_ID,
             :PAT_NUM_PATRONAL,
             :PAT_REP_LEGAL,
             :PAT_DIR,
             :PAT_RAZ_SOCIAL,
             --:PAT_FEC_CONST,
             --:PAT_FEC_LIQ,
             :PAT_OBS,
             :PAT_NOMBRE,
             :PAT_ESTADO,
             --:PAT_PROVNOMBRE,
             --:PAT_PROVCOD,
             --:PAT_CANTNOM,
             --:PAT_CANTCOD,
             --:PAT_PARRNOM,
             --:PAT_PARRCOD,
             :PAT_TELF,
             :PAT_NUM_RUC,
             --:PAT_CODSUC,
             :PAT_ESTADO_CONTA,
             --:DIR_NUMERO,
             :PAT_ACTIVIDAD,
             :PAT_OBS2,
             :PAT_RUC_CONTADOR)";
        //:PAT_JDE)";
        private static string sqlEmpresaCodigo = "SELECT NVL(MAX(PAT_ID),0)+1 FROM DESARROLLO.DAT_PATRONO";
        private static string sqlEmpresaUpdate = @"UPDATE DESARROLLO.DAT_PATRONO
                                                SET    PAT_NUM_PATRONAL = :PAT_NUM_PATRONAL,
                                                       PAT_REP_LEGAL    = :PAT_REP_LEGAL,
                                                       PAT_DIR          = :PAT_DIR,
                                                       PAT_RAZ_SOCIAL   = :PAT_RAZ_SOCIAL,
                                                       --PAT_FEC_CONST    = :PAT_FEC_CONST,
                                                       --PAT_FEC_LIQ      = :PAT_FEC_LIQ,
                                                       PAT_OBS          = :PAT_OBS,
                                                       PAT_NOMBRE       = :PAT_NOMBRE,
                                                       PAT_ESTADO       = :PAT_ESTADO,
                                                       --PAT_PROVNOMBRE   = :PAT_PROVNOMBRE,
                                                       --PAT_PROVCOD      = :PAT_PROVCOD,
                                                       --PAT_CANTNOM      = :PAT_CANTNOM,
                                                       --PAT_CANTCOD      = :PAT_CANTCOD,
                                                       --PAT_PARRNOM      = :PAT_PARRNOM,
                                                       --PAT_PARRCOD      = :PAT_PARRCOD,
                                                       PAT_TELF         = :PAT_TELF,
                                                       PAT_NUM_RUC      = :PAT_NUM_RUC,
                                                       --PAT_CODSUC       = :PAT_CODSUC,
                                                       PAT_ESTADO_CONTA = :PAT_ESTADO_CONTA,
                                                       --DIR_NUMERO       = :DIR_NUMERO,
                                                       PAT_ACTIVIDAD    = :PAT_ACTIVIDAD,
                                                       PAT_OBS2         = :PAT_OBS2,
                                                       PAT_RUC_CONTADOR = :PAT_RUC_CONTADOR
                                                       --PAT_JDE          = :PAT_JDE
                                                WHERE  PAT_ID           = :PAT_ID
                                                ";
        #endregion

        #region Instancia
        private static PatronoRepository _instancia;
        public static PatronoRepository Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new PatronoRepository();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }

        }

        private PatronoRepository()
        {
            db = ConnectionDDBB.Instancia;
        }
        #endregion

        private ConnectionDDBB db { get; set; }



        public int Delete(int empresaID)
        {
            OracleParameter[] rmp = new OracleParameter[]
                {                    
                    new OracleParameter(":PAT_ID", empresaID)
                };
            return db.ExecQuery(sqlEmpresaDelete, rmp);
        }

        public int AddNew(PatronoEntity empresa)
        {
            int pkCode = 0;
            OracleParameter[] rmp = new OracleParameter[]
                {
             new OracleParameter(":PAT_ID", pkCode=EmpresaGeneraCodigo()),
             new OracleParameter(":PAT_NUM_PATRONAL", empresa.PatronoNum),
             new OracleParameter(":PAT_REP_LEGAL", empresa.RepLegal),
             new OracleParameter(":PAT_DIR", empresa.Direccion),
             new OracleParameter(":PAT_RAZ_SOCIAL", empresa.RazonSocial),
             //new OracleParameter(":PAT_FEC_CONST", empresa.FechaConst),
             //new OracleParameter(":PAT_FEC_LIQ", empresa.FechaLiq),
             new OracleParameter(":PAT_OBS", empresa.Observacion),
             new OracleParameter(":PAT_NOMBRE", empresa.Nombre),
             new OracleParameter(":PAT_ESTADO", empresa.Estado),
             //new OracleParameter(":PAT_PROVNOMBRE", empresa.Provincia),
             //new OracleParameter(":PAT_PROVCOD", empresa.ProvinciaCod),
             //new OracleParameter(":PAT_CANTNOM", empresa.Direccion),
             //new OracleParameter(":PAT_CANTCOD", empresa.Direccion),
             //new OracleParameter(":PAT_PARRNOM", empresa.Direccion),
             //new OracleParameter(":PAT_PARRCOD", empresa.Direccion),
             new OracleParameter(":PAT_TELF", empresa.Telefono),
             new OracleParameter(":PAT_NUM_RUC", empresa.Ruc),
             //new OracleParameter(":PAT_CODSUC", empresa.Direccion),
             new OracleParameter(":PAT_ESTADO_CONTA", empresa.EstadoConta),
             //new OracleParameter(":DIR_NUMERO", empresa.),
             new OracleParameter(":PAT_ACTIVIDAD", empresa.Actividad),
             new OracleParameter(":PAT_OBS2", empresa.Observacion2),
             new OracleParameter(":PAT_RUC_CONTADOR", empresa.RucContador)
             //new OracleParameter(":PAT_JDE", empresa.PatJDE)
                };

            if (db.ExecQuery(sqlEmpresaInsert, rmp).Equals(1))
                return pkCode;
            else
                return 0;
            //return db.ExecQuery(sqlLocalInsert, rmp);

        }
        private int EmpresaGeneraCodigo()
        {
            return db.GetEntero(sqlEmpresaCodigo);
        }
        public int Update(PatronoEntity empresa)
        {
            //ConnectionDDBB db = new ConnectionDDBB();
            OracleParameter[] rmp = new OracleParameter[]
                {                    
             new OracleParameter(":PAT_NUM_PATRONAL", empresa.PatronoNum),
             new OracleParameter(":PAT_REP_LEGAL", empresa.RepLegal),
             new OracleParameter(":PAT_DIR", empresa.Direccion),
             new OracleParameter(":PAT_RAZ_SOCIAL", empresa.RazonSocial),
             //new OracleParameter(":PAT_FEC_CONST", empresa.FechaConst),
             //new OracleParameter(":PAT_FEC_LIQ", empresa.FechaLiq),
             new OracleParameter(":PAT_OBS", empresa.Observacion),
             new OracleParameter(":PAT_NOMBRE", empresa.Nombre),
             new OracleParameter(":PAT_ESTADO", empresa.Estado),
             //new OracleParameter(":PAT_PROVNOMBRE", empresa.Provincia),
             //new OracleParameter(":PAT_PROVCOD", empresa.ProvinciaCod),
             //new OracleParameter(":PAT_CANTNOM", empresa.Direccion),
             //new OracleParameter(":PAT_CANTCOD", empresa.Direccion),
             //new OracleParameter(":PAT_PARRNOM", empresa.Direccion),
             //new OracleParameter(":PAT_PARRCOD", empresa.Direccion),
             new OracleParameter(":PAT_TELF", empresa.Telefono),
             new OracleParameter(":PAT_NUM_RUC", empresa.Ruc),
             //new OracleParameter(":PAT_CODSUC", empresa.Direccion),
             new OracleParameter(":PAT_ESTADO_CONTA", empresa.EstadoConta),
             //new OracleParameter(":DIR_NUMERO", empresa.),
             new OracleParameter(":PAT_ACTIVIDAD", empresa.Actividad),
             new OracleParameter(":PAT_OBS2", empresa.Observacion2),
             new OracleParameter(":PAT_RUC_CONTADOR", empresa.RucContador),
             //new OracleParameter(":PAT_JDE", empresa.PatJDE)
             new OracleParameter(":PAT_ID", empresa.PatronoID)
                };

            if (db.ExecQuery(sqlEmpresaUpdate, rmp).Equals(1))
                return empresa.PatronoID;
            else
                return 0;
        }

        public DataTable Listar(string idEmpresa)
        {
            DataTable datos = new DataTable();
            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":idEmpresa", idEmpresa)
                };
            datos = db.GetData(sqlListaEmpresa, prm);
            return datos;
        }
        public DataTable Listar()
        {
            DataTable datos = new DataTable();
            datos = db.GetData(sqlListar);
            return datos;
        }

        //public List<PatronoEntity> Listar(string prm)
        //{
        //    List<PatronoEntity> lis = new List<PatronoEntity>();            
        //    var reader = db.ExecuteSelect(prm == "F"? sqlListarFiltro: sqlListar);
        //    while (reader.Read())
        //    {
        //        lis.Add(ConvertData(reader));
        //    }
        //    return lis;
        //}
        //private PatronoEntity ConvertData(IDataReader reader)
        //{
        //    PatronoEntity item = new PatronoEntity();
        //    item.PatronoID = Convert.ToInt32(reader["PAT_ID"]);
        //    item.RazonSocial = Convert.ToString(reader["PAT_RAZ_SOCIAL"]);
        //    item.Direccion = Convert.ToString(reader["PAT_DIR"]);
        //    item.Telefono = Convert.ToString(reader["PAT_TELF"]);
        //    item.RepLegal = Convert.ToString(reader["PAT_REP_LEGAL"]);
        //    item.Ruc = Convert.ToString(reader["PAT_NUM_RUC"]);
        //    item.Estado = Convert.ToInt32(reader["PAT_ESTADO"]);
        //    item.Observacion = Convert.ToString(reader["PAT_OBS"]);

        //    return item;
        //}

    }
}
