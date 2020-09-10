using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class DatEmpFam
    {
        public decimal empId { get; set; }
        public decimal empFamId{get;set;}
        public string empFamNombre{get;set;}
        public DateTime empFamFecNac{get;set;}
        public string empFamParent{get;set;}
        public string empFamOcup{get;set;}
        public string empFamTelfRef{get;set;}
        public decimal empFamDisc { get; set; }
    }
}
