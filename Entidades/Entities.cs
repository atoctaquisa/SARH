using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class Entities
    {
    }

    public class DatUsro
    {
        public decimal usrocdgo;
        public string usrologin;
        public string usronomb;
        public decimal usrostdo;
        public string tpuscdgo;
        public DateTime usrofcrea;
        public DateTime usrofmod;
        public string usropass;
    }
    public class DatDetDiario
    {
        public decimal cueId;
        public decimal cueId_;
        public decimal percId;
        public decimal diaId;
        public decimal patId;
        public decimal cliId;
        public decimal cliId_;
        public decimal detDiaDb;
        public decimal detDiaHb;
        public DateTime detDiaFecReg;
        public DateTime detDiaFecMod;        
        public decimal detDiaCliSeg;
        public decimal detId;
        public decimal ordImp;
        public string usuCrea;
        public string usuModif;
        public decimal anioPerc;
        public string detObser;
    }
        public class DatDiario
    {
        public decimal percId;
        public decimal diaId;
        public decimal diaDia;
        public decimal cliId;
        public decimal tipMatId;
        public string diaObs;       
        public decimal diaOri;
        public DateTime diaFecDiario;
        public string diaResp;
        public DateTime diaFecReg;
        public DateTime diaFecMod;
        public decimal diaCodOri;
        public decimal diaEstado;
        public decimal diaIdProv;
        public decimal patId;
        public string diaNumCheq;
        public DateTime diaFecCheq;
        public string diaBeneficiario;
        public decimal diaNumEgreso;
        public string usuCrea;
        public string usuModif;
        public decimal anioPerc;
        public decimal provId;
        public decimal datPatId;
        public string numDoc;
    }

        public class DatDetLiq
    {
        public decimal empId;
        public decimal liqId;
        public decimal rubLiqId;
        public decimal detLiqRef;
        public decimal detLiqValor;
        public string detLiqObs;
    }
        public class DatDetRolLiq
    {
        public decimal segRolId;
        public decimal segRolRepro;
        public decimal empId;
        public decimal rolId;
        public decimal rolIdOrg;
        public decimal rolLiqId;
        public decimal rolLiqValor;
        public DateTime rolLiqFecReg;
    }
        public class DatIessDiaEnfe
    {
        public decimal diaId;
        public string empId;
        public decimal rolIdGen;
        public decimal rolRepro;
        public decimal rolIdGen_;
        public decimal rolRepro_;
        public decimal diaNum;
        public decimal diaPorc;

    }

    public class DatIessEnfermedad
    {
        public string empId;
        public decimal rolIdGen;
        public decimal rolRepro;
        public decimal rolIdGen_;
        public decimal rolRepro_;
        public string  iessFechainicio;
        public string  iessFechafin;
        public DateTime iessFechaingreso;
        public DateTime iessFechamodif;
        public decimal iessTipo;
        public string iessObservacion;
        public decimal dias25;
        public decimal dias100;

    }

    public class DatGastosProyEmp
    {
        public decimal proyId;
        public decimal anio;
        public decimal proyValor;
        public decimal proyEstado;
        public DateTime fechacre;
        public DateTime fechamod;
        public decimal proyLim;
    }
    public class DatConceptoGasto
    {
        public decimal gasId { get; set; }
        public string gasNombre { get; set; }
        public decimal gasPor { get; set; }
        public decimal gasEstado { get; set; }
        public DateTime fechacre { get; set; }
        public DateTime fechamod { get; set; }
    }

    public class DatRolSeg
    {
        public decimal segRolId { get; set; }
        public DateTime rolFechaIni { get; set; }
        public DateTime rolFechaFin { get; set; }
        public decimal totalIng { get; set; }
        public decimal totalEgr { get; set; }
        public decimal totalTotal { get; set; }
        public decimal totalEmp { get; set; }
        public decimal segRolRepro { get; set; }
        public string segRolObs { get; set; }
        public DateTime segRolReproFecha { get; set; }
        public decimal segRolEstado { get; set; }
        public decimal segEstQuin { get; set; }

    }
    public class DatPrestamo
    {
        public decimal empID { get; set; }
        public decimal rolIdGen { get; set; }
        public decimal rolRepro { get; set; }
        public double rolId { get; set; }
        public decimal presPlazo { get; set; }
        public decimal presValor { get; set; }
        public string presObservacion { get; set; }
        public string empleado { get; set; }
        public DateTime fecharegistro { get; set; }
        public DateTime fechaactualiza { get; set; }
        public decimal presEstado { get; set; }

    }
    public class ValorGrupo
    {
        public decimal? patID { get; set; }
        public decimal? empID { get; set; }
        public double? cuentaID { get; set; }
        public decimal? localID { get; set; }
        public decimal? cargoID { get; set; }
        public decimal? valor { get; set; }
        public decimal? cantidad { get; set; }
    }

    public class ValAdi
    {
        public decimal adiId { get; set; }
        public string adiNombre { get; set; }
        public decimal adiValor { get; set; }
    }

    public class ValAdiRen
    {
        public decimal adiRenId { get; set; }
        public decimal? adiRenFracBas { get; set; }
        public decimal? adiRenExes { get; set; }
        public decimal? adiRenImp { get; set; }
        public decimal? adiRenPor { get; set; }
    }

    public class DatProvisionRol
    {
        public decimal rolId { get; set; }
        public decimal cueProvId { get; set; }
        public decimal cueProvId_Temp { get; set; }
        public Int32 provRolEstado { get; set; }
        public Int32 provRolTipo { get; set; }
        public DateTime provFechacreacion { get; set; }
        public DateTime provFechamodif { get; set; }
 
    }
    public class DatCabVac
    {
        public Int32 cabVacId { get; set; }
        public string vacPerDado { get; set; }
        public Int32 cabVacDias { get; set; }
        public Int32 cabVacDiasPag { get; set; }
        public Int32 cabVacDiasPen { get; set; }
        public Int32 cabVacDiasAdi { get; set; }
        public double cabVacVal { get; set; }
        public double cabVacValPag { get; set; }
        public double cabVacValPen { get; set; }
        public double cabVacEstado { get; set; }
        public DateTime fechacreacion { get; set; }
        public DateTime fechamodif { get; set; }
        public string cabVacObs { get; set; }
        public DateTime cabVacFecini { get; set; }
        public DateTime cabVacFecfin { get; set; }
    }
    public class DatDetVac
    {
        public string empID { get; set; }
        public Int32 detVacId { get; set; }
        public Int32 escId { get; set; }
        public Int32 vacId { get; set; }
        public Int32 empConId { get; set; }
        public Int32 locId { get; set; }
        public DateTime detFechaIni { get; set; }
        public DateTime detFechaFin { get; set; }
        public Int32 detDias { get; set; }
        public double detValor { get; set; }
        public string detObserv { get; set; }
        public decimal vacAutorizado { get; set; }
        public decimal detEstado { get; set; }
        public DateTime fechacreacionc { get; set; }
        public DateTime fechamodif { get; set; }
        public decimal vacIdAnt { get; set; }
    }
    public class PerEntity
    {
        public string empID { get; set; }
        public Int32 tipID { get; set; }
        public Int32 locID { get; set; }
        public Int32 escID { get; set; }
        public Int32 perId { get; set; }
        public DateTime perFecReg { get; set; }
        public DateTime perFecIni { get; set; }
        public DateTime perFecFin { get; set; }
        public string perObs { get; set; }
        public int perDia { get; set; }
        public int perNumHor { get; set; }
        public int perNumMin { get; set; }
        public string perRes { get; set; }
        public string perHorIni { get; set; }
        public string perHorFin { get; set; }
    }
    public class TipPerEntity
    {
        public Int16 tipId { get; set; }
        public string tipNombre { get; set; }
        public string tipObs { get; set; }
        public decimal tipTipo { get; set; }
    }

    public class GrupoCuentaEntity
    {
        public int GrupoCuentaID { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaMod { get; set; }
    }

    public class RolAdicialEntity
    {
        public int AdicionID { get; set; }
        public string Nombre { get; set; }
        public int Valor { get; set; }

    }
    public class PuestoRentaEntity
    {
        public int RentaAdicionID { get; set; }
        public int FraccionBasica { get; set; }
        public int Impuesto { get; set; }
        public int Porcentaje { get; set; }
    }
    public class DetRolEspEntity
    {
        public decimal rolId { get; set; }
        public decimal empId { get; set; }
        public decimal rolIdGen { get; set; }
        public decimal detRolId { get; set; }
        public decimal espId { get; set; }
        public decimal locId { get; set; }
        public decimal espValor { get; set; }
        public DateTime espFechaIng { get; set; }
        public DateTime espFechaRep { get; set; }
        public string espObs { get; set; }
        public decimal rolRepro { get; set; }
        public string espAudit { get; set; }
    }
    public class DetRolEntity
    {
       public int rolId{ get; set; }
       public string empId { get; set; }
       public int rolIdGen{ get; set; }
       public string detRolId{ get; set; }
       public double detRolValor{ get; set; }
       public DateTime detRolFecha { get; set; }
       public int rolRepro{ get; set; }
       public int detRolAudit{ get; set; }
       public int detRolAudit2{ get; set; }
    }

    public class RolEntity
    {
        public int RodID { get; set; }
        public string Cuenta { get; set; }
        public string SubCuenta { get; set; }
        public string Variable { get; set; }
        public int OrdImp { get; set; }
        public int Estado { get; set; }
        public DateTime FechaMod { get; set; }
        public DateTime FechaCrea { get; set; }
        public int RolTip { get; set; }
        public int? RolLocal { get; set; }
        public double CuentaID { get; set; }
        public int CuentaCostID { get; set; }
        public int? GrupoRolID { get; set; }
        public int TipoCuenta { get; set; }
    }

    public class PermisoTipoEntity
    {
        public int PermisoTipoID { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
        public int Tipo { get; set; }
    }

    public class ContratoEntity
    {
        public int ContratoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
    public class ContratoFinEntity
    {
        public int ContratoFinID { get; set; }
        public string Causa { get; set; }
        public string Abrev { get; set; }
        public DateTime FechaCrea { get; set; }
    }
    public class EscalafonGrupoEntity
    {
        public int EscGruID { get; set; }
        public string Nombre { get; set; }
        public int CredMax { get; set; }
        public int DescMAx { get; set; }
    }

    public class EscalafonEntity
    {
        public int EscID { get; set; }
        public int EscGruID { get; set; }
        public string Cargo { get; set; }
        public string CategoriaIESS { get; set; }
        public string CodIESS { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaMod { get; set; }
        public int Puntaje { get; set; }
        public Double SalarioUnifi { get; set; }
        public Double BonoAsis { get; set; }
        public Double Aliment { get; set; }
        public Double Vestiment { get; set; }
        public Double ObsSueldo { get; set; }
        public int Estado { get; set; }
        public string CodActSec { get; set; }
        public int GrupCargID { get; set; }
        public string Abrev { get; set; }
        public Double AdiBono { get; set; }
        public Double PuntUtili { get; set; }
        public Double Rbu { get; set; }
        public Double ValFact { get; set; }
    }

    public class EmpleadoEntity
    {
        public Int64 EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string LugarNacimiento { get; set; }
        public string FechaNacimiento { get; set; }
        public string Cedula { get; set; }
        public string NumeroIESS { get; set; }
        public string EstadoCivil { get; set; }
        public string NumeroHijos { get; set; }
        public string FechaIngreso { get; set; }
        public string EMP_CUENTA { get; set; }
        public string EMP_APELLIDO { get; set; }
        public string EMP_FEC_SALIDA { get; set; }
        public string EMP_AFIL_HUMANA { get; set; }
        public string EMP_TELEFONO2 { get; set; }
        public string EMP_FEC_SALIDAREAL { get; set; }
        public string EMP_CNTA_CAM { get; set; }
        public string EMP_TIPO_CNTA { get; set; }
        public string EMP_FEC_REG { get; set; }
        public string EMP_FEC_MOD { get; set; }
        public string EMP_FEC_SEG { get; set; }
        public string EMP_SEXO { get; set; }
        public string EMP_SEC_ID { get; set; }
        public string EMP_BARRIO { get; set; }
        public string EMP_FECHA_REINGRESO { get; set; }
        public string EMP_EDU { get; set; }
        public string EMP_DIRE_NUMERO { get; set; }
        public string EMP_TIP_SANGRE { get; set; }
        public string EMP_DISCAPACIDAD { get; set; }
        public string EMP_NUM_CONADIS { get; set; }
        public string EMP_AFI_FARMA { get; set; }
        public string EMP_AFI_FARMA_FEC { get; set; }
        public string EMP_AFI_SEG_FEC { get; set; }
        public string EMP_HOR { get; set; }
        public string EMP_PAG_FON_RES { get; set; }
        public string EMP_PASAPORTE { get; set; }
        public string EMP_SUJ_CRDT { get; set; }
        public string EMP_MAIL { get; set; }
        public string EMP_CLAVE_ASIST { get; set; }
        public string EMP_PORC_DISC { get; set; }
        public string DSC_ID { get; set; }
        public string EMP_PAG_DEC_TER { get; set; }
        public string EMP_PAG_DEC_CUA { get; set; }
        public string EMP_OBS { get; set; }
        public string FEC_CONTRATO_AUX { get; set; }
        public string EMP_DEPENDIENTES { get; set; }
    }

    public class DiscapacidaEmpleadodEntity
    {
        public int DSCP_ID { get; set; }
        public Int64 EMP_ID { get; set; }
        public int DSCP_TIP_ID { get; set; }
        public string DSCP_NUM { get; set; }
        public int DSCP_PRCT { get; set; }
        public string DSCP_DSC { get; set; }         
    }

    public class DiscapacidadEntity
    {
        public int DSCP_TIP_ID { get; set; }
        public string DSCP_TIP_DSC { get; set; }
    }

    public class FrmEmergente
    {
        public string Titulo { get; set; }
        public string NombreLista { get; set; }
    }

    public class PatronoEntity
    {
        public int PatronoID { get; set; }
        public string PatronoNum { get; set; }
        public string RepLegal { get; set; }
        public string Direccion { get; set; }
        public string RazonSocial { get; set; }
        public DateTime FechaConst { get; set; }
        public DateTime FechaLiq { get; set; }
        public string Observacion { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public string Provincia { get; set; }
        public string ProvinciaCod { get; set; }
        public string Telefono { get; set; }
        public string Ruc { get; set; }
        public int EstadoConta { get; set; }
        public string Actividad { get; set; }
        public string Observacion2 { get; set; }
        public string RucContador { get; set; }
        public string PatJDE { get; set; }

        private static PatronoEntity _instancia;
        public static PatronoEntity Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new PatronoEntity();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }


    }

    public class LocalEntity
    {
        public int LocalID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public int Estado { get; set; }
        public int PagoServicio { get; set; }
        public string Ruc { get; set; }
        public string CodIESS { get; set; }
        public string Abrev { get; set; }
        public DateTime FechaMod { get; set; }
        public DateTime FechaCrea { get; set; }
        public int SeguroM { get; set; }
        public string Regimen { get; set; }
        private static LocalEntity _instancia;
        public static LocalEntity Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new LocalEntity();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
    }

    public class ProvinciaEntity
    {
        public int ProvinciaID { get; set; }
        public string Nombre { get; set; }
        public string CodSRI { get; set; }
    }

    public class CiudadEntity
    {
        public int CiudadID { get; set; }
        public string Nombre { get; set; }
        public string Abrev { get; set; }
        public string Regimen { get; set; }
    }

    public class FaltaEmpEntity
    {
        public Int64 FaltaID { get; set; }
        public Int64 EmpID { get; set; }
        public Int64 RolID { get; set; }
        public Int64 RolRepro { get; set; }
        public DateTime FechaNovedad { get; set; }
        public DateTime FechaCrea { get; set; }
        public int PermiNoJus { get; set; }
        public int PermiJus { get; set; }
        public int FaltaNoJus { get; set; }
        public int FaltaJus { get; set; }
        public int OtrpNoJus { get; set; }
        public int OtroJus { get; set; }
        public string Observ { get; set; }
        private static FaltaEmpEntity _instancia;
        public static FaltaEmpEntity Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new FaltaEmpEntity();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
    }
}
