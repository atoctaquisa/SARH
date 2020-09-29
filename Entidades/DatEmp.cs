using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class DatEmp
    {
        public Int64 empId { get; set; }
        public string empNombre { get; set; }
        public string empDirec { get; set; }
        public string empTelefono { get; set; }
        public string empLugNac { get; set; }
        public DateTime empFecNac { get; set; }
        public string empCi { get; set; }
        public string empNumIess { get; set; }
        public string empEstCivil { get; set; }
        public decimal empNumHijos { get; set; }
        public DateTime? labFecIngreso { get; set; }
        public string empCuenta { get; set; }
        public string empApellido { get; set; }
        public DateTime? empFecSalida { get; set; }
        public decimal empAfilHumana { get; set; }
        public string empTelefono2 { get; set; }
        public DateTime? empFecSalidareal { get; set; }
        public string empCntaCam { get; set; }
        public decimal empTipoCnta { get; set; }
        public DateTime empFecReg { get; set; }
        public DateTime empFecMod { get; set; }
        public string empFecSeg { get; set; }
        public decimal empSexo { get; set; }
        public decimal empSecId { get; set; }
        public string empBarrio { get; set; }
        /// campo en el que se almacenara la fecha en que a un empleado se le registra la fecha de reingreso
        public DateTime empFechaReingreso { get; set; }
        public string empEdu { get; set; }
        public string empDireNumero { get; set; }
        public string empTipSangre { get; set; }
        public decimal empDiscapacidad { get; set; }
        public string empNumConadis { get; set; }
        public decimal empAfiFarma { get; set; }
        public DateTime? empAfiFarmaFec { get; set; }
        public DateTime empAfiSegFec { get; set; }
        public string empHor { get; set; }
        public decimal empPagFonRes { get; set; }
        public string empPasaporte { get; set; }
        public decimal empSujCrdt { get; set; }
        public string empMail { get; set; }
        public string empMailPer { get; set; }
        public decimal empClaveAsist { get; set; }
        public decimal empPorcDisc { get; set; }
        public string dscId { get; set; }
        public decimal empPagDecTer { get; set; }
        public decimal empPagDecCua { get; set; }
        public string empObs { get; set; }
        public DateTime fecContratoAux { get; set; }
        public decimal empDependientes { get; set; }
    }
}
