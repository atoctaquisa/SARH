using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class DatEmpCon
    {
        public decimal empId {get; set;}
        public decimal empConId{get;set;}
        public decimal conId{get;set;}
        public decimal patId{get;set;}
        public string empConRazonSale{get;set;}
        public Int32? empConFirmRenu{get;set;}
        public DateTime? empConFecLiqui{get;set;}
        public int? empConFirmLiqui{get;set;}
        public DateTime empConFecLegSa{get;set;}
        public string empConFirmSalida{get;set;}
        public DateTime empConFecMinTr{get;set;}
        public DateTime? empConFecContrato{get;set;}
        public string empConObs{get;set;}
        public DateTime empConFecReg{get;set;}
        public DateTime empConFecMod{get;set;}
        public string empConCausa{get;set;}
        public decimal empConEstado{get;set;}
        public Int32? conCauId { get; set; }
        public decimal empConFirmCon{get;set;}
        public decimal empConLegalizado { get; set; }
    }
}
