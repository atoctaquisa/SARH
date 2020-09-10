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
    public class CuentaRepository
    {
        private static string sqlListaRol = "SELECT ROL_ID, ROL_CUENTA, ROL_SUBCUENTA, ROL_VARIABLE, ROL_ORD_IMP, ROL_ESTADO, ROL_FEC_MOD, ROL_FEC_CRE, ROL_TIP, ROL_APA_LOCAL, CUE_ID, CUE_COS_ID, GRU_VAR_ROL_ID, ROL_TIPO_CUENTA FROM DESARROLLO.VAR_ROL ORDER BY 2";
        private static string sqlGrupoCuenta = "SELECT GRU_VAR_ROL_ID, GRU_VAR_ROL_NOMBRE, FECHACREACION, FECHAMODIF FROM DESARROLLO.DAT_GRU_VAR_ROL ORDER BY 2";
        private static string sqlListaCuentas = "SELECT ROL_CUENTA || ' - ' || ROL_SUBCUENTA AS CUENTA, ROL_ID FROM desarrollo.var_rol WHERE ROL_TIPO_CUENTA = 1 AND ROL_ESTADO = 1 ORDER BY ROL_CUENTA, ROL_SUBCUENTA "; //ROL_SUBCUENTA || ' - ' || ROL_CUENTA
        private static string sqlListaCuenta = @"
                                                SELECT  ROL_CUENTA || ' - ' || ROL_SUBCUENTA AS CUENTA, ROL_ID
                                                    FROM DESARROLLO.VAR_ROL
                                                   WHERE     ROL_SUBCUENTA IS NOT NULL
                                                         AND ROL_ID BETWEEN 10001 AND 29999
                                                         AND ROL_ESTADO = 1
                                                ORDER BY CUENTA";
        private static string sqlListaCuentasPrestamo = "SELECT ROL_SUBCUENTA || ' - ' || ROL_CUENTA AS CUENTA, ROL_ID FROM desarrollo.var_rol WHERE ROL_TIPO_CUENTA = 1 AND ROL_ESTADO = 1 AND ROL_SUBCUENTA LIKE '%PREST%' ORDER BY ROL_CUENTA, ROL_SUBCUENTA ";
        private static string sqlProvisionRol = "SELECT ROL_ID, CUE_PROV_ID, PROV_ROL_ESTADO, PROV_ROL_TIPO, PROV_FECHACREACION, PROV_FECHAMODIF FROM DESARROLLO.DAT_PROVISION_ROL WHERE ROL_ID = :ROL_ID ";
        private static string sqlListaCuentaProvision = "SELECT CUE_PROV_NOMBRE,CUE_PROV_ID FROM DESARROLLO.DAT_CUENTA_PROVISION ";
        private static string sqlCuentaI = @"
                                            INSERT INTO DESARROLLO.VAR_ROL (ROL_ID,
                                                                    ROL_CUENTA,
                                                                    ROL_SUBCUENTA,
                                                                    ROL_VARIABLE,
                                                                    ROL_ORD_IMP,
                                                                    ROL_ESTADO,                                
                                                                    ROL_FEC_CRE,
                                                                    ROL_TIP,
                                                                    ROL_APA_LOCAL,
                                                                    CUE_ID,
                                                                    CUE_COS_ID,
                                                                    GRU_VAR_ROL_ID,
                                                                    ROL_TIPO_CUENTA)
                                         VALUES ( :ROL_ID
                                                 ,:ROL_CUENTA
                                                 ,:ROL_SUBCUENTA
                                                 ,:ROL_VARIABLE
                                                 ,:ROL_ORD_IMP
                                                 ,:ROL_ESTADO             
                                                 ,SYSDATE
                                                 ,:ROL_TIP
                                                 ,:ROL_APA_LOCAL
                                                 ,:CUE_ID
                                                 ,:CUE_COS_ID
                                                 ,:GRU_VAR_ROL_ID
			                                     ,:ROL_TIPO_CUENTA
                                                 )";
        private static string sqlCuentaU = @"
                                            UPDATE DESARROLLO.VAR_ROL
                                               SET ROL_CUENTA = :ROL_CUENTA,
                                                   ROL_SUBCUENTA = :ROL_SUBCUENTA,
                                                   ROL_VARIABLE = :ROL_VARIABLE,
                                                   ROL_ORD_IMP = :ROL_ORD_IMP,
                                                   ROL_ESTADO = :ROL_ESTADO,
                                                   ROL_FEC_MOD = SYSDATE,               
                                                   ROL_TIP = :ROL_TIP,
                                                   ROL_APA_LOCAL = :ROL_APA_LOCAL,
                                                   CUE_ID = :CUE_ID,
                                                   CUE_COS_ID = :CUE_COS_ID,
                                                   GRU_VAR_ROL_ID = :GRU_VAR_ROL_ID,
                                                   ROL_TIPO_CUENTA = :ROL_TIPO_CUENTA
                                             WHERE ROL_ID = :ROL_ID";
        private static string sqlProvisionI = @"
                                                INSERT INTO DESARROLLO.DAT_PROVISION_ROL (ROL_ID,
                                                                                          CUE_PROV_ID,
                                                                                          PROV_ROL_ESTADO,
                                                                                          PROV_ROL_TIPO,
                                                                                          PROV_FECHACREACION
                                                                                          )
                                                     VALUES (:ROL_ID
                                                             ,:CUE_PROV_ID
                                                             ,:PROV_ROL_ESTADO
                                                             ,:PROV_ROL_TIPO
                                                             ,SYSDATE             
                                                             )";
        private static string sqlProvisionU = @"
                                                UPDATE DESARROLLO.DAT_PROVISION_ROL
                                                   SET CUE_PROV_ID = :CUE_PROV_ID,
                                                       PROV_ROL_ESTADO = :PROV_ROL_ESTADO,
                                                       PROV_ROL_TIPO = :PROV_ROL_TIPO,                                                       
                                                       PROV_FECHAMODIF = SYSDATE
                                                 WHERE ROL_ID = :ROL_ID AND CUE_PROV_ID = :CUE_PROV_ID";
        private static string sqlGrupoCuentaI = @"INSERT INTO DESARROLLO.DAT_GRU_VAR_ROL (GRU_VAR_ROL_ID, GRU_VAR_ROL_NOMBRE, FECHACREACION )
                                                  VALUES ( :GRU_VAR_ROL_ID, :GRU_VAR_ROL_NOMBRE, SYSDATE)";
        private static string sqlGrupoCuentaU = @"UPDATE DESARROLLO.DAT_GRU_VAR_ROL
                                                   SET GRU_VAR_ROL_NOMBRE = :GRU_VAR_ROL_NOMBRE,                                                       
                                                       FECHAMODIF = SYSDATE
                                                 WHERE GRU_VAR_ROL_ID = :GRU_VAR_ROL_ID";

        private ConnectionDDBB db { get; set; }

        #region Instancia / Constructor
        private static CuentaRepository _instancia;
        public static CuentaRepository Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CuentaRepository();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public CuentaRepository()
        {
            db = ConnectionDDBB.Instancia;
        }
        #endregion

        public int RegistraGrupoCuenta(Int32 idGrupo, string nombreGrupo, string tipoSQL)
        {
            int pkCode = 0;
            if (tipoSQL.Equals("I"))
            {
                OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":GRU_VAR_ROL_ID", idGrupo ),
               new OracleParameter(":GRU_VAR_ROL_NOMBRE", nombreGrupo)
               };

                if (!db.ExecQuery(sqlGrupoCuentaI, prm).Equals(1))
                    pkCode = 0;
            }
            else
            {
                OracleParameter[] prm = new OracleParameter[]{               
               new OracleParameter(":GRU_VAR_ROL_NOMBRE", nombreGrupo),
               new OracleParameter(":GRU_VAR_ROL_ID", idGrupo )
               };

                if (!db.ExecQuery(sqlGrupoCuentaU, prm).Equals(1))
                    pkCode = 0;

            }

            return pkCode;
        }

        public int RegistraProvision(DatProvisionRol provision, string tipoSQL)
        {
            int pkCode = 0;
            if (tipoSQL.Equals("I"))
            {
                OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":ROL_ID", provision.rolId ),
               new OracleParameter(":CUE_PROV_ID", provision.cueProvId),
               new OracleParameter(":PROV_ROL_ESTADO", provision.provRolEstado),
               new OracleParameter(":PROV_ROL_TIPO", 1)               
               };

                if (!db.ExecQuery(sqlProvisionI, prm).Equals(1))
                    pkCode = 0;
            }
            else
            {
                OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":CUE_PROV_ID", provision.cueProvId),
               new OracleParameter(":PROV_ROL_ESTADO", provision.provRolEstado),
               new OracleParameter(":PROV_ROL_TIPO", 1),
               new OracleParameter(":ROL_ID", provision.rolId),
               new OracleParameter(":CUE_PROV_ID", provision.cueProvId_Temp)
               };

                if (!db.ExecQuery(sqlProvisionU, prm).Equals(1))
                    pkCode = 0;

            }

            return pkCode;
        }
        public int RegistraCuenta(RolEntity rol, string tipoSQL)
        {
            int pkCode = 0;
            if (tipoSQL.Equals("I"))
            {
                OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":ROL_ID", rol.RodID),
               new OracleParameter(":ROL_CUENTA", rol.Cuenta),
               new OracleParameter(":ROL_SUBCUENTA", rol.SubCuenta),
               new OracleParameter(":ROL_VARIABLE", rol.Cuenta.Substring(0,3)+rol.SubCuenta.Substring(0,3)),
               new OracleParameter(":ROL_ORD_IMP", rol.OrdImp),
               new OracleParameter(":ROL_ESTADO", rol.Estado ),
               new OracleParameter(":ROL_TIP", null),
               new OracleParameter(":ROL_APA_LOCAL", rol.RolLocal),
               new OracleParameter(":CUE_ID", null),
               new OracleParameter(":CUE_COS_ID",null ),
               new OracleParameter(":GRU_VAR_ROL_ID", rol.GrupoRolID),
               new OracleParameter(":ROL_TIPO_CUENTA", 1)
               };

                if (!db.ExecQuery(sqlCuentaI, prm).Equals(1))
                    pkCode = 0;
            }
            else
            {
                OracleParameter[] prm = new OracleParameter[]{              
               new OracleParameter(":ROL_CUENTA", rol.Cuenta),
               new OracleParameter(":ROL_SUBCUENTA", rol.SubCuenta),
               new OracleParameter(":ROL_VARIABLE", rol.Cuenta.Substring(0,3)+rol.SubCuenta.Substring(0,3)),
               new OracleParameter(":ROL_ORD_IMP", rol.OrdImp),
               new OracleParameter(":ROL_ESTADO", rol.Estado ),
               new OracleParameter(":ROL_TIP", null),
               new OracleParameter(":ROL_APA_LOCAL", rol.RolLocal),
               new OracleParameter(":CUE_ID", null),
               new OracleParameter(":CUE_COS_ID", null),
               new OracleParameter(":GRU_VAR_ROL_ID", rol.GrupoRolID),
               new OracleParameter(":ROL_TIPO_CUENTA", 1),
                new OracleParameter(":ROL_ID", rol.RodID),
               };

                if (!db.ExecQuery(sqlCuentaU, prm).Equals(1))
                    pkCode = 0;

            }

            return pkCode;
        }



        public DataTable ListaCuentaProvision()
        {
            return db.GetData(sqlListaCuentaProvision);
        }
        public DataTable ListaCuenta()
        {
            return db.GetData(sqlListaCuenta);
        }
        public DataTable ListaCuentas()
        {
            return db.GetData(sqlListaCuentas);
        }
        public DataTable ListaCuentas(string[] param)
        {
            string sql = string.Empty;

            if (param[0].Equals("Prestamo"))
                sql = sqlListaCuentasPrestamo;

            if (param[0].Equals("ValorGrupo"))
                sql = sqlListaCuentas;
            
            return db.GetData(sql);
        }
        public DataTable ListaProvisionRol(int rolID)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":ROL_ID", rolID)
            };
            return db.GetData(sqlProvisionRol, prm);
        }
        public DataTable ListaCuentaIO()
        {
            return db.GetData(sqlListaRol);
        }

        public DataTable ListaGrupoCuentas()
        {
            return db.GetData(sqlGrupoCuenta);
        }

        public List<GrupoCuentaEntity> ListaGrupoCuenta()
        {
            List<GrupoCuentaEntity> lis = new List<GrupoCuentaEntity>();
            var reader = db.ExecuteSelect(sqlGrupoCuenta);
            while (reader.Read())
            {
                lis.Add(ConvertGrupoCuenta(reader));
            }
            return lis;
        }
        private GrupoCuentaEntity ConvertGrupoCuenta(IDataReader reader)
        {
            GrupoCuentaEntity item = new GrupoCuentaEntity();
            item.GrupoCuentaID = Convert.ToInt32(reader["GRU_VAR_ROL_ID"]);
            item.Nombre = Convert.ToString(reader["GRU_VAR_ROL_NOMBRE"]);
            item.FechaCrea = Convert.ToDateTime(reader["FECHACREACION"]);
            item.FechaMod = Convert.ToDateTime(reader["FECHAMODIF"]);


            return item;
        }

        public List<RolEntity> ListaContratoFin()
        {
            List<RolEntity> lis = new List<RolEntity>();
            var reader = db.ExecuteSelect(sqlListaRol);
            while (reader.Read())
            {
                lis.Add(ConvertContratoFin(reader));
            }
            return lis;
        }
        private RolEntity ConvertContratoFin(IDataReader reader)
        {
            RolEntity item = new RolEntity();
            item.RodID = Convert.ToInt32(reader["ROL_ID"]);
            item.Cuenta = Convert.ToString(reader["ROL_CUENTA"]);
            item.SubCuenta = Convert.ToString(reader["ROL_SUBCUENTA"]);
            item.Variable = Convert.ToString(reader["ROL_VARIABLE"]);
            item.OrdImp = Convert.ToInt32(reader["ROL_ORD_IMP"]);
            item.Estado = Convert.ToInt32(reader["ROL_ESTADO"]);
            item.TipoCuenta = Convert.ToInt32(reader["ROL_TIPO_CUENTA"]);

            return item;
        }
    }
}
