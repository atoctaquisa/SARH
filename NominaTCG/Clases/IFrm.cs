using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NominaTCG
{
    class IFrm
    {
    }
    public interface IFrmResumenRol
    {
        void getEmpleadoID(string idCodigo);
        void getPeriodoID(string idPeriodo);
        void getCuentaID(string idCuenta);
        void getCuentaNom(string nomCuenta);
    }
    public interface IFrmOperacionRol
    {
        void getEmpleadoID(string idCodigo);
        void getPeriodoID(string idPeriodo);
        void getCuentaID(string idCuenta);
        void getCuentaNom(string nomCuenta);
    }
    public interface IFrmJornada
    {
        void getPeriodoID(string idCodigo);
    }
    public interface IFrmConsumoLocal
    {
        void getPeriodoID(string idCodigo);
    }
}
