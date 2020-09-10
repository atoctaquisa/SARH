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
    public class SolicitudController
    {

        private SolicitudRepository SolicitudAD { get; set; }

        #region Instancia / Constructor
        private static SolicitudController _instancia;
        public static SolicitudController Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SolicitudController();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public SolicitudController()
        {
            SolicitudAD = SolicitudRepository.Instancia;
            
        }
        #endregion

        public DataTable ListaPorcentajeAccMatEnf()
        {
            return SolicitudAD.ListaPorcentajeAccMatEnf();
        }

        public DataTable ListaTipoAccMatEnf()
        {
            return SolicitudAD.ListaTipoAccMatEnf();
        }

        public DataTable ListaDiaAccMatEnf(string empID, string rolID, string reproID)
        {
            return SolicitudAD.ListaDiaAccMatEnf(empID,rolID,reproID);
        }
        public DataTable ListaSolicitudAccMatEnf()
        {
            return SolicitudAD.ListaSolicitudAccMatEnf();
        }

        public DataTable ListaSolicitudAccMatEnf(string empID)
        {
            return SolicitudAD.ListaSolicitudAccMatEnf(empID);
        }
        public int RegistraSolicitudAccMatEnf(List<DatIessEnfermedad> notifica, List<DatIessDiaEnfe> dia, string tipoID)
        {
            return SolicitudAD.RegistraSolicitudAccMatEnf(notifica,dia, tipoID);
        }
        public DataTable ListaSolicitudVacacion(string empID, string perID)
        {
            return SolicitudAD.ListaSolicitudVacacion(empID,perID);
        }
        public int RegistraSolicitud(int cliID,string fechaIni, string fechaFin, string fechaInc, string obs , string emp_id , string emp_ad, int idVac , string fechaAnio, int diaPendiente, double valor )
        {
            return SolicitudAD.RegistraSolicitud(cliID, fechaIni, fechaFin, fechaInc, obs, emp_id, emp_ad, idVac, fechaAnio, diaPendiente, valor);
        }
        public int VerificaSolicitud(string empID, int perID)
        {
            return SolicitudAD.VerificaSolicitud(empID, perID);
        }
        public int VerificaDiasVacacion(string empID, int perID)
        {
            return SolicitudAD.VerificaDiasVacacion(empID,perID);
        }
        public DataTable ListaSolicitudVacacion(string codigo, int estado, string empID, string fechaD, string fechaH)
        {
            return SolicitudAD.ListaSolicitudVacacion(codigo,estado,empID,fechaD,fechaH );
        }
        public int ApruebaSolicitud(string empID, string cabVacID, string obsr)
        {
            return SolicitudAD.ApruebaSolicitud(empID, cabVacID,obsr);
        }
        public int AnulaSolicitud(Int32 cabVacID)
        {
            return SolicitudAD.AnulaSolicitud(cabVacID);
        }

    }
}
