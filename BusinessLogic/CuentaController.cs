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
    public class CuentaController
    {

        private CuentaRepository cuentaAD { get; set; }
        public RolEntity Cuenta { get; set; }

        #region Instancia / Constructor
        private static CuentaController _instancia;
        public static CuentaController Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CuentaController();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public CuentaController()
        {
            cuentaAD = CuentaRepository.Instancia;
        }
        #endregion

        public int RegistraCuenta(RolEntity rol, string tipoSQL)
        {
            return cuentaAD.RegistraCuenta(rol, tipoSQL);
        }
        public int RegistraProvision( DatProvisionRol provision, string tipoSQL)
        {
            return cuentaAD.RegistraProvision(provision, tipoSQL);
        }

        public int RegistraGrupoCuenta(Int32 idGrupo, string nombreGrupo, string tipoSQL)
        {
            return cuentaAD.RegistraGrupoCuenta(idGrupo, nombreGrupo,tipoSQL);
        }

        public DataTable ListaCuentaDiario()
        {
            return cuentaAD.ListaCuentaDiario();
        }
        public DataTable ListaCuenta(int tipo)
        {
            return cuentaAD.ListaCuenta(tipo);
        }
        public DataTable ListaCuentasGen()
        {
            return cuentaAD.ListaCuentasGen();
        }
        public DataTable ListaCuentas()
        {
            return cuentaAD.ListaCuentas();
        }
        public DataTable ListaCuentas(string [] param)
        {
            return cuentaAD.ListaCuentas(param);
        }

        public DataTable ListaGrupoCuentas()
        {
            return cuentaAD.ListaGrupoCuentas();
        }

        public DataTable ListaCuentaIO()
        {
            return cuentaAD.ListaCuentaIO();
        }
        public DataTable ListaProvisionRol(int rolID)
        {
            return cuentaAD.ListaProvisionRol(rolID);
        }
        public DataTable ListaCuentaProvision()
        {
            return cuentaAD.ListaCuentaProvision();
        }
        
    }
}
