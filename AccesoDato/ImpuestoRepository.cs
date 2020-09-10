using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;
using System.Data;
using Oracle.DataAccess.Client;

namespace DataAccess
{
    public class ImpuestoRepository
    {
        private static string sqlListaRol = "SELECT ADI_REN_ID, ADI_REN_FRAC_BAS, ADI_REN_EXES, ADI_REN_IMP, ADI_REN_POR FROM DESARROLLO.VAL_ADI_REN";
        private static string sqlValoresRol = "SELECT ADI_ID, ADI_NOMBRE, ADI_VALOR FROM DESARROLLO.VAL_ADI";
        private static string sqlImpuestoRentaI = @"
                                                    INSERT INTO DESARROLLO.VAL_ADI_REN (ADI_REN_ID,
                                                                                        ADI_REN_FRAC_BAS,
                                                                                        ADI_REN_EXES,
                                                                                        ADI_REN_IMP,
                                                                                        ADI_REN_POR)
                                                         VALUES ( :ADI_REN_ID
                                                                 ,:ADI_REN_FRAC_BAS
                                                                 ,:ADI_REN_EXES
                                                                 ,:ADI_REN_IMP
                                                                 ,:ADI_REN_POR
                                                                 )";
        private static string sqlImpuestoRentaU = @"
                                                    UPDATE DESARROLLO.VAL_ADI_REN
                                                       SET 
                                                           ADI_REN_FRAC_BAS = :ADI_REN_FRAC_BAS,
                                                           ADI_REN_EXES = :ADI_REN_EXES,
                                                           ADI_REN_IMP = :ADI_REN_IMP,
                                                           ADI_REN_POR = :ADI_REN_POR
                                                     WHERE ADI_REN_ID = :ADI_REN_ID";
        private static string sqlImpuestoRentaCode = "SELECT COUNT(ADI_REN_ID)+1 FROM DESARROLLO.VAL_ADI_REN ";
        private static string sqlValorAdicionalI = @"INSERT INTO DESARROLLO.VAL_ADI (ADI_ID, ADI_NOMBRE, ADI_VALOR)
                                                     VALUES ( :ADI_ID, :ADI_NOMBRE, :ADI_VALOR)";
        private static string sqlValorAdicionalU = @"UPDATE DESARROLLO.VAL_ADI
                                                       SET ADI_NOMBRE = :ADI_NOMBRE, ADI_VALOR = :ADI_VALOR
                                                     WHERE ADI_ID = :ADI_ID";
        private ConnectionDDBB db { get; set; }
        
        #region Instancia / Constructor
        private static ImpuestoRepository _instancia;
        public static ImpuestoRepository Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ImpuestoRepository();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public ImpuestoRepository()
        {
            db = ConnectionDDBB.Instancia;
        }
        #endregion

        public int RegistraValorAdicional(ValAdi valAdi, string tipoSQL)
        {
            int pkCode = 0;
            if (tipoSQL.Equals("I"))
            {
                OracleParameter[] prm = new OracleParameter[]{           
               new OracleParameter(":ADI_ID", valAdi.adiId),
               new OracleParameter(":ADI_NOMBRE", valAdi.adiNombre ),
               new OracleParameter(":ADI_VALOR", valAdi.adiValor)
                          
            };

                if (db.ExecQuery(sqlValorAdicionalI, prm).Equals(1))
                    pkCode = 0;
            }
            else
            {
                OracleParameter[] prm = new OracleParameter[]{                            
               new OracleParameter(":ADI_NOMBRE", valAdi.adiNombre ),
               new OracleParameter(":ADI_VALOR", valAdi.adiValor),
               new OracleParameter(":ADI_ID", valAdi.adiId),
            };

                if (db.ExecQuery(sqlValorAdicionalU, prm).Equals(1))
                    pkCode = 0;
            }

            return pkCode;
        }      

        
        private int ImpuestoRentaCodigo()
        {            
            return db.GetEntero(sqlImpuestoRentaCode);
        }


        public int RegistraImpuestoRenta(ValAdiRen impRenta, string tipoSQL)
        {
            int pkCode = 0;
            if (tipoSQL.Equals("I"))
            {
                OracleParameter[] prm = new OracleParameter[]{           
               new OracleParameter(":ADI_REN_ID", pkCode=ImpuestoRentaCodigo()),
               new OracleParameter(":ADI_REN_FRAC_BAS", impRenta.adiRenFracBas),
               new OracleParameter(":ADI_REN_EXES", impRenta.adiRenExes),
               new OracleParameter(":ADI_REN_IMP", impRenta.adiRenImp),               
               new OracleParameter(":ADI_REN_POR", impRenta.adiRenPor)             
            };

                if (db.ExecQuery(sqlImpuestoRentaI, prm).Equals(1))
                    pkCode = 0;

            }
            else
            {
                OracleParameter[] prm = new OracleParameter[]{             
               new OracleParameter(":ADI_REN_FRAC_BAS", impRenta.adiRenFracBas),
               new OracleParameter(":ADI_REN_EXES", impRenta.adiRenExes),
               new OracleParameter(":ADI_REN_IMP", impRenta.adiRenImp),               
               new OracleParameter(":ADI_REN_POR", impRenta.adiRenPor),
               new OracleParameter(":ADI_REN_ID", impRenta.adiRenId),
            };

                if (db.ExecQuery(sqlImpuestoRentaU, prm).Equals(1))
                    pkCode = 0;
            }

            return pkCode;
        }      

        public DataTable ListaImpuestoRenta()
        {
            return db.GetData(sqlListaRol);
        }
        public DataTable ListaValorAdicional()
        {
            return db.GetData(sqlValoresRol);
        } 
    }
}
