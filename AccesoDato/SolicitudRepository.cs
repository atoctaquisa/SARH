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
    public class SolicitudRepository
    {
        #region Variables
        private static string sqlListaPermisoTipo = "SELECT TIP_ID, TIP_NOMBRE, TIP_OBS, TIP_TIPO FROM DESARROLLO.DAT_TIP_PER";
        private static string sqlListaSolicitudVacacion = @"SELECT SOLVAC_ID,
                                                               EMP_ID,
                                                               NOMBRE,
                                                               ESC_CARGOMB,
                                                               V.LOC_ID,
                                                               V.CLI_ID,
                                                               LOC_NOMBRE,
                                                               SOLVAC_FECHA,
                                                               PERIODO,
                                                               SOLVAC_DESDE,
                                                               SOLVAC_HASTA,
                                                               SOLVAC_INCORPORACION,
                                                               DIAS_PEND,
                                                               SOLVAC_OBSERVACION,
                                                               SOLVAC_ESTADO,
                                                               DECODE (SOLVAC_ESTADO,
                                                                       0, 'GENERADO',
                                                                       1, 'PENDIENTE',
                                                                       2, 'APROBADO',
                                                                       3, 'PROCESADO',
                                                                       4, 'NEGADO')
                                                                   ESTADO,
                                                               SOLVAC_RRHH,
                                                               CLI_RESPONSABLE,
                                                               CAB_VAC_ID,
                                                               DIAS
                                                          FROM DESARROLLO.V_SOLICITUD_VACACION  V
                                                               JOIN DAT_CLIENTE C ON (V.CLI_ID = C.CLI_ID)";
        private static string sqlRegistraSolicitud = "DESARROLLO.PK_OPERACIONESTCG.P_CARGA_SOLICITUD_VACACION";
        private static string sqlApruebaSolicitud = "DESARROLLO.PK_NOMINATCG.P_SOLICITUD_VACACION_AUT";
        private static string sqlAnulaSolicitud = "UPDATE DESARROLLO.DAT_SOLIC_VACACION SET SOLVAC_ESTADO=4 WHERE SOLVAC_ID=:SOLVAC_ID";
        private static string sqlVerificaDia = "SELECT CAB_VAC_DIAS_PEN FROM DESARROLLO.DAT_CAB_VAC WHERE EMP_ID =:EMP_ID AND CAB_VAC_ID =:CAB_VAC_ID";
        private static string sqlVerificaSolicitud = "SELECT COUNT(1) FROM V_SOLICITUD_VACACION WHERE EMP_ID=:EMP_ID AND CAB_VAC_ID=:CAB_VAC_ID AND SOLVAC_ESTADO IN(0,1)";
        private static string sqlSolicitudEmp = " WHERE EMP_ID=:EMP_ID AND CAB_VAC_ID=:CAB_VAC_ID ORDER BY SOLVAC_ID DESC";
        private static string sqlNumeroSolicitud = "SELECT SEQ_SOLICITUD_VACACION.CURRVAL FROM DUAL";
        private static string sqlListaTipoAccMatEnf = @"SELECT IESS_TIPO, IESS_DESC FROM DESARROLLO.DAT_IESS_TIPO";
        private static string sqlListaPorcentajeAccMatEnf = @"
                                                                SELECT CAT_ID,
                                                                       CAT_NOMBRE,
                                                                       CAT_VALOR,
                                                                       CAT_DESC
                                                                  FROM DESARROLLO.DAT_CATALOGO
                                                                 WHERE CAT_NOMBRE = 'PorcentajaIESS'";
        private static string sqlListaSolicitudAccMatEnf = @"
                                                            SELECT (SELECT NOMBRE FROM V_DETALLE_EMP WHERE EMP_ID =D.EMP_ID) NOMBRE,
                                                                   EMP_ID, (ROL_ID_GEN ||' - ' || ROL_REPRO) PROCESO,
                                                                   ROL_ID_GEN,
                                                                   ROL_REPRO,
                                                                   IESS_FECHAINICIO,
                                                                   IESS_FECHAFIN,
                                                                   IESS_FECHAINGRESO,
                                                                   (IESS_FECHAFIN - IESS_FECHAINICIO)+1 DIAS,
                                                                   IESS_FECHAMODIF,
                                                                   IESS_TIPO,
                                                                   IESS_OBSERVACION,
                                                                   DIAS_25,
                                                                   DIAS_100
                                                              FROM DESARROLLO.DAT_IESS_ENFERMEDAD D
                                                             WHERE EMP_ID =:EMP_ID ORDER BY ROL_ID_GEN, ROL_REPRO ASC";
private static string sqlListaAccMatEnf = @"
                                                            SELECT DISTINCT (SELECT NOMBRE FROM V_DETALLE_EMP WHERE EMP_ID =D.EMP_ID) NOMBRE,
                                                                   EMP_ID
                                                              FROM DESARROLLO.DAT_IESS_ENFERMEDAD D";
private static string sqlListaDiaAccMatEnf = @"
                                           SELECT DIA_ID,
                                               EMP_ID,
                                               ROL_ID_GEN,
                                               ROL_REPRO,
                                               DIA_NUM,
                                               DIA_PORC
                                          FROM DESARROLLO.DAT_IESS_DIA_ENFE
                                         WHERE EMP_ID = :EMP_ID AND ROL_ID_GEN = :ROL_ID_GEN AND ROL_REPRO=:ROL_REPRO";
private static string sqlRegistraSolicitudAccMatEnf = @"
                                                    INSERT INTO DESARROLLO.DAT_IESS_ENFERMEDAD (EMP_ID,
                                                                                                ROL_ID_GEN,
                                                                                                ROL_REPRO,
                                                                                                IESS_FECHAINICIO,
                                                                                                IESS_FECHAFIN,
                                                                                                IESS_FECHAINGRESO,
                                                                                                --IESS_FECHAMODIF,
                                                                                                IESS_TIPO,
                                                                                                IESS_OBSERVACION
                                                                                                )
                                                         VALUES ( :EMP_ID
                                                                 ,:ROL_ID_GEN
                                                                 ,:ROL_REPRO
                                                                 ,:IESS_FECHAINICIO
                                                                 ,:IESS_FECHAFIN
                                                                 ,SYSDATE --:IESS_FECHAINGRESO
                                                                 --,:IESS_FECHAMODIF
                                                                 ,:IESS_TIPO
                                                                 ,:IESS_OBSERVACION             
                                                                 )";
private static string sqlRegistraDiaAccMatEnf = @"
                                                INSERT INTO DESARROLLO.DAT_IESS_DIA_ENFE (DIA_ID,
                                                                                          EMP_ID,
                                                                                          ROL_ID_GEN,
                                                                                          ROL_REPRO,
                                                                                          DIA_NUM,
                                                                                          DIA_PORC)
                                                     VALUES ( SEQ_DAT_IESS_DIA_ENFE.NEXTVAL--:DIA_ID
                                                             ,:EMP_ID
                                                             ,:ROL_ID_GEN
                                                             ,:ROL_REPRO
                                                             ,:DIA_NUM
                                                             ,:DIA_PORC
                                                             )";
private static string sqlActualizaSolicitudAccMatEnf = @"
                                                    UPDATE DESARROLLO.DAT_IESS_ENFERMEDAD
                                                       SET IESS_FECHAINICIO = :IESS_FECHAINICIO,
                                                           IESS_FECHAFIN = :IESS_FECHAFIN,
                                                           --IESS_FECHAINGRESO = :IESS_FECHAINGRESO,
                                                           IESS_FECHAMODIF = SYSDATE,--:IESS_FECHAMODIF,
                                                           IESS_TIPO = :IESS_TIPO,
                                                           IESS_OBSERVACION = :IESS_OBSERVACION
                                                     WHERE     EMP_ID = :EMP_ID
                                                           AND ROL_ID_GEN = :ROL_ID_GEN
                                                           AND ROL_REPRO = :ROL_REPRO";
private static string sqlActualizaDiaAccMatEnf = @"
                                                    UPDATE DESARROLLO.DAT_IESS_DIA_ENFE
                                                       SET DIA_NUM = :DIA_NUM,
                                                           DIA_PORC = :DIA_PORC
                                                    WHERE  DIA_ID = :DIA_ID
                                                      AND  EMP_ID = :EMP_ID
                                                      AND  ROL_ID_GEN = :ROL_ID_GEN
                                                      AND  ROL_REPRO = :ROL_REPRO";
        #endregion

        #region Properties
        private ConnectionDDBB db { get; set; }
        #endregion

        #region Instancia / Constructor
        private static SolicitudRepository _instancia;
        public static SolicitudRepository Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SolicitudRepository();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public SolicitudRepository()
        {
            db = ConnectionDDBB.Instancia;
        }
        #endregion

        #region Methods
        public int RegistraSolicitud(int cliID, string fechaIni, string fechaFin, string fechaInc, string obs, string emp_id, string emp_ad, int idVac, string fechaAnio, int diaPendiente, double valor)
        {
            OracleParameter[] prm = new OracleParameter[] 
            {
                new OracleParameter("P_EMP_ID",OracleDbType.Int64){Value = Convert.ToInt64( emp_id)},
                new OracleParameter("P_ESTADO",OracleDbType.Int64){Value = 0},
                new OracleParameter("P_ANIO",OracleDbType.Varchar2){Value = fechaAnio}, //fechaAnio),
                new OracleParameter("P_FECHAD",OracleDbType.Date ){Value = Convert.ToDateTime(fechaIni).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))},//DateTime.Now), //Convert.ToDateTime(fechaIni).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))),
                new OracleParameter("P_FECHAH",OracleDbType.Date){Value = Convert.ToDateTime(fechaFin).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))},//DateTime.Now),//Convert.ToDateTime(fechaFin).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))),
                new OracleParameter("P_OBSR",OracleDbType.Varchar2){Value = obs},//obs),
                new OracleParameter("P_CLI_ID",OracleDbType.Int32 ){Value = cliID},//cliID),
                new OracleParameter("P_FECHAI",OracleDbType.Date){Value = Convert.ToDateTime(fechaInc).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))},//DateTime.Now),//Convert.ToDateTime(fechaInc).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))),
                new OracleParameter("P_RESADM",OracleDbType.Int64){Value = emp_ad},//emp_ad),
                new OracleParameter("P_CAB_VAC_ID",OracleDbType.Int32){Value = idVac},//idVac),
                new OracleParameter("P_DIA",OracleDbType.Int16 ){Value = diaPendiente},//diaPendiente),
                new OracleParameter("P_VALOR",OracleDbType.Decimal){Value = valor}//valor)
            };
            
            if (db.ExecProcedure(sqlRegistraSolicitud, prm)==1)
                return db.GetEntero(sqlNumeroSolicitud);
            else
                return 0;
        }

        public int VerificaSolicitud(string empID, int perID)
        {
            OracleParameter[] prm = new OracleParameter[] 
            { 
                new OracleParameter(":EMP_ID",empID ),
                new OracleParameter(":CAB_VAC_ID",perID)
            };
            return db.GetEntero(sqlVerificaSolicitud, prm);
        }

        public int VerificaDiasVacacion(string empID, int perID)
        {
            OracleParameter[] prm = new OracleParameter[] 
            { 
                new OracleParameter(":EMP_ID",empID ),
                new OracleParameter(":CAB_VAC_ID",perID)
            };
            return db.GetEntero(sqlVerificaDia, prm);
        }
        public int ApruebaSolicitud(string empID, string cabVacID, string obsr)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter("P_EMP_ID",empID),
                new OracleParameter("P_VAC_ID",cabVacID),
                new OracleParameter("P_OBSR",obsr)
            };
            return db.ExecProcedure(sqlApruebaSolicitud, prm);
        }
        public int AnulaSolicitud(Int32 cabVacID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":SOLVAC_ID",cabVacID)                
            };
            return db.ExecQuery(sqlAnulaSolicitud, prm);
        }
        public DataTable ListaPorcentajeAccMatEnf()
        {

            return db.GetData(sqlListaPorcentajeAccMatEnf);
        }
        public DataTable ListaTipoAccMatEnf()
        {
            
            return db.GetData(sqlListaTipoAccMatEnf);
        }
        public DataTable ListaSolicitudAccMatEnf()
        {
            
            return db.GetData(sqlListaAccMatEnf);
        }
        public DataTable ListaSolicitudAccMatEnf(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID",empID)
                
            };
            return db.GetData(sqlListaSolicitudAccMatEnf, prm);
        }
        public DataTable ListaDiaAccMatEnf(string empID, string rolID,string reproID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID",empID),
                new OracleParameter(":ROL_ID_GEN",rolID ),
                new OracleParameter(":ROL_REPRO",reproID)
                
            };
            return db.GetData(sqlListaDiaAccMatEnf, prm);
        }
        public int RegistraSolicitudAccMatEnf(List<DatIessEnfermedad> notifica, List<DatIessDiaEnfe> dia, string tipoID)
        {
            if (tipoID.Equals("I"))
            {
                foreach (var item in notifica)
                {
                    OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":EMP_ID",item.empId),
                    new OracleParameter(":ROL_ID_GEN",item.rolIdGen),
                    new OracleParameter(":ROL_REPRO",item.rolRepro),
                    new OracleParameter(":IESS_FECHAINICIO", Convert.ToDateTime(item.iessFechainicio).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))),
                    new OracleParameter(":IESS_FECHAFIN",Convert.ToDateTime(item.iessFechafin).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))),
                    new OracleParameter(":IESS_TIPO",item.iessTipo),
                    new OracleParameter(":IESS_OBSERVACION",item.iessObservacion)
                };
                    db.ExecQuery(sqlRegistraSolicitudAccMatEnf, prm);
                }

                foreach (var item in dia)
                {
                    OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":EMP_ID",item.empId),
                    new OracleParameter(":ROL_ID_GEN",item.rolIdGen),
                    new OracleParameter(":ROL_REPRO",item.rolRepro),
                    new OracleParameter(":DIA_NUM",item.diaNum),
                    new OracleParameter(":DIA_PORC",item.diaPorc)
                };
                    db.ExecQuery(sqlRegistraDiaAccMatEnf, prm);
                }
            }
            else
            {
                foreach (var item in notifica)
                {
                    OracleParameter[] prm = new OracleParameter[]
                {
                    
                    new OracleParameter(":IESS_FECHAINICIO", Convert.ToDateTime(item.iessFechainicio).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))),
                    new OracleParameter(":IESS_FECHAFIN",Convert.ToDateTime(item.iessFechafin).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))),
                    new OracleParameter(":IESS_TIPO",item.iessTipo),
                    new OracleParameter(":IESS_OBSERVACION",item.iessObservacion),
                    new OracleParameter(":EMP_ID",item.empId),
                    new OracleParameter(":ROL_ID_GEN",item.rolIdGen),
                    new OracleParameter(":ROL_REPRO",item.rolRepro)

                };
                    db.ExecQuery(sqlActualizaSolicitudAccMatEnf, prm);
                }

                foreach (var item in dia)
                {
                    OracleParameter[] prm = new OracleParameter[]
                {                   
                    new OracleParameter(":DIA_NUM",item.diaNum),
                    new OracleParameter(":DIA_PORC",item.diaPorc),
                    new OracleParameter(":DIA_ID",item.diaId),
                    new OracleParameter(":EMP_ID",item.empId),
                    new OracleParameter(":ROL_ID_GEN",item.rolIdGen),
                    new OracleParameter(":ROL_REPRO",item.rolRepro)
                };
                    db.ExecQuery(sqlActualizaDiaAccMatEnf, prm);
                }

            }

            return 1;
        }
        public DataTable ListaSolicitudVacacion(string empID, string perID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID",empID),                
                new OracleParameter(":CAB_VAC_ID",perID)
            };
            return db.GetData(sqlListaSolicitudVacacion+ sqlSolicitudEmp, prm); 
        }
        public DataTable ListaSolicitudVacacion(string codigo, int estado, string empID, string fechaD, string fechaH)
        {
            string sql = "WHERE ";

            if (estado >= 0)
                sql += "SOLVAC_ESTADO =" + estado;
            else
                sql += "SOLVAC_ESTADO >=" + estado;

            if (codigo != string.Empty)
                sql += " AND SOLVAC_ID='" + codigo + "'";

            if (Convert.ToInt64(empID) > 0)
                sql += " AND EMP_ID='" + empID + "'";

            if (fechaD != "1/1/0001 0:00:00")
            {
                if (fechaH != "1/1/0001 0:00:00")
                    sql += " AND TRUNC(SOLVAC_FECHA) BETWEEN '" + Convert.ToDateTime(fechaD).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) + "' AND '" + Convert.ToDateTime(fechaH).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) + "' ";
                else
                    sql += " AND TRUNC(SOLVAC_FECHA) BETWEEN '" + Convert.ToDateTime(fechaD).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) + "' AND TRUNC(SYSDATE) ";
            }
            else
            {
                if (fechaH != "1/1/0001 0:00:00")
                    sql += " AND TRUNC(SOLVAC_FECHA)='" + Convert.ToDateTime(fechaH).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) + "'";
            }




            return db.GetData(sqlListaSolicitudVacacion + sql + " ORDER BY SOLVAC_ID ASC");
        }

        public List<PermisoTipoEntity> ListaPermisoTipo()
        {
            List<PermisoTipoEntity> lis = new List<PermisoTipoEntity>();
            var reader = db.ExecuteSelect(sqlListaPermisoTipo);
            while (reader.Read())
            {
                lis.Add(ConvertPermisoTipo(reader));
            }
            return lis;
        }
        private PermisoTipoEntity ConvertPermisoTipo(IDataReader reader)
        {
            PermisoTipoEntity item = new PermisoTipoEntity();
            item.PermisoTipoID = Convert.ToInt32(reader["TIP_ID"]);
            item.Nombre = Convert.ToString(reader["TIP_NOMBRE"]);
            item.Observacion = Convert.ToString(reader["TIP_OBS"]);
            item.Tipo = Convert.ToInt32(reader["TIP_TIPO"]);

            return item;
        }
        #endregion
    }
}
