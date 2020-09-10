﻿using System;
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

        public DataTable LiquidacionDT(string empID, string vacID)
        {
            return ReportDataDA.LiquidacionDT(empID, vacID);
        }
        public DataTable RolIndividual(string rolID, string reproID, string empID, string localID, string cadenaID)
        {
            return ReportDataDA.RolIndividual(rolID,reproID,empID,localID,cadenaID);           
        }
        public DataTable PagoQuincena(string rolID, string patrono, string local, string empID)
        {
            return ReportDataDA.PagoQuincena(rolID, patrono , local , empID );
        }
        public DataTable DetalleContabilidad(string rolID, string reproID)
        {
            return ReportDataDA.DetalleContabilidad(rolID, reproID);
        }
    }
}