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
    public class UbicacionController
    {
       #region Propiedades
        private UbicacionRepository UbicacionAD { get; set; }        
        #endregion
               
       
        public DataTable Sector()
        {
            return UbicacionAD.listaSector();
        }

        #region Instancia / Constructor
        private static UbicacionController _instancia;
        public static UbicacionController Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new UbicacionController();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public UbicacionController()
        {
            UbicacionAD = UbicacionRepository.Instancia;            
        }

        #endregion
    }
}
