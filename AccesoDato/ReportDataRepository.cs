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
                                                   IMP_LIQ_SUB_NOM, IMP_LIQ_DES, trunc(IMP_LIQ_VALOR,2)IMP_LIQ_VALOR, 
                                                   trunc(IMP_LIQ_VALOR_AUX,2) FROM DESARROLLO.DAT_IMP_LIQ";
        private string sqlLiquidacionReport = "DESARROLLO.P_IMP_LIQ";

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
        private string sqlListaRol = "SELECT  DISTINCT IND_ID, DETALLE, IND_COL FROM DAT_ROL_IND ORDER BY IND_ID ";
        private string sqlListaRolSub = "SELECT DISTINCT IND_ID, DETALLE, IND_COL FROM DAT_ROL_IND where IND_ID=:IND_ID";
        //private string sqlPrestamoDT = @"SELECT PRESTAMO,
        //                                       DESCRIPCION,
        //                                       NOMBRE,
        //                                       PRES_VALOR,
        //                                       PAGO,
        //                                       PRES_ESTADO,
        //                                       MES_DESCUENTO,
        //                                       MES_INICIO,
        //                                       PATRONO,PRES_PLAZO,
        //                                       PAT_ID
        //                                  FROM (  SELECT                                              --*--MES_DESCUENTO
        //                                                 'Prestamo: $' || PRES_VALOR || ' Cuotas: ' || PRES_PLAZO
        //                                                     PRESTAMO,
        //                                                    'Cuenta: '
        //                                                 || ROL_SUBCUENTA
        //                                                 || ' Observación: '
        //                                                 || PRES_OBSERVACION
        //                                                     DESCRIPCION,
        //                                                 NOMBRE,
        //                                                 PRES_VALOR,
        //                                                 DECODE (PRES_ESTADO,  0, 'PAGADO',  1, 'PENDIENTE')
        //                                                     PRES_ESTADO,
        //                                                 MES_DESCUENTO,
        //                                                 DET_PRES_ROL,
        //                                                 MES_INICIO,
        //                                                 ROUND (DET_PRES_VALOR, 3)
        //                                                     PAGO,
        //                                                 PATRONO,PRES_PLAZO,
        //                                                 PAT_ID,EMP_ID
        //                                            FROM DESARROLLO.V_DET_PRESTAMOS
        //                                           WHERE     ROL_ID_GEN IN (SELECT DISTINCT ROL_ID_GEN
        //                                                                      FROM DESARROLLO.V_DET_PRESTAMOS
        //                                                                     WHERE DET_PRES_ROL = :PER_ID)
        //                                                 AND EMP_ID IN (SELECT DISTINCT EMP_ID
        //                                                                  FROM DESARROLLO.V_DET_PRESTAMOS
        //                                                                 WHERE DET_PRES_ROL = :PER_ID)
        //                                        GROUP BY PATRONO,
        //                                                 NOMBRE,
        //                                                 PRES_VALOR,
        //                                                 PRES_PLAZO,
        //                                                 ROL_SUBCUENTA,
        //                                                 PRES_OBSERVACION,
        //                                                 PRES_ESTADO,
        //                                                 MES_DESCUENTO,
        //                                                 DET_PRES_ROL,
        //                                                 MES_INICIO,
        //                                                 DET_PRES_VALOR,
        //                                                 PAT_ID,EMP_ID
        //                                                 ORDER BY 1,2,3,7) ";
        private string sqlPrestamoDT = @"SELECT PRESTAMO,
                                               DESCRIPCION,
                                               NOMBRE,
                                               PRES_VALOR,
                                               PAGO,
                                               PRES_ESTADO,
                                               MES_DESCUENTO,
                                               MES_INICIO,
                                               PATRONO,PRES_PLAZO,
                                               PAT_ID
                                          FROM (  SELECT                                              --*--MES_DESCUENTO
                                                         'Prestamo: $' || PRES_VALOR || ' Cuotas: ' || PRES_PLAZO
                                                             PRESTAMO,
                                                            /*'Cuenta: '
                                                         || ROL_SUBCUENTA
                                                         || ' Observación: '
                                                         ||*/ PRES_OBSERVACION
                                                             DESCRIPCION,
                                                         NOMBRE,
                                                         PRES_VALOR,
                                                         DECODE (DESARROLLO.F_VER_EST_PRESTAMO (EMP_ID,
                                                        ROL_ID,
                                                        ROL_ID_GEN,
                                                        ROL_REPRO,
                                                        PRES_PLAZO),
                         0, 'PAGADO',
                         1, 'PENDIENTE')
                     PRES_ESTADO,
                                                         MES_DESCUENTO,
                                                         DET_PRES_ROL,
                                                         MES_INICIO,
                                                         ROUND (DET_PRES_VALOR, 3)
                                                             PAGO,
                                                         PATRONO,PRES_PLAZO,
                                                         PAT_ID,EMP_ID,ROL_ID_GEN
                                                    FROM DESARROLLO.V_DET_PRESTAMOS)
                                                    WHERE PAT_ID>0
                                                   ";
        //private string sqlPrestamo = @" SELECT PRESTAMO,
        //                                       DESCRIPCION,
        //                                       PRES_PLAZO,
        //                                       NOMBRE,
        //                                       PRES_VALOR - PAGO     PENDIENTE,
        //                                       PRES_VALOR,
        //                                       PRES_ESTADO,
        //                                       PATRONO,
        //                                       PAT_ID
        //                                  FROM (  SELECT 'Prestamo: $' || PRES_VALOR || ' Cuotas: ' || PRES_PLAZO
        //                                                     PRESTAMO,
        //                                                    'Cuenta: '
        //                                                 || ROL_SUBCUENTA
        //                                                 || ' Observación: '
        //                                                 || PRES_OBSERVACION
        //                                                     DESCRIPCION,
        //                                                 PRES_PLAZO,
        //                                                 NOMBRE,
        //                                                 PRES_VALOR,
        //                                                 DECODE (PRES_ESTADO,  0, 'PAGADO',  1, 'PENDIENTE')
        //                                                     PRES_ESTADO,
        //                                                 ROUND (SUM (DET_PRES_VALOR), 3)
        //                                                     PAGO,
        //                                                 PATRONO,
        //                                                 PAT_ID,EMP_ID
        //                                            FROM DESARROLLO.V_DET_PRESTAMOS
        //                                           WHERE     ROL_ID_GEN IN (SELECT DISTINCT ROL_ID_GEN
        //                                                                      FROM DESARROLLO.V_DET_PRESTAMOS
        //                                                                     WHERE DET_PRES_ROL = :PER_ID)
        //                                                 AND EMP_ID IN (SELECT DISTINCT EMP_ID
        //                                                                  FROM DESARROLLO.V_DET_PRESTAMOS
        //                                                                 WHERE DET_PRES_ROL = :PER_ID)                                                 
        //                                        GROUP BY PATRONO,
        //                                                 NOMBRE,
        //                                                 PRES_VALOR,
        //                                                 PRES_PLAZO,
        //                                                 ROL_SUBCUENTA,
        //                                                 PRES_OBSERVACION,
        //                                                 PRES_ESTADO, PAT_ID,EMP_ID)
        //                                 ";
        private string sqlPrestamo = @"
SELECT PRESTAMO,
       DESCRIPCION,
       PRES_PLAZO,
       NOMBRE,
       PAGO     PENDIENTE,
       PRES_VALOR,
       PRES_ESTADO,
       PATRONO,
       PAT_ID
  FROM (  SELECT 'Prestamo: $' || PRES_VALOR || ' Cuotas: ' || PRES_PLAZO
                     PRESTAMO,
                    /*'Cuenta: '
                 || ROL_SUBCUENTA
                 || ' Observación: '
                 ||*/ PRES_OBSERVACION
                     DESCRIPCION,
                 PRES_PLAZO,
                 NOMBRE,
                 PRES_VALOR,
                 DECODE (DESARROLLO.F_VER_EST_PRESTAMO (EMP_ID,
                                                        ROL_ID,
                                                        ROL_ID_GEN,
                                                        ROL_REPRO,
                                                        PRES_PLAZO),
                         0, 'PAGADO',
                         1, 'PENDIENTE')
                     PRES_ESTADO,
                 ROUND ((DET_PRES_VALOR), 3)
                     PAGO,
                 PATRONO,
                 PAT_ID,
                 EMP_ID,
                 ROL_ID_GEN
            FROM DESARROLLO.V_DET_PRESTAMOS)
            WHERE PAT_ID>0
";
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
                                               ROL_CUENTA_IMP, TRUNC (ROL_VALOR,4)ROL_VALOR, ROL_ORD, 
                                               ROL_ID_IMP, EMP_ID, ROL_ID_GEN, 
                                               ROL_REPRO, PATRONO, ROL_PAGADO, 
                                               LOC_CIUDAD, CARGO, PERIODO, 
                                               ESTADO, GRUPO, ESC_ID
                                            FROM DESARROLLO.DAT_IMP_ROL_EXC WHERE ROL_ID_GEN=:ROL_ID_GEN AND ROL_REPRO=:ROL_REPRO";

        private string sqlDetalleContabilidadC = @"SELECT PATRONO, ROL_CUENTA_IMP, trunc(Sum(ROL_VALOR), 4) as valor
                                                     FROM DESARROLLO.DAT_IMP_ROL_EXC
                                                     where  ROL_ID_GEN=:ROL_ID_GEN AND ROL_REPRO=:ROL_REPRO 
                                                     GROUP BY PATRONO, ROL_CUENTA_IMP--, ROL_ORD, ROL_ID_IMP
--                                                ORDER BY ROL_ORD,ROL_ID_IMP
";

        private string sqlDetalleContabilidadD = @"SELECT LOC_CIUDAD,ROL_LOCAL,ROL_NOMBRE,ROL_DIAS,ROL_CUENTA_IMP,TRUNC(ROL_VALOR,4)ROL_VALOR, ROL_ORD, ROL_ID_IMP,EMP_ID,
		ROL_ID_GEN,ROL_REPRO,PATRONO,DECODE(ROL_PAGADO,1,'PAGADO',0,'NO PAGADO',3,'PAGO CHEQUE') AS ROL_PAGADO,CARGO,ESTADO,GRUPO
		FROM DESARROLLO.DAT_IMP_ROL_EXC
		WHERE ROL_DIAS>=0 AND ROL_ID_GEN=:ROL_ID_GEN AND ROL_REPRO=:ROL_REPRO 
		ORDER BY ROL_PAGADO DESC,ROL_LOCAL,ROL_NOMBRE ASC,PATRONO,ROL_ORD ASC,ROL_CUENTA_IMP";

        private string sqlReporteDetalleSueldo = "DESARROLLO.P_IMP_SUELDO_CONS_CONTA_DET";
        private string sqlReporteDetalleSueldoExel = "DESARROLLO.P_IMP_ROL_EXCEL";

        private string sqlSueldoQuincena = "DESARROLLO.P_GEN_CUEN_SUELDO";
        private string sqlSueldoQuincenaTotal = "DESARROLLO.P_GEN_CUEN_SUELDO_TOT";
        private string sqlSueldoQuincenaGlobal = "DESARROLLO.P_GEN_CUEN_SUELDO_GT";
        private string sqlDetalleEmpleado = @"SELECT ROWNUM                             NUM,
                                                   LOC_CIUDAD_ABREV CIUDAD,
                                                   LOC_NOMBRE LOCAL,
                                                   NOMBRE EMPLEADO,
                                                   ESC_ABRE CARGO,
                                                   LAB_FEC_INGRESO INGRESO,
                                                   EMP_CON_FEC_CONTRATO CONTRATO,
                                                   TIPO_CONTRATO,
                                                   PATRONO,
                                                   LAB_FEC_CAMB_ESC ULTM_ASC,
                                                   EMP_FEC_SALIDAREAL SALIDA_REAL,
                                                   EMP_CI CEDULA,
                                                   EMP_FEC_NAC FECHA_NACIMIENTO,
                                                   EMP_DIREC DIRECCION,
                                                   EMP_BARRIO BARRIO,
                                                   (SELECT EMP_SEC_NOMBRE
                                                      FROM DESARROLLO.DAT_EMP_SEC
                                                     WHERE EMP_SEC_ID = V.EMP_SEC)    SECTOR,
                                                   EMP_TELEFONO TELEFONO,
                                                   DECODE(EMP_EST_CIVIL,'S','Soltero','C','Casado','U','Unión Libre','Se', 'Separado', 'D', 'Divorciado','V','Viudo') ESTADO_CIVIL,
                                                   DECODE(EMP_SEXO,1,'Hombre',0,'Mujer') SEXO,
                                                   EMP_CUENTA CUENTA,
                                                   DECODE(EMP_DISCAPACIDAD,0,'No',1,'Si') DISCAPACIDAD,
                                                   EMP_MAIL_PER CORREO_PERSONAL,
                                                   EMP_MAIL CORREO_EMPRESARIAL
                                              FROM DESARROLLO.V_DETALLE_EMP V";


        public DataTable DetalleEmpleado(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID",empID )

            };
            //return db.GetData(sqlSolicitudVacacion, prm);
            return db.GetData(sqlDetalleEmpleado, prm);
        }

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
            return db.GetData(sqlLiquidacion, prm);
        }
        public DataSet LiquidacionParamReport(string empID, string perID, string reproID)
        {
            string sqlVestimenta = @"
                                    SELECT ESC_SAL_UNIFICADO, ESC_VEST, ESC_ADI_BON_PRO
                                      FROM DESARROLLO.RES_DAT_ESC
                                     WHERE     ESC_ID = (SELECT ESC_ID
                                                           FROM DESARROLLO.V_DETALLE_EMP
                                                          WHERE EMP_ID = :EMP_ID)
                                           AND RES_ROL_GENERAL = :PER_ID
                                           AND RES_ROL_REPRO = :REPRO_ID ";

            DataSet content = new DataSet();
            DataTable data = new DataTable();
            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":EMP_ID", empID),
                    new OracleParameter(":PER_ID", perID),
                    new OracleParameter(":PERC_ID", reproID)

                };

            data = db.GetData(sqlVestimenta, prm).Copy();
            data.TableName = "Vestimenta";
            content.Tables.Add(data);

            //string sql
            //prm = new OracleParameter[]
            //{
            //        new OracleParameter(":DIA_ID", diaID),
            //        new OracleParameter(":PERC_ID", percID ),
            //        new OracleParameter(":PAT_ID", patID)
            //};
            //data = db.GetData(sqlAsientoLiquidacionDT, prm).Copy();
            //data.TableName = "Detail";
            //content.Tables.Add(data);
            return content;
        }
        public DataTable LiquidacionDT(string empID, string vacID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID",empID ),
                new OracleParameter(":DIAR_ID",vacID)
            };
            db.ExecProcedure(sqlLiquidacionReport, prm);
            return db.GetData(sqlLiquidacionDT);
        }
        public DataTable DetalleContabilidad(string rolID, string reproID, string tipoRep)
        {
            OracleParameter[] prm = new OracleParameter[]
         {
                new OracleParameter(":ROL_ID_GEN",rolID ),
                new OracleParameter(":ROL_REPRO",reproID ),
                new OracleParameter(":OP",1 )
         };

            db.ExecProcedure(sqlReporteDetalleSueldo, prm);
            db.ExecProcedure(sqlReporteDetalleSueldoExel, prm);

            prm = new OracleParameter[]
           {
                new OracleParameter(":ROL_ID_GEN",rolID ),
                new OracleParameter(":ROL_REPRO",reproID )
           };
            string sql;
            if (tipoRep.Equals("Consolidado"))
                sql = sqlDetalleContabilidadC;
            else
                sql = sqlDetalleContabilidadD;


            return db.GetData(sqlDetalleContabilidad, prm);
        }

        public DataTable Prestamo(string rolID, string estado, string patrono, string tipo, string empID)
        {
            String sqlWhere = String.Empty; ;
            //if (!estado.Equals(""))
            //{
            //    sqlWhere = " WHERE PRES_ESTADO ='" + estado.ToUpper() + "'";
            //    if (!patrono.Equals(""))
            //        sqlWhere += " AND PAT_ID = " + patrono;
            //    if (!empID.Equals(""))
            //        sqlWhere += " AND EMP_ID = " + empID;
            //}
            //else
            //{
            //    if (!patrono.Equals(""))
            //    {
            //        sqlWhere += " WHERE PAT_ID = " + patrono;
            //        if (!empID.Equals(""))
            //            sqlWhere += " AND EMP_ID = " + empID;
            //    }            
            //    else
            //    {
            //        if (!empID.Equals(""))
            //            sqlWhere += " WHERE EMP_ID = " + empID;
            //    }
            //}

            if (!estado.Equals(""))
                sqlWhere = " AND PRES_ESTADO ='" + estado.ToUpper() + "'";
            if (!patrono.Equals(""))
                sqlWhere += " AND PAT_ID = " + patrono;
            if (!empID.Equals(""))
                sqlWhere += " AND EMP_ID = " + empID;
            if (!rolID.Equals("0") & !rolID.Equals(""))
            {
                sqlWhere += " AND ROL_ID_GEN IN (SELECT DISTINCT ROL_ID_GEN FROM DESARROLLO.V_DET_PRESTAMOS WHERE DET_PRES_ROL="+ rolID+")";
                sqlWhere += " AND EMP_ID IN(SELECT DISTINCT EMP_ID FROM DESARROLLO.V_DET_PRESTAMOS WHERE DET_PRES_ROL=" + rolID + ")";
            }
                


            string sql;
            if (tipo.Equals("Detallado"))
                sql = sqlPrestamoDT + sqlWhere;
            else
                sql = sqlPrestamo + sqlWhere;

            OracleParameter[] prm = new OracleParameter[]
            {                
                new OracleParameter(":PER_ID",rolID ),
                new OracleParameter(":PER_ID",rolID )
            };
            return db.GetData(sql, prm);
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
                new OracleParameter(":PAT_ID",patrono.Equals("0")?"": patrono ),
                new OracleParameter(":LOC_ID",local.Equals("0")?"": local),
                new OracleParameter(":EMP_CI",empID.Equals("0")?"": empID )
            };
            return db.GetData(sqlPagoQuincena, prm);
        }
        public DataTable RolIndividual(string rolID, string reproID, string empID, string localID, string cadenaID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":rolID",rolID ),
                new OracleParameter(":reproID",reproID ),
                new OracleParameter(":empID",empID.Equals("0")? null: empID ),
                new OracleParameter(":localID",localID.Equals("0")? null: localID),
                new OracleParameter(":ciudadlID",string.Empty ),
                new OracleParameter(":cadenaID",cadenaID)
            };
            db.ExecProcedure(sqlGeneraRol, prm);
            return db.GetData(sqlListaRol);
        }

        public DataTable RolIndividualSub(string rolID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":IND_ID",rolID )
            };
             return db.GetData(sqlListaRolSub, prm );
        }
    }
}
