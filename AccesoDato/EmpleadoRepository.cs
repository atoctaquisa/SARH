using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Oracle.DataAccess.Client;
using System.Data;
using Entity;
namespace DataAccess
{
    public class EmpleadoRepository
    {
        #region Instancia / Constructor
        private static EmpleadoRepository _instancia;
        public static EmpleadoRepository Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new EmpleadoRepository();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        private EmpleadoRepository()
        {
            db = ConnectionDDBB.Instancia;
        }

        #endregion

        #region Variables
        //private static string sqlDeleteEmpleado0 = "DELETE DESARROLLO.DAT_DET_ING_EMP WHERE EMP_ID = :EMP_ID";
        //private static string sqlDeleteEmpleado1 = "DELETE DESARROLLO.DAT_LAB WHERE EMP_ID = :EMP_ID";
        //private static string sqlDeleteEmpleado2 = "DELETE DESARROLLO.DAT_EMP_CON WHERE EMP_ID = :EMP_ID";
        //private static string sqlDeleteEmpleado3 = "DELETE DESARROLLO.DAT_EMP WHERE EMP_ID = :EMP_ID";
        //private static string sqlDeleteEmpleado4 = "DELETE DESARROLLO.DAT_EMP_ING WHERE EMP_ID = :EMP_ID";
        private static string sqlDeleteEmpleado = "P_ELIMINA_EMP";
        private static string sqlValidaCedula = "SELECT F_VALIDA_DOCUMENTO(:empCI) FROM DUAL";
        private static string sqlDiscapacidad = "SELECT DSCP_TIP_ID, DSCP_TIP_DSC FROM DESARROLLO.DAT_DSCP_TIP ";
        private static string sqlEmpleadoDiscapacidad = "SELECT DSCP_ID, EMP_ID, DSCP_TIP_ID, DSCP_NUM, DSCP_PRCT, DSCP_DSC FROM DESARROLLO.DAT_DSCP WHERE EMP_ID=:EMP_ID";
        private static string sqlDiscapacidadEmp = @"SELECT LISTAGG (DSCP_PRCT || '% ' || DSCP_TIP_DSC, '; ')  WITHIN GROUP(ORDER BY DSCP_TIP_DSC) DISCAPACIDAD    
                                                    FROM DESARROLLO.DAT_DSCP  D JOIN DAT_DSCP_TIP T ON (D.DSCP_TIP_ID = T.DSCP_TIP_ID) WHERE EMP_ID=:EMP_ID";
        private static string sqlCargoEmpleadoRol = "SELECT PK_NOMINATCG.F_CARGOEMPROL(:EMP_ID, :PER_ID, :REPRO_ID) FROM DUAL ";
        private static string sqlListarEmpleado = @"SELECT EMP_ID,EMP_APELLIDO,EMP_NOMBRE,EMP_CI,EMP_NUM_IESS,EMP_CUENTA,EMP_DISCAPACIDAD,
                                                           EMP_MAIL,EMP_PASAPORTE,EMP_PAG_FON_RES,EMP_TIPO_CNTA,EMP_NUM_CONADIS,
                                                           EMP_AFIL_HUMANA,EMP_AFI_SEG_FEC,EMP_PAG_DEC_TER,EMP_PAG_DEC_CUA,EMP_BARRIO,
                                                           EMP_DIREC,EMP_TELEFONO,EMP_SEC_ID,EMP_DIRE_NUMERO,EMP_TELEFONO2,
                                                           EMP_LUG_NAC,EMP_FEC_NAC,EMP_SEXO,EMP_EDU,EMP_FEC_SEG,EMP_EST_CIVIL,EMP_TIP_SANGRE,
                                                           EMP_FEC_SALIDAREAL,LAB_FEC_INGRESO,EMP_FEC_SALIDA,EMP_FEC_REG,EMP_FEC_MOD, EMP_MAIL_PER 
                                                    FROM DESARROLLO.DAT_EMP ";
        //private static string sqlListarEmpleado = "SELECT * FROM V_DETALLE_EMP";
        private static string sqlListarEmpleadoDetalle = @"SELECT
                                                                    EMP_ID, NOMBRE, LOC_NOMBRE, ESC_CARGOMB, LAB_FEC_INGRESO, EMP_FEC_NAC, EMP_SEC,
                                                                    EMP_DIREC, EMP_EST_CIVIL, EMP_CLAVE_ASIST, EMP_PAG_DEC_CUA, EMP_CON_FEC_CONTRATO,
                                                                    EMP_CI, ESC_CARGOIESS, LAB_ESTADO, DECODE(LAB_ESTADO, 0, 'Pasivo',1,'Activo',2,'A prueba',3,'Inactivo',4,'Suspendido',5,'Sin Rol') ESTADO,
                                                                    ESC_GRU_NOMBRE, ESC_GRU_ID,	--(SELECT l.LOC_NOMBRE FROM DESARROLLO.DAT_LOC l Where l.loc_id=loc_id)LOCAL,
                                                                    LOC_ID, LAB_FEC_CAMB_ESC, EMP_LUG_NAC, EMP_TELEFONO, EMP_NUM_HIJOS,
                                                                    /*EMP_DEPENDIENTES,*/ DECODE(EMP_AFIL_HUMANA,1,'Si','No') AFILIACION, EMP_AFIL_HUMANA, ESC_ID, EMP_FEC_SALIDAREAL, EMP_FEC_SALIDA,
                                                                    LAB_TIPO_EMP, ESC_COD_ACT_SEC, EMP_CON_CAUSA, ESC_CODIESS, GRU_CARG_ID,
                                                                    ESC_ABRE, PATRONO, PAT_ID, EMP_BARRIO, EMP_SEXO, LOC_CIUDAD, LOC_PROVINCIA, CON_ID,
                                                                    EMP_EDU, EMP_CUENTA, EMP_TIPO_CNTA, EMP_MAIL, TIPO_CONTRATO, CON_CAU_ID,
                                                                    LOC_PROV_SEDE, LOC_CIU_SEDE, LOC_DIR_SEDE, ESC_FUN_MIN_TRA, GRU_LOC_ID,
                                                                    EMP_DIRE_NUMERO, EMP_FEC_REG, EMP_FEC_MOD, EMP_FECHA_REINGRESO, EMP_CON_OBS,
                                                                    LAB_ID, EMP_TIP_SANGRE, EMP_DISCAPACIDAD, EMP_NUM_CONADIS, LOC_CIUDAD_ABREV,
                                                                    EMP_AFI_FARMA, EMP_HOR, GRU_LOC_NOM_ID, LOC_REGIMEN, EMP_PASAPORTE, EMP_SUJ_CRDT,
                                                                    ESC_GRU_CRDT_MAX, ESC_GRU_DSCT_MAX, EMP_CON_FIRM_CON, EMP_CON_LEGALIZADO,
                                                                    FEC_CONTRATO_AUX, RBU, ESC_ADI_BON_PRO, ESC_VEST, EMP_PAG_FON_RES, LAB_RBU,
                                                                    LAB_VEST, LAB_BONO, EMP_SEC_NOMBRE, LAB_QUINCENA, EMP_MAIL_PER
                                                          FROM DESARROLLO.V_DETALLE_EMP ";
        private static string sqlListarEmpleadoDetallePRM = @"SELECT
                                                                    EMP_ID, NOMBRE, LOC_NOMBRE, ESC_CARGOMB, LAB_FEC_INGRESO, EMP_FEC_NAC, EMP_SEC,
                                                                    EMP_DIREC, EMP_EST_CIVIL, EMP_CLAVE_ASIST, EMP_PAG_DEC_CUA, EMP_CON_FEC_CONTRATO,
                                                                    EMP_CI, ESC_CARGOIESS, LAB_ESTADO, DECODE(LAB_ESTADO, 0, 'Pasivo',1,'Activo',2,'A prueba',3,'Inactivo',4,'Suspendido',5,'Sin Rol') ESTADO,
                                                                    ESC_GRU_NOMBRE, ESC_GRU_ID,	--(SELECT l.LOC_NOMBRE FROM DESARROLLO.DAT_LOC l Where l.loc_id=loc_id)LOCAL,
                                                                    LOC_ID, LAB_FEC_CAMB_ESC, EMP_LUG_NAC, EMP_TELEFONO, EMP_NUM_HIJOS,
                                                                    /*EMP_DEPENDIENTES,*/ DECODE(EMP_AFIL_HUMANA,1,'Si','No') AFILIACION, EMP_AFIL_HUMANA, ESC_ID, EMP_FEC_SALIDAREAL, EMP_FEC_SALIDA,
                                                                    LAB_TIPO_EMP, ESC_COD_ACT_SEC, EMP_CON_CAUSA, ESC_CODIESS, GRU_CARG_ID,
                                                                    ESC_ABRE, PATRONO, PAT_ID, EMP_BARRIO, EMP_SEXO, LOC_CIUDAD, LOC_PROVINCIA, CON_ID,
                                                                    EMP_EDU, EMP_CUENTA, EMP_TIPO_CNTA, EMP_MAIL, TIPO_CONTRATO, CON_CAU_ID,
                                                                    LOC_PROV_SEDE, LOC_CIU_SEDE, LOC_DIR_SEDE, ESC_FUN_MIN_TRA, GRU_LOC_ID,
                                                                    EMP_DIRE_NUMERO, EMP_FEC_REG, EMP_FEC_MOD, EMP_FECHA_REINGRESO, EMP_CON_OBS,
                                                                    LAB_ID, EMP_TIP_SANGRE, EMP_DISCAPACIDAD, EMP_NUM_CONADIS, LOC_CIUDAD_ABREV,
                                                                    EMP_AFI_FARMA, EMP_HOR, GRU_LOC_NOM_ID, LOC_REGIMEN, EMP_PASAPORTE, EMP_SUJ_CRDT,
                                                                    ESC_GRU_CRDT_MAX, ESC_GRU_DSCT_MAX, EMP_CON_FIRM_CON, EMP_CON_LEGALIZADO,
                                                                    FEC_CONTRATO_AUX, RBU, ESC_ADI_BON_PRO, ESC_VEST, EMP_PAG_FON_RES, LAB_RBU,
                                                                    LAB_VEST, LAB_BONO, EMP_SEC_NOMBRE, LAB_QUINCENA, EMP_MAIL_PER
                                                          FROM DESARROLLO.V_DETALLE_EMP WHERE ";
        private static string sqlPaginaEmpleadoDetalle = @"SELECT * from (SELECT 
                                                                    EMP_ID, NOMBRE, LOC_NOMBRE, ESC_CARGOMB, LAB_FEC_INGRESO, EMP_FEC_NAC, EMP_SEC,
                                                                    EMP_DIREC, EMP_EST_CIVIL, EMP_CLAVE_ASIST, EMP_PAG_DEC_CUA, EMP_CON_FEC_CONTRATO,
                                                                    EMP_CI, ESC_CARGOIESS, LAB_ESTADO, DECODE(LAB_ESTADO, 0, 'Pasivo',1,'Activo',2,'A prueba',3,'Inactivo',4,'Suspendido',5,'Sin Rol') ESTADO,
                                                                    ESC_GRU_NOMBRE, ESC_GRU_ID,	--(SELECT l.LOC_NOMBRE FROM DESARROLLO.DAT_LOC l Where l.loc_id=loc_id)LOCAL,
                                                                    LOC_ID, LAB_FEC_CAMB_ESC, EMP_LUG_NAC, EMP_TELEFONO, EMP_NUM_HIJOS,
                                                                    /*EMP_DEPENDIENTES,*/ DECODE(EMP_AFIL_HUMANA,1,'Si','No') AFILIACION, EMP_AFIL_HUMANA, ESC_ID, EMP_FEC_SALIDAREAL, EMP_FEC_SALIDA,
                                                                    LAB_TIPO_EMP, ESC_COD_ACT_SEC, EMP_CON_CAUSA, ESC_CODIESS, GRU_CARG_ID,
                                                                    ESC_ABRE, PATRONO, PAT_ID, EMP_BARRIO, EMP_SEXO, LOC_CIUDAD, LOC_PROVINCIA, CON_ID,
                                                                    EMP_EDU, EMP_CUENTA, EMP_TIPO_CNTA, EMP_MAIL, TIPO_CONTRATO, CON_CAU_ID,
                                                                    LOC_PROV_SEDE, LOC_CIU_SEDE, LOC_DIR_SEDE, ESC_FUN_MIN_TRA, GRU_LOC_ID,
                                                                    EMP_DIRE_NUMERO, EMP_FEC_REG, EMP_FEC_MOD, EMP_FECHA_REINGRESO, EMP_CON_OBS,
                                                                    LAB_ID, EMP_TIP_SANGRE, EMP_DISCAPACIDAD, EMP_NUM_CONADIS, LOC_CIUDAD_ABREV,
                                                                    EMP_AFI_FARMA, EMP_HOR, GRU_LOC_NOM_ID, LOC_REGIMEN, EMP_PASAPORTE, EMP_SUJ_CRDT,
                                                                    ESC_GRU_CRDT_MAX, ESC_GRU_DSCT_MAX, EMP_CON_FIRM_CON, EMP_CON_LEGALIZADO,
                                                                    FEC_CONTRATO_AUX, RBU, ESC_ADI_BON_PRO, ESC_VEST, EMP_PAG_FON_RES, LAB_RBU,
                                                                    LAB_VEST, LAB_BONO, EMP_SEC_NOMBRE, LAB_QUINCENA, rownum AS rnum
                                                          FROM DESARROLLO.V_DETALLE_EMP ) where rnum between 1 and 10 ";
        private static string sqlFamiliares = "SELECT EMP_ID, EMP_FAM_ID, EMP_FAM_NOMBRE, EMP_FAM_FEC_NAC, DESARROLLO.calc_edad(EMP_FAM_FEC_NAC) EDAD, EMP_FAM_PARENT, EMP_FAM_OCUP, EMP_FAM_TELF_REF, EMP_FAM_DISC FROM DESARROLLO.DAT_EMP_FAM WHERE EMP_ID=:empID";
        private static string sqlInsert = @"
                                            INSERT INTO DESARROLLO.DAT_EMP (EMP_ID,
                                                                            EMP_NOMBRE,
                                                                            EMP_DIREC,
                                                                            EMP_TELEFONO,
                                                                            EMP_LUG_NAC,
                                                                            EMP_FEC_NAC,
                                                                            EMP_CI,
                                                                            EMP_NUM_IESS,
                                                                            EMP_EST_CIVIL,
                                                                            EMP_NUM_HIJOS,
                                                                            LAB_FEC_INGRESO,
                                                                            EMP_CUENTA,
                                                                            EMP_APELLIDO,
                                                                            --EMP_FEC_SALIDA,
                                                                            EMP_AFIL_HUMANA,
                                                                            EMP_TELEFONO2,
                                                                            --EMP_FEC_SALIDAREAL,
                                                                            --EMP_CNTA_CAM,
                                                                            EMP_TIPO_CNTA,
                                                                            EMP_FEC_REG,
                                                                            --EMP_FEC_MOD,
                                                                            EMP_FEC_SEG,
                                                                            EMP_SEXO,
                                                                            EMP_SEC_ID,
                                                                            EMP_BARRIO,
                                                                            --EMP_FECHA_REINGRESO,
                                                                            EMP_EDU,
                                                                            EMP_DIRE_NUMERO,
                                                                            EMP_TIP_SANGRE,
                                                                            EMP_DISCAPACIDAD,
                                                                            EMP_NUM_CONADIS,
                                                                            EMP_AFI_FARMA,
                                                                            --EMP_AFI_FARMA_FEC,
                                                                            --EMP_AFI_SEG_FEC,
                                                                            --EMP_HOR,
                                                                            EMP_PAG_FON_RES,
                                                                            EMP_PASAPORTE,
                                                                            --EMP_SUJ_CRDT,
                                                                            EMP_MAIL,
                                                                            EMP_MAIL_PER,
                                                                            --EMP_CLAVE_ASIST,
                                                                            --EMP_PORC_DISC,
                                                                            --DSC_ID,
                                                                            EMP_PAG_DEC_TER,
                                                                            EMP_PAG_DEC_CUA,
                                                                            --EMP_OBS,
                                                                            --FEC_CONTRATO_AUX,
                                                                            EMP_DEPENDIENTES)
                                                 VALUES (:EMP_ID,
                                                         :EMP_NOMBRE,
                                                         :EMP_DIREC,
                                                         :EMP_TELEFONO,
                                                         :EMP_LUG_NAC,
                                                         :EMP_FEC_NAC,
                                                         :EMP_CI,
                                                         :EMP_NUM_IESS,
                                                         :EMP_EST_CIVIL,
                                                         :EMP_NUM_HIJOS,
                                                         :LAB_FEC_INGRESO,
                                                         :EMP_CUENTA,
                                                         :EMP_APELLIDO,
                                                         --:EMP_FEC_SALIDA,
                                                         :EMP_AFIL_HUMANA,
                                                         :EMP_TELEFONO2,
                                                         --:EMP_FEC_SALIDAREAL,
                                                         --:EMP_CNTA_CAM,
                                                         :EMP_TIPO_CNTA,
                                                         DESARROLLO.PK_NOMINATCG.F_FECHASERVER,--:EMP_FEC_REG,
                                                         --:EMP_FEC_MOD,
                                                         'Fecha:'||to_char(sysdate,'DD/MON/RRRR HH24:MI:SS')||chr(10)||'* Ingreso:'|| :LAB_FEC_INGRESO1||chr(10)||' '||user,
                                                         --:EMP_FEC_SEG,
                                                         :EMP_SEXO,
                                                         :EMP_SEC_ID,
                                                         :EMP_BARRIO,
                                                         --:EMP_FECHA_REINGRESO,
                                                         :EMP_EDU,
                                                         :EMP_DIRE_NUMERO,
                                                         :EMP_TIP_SANGRE,
                                                         :EMP_DISCAPACIDAD,
                                                         :EMP_NUM_CONADIS,
                                                         :EMP_AFI_FARMA,
                                                         --:EMP_AFI_FARMA_FEC,
                                                         --:EMP_AFI_SEG_FEC,
                                                         --:EMP_HOR,
                                                         :EMP_PAG_FON_RES,
                                                         :EMP_PASAPORTE,
                                                         --:EMP_SUJ_CRDT,
                                                         :EMP_MAIL,
                                                         :EMP_MAIL_PER,
                                                         --:EMP_CLAVE_ASIST,
                                                         --:EMP_PORC_DISC,
                                                         --:DSC_ID,
                                                         :EMP_PAG_DEC_TER,
                                                         :EMP_PAG_DEC_CUA,
                                                         --:EMP_OBS,
                                                         --:FEC_CONTRATO_AUX,
                                                         :EMP_DEPENDIENTES)";

        private static string sqlUpdate = @"UPDATE DESARROLLO.DAT_EMP
                                            SET    --EMP_ID              = :EMP_ID,
                                                   EMP_NOMBRE          = :EMP_NOMBRE,
                                                   EMP_DIREC           = :EMP_DIREC,
                                                   EMP_TELEFONO        = :EMP_TELEFONO,
                                                   EMP_LUG_NAC         = :EMP_LUG_NAC,
                                                   EMP_FEC_NAC         = :EMP_FEC_NAC,
                                                   EMP_CI              = :EMP_CI,
                                                   EMP_NUM_IESS        = :EMP_NUM_IESS,
                                                   EMP_EST_CIVIL       = :EMP_EST_CIVIL,
                                                   EMP_NUM_HIJOS       = :EMP_NUM_HIJOS,
                                                   LAB_FEC_INGRESO     = :LAB_FEC_INGRESO,
                                                   EMP_CUENTA          = :EMP_CUENTA,
                                                   EMP_APELLIDO        = :EMP_APELLIDO,
                                                   EMP_FEC_SALIDA      = :EMP_FEC_SALIDA,
                                                   EMP_AFIL_HUMANA     = :EMP_AFIL_HUMANA,
                                                   EMP_TELEFONO2       = :EMP_TELEFONO2,
                                                   --EMP_FEC_SALIDAREAL  = :EMP_FEC_SALIDAREAL,
                                                   --EMP_CNTA_CAM        = :EMP_CNTA_CAM,
                                                   EMP_TIPO_CNTA       = :EMP_TIPO_CNTA,
                                                   --EMP_FEC_REG         = :EMP_FEC_REG,
                                                   EMP_FEC_MOD         = SYSDATE,--:EMP_FEC_MOD,
                                                   --EMP_FEC_SEG         = :EMP_FEC_SEG,
                                                   EMP_SEXO            = :EMP_SEXO,
                                                   EMP_SEC_ID          = :EMP_SEC_ID,
                                                   EMP_BARRIO          = :EMP_BARRIO,
                                                   --EMP_FECHA_REINGRESO = :EMP_FECHA_REINGRESO,
                                                   EMP_EDU             = :EMP_EDU,
                                                   EMP_DIRE_NUMERO     = :EMP_DIRE_NUMERO,
                                                   EMP_TIP_SANGRE      = :EMP_TIP_SANGRE,
                                                   EMP_DISCAPACIDAD    = :EMP_DISCAPACIDAD,
                                                   EMP_NUM_CONADIS     = :EMP_NUM_CONADIS,
                                                   --EMP_AFI_FARMA       = :EMP_AFI_FARMA,
                                                   --EMP_AFI_FARMA_FEC   = :EMP_AFI_FARMA_FEC,
                                                   --EMP_AFI_SEG_FEC     = :EMP_AFI_SEG_FEC,
                                                   --EMP_HOR             = :EMP_HOR,
                                                   EMP_PAG_FON_RES     = :EMP_PAG_FON_RES,
                                                   EMP_PASAPORTE       = :EMP_PASAPORTE,
                                                   --EMP_SUJ_CRDT        = :EMP_SUJ_CRDT,
                                                   EMP_MAIL            = :EMP_MAIL,
                                                   EMP_MAIL_PER        = :EMP_MAIL_PER,
                                                   --EMP_CLAVE_ASIST     = :EMP_CLAVE_ASIST,
                                                   --EMP_PORC_DISC       = :EMP_PORC_DISC,
                                                   --DSC_ID              = :DSC_ID,
                                                   EMP_PAG_DEC_TER     = :EMP_PAG_DEC_TER,
                                                   EMP_PAG_DEC_CUA     = :EMP_PAG_DEC_CUA,
                                                   --EMP_OBS             = :EMP_OBS,
                                                   --FEC_CONTRATO_AUX    = :FEC_CONTRATO_AUX,                                                   
                                                   EMP_DEPENDIENTES    = :EMP_DEPENDIENTES
                                            WHERE  EMP_ID              = :EMP_ID";


        private static string sqlRegistrarFamiliar = @"INSERT INTO DESARROLLO.DAT_EMP_FAM (EMP_ID,
                                                                   EMP_FAM_ID,
                                                                   EMP_FAM_NOMBRE,
                                                                   EMP_FAM_FEC_NAC,
                                                                   EMP_FAM_PARENT,
                                                                   EMP_FAM_OCUP,
                                                                   EMP_FAM_TELF_REF,
                                                                   EMP_FAM_DISC,
                                                                   EMP_FAM_CREA
                                                                    )
                                                       VALUES      (:EMP_ID,
                                                                    :EMP_FAM_ID,
                                                                    :EMP_FAM_NOMBRE,
                                                                    :EMP_FAM_FEC_NAC,
                                                                    :EMP_FAM_PARENT,
                                                                    :EMP_FAM_OCUP,
                                                                    :EMP_FAM_TELF_REF,
                                                                    :EMP_FAM_DISC,
                                                                    SYSDATE
                                                                    )";
        private static string sqlActualizarFamiliar = @"UPDATE  DESARROLLO.DAT_EMP_FAM 
                                                        SET 
                                                                EMP_FAM_NOMBRE=:EMP_FAM_NOMBRE,
                                                                EMP_FAM_FEC_NAC=:EMP_FAM_FEC_NAC,
                                                                EMP_FAM_PARENT=:EMP_FAM_PARENT,
                                                                EMP_FAM_OCUP=:EMP_FAM_OCUP,
                                                                EMP_FAM_TELF_REF=:EMP_FAM_TELF_REF,
                                                                EMP_FAM_DISC=:EMP_FAM_DISC,
                                                                EMP_FAM_ACT:=SYSDATE 
                                                        WHERE   EMP_ID=:EMP_ID AND EMP_FAM_ID=:EMP_FAM_ID";

        private static string sqlEliminaFamiliar = @"DELETE DESARROLLO.DAT_EMP_FAM WHERE EMP_ID=:EMP_ID AND EMP_FAM_ID=:EMP_FAM_ID";

        private static string sqlRegistraReingreso = @"INSERT INTO DESARROLLO.DAT_DET_ING_EMP (EMP_ID,ING_ID,ING_FEC_ING) 
                                                       VALUES(:EMP_ID,1,:LAB_FEC_INGRESO) ";
        private static string sqlCargarConsumoLocal = "DESARROLLO.PK_NOMINATCG.F_CARGACONSUMO";
        private static string sqlProcesaFaltanteCaja = "DESARROLLO.P_CARGA_NOMINA_FALTANTE_CJ";
        private static string sqlProcesaAsientoRol = "DESARROLLO.P_CARGA_ASIENTO_NOMINA";
        private static string sqlProcesaCargaAsientoRol = "DESARROLLO.JDE_ASIENTO_CONTABLE";
        private static string sqlVerificaAsientoRol = @"
SELECT COUNT(1)
          FROM DAT_ROL_CONT
         WHERE     SEG_ROL_ID = :ROL_ID
               AND SEG_ROL_REPRO = :ROL_REPRO
               AND TIPO IN (1, 2)";
        private static string sqlVerificaCargaAsientoRol = @"
SELECT COUNT (1)
  FROM DAT_CNT_LOAD
 WHERE CNT_STDO = 0 AND ID_PRC = 0 AND PER_ID = :PER_ID
";
        private static string sqlVerProcesoAsientoRol = @"
--SELECT * FROM (
  SELECT DT.CLI_ID,
         (SELECT C.CLI_NOMBRE FROM DAT_CLIENTE C WHERE C.CLI_ID =DT.CLI_ID) LOCAL,       
         ROUND(SUM (DET_DIA_DB ),2)DEBE,
         ROUND(SUM (DET_DIA_HB),2) HABER,
         SUM (ROUND (DET_DIA_DB, 2)) - SUM (ROUND (DET_DIA_HB, 2))    DIFERENCIA
    FROM DESARROLLO.DAT_DET_DIARIO DT
         JOIN DAT_DIARIO D
             ON (    DT.PERC_ID = D.PERC_ID
                 AND DT.DIA_ID = D.DIA_ID
                 AND DT.PAT_ID = D.PAT_ID)
   WHERE  D.TIP_MAT_ID = 9
AND DIA_FEC_DIARIO = (SELECT TRUNC(LAST_DAY(R.ROL_FECHA_INI)) FROM DAT_ROL_SEG R WHERE R.SEG_ROL_ID =:P_ROL_ID AND R.SEG_ROL_ESTADO =1)
GROUP BY DT.CLI_ID, DT.PERC_ID--) WHERE DIFERENCIA!=0 
";
        private static string sqlCargaFaltanteCaja = @"
 SELECT LOC_NOMBRE LOCAL, ROUND (SUM (VALOR), 2) VALOR
    FROM V_REPORTE_SANCIONES S
         JOIN DAT_CLIENTE C ON (S.LOC_ID = C.LOC_ID)         
   WHERE     TIPO = 20050         
         AND FECHA_SANCION BETWEEN (SELECT TO_DATE (
                                                  '21'
                                               || TO_CHAR (
                                                      ADD_MONTHS (ROL_FECHA_INI,
                                                                  -1),
                                                      'MM/RRRR'),
                                               'DD/MM/RRRR')    FECHAINI
                                      FROM DAT_ROL_SEG
                                     WHERE SEG_ROL_ID = :ROL_ID AND ROWNUM = 1)
                               AND (SELECT TO_DATE (
                                                  '20'
                                               || TO_CHAR (ROL_FECHA_INI,
                                                           'MM/RRRR'),
                                               'DD/MM/RRRR')    FECHAFIN
                                      FROM DAT_ROL_SEG
                                     WHERE SEG_ROL_ID = :ROL_ID AND ROWNUM = 1)
         AND C.PAT_ID =:PAT_ID
         AND ADM = 0
AND C.LOC_ID NOT IN(1)
         GROUP BY LOC_NOMBRE
ORDER BY 1 ASC ";
        private static string sqlCargaFaltanteCajaDT = @"
 SELECT LOC_NOMBRE LOCAL,FECHA_SANCION FECHA,EMP_ID EMPID, NOMBRE, ROUND (VALOR, 2) VALOR, OBSERVACION 
    FROM V_REPORTE_SANCIONES S
         JOIN DAT_CLIENTE C ON (S.LOC_ID = C.LOC_ID)         
   WHERE     TIPO = 20050         
         AND FECHA_SANCION BETWEEN (SELECT TO_DATE (
                                                  '21'
                                               || TO_CHAR (
                                                      ADD_MONTHS (ROL_FECHA_INI,
                                                                  -1),
                                                      'MM/RRRR'),
                                               'DD/MM/RRRR')    FECHAINI
                                      FROM DAT_ROL_SEG
                                     WHERE SEG_ROL_ID = :ROL_ID AND ROWNUM = 1)
                               AND (SELECT TO_DATE (
                                                  '20'
                                               || TO_CHAR (ROL_FECHA_INI,
                                                           'MM/RRRR'),
                                               'DD/MM/RRRR')    FECHAFIN
                                      FROM DAT_ROL_SEG
                                     WHERE SEG_ROL_ID = :ROL_ID AND ROWNUM = 1)
         AND C.PAT_ID =:PAT_ID
         AND ADM = 0
AND C.LOC_ID NOT IN(1)        
ORDER BY LOC_NOMBRE,FECHA_SANCION,NOMBRE ASC ";
        private static string sqlRegistrarDiscapacidad = @"INSERT INTO DESARROLLO.DAT_DSCP (DSCP_ID,
                                                                                             EMP_ID,
                                                                                             DSCP_TIP_ID,
                                                                                             DSCP_NUM,
                                                                                             DSCP_PRCT,
                                                                                             DSCP_DSC)
                                                                                     VALUES ( :DSCP_ID,
                                                                                             :EMP_ID,
                                                                                             :DSCP_TIP_ID,
                                                                                             :DSCP_NUM,
                                                                                             :DSCP_PRCT,
                                                                                             :DSCP_DSC) ";
        private static string sqlActualizarDiscapacidad = @"UPDATE DESARROLLO.DAT_DSCP
                                                            SET DSCP_TIP_ID = :DSCP_TIP_ID,
                                                                DSCP_NUM = :DSCP_NUM,
                                                                DSCP_PRCT = :DSCP_PRCT,
                                                                DSCP_DSC = :DSCP_DSC
                                                            WHERE DSCP_ID = :DSCP_ID AND EMP_ID = :EMP_ID";

        private static string sqlActualizaEstadoDiscapacidad = @"DESARROLLO.PK_NOMINATCG.P_ACTUALIZA_DISCAPACIDAD";

        private static string sqlEliminarDiscapacidad = "DELETE DESARROLLO.DAT_DSCP WHERE DSCP_ID = :DSCP_ID AND EMP_ID = :EMP_ID ";
        private static string sqlEmpleadoLocal = @"SELECT CLI_ID
                                                     FROM DESARROLLO.DAT_CLIENTE
                                                    WHERE LOC_ID IN (SELECT LOC_ID
                                                                       FROM DESARROLLO.V_DETALLE_EMP
                                                                      WHERE EMP_ID = :empID)";
        private static string sqlEmpleadoEmail = "SELECT EMP_MAIL_PER FROM DESARROLLO.V_DETALLE_EMP WHERE EMP_ID=:EMP_ID";
        private static string sqlRegistraReingresoID = "SELECT COUNT(1)+1 FROM DESARROLLO.DAT_EMP_ING";
        private static string sqlRegistraReingreso2 = @"INSERT INTO DESARROLLO.DAT_EMP_ING (EMP_ING, EMP_CI,EMP_ID,EMP_ID_ANT,FECHA_REG,USER_CREA)
                                                       VALUES (:EMP_ING,:EMP_CI,:EMP_ID,:EMP_ID_ANT,SYSDATE,:USER_CREA) ";
        private static string sqlValidaEmpleado = @"SELECT COUNT(1) FROM V_DETALLE_EMP WHERE EMP_CI=:EMP_CI AND PAT_ID=:PAT_ID";
        private static string sqlValidaEmpleadoCI = @"SELECT COUNT(1) FROM V_DETALLE_EMP WHERE EMP_CI=:EMP_CI ";
        private static string sqlValidaEmpleadoActivo = @"SELECT COUNT(1) FROM V_DETALLE_EMP WHERE EMP_CI=:EMP_CI AND PAT_ID=:PAT_ID AND LAB_ESTADO=1";
        private static string sqlValidaSalidaEmpleado = @"SELECT COUNT(1) FROM V_DETALLE_EMP WHERE EMP_CI=:EMP_CI AND PAT_ID=:PAT_ID AND EMP_FEC_SALIDA IS NULL";
        private static string sqlPrestamoEmpleado = @"SELECT P.EMP_ID,
                                                           (SELECT NOMBRE
                                                              FROM V_DETALLE_EMP
                                                             WHERE EMP_ID = P.EMP_ID)
                                                               EMPLEADO,
                                                           PRES_PLAZO,
                                                           PRES_VALOR,
                                                           PRES_OBSERVACION,
                                                           (SELECT TRUNC(ROL_FECHA_INI)
                                                              FROM DAT_ROL_SEG
                                                             WHERE SEG_ROL_ID = ROL_ID_GEN AND SEG_ROL_REPRO = ROL_REPRO)
                                                               PERIODO,
                                                           ROL_ID_GEN,
                                                           ROL_REPRO,
                                                           P.ROL_ID,
                                                           (SELECT ROL_SUBCUENTA || ' - ' || ROL_CUENTA
                                                              FROM VAR_ROL
                                                             WHERE ROL_ID = P.ROL_ID)
                                                               CUENTA,
                                                          
                                                           FECHAREGISTRO,
                                                           --FECHAACTUALIZA,
                                                           --PRES_ESTADO,
                                                           DECODE (PRES_ESTADO, 1, 'ACTIVO', 'INACTIVO')
                                                               ESTADO
                                                      FROM DESARROLLO.DAT_PRESTAMO P";
        private static string sqlTablaAmortizacion = @"Select EMP_ID, ROL_ID_GEN, ROL_REPRO, 
                                                              ROL_ID, DET_PRES_ID, ROUND(DET_PRES_VALOR,2) DET_PRES_VALOR, 
                                                              DET_PRES_ROL, DET_PRES_REPRO, FECHACREACION, 
                                                              FECHAMODIF, F_MES_CALCULADO(DET_PRES_ROL) PERIODO,DET_PRES_VALOR_PAG
                                                        From DESARROLLO.DAT_TAB_AMORTI T
                                                        Where EMP_ID = :EMP_ID
                                                        And   ROL_ID_GEN = :ROL_ID_GEN
                                                        And   ROL_REPRO = :ROL_REPRO
                                                        And   ROL_ID = :ROL_ID";
        private static string sqlGeneraTablaAmortizacion = "DESARROLLO.P_GEN_TAB_AMOR";
        private static string sqlRegistraPrestamoEmpleado = @"
                                                            INSERT INTO DESARROLLO.DAT_PRESTAMO (EMP_ID,
                                                                                                 ROL_ID_GEN,
                                                                                                 ROL_REPRO,
                                                                                                 ROL_ID,
                                                                                                 PRES_PLAZO,
                                                                                                 PRES_VALOR,
                                                                                                 PRES_OBSERVACION,
                                                                                                 FECHAREGISTRO,
                                                                                                 --FECHAACTUALIZA,
                                                                                                 PRES_ESTADO)
                                                                 VALUES (:EMP_ID
                                                                         ,:ROL_ID_GEN
                                                                         ,:ROL_REPRO
                                                                         ,:ROL_ID
                                                                         ,:PRES_PLAZO
                                                                         ,:PRES_VALOR
                                                                         ,:PRES_OBSERVACION
                                                                         ,SYSDATE
                                                                         --,:FECHAACTUALIZA
                                                                         ,1--:PRES_ESTADO
                                                                         ) ";
        private static string sqlListaProyeccionGasto = @"
                                                        SELECT PROY_ID,
                                                               GAS_ID,
                                                               (SELECT GAS_NOMBRE
                                                                  FROM DESARROLLO.DAT_CONCEPTO_GASTO T
                                                                 WHERE GAS_ID = P.GAS_ID)    CONCEPTO,
                                                               ANIO,
                                                               EMP_ID,
                                                               PAT_ID,
                                                               PROY_VALOR,
                                                               PROY_ESTADO,                                                               
                                                               PROY_LIM,
                                                               (SELECT MIN (ADI_REN_FRAC_BAS) * 1.3
                                                                  FROM DESARROLLO.VAL_ADI_REN
                                                                 WHERE ADI_REN_POR > 0)      MAXLIM,
                                                                 FECHACRE, FECHAMOD
                                                          FROM DESARROLLO.DAT_GASTOS_PROY_EMP P
                                                         WHERE EMP_ID = :EMP_ID AND ANIO = :ANIO AND PAT_ID = :PAT_ID ORDER BY 1";
        private static string sqlGeneraProyeccionGasto = "DESARROLLO.P_INI_GASTOS_ANIO";
        private static string sqlActualizaProyeccionGasto = @"UPDATE DESARROLLO.DAT_GASTOS_PROY_EMP SET PROY_VALOR=:PROY_VALOR
                                                           WHERE EMP_ID = :EMP_ID AND ANIO = :ANIO AND PAT_ID = :PAT_ID AND GAS_ID=:GAS_ID";
        private static string sqlPeriodoID = "SELECT MAX( SEG_ROL_ID) FROM DESARROLLO.DAT_ROL_SEG WHERE SEG_ROL_ESTADO = 1 ";
        private static string sqlPeriodIDMax = "SELECT MAX(SEG_ROL_REPRO) FROM DESARROLLO.DAT_ROL_SEG WHERE SEG_ROL_ESTADO = 1 AND SEG_ROL_ID =";
        private static string sqlExisteRol = "SELECT COUNT(*) From DESARROLLO.DAT_ROL Where EMP_ID = :EMP_ID And   ROL_ID_GEN = :ROL_ID_GEN And   ROL_REPRO = :ROL_REPRO";
        private static string sqlExistePrestamo = "SELECT COUNT(*) From DESARROLLO.DAT_PRESTAMO Where EMP_ID = :EMP_ID And   ROL_ID_GEN = :ROL_ID_GEN And   ROL_REPRO = :ROL_REPRO";
        private static string sqlTransferenciaBancaria = "DESARROLLO.TRANSFERENCIA_BP";
        private static string sqlTransferenciaBancariaData = "SELECT  TRNID, BANID, BANCO, EMPID, EMPRE, DATOS FROM TRANS_BANCO_TMP WHERE EMPID=:emprID";
        private static string sqlTransferenciaBAncariaEmpresa = @"SELECT PAT_ID, SUBSTR (PAT_RAZ_SOCIAL, 1, INSTR (PAT_RAZ_SOCIAL, ' ', 1) - 1) AS RAZON FROM DESARROLLO.DAT_PATRONO WHERE PAT_ID NOT IN (23)";
        private static string sqlTransferenciaBancariaDecimoT = "DESARROLLO.TRANFERENCIA_DECIMOT";
        private static string sqlTransferenciaBancariaDecimoC = "DESARROLLO.TRANFERENCIA_DECIMOC";
        private static string sqlTranferenciaDecimo = "SELECT  TRNID, BANID, BANCO, EMPID, EMPRE, DATOS FROM TRANS_BANCO_TMP WHERE EMPID=:emprID and BANCO=:bancoID";
        private static string sqlActuarial = "P_ACTUARIAL";
        private static string sqlActuarialData = "SELECT * FROM ACTUARIAL_TMP";
        //EMPID, TIPOID, CEDULA, TIPOEMP, APELLIDO, NOMBRE, CARGO, CENTROCOSTO, SEXO, RUCEMPRESA, NACIMIENTO, EDADEMP, SUELDOMES
        private static string sqlActuarialSalario = "SELECT * FROM ACTUARIAL_ANIO_TMP WHERE EMPID=:empID";
        private static string sqlActuarialIngreso = "SELECT * FROM ACTUARIAL_INGRESO_TMP WHERE CEDULA=:empID";
        #endregion

        #region Propiedades
        private ConnectionDDBB db { get; set; }
        #endregion

        #region Methods
        public DataSet ActuarialEmpleado()
        {
            db.ExecProcedure(sqlActuarial);

            DataSet content = new DataSet();
            DataTable data = new DataTable();

            data = db.GetData(sqlActuarialData).Copy();
            data.TableName = "Empleados";
            content.Tables.Add(data);
            return content;

        }
        public DataSet ActuarialEmpleado(string empID, string empCI)
        {

            DataSet content = new DataSet();
            DataTable data = new DataTable();

            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":empID",empID)
            };
            data = db.GetData(sqlActuarialSalario, prm).Copy();
            data.TableName = "Salario";
            content.Tables.Add(data);
            prm = new OracleParameter[]
           {
                new OracleParameter(":empID",empCI)
           };
            data = db.GetData(sqlActuarialIngreso, prm).Copy();
            data.TableName = "Ingreso";
            content.Tables.Add(data);
            return content;

        }
        public DataTable TransferenciaBancariaDecimo(string proID, string anioINI, string anioFIN, string emprID, string tipoID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":emprID",proID),
                new OracleParameter(":emprID",anioINI),
                new OracleParameter(":emprID",anioFIN)
            };
            string sql;
            if (tipoID == "3")
            {
                db.ExecProcedure(sqlTransferenciaBancariaDecimoT, prm);
                sql = "DECIMO TERCERO";
            }

            else
            {
                db.ExecProcedure(sqlTransferenciaBancariaDecimoC, prm);
                sql = "DECIMO CUARTO";
            }

            prm = new OracleParameter[]
             {
                new OracleParameter(":emprID",emprID),
                new OracleParameter(":bancoID",sql)
             };

            return db.GetData(sqlTranferenciaDecimo, prm);
        }
        public DataTable TransferenciaBancaria(string emprID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":emprID",emprID)
            };
            return db.GetData(sqlTransferenciaBancariaData, prm);
        }

        public DataTable TransferenciaBancaria(string perID, string reproID, string empID, string tipoID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":perID",perID),
                new OracleParameter(":reproID",reproID),
                new OracleParameter(":empID",empID),
                new OracleParameter(":tipoID",tipoID)
            };
            db.ExecProcedure(sqlTransferenciaBancaria, prm);
            return db.GetData(sqlTransferenciaBAncariaEmpresa);
        }

        public int ActualizaProyeccionGasto(DataTable data)
        {
            foreach (DataRow row in data.Rows)
            {
                OracleParameter[] prm = new OracleParameter[]
                {
                    new OracleParameter(":PROY_VALOR",Convert.ToInt32(row["PROY_VALOR"])),
                    new OracleParameter(":EMP_ID",Convert.ToInt64(row["EMP_ID"])),
                    new OracleParameter(":ANIO",Convert.ToInt32(row["ANIO"])),
                    new OracleParameter(":PAT_ID",Convert.ToInt32(row["PAT_ID"])),
                    new OracleParameter(":GAS_ID",Convert.ToInt32(row["GAS_ID"]))
                };
                db.ExecQuery(sqlActualizaProyeccionGasto, prm);
            }

            return 1;
        }

        public DataTable ListaProyeccionGasto(string empID, string anio, string patID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID",empID),
                new OracleParameter(":ANIO",anio),
                new OracleParameter(":PAT_ID",patID),
            };
            DataTable datos = new DataTable();
            datos = db.GetData(sqlListaProyeccionGasto, prm);
            if (datos.Rows.Count == 0)
            {
                db.ExecProcedure(sqlGeneraProyeccionGasto, prm);
                datos = db.GetData(sqlListaProyeccionGasto, prm);
            }

            return datos;
        }

        private void GeneraPlantillaProyeccion(string empID, string anio, string patID)
        {
            OracleParameter[] prm1 = new OracleParameter[]
                {
                    new OracleParameter(":EMP_ID",empID),
                    new OracleParameter(":ANIO",anio),
                    new OracleParameter(":PAT_ID",patID)
                };
            if (db.ExecProcedure(sqlGeneraProyeccionGasto, prm1) == 1)
                ListaProyeccionGasto(empID, anio, patID);

        }
        public int ExisteRol(DatPrestamo pres)
        {
            pres.rolIdGen = db.GetEntero(sqlPeriodoID);
            pres.rolRepro = db.GetEntero(sqlPeriodIDMax + pres.rolIdGen);
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID",pres.empID ),
                new OracleParameter(":ROL_ID_GEN",pres.rolIdGen ),
                new OracleParameter(":ROL_REPRO",pres.rolRepro)
            };
            return db.GetEntero(sqlExisteRol, prm);
        }

        public int ExistePrestamo(DatPrestamo pres)
        {
            pres.rolIdGen = db.GetEntero(sqlPeriodoID);
            pres.rolRepro = db.GetEntero(sqlPeriodIDMax + pres.rolIdGen);
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID",pres.empID ),
                new OracleParameter(":ROL_ID_GEN",pres.rolIdGen ),
                new OracleParameter(":ROL_REPRO",pres.rolRepro)
            };
            return db.GetEntero(sqlExistePrestamo, prm);
        }


        public int RegistraTablaPrestamo(DatPrestamo pres)
        {
            pres.rolIdGen = db.GetEntero(sqlPeriodoID);
            pres.rolRepro = db.GetEntero(sqlPeriodIDMax + pres.rolIdGen);
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID",pres.empID ),
                new OracleParameter(":ROL_ID_GEN",pres.rolIdGen ),
                new OracleParameter(":ROL_REPRO",pres.rolRepro),
                new OracleParameter(":ROL_ID",pres.rolId),
                new OracleParameter(":PRES_PLAZO",pres.presPlazo),
                new OracleParameter(":PRES_VALOR",pres.presValor),
                new OracleParameter(":PRES_OBSERVACION",pres.presObservacion)
            };
            db.ExecQuery(sqlRegistraPrestamoEmpleado, prm);

            prm = new OracleParameter[]
        {
                new OracleParameter(":EMP_ID",pres.empID ),
                new OracleParameter(":ROL_ID_GEN",pres.rolIdGen ),
                new OracleParameter(":ROL_REPRO",pres.rolRepro),
                new OracleParameter(":ROL_ID",pres.rolId),
                new OracleParameter(":PRES_PLAZO",pres.presPlazo),
                new OracleParameter(":PRES_VALOR",pres.presValor)

        };
            db.ExecProcedure(sqlGeneraTablaAmortizacion, prm);

            return 0;
        }

        public int RegistraPrestamoEmpleado(DatPrestamo pres)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID",pres.empID ),
                new OracleParameter(":ROL_ID_GEN",pres.rolIdGen ),
                new OracleParameter(":ROL_REPRO",pres.rolRepro),
                new OracleParameter(":ROL_ID",pres.rolId),
                new OracleParameter(":PRES_PLAZO",pres.presPlazo),
                new OracleParameter(":PRES_VALOR",pres.presValor),
                new OracleParameter(":PRES_OBSERVACION",pres.presObservacion)

            };
            return db.ExecQuery(sqlRegistraPrestamoEmpleado, prm);
        }
        public int GeneraTablaAmortizacion(DatPrestamo pres)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID",pres.empID ),
                new OracleParameter(":ROL_ID_GEN",pres.rolIdGen ),
                new OracleParameter(":ROL_REPRO",pres.rolRepro),
                new OracleParameter(":ROL_ID",pres.rolId),
                new OracleParameter(":PRES_PLAZO",pres.presPlazo),
                new OracleParameter(":PRES_VALOR",pres.presValor)

            };
            return db.ExecProcedure(sqlGeneraTablaAmortizacion, prm);
        }
        public DataTable ListaTablaAmortizacion(DatPrestamo pres)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID",pres.empID ),
                new OracleParameter(":ROL_ID_GEN",pres.rolIdGen ),
                new OracleParameter(":ROL_REPRO",pres.rolRepro),
                new OracleParameter(":ROL_ID",pres.rolId)
            };
            return db.GetData(sqlTablaAmortizacion, prm);
        }
        public DataTable ListaPrestamoEmpleado()
        {
            return db.GetData(sqlPrestamoEmpleado);
        }

        public int ValidaEmpleadoSalidaEmpresa(string empCI, string emprID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_CI",empCI),
                new OracleParameter(":PAT_ID",emprID)
            };
            return db.GetEntero(sqlValidaSalidaEmpleado, prm);
        }

        public int ValidaEmpleadoActivo(string empCI, string emprID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_CI",empCI),
                new OracleParameter(":PAT_ID",emprID)
            };
            return db.GetEntero(sqlValidaEmpleadoActivo, prm);
        }
        public int ValidaEmpleadoEmpresa(string empCI)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_CI",empCI)
            };
            return db.GetEntero(sqlValidaEmpleadoCI, prm);
        }
        public int ValidaEmpleadoEmpresa(string empCI, string emprID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_CI",empCI),
                new OracleParameter(":PAT_ID",emprID)
            };
            return db.GetEntero(sqlValidaEmpleado, prm);
        }

        public int RegistraReingreso(string empCI, string empID, string empIDO, string userID)
        {
            int idReg = db.GetEntero(sqlRegistraReingresoID);
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ING",idReg),
                new OracleParameter(":EMP_CI",empCI),
                new OracleParameter(":EMP_ID",empID),
                new OracleParameter(":EMP_ID_ANT",empIDO),
                new OracleParameter(":USER_CREA",userID)
            };
            return db.GetEntero(sqlRegistraReingreso2, prm);
        }

        public string EmpleadoEmail(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID",empID)
            };
            return db.GetString(sqlEmpleadoEmail, prm);
        }
        public int EmpleadoLocal(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":empID",empID)
            };
            return db.GetEntero(sqlEmpleadoLocal, prm);
        }
        public int CargaConsumoLocal(string perID)
        {
            OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":PER_ID",perID )
            };
            return db.ExecProcedure(sqlCargarConsumoLocal, prm);
        }
        public int ProcesaFaltanteCaja(string perID, string patID)
        {
            OracleParameter[] prm = new OracleParameter[]{
                 new OracleParameter(":ROL_ID",perID ),
                new OracleParameter(":PAT_ID",patID )
            };
            return db.ExecProcedure(sqlProcesaFaltanteCaja, prm);
        }

        public int VerificaAsientoRol(string perID, string patID, int tipo)
        {
            string sql;
            OracleParameter[] prm;
            if (tipo.Equals(0))
            {
                prm = new OracleParameter[]{
                new OracleParameter(":ROL_ID",perID ),
                new OracleParameter(":ROL_REPRO",patID )
                };
                sql = sqlVerificaAsientoRol;
            }
            else
            {
                prm = new OracleParameter[]{
                new OracleParameter(":ROL_ID",perID )
                };
                sql = sqlVerificaCargaAsientoRol;
            }
            return db.GetEntero(sql, prm);
        }

        public int GeneraAsientoRol(string perID, string patID, int tipo)
        {
            string sql;
            OracleParameter[] prm;
            prm = new OracleParameter[]{
                new OracleParameter(":ROL_ID",perID )
                };

            if (tipo.Equals(0))
            {
                sql = sqlProcesaAsientoRol;
            }
            else
            {
                sql = sqlProcesaCargaAsientoRol;
            }
            return db.ExecProcedure(sql, prm);
        }

        public DataTable ConsultaAsientoRol(string perID, string patID, int tipo)
        {
            OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":ROL_ID",perID )
            };
            return db.GetData(sqlVerProcesoAsientoRol, prm);
        }
        public DataTable CargaFaltanteCaja(string perID, string patID, int tipo)
        {
            OracleParameter[] prm = new OracleParameter[]{
                new OracleParameter(":ROL_ID",perID ),
                new OracleParameter(":ROL_ID",perID ),
                new OracleParameter(":PAT_ID",patID )
            };
            string sql;
            if (tipo.Equals(1))
                sql = sqlCargaFaltanteCaja;
            else
                sql = sqlCargaFaltanteCajaDT;

            return db.GetData(sql, prm);
        }
        public string CargoEmpleadoRol(string empID, string perID, string reproID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID",empID),
                new OracleParameter(":PER_ID",perID ),
                new OracleParameter(":REPRO_ID",reproID)
            };
            return db.GetString(sqlCargoEmpleadoRol, prm);
        }
        public int ValidaCedula(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":empCI", empID)
            };
            return db.GetEntero(sqlValidaCedula, prm);
        }
        public int DeleteEmpleado(string empID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID", empID)
            };
            return db.ExecProcedure(sqlDeleteEmpleado, prm);
        }
        public int EliminaFamiliar(string empID, string famID)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":EMP_ID", empID),
                new OracleParameter(":EMP_FAM_ID", famID)
            };
            return db.ExecQuery(sqlEliminaFamiliar, prm);
        }

        public int ActualizarFamiliar(DatEmpFam emp)
        {
            OracleParameter[] prm = new OracleParameter[]{
            new OracleParameter(":EMP_FAM_NOMBRE",emp.empFamNombre),
            new OracleParameter(":EMP_FAM_FEC_NAC",emp.empFamFecNac),
            new OracleParameter(":EMP_FAM_PARENT",emp.empFamParent),
            new OracleParameter(":EMP_FAM_OCUP",emp.empFamOcup),
            new OracleParameter(":EMP_FAM_TELF_REF",emp.empFamTelfRef),
            new OracleParameter(":EMP_FAM_DISC",emp.empFamDisc),
            new OracleParameter(":EMP_ID",emp.empId),
            new OracleParameter(":EMP_FAM_ID",emp.empFamId)
            };
            return db.ExecQuery(sqlActualizarFamiliar, prm);
        }

        public int RegistrarFamiliar(DatEmpFam emp)
        {
            string sql = @"SELECT COUNT (1)
                          FROM DAT_EMP_FAM
                         WHERE     UPPER (TRIM (EMP_FAM_NOMBRE)) = UPPER (TRIM ( :EMP_FAM_NOMBRE))
                               AND EMP_ID = :EMP_ID ";
            OracleParameter[] prm = new OracleParameter[]{
            new OracleParameter(":EMP_FAM_NOMBRE",emp.empFamNombre),
            new OracleParameter(":EMP_ID",emp.empId) };
            int cnt = db.GetEntero(sql, prm);
            if (cnt.Equals(0))
            {
                prm = new OracleParameter[]{
                    new OracleParameter(":EMP_ID",emp.empId),
                    new OracleParameter(":EMP_FAM_ID",emp.empFamId),
                    new OracleParameter(":EMP_FAM_NOMBRE",emp.empFamNombre),
                    new OracleParameter(":EMP_FAM_FEC_NAC",emp.empFamFecNac),
                    new OracleParameter(":EMP_FAM_PARENT",emp.empFamParent),
                    new OracleParameter(":EMP_FAM_OCUP",emp.empFamOcup),
                    new OracleParameter(":EMP_FAM_TELF_REF",emp.empFamTelfRef),
                    new OracleParameter(":EMP_FAM_DISC",emp.empFamDisc)
                    };
                return db.ExecQuery(sqlRegistrarFamiliar, prm);
            }
            return cnt;
        }

        public Int64 RegistarEmpleado(DatEmp emp, string prmScript)
        {

            if (prmScript == "I")
            {

                emp.empId = db.GetEntero("SELECT DESARROLLO.PK_NOMINATCG.F_EMPLEADOID FROM DUAL");
                OracleParameter[] prm = new OracleParameter[]{
                 new OracleParameter(":EMP_ID",emp.empId),
                 new OracleParameter(":EMP_NOMBRE",emp.empNombre),
                 new OracleParameter(":EMP_DIREC",emp.empDirec),
                 new OracleParameter(":EMP_TELEFONO",emp.empTelefono),
                 new OracleParameter(":EMP_LUG_NAC",emp.empLugNac),
                 new OracleParameter(":EMP_FEC_NAC",emp.empFecNac),
                 new OracleParameter(":EMP_CI",emp.empCi),
                 new OracleParameter(":EMP_NUM_IESS",emp.empNumIess),
                 new OracleParameter(":EMP_EST_CIVIL",emp.empEstCivil),
                 new OracleParameter(":EMP_NUM_HIJOS",emp.empNumHijos),
                 new OracleParameter(":LAB_FEC_INGRESO",emp.labFecIngreso),
                 new OracleParameter(":EMP_CUENTA",emp.empCuenta),
                 new OracleParameter(":EMP_APELLIDO",emp.empApellido),
                 //new OracleParameter(":EMP_FEC_SALIDA",emp.empFecSalida),
                 new OracleParameter(":EMP_AFIL_HUMANA",emp.empAfiFarma),
                 new OracleParameter(":EMP_TELEFONO2",emp.empTelefono2),
                 //new OracleParameter(":EMP_FEC_SALIDAREAL",emp.empFecSalida),
                 //new OracleParameter(":EMP_CNTA_CAM",emp.empCntaCam),
                 new OracleParameter(":EMP_TIPO_CNTA",emp.empTipoCnta),
                 //new OracleParameter(":EMP_FEC_REG","DESARROLLO.NOMINA.FECHASERVER"),//emp.empFecReg),
                 //new OracleParameter(":EMP_FEC_MOD",emp.empFecMod),
                 //new OracleParameter(":EMP_FEC_SEG","DESARROLLO.NOMINA.FECHASERVER"),//emp.empFecSeg),
                 new OracleParameter(":LAB_FEC_INGRESO1",emp.labFecIngreso),
                 new OracleParameter(":EMP_SEXO",emp.empSexo),
                 new OracleParameter(":EMP_SEC_ID",emp.empSecId),
                 new OracleParameter(":EMP_BARRIO",emp.empBarrio),
                 //new OracleParameter(":EMP_FECHA_REINGRESO",emp.empFechaReingreso),
                 new OracleParameter(":EMP_EDU",emp.empEdu),
                 new OracleParameter(":EMP_DIRE_NUMERO",emp.empDireNumero),
                 new OracleParameter(":EMP_TIP_SANGRE",emp.empTipSangre),
                 new OracleParameter(":EMP_DISCAPACIDAD",emp.empDiscapacidad),
                 new OracleParameter(":EMP_NUM_CONADIS",emp.empNumConadis),
                 new OracleParameter(":EMP_AFI_FARMA",emp.empAfiFarma),
                 //new OracleParameter(":EMP_AFI_FARMA_FEC",emp.empAfiFarmaFec),
                 //new OracleParameter(":EMP_AFI_SEG_FEC",emp.empAfiSegFec),
                 //new OracleParameter(":EMP_HOR",emp.empHor),
                 new OracleParameter(":EMP_PAG_FON_RES",emp.empPagFonRes),
                 new OracleParameter(":EMP_PASAPORTE",emp.empPasaporte),
                 //new OracleParameter(":EMP_SUJ_CRDT",emp.empSujCrdt),
                 new OracleParameter(":EMP_MAIL",emp.empMail),
                 new OracleParameter(":EMP_MAIL_PER",emp.empMailPer),
                 //new OracleParameter(":EMP_CLAVE_ASIST",emp.empClaveAsist),
                 //new OracleParameter(":EMP_PORC_DISC",emp.empPorcDisc),
                 //new OracleParameter(":DSC_ID",emp.dscId),
                 new OracleParameter(":EMP_PAG_DEC_TER",emp.empPagDecTer),
                 new OracleParameter(":EMP_PAG_DEC_CUA",emp.empPagDecCua),
                 //new OracleParameter(":EMP_OBS",emp.empObs),
                 //new OracleParameter(":FEC_CONTRATO_AUX","DESARROLLO.NOMINA.FECHASERVER"),//emp.fecContratoAux),
                 new OracleParameter(":EMP_DEPENDIENTES",emp.empDependientes)
                };
                if (db.ExecQuery(sqlInsert, prm) == 1)
                {

                    if (db.GetEntero("SELECT NVL(MAX(ING_ID),0)FROM DESARROLLO.DAT_DET_ING_EMP WHERE EMP_ID=" + emp.empId + " AND ING_FEC_ING='" + emp.labFecIngreso.Value.ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US")) + "'") == 0)
                    {
                        OracleParameter[] prm1 = new OracleParameter[]{
                            new OracleParameter(":EMP_ID",emp.empId),
                            new OracleParameter(":LAB_FEC_INGRESO",emp.labFecIngreso)};
                        db.ExecQuery(sqlRegistraReingreso, prm1);
                    }
                    return emp.empId;
                }
                else
                    return 0;
            }

            else
            {
                OracleParameter[] prm = new OracleParameter[]{

                 new OracleParameter(":EMP_NOMBRE",emp.empNombre),
                 new OracleParameter(":EMP_DIREC",emp.empDirec),
                 new OracleParameter(":EMP_TELEFONO",emp.empTelefono),
                 new OracleParameter(":EMP_LUG_NAC",emp.empLugNac),
                 new OracleParameter(":EMP_FEC_NAC",emp.empFecNac),
                 new OracleParameter(":EMP_CI",emp.empCi),
                 new OracleParameter(":EMP_NUM_IESS",emp.empNumIess),
                 new OracleParameter(":EMP_EST_CIVIL",emp.empEstCivil),
                 new OracleParameter(":EMP_NUM_HIJOS",emp.empNumHijos),
                 new OracleParameter(":LAB_FEC_INGRESO",emp.labFecIngreso),
                 new OracleParameter(":EMP_CUENTA",emp.empCuenta),
                 new OracleParameter(":EMP_APELLIDO",emp.empApellido),
                 new OracleParameter(":EMP_FEC_SALIDA",emp.empFecSalidareal),
                 new OracleParameter(":EMP_AFIL_HUMANA",emp.empAfiFarma),
                 new OracleParameter(":EMP_TELEFONO2",emp.empTelefono2),
                 //new OracleParameter(":EMP_FEC_SALIDAREAL",emp.empFecSalidareal),
                 //new OracleParameter(":EMP_CNTA_CAM",emp.empCntaCam),
                 new OracleParameter(":EMP_TIPO_CNTA",emp.empTipoCnta),
                 //new OracleParameter(":EMP_FEC_REG","DESARROLLO.NOMINA.FECHASERVER"),//emp.empFecReg),
                 //new OracleParameter(":EMP_FEC_MOD",emp.empFecMod),
                 //new OracleParameter(":EMP_FEC_SEG","DESARROLLO.NOMINA.FECHASERVER"),//emp.empFecSeg),
                 new OracleParameter(":EMP_SEXO",emp.empSexo),
                 new OracleParameter(":EMP_SEC_ID",emp.empSecId),
                 new OracleParameter(":EMP_BARRIO",emp.empBarrio),
                 //new OracleParameter(":EMP_FECHA_REINGRESO",emp.empFechaReingreso),
                 new OracleParameter(":EMP_EDU",emp.empEdu),
                 new OracleParameter(":EMP_DIRE_NUMERO",emp.empDireNumero),
                 new OracleParameter(":EMP_TIP_SANGRE",emp.empTipSangre),
                 new OracleParameter(":EMP_DISCAPACIDAD",emp.empDiscapacidad),
                 new OracleParameter(":EMP_NUM_CONADIS",emp.empNumConadis),
                 //new OracleParameter(":EMP_AFI_FARMA",emp.empAfiFarma),
                 //new OracleParameter(":EMP_AFI_FARMA_FEC",emp.empAfiFarmaFec),
                 //new OracleParameter(":EMP_AFI_SEG_FEC",emp.empAfiSegFec),
                 //new OracleParameter(":EMP_HOR",emp.empHor),
                 new OracleParameter(":EMP_PAG_FON_RES",emp.empPagFonRes),
                 new OracleParameter(":EMP_PASAPORTE",emp.empPasaporte),
                 //new OracleParameter(":EMP_SUJ_CRDT",emp.empSujCrdt),
                 new OracleParameter(":EMP_MAIL",emp.empMail),
                 new OracleParameter(":EMP_MAIL_PER",emp.empMailPer),
                 //new OracleParameter(":EMP_CLAVE_ASIST",emp.empClaveAsist),
                 //new OracleParameter(":EMP_PORC_DISC",emp.empPorcDisc),
                 //new OracleParameter(":DSC_ID",emp.dscId),
                 new OracleParameter(":EMP_PAG_DEC_TER",emp.empPagDecTer),
                 new OracleParameter(":EMP_PAG_DEC_CUA",emp.empPagDecCua),
                 //new OracleParameter(":EMP_OBS",emp.empObs),
                 //new OracleParameter(":FEC_CONTRATO_AUX","DESARROLLO.NOMINA.FECHASERVER"),//emp.fecContratoAux),
                 new OracleParameter(":EMP_DEPENDIENTES",emp.empDependientes),
                 new OracleParameter(":EMP_ID",emp.empId),
                };

                if (db.ExecQuery(sqlUpdate, prm) == 1)
                {

                    //if (emp.empFecSalidareal != null)
                    //{
                    //    OracleParameter[] prmPer;
                    //    string[] resp = { "fechaIni", "fechaFin" };
                    //    int perID = db.GetEntero("SELECT NVL(MAX(ROL_ID_GEN),0) FROM DESARROLLO.DAT_ROL WHERE ROL_REPRO=1 AND EMP_ID=" + emp.empId);
                    //    string fechaIni = string.Empty;
                    //    string fechaFin = string.Empty;
                    //    if (perID != 0)
                    //    {
                    //        prmPer = new OracleParameter[]{
                    //             new OracleParameter(":perID",perID),
                    //             new OracleParameter(":reproID",1),
                    //             new OracleParameter("fechaIni",OracleDbType.Date,ParameterDirection.Output),
                    //             new OracleParameter("fechaFin",OracleDbType.Date,ParameterDirection.Output)};
                    //        //string[] resp = { "fechaIni", "fechaFin"};
                    //        //db.ExecProcedureOUTIN("DESARROLLO.P_FECH_RANG_PERIODO", prmPer, resp);

                    //    }
                    //    else
                    //    {
                    //        perID = db.GetEntero("SELECT DESARROLLO.F_ULTIMO_PERIODO FROM DUAL");
                    //        prmPer = new OracleParameter[]{
                    //             new OracleParameter(":perID",perID),
                    //             new OracleParameter(":reproID",1),
                    //             new OracleParameter("fechaIni",OracleDbType.Date,ParameterDirection.Output),
                    //             new OracleParameter("fechaFin",OracleDbType.Date,ParameterDirection.Output)};
                    //        //string[] resp = { "fechaIni", "fechaFin" };
                    //        //db.ExecProcedureOUTIN("DESARROLLO.P_FECH_RANG_PERIODO", prmPer, resp);
                    //    }
                    //    resp = db.ExecProcedureOUTIN("DESARROLLO.P_FECH_RANG_PERIODO", prmPer,resp);

                    //}

                    return emp.empId;
                }

                else
                    return 0;

            }

        }

        public string[] ValidaFechaIngreso(string empID)
        {
            if (empID == string.Empty)
                empID = "0";
            OracleParameter[] prmPer;
            string[] resp = { "fechaIni", "fechaFin" };
            int perID = db.GetEntero("SELECT NVL(MAX(ROL_ID_GEN),0) FROM DESARROLLO.DAT_ROL WHERE ROL_REPRO=1 AND EMP_ID=" + empID);
            string fechaIni = string.Empty;
            string fechaFin = string.Empty;
            if (perID != 0)
            {
                prmPer = new OracleParameter[]{
                         new OracleParameter(":perID",perID),
                         new OracleParameter(":reproID",1),
                         new OracleParameter("fechaIni",OracleDbType.Date,ParameterDirection.Output),
                         new OracleParameter("fechaFin",OracleDbType.Date,ParameterDirection.Output)};
            }
            else
            {
                perID = db.GetEntero("SELECT DESARROLLO.F_ULTIMO_PERIODO FROM DUAL");
                prmPer = new OracleParameter[]{
                         new OracleParameter(":perID",perID),
                         new OracleParameter(":reproID",1),
                         new OracleParameter("fechaIni",OracleDbType.Date,ParameterDirection.Output),
                         new OracleParameter("fechaFin",OracleDbType.Date,ParameterDirection.Output)};
            }
            return db.ExecProcedureOUTIN("DESARROLLO.P_FECH_RANG_PERIODO", prmPer, resp);


        }

        public Int64 RegistarDiscapacidad(DiscapacidaEmpleadodEntity dsc, string prmScript)
        {
            OracleParameter[] prm;
            string query = string.Empty;

            switch (prmScript)
            {
                case "I":
                    dsc.DSCP_ID = db.GetEntero("SELECT COUNT(1)+1 FROM DAT_DSCP WHERE EMP_ID=" + dsc.EMP_ID);
                    prm = new OracleParameter[]{
                 new OracleParameter(":DSCP_ID",dsc.DSCP_ID),
                 new OracleParameter(":EMP_ID",dsc.EMP_ID),
                 new OracleParameter(":DSCP_TIP_ID",dsc.DSCP_TIP_ID),
                 new OracleParameter(":DSCP_NUM",dsc.DSCP_NUM),
                 new OracleParameter(":DSCP_PRCT",dsc.DSCP_PRCT),
                 new OracleParameter(":DSCP_DSC",dsc.DSCP_DSC)

                 };
                    query = sqlRegistrarDiscapacidad;
                    break;
                case "U":
                    prm = new OracleParameter[]{
                 new OracleParameter(":DSCP_TIP_ID",dsc.DSCP_TIP_ID),
                 new OracleParameter(":DSCP_NUM",dsc.DSCP_NUM),
                 new OracleParameter(":DSCP_PRCT",dsc.DSCP_PRCT),
                 new OracleParameter(":DSCP_DSC",dsc.DSCP_DSC),
                 new OracleParameter(":DSCP_ID",dsc.DSCP_ID),
                 new OracleParameter(":EMP_ID",dsc.EMP_ID)
                };
                    query = sqlActualizarDiscapacidad;
                    break;
                default:
                    prm = new OracleParameter[]{
                 new OracleParameter(":DSCP_ID",dsc.DSCP_ID),
                 new OracleParameter(":EMP_ID",dsc.EMP_ID)
                };
                    query = sqlEliminarDiscapacidad;
                    break;
            }
            int conf = db.ExecQuery(query, prm);

            OracleParameter[] prm1 = new OracleParameter[]{
            new OracleParameter(":empID",dsc.EMP_ID)
            };

            db.ExecProcedure(sqlActualizaEstadoDiscapacidad, prm1);
            return conf;


        }

        public DataTable Familiares(string empID)
        {

            OracleParameter[] prm = new OracleParameter[]{
            new OracleParameter(":empID",empID)
            };
            return db.GetData(sqlFamiliares, prm);
            //return datos;
        }

        public DataTable ListaEmpleadoDetalle()
        {
            return db.GetData(sqlListarEmpleadoDetalle);
            //return datos;
        }
        public DataTable ListaEmpleadoDetalle(string prm)
        {
            return db.GetData(sqlListarEmpleadoDetallePRM + prm);
            //return datos;
        }
        public DataSet PaginaEmpleadoDetalle(int recordIni, int recordMax)
        {
            return db.paginacionData(sqlPaginaEmpleadoDetalle, recordIni, recordMax);
            //return datos;
        }
        public DataTable ListaEmpleado()
        {
            return db.GetData(sqlListarEmpleado);
            //return datos;
        }
        public DataTable ListaEmpleadoCI(string cedulaEmp)
        {
            return db.GetData(sqlListarEmpleadoDetalle + " WHERE EMP_CI=" + cedulaEmp);
            //return datos;
        }
        public DataTable ListaEmpleado(string empID)
        {
            return db.GetData(sqlListarEmpleado + " WHERE EMP_ID=" + empID);
            //return datos;
        }

        public DataTable ListaDiscapacidad()
        {
            return db.GetData(sqlDiscapacidad);
            //return datos;
        }
        public DataTable ListaEmpleadoDiscapacidad(string empID, string tipo)
        {
            string sql;
            OracleParameter[] prm = new OracleParameter[]{
            new OracleParameter(":empID",empID)
            };
            if (tipo.Equals("V"))
                sql = sqlDiscapacidadEmp;
            else
                sql = sqlEmpleadoDiscapacidad;

            return db.GetData(sql, prm);
        }

        public DataTable ListaEmpleadoDT(string empID)
        {
            return db.GetData(sqlListarEmpleadoDetalle + " WHERE EMP_ID=" + empID);
            //return datos;
        }

        private DataTable RenameColumns(DataTable datos)
        {
            datos.Columns["EMP_ID"].ColumnName = "ID";
            datos.Columns["EMP_NOMBRE"].ColumnName = "Nombres";
            datos.Columns["EMP_DIREC"].ColumnName = "Dirección";
            datos.Columns["EMP_TELEFONO"].ColumnName = "Teléfono";
            datos.Columns["EMP_LUG_NAC"].ColumnName = "Lugar Nacimiento";
            datos.Columns["EMP_FEC_NAC"].ColumnName = "Fecha Nacimiento";
            datos.Columns["EMP_CI"].ColumnName = "Cédula";
            datos.Columns["EMP_NUM_IESS"].ColumnName = "ID";
            datos.Columns["EMP_EST_CIVIL"].ColumnName = "ID";
            datos.Columns["EMP_NUM_HIJOS"].ColumnName = "ID";
            datos.Columns["LAB_FEC_INGRESO"].ColumnName = "ID";
            datos.Columns["EMP_CUENTA"].ColumnName = "ID";
            datos.Columns["EMP_APELLIDO"].ColumnName = "ID";
            datos.Columns["EMP_FEC_SALIDA"].ColumnName = "ID";
            datos.Columns["EMP_AFIL_HUMANA"].ColumnName = "ID";
            datos.Columns["EMP_TELEFONO2"].ColumnName = "ID";
            datos.Columns["EMP_FEC_SALIDAREAL"].ColumnName = "ID";
            datos.Columns["EMP_CNTA_CAM"].ColumnName = "ID";
            datos.Columns["EMP_TIPO_CNTA"].ColumnName = "ID";
            datos.Columns["EMP_FEC_REG"].ColumnName = "ID";
            datos.Columns["EMP_FEC_MOD"].ColumnName = "ID";
            datos.Columns["EMP_FEC_SEG"].ColumnName = "ID";
            datos.Columns["EMP_SEXO"].ColumnName = "ID";
            datos.Columns["EMP_SEC_ID"].ColumnName = "ID";
            datos.Columns["EMP_BARRIO"].ColumnName = "ID";
            datos.Columns["EMP_FECHA_REINGRESO"].ColumnName = "ID";
            datos.Columns["EMP_EDU"].ColumnName = "ID";
            datos.Columns["EMP_DIRE_NUMERO"].ColumnName = "ID";
            datos.Columns["EMP_TIP_SANGRE"].ColumnName = "ID";
            datos.Columns["EMP_DISCAPACIDAD"].ColumnName = "ID";
            datos.Columns["EMP_NUM_CONADIS"].ColumnName = "ID";
            datos.Columns["EMP_AFI_FARMA"].ColumnName = "ID";
            datos.Columns["EMP_AFI_FARMA_FEC"].ColumnName = "ID";
            datos.Columns["EMP_AFI_SEG_FEC"].ColumnName = "ID";
            datos.Columns["EMP_HOR"].ColumnName = "ID";
            datos.Columns["EMP_PAG_FON_RES"].ColumnName = "ID";
            datos.Columns["EMP_PASAPORTE"].ColumnName = "ID";
            datos.Columns["EMP_SUJ_CRDT"].ColumnName = "ID";
            datos.Columns["EMP_MAIL"].ColumnName = "ID";
            datos.Columns["EMP_CLAVE_ASIST"].ColumnName = "ID";
            datos.Columns["EMP_PORC_DISC"].ColumnName = "ID";
            datos.Columns["DSC_ID"].ColumnName = "ID";
            datos.Columns["EMP_PAG_DEC_TER"].ColumnName = "ID";
            datos.Columns["EMP_PAG_DEC_CUA"].ColumnName = "ID";
            datos.AcceptChanges();
            return datos;
        }

        //public List<EmpleadoEntity> ListarEmpleado()
        //{
        //    List<EmpleadoEntity> lis = new List<EmpleadoEntity>();
        //    var reader = db.ExecuteSelect(sqlListarEmpleado);
        //    while (reader.Read())
        //    {
        //        lis.Add(AssignDataEmpleado(reader));
        //    }
        //    return lis;
        //}

        private EmpleadoEntity AssignDataEmpleado(IDataReader reader)
        {
            EmpleadoEntity item = new EmpleadoEntity();
            item.EmpleadoID = Convert.ToInt64(reader["EMP_ID"]);
            item.Nombre = Convert.ToString(reader["EMP_NOMBRE"]);
            item.Direccion = Convert.ToString(reader["EMP_DIREC"]);
            item.Telefono = Convert.ToString(reader["EMP_TELEFONO"]);
            //item. = Convert.ToString(reader["PAT_REP_LEGAL"]);
            //item.Ruc = Convert.ToString(reader["PAT_NUM_RUC"]);
            //item.Estado = Convert.ToInt32(reader["PAT_ESTADO"]);
            //item.Observacion = Convert.ToString(reader["PAT_OBS"]);

            return item;
        }

        #endregion

    }
}
