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
    public class ContratoRepository
    {
        #region Variables
        private static string sqlContratoHoraGeneral = @"SELECT      COUNT(*) 
      FROM DESARROLLO.V_DETALLE_EMP,DESARROLLO.DAT_EMP_CON
      WHERE
      V_DETALLE_EMP.EMP_ID=DAT_EMP_CON.EMP_ID AND
      LAB_TIPO_EMP=0
      AND V_DETALLE_EMP.EMP_CON_FEC_CONTRATO=TO_DATE('01/MAY/2008')
      AND DAT_EMP_CON.CON_ID IN (16,10,17,18)
      AND (EMP_CON_FEC_LIQUI IS NULL OR EMP_CON_FEC_LIQUI=TO_DATE('30/APR/2008'))
      AND V_DETALLE_EMP.EMP_ID=:V_DETALLE_EMP.EMP_ID
      AND (ESC_CARGOMB NOT LIKE '%MOTO%' AND ESC_CARGOMB NOT LIKE '%HORA%')";
        private static string sqlTipoContrato = @"SELECT upper(TIPO_CONTRATO) 
			FROM DESARROLLO.V_DETALLE_EMP
			WHERE EMP_ID=:EMP_ID";
        private static string sqlEmpleadoEsMotorista = @"SELECT COUNT(*)
			FROM DESARROLLO.V_DETALLE_EMP
			WHERE 
			EMP_ID=:EMP_ID AND 
			(ESC_CARGOMB LIKE '%MOTO%' OR ESC_CARGOMB LIKE '%HORA%')";
        private static string sqlProcesaDiario = @"UPDATE DESARROLLO.DAT_DIARIO
   SET DIA_ESTADO = 1
 WHERE     PAT_ID = 1
       AND PERC_ID = :PERC_ID
       AND DIA_ID = :DIA_ID";
        private static string sqlAsientoLiquidacionDT = @"SELECT CUE_ID,
                                                               PERC_ID,
                                                               DIA_ID,
                                                               CLI_ID,
                                                               DET_DIA_DB,
                                                               DET_DIA_HB,
                                                               DET_DIA_FEC_REG,
                                                               DET_DIA_FEC_MOD,
                                                               DET_DIA_CLI_SEG,
                                                               PAT_ID,
                                                               DET_ID,
                                                               ORD_IMP,
                                                               USU_CREA,
                                                               USU_MODIF,
                                                               ANIO_PERC,
                                                               DET_OBSER,
                                                                (SELECT CUE_NOMBRE
                                                                  FROM DESARROLLO.DAT_CUENTA
                                                                 WHERE CUE_ID = T.CUE_ID AND PAT_ID = T.PAT_ID)CUENTA,
                                                                DESARROLLO.PK_TRANS_CONT.F_BUSCA_NOM_LOC(T.CLI_ID)LOCAL
                                                          FROM DESARROLLO.DAT_DET_DIARIO T
                                                         WHERE DIA_ID = :DIA_ID AND PERC_ID = :PERC_ID AND PAT_ID = :PAT_ID";
        private static string sqlAsientoLiquidacion = @"SELECT PERC_ID,
                                                               DIA_ID,
                                                               DIA_DIA,
                                                               CLI_ID,
                                                               TIP_MAT_ID,
                                                               DIA_OBS,
                                                               DIA_ORI,
                                                               DIA_FEC_DIARIO,
                                                               DIA_RESP,
                                                               DIA_FEC_REG,
                                                               DIA_FEC_MOD,
                                                               DIA_COD_ORI,
                                                               DIA_ESTADO,
                                                               DIA_ID_PROV,
                                                               PAT_ID,
                                                               DIA_NUM_CHEQ,
                                                               DIA_FEC_CHEQ,
                                                               DIA_BENEFICIARIO,
                                                               DIA_NUM_EGRESO,
                                                               USU_CREA,
                                                               USU_MODIF,
                                                               ANIO_PERC,
                                                               PROV_ID,
                                                               DAT_PAT_ID,
                                                               NUM_DOC,
                                                               DECODE (DIA_ESTADO,
                                                                       0, 'Pendiente',
                                                                       1, 'Procesado',
                                                                       2, 'Provisionado',
                                                                       3, 'Dado de Baja',
                                                                       4, 'Reversado',
                                                                       'Sin Estado')ESTADO,
                                                               (SELECT PERC_MES || ' - ' || PERC_ANO
                                                                  FROM DESARROLLO.DAT_PER_CONT
                                                                 WHERE PERC_ID = D.PERC_ID)PERIODO,
                                                               DESARROLLO.PK_TRANS_CONT.F_BUSCA_NOM_LOC (D.CLI_ID)LOCAL,
                                                               (SELECT TIP_MAT_DESC
                                                                  FROM DESARROLLO.DAT_TIP_MAT
                                                                 WHERE TIP_MAT_ID = D.TIP_MAT_ID)TIPO,
                                                               DESARROLLO.PK_TRANS_CONT.F_BUSC_NOMBRE (D.TIP_MAT_ID, D.DIA_COD_ORI)NOMBRE,
(SELECT PAT_RAZ_SOCIAL FROM DAT_PATRONO WHERE PAT_ID=D.DAT_PAT_ID )PATRONO
                                                          FROM DESARROLLO.DAT_DIARIO D
                                                         WHERE     D.DIA_ID = :DIA_ID
                                                               AND D.CLI_ID = :CLI_ID
                                                               AND D.PERC_ID = :PERC_ID
                                                               AND D.PAT_ID = :PAT_ID";
        private static string sqlGeneraAsientoLiquidacion = "DESARROLLO.P_CREA_ASIENTO_LIQ";
        private static string sqlCalculaVacaciones = "DESARROLLO.P_CALC_FEC_VACACIONES";
        private static string sqlCalculaLiquidacionEmp = "DESARROLLO.PK_LIQUIDACION.P_CAL_LIQ";
        private static string sqlCalculaLiquidacionMot = "DESARROLLO.PK_LIQUIDACION_MOTO.P_CAL_LIQ";
        private static string sqlEsMotorista = @"
                                            SELECT COUNT (*)
                                              FROM DESARROLLO.V_DETALLE_EMP
                                             WHERE     EMP_ID = :EMP_ID
                                                   AND (ESC_CARGOMB LIKE '%MOTO%' OR ESC_CARGOMB LIKE '%HORA%')";

        private static string sqlEsEmpleado = @"
                                                        SELECT COUNT (*)
                                                          FROM DESARROLLO.V_DETALLE_EMP, DESARROLLO.DAT_EMP_CON
                                                         WHERE     V_DETALLE_EMP.EMP_ID = DAT_EMP_CON.EMP_ID
                                                               AND LAB_TIPO_EMP = 0
                                                               AND V_DETALLE_EMP.EMP_CON_FEC_CONTRATO = TO_DATE ('01/MAY/2008')
                                                               AND DAT_EMP_CON.CON_ID IN (16,
                                                                                          10,
                                                                                          17,
                                                                                          18)
                                                               AND (   EMP_CON_FEC_LIQUI IS NULL
                                                                    OR EMP_CON_FEC_LIQUI = TO_DATE ('30/APR/2008'))
                                                               AND V_DETALLE_EMP.EMP_ID = :EMP_ID
                                                               AND (ESC_CARGOMB NOT LIKE '%MOTO%' AND ESC_CARGOMB NOT LIKE '%HORA%')";
        private static string sqlValidaLiquidacion = "SELECT COUNT (*)  FROM DESARROLLO.DAT_LIQ WHERE EMP_ID = :EMP_ID AND LIQ_FEC_ING = :CONTRATO";
        private static string sqlDetalleVacacionDT = @"
                                                        SELECT ROWNUM                                                      NUM,
                                                               DESARROLLO.F_MES_CALCULADO (C.SEG_ROL_ID)     MES,
                                                               C.EMP_ID,
                                                               C.CAL_VAC_ID,
                                                               C.VAC_PER_ID,
                                                               C.SEG_ROL_ID,
                                                               C.SEG_ROL_REPRO,
                                                               C.VAC_VAL_DIAS,
                                                               ROUND(C.VAC_VAL_VALOR,2)VAC_VAL_VALOR,
                                                               ROUND(C.VAC_VAL_VALOR_VAC,2)VAC_VAL_VALOR_VAC
                                                          FROM DESARROLLO.DAT_CAL_VAC_VAL C
                                                               JOIN DESARROLLO.DAT_CAL_VAC_PER  V
                                                                   ON (    V.EMP_ID = C.EMP_ID
                                                                       AND V.CAL_VAC_ID = C.CAL_VAC_ID
                                                                       AND V.VAC_PER_ID = C.VAC_PER_ID)
                                                         WHERE     C.EMP_ID = :EMP_ID
                                                               AND C.CAL_VAC_ID = :CAL_VAC_ID ";
        private static string sqlDetalleVacacion = @"SELECT ROWNUM NUM,
                                                           EMP_ID,
                                                           CAL_VAC_ID,
                                                           VAC_PER_ID,
                                                           VAC_PER_VAC,
                                                           VAC_PER_FEC_INI,
                                                           VAC_PER_FEC_FIN,
                                                           VAC_DIAS_CAL
                                                      FROM DESARROLLO.DAT_CAL_VAC_PER
                                                     WHERE EMP_ID = :EMP_ID AND CAL_VAC_ID = :CAL_VAC_ID";
        private static string sqlDetalleDecimoTerceroDT = @"SELECT ROWNUM                                        NUM,
                                                                   DESARROLLO.F_MES_CALCULADO (V.SEG_ROL_ID)     MES,
                                                                   V.DEC_TER_PROC,
                                                                   V.DEC_TER_TIP,
                                                                   V.EMP_ID,
                                                                   V.TER_PER_ID,
                                                                   V.SEG_ROL_ID,
                                                                   V.SEG_ROL_REPRO,
                                                                   V.ESC_ID,
                                                                   V.LOC_ID,
                                                                   V.TER_VAL_VALOR,
                                                                   ROUND (V.TER_VAL_VALOR_TER, 2) TER_VAL_VALOR_TER                     --DAT_CAL_TER_VAL.*
                                                              FROM DAT_CAL_TER_VAL  V
                                                                   JOIN DAT_CAL_TER_PER T
                                                                       ON (    V.DEC_TER_PROC = T.DEC_TER_PROC
                                                                           AND V.DEC_TER_TIP = T.DEC_TER_TIP
                                                                           AND V.EMP_ID = T.EMP_ID
                                                                           AND V.ESC_ID = T.ESC_ID
                                                                           AND V.LOC_ID = T.LOC_ID)
                                                             WHERE     T.EMP_ID = :EMP_ID
                                                                   AND T.DEC_TER_PROC IN
                                                                           (SELECT DEC_TER_PROC
                                                                              FROM DESARROLLO.DAT_PER_CAL_DEC_TER
                                                                             WHERE EMP_ID = :EMP_ID AND CAL_DEC_TER_ID = :CAL_DEC_TER_ID)";
        private static string sqlDetalleDecimoTercero = @"
                                                        SELECT ROWNUM NUM, DEC_TER_PROC,
                                                               DEC_TER_TIP,
                                                               EMP_ID,
                                                               TER_PER_ID,
                                                               ESC_ID,
                                                               LOC_ID,
                                                               TER_FEC_REG,
                                                               TER_FEC_INI,
                                                               TER_FEC_FIN,
                                                               DEC_TER_FEC_ULT_CONT
                                                          FROM DESARROLLO.DAT_CAL_TER_PER
                                                         WHERE     EMP_ID = :EMP_ID
                                                               AND DEC_TER_PROC IN
                                                                       (SELECT DEC_TER_PROC
                                                                          FROM DESARROLLO.DAT_PER_CAL_DEC_TER
                                                                         WHERE EMP_ID = :EMP_ID AND CAL_DEC_TER_ID = :CAL_DEC_TER_ID)";
        private static string sqlActualizaDetalleingresoCb = @"UPDATE DESARROLLO.DAT_DET_LIQ
   SET DET_LIQ_VALOR = :INGRESO
 WHERE     EMP_ID = :EMP_ID
       AND LIQ_ID = :LIQ_ID
       AND RUB_LIQ_ID = :RUB_LIQ_ID";
        private static string sqlEliminaDetalleIngreso = @"DELETE DESARROLLO.DAT_DET_ROL_LIQ 
WHERE SEG_ROL_ID=:SEG_ROL_ID
AND SEG_ROL_REPRO=:SEG_ROL_REPRO
AND EMP_ID=:EMP_ID 
AND ROL_ID=:ROL_ID
AND ROL_LIQ_ID=:ROL_LIQ_ID";
        private static string sqlRegistraDetalleIngreso = @"INSERT INTO DESARROLLO.DAT_DET_ROL_LIQ (SEG_ROL_ID,
                                        SEG_ROL_REPRO,
                                        EMP_ID,
                                        ROL_ID,
                                        ROL_LIQ_ID,
                                        ROL_LIQ_VALOR,
                                        ROL_LIQ_FEC_REG)
     VALUES (                                    :SEG_ROL_ID
             ,:SEG_ROL_REPRO
             ,:EMP_ID
             ,:ROL_ID
             ,:ROL_LIQ_ID
             ,:ROL_LIQ_VALOR
             ,SYSDATE--:ROL_LIQ_FEC_REG
             )
";
        private static string sqlIdDetalleDiaio = @"
                                                    SELECT NVL (MAX (DET_ID), 0) + 1
                                                      FROM DESARROLLO.DAT_DET_DIARIO
                                                     WHERE     CUE_ID = :CUE_ID
                                                           AND PERC_ID = :PERC_ID
                                                           AND DIA_ID = :DIA_ID
                                                           AND CLI_ID = :CLI_ID
                                                           AND PAT_ID = :PAT_ID";
        private static string sqlOrdenImpresion = @"
                                                    SELECT NVL (MAX (DET_ID), 0)+1                                                      
                                                      FROM DESARROLLO.DAT_DET_DIARIO
                                                     WHERE     PERC_ID = :PERC_ID
                                                           AND DIA_ID = :DIA_ID
                                                           AND PAT_ID = :PAT_ID";
        private static string sqlRegistraDetalleDiario = @"
                                                            INSERT INTO DESARROLLO.DAT_DET_DIARIO (CUE_ID,
                                                                                                   PERC_ID,
                                                                                                   DIA_ID,
                                                                                                   CLI_ID,
                                                                                                   DET_DIA_DB,
                                                                                                   DET_DIA_HB,
                                                                                                   DET_DIA_FEC_REG,
                                                                                                   --DET_DIA_FEC_MOD,
                                                                                                   DET_DIA_CLI_SEG,
                                                                                                   PAT_ID,
                                                                                                   DET_ID,
                                                                                                   ORD_IMP,
                                                                                                   USU_CREA,
                                                                                                   --USU_MODIF,
                                                                                                   --ANIO_PERC,
                                                                                                   DET_OBSER)
                                                                 VALUES ( :CUE_ID
                                                                         ,:PERC_ID
                                                                         ,:DIA_ID
                                                                         ,:CLI_ID
                                                                         ,:DET_DIA_DB
                                                                         ,:DET_DIA_HB
                                                                         ,SYSDATE--:DET_DIA_FEC_REG
                                                                         --,:DET_DIA_FEC_MOD
                                                                         ,:DET_DIA_CLI_SEG
                                                                         ,:PAT_ID
                                                                         ,:DET_ID
                                                                         ,:ORD_IMP
                                                                         ,:USU_CREA
			                                                             --,:USU_MODIF
                                                                         --,:ANIO_PERC
			                                                             ,:DET_OBSER
                                                                         )";
        private static string sqlActualizaDetalleDiario = @"UPDATE DESARROLLO.DAT_DET_DIARIO
                                                               SET CUE_ID = :CUE_ID,
                                                                   --PERC_ID = :PERC_ID,
                                                                   --DIA_ID = :DIA_ID,
                                                                   CLI_ID = :CLI_ID,
                                                                   DET_DIA_DB = :DET_DIA_DB,
                                                                   DET_DIA_HB = :DET_DIA_HB,
                                                                   --DET_DIA_FEC_REG = :DET_DIA_FEC_REG,
                                                                   DET_DIA_FEC_MOD = SYSDATE,--:DET_DIA_FEC_MOD,
                                                                   --DET_DIA_CLI_SEG = :DET_DIA_CLI_SEG,
                                                                   --PAT_ID = :PAT_ID,
                                                                   --DET_ID = :DET_ID,
                                                                   --ORD_IMP = :ORD_IMP,
                                                                   --USU_CREA = :USU_CREA,
                                                                   USU_MODIF = :USU_MODIF
                                                                   --ANIO_PERC = :ANIO_PERC,
                                                                   --DET_OBSER = :DET_OBSER
                                                             WHERE     CUE_ID = :CUE_ID
                                                                   AND PERC_ID = :PERC_ID
                                                                   AND DIA_ID = :DIA_ID
                                                                   AND CLI_ID = :CLI_ID
                                                                   AND PAT_ID = :PAT_ID
                                                                   AND DET_ID = :DET_ID";
        private static string sqlEliminaDetalleDiario = @"DELETE DESARROLLO.DAT_DET_DIARIO 
                                                              WHERE     CUE_ID = :CUE_ID
                                                                   AND PERC_ID = :PERC_ID
                                                                   AND DIA_ID = :DIA_ID
                                                                   AND CLI_ID = :CLI_ID
                                                                   AND PAT_ID = :PAT_ID
                                                                   AND DET_ID = :DET_ID";
        private static string sqlActualizaDetalleingreso = @"
                                                            UPDATE DESARROLLO.DAT_DET_ROL_LIQ
                                                               SET --SEG_ROL_ID = :SEG_ROL_ID,
                                                                   --SEG_ROL_REPRO = :SEG_ROL_REPRO,
                                                                   --EMP_ID = :EMP_ID,
                                                                   ROL_ID = :ROL_ID,
                                                                   ROL_LIQ_ID = :ROL_LIQ_ID,
                                                                   ROL_LIQ_VALOR = :ROL_LIQ_VALOR,
                                                                   ROL_LIQ_FEC_REG = SYSDATE --:ROL_LIQ_FEC_REG
                                                             WHERE     SEG_ROL_ID = :SEG_ROL_ID
                                                                   AND SEG_ROL_REPRO = :SEG_ROL_REPRO
                                                                   AND EMP_ID = :EMP_ID
                                                                   AND ROL_ID = :ROL_ID
                                                                   AND ROL_LIQ_ID = :ROL_LIQ_ID";
        private static string sqlDetalleIngreso = @"
                                                    SELECT SEG_ROL_ID,
                                                           SEG_ROL_REPRO,
                                                           EMP_ID,
                                                           ROL_ID,
                                                           (SELECT LTRIM (ROL_CUENTA || ' - ' || ROL_SUBCUENTA)
                                                              FROM DESARROLLO.VAR_ROL
                                                             WHERE ROL_SUBCUENTA IS NOT NULL AND ROL_ID = R.ROL_ID)    CUENTA,
                                                           ROL_LIQ_ID,
                                                           ROL_LIQ_VALOR,
                                                           ROL_LIQ_FEC_REG
                                                      FROM DESARROLLO.DAT_DET_ROL_LIQ R
                                                     WHERE     EMP_ID = :EMP_ID
                                                           AND SEG_ROL_ID = :SEG_ROL_ID
                                                           AND SEG_ROL_REPRO = :SEG_ROL_REPRO";
        private static string sqlGetReproceso = "SELECT DESARROLLO.PK_NOMINATCG.GET_REPROCESO ( :EMP_ID, :PER_ID) FROM DUAL";
        private static string sqlListaReproceso = @"
                                                    SELECT SEG_ROL_REPRO
                                                      FROM DESARROLLO.DAT_ROL_SEG
                                                     WHERE     SEG_ROL_ID = :SEG_ROL_ID
                                                           AND SEG_ROL_REPRO <= (SELECT SEG_ROL_REPRO
                                                                                   FROM DESARROLLO.DAT_ROL_SEG
                                                                                  WHERE SEG_ROL_ID = :SEG_ROL_ID AND SEG_ROL_ESTADO = 1)";
        private static string sqlListaContrato = "SELECT CON_ID, CON_NOMBRE, CON_DESC FROM DESARROLLO.DAT_CONTRATO";
        private static string sqlContratoFin = "SELECT CON_CAU_ID, CON_CAU_CAUSA, CON_CAU_ABREV, CON_CAU_FECHACREACION FROM DESARROLLO.DAT_CON_CAUSA";
        private static string sqlContratoEmpleado = "SELECT EMP_ID, EMP_CON_ID, CON_ID, PAT_ID, EMP_CON_RAZON_SALE, EMP_CON_FIRM_RENU, EMP_CON_FEC_LIQUI, EMP_CON_FIRM_LIQUI, EMP_CON_FEC_LEG_SA, EMP_CON_FIRM_SALIDA, EMP_CON_FEC_MIN_TR, EMP_CON_FEC_CONTRATO, EMP_CON_OBS, EMP_CON_FEC_REG, EMP_CON_FEC_MOD, EMP_CON_CAUSA, EMP_CON_ESTADO, CON_CAU_ID, EMP_CON_FIRM_CON, EMP_CON_LEGALIZADO FROM DESARROLLO.DAT_EMP_CON WHERE EMP_ID=:EMP_ID";
        private static string sqlInfoLaboral = "SELECT EMP_ID, LAB_ID, LOC_ID, ESC_ID, LAB_FEC_CAMB_ESC, LAB_SUELDO_BONO, LAB_OBS, LAB_FEC_REG, LAB_FEC_MOD, LAB_FEC_OBS_SIS, LAB_ESTADO, LAB_TIPO_EMP, LAB_RBU, LAB_VEST, LAB_BONO, LAB_QUINCENA FROM DESARROLLO.DAT_LAB WHERE EMP_ID =:EMP_ID AND LAB_ID=(SELECT MAX(LAB_ID) FROM DESARROLLO.DAT_LAB WHERE EMP_ID = :EMP_ID)";



        private static string sqlRubroAdicional = "SELECT EMP_ID, ROL_ID, FIJ_VALOR, FIJ_ESTADO, FECHACREA, FECHAMODI FROM DESARROLLO.DAT_EMP_VAL_FIJO WHERE EMP_ID =:empID";
        private static string sqlRegistraContrato = @"
                                INSERT INTO DESARROLLO.DAT_EMP_CON (EMP_ID,
                                                                    EMP_CON_ID,
                                                                    CON_ID,
                                                                    PAT_ID,
                                                                    EMP_CON_RAZON_SALE,
                                                                    EMP_CON_FIRM_RENU,
                                                                    EMP_CON_FEC_LIQUI,
                                                                    EMP_CON_FIRM_LIQUI,
                                                                    EMP_CON_FEC_LEG_SA,
                                                                    --EMP_CON_FIRM_SALIDA,
                                                                    --EMP_CON_FEC_MIN_TR,
                                                                    EMP_CON_FEC_CONTRATO,
                                                                    EMP_CON_OBS,
                                                                    EMP_CON_FEC_REG,
                                                                    --EMP_CON_FEC_MOD,
                                                                    --EMP_CON_CAUSA,
                                                                    EMP_CON_ESTADO,
                                                                    CON_CAU_ID
                                                                    --EMP_CON_FIRM_CON,
                                                                    --EMP_CON_LEGALIZADO
                                                                    )
                                     VALUES (:EMP_ID,
                                             :EMP_CON_ID,
                                             :CON_ID,
                                             :PAT_ID,
                                             :EMP_CON_RAZON_SALE,
                                             :EMP_CON_FIRM_RENU,
                                             :EMP_CON_FEC_LIQUI,
                                             :EMP_CON_FIRM_LIQUI,
                                             :EMP_CON_FEC_LEG_SA,
                                             --:EMP_CON_FIRM_SALIDA,
                                             --:EMP_CON_FEC_MIN_TR,
                                             :EMP_CON_FEC_CONTRATO,
                                             :EMP_CON_OBS,
                                             SYSDATE,--:EMP_CON_FEC_REG,
                                             --:EMP_CON_FEC_MOD,
                                             --:EMP_CON_CAUSA,
                                             --:EMP_CON_ESTADO,
                                             1,
                                             :CON_CAU_ID
                                             --:EMP_CON_FIRM_CON,
                                             --:EMP_CON_LEGALIZADO 
                                             )";
        private static string sqlActualizaContrato = @"
                                UPDATE DESARROLLO.DAT_EMP_CON SET   
                                                                    CON_ID=:CON_ID,
                                                                    PAT_ID=:PAT_ID,
                                                                    EMP_CON_RAZON_SALE=:EMP_CON_RAZON_SALE,
                                                                    EMP_CON_FIRM_RENU=:EMP_CON_FIRM_RENU,
                                                                    EMP_CON_FEC_LIQUI=:EMP_CON_FEC_LIQUI,
                                                                    EMP_CON_FIRM_LIQUI=:EMP_CON_FIRM_LIQUI,
                                                                    EMP_CON_FEC_LEG_SA=:EMP_CON_FEC_LEG_SA,
                                                                    --EMP_CON_FIRM_SALIDA,
                                                                    --EMP_CON_FEC_MIN_TR,
                                                                    EMP_CON_FEC_CONTRATO=:EMP_CON_FEC_CONTRATO,
                                                                    EMP_CON_OBS=:EMP_CON_OBS,
                                                                    --EMP_CON_FEC_REG,
                                                                    EMP_CON_FEC_MOD=SYSDATE,
                                                                    --EMP_CON_CAUSA,
                                                                    --EMP_CON_ESTADO,
                                                                    CON_CAU_ID=:CON_CAU_ID
                                                                    --EMP_CON_FIRM_CON,
                                                                    --EMP_CON_LEGALIZADO
                                 WHERE EMP_ID=:EMP_ID AND EMP_CON_ID=:EMP_CON_ID";
        private static string sqlRegistrarInfoLaboral = @"
                    INSERT INTO DESARROLLO.DAT_LAB (EMP_ID,
                                                    LAB_ID,
                                                    LOC_ID,
                                                    ESC_ID,
                                                    LAB_FEC_CAMB_ESC,
                                                    LAB_SUELDO_BONO,
                                                    LAB_OBS,
                                                    LAB_FEC_REG,
                                                    --LAB_FEC_MOD,
                                                    LAB_FEC_OBS_SIS,
                                                    LAB_ESTADO,
                                                    LAB_TIPO_EMP,
                                                    LAB_RBU,
                                                    LAB_VEST,
                                                    LAB_BONO,
                                                    LAB_QUINCENA
                                                    )
                         VALUES ( :EMP_ID,
                                 :LAB_ID,
                                 :LOC_ID,
                                 :ESC_ID,
                                 :LAB_FEC_CAMB_ESC,
                                 :LAB_SUELDO_BONO,
                                 :LAB_OBS,
                                 SYSDATE,--:LAB_FEC_REG,
                                 --:LAB_FEC_MOD,
                                 SYSDATE,--:LAB_FEC_OBS_SIS,
                                 :LAB_ESTADO,
                                 :LAB_TIPO_EMP,
                                 :LAB_RBU,
                                 :LAB_VEST,
                                 :LAB_BONO,
                                 :LAB_QUINCENA
                                 )";
        private static string sqlActualizaInfoLaboral = @"
                    UPDATE DESARROLLO.DAT_LAB SET                                                    
                                                    LOC_ID=:LOC_ID,
                                                    ESC_ID=:ESC_ID,
                                                    --LAB_FEC_CAMB_ESC,
                                                    LAB_SUELDO_BONO=:LAB_SUELDO_BONO,
                                                    LAB_OBS=:LAB_OBS,
                                                    --LAB_FEC_REG,
                                                    LAB_FEC_MOD=SYSDATE,
                                                    --LAB_FEC_OBS_SIS,
                                                    LAB_ESTADO=:LAB_ESTADO,
                                                    LAB_TIPO_EMP=:LAB_TIPO_EMP,
                                                    LAB_RBU=:LAB_RBU,
                                                    LAB_VEST=:LAB_VEST,
                                                    LAB_BONO=:LAB_BONO,
                                                    LAB_QUINCENA=:LAB_QUINCENA
                     WHERE EMP_ID=:EMP_ID AND LAB_ID=:LAB_ID";
        private static string sqlRegistrarValorFijo = @"INSERT INTO DESARROLLO.DAT_EMP_VAL_FIJO (EMP_ID,
                                         ROL_ID,
                                         FIJ_VALOR,
                                         FIJ_ESTADO,
                                         FECHACREA
                                         --FECHAMODI
                                         )
     VALUES (:EMP_ID,
             :ROL_ID,
             :FIJ_VALOR,
             :FIJ_ESTADO,
             SYSDATE
             --:FECHAMODI
             )";

        private static string sqlActualizarValorFijo = @"UPDATE DESARROLLO.DAT_EMP_VAL_FIJO 
                                                         SET    ROL_ID=:ROL_ID,
                                                                FIJ_VALOR=:FIJ_VALOR,
                                                                FIJ_ESTADO=:FIJ_ESTADO, 
                                                                FECHAMODI=SYSDATE
                                                         WHERE  EMP_ID=:EMP_ID AND ROL_ID=:AUX_ROL_ID";

        private static string sqlEliminaValorFijo = @"DELETE DESARROLLO.DAT_EMP_VAL_FIJO                                                          
                                                         WHERE  EMP_ID=:EMP_ID AND ROL_ID=:AUX_ROL_ID";
        private static string sqlListaPeriodoDecimoT = @"
                                                        SELECT DISTINCT
                                                                  DESARROLLO.F_MES_INV (
                                                                      TO_DATE ('01/' || DEC_TER_MES_INI || '/1975', 'dd/mm/rrrr'))
                                                               || ' '
                                                               || DEC_TER_ANO_INI
                                                               || ' - '
                                                               || DESARROLLO.F_MES_INV (
                                                                      TO_DATE ('01/' || DEC_TER_MES_FIN || '/1975', 'dd/mm/rrrr'))
                                                               || ' '
                                                               || DEC_TER_ANO_FIN                         AS PERIODO,
                                                               TO_CHAR (DEC_TER_FEC_REG, 'dd/mm/rrrr')    AS FECHA,
                                                               DEC_TER_PROC                               AS PROCESO,
                                                               DEC_TER_ANO_INI DEC_ANO_INI,
                                                               DEC_TER_ANO_FIN DEC_ANO_FIN,
                                                               DEC_TER_ORI
                                                          FROM DESARROLLO.DAT_DEC_TER
                                                         WHERE DEC_TER_ORI = 'N'
                                                         ORDER BY 1 DESC";
        private static string sqlListaPeriodoDecimoC = @"
                                                        SELECT DISTINCT
                                                                  DESARROLLO.F_MES_INV (
                                                                      TO_DATE ('01/' || DEC_MES_INI || '/1975', 'dd/mm/rrrr'))
                                                               || ' '
                                                               || DEC_ANO_INI
                                                               || ' - '
                                                               || DESARROLLO.F_MES_INV (
                                                                      TO_DATE ('01/' || DEC_MES_FIN || '/1975', 'dd/mm/rrrr'))
                                                               || ' '
                                                               || DEC_ANO_FIN                         AS PERIODO,
                                                               TO_CHAR (DEC_FEC_REG, 'dd/mm/rrrr')    AS FECHA,
                                                               DEC_PROC                               AS PROCESO,
                                                               DEC_ANO_INI,
                                                               DEC_ANO_FIN,
                                                               DEC_ORI
                                                          FROM DESARROLLO.DAT_DEC_CUA
                                                         WHERE DEC_ORI = 'N'
                                                         ORDER BY 4 DESC";
        private static string sqlListaPeriodoRol = @"  SELECT SEG_ROL_ID,
                                                             ROL_FECHA_INI,
                                                             ROL_FECHA_FIN,
                                                             SEG_ROL_REPRO
                                                        FROM DESARROLLO.DAT_ROL_SEG
                                                       WHERE    ROL_FECHA_FIN IS NOT NULL
                                                             OR (ROL_FECHA_FIN IS NULL AND SEG_ROL_REPRO = 1)
                                                    ORDER BY SEG_ROL_ID DESC, SEG_ROL_REPRO DESC";
        private static string sqlListaPeriodoUnico = @"SELECT DISTINCT DAT_ROL_SEG.SEG_ROL_ID,'Mes de: ' || DESARROLLO.F_MES_CALCULADO (DAT_ROL_SEG.SEG_ROL_ID) PERIODO  FROM DESARROLLO.DAT_ROL_SEG ORDER BY 1 DESC";
        private static string sqlListaPeriodoRolReporte = @"
                                                              SELECT DAT_ROL_SEG.SEG_ROL_ID,
                                                                     SEG_ROL_REPRO,
                                                                     'Mes de: ' || DESARROLLO.F_MES_CALCULADO (DAT_ROL_SEG.SEG_ROL_ID)
                                                                         PERIODO,
                                                                     ROL_FECHA_INI,
                                                                     ROL_FECHA_FIN
                                                                FROM DESARROLLO.DAT_ROL_SEG
                                                               WHERE SEG_ROL_ESTADO = 1
                                                            ORDER BY 1 DESC";
        private static string sqlListaPeriodo = "SELECT SEG_ROL_ID, ROL_FECHA_INI, ROL_FECHA_FIN, ROUND(TOTAL_ING,5) TOTAL_ING, ROUND(TOTAL_EGR,5) TOTAL_EGR, ROUND(TOTAL_TOTAL,5) TOTAL_TOTAL, ROUND(TOTAL_EMP,5) TOTAL_EMP, SEG_ROL_REPRO, SEG_ROL_OBS, SEG_ROL_REPRO_FECHA, SEG_ROL_ESTADO, SEG_EST_QUIN, 'Mes de: '||desarrollo.F_MES_CALCULADO(dat_rol_seg.seg_rol_id) Periodo FROM DESARROLLO.DAT_ROL_SEG ORDER BY 1 desc, SEG_ROL_REPRO DESC";
        private static string sqlListaPeriodoQuincena = "SELECT SEG_ROL_ID, ROL_FECHA_INI, ROL_FECHA_FIN, ROUND(TOTAL_ING,5) TOTAL_ING, ROUND(TOTAL_EGR,5) TOTAL_EGR, ROUND(TOTAL_TOTAL,5) TOTAL_TOTAL, ROUND(TOTAL_EMP,5) TOTAL_EMP, SEG_ROL_REPRO, SEG_ROL_OBS, SEG_ROL_REPRO_FECHA, SEG_ROL_ESTADO, SEG_EST_QUIN, 'Mes de: '||desarrollo.F_MES_CALCULADO(dat_rol_seg.seg_rol_id) Periodo FROM DESARROLLO.DAT_ROL_SEG WHERE seg_rol_estado=1 ORDER BY 1 DESC";
        private static string sqlAperturaPeriodo = "DESARROLLO.PK_NOMINATCG.P_PERIDOING ";
        private static string sqlVerificaPeriodo = "SELECT DESARROLLO.PK_NOMINATCG.F_PERIODOABIERTO FROM DUAL ";
        private static string sqlVerificaPeriodoRol = "SELECT COUNT(SEG_ROL_ID) FROM DESARROLLO.DAT_ROL_SEG  WHERE SEG_ROL_ID =:rolID AND SEG_ROL_REPRO=:reproID";
        //private static string sqlVerificaPeriodoRolAbierto = "SELECT COUNT(SEG_ROL_ID) FROM DESARROLLO.DAT_ROL_SEG  WHERE SEG_ROL_ID =:rolID AND SEG_ROL_REPRO=:reproID and rol_fecha_fin is not null";
        private static string sqlVerificaPeriodoRolAbierto1 = "SELECT COUNT(1) FROM DAT_ROL_SEG WHERE SEG_ROL_ID>(SELECT DISTINCT SEG_ROL_ID FROM DAT_ROL_SEG WHERE SEG_ROL_ID=:rolID)";
        private static string sqlGeneraRol = "DESARROLLO.PK_NOMINATCG.P_GENERAROL";
        private static string sqlNumeroProceso = "SELECT MAX(SEG_ROL_REPRO) FROM DESARROLLO.DAT_ROL_SEG WHERE SEG_ROL_ID=:idPeriodo ";
        private static string sqlNumeroProcesoRol = "SELECT MAX(ROL_REPRO) FROM DESARROLLO.DAT_ROL WHERE ROL_ID_GEN=:idPeriodo";
        private static string sqlNumeroProcesoRolEmp = "SELECT NVL(MAX(ROL_REPRO),0) FROM DESARROLLO.DAT_ROL WHERE ROL_ID_GEN=:idPeriodo AND EMP_ID=:empID";
        private static string sqlHabilitaQuincena = "UPDATE DESARROLLO.DAT_ROL_SEG SET SEG_EST_QUIN=:estado WHERE SEG_ROL_ID=:idPeriodo AND SEG_ROL_REPRO=:numProc ";
        private static string sqlListaRol = "SELECT EMP_ID, ROL_ID_GEN, ROL_TOT_ING, ROL_TOT_EGR, ROL_TOTAL, ROL_DIA_TRA, ROL_RETENIDO, ROL_DIA_DESC, ROL_REPRO, ROL_PAGADO, ROL_PAG_QUIN, FECHACREACION, FECHAMODIF FROM DESARROLLO.DAT_ROL WHERE EMP_ID=:EMP_ID AND ROL_ID_GEN=:ROL_ID_GEN AND ROL_REPRO=:ROL_REPRO";
        private static string sqlListaRolTipo = "SELECT EMP_ID, ROL_ID_GEN, ROL_TOT_ING, ROL_TOT_EGR, ROL_TOTAL, ROL_DIA_TRA, ROL_RETENIDO, ROL_DIA_DESC, ROL_REPRO, ROL_PAGADO, ROL_PAG_QUIN, FECHACREACION, FECHAMODIF FROM DESARROLLO.DAT_ROL WHERE EMP_ID=:EMP_ID AND ROL_ID_GEN=:ROL_ID_GEN AND ROL_REPRO=:ROL_REPRO and (dat_det_rol.ROL_ID IN (SELECT rol_id FROM desarrollo.var_rol WHERE ROL_TIPO_CUENTA=1)) ";
        private static string sqlListaRolDetalle = @"SELECT ROL_ID, (SELECT TRIM(ROL_CUENTA)||' - '||ROL_SUBCUENTA FROM DESARROLLO.VAR_ROL WHERE ROL_ID=R.ROL_ID)CUENTA,
                                                     EMP_ID, ROL_ID_GEN, DET_ROL_ID, DET_ROL_VALOR, DET_ROL_FECHA, ROL_REPRO, DET_ROL_AUDIT, DET_ROL_AUDIT2 
                                                     FROM DESARROLLO.DAT_DET_ROL R WHERE EMP_ID=:EMP_ID AND ROL_ID_GEN=:ROL_ID_GEN AND ROL_REPRO=:ROL_REPRO";
        private static string sqlListaRolDetalleTipo = @"SELECT ROL_ID, (SELECT TRIM(ROL_CUENTA)||' - '||ROL_SUBCUENTA FROM DESARROLLO.VAR_ROL WHERE ROL_ID=R.ROL_ID)CUENTA,
                                                     EMP_ID, ROL_ID_GEN, DET_ROL_ID, DET_ROL_VALOR, DET_ROL_FECHA, ROL_REPRO, DET_ROL_AUDIT, DET_ROL_AUDIT2 
                                                     FROM DESARROLLO.DAT_DET_ROL R WHERE EMP_ID=:EMP_ID AND ROL_ID_GEN=:ROL_ID_GEN AND ROL_REPRO=:ROL_REPRO 
AND (R.ROL_ID IN (SELECT rol_id
                                     FROM desarrollo.var_rol
                                    WHERE ROL_TIPO_CUENTA = 1))";
        private static string sqlListaRolDetalleCuenta = @"SELECT T.ROL_ID,
                                                           T.EMP_ID,
                                                           T.ROL_ID_GEN,
                                                           T.DET_ROL_ID,
                                                           T.ESP_ID,
                                                           T.LOC_ID,
                                                           T.ESP_VALOR,
                                                           T.ESP_FECHA_ING,
                                                           T.ESP_FECHA_REP,
                                                           T.ESP_OBS,
                                                           T.ROL_REPRO,
                                                           T.ESP_AUDIT
                                                          FROM DESARROLLO.DAT_DET_ROL_ESP  T
                                                               JOIN DESARROLLO.DAT_DET_ROL R
                                                                   ON (    T.EMP_ID = R.EMP_ID
                                                                       AND T.ROL_ID_GEN = R.ROL_ID_GEN
                                                                       AND T.ROL_REPRO = R.ROL_REPRO
                                                                       AND T.ROL_ID = R.ROL_ID
                                                                       AND T.DET_ROL_ID = R.DET_ROL_ID)
                                                         WHERE     T.EMP_ID = :EMP_ID
                                                               AND T.ROL_ID_GEN = :ROL_ID_GEN
                                                               AND T.ROL_REPRO = :ROL_REPRO
                                                               AND T.ROL_ID = :ROL_ID";

        private static string sqlListarFaltas = @"SELECT EMP_ID, ROL_ID_GEN, DIA_ID, DIA_FEC_NOVEDAD, DIA_FEC_INGRESO, DIA_PERMISOINJUST, DIA_FALTAINJUSTI, DIA_FALTAJUSTIFI, DIA_PERMISOJUST, DIA_OTRODESCUN, DIA_OTRODESCNADA, DIA_OBS, ROL_REPRO 
                                                  FROM DESARROLLO.DAT_DIA_FALTA WHERE EMP_ID=:EMP_ID AND ROL_ID_GEN=:ROL_ID_GEN AND ROL_REPRO=:ROL_REPRO";
        private static string sqlGeneraCodigoFalta = @"SELECT COUNT(*)+1 FROM DESARROLLO.DAT_DIA_FALTA WHERE EMP_ID=:EMP_ID AND ROL_ID_GEN=:ROL_ID_GEN AND ROL_REPRO=:ROL_REPRO";

        private static string sqlRegistrarFaltas = @"INSERT INTO DESARROLLO.DAT_DIA_FALTA ( DIA_ID,
                                                                                            EMP_ID,
                                                                                            ROL_ID_GEN,
                                                                                            ROL_REPRO,
                                                                                            DIA_FEC_NOVEDAD,
                                                                                            DIA_FEC_INGRESO,
                                                                                            DIA_PERMISOINJUST,
                                                                                            DIA_FALTAINJUSTI,
                                                                                            DIA_FALTAJUSTIFI,
                                                                                            DIA_PERMISOJUST,
                                                                                            DIA_OTRODESCUN,
                                                                                            DIA_OTRODESCNADA,
                                                                                            DIA_OBS
                                                                                           )
                                                                                    VALUES ( :DIA_ID 
                                                                                            ,:EMP_ID
                                                                                            ,:ROL_ID_GEN
                                                                                            ,:ROL_REPRO
                                                                                            ,:DIA_FEC_NOVEDAD
                                                                                            ,SYSDATE
                                                                                            ,:DIA_PERMISOINJUST
                                                                                            ,:DIA_FALTAINJUSTI
                                                                                            ,:DIA_FALTAJUSTIFI
                                                                                            ,:DIA_PERMISOJUST
                                                                                            ,:DIA_OTRODESCUN
                                                                                            ,:DIA_OTRODESCNADA
                                                                                            ,:DIA_OBS                                                                                            
                                                                                            )";
        private static string sqlActualizaFaltas = @"UPDATE DESARROLLO.DAT_DIA_FALTA
                                                    SET    DIA_FEC_NOVEDAD   = :DIA_FEC_NOVEDAD,
                                                           DIA_FEC_INGRESO   = SYSDATE,
                                                           DIA_PERMISOINJUST = :DIA_PERMISOINJUST,
                                                           DIA_FALTAINJUSTI  = :DIA_FALTAINJUSTI,
                                                           DIA_FALTAJUSTIFI  = :DIA_FALTAJUSTIFI,
                                                           DIA_PERMISOJUST   = :DIA_PERMISOJUST,
                                                           DIA_OTRODESCUN    = :DIA_OTRODESCUN,
                                                           DIA_OTRODESCNADA  = :DIA_OTRODESCNADA,
                                                           DIA_OBS           = :DIA_OBS                                                           
                                                    WHERE  EMP_ID            = :EMP_ID
                                                    AND    ROL_ID_GEN        = :ROL_ID_GEN
                                                    AND    ROL_REPRO         = :ROL_REPRO
                                                    AND    DIA_ID            = :DIA_ID";
        private static string sqlListarPermisoTipo = "SELECT TIP_ID, TIP_NOMBRE, TIP_OBS, TIP_TIPO FROM DESARROLLO.DAT_TIP_PER ORDER BY 2 DESC";
        private static string sqlListarTipo = "SELECT TIP_TIPO, TIP_NOMBRE FROM DESARROLLO.DAT_TIP_TIPO ORDER BY 1 DESC";
        private static string sqlRegistraPermiso = @"INSERT INTO DESARROLLO.DAT_PER (
                                                       EMP_ID, TIP_ID, LOC_ID, 
                                                       ESC_ID, PER_ID, PER_FEC_REG, 
                                                       PER_FEC_INI, PER_FEC_FIN, PER_OBS, 
                                                       PER_DIA, PER_NUM_HOR, PER_NUM_MIN, 
                                                       PER_RES, PER_HOR_INI, PER_HOR_FIN) 
                                                    VALUES ( :EMP_ID,
                                                     :TIP_ID,
                                                     :LOC_ID,
                                                     :ESC_ID,
                                                     :PER_ID,
                                                     SYSDATE,
                                                     :PER_FEC_INI,
                                                     :PER_FEC_FIN,
                                                     :PER_OBS,
                                                     :PER_DIA,
                                                     :PER_NUM_HOR,
                                                     :PER_NUM_MIN,
                                                     :PER_RES,
                                                     :PER_HOR_INI,
                                                     :PER_HOR_FIN )";
        private static string sqlPermisoCodigo = "SELECT COUNT(PER_ID)+1 FROM DESARROLLO.DAT_PER WHERE EMP_ID=:EMP_ID";

        private static string sqlListarVacacion = @"SELECT EMP_ID, CAB_VAC_ID, EMP_CON_ID, VAC_PER_DADO, CAB_VAC_DIAS, CAB_VAC_DIAS_PAG, 
                                                           CAB_VAC_DIAS_PEN, CAB_VAC_DIAS_ADI,trunc(CAB_VAC_VAL,4)CAB_VAC_VAL, 
                                                           CAB_VAC_VAL_PAG, trunc(CAB_VAC_VAL_PEN,4)CAB_VAC_VAL_PEN, CAB_VAC_ESTADO, 
                                                           FECHACREACION, FECHAMODIF, CAB_VAC_OBS, 
                                                           CAB_VAC_FECINI, CAB_VAC_FECFIN
                                                    FROM DESARROLLO.DAT_CAB_VAC WHERE EMP_ID=:EMP_ID ORDER BY VAC_PER_DADO";
        private static string sqlListarVacacionDT = @"SELECT 
                                                           EMP_ID, CAB_VAC_ID, EMP_CON_ID, 
                                                           DET_VAC_ID, ESC_ID, LOC_ID, 
                                                           DET_FECHA_INI, DET_FECHA_FIN, DET_DIAS, 
                                                           TRUNC(DET_VALOR,4) DET_VALOR, DET_OBSERV, VAC_AUTORIZADO, 
                                                           DET_ESTADO, FECHACREACION, FECHAMODIF, 
                                                           VAC_ID_ANT,(SELECT NOMBRE FROM V_DETALLE_EMP WHERE EMP_ID=VAC_AUTORIZADO)AUTORIZADO,
                                                           DESARROLLO.PK_FUNCTIONTCG.F_FINSEMANADIA(DET_FECHA_INI,DET_FECHA_FIN) FINSEMANA,DESARROLLO.PK_FUNCTIONTCG.F_FINSEMANA(DET_FECHA_INI,DET_FECHA_FIN) FIN
                                                        FROM DESARROLLO.DAT_DET_VAC
                                                        where EMP_ID=:EMP_ID
                                                        and CAB_VAC_ID=:CAB_VAC_ID
                                                        and EMP_CON_ID=:EMP_CON_ID";
        private static string sqlRegistraVacacion = @"INSERT INTO DESARROLLO.DAT_DET_VAC (
                                                       EMP_ID, CAB_VAC_ID, EMP_CON_ID, 
                                                       DET_VAC_ID, ESC_ID, LOC_ID, 
                                                       DET_FECHA_INI, DET_FECHA_FIN, DET_DIAS, 
                                                       DET_VALOR, DET_OBSERV, VAC_AUTORIZADO, 
                                                       DET_ESTADO, FECHACREACION, --FECHAMODIF, 
                                                       VAC_ID_ANT) 
                                                    VALUES (:EMP_ID,
                                                    :CAB_VAC_ID,
                                                    :EMP_CON_ID,
                                                    :DET_VAC_ID,
                                                    :ESC_ID,
                                                    :LOC_ID,
                                                    :DET_FECHA_INI,
                                                    :DET_FECHA_FIN,
                                                    :DET_DIAS,
                                                    :DET_VALOR,
                                                    :DET_OBSERV,
                                                    :VAC_AUTORIZADO,
                                                    :DET_ESTADO,
                                                    SYSDATE,
                                                    --:FECHAMODIF,
                                                    :VAC_ID_ANT )";
        private static string sqlVacacionDTCodigo = "SELECT COUNT(DET_VAC_ID)+1 FROM DESARROLLO.DAT_DET_VAC WHERE EMP_ID=:EMP_ID AND EMP_CON_ID=:EMP_CON_ID AND CAB_VAC_ID=:CAB_VAC_ID ";
        private static string sqlVerificaQuincena = " SELECT Count(*) FROM DESARROLLO.dat_rol_seg  WHERE seg_rol_id=desarrollo.F_Ultimo_periodo AND  seg_rol_repro=1 AND seg_est_quin=1 ";
        private static string sqlCargaQuincenaPR = "DESARROLLO.P_CARGA_QUINCENA";
        private static string sqlEstadoRol = "SELECT PK_NOMINATCG.F_ESTADOROL(:perID,:reproID) FROM DUAL";
        private static string sqlMesRol = "SELECT DESARROLLO.F_MES_CALCULADO(:perID) FROM DUAL";
        private static string sqlRegistarDetalleRol = @"INSERT INTO DESARROLLO.DAT_DET_ROL(ROL_ID, EMP_ID, ROL_ID_GEN, DET_ROL_ID, DET_ROL_VALOR, DET_ROL_FECHA, ROL_REPRO, DET_ROL_AUDIT)
                                                                          VALUES(:ROL_ID, :EMP_ID, :ROL_ID_GEN, :DET_ROL_ID, :DET_ROL_VALOR, SYSDATE, :ROL_REPRO, :DET_ROL_AUDIT)";
        private static string sqlDeleteDetalleRol = @"
                                                        DELETE DESARROLLO.DAT_DET_ROL
                                                         WHERE     EMP_ID = :EMP_ID
                                                               AND ROL_ID_GEN = :ROL_ID_GEN
                                                               AND ROL_REPRO = :ROL_REPRO
                                                               AND ROL_ID = :ROL_ID
                                                               AND DET_ROL_ID = :DET_ROL_ID";
        private static string sqlUpdateDetalleRol = @"
                                                        UPDATE DESARROLLO.DAT_DET_ROL
                                                           SET --ROL_ID = :ROL_ID,
                                                               --EMP_ID = :EMP_ID,
                                                               --ROL_ID_GEN = :ROL_ID_GEN,
                                                               --DET_ROL_ID = :DET_ROL_ID,
                                                               DET_ROL_VALOR = :DET_ROL_VALOR
                                                               --DET_ROL_FECHA = :DET_ROL_FECHA,
                                                               --ROL_REPRO = :ROL_REPRO,
                                                               --DET_ROL_AUDIT = :DET_ROL_AUDIT,
                                                               --DET_ROL_AUDIT2 = :DET_ROL_AUDIT2
                                                         WHERE     EMP_ID = :EMP_ID
                                                               AND ROL_ID_GEN = :ROL_ID_GEN
                                                               AND ROL_REPRO = :ROL_REPRO
                                                               AND ROL_ID = :ROL_ID
                                                               AND DET_ROL_ID = :DET_ROL_ID ";
        private static string sqlVerificaDetalleRol_ES = @"
                                                        SELECT COUNT(1) FROM DESARROLLO.DAT_DET_ROL_ESP
                                                         WHERE     EMP_ID = :EMP_ID
                                                               AND ROL_ID_GEN = :ROL_ID_GEN
                                                               AND ROL_REPRO = :ROL_REPRO
                                                               AND ROL_ID = :ROL_ID
                                                               AND DET_ROL_ID = :DET_ROL_ID
                                                               ";
        private static string sqlDeleteDetalleRol_ES = @"
                                                        DELETE DESARROLLO.DAT_DET_ROL_ESP
                                                         WHERE     EMP_ID = :EMP_ID
                                                               AND ROL_ID_GEN = :ROL_ID_GEN
                                                               AND ROL_REPRO = :ROL_REPRO
                                                               AND ROL_ID = :ROL_ID
                                                               AND DET_ROL_ID = :DET_ROL_ID
                                                               AND ESP_ID = :ESP_ID";
        private static string sqlDeleteDetalleRol_ES2 = @"
                                                        DELETE DESARROLLO.DAT_DET_ROL_ESP
                                                         WHERE     EMP_ID = :EMP_ID
                                                               AND ROL_ID_GEN = :ROL_ID_GEN
                                                               AND ROL_REPRO = :ROL_REPRO
                                                               AND ROL_ID = :ROL_ID
                                                               AND DET_ROL_ID = :DET_ROL_ID
                                                               ";
        private static string sqlUpdateDetalleRol_ES = @"
                                                        UPDATE DESARROLLO.DAT_DET_ROL_ESP
                                                           SET --ROL_ID = :ROL_ID,
                                                               --EMP_ID = :EMP_ID,
                                                               --ROL_ID_GEN = :ROL_ID_GEN,
                                                               --DET_ROL_ID = :DET_ROL_ID,
                                                               --ESP_ID = :ESP_ID,
                                                               --LOC_ID = :LOC_ID,
                                                               ESP_VALOR = :ESP_VALOR,
                                                               --ESP_FECHA_ING = :ESP_FECHA_ING,
                                                               ESP_FECHA_REP = SYSDATE,--:ESP_FECHA_REP,
                                                               ESP_OBS = :ESP_OBS,
                                                               --ROL_REPRO = :ROL_REPRO,
                                                               ESP_AUDIT = :ESP_AUDIT
                                                         WHERE     EMP_ID = :EMP_ID
                                                               AND ROL_ID_GEN = :ROL_ID_GEN
                                                               AND ROL_REPRO = :ROL_REPRO
                                                               AND ROL_ID = :ROL_ID
                                                               AND DET_ROL_ID = :DET_ROL_ID
                                                               AND ESP_ID = :ESP_ID";

        private static string sqlRegistrateDetalleRol_ES = @"
                                                            INSERT INTO DESARROLLO.DAT_DET_ROL_ESP (ROL_ID,
                                                                                                    EMP_ID,
                                                                                                    ROL_ID_GEN,
                                                                                                    DET_ROL_ID,
                                                                                                    ESP_ID,
                                                                                                    LOC_ID,
                                                                                                    ESP_VALOR,
                                                                                                    ESP_FECHA_ING,
                                                                                                    --ESP_FECHA_REP,
                                                                                                    ESP_OBS,
                                                                                                    ROL_REPRO,
                                                                                                    ESP_AUDIT)
                                                                 VALUES (:ROL_ID
                                                                         ,:EMP_ID
                                                                         ,:ROL_ID_GEN
                                                                         ,:DET_ROL_ID
                                                                         ,:ESP_ID
                                                                         ,:LOC_ID
                                                                         ,:ESP_VALOR
                                                                         ,SYSDATE--:ESP_FECHA_ING
                                                                         --,:ESP_FECHA_REP
                                                                         ,:ESP_OBS
                                                                         ,:ROL_REPRO
                                                                         ,:ESP_AUDIT
                                                                         )";
        private static string sqlRegistraDetalleRolCod_ES = @"
                                                                SELECT COUNT(1)+1 FROM DESARROLLO.DAT_DET_ROL_ESP                                                           
                                                                 WHERE     EMP_ID = :EMP_ID
                                                                       AND ROL_ID_GEN = :ROL_ID_GEN
                                                                       AND ROL_REPRO = :ROL_REPRO
                                                                       AND ROL_ID = :ROL_ID
                                                                       AND DET_ROL_ID = :DET_ROL_ID
                                                                       --AND ESP_ID = :ESP_ID
";

        private static string sqlVerificaRol = "SELECT COUNT(1) FROM DESARROLLO.DAT_ROL WHERE ROL_STDO=1 AND EMP_ID=:EMP_ID AND ROL_ID_GEN=:ROL_ID_GEN AND ROL_REPRO=:ROL_REPRO";
        private static string sqlEstadoEdicionRol = "UPDATE DESARROLLO.DAT_ROL SET ROL_STDO=1 WHERE EMP_ID=:EMP_ID AND ROL_ID_GEN=:ROL_ID_GEN AND ROL_REPRO=:ROL_REPRO";
        private static string sqlCargaPeriodoVacacion = "DESARROLLO.P_CARGA_PER_VAC";
        private static string sqlActualizaSalidaEmp = @"UPDATE DESARROLLO.DAT_DET_ING_EMP
                                                           SET ING_FEC_SAL_REAL = :FEC_LIQUI,
                                                               ING_FEC_SAL_DIF = :FEC_SALIDA
                                                         WHERE     EMP_ID = :EMP_ID
                                                               AND ING_ID = (SELECT MAX (ING_ID)
                                                                               FROM DESARROLLO.DAT_DET_ING_EMP
                                                                              WHERE EMP_ID = :EMPT_ID)";
        private static string sqlActualizaSalidaEmp2 = "UPDATE DESARROLLO.DAT_EMP SET EMP_FEC_SALIDAREAL = :FEC_SALIDA, EMP_FEC_SALIDA = :FEC_SALIDA WHERE EMP_ID=:EMP_ID";
        private static string sqlActualizaSalidaEmp3 = "desarrollo.p_registra_salida_emp";
        private static string sqlContratoTipoI = "INSERT INTO DESARROLLO.DAT_CONTRATO (CON_ID, CON_NOMBRE, CON_DESC)VALUES (:CON_ID,:CON_NOMBRE,:CON_DESC) ";
        private static string sqlContratoTipoU = "UPDATE DESARROLLO.DAT_CONTRATO SET CON_NOMBRE=:CON_NOMBRE, CON_DESC=:CON_DESC WHERE CON_ID=:CON_ID";
        private static string sqlPermisoTipoI = "INSERT INTO DESARROLLO.DAT_TIP_PER (TIP_ID, TIP_NOMBRE, TIP_OBS, TIP_TIPO)VALUES (:TIP_ID, :TIP_NOMBRE, :TIP_OBS, :TIP_TIPO) ";
        private static string sqlPermisoTipoU = "UPDATE DESARROLLO.DAT_TIP_PER SET TIP_NOMBRE=:TIP_NOMBRE, TIP_OBS=:TIP_OBS, TIP_TIPO=:TIP_TIPO WHERE TIP_ID=:TIP_ID";
        private static string sqlContratoID = "SELECT NVL(MAX(CON_ID),0)+1 FROM DESARROLLO.DAT_CONTRATO";
        //private static string sqlPermisoID = "SELECT NVL(MAX(TIP_ID),0)+1 FROM DESARROLLO.DAT_TIP_PER";
        private static string sqlContratoFinI = "INSERT INTO DESARROLLO.DAT_CON_CAUSA (CON_CAU_ID, CON_CAU_CAUSA, CON_CAU_ABREV, CON_CAU_FECHACREACION) VALUES(:CON_CAU_ID,:CON_CAU_CAUSA,:CON_CAU_ABREV,SYSDATE) ";
        private static string sqlContratoFinU = "UPDATE DESARROLLO.DAT_CON_CAUSA SET CON_CAU_CAUSA = :CON_CAU_CAUSA, CON_CAU_ABREV = :CON_CAU_ABREV, CON_CAU_FECHACREACION = SYSDATE WHERE CON_CAU_ID = :CON_CAU_ID ";
        private static string sqlContratoFinID = "SELECT NVL(MAX(CON_CAU_ID),0)+1 FROM DESARROLLO.DAT_CON_CAUSA ";
        private static string sqlValoresGrupoRol = @"
                                                    SELECT PATRONO,
                                                           NOMBRE,
                                                           V_DETALLE_EMP.EMP_ID, 0 CANTIDAD,
                                                           0     AS VALOR,
                                                           LOC_ID
                                                      FROM DESARROLLO.V_DETALLE_EMP
                                                     WHERE     PAT_ID LIKE ''||:PAT_ID||'%'
                                                           AND LOC_ID LIKE ''||:LOC_ID||'%'
                                                           AND ESC_ID LIKE ''||:ESC_ID||'%'
                                                           AND EMP_ID LIKE ''||:EMP_ID||'%'
                                                           AND LAB_ESTADO = 1";
        private static string sqlRegistraValorGrupoRol = "DESARROLLO.P_CARGA_VALOR_ROL_ESP";
        private static string sqlProcesaDatoIESS = "P_PROCESA_DATO_IESS";
        private static string sqlGeneraDatoIESS = "P_GENERA_DATO_IESS";
        private static string sqlListoDatoIESS = "SELECT IND_ID, DETALLE, IND_COL FROM DESARROLLO.DAT_ROL_IND ";
        private static string sqlFinContratoEmpleadoU = @"UPDATE DESARROLLO.DAT_EMP_CON
                                                           SET EMP_CON_OBS = :EMP_OBS
                                                         WHERE EMP_ID = :EMP_ID AND EMP_CON_ID = :EMP_CON_ID";
        private static string sqlFinContratoEmpleadoDT = @"UPDATE DESARROLLO.DAT_DET_LIQ
                                                           SET DET_LIQ_REF = :DET_LIQ_REF,
                                                               DET_LIQ_VALOR = :DET_LIQ_VALOR,
                                                               DET_LIQ_OBS = :DET_LIQ_OBS
                                                         WHERE RUB_LIQ_ID = :RUB_LIQ_ID AND EMP_ID = :EMP_ID AND LIQ_ID = :LIQ_ID";
        private static string sqlFinContratoEmpleado = @"
                                                        SELECT (SELECT PAT_RAZ_SOCIAL
                                                                  FROM DESARROLLO.DAT_PATRONO
                                                                 WHERE PAT_ID = E.PAT_ID) PATRONO,
                                                               (SELECT CON_CAU_CAUSA
                                                                  FROM DESARROLLO.DAT_CON_CAUSA
                                                                 WHERE CON_CAU_ID = E.CON_CAU_ID) CAUSA,
                                                               DECODE(EMP_CON_FIRM_RENU,1,'SI',0,'NO') FIRMA,
                                                               DECODE (EMP_CON_RAZON_SALE,  'P', 'Positiva',  'N', 'Negativa') RAZON,
                                                               EMP_CON_OBS, EMP_CON_ID
                                                          FROM DESARROLLO.DAT_EMP_CON E
                                                         WHERE     EMP_ID = :EMP_ID
                                                               AND PAT_ID IS NOT NULL
                                                               AND EMP_CON_ID = (SELECT MAX (EMP_CON_ID)
                                                                                   FROM DESARROLLO.DAT_EMP_CON
                                                                                  WHERE EMP_ID = :EMP_ID)";
        private static string sqlLiquidacionEmpleado = @"
                                                        SELECT ROWNUM ID,
                                                           EMP_ID, LIQ_ID, ESC_ID,(SELECT ESC_CARGOIESS  FROM DESARROLLO.DAT_ESC
                                                                                    WHERE ESC_ID = L.ESC_ID)CARGO_IESS, 
                                                           LIQ_FEC_ING, LIQ_FEC_SAL, LIQ_REM_ACT, 
                                                           LIQ_FEC_REG, LIQ_RESP, DIA_ID, 
                                                           PERC_ID, CLI_ID,
                                                            (SELECT MAX (SEG_ROL_ID)
                                                                      FROM DESARROLLO.DAT_ROL_SEG
                                                                     WHERE     SEG_ROL_ESTADO = 1
                                                                           AND TO_DATE (TO_CHAR (ROL_FECHA_INI, 'DD/MON/RRRR')) <=
                                                                               LIQ_FEC_SAL)                 PER_ID,
                                                                   (SELECT SEG_ROL_REPRO
                                                                      FROM DESARROLLO.DAT_ROL_SEG
                                                                     WHERE     SEG_ROL_ESTADO = 1
                                                                           AND SEG_ROL_ID =
                                                                               (SELECT MAX (SEG_ROL_ID)
                                                                                  FROM DESARROLLO.DAT_ROL_SEG
                                                                                 WHERE     SEG_ROL_ESTADO = 1
                                                                                       AND TO_DATE (TO_CHAR (ROL_FECHA_INI, 'DD/MON/RRRR')) <=
                                                                                           LIQ_FEC_SAL))    REPRO_ID
                                                        FROM DESARROLLO.DAT_LIQ L WHERE EMP_ID=:EMP_ID";
        private static string sqlLiquidacionEmpleadoDT = @"
                                                           SELECT ROWNUM ID_DT, EMP_ID,
                                                                   LIQ_ID,
                                                                   RUB_LIQ_ID,(SELECT RUB_LIQ_DES FROM desarrollo.dat_rub_liq WHERE RUB_LIQ_ID=D.RUB_LIQ_ID) RUBRO,
                                                                   DET_LIQ_REF,
                                                                   TRUNC (DET_LIQ_VALOR, 2)DET_LIQ_VALOR,
                                                                   DET_LIQ_OBS
                                                              FROM DESARROLLO.DAT_DET_LIQ D
                                                            Where EMP_ID = :EMP_ID
                                                            And   LIQ_ID = :LIQ_ID";
        private static string sqlPeriodoDiario = "SELECT DESARROLLO.PK_TRANS_CONT.F_PER_CONT_ACTIVO(:PERC_ID) FROM DUAL";
        #endregion

        #region Properties
        private ConnectionDDBB db { get; set; }
        #endregion

        #region Methods

        public int VerificaPeridoDiario(string perID)
        {
            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":PERC_ID", perID)
                };
            return db.GetEntero(sqlPeriodoDiario, prm);
        }

        public DataSet AsientoLiquidacion(string diaID, string cliID, string percID, string patID)
        {
            DataSet content = new DataSet();
            DataTable data = new DataTable();
            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":DIA_ID", diaID),
                    new OracleParameter(":CLI_ID", cliID),
                    new OracleParameter(":PERC_ID", percID),
                    new OracleParameter(":PAT_ID", patID )
                };
            data = db.GetData(sqlAsientoLiquidacion, prm).Copy();
            data.TableName = "Master";
            content.Tables.Add(data);
            prm = new OracleParameter[]
            {
                    new OracleParameter(":DIA_ID", diaID),
                    new OracleParameter(":PERC_ID", percID ),
                    new OracleParameter(":PAT_ID", patID)
            };
            data = db.GetData(sqlAsientoLiquidacionDT, prm).Copy();
            data.TableName = "Detail";
            content.Tables.Add(data);
            return content;
        }

        public DataTable GeneraDatosIESS(string perID, string reproID, string tipoID, string fechaIni, string fechaFin)
        {
            OracleParameter[] prm = new OracleParameter[]{
                    new OracleParameter(":P_PERIODO", perID ),
                    new OracleParameter(":P_REPROCESO", reproID ),
                    new OracleParameter(":P_TIPO_NOV", tipoID ),
                    new OracleParameter(":P_FECHA_INI", Convert.ToDateTime(fechaIni).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))),
                    new OracleParameter(":P_FECHA_FIN", Convert.ToDateTime(fechaFin).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")))
                };
            db.ExecProcedure(sqlProcesaDatoIESS, prm);
            db.ExecProcedure(sqlGeneraDatoIESS, prm);
            return db.GetData(sqlListoDatoIESS);
        }

        public int RegistraValorGrupoRol(ValorGrupo valorGrupo)
        {
            try
            {
                int perID = db.GetEntero("SELECT MAX (SEG_ROL_ID) FROM DESARROLLO.DAT_ROL_SEG ");
                string sysdateServer = db.GetString("SELECT SYSDATE FROM DUAL");
                OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":PER_ID", perID),
               new OracleParameter(":EMP_ID", valorGrupo.empID),
               new OracleParameter(":ROL_ID", valorGrupo.cuentaID ),
               new OracleParameter(":VALOR", valorGrupo.valor ),
               new OracleParameter(":OBSERV", "VALOR FIJO" ),
               new OracleParameter(":FECHA",  OracleDbType.Date){Value = Convert.ToDateTime(sysdateServer).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))},
               new OracleParameter(":LOC_ID", valorGrupo.localID )
            };
                db.ExecProcedure(sqlRegistraValorGrupoRol, prm);
            }
            catch (Exception e)
            {
                Logger.ErrorLog.ErrorRoutine(false, e);
                throw new System.ArgumentException(e.Message);

            }
            return 1;
        }
        public DataTable ValorGrupoRol(ValorGrupo valorGrupo)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":PAT_ID", valorGrupo.patID ),
               new OracleParameter(":LOC_ID", valorGrupo.localID ),
               new OracleParameter(":ESC_ID", valorGrupo.cargoID ),
               new OracleParameter(":EMP_ID", valorGrupo.empID )
            };//sqlValoresGrupoRol
            //return db.GetData("SELECT * FROM DAT_EMP WHERE EMP_ID LIKE '%'||:PAT_ID||''", prm);
            return db.GetData(sqlValoresGrupoRol, prm);
        }

        private int ContratoTipoID()
        {
            return db.GetEntero(sqlContratoID);
        }
        private int PermisoTipoID()
        {
            return db.GetEntero(sqlContratoID);
        }
        private int ContratoFinID()
        {
            return db.GetEntero(sqlContratoFinID);
        }
        public int RegistraContratoFin(int idContrato, string nombre, string Descripcion, int tipo)
        {
            int pkCode = idContrato;
            if (tipo.Equals(0))
            {
                OracleParameter[] prm = new OracleParameter[]{
                    new OracleParameter(":CON_CAU_ID",  pkCode = ContratoFinID()),
                    new OracleParameter(":CON_CAU_CAUSA", nombre),
                    new OracleParameter(":CON_CAU_ABREV",Descripcion)};

                if (!db.ExecQuery(sqlContratoFinI, prm).Equals(1))
                    pkCode = 0;
            }
            else
            {
                OracleParameter[] prm = new OracleParameter[]{
                    new OracleParameter(":CON_CAU_CAUSA", nombre),
                    new OracleParameter(":CON_CAU_ABREV",Descripcion),
                    new OracleParameter(":CON_CAU_ID",  idContrato)
                };

                if (!db.ExecQuery(sqlContratoFinU, prm).Equals(1))
                    pkCode = 0;
            }

            return pkCode;
        }

        public int RegistraContratoTipo(int idContrato, string nombre, string Descripcion, int tipo)
        {
            int pkCode = idContrato;
            if (tipo.Equals(0))
            {
                OracleParameter[] prm = new OracleParameter[]{
                    new OracleParameter(":CON_ID",  pkCode = ContratoTipoID()),
                    new OracleParameter(":CON_NOMBRE", nombre),
                    new OracleParameter(":CON_DESC",Descripcion)};

                if (!db.ExecQuery(sqlContratoTipoI, prm).Equals(1))
                    pkCode = 0;
            }
            else
            {
                OracleParameter[] prm = new OracleParameter[]{
                    new OracleParameter(":CON_NOMBRE", nombre),
                    new OracleParameter(":CON_DESC",Descripcion),
                    new OracleParameter(":CON_ID",  idContrato)
                };

                if (!db.ExecQuery(sqlContratoTipoU, prm).Equals(1))
                    pkCode = 0;
            }

            return pkCode;
        }
        public int RegistraPermisoTipo(int idContrato, string nombre, string Descripcion, int tipoID, int tipo)
        {
            int pkCode = idContrato;
            if (tipo.Equals(0))
            {
                OracleParameter[] prm = new OracleParameter[]{
                    new OracleParameter(":TIP_ID",  pkCode = PermisoTipoID()),
                     new OracleParameter(":TIP_NOMBRE", nombre),
                    new OracleParameter(":TIP_OBS",Descripcion),
                    new OracleParameter(":TIP_TIPO",tipoID)};

                if (!db.ExecQuery(sqlPermisoTipoI, prm).Equals(1))
                    pkCode = 0;
            }
            else
            {
                OracleParameter[] prm = new OracleParameter[]{
                    new OracleParameter(":TIP_NOMBRE", nombre),
                    new OracleParameter(":TIP_OBS",Descripcion),
                    new OracleParameter(":TIP_TIPO",tipoID),
                    new OracleParameter(":TIP_ID",  idContrato)
                };

                if (!db.ExecQuery(sqlPermisoTipoU, prm).Equals(1))
                    pkCode = 0;
            }

            return pkCode;
        }

        public int RegistraDetalleRol(List<DetRolEntity> detRol)
        {
            string empID = string.Empty, rolID = string.Empty, reproID = string.Empty;
            foreach (var item in detRol)
            {
                empID = item.empId.ToString();
                rolID = item.rolIdGen.ToString();
                reproID = item.rolRepro.ToString();
                OracleParameter[] prm = new OracleParameter[]{
                    new OracleParameter(":ROL_ID", item.rolId),
                    new OracleParameter(":EMP_ID",  item.empId),
                    new OracleParameter(":ROL_ID_GEN", item.rolIdGen),
                    new OracleParameter(":DET_ROL_ID", item.detRolId),
                    new OracleParameter(":DET_ROL_VALOR", item.detRolValor),
                    new OracleParameter(":ROL_REPRO", item.rolRepro),
                    new OracleParameter(":DET_ROL_AUDIT", item.detRolAudit)
                };
                db.ExecQuery(sqlRegistarDetalleRol, prm);
            }
            EstadoEdicionRol(empID, rolID, reproID);
            return 1;//db.ExecQuery(sqlRegistarDetalleRol, prm);
        }

        public int EstadoEdicionRol(string empID, string rolID, string reproID)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID",  empID),
               new OracleParameter(":ROL_ID_GEN", rolID),
               new OracleParameter(":ROL_REPRO",reproID)

            };
            return db.GetEntero(sqlEstadoEdicionRol, prm);
        }

        public int VerificaRol(string empID, string rolID, string reproID)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID",  empID),
               new OracleParameter(":ROL_ID_GEN", rolID),
               new OracleParameter(":ROL_REPRO",reproID)

            };
            return db.GetEntero(sqlVerificaRol, prm);
        }

        public int EliminaDetalleRol(DetRolEntity detRol)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID",  detRol.empId ),
               new OracleParameter(":ROL_ID_GEN", detRol.rolIdGen),
               new OracleParameter(":ROL_REPRO",detRol.rolRepro),
               new OracleParameter(":ROL_ID",detRol.rolId ),
               new OracleParameter(":DET_ROL_ID",detRol.detRolId)
            };

            if (db.GetEntero(sqlVerificaDetalleRol_ES, prm) > 0)
                db.ExecQuery(sqlDeleteDetalleRol_ES2, prm);

            return db.ExecQuery(sqlDeleteDetalleRol, prm);
        }


        public int EliminaDetalleRol_ES(DetRolEspEntity datos)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID",  datos.empId),
               new OracleParameter(":ROL_ID_GEN", datos.rolIdGen ),
               new OracleParameter(":ROL_REPRO",datos.rolRepro ),
               new OracleParameter(":ROL_ID",datos.rolId ),
               new OracleParameter(":DET_ROL_ID",datos.detRolId ),
               new OracleParameter(":ESP_ID",datos.espId )
            };
            return db.ExecQuery(sqlDeleteDetalleRol_ES, prm);
        }
        public int EliminaDetalleIngreso(List<DatDetRolLiq> datosIngreso)
        {
            foreach (var datos in datosIngreso)
            {
                OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":SEG_ROL_ID",datos.segRolId ),
               new OracleParameter(":SEG_ROL_REPRO",datos.segRolRepro ),
               new OracleParameter(":EMP_ID",datos.empId ),
               new OracleParameter(":ROL_ID",datos.rolId ),
               new OracleParameter(":ROL_LIQ_ID",datos.rolLiqId)
            };
                db.ExecQuery(sqlEliminaDetalleIngreso, prm);
            }
            return 1;
        }
        public int RegistraDetalleIngreso(List<DatDetRolLiq> datosIngreso)
        {
            foreach (var datos in datosIngreso)
            {
                OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":SEG_ROL_ID",datos.segRolId ),
               new OracleParameter(":SEG_ROL_REPRO",datos.segRolRepro ),
               new OracleParameter(":EMP_ID",datos.empId ),
               new OracleParameter(":ROL_ID",datos.rolId ),
               new OracleParameter(":ROL_LIQ_ID",  datos.segRolId.ToString()+datos.empId.ToString() ),
               new OracleParameter(":ROL_LIQ_VALOR", datos.rolLiqValor )
            };
                db.ExecQuery(sqlRegistraDetalleIngreso, prm);
            }
            return 1;
        }
        public int ActualizaDetalleDiario(List<DatDetDiario> datosIngreso, string tipoOp)
        {
            OracleParameter[] prm;
            int resp = 0;
            switch (tipoOp)
            {

                case "I":
                    foreach (var datos in datosIngreso)
                    {
                        prm = new OracleParameter[] {
                        new OracleParameter(":PERC_ID",  datos.percId),
                        new OracleParameter(":DIA_ID", datos.diaId),
                        new OracleParameter(":PAT_ID",  datos.patId)};
                        datos.ordImp = db.GetEntero(sqlOrdenImpresion, prm);

                        prm = new OracleParameter[] {
                        new OracleParameter(":CUE_ID",  datos.cueId),
                        new OracleParameter(":PERC_ID",  datos.percId),
                        new OracleParameter(":DIA_ID", datos.diaId),
                        new OracleParameter(":CLI_ID",datos.cliId  ),
                        new OracleParameter(":PAT_ID",  datos.patId)};
                        datos.detId = db.GetEntero(sqlIdDetalleDiaio, prm);

                        prm = new OracleParameter[]{
                       new OracleParameter(":CUE_ID",  datos.cueId),
                       new OracleParameter(":PERC_ID",  datos.percId  ),
                       new OracleParameter(":DIA_ID", datos.diaId  ),
                       new OracleParameter(":CLI_ID",datos.cliId  ),
                       new OracleParameter(":DET_DIA_DB",datos.detDiaDb  ),
                       new OracleParameter(":DET_DIA_HB",datos.detDiaHb  ),
                       //new OracleParameter(":DET_DIA_FEC_REG",datos.detDiaFecReg  ),
                       //new OracleParameter(":DET_DIA_FEC_MOD",datos.detDiaFecMod ),
                       new OracleParameter(":DET_DIA_CLI_SEG",  datos.cliId),
                       new OracleParameter(":PAT_ID",  datos.patId  ),
                       new OracleParameter(":DET_ID", datos.detId  ),
                       new OracleParameter(":ORD_IMP", datos.ordImp ),
                       new OracleParameter(":USU_CREA",datos.usuCrea  ),
                       //new OracleParameter(":USU_MODIF",datos.usuModif  ),
                       //new OracleParameter(":ANIO_PERC",datos.anioPerc  ),
                       new OracleParameter(":DET_OBSER",datos.detObser)};
                        resp = db.ExecQuery(sqlRegistraDetalleDiario, prm);
                    }
                    break;
                case "U":
                    foreach (var datos in datosIngreso)
                    {
                        prm = new OracleParameter[]{
                       new OracleParameter(":CUE_ID",  datos.cueId),
                       //new OracleParameter(":PERC_ID",  datos.percId  ),
                       //new OracleParameter(":DIA_ID", datos.diaId  ),
                       new OracleParameter(":CLI_ID",datos.cliId  ),
                       new OracleParameter(":DET_DIA_DB",datos.detDiaDb  ),
                       new OracleParameter(":DET_DIA_HB",datos.detDiaHb  ),
                       //new OracleParameter(":DET_DIA_FEC_REG",datos.detDiaFecReg  ),
                       //new OracleParameter(":DET_DIA_FEC_MOD",datos.detDiaFecMod ),
                       //new OracleParameter(":DET_DIA_CLI_SEG",  datos.detDiaCliSeg),
                       //new OracleParameter(":PAT_ID",  datos.patId  ),
                       //new OracleParameter(":DET_ID", datos.detId  ),
                       //new OracleParameter(":ORD_IMP",datos.ordImp  ),
                       //new OracleParameter(":USU_CREA",datos.usuCrea  ),
                       new OracleParameter(":USU_MODIF",datos.usuModif  ),
                       //new OracleParameter(":ANIO_PERC",datos.anioPerc  ),
                       //new OracleParameter(":DET_OBSER",datos.detObser ),
                       //--------------
                       new OracleParameter(":CUE_ID",  datos.cueId_),
                       new OracleParameter(":PERC_ID",  datos.percId),
                       new OracleParameter(":DIA_ID", datos.diaId),
                       new OracleParameter(":CLI_ID",datos.cliId_),
                       new OracleParameter(":PAT_ID",  datos.patId),
                       new OracleParameter(":DET_ID", datos.detId)};
                        resp = db.ExecQuery(sqlActualizaDetalleDiario, prm);
                    }
                    break;

                case "D":
                    foreach (var datos in datosIngreso)
                    {
                        prm = new OracleParameter[]{
                       new OracleParameter(":CUE_ID", datos.cueId),
                       new OracleParameter(":PERC_ID", datos.percId),
                       new OracleParameter(":DIA_ID", datos.diaId),
                       new OracleParameter(":CLI_ID", datos.cliId),
                       new OracleParameter(":PAT_ID", datos.patId),
                       new OracleParameter(":DET_ID", datos.detId)};
                        resp = db.ExecQuery(sqlEliminaDetalleDiario, prm);
                    }
                    break;
            }

            return resp;
        }
        public int ActualizaDetalleIngreso(List<DatDetRolLiq> datosIngreso)
        {
            foreach (var datos in datosIngreso)
            {
                OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":ROL_ID",  datos.rolId),
               new OracleParameter(":ROL_LIQ_ID",  datos.segRolId.ToString()+datos.empId.ToString() ),
               new OracleParameter(":ROL_LIQ_VALOR", datos.rolLiqValor ),
               new OracleParameter(":SEG_ROL_ID",datos.segRolId ),
               new OracleParameter(":SEG_ROL_REPRO",datos.segRolRepro ),
               new OracleParameter(":EMP_ID",datos.empId ),
               new OracleParameter(":ROL_ID",datos.rolId ),
               new OracleParameter(":ROL_LIQ_ID",datos.rolLiqId)
            };
                db.ExecQuery(sqlActualizaDetalleingreso, prm);
            }

            return 1;
        }

        public int ActualizaDetalleIngreso(string empID, string liqID, decimal ingreso, decimal egreso)
        {
            OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":VALOR",ingreso),
               new OracleParameter(":EMP_ID",empID ),
               new OracleParameter(":LIQ_ID",liqID ),
               new OracleParameter(":RUB_LIQ_ID",1 )
            };
            db.ExecQuery(sqlActualizaDetalleingresoCb, prm);

            prm = new OracleParameter[]{
                new OracleParameter(":VALOR",egreso ),
               new OracleParameter(":EMP_ID",empID ),
               new OracleParameter(":LIQ_ID",liqID ),
               new OracleParameter(":RUB_LIQ_ID",5 )
            };
            return db.ExecQuery(sqlActualizaDetalleingresoCb, prm);
        }


        public int ActualizaDetalleRol(DetRolEntity datos)
        {
            OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":DET_ROL_VALOR",  datos.detRolValor),
               new OracleParameter(":EMP_ID",  datos.empId),
               new OracleParameter(":ROL_ID_GEN", datos.rolIdGen),
               new OracleParameter(":ROL_REPRO",datos.rolRepro),
               new OracleParameter(":ROL_ID",datos.rolId),
               new OracleParameter(":DET_ROL_ID",datos.detRolId)
            };
            return db.ExecQuery(sqlUpdateDetalleRol, prm);
        }

        public int ActualizaDetalleRol_ES(DetRolEspEntity datos)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":ESP_VALOR",  datos.espValor ),
               new OracleParameter(":ESP_OBS", datos.espObs ),
               new OracleParameter(":ESP_AUDIT",datos.espAudit ),
               new OracleParameter(":EMP_ID",  datos.empId),
               new OracleParameter(":ROL_ID_GEN", datos.rolIdGen ),
               new OracleParameter(":ROL_REPRO",datos.rolRepro ),
               new OracleParameter(":ROL_ID",datos.rolId ),
               new OracleParameter(":DET_ROL_ID",datos.detRolId ),
               new OracleParameter(":ESP_ID",datos.espId )
            };
            return db.ExecQuery(sqlUpdateDetalleRol_ES, prm);
        }

        public int RegistraDetalleRol_ES(DetRolEspEntity datos)
        {
            OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":EMP_ID",  datos.empId),
                new OracleParameter(":ROL_ID_GEN", datos.rolIdGen ),
                new OracleParameter(":ROL_REPRO",datos.rolRepro ),
                new OracleParameter(":ROL_ID",datos.rolId ),
                new OracleParameter(":DET_ROL_ID",datos.detRolId )
                          //new OracleParameter(":ESP_ID",datos.espId )
            };
            datos.espId = db.GetEntero(sqlRegistraDetalleRolCod_ES, prm);

            prm = new OracleParameter[]{
                new OracleParameter(":ROL_ID",datos.rolId ),
                new OracleParameter(":EMP_ID",  datos.empId),
                new OracleParameter(":ROL_ID_GEN", datos.rolIdGen ),
                new OracleParameter(":DET_ROL_ID",datos.detRolId ),
                new OracleParameter(":ESP_ID",datos.espId ),
                new OracleParameter(":LOC_ID",datos.locId ),
                new OracleParameter(":ESP_VALOR",  datos.espValor ),
               new OracleParameter(":ESP_OBS", datos.espObs ),
               new OracleParameter(":ROL_REPRO",datos.rolRepro ),
               new OracleParameter(":ESP_AUDIT",datos.espAudit )
            };
            return db.ExecQuery(sqlRegistrateDetalleRol_ES, prm);
        }

        public string MesRol(string perID)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":perID", perID)
            };
            return db.GetString(sqlMesRol, prm);
        }
        public string EstadoRol(string perID, string reproID)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":perID", perID),
               new OracleParameter(":reproID", reproID)
            };
            return db.GetString(sqlEstadoRol, prm);
        }

        public int CargaQuincena()
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter("OUT_Q",OracleDbType.Int16, ParameterDirection.Output)
            };
            return db.ExecProcedureOUT(sqlCargaQuincenaPR, prm);
        }

        public int VerificaQuincena()
        {
            return db.GetEntero(sqlVerificaQuincena);
        }

        private int GeneraCodigoVacacion(string empID, int conID, int vacID)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID", empID),
               new OracleParameter(":EMP_CON_ID", conID),
               new OracleParameter(":CAB_VAC_ID", vacID)
            };
            return db.GetEntero(sqlVacacionDTCodigo, prm);
        }

        public int RegistraVacacionEmpleado(DatDetVac VacacionEmp)
        {
            int pkCode = 0;
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID", VacacionEmp.empID),
               new OracleParameter(":CAB_VAC_ID", VacacionEmp.vacId),
               new OracleParameter(":EMP_CON_ID", VacacionEmp.empConId),
               new OracleParameter(":DET_VAC_ID", pkCode=GeneraCodigoVacacion(VacacionEmp.empID,VacacionEmp.empConId, VacacionEmp.vacId)),
               new OracleParameter(":ESC_ID", VacacionEmp.escId),
               new OracleParameter(":LOC_ID", VacacionEmp.locId),
               new OracleParameter(":DET_FECHA_INI", VacacionEmp.detFechaIni),
               new OracleParameter(":DET_FECHA_FIN", VacacionEmp.detFechaFin),
               new OracleParameter(":DET_DIAS", VacacionEmp.detDias),
               new OracleParameter(":DET_VALOR", VacacionEmp.detValor),
               new OracleParameter(":DET_OBSERV", VacacionEmp.detObserv),
               new OracleParameter(":VAC_AUTORIZADO", VacacionEmp.vacAutorizado),
               new OracleParameter(":DET_ESTADO", VacacionEmp.detEstado),
               //new OracleParameter(":FECHACREACION", VacacionEmp.fechacreacionc),
               new OracleParameter(":VAC_ID_ANT", VacacionEmp.vacIdAnt)
            };

            if (db.ExecQuery(sqlRegistraVacacion, prm).Equals(1))
                return pkCode;
            else
                return 0;
        }

        public DataTable ListarVacacionDT(string empID, string cabID, string conID)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID", empID),
               new OracleParameter(":CAB_VAC_ID", cabID),
               new OracleParameter(":EMP_CON_ID", conID)
            };
            return db.GetData(sqlListarVacacionDT, prm);
        }

        public DataTable ListarVacacion(string empID, string rolID, string reproID)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID", empID)
            };
            return db.GetData(sqlListarVacacion, prm);
        }

        private int PermisoGeneraCodigo(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID", empID)
            };
            return db.GetEntero(sqlPermisoCodigo, prm);
        }

        public int RegistraPermisoEmpleado(PerEntity PermisoEmp)
        {
            int pkCode = 0;
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID", PermisoEmp.empID),
               new OracleParameter(":TIP_ID", PermisoEmp.tipID),
               new OracleParameter(":LOC_ID", PermisoEmp.locID),
               new OracleParameter(":ESC_ID", PermisoEmp.escID),
               new OracleParameter(":PER_ID", pkCode=PermisoGeneraCodigo(PermisoEmp.empID)),
               new OracleParameter(":PER_FEC_INI", PermisoEmp.perFecIni),
               new OracleParameter(":PER_FEC_FIN", PermisoEmp.perFecFin),
               new OracleParameter(":PER_OBS", PermisoEmp.perObs),
               new OracleParameter(":PER_DIA", PermisoEmp.perDia),
               new OracleParameter(":PER_NUM_HOR", PermisoEmp.perNumHor),
               new OracleParameter(":PER_NUM_MIN", PermisoEmp.perNumMin),
               new OracleParameter(":PER_RES", PermisoEmp.perRes),
               new OracleParameter(":PER_HOR_INI", PermisoEmp.perHorIni),
               new OracleParameter(":PER_HOR_FIN", PermisoEmp.perHorFin)
            };

            if (db.ExecQuery(sqlRegistraPermiso, prm).Equals(1))
                return pkCode;
            else
                return 0;
        }

        public DataTable ListarPermisoTipo()
        {
            return db.GetData(sqlListarPermisoTipo);
        }
        public DataTable ListarTipo()
        {
            return db.GetData(sqlListarTipo);
        }

        public int ActualizarFaltaEmpleado(FaltaEmpEntity faltaEmp)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":DIA_FEC_NOVEDAD", faltaEmp.FechaNovedad),
               new OracleParameter(":DIA_PERMISOINJUST", faltaEmp.PermiNoJus),
               new OracleParameter(":DIA_FALTAINJUSTI", faltaEmp.FaltaNoJus),
               new OracleParameter(":DIA_FALTAJUSTIFI", faltaEmp.FaltaJus),
               new OracleParameter(":DIA_PERMISOJUST", faltaEmp.PermiJus),
               new OracleParameter(":DIA_OTRODESCUN", faltaEmp.OtroJus),
               new OracleParameter(":DIA_OTRODESCNADA", faltaEmp.OtrpNoJus),
               new OracleParameter(":DIA_OBS", faltaEmp.Observ),
               new OracleParameter(":EMP_ID", faltaEmp.EmpID),
               new OracleParameter(":ROL_ID_GEN", faltaEmp.RolID),
               new OracleParameter(":ROL_REPRO", faltaEmp.RolRepro),
               new OracleParameter(":DIA_ID", faltaEmp.FaltaID)
            };
            return db.ExecQuery(sqlActualizaFaltas, prm);
        }

        public int RegistrarFaltaEmpleado(FaltaEmpEntity faltaEmp)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID", faltaEmp.EmpID),
               new OracleParameter(":ROL_ID_GEN", faltaEmp.RolID),
               new OracleParameter(":ROL_REPRO", faltaEmp.RolRepro)
            };

            int FaltaID = db.GetEntero(sqlGeneraCodigoFalta, prm);

            prm = new OracleParameter[]{
               new OracleParameter(":DIA_ID", FaltaID),
               new OracleParameter(":EMP_ID", faltaEmp.EmpID),
               new OracleParameter(":ROL_ID_GEN", faltaEmp.RolID),
               new OracleParameter(":ROL_REPRO", faltaEmp.RolRepro),
               new OracleParameter(":DIA_FEC_NOVEDAD", faltaEmp.FechaNovedad),
               new OracleParameter(":DIA_PERMISOINJUST", faltaEmp.PermiNoJus),
               new OracleParameter(":DIA_FALTAINJUSTI", faltaEmp.FaltaNoJus),
               new OracleParameter(":DIA_FALTAJUSTIFI", faltaEmp.FaltaJus),
               new OracleParameter(":DIA_PERMISOJUST", faltaEmp.PermiJus),
               new OracleParameter(":DIA_OTRODESCUN", faltaEmp.OtroJus),
               new OracleParameter(":DIA_OTRODESCNADA", faltaEmp.OtrpNoJus),
               new OracleParameter(":DIA_OBS", faltaEmp.Observ)
            };
            return db.ExecQuery(sqlRegistrarFaltas, prm);
        }

        public DataTable ListarFaltas(string empID, string rolID, string reproID)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID", empID),
               new OracleParameter(":ROL_ID_GEN", rolID),
               new OracleParameter(":ROL_REPRO", reproID)
            };
            return db.GetData(sqlListarFaltas, prm);
        }

        public DataTable ListarRol(string empID, int rolID, int reproID, string tipo)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID", empID),
               new OracleParameter(":ROL_ID_GEN", rolID),
               new OracleParameter(":ROL_REPRO", reproID)
            };

            return db.GetData(sqlListaRolTipo, prm); ;
        }
        public DataTable ListarRol(string empID, int rolID, int reproID)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID", empID),
               new OracleParameter(":ROL_ID_GEN", rolID),
               new OracleParameter(":ROL_REPRO", reproID)
            };

            return db.GetData(sqlListaRol, prm); ;
        }

        public DataTable ListarRolDetalleCuenta(string empID, string rolID, string reproID, string rol)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID", empID),
               new OracleParameter(":ROL_ID_GEN", rolID),
               new OracleParameter(":ROL_REPRO", reproID),
               new OracleParameter(":ROL_ID", rol)
            };
            return db.GetData(sqlListaRolDetalleCuenta, prm);
        }

        public DataTable ListarRolDetalle(string empID, int rolID, int reproID, string tipo)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID", empID),
               new OracleParameter(":ROL_ID_GEN", rolID),
               new OracleParameter(":ROL_REPRO", reproID)
            };
            return db.GetData(sqlListaRolDetalleTipo, prm);
        }

        public DataTable ListarRolDetalle(string empID, int rolID, int reproID)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":EMP_ID", empID),
               new OracleParameter(":ROL_ID_GEN", rolID),
               new OracleParameter(":ROL_REPRO", reproID)
            };
            return db.GetData(sqlListaRolDetalle, prm);
        }

        public int HabilitaQuincena(int idPeriodo, int numProc, int estado)
        {
            OracleParameter[] prm = new OracleParameter[]{
               new OracleParameter(":estado", estado),
                new OracleParameter(":idPeriodo", idPeriodo),
                 new OracleParameter(":numProc", numProc)
            };

            return db.ExecQuery(sqlHabilitaQuincena, prm);
        }

        public int GeneraRol(int idPeriodo, int numProc)
        {
            OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":idPeriodo", idPeriodo),
                 new OracleParameter(":numProc", numProc)
            };

            return db.ExecProcedure(sqlGeneraRol, prm);
        }

        public int NumeroProcesoEmp(int idPeriodo, string empID)
        {
            OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":idPeriodo",idPeriodo),
                new OracleParameter(":empID",empID)
            };
            DataTable datos = db.GetData(sqlNumeroProcesoRolEmp, prm);
            return Convert.ToInt32(datos.Rows[0][0].ToString());

        }

        public int ProcesaDiario(string perID, string diaID)
        {
            OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":PERC_ID",perID ),
                new OracleParameter(":DIA_ID",diaID)
            };
            return db.GetEntero(sqlProcesaDiario, prm);


        }

        public int NumeroProceso(int idPeriodo, string tipo)
        {
            OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":idPeriodo",idPeriodo)
            };
            string sql = string.Empty;

            if (tipo.Equals("ProcesoPeriodo"))
                sql = sqlNumeroProceso;
            if (tipo.Equals("ProcesoRol"))
                sql = sqlNumeroProcesoRol;

            DataTable datos = db.GetData(sql, prm);
            return Convert.ToInt32(datos.Rows[0][0].ToString());
        }

        public int VerificaPeriodo(int rolID, int reproID)
        {
            OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":rolID",rolID),
                new OracleParameter(":reproID",reproID)
            };
            return db.GetEntero(sqlVerificaPeriodoRol, prm);
        }
        public int VerificaPeriodo(int rolID, int reproID, string fecha)
        {
            OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":rolID",rolID)
                //new OracleParameter(":reproID",reproID)
            };
            return db.GetEntero(sqlVerificaPeriodoRolAbierto1, prm);
        }
        public int VerificaPeriodo()
        {
            return db.GetEntero(sqlVerificaPeriodo);
        }

        public int AperturaPeriodo()
        {

            return db.ExecProcedure(sqlAperturaPeriodo);

        }
        public DataTable ListaPeriodoDecimo(string tipo)
        {
            string sql = string.Empty;
            if (tipo.Equals("DT"))
                sql = sqlListaPeriodoDecimoT;

            if (tipo.Equals("DC"))
                sql = sqlListaPeriodoDecimoC;

            return db.GetData(sql);

        }
        public DataTable ListaReproceso(string tipo)
        {
            OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":SEG_ROL_ID",tipo)
            };
            return db.GetData(sqlListaReproceso, prm);
        }
        public DataTable ListarPeriodo(string tipo)
        {
            string sql = string.Empty;
            if (tipo.Equals("P"))
                sql = sqlListaPeriodo;

            if (tipo.Equals("PQ"))
                sql = sqlListaPeriodoQuincena;

            if (tipo.Equals("PU"))
                sql = sqlListaPeriodoUnico;

            if (tipo.Equals("PR"))
                sql = sqlListaPeriodoRol;
            if (tipo.Equals("PREPO"))
                sql = sqlListaPeriodoRolReporte;
            return db.GetData(sql);

        }

        public int RegistrarValorFijo(DatEmpValFijo valFijo)
        {
            OracleParameter[] prm = new OracleParameter[]{
            new OracleParameter(":EMP_ID",valFijo.empId),
            new OracleParameter(":ROL_ID",valFijo.rolId ),
            new OracleParameter(":FIJ_VALOR",valFijo.fijValor),
            new OracleParameter(":FIJ_ESTADO",valFijo.fijEstado)
            };
            return db.ExecQuery(sqlRegistrarValorFijo, prm);
        }

        public int ActualizarValorFijo(DatEmpValFijo valFijo, int auxRolID)
        {
            OracleParameter[] prm = new OracleParameter[]{
            new OracleParameter(":ROL_ID",valFijo.rolId),
            new OracleParameter(":FIJ_VALOR",valFijo.fijValor),
            new OracleParameter(":FIJ_ESTADO",valFijo.fijEstado),
            new OracleParameter(":EMP_ID",valFijo.empId),
            new OracleParameter(":AUX_ROL_ID",auxRolID )
            };
            return db.ExecQuery(sqlActualizarValorFijo, prm);
        }

        public int EliminaValorFijo(string empID, int auxRolID)
        {
            OracleParameter[] prm = new OracleParameter[]{
            new OracleParameter(":EMP_ID",empID),
            new OracleParameter(":AUX_ROL_ID",auxRolID )
            };
            return db.ExecQuery(sqlEliminaValorFijo, prm);
        }

        public int RegistrarInfoLaboral(DatLab lab)
        {
            int cnt = db.GetEntero("SELECT COUNT(*) FROM DESARROLLO.DAT_LAB WHERE EMP_ID=" + lab.empId);


            if (cnt == 0)
            {
                OracleParameter[] prm = new OracleParameter[]{
                    new OracleParameter(":EMP_ID",lab.empId),
                    new OracleParameter(":LAB_ID",cnt+1 ),
                    new OracleParameter(":LOC_ID",lab.locId),
                    new OracleParameter(":ESC_ID",lab.escId),
                    new OracleParameter(":LAB_FEC_CAMB_ESC",lab.labFecCambEsc ),
                    new OracleParameter(":LAB_SUELDO_BONO",lab.labSueldoBono),
                    new OracleParameter(":LAB_OBS",lab.labObs ),
                    new OracleParameter(":LAB_ESTADO",lab.labEstado),
                    new OracleParameter(":LAB_TIPO_EMP",lab.labTipoEmp),
                    new OracleParameter(":LAB_RBU",lab.labRbu),
                    new OracleParameter(":LAB_VEST",lab.labVest),
                    new OracleParameter(":LAB_BONO",lab.labBono),
                    new OracleParameter(":LAB_QUINCENA",lab.labQuincena)};
                return db.ExecQuery(sqlRegistrarInfoLaboral, prm);

            }

            else
            {
                OracleParameter[] prm = new OracleParameter[]{                    
                    new OracleParameter(":LOC_ID",lab.locId),
                    new OracleParameter(":ESC_ID",lab.escId),
                    //new OracleParameter(":LAB_FEC_CAMB_ESC",lab.labFecCambEsc ),
                    new OracleParameter(":LAB_SUELDO_BONO",lab.labSueldoBono),
                    new OracleParameter(":LAB_OBS",lab.labObs ),
                    new OracleParameter(":LAB_ESTADO",lab.labEstado),
                    new OracleParameter(":LAB_TIPO_EMP",lab.labTipoEmp),
                    new OracleParameter(":LAB_RBU",lab.labRbu),
                    new OracleParameter(":LAB_VEST",lab.labVest),
                    new OracleParameter(":LAB_BONO",lab.labBono),
                    new OracleParameter(":LAB_QUINCENA",lab.labQuincena),
                    new OracleParameter(":EMP_ID",lab.empId),
                    new OracleParameter(":LAB_ID",lab.labId)};
                return db.ExecQuery(sqlActualizaInfoLaboral, prm);

            }
        }

        public Int64 RegistraContrato(DatEmpCon emp, string prmScript)
        {
            int cnt = db.GetEntero("SELECT COUNT(*) FROM DESARROLLO.DAT_EMP_CON WHERE EMP_ID=" + emp.empId);
            if (cnt == 0)
            {
                OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":EMP_ID",emp.empId),
                new OracleParameter(":EMP_CON_ID",cnt+1),
                new OracleParameter(":CON_ID",emp.conId),
                new OracleParameter(":PAT_ID",emp.patId),
                new OracleParameter(":EMP_CON_RAZON_SALE",emp.empConRazonSale),
                new OracleParameter(":EMP_CON_FIRM_RENU",emp.empConFirmRenu),
                new OracleParameter(":EMP_CON_FEC_LIQUI",emp.empConFecLiqui),
                new OracleParameter(":EMP_CON_FIRM_LIQUI",emp.empConFirmLiqui),
                new OracleParameter(":EMP_CON_FEC_LEG_SA",emp.empConFecLiqui),
                new OracleParameter(":EMP_CON_FEC_CONTRATO",emp.empConFecContrato),
                new OracleParameter(":EMP_CON_OBS",emp.empConObs),
                new OracleParameter(":CON_CAU_ID",emp.conCauId)
                };

                return (db.ExecQuery(sqlRegistraContrato, prm).Equals(1) ? Convert.ToInt64(emp.empId) : 0);
            }
            else
            {
                OracleParameter[] prm = new OracleParameter[]{                
                new OracleParameter(":CON_ID",emp.conId),
                new OracleParameter(":PAT_ID",emp.patId),
                new OracleParameter(":EMP_CON_RAZON_SALE",emp.empConRazonSale),
                new OracleParameter(":EMP_CON_FIRM_RENU",emp.empConFirmRenu),
                new OracleParameter(":EMP_CON_FEC_LIQUI",emp.empConFecLiqui),
                new OracleParameter(":EMP_CON_FIRM_LIQUI",emp.empConFirmLiqui),
                new OracleParameter(":EMP_CON_FEC_LEG_SA",emp.empConFecLiqui),
                new OracleParameter(":EMP_CON_FEC_CONTRATO",emp.empConFecContrato),
                new OracleParameter(":EMP_CON_OBS",emp.empConObs),
                new OracleParameter(":CON_CAU_ID",emp.conCauId),
                new OracleParameter(":EMP_ID",emp.empId),
                new OracleParameter(":EMP_CON_ID",emp.empConId)
                };

                if (db.ExecQuery(sqlActualizaContrato, prm).Equals(1))
                {
                    if (emp.empConFecLiqui != null)
                    {
                        OracleParameter[] prmVac = new OracleParameter[]{
                            new OracleParameter(":EMP_ID",OracleDbType.Int64){Value = emp.empId},
                            new OracleParameter(":FEC_LIQUI",OracleDbType.Date){Value = emp.empConFecLiqui}};
                        db.ExecProcedure(sqlCargaPeriodoVacacion, prmVac);

                        OracleParameter[] prmLiq = new OracleParameter[]{
                            new OracleParameter(":FEC_LIQUI",OracleDbType.Date){Value = emp.empConFecLiqui},
                            new OracleParameter(":FEC_SALIDA",OracleDbType.Date){Value = emp.empConFecLiqui},
                            new OracleParameter(":EMP_ID",OracleDbType.Int64){Value = emp.empId},
                            new OracleParameter(":EMPT_ID",OracleDbType.Int64){Value = emp.empId}};
                        db.ExecQuery(sqlActualizaSalidaEmp, prmLiq);

                        prmLiq = new OracleParameter[]{
                            new OracleParameter(":FEC_SALIDA",OracleDbType.Date){Value = emp.empConFecLiqui},
                            new OracleParameter(":FEC_SALIDA",OracleDbType.Date){Value = emp.empConFecLiqui},
                            new OracleParameter(":EMP_ID",OracleDbType.Int64){Value = emp.empId}};
                        db.ExecQuery(sqlActualizaSalidaEmp2, prmLiq);

                        prmLiq = new OracleParameter[]{
                            new OracleParameter("p_emp_id",OracleDbType.Int64){Value = emp.empId}};
                        db.ExecProcedure(sqlActualizaSalidaEmp3, prmLiq);
                    }
                    return Convert.ToInt64(emp.empId);
                }
                else
                    return 0;
            }
        }

        public DataTable RubroAdicional(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":empID", empID)
                };
            return db.GetData(sqlRubroAdicional, prm);
        }

        public DataTable InfoLaboral(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":EMP_ID", empID),
                    new OracleParameter(":EMP_ID", empID)
                };
            return db.GetData(sqlInfoLaboral, prm);
        }

        public DataTable ContratoEmpleado(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":EMP_ID", empID)
                };
            return db.GetData(sqlContratoEmpleado, prm);
        }

        public int FinContratoEmpleadoDT(DatDetLiq liquidacion)
        {
            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":DET_LIQ_REF", liquidacion.detLiqRef),
                    new OracleParameter(":DET_LIQ_VALOR", liquidacion.detLiqValor ),
                     new OracleParameter(":DET_LIQ_OBS", liquidacion.detLiqObs),
                     new OracleParameter(":RUB_LIQ_ID", liquidacion.rubLiqId),
                     new OracleParameter(":EMP_ID", liquidacion.empId),
                     new OracleParameter(":LIQ_ID", liquidacion.liqId)
                };
            return db.ExecQuery(sqlFinContratoEmpleadoDT, prm);
        }

        public int FinContratoEmpleado(string empID, string observacion, string id)
        {

            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":EMP_OBS", observacion),
                    new OracleParameter(":EMP_ID", empID),
                     new OracleParameter(":EMP_CON_ID", id)
                };
            return db.ExecQuery(sqlFinContratoEmpleadoU, prm);
        }

        public DataTable FinContratoEmpleado(string empID)
        {

            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":EMP_ID", empID)
                };
            return db.GetDataLong(sqlFinContratoEmpleado, prm);
        }

        public DataTable LiquidacionEmpleado(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":EMP_ID", empID)
                };
            return db.GetData(sqlLiquidacionEmpleado, prm);
        }
        public DataTable LiquidacionEmpleadoDT(string empID, string liqID)
        {
            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":EMP_ID", empID),
                    new OracleParameter(":LIQ_ID", liqID)
                };
            return db.GetData(sqlLiquidacionEmpleadoDT, prm);
        }

        public List<ContratoFinEntity> ListaContratoFin()
        {
            List<ContratoFinEntity> lis = new List<ContratoFinEntity>();
            var reader = db.ExecuteSelect(sqlContratoFin);
            while (reader.Read())
            {
                lis.Add(ConvertContratoFin(reader));
            }
            return lis;
        }
        public DataTable ListarContratoFin()
        {
            return db.GetData(sqlContratoFin);
        }

        private ContratoFinEntity ConvertContratoFin(IDataReader reader)
        {
            ContratoFinEntity item = new ContratoFinEntity();
            item.ContratoFinID = Convert.ToInt32(reader["CON_CAU_ID"]);
            item.Causa = Convert.ToString(reader["CON_CAU_CAUSA"]);
            item.Abrev = Convert.ToString(reader["CON_CAU_ABREV"]);
            item.FechaCrea = Convert.ToDateTime(reader["CON_CAU_FECHACREACION"]);

            return item;
        }

        public List<ContratoEntity> ListaContrato()
        {
            List<ContratoEntity> lis = new List<ContratoEntity>();
            var reader = db.ExecuteSelect(sqlListaContrato);
            while (reader.Read())
            {
                lis.Add(ConvertLocal(reader));
            }
            return lis;
        }
        public int GetReproceso(string empID, string perID)
        {
            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":EMP_ID", empID),
                    new OracleParameter(":PER_ID", perID)
                };
            return db.GetEntero(sqlGetReproceso, prm);
        }
        public DataTable ListarContrato()
        {
            return db.GetData(sqlListaContrato);
        }
        public DataTable DetalleIngreso(string empID, string perID, string reproID)
        {
            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":EMP_ID", empID),
                    new OracleParameter(":SEG_ROL_ID", perID),
                    new OracleParameter(":SEG_ROL_REPRO", reproID)
                };
            return db.GetData(sqlDetalleIngreso, prm);
        }
        public DataSet DetalleDecimoTercero(string empID, string perID)
        {
            DataSet content = new DataSet();
            DataTable data = new DataTable();
            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":EMP_ID", empID),
                    new OracleParameter(":EMP_ID", empID),
                    new OracleParameter(":CAL_DEC_TER_ID", perID)
                };

            data = db.GetData(sqlDetalleDecimoTercero, prm).Copy();
            data.TableName = "Master";
            content.Tables.Add(data);
            data = db.GetData(sqlDetalleDecimoTerceroDT, prm).Copy();
            data.TableName = "Detail";
            content.Tables.Add(data);
            return content;
        }
        public DataSet DetalleVacacion(string empID, string perID)
        {
            DataSet content = new DataSet();
            DataTable data = new DataTable();
            OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":EMP_ID", empID),
                    new OracleParameter(":CAL_VAC_ID", perID)
                };

            data = db.GetData(sqlDetalleVacacion, prm).Copy();
            data.TableName = "Master";
            content.Tables.Add(data);
            data = db.GetData(sqlDetalleVacacionDT, prm).Copy();
            data.TableName = "Detail";
            content.Tables.Add(data);
            return content;

        }
        public DataTable DetalleEgreso()
        {
            return db.GetData(sqlListaContrato);
        }

        private ContratoEntity ConvertLocal(IDataReader reader)
        {
            ContratoEntity item = new ContratoEntity();
            item.ContratoID = Convert.ToInt32(reader["CON_ID"]);
            item.Nombre = Convert.ToString(reader["CON_NOMBRE"]);
            item.Descripcion = Convert.ToString(reader["CON_DESC"]);

            return item;
        }

        public int GeneraAsientoLiquidacion(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
              {
                    new OracleParameter(":EMP_ID", empID)
              };
            return db.ExecProcedure(sqlGeneraAsientoLiquidacion, prm);
        }
        public void CalculaVacaciones(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
              {
                    new OracleParameter(":EMP_ID", empID)
              };
            db.ExecProcedure(sqlCalculaVacaciones, prm);
        }

        public int ValidaLiquidacion(string empID, string fechaContrato)
        {
            OracleParameter[] prm = new OracleParameter[]
               {
                    new OracleParameter(":EMP_ID", empID),
                    new OracleParameter(":CONTRATO",  Convert.ToDateTime(fechaContrato).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")))
               };
            return db.GetEntero(sqlValidaLiquidacion, prm);
        }
        public string TipoContrato(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
               {
                    new OracleParameter(":EMP_ID", empID)
               };
            return db.GetString(sqlTipoContrato, prm);
        }
        public int ContratoHoraGeneral(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
               {
                    new OracleParameter(":EMP_ID", empID)
               };
            return db.GetEntero(sqlContratoHoraGeneral, prm);
        }
        public int EmpleadoEsMotorista(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
               {
                    new OracleParameter(":EMP_ID", empID)
               };
            return db.GetEntero(sqlEmpleadoEsMotorista, prm);
        }
        public int CalculaLiquidacion(string empID, int pagoID, int provID)
        {
            OracleParameter[] prm = new OracleParameter[]
               {
                    new OracleParameter(":EMP_ID", empID)
               };
            db.ExecProcedure(sqlCalculaVacaciones, prm);
            int esEmpleado = db.GetEntero(sqlEsEmpleado, prm);
            int esMotorista = db.GetEntero(sqlEsMotorista, prm);
            prm = new OracleParameter[]
               {
                    new OracleParameter(":EMP_ID", empID),
                    new OracleParameter(":PAGO_ID", pagoID),
                    new OracleParameter(":PROV_ID", provID)
               };

            if (esEmpleado > 0)
            {
                db.ExecProcedure(sqlCalculaLiquidacionEmp, prm);
            }
            else
            {
                if (esMotorista > 0)
                {
                    db.ExecProcedure(sqlCalculaLiquidacionMot, prm);
                }
                else
                {
                    db.ExecProcedure(sqlCalculaLiquidacionEmp, prm);
                }
            }

            //if (esEmpleado > 0 || esMotorista < 1)
            //{
            //    db.ExecProcedure(sqlCalculaLiquidacionEmp, prm);
            //}
            //else
            //{
            //    db.ExecProcedure(sqlCalculaLiquidacionMot, prm);
            //    //if (resp1 > 0)
            //    //{
            //    //    db.GetEntero(sqlCalculaLiquidacion1, prm);
            //    //}
            //    //else
            //    //{
            //    //    db.GetEntero(sqlCalculaLiquidacion, prm);

            //    //}

            //}


            return 0;
        }

        #endregion

        #region Instancia / Constructor
        private static ContratoRepository _instancia;
        public static ContratoRepository Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ContratoRepository();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public ContratoRepository()
        {
            db = ConnectionDDBB.Instancia;
        }
        #endregion
    }
}
