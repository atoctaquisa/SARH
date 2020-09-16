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
    public class ReportDataRepository
    {
        #region Properties
        private ConnectionDDBB db { get; set; }
        #endregion

        #region Instancia / Constructor
        private static ReportDataRepository _instancia;
        public static ReportDataRepository Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ReportDataRepository();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public ReportDataRepository()
        {
            db = ConnectionDDBB.Instancia;
        }
        #endregion

        private string sqlLiquidacion = @"SELECT e.emp_id, ESC_CARGOMB,
       NOMBRE,
       EMP_CI,
       LOC_NOMBRE,
       LIQ_FEC_ING,
       LIQ_FEC_SAL,
          TO_CHAR (LIQ_FEC_ING, 'DD')
       || ' de '
       || (SELECT MES_NOMBRE
             FROM DESARROLLO.dat_meses
            WHERE MES_ID = TO_CHAR (LIQ_FEC_ING, 'MM'))
       || ' del '
       || TO_CHAR (LIQ_FEC_ING, 'rrrr')    ingreso,
          TO_CHAR (LIQ_FEC_SAL, 'DD')
       || ' de '
       || (SELECT MES_NOMBRE
             FROM DESARROLLO.dat_meses
            WHERE MES_ID = TO_CHAR (LIQ_FEC_SAL, 'MM'))
       || ' del '
       || TO_CHAR (LIQ_FEC_SAL, 'rrrr')    salida
  FROM DESARROLLO.v_detalle_emp  e
       JOIN DESARROLLO.DAT_LIQ l ON (e.emp_id = l.emp_id)
 WHERE e.emp_id = :EMP_ID";
        private string sqlLiquidacionDT = @"SELECT IMP_LIQ_GRU_ID, IMP_LIQ_GRU_NOM, IMP_LIQ_SUB_ID, 
   IMP_LIQ_SUB_NOM, IMP_LIQ_DES, IMP_LIQ_VALOR, 
   trunc(IMP_LIQ_VALOR_AUX,2) FROM DESARROLLO.DAT_IMP_LIQ";

        private string sqlSolicitudVacacion = @"SELECT PATRONO, NOMBRE, CEDULA, ESC_CARGOMB, SOLVAC_ID, SOLVAC_DESDE, SOLVAC_HASTA,
                                                       PERIODO, DIAS, LAB_FEC_INGRESO, SOLVAC_FECHA 
                                                FROM DESARROLLO.V_SOLICITUD_VACACION WHERE EMP_ID=:EMP_ID AND SOLVAC_ID=:SOLVAC_ID";
        private string sqlActuarial = @"
                                        SELECT A.EMPRESA,
                                               A.NOMBRE,
                                               A.CEDULA,
                                               A.CARGO,
                                               A.SEXO,
                                               ROUND (A.SUELDO, 3)           SUELDO,
                                               ROUND (A.COMISIONES, 3)       COMISIONES,
                                               ROUND (A.HORAS_EXTRAS, 3)     HORAS_EXTRAS,
                                               ROUND (A.REMUNERACION, 3)     REMUNERACION,
                                               A.NACIMIENTO,
                                               I.INGRESO,
                                               I.SALIDA
                                          FROM DESARROLLO.ACTUARIAL_TMP  A
                                               JOIN DESARROLLO.ACTUARIAL_INGRESO_TMP I ON (A.CEDULA = I.CEDULA)";
        private string sqlGeneraRol = @"DESARROLLO.P_IMP_DAT_ROL_IND3";
        private string sqlListaRol = "SELECT DETALLE FROM DAT_ROL_IND";
        private string sqlPagoQuincena = @" SELECT 
                                            ROL_ID_GEN, ROL_REPRO, LOC_ID, 
                                               LOC_NOMBRE, EMP_ID, EMP_CI, 
                                               NOMBRE, CUENTA_ID, CUENTA_NOMBRE, 
                                               CUENTA_TIPO, CUENTA_VALOR, ORD_CUENTA, 
                                               PATRONO, PAT_ID, ESC_CARGOMB, 
                                               ESC_ID, LAB_ESTADO, EMP_FEC_SALIDA, 
                                               ESC_ABRE
                                            FROM DESARROLLO.VI_PAGO_PROPESEL
                                           WHERE    ROL_ID_GEN =:ROL_ID_GEN 
                                                AND PAT_ID LIKE ''||:PAT_ID||'%'
                                                AND LOC_ID LIKE ''||:LOC_ID||'%'
                                                AND EMP_CI LIKE ''||:EMP_CI||'%'
                                                 ";
        private string sqlDetalleContabilidad = @"SELECT 
                                               ROL_LOCAL, ROL_DIAS, ROL_NOMBRE, 
                                               ROL_CUENTA_IMP, ROL_VALOR, ROL_ORD, 
                                               ROL_ID_IMP, EMP_ID, ROL_ID_GEN, 
                                               ROL_REPRO, PATRONO, ROL_PAGADO, 
                                               LOC_CIUDAD, CARGO, PERIODO, 
                                               ESTADO, GRUPO, ESC_ID
                                            FROM DESARROLLO.DAT_IMP_ROL_EXC WHERE ROL_ID_GEN=:ROL_ID_GEN AND ROL_REPRO=:ROL_REPRO";

        private string sqlSueldoQuincena = "DESARROLLO.P_GEN_CUEN_SUELDO";
        private string sqlSueldoQuincenaTotal = "DESARROLLO.P_GEN_CUEN_SUELDO_TOT";
        private string sqlSueldoQuincenaGlobal = "DESARROLLO.P_GEN_CUEN_SUELDO_GT";

        public DataTable Actuarial(string nAnio)
        {
            //OracleParameter[] prm = new OracleParameter[] 
            //{ 
            //    new OracleParameter(":EMP_ID",empID ),
            //    new OracleParameter(":SOLVAC_ID",vacID)
            //};
            //return db.GetData(sqlSolicitudVacacion, prm);
            return db.GetData(sqlActuarial);
        }
        public DataTable SolicitudVacacion(string empID, string vacID)
        {
            OracleParameter[] prm = new OracleParameter[] 
            { 
                new OracleParameter(":EMP_ID",empID ),
                new OracleParameter(":SOLVAC_ID",vacID)
            };
            return db.GetData(sqlSolicitudVacacion, prm);
        }
        public DataTable Liquidacion(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID",empID )

            };
            //return db.GetData(sqlSolicitudVacacion, prm);
            return db.GetData(sqlLiquidacion,prm);
        }
        public DataTable LiquidacionDT(string empID, string vacID)
        {
            //OracleParameter[] prm = new OracleParameter[]
            //{
            //    new OracleParameter(":EMP_ID",empID ),
            //    new OracleParameter(":SOLVAC_ID",vacID)
            //};
            //return db.GetData(sqlSolicitudVacacion, prm);
            return db.GetData(sqlLiquidacionDT);
        }
        public DataTable DetalleContabilidad(string rolID, string reproID)
        {
            OracleParameter[] prm = new OracleParameter[] 
            { 
                new OracleParameter(":ROL_ID_GEN",rolID ),
                new OracleParameter(":ROL_REPRO",reproID )
            };
            return db.GetData(sqlDetalleContabilidad,prm);
        }
        public DataTable PagoQuincena(string rolID, string reproID, string patrono, string local, string empID)
        {
            
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID","200402001" ),
                new OracleParameter(":ROL_ID",rolID ),
                new OracleParameter(":REPRO_ID",reproID),
                new OracleParameter(":ESTADO_ID","2" )
            };
            db.ExecProcedure(sqlSueldoQuincena, prm);
            prm = new OracleParameter[]
            {
                new OracleParameter(":ESTADO_ID","2" )
            };
            db.ExecProcedure(sqlSueldoQuincenaTotal, prm);

            prm = new OracleParameter[]
            {
                new OracleParameter(":ESTADO_ID","2" ),
                new OracleParameter(":ROL_ID", rolID )
            };
            db.ExecProcedure(sqlSueldoQuincenaGlobal, prm);

            prm = new OracleParameter[] 
            { 
                new OracleParameter(":ROL_ID_GEN",rolID ),
                new OracleParameter(":PAT_ID",patrono ),
                new OracleParameter(":LOC_ID",local.Equals("0")?"": local),
                new OracleParameter(":EMP_CI",empID.Equals("0")?"": empID )
            };
            return db.GetData(sqlPagoQuincena,prm);
        }
        public DataTable RolIndividual(string rolID, string reproID, string empID, string localID, string cadenaID)
        {
            OracleParameter[] prm = new OracleParameter[] 
            { 
                new OracleParameter(":rolID",rolID ),
                new OracleParameter(":reproID",reproID ),
                new OracleParameter(":empID",empID.Equals("0")?"": empID ),
                new OracleParameter(":localID",localID.Equals("0")?"": localID),
                new OracleParameter(":ciudadlID",string.Empty ),
                new OracleParameter(":cadenaID",cadenaID)
            };
            db.ExecProcedure(sqlGeneraRol, prm);
            return db.GetData(sqlListaRol);
        }

    }
}
