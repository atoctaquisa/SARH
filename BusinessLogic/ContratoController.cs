using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DataAccess;
using db=Entity;

namespace BusinessLogic
{
    public class ContratoController
    {
        #region Properties
        private ContratoRepository ContratoAD { get; set; }
        public db.DatEmpCon EmpleadoContrato { get; set; }
        public db.DatLab Laboral { get; set; }
        public db.DatDetVac Vacacion { get; set; }
        public db.DatEmpValFijo ValorFijo { get; set; }
        public db.FaltaEmpEntity FaltaEmp { get; set; }
        public db.PerEntity Permiso { get; set; }
        public db.DatRolSeg RolSeg { get; set; }
        #endregion        

        #region Instancia / Constructor
        private static ContratoController _instancia;
        public static ContratoController Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ContratoController();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public ContratoController()
        {
            ContratoAD = ContratoRepository.Instancia;
            EmpleadoContrato = new db.DatEmpCon();
            Laboral = new db.DatLab();
            ValorFijo = new db.DatEmpValFijo();
            FaltaEmp = new db.FaltaEmpEntity();
            Permiso = new db.PerEntity();
            Vacacion = new db.DatDetVac();
            RolSeg = new db.DatRolSeg();
        }
        #endregion

        #region Methods

        public int VerificaPeridoDiario(string perID)
        {
            return ContratoAD.VerificaPeridoDiario(perID);
        }
        public DataSet AsientoLiquidacion(string diaID, string cliID, string percID,string patID)
        {
            return ContratoAD.AsientoLiquidacion(diaID, cliID, percID, patID);
        }
        public DataTable GeneraDatosIESS(string perID, string reproID, string tipoID, string fechaIni, string fechaFin)
        {
            return ContratoAD.GeneraDatosIESS(perID, reproID , tipoID , fechaIni, fechaFin );
        }

        public int RegistraValorGrupoRol(db.ValorGrupo valorGrupo)
        {
            return ContratoAD.RegistraValorGrupoRol(valorGrupo);
        }

        public DataTable ValorGrupoRol(db.ValorGrupo valorGrupo)
        {
            return ContratoAD.ValorGrupoRol(valorGrupo);
        }

        public int RegistraContratoFin(int idContrato, string nombre, string Descripcion, int tipo)
        {
            return ContratoAD.RegistraContratoFin(idContrato, nombre, Descripcion, tipo);
        }
        public int RegistraContratoTipo(int idContrato, string nombre,string Descripcion, int tipo)
        {
            return ContratoAD.RegistraContratoTipo(idContrato,nombre,Descripcion, tipo);
        }
        public int RegistraPermisoTipo(int idContrato, string nombre, string Descripcion, int tipoID ,int tipo)
        {
            return ContratoAD.RegistraPermisoTipo(idContrato, nombre, Descripcion, tipoID, tipo);
        }

        public int RegistraDetalleRol(List<db.DetRolEntity> detRol)
        {
            return ContratoAD.RegistraDetalleRol(detRol);
        }

        public int VerificaRol(string empID, string rolID, string reproID)
        {
            return ContratoAD.VerificaRol(empID, rolID, reproID);
        }

        public int EliminaDetalleRol(db.DetRolEntity detRol)
        {
            return ContratoAD.EliminaDetalleRol(detRol);
        }

        public int EliminaDetalleRol_ES(db.DetRolEspEntity datos)
        {
            return ContratoAD.EliminaDetalleRol_ES(datos);
        }
        public int EliminaDetalleIngreso(List<db.DatDetRolLiq> datos)
        {
            return ContratoAD.EliminaDetalleIngreso(datos);
        }
        public int RegistraDetalleIngreso(List<db.DatDetRolLiq> datos)
        {
            return ContratoAD.RegistraDetalleIngreso(datos);
        }
        public int ActualizaDetalleDiario(List<db.DatDetDiario> datos)
        {
            return ContratoAD.ActualizaDetalleDiario(datos);
        }
        public int ActualizaDetalleIngreso(List<db.DatDetRolLiq> datos)
        {
            return ContratoAD.ActualizaDetalleIngreso(datos);
        }
        public int ActualizaDetalleIngreso(string empID, string liqID, decimal ingreso, decimal egreso)
        {
            return ContratoAD.ActualizaDetalleIngreso(empID ,liqID,ingreso,egreso);
        }
        public int ActualizaDetalleRol(db.DetRolEntity datos)
        {
            return ContratoAD.ActualizaDetalleRol(datos);
        }
        public int ActualizaDetalleRol_ES(db.DetRolEspEntity datos)
        {
            return ContratoAD.ActualizaDetalleRol_ES(datos);
        }
        public int RegistraDetalleRol_ES(db.DetRolEspEntity datos)
        {
            return ContratoAD.RegistraDetalleRol_ES(datos);
        }
        public string MesRol(string reproID)
        {
            return ContratoAD.MesRol(reproID);
        }

        public string EstadoRol(string rolID, string reproID)
        {
            return ContratoAD.EstadoRol(rolID, reproID);
        }

        public int CargaQuincena()
        {
            return ContratoAD.CargaQuincena();
        }
        public int VerificaQuincena()
        {
            return ContratoAD.VerificaQuincena();
        }
        public int RegistraVacacionEmpleado(db.DatDetVac VacacionEmp)
        {
            return ContratoAD.RegistraVacacionEmpleado(VacacionEmp);
        }
        public DataTable ListarVacacionDT(string empID, string rolID, string reproID)
        {
            return ContratoAD.ListarVacacionDT(empID, rolID, reproID);
        }
        public DataTable ListarVacacion(string empID, string rolID, string reproID)
        {
            return ContratoAD.ListarVacacion(empID, rolID, reproID);
        }
        public int RegistraPermisoEmpleado(db.PerEntity PermisoEmp)
        {
            return ContratoAD.RegistraPermisoEmpleado(PermisoEmp);
        }

        public DataTable ListarPermisoTipo()
        {
            return ContratoAD.ListarPermisoTipo();
        }
        public DataTable ListarTipo()
        {
            return ContratoAD.ListarTipo();
        }
        public int ActualizarFaltaEmpleado(db.FaltaEmpEntity FaltaEmp)
        {
            return ContratoAD.ActualizarFaltaEmpleado(FaltaEmp);
        }
        public int RegistrarFaltaEmpleado(db.FaltaEmpEntity faltaEmp)
        {
            return ContratoAD.RegistrarFaltaEmpleado(faltaEmp);
        }
        public DataTable ListarFaltas(string empID, string rolID, string reproID)
        {
            return ContratoAD.ListarFaltas(empID,rolID, reproID);
        }

        public DataTable ListarRol(string empID,int rolID, int reproID)
        {
            return ContratoAD.ListarRol(empID,rolID,reproID);
        }
        public DataTable ListarRol(string empID, int rolID, int reproID, string tipo)
        {
            return ContratoAD.ListarRol(empID, rolID, reproID, tipo);
        }
        public DataTable ListarRolDetalleCuenta(string empID, string rolID, string reproID, string rol)
        {
            return ContratoAD.ListarRolDetalleCuenta(empID, rolID, reproID, rol);
        }
        public DataTable ListarRolDetalle(string empID, int rolID, int reproID)
        {
            return ContratoAD.ListarRolDetalle(empID, rolID, reproID);
        }
        public DataTable ListarRolDetalle(string empID, int rolID, int reproID,string tipo)
        {
            return ContratoAD.ListarRolDetalle(empID, rolID, reproID,tipo);
        }

        public int HabilitaQuincena(int idPeriodo, int numProc, int estado)
        {
            return ContratoAD.HabilitaQuincena(idPeriodo, numProc, estado);
        }

        public int GeneraRol(int idPeriodo, int numProc)
        {
            return ContratoAD.GeneraRol(idPeriodo, numProc);
        }

        public int NumeroProcesoEmp(int idPeriodo,string empID)
        {
            return ContratoAD.NumeroProcesoEmp(idPeriodo, empID);
        }
        public int ProcesaDiario(string perID, string diaID)
        {
            return ContratoAD.ProcesaDiario(perID , diaID);
        }
        public int NumeroProceso(int idPeriodo, string tipo)
        {
            return ContratoAD.NumeroProceso(idPeriodo,tipo);
        }

        public int VerificaPeriodo()
        {
            return ContratoAD.VerificaPeriodo();
        }
        public int VerificaPeriodo(int rolID,int reproID)
        {
            return ContratoAD.VerificaPeriodo(rolID,reproID);
        }
        public int VerificaPeriodo(int rolID, int reproID, string fecha)
        {
            return ContratoAD.VerificaPeriodo(rolID, reproID, fecha);
        }

        public int ValidaLiquidacion(string empID, string fechaContrato)
        {
            return ContratoAD.ValidaLiquidacion(empID,fechaContrato);
        }
        public string  TipoContrato(string empID)
        {
            return ContratoAD.TipoContrato(empID);
        }
        public int ContratoHoraGeneral(string empID)
        {
            return ContratoAD.ContratoHoraGeneral(empID);
        }
        public int EmpleadoEsMotorista(string empID)
        {
            return ContratoAD.EmpleadoEsMotorista(empID);
        }
        public int CalculaLiquidacion(string empID, int pagoID, int provID)
        {
            return ContratoAD.CalculaLiquidacion(empID, pagoID, provID );
        }
        public int GeneraAsientoLiquidacion(string empID)
        {
            return ContratoAD.GeneraAsientoLiquidacion(empID);
        }

        public int AperturaPeriodo()
        {
            return ContratoAD.AperturaPeriodo();
        }

        public DataTable ListaPeriodoDecimo(string tipo)
        {
            return ContratoAD.ListaPeriodoDecimo(tipo);
        }
        public DataTable ListaPeriodo(string tipo)
        {
            return ContratoAD.ListarPeriodo(tipo);
        }
        public DataTable ListaReproceso(string tipo)
        {
            return ContratoAD.ListaReproceso(tipo);
        }

        public int RegistrarValorFijo(db.DatEmpValFijo valFijo)
        {
            return ContratoAD.RegistrarValorFijo(valFijo);
        }

        public int ActualizarValorFijo(db.DatEmpValFijo valFijo, int auxRolID)
        {
            return ContratoAD.ActualizarValorFijo(valFijo, auxRolID);
        }

        public int EliminaValorFijo(string empID, int auxRolID)
        {
            return ContratoAD.EliminaValorFijo(empID, auxRolID);
        }

        public int RegistrarInfoLaboral(db.DatLab lab)
        {
            return ContratoAD.RegistrarInfoLaboral(lab);
        }

        public Int64 RegistraContrato(db.DatEmpCon emp, string prmScript)
        {
            return ContratoAD.RegistraContrato(emp, prmScript);
        }        

        public DataTable RubroAdicional(string empID)
        {            
            return ContratoAD.RubroAdicional(empID);
        }

        public DataTable InfoLaboral(string empID)
        {
            return ContratoAD.InfoLaboral(empID);
        }

        public DataTable ContratoEmpleado(string empID)
        {
            return ContratoAD.ContratoEmpleado(empID);
        }
        public DataTable FinContratoEmpleado(string empID)
        {
            return ContratoAD.FinContratoEmpleado(empID);
        }
        public int FinContratoEmpleadoDT(db.DatDetLiq liquidacion)
        {
            return ContratoAD.FinContratoEmpleadoDT(liquidacion);
        }
        public int FinContratoEmpleado(string empID,string observacion,string id)
        {
            return ContratoAD.FinContratoEmpleado(empID, observacion, id);
        }
        public DataTable LiquidacionEmpleado(string empID)
        {
            return ContratoAD.LiquidacionEmpleado(empID);
        }
        public DataTable LiquidacionEmpleadoDT(string empID, string liqID)
        {
            return ContratoAD.LiquidacionEmpleadoDT(empID, liqID);
        }

        public List<db.ContratoFinEntity> ListaContratoFin()
        {
            List<db.ContratoFinEntity> datos = new List<db.ContratoFinEntity>();
            datos = ContratoAD.ListaContratoFin();
            return datos;
        }
        public DataTable ListarContratoFin()
        {
            return ContratoAD.ListarContratoFin();
        }

        public List<db.ContratoEntity> ListaContrato()
        {
            List<db.ContratoEntity> datos = new List<db.ContratoEntity>();
            datos = ContratoAD.ListaContrato();
            return datos;
        }
        public DataTable ListarContrato()
        {
            return ContratoAD.ListarContrato();
        }
        public int GetReproceso(string empID,string perID)
        {
            return ContratoAD.GetReproceso(empID,perID);
        }
        public DataTable DetalleIngreso(string empID, string perID, string reproID)
        {
            return ContratoAD.DetalleIngreso(empID ,perID,reproID);
        }
        public DataSet DetalleDecimoTercero(string empID, string perID)
        {
            return ContratoAD.DetalleDecimoTercero(empID,perID);
        }
        public DataSet  DetalleVacacion(string empID, string perID)
        {
            return ContratoAD.DetalleVacacion(empID ,perID);
        }
        public DataTable DetalleEgreso()
        {
            return ContratoAD.DetalleEgreso();
        }
        #endregion

    }
}
