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
    public class ImpuestoController
    {
        private ImpuestoRepository  ImpuestoRentaAD { get; set; }

        #region Instancia / Constructor
        private static ImpuestoController _instancia;
        public static ImpuestoController Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ImpuestoController();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public ImpuestoController()
        {
            ImpuestoRentaAD = ImpuestoRepository.Instancia;
        }
        #endregion

        public int RegistraImpuestoRenta(ValAdiRen impRenta, string tipoSQL)
        {
            return ImpuestoRentaAD.RegistraImpuestoRenta(impRenta, tipoSQL);
        }
        public int RegistraValorAdicional(ValAdi impRenta, string tipoSQL)
        {
            return ImpuestoRentaAD.RegistraValorAdicional(impRenta, tipoSQL);
        }
        public DataTable ListaImpuestoRenta()
        {            
            return  ImpuestoRentaAD.ListaImpuestoRenta();            
        }
        public DataTable ListaValorAdicional()
        {
            return ImpuestoRentaAD.ListaValorAdicional();
        }
       
    }
}
