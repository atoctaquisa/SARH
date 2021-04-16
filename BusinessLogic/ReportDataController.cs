using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DataAccess;
using Entity;

namespace BusinessLogic
{
    public class ReportDataController
    {

        #region Instancia / Constructor
        private static ReportDataController _instancia;
        public static ReportDataController Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ReportDataController();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public ReportDataController()
        {
            ReportDataDA = ReportDataRepository.Instancia;
        }
        #endregion

        public DataTable VacacionSub(string empID, string vacID)
        {
            return ReportDataDA.VacacionSub(empID, vacID);
        }

        public DataTable Vacacion(string subQuery)
        {
            return ReportDataDA.Vacacion(subQuery);
        }
        public DataTable ActurialEmpresa(string subQuery)
        {
            return ReportDataDA.ActuarialEmpresa(subQuery);
        }
        public DataTable ActurialEmpresaSalida(string subQuery)
        {
            return ReportDataDA.ActuarialEmpresaSalida(subQuery);
        }

        public DataTable DetalleEmpleado(string subQuery)
        {
            return ReportDataDA.DetalleEmpleado(subQuery);
        }
        private ReportDataRepository ReportDataDA { get; set; }

        public DataTable Actualial(string nAnio)
        {
            return ReportDataDA.Actuarial(nAnio);
        }

        public DataTable SolicitudVacacion(string empID, string vacID)
        {
            return ReportDataDA.SolicitudVacacion(empID, vacID);
        }

        public DataTable Liquidacion(string empID)
        {
            return ReportDataDA.Liquidacion(empID);
        }
        public DataSet LiquidacionParamReport(string empID, string perID, string reproID)
        {
            return ReportDataDA.LiquidacionParamReport(empID,perID,reproID);
        }

        public DataTable LiquidacionDT(string empID, string vacID)
        {
            return ReportDataDA.LiquidacionDT(empID, vacID);
        }
        public DataTable Certificado(string empID, string tipo)
        {
            return ReportDataDA.Certificado(empID, tipo);
        }
        public DataTable RolIndividual(string rolID, string reproID, string empID, string localID, string cadenaID)
        {
            return ReportDataDA.RolIndividual(rolID, reproID, empID, localID, cadenaID);
        }
        public DataTable RolIndividualSub(string rolID)
        {
            return ReportDataDA.RolIndividualSub(rolID);
        }
        public DataTable Prestamo(string rolID, string estado, string patrono, string tipo, string empID)
        {
            return ReportDataDA.Prestamo(rolID, estado, patrono, tipo, empID);
        }
        public DataTable PagoQuincena(string rolID, string reproID, string patrono, string local, string empID)
        {
            return ReportDataDA.PagoQuincena(rolID, reproID, patrono, local, empID);
        }
        public DataTable DetalleContabilidad(string rolID, string reproID, string tipoRep)
        {
            return ReportDataDA.DetalleContabilidad(rolID, reproID, tipoRep);
        }
        public DataTable DetalleContabilidad(string fechaIni, string fechaFin, string emprID,string locID)
        {
            return ReportDataDA.DetalleContabilidad(fechaIni, fechaFin, emprID, locID);
        }
        public DataTable RolNegativo(string rolID, string reproID)
        {
            return ReportDataDA.RolNegativo(rolID, reproID);
        }
        public DataTable Provision(string fechaIni, string fechaFin, string patrono, string local, string empID)
        {
            return ReportDataDA.Provision(fechaIni, fechaFin, patrono, local, empID);
        }
    }
}
