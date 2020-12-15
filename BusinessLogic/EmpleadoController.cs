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
    public class EmpleadoController
    {
        #region Properties
        private EmpleadoRepository EmpleadoAD { get; set; }
        public db.DatEmp Empleado { get; set; }
        public db.DatPrestamo Prestamo { get; set; }
        public db.DatEmpFam Familia { get; set; }
        public db.DiscapacidaEmpleadodEntity Discapicidad { get; set; }
        #endregion

        #region Methods
        public DataTable TransferenciaBancariaDecimo(string proID, string anioINI, string anioFIN, string emprID, string tipoID)
        {
            return EmpleadoAD.TransferenciaBancariaDecimo(proID, anioINI, anioFIN,emprID, tipoID);
        }
        //public DataTable TransferenciaBancaria(string emprID)
        //{
        //    return EmpleadoAD.TransferenciaBancaria(emprID);
        //}
        public DataTable TransferenciaBancaria(string emprID)
        {
            return EmpleadoAD.TransferenciaBancaria(emprID);
        }
        public DataTable TransferenciaBancaria(string perID, string reproID, string empID, string tipoID)
        {
            return EmpleadoAD.TransferenciaBancaria(perID, reproID, empID, tipoID);
        }
        public int ActualizaProyeccionGasto(DataTable data)
        {
            return EmpleadoAD.ActualizaProyeccionGasto(data);
        }
        public DataTable ListaProyeccionGasto(string empID, string anio, string patID)
        {
            return EmpleadoAD.ListaProyeccionGasto(empID, anio, patID);
        }
        public int ExisteRol(db.DatPrestamo pres)
        {
            return EmpleadoAD.ExisteRol(pres);
        }
        public int ExistePrestamo(db.DatPrestamo pres)
        {
            return EmpleadoAD.ExistePrestamo(pres);
        }
        public int RegistraTablaPrestamo(db.DatPrestamo pres)
        {
            return EmpleadoAD.RegistraTablaPrestamo(pres);
        }
        public int RegistraPrestamoEmpleado(db.DatPrestamo pres)
        {
            return EmpleadoAD.RegistraPrestamoEmpleado(pres);
        }
        public int GeneraTablaAmortizacion(db.DatPrestamo pres)
        {
            return EmpleadoAD.GeneraTablaAmortizacion(pres);
        }
        public DataTable ListaPrestamoEmpleado()
        {
            return EmpleadoAD.ListaPrestamoEmpleado();
        }
        public DataTable ListaTablaAmortizacion(db.DatPrestamo pres)
        {
            return EmpleadoAD.ListaTablaAmortizacion(pres);
        }

        public int ValidaEmpleadoSalidaEmpresa(string empCI, string emprID)
        {
            return EmpleadoAD.ValidaEmpleadoEmpresa(empCI, emprID);
        }
        public int ValidaEmpleadoEmpresa(string empCI)
        {
            return EmpleadoAD.ValidaEmpleadoEmpresa(empCI);
        }
        public int ValidaEmpleadoEmpresa(string empCI, string emprID)
        {
            return EmpleadoAD.ValidaEmpleadoEmpresa(empCI, emprID);
        }
        public int ValidaEmpleadoActivo(string empCI, string emprID)
        {
            return EmpleadoAD.ValidaEmpleadoActivo(empCI, emprID);
        }
        public int RegistraReingreso(string empCI, string empID, string empIDO, string userID)
        {
            return EmpleadoAD.RegistraReingreso(empCI, empID,empIDO,userID);
        }

        public string EmpleadoEmail(string empID)
        {
            return EmpleadoAD.EmpleadoEmail(empID);
        }
        public int EmpleadoLocal(string empID)
        {
            return EmpleadoAD.EmpleadoLocal(empID);
        }
        public int CargaConsumoLocal(string perID)
        {
            return EmpleadoAD.CargaConsumoLocal(perID);
        }
        public string CargoEmpleadoRol(string empID, string perID, string reproID)
        {
            return EmpleadoAD.CargoEmpleadoRol(empID,perID, reproID);
        }

        public Int32 RegistarFamiliar(db.DatEmpFam emp)
        {
            return EmpleadoAD.RegistrarFamiliar(emp);
        }

        public Int32 ActualizarFamiliar(db.DatEmpFam emp)
        {
            return EmpleadoAD.ActualizarFamiliar(emp);
        }
        public Int32 DeleteEmpleado(string empID)
        {
            return EmpleadoAD.DeleteEmpleado(empID);
        }
        public Int32 EliminaFamiliar(string empID, string famID)
        {
            return EmpleadoAD.EliminaFamiliar(empID, famID);
        }

        public Int64 RegistarEmpleado(db.DatEmp emp, string prmScript)
        {
            return EmpleadoAD.RegistarEmpleado(emp, prmScript);
        }

        public DataTable Familiares(string empID)
        {
            return EmpleadoAD.Familiares(empID);
        }

        //public List<EmpleadoEntity> ListarEmpleado()
        //{
        //    List<EmpleadoEntity> datos = new List<EmpleadoEntity>();
        //    datos = EmpleadoAD.ListarEmpleado();
        //    return datos;
        //}
        public int ValidaCeldula(string empCI)
        {
            return EmpleadoAD.ValidaCedula(empCI);
        }
        public string[] ValidaFechaIngreso(string empID)
        {
            return EmpleadoAD.ValidaFechaIngreso(empID);
        }
        public DataTable ListaEmpleadoDetalle()
        {
            return EmpleadoAD.ListaEmpleadoDetalle();
        }
        public DataTable ListaEmpleadoDetalle(string prm)
        {
            return EmpleadoAD.ListaEmpleadoDetalle(prm);
        }
        public DataSet PaginaEmpleadoDetalle(int recordIni, int recordMax)
        {
            return EmpleadoAD.PaginaEmpleadoDetalle(recordIni,recordMax);
        }
        public DataTable ListaEmpleado()
        {
            return EmpleadoAD.ListaEmpleado();
        }
        public DataTable ListaEmpleadoCI(string cedulaEmp)
        {
            return EmpleadoAD.ListaEmpleadoCI(cedulaEmp);
        }
        public DataTable ListaEmpleado(string empID)
        {
            return EmpleadoAD.ListaEmpleado(empID);
        }

        public DataTable ListaEmpleadoDT(string empID)
        {
            return EmpleadoAD.ListaEmpleadoDT(empID);
        }

        public DataTable ListaDiscapacidad()
        {
            return EmpleadoAD.ListaDiscapacidad();
        }

        public DataTable ListaEmpleadoDiscapacidad(string empID)
        {
            return EmpleadoAD.ListaEmpleadoDiscapacidad(empID);
        }
        public Int64 RegistarDiscapacidad(db.DiscapacidaEmpleadodEntity emp, string prmScript)
        {
            return EmpleadoAD.RegistarDiscapacidad(emp, prmScript);
        }
        #endregion

        #region Instancia / Constructor
        private static EmpleadoController _instancia;
        public static EmpleadoController Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new EmpleadoController();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        private EmpleadoController()
        {
            EmpleadoAD = EmpleadoRepository.Instancia;
            Empleado = new db.DatEmp();
            Familia = new db.DatEmpFam();
            Prestamo = new db.DatPrestamo();
            Discapicidad = new db.DiscapacidaEmpleadodEntity();
        }

        #endregion
    }
}
