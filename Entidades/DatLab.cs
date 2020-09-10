using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class DatLab
    {
        public decimal empId{ get; set; }
        public decimal labId{ get; set; }
        public decimal locId{ get; set; }
        public decimal escId{ get; set; }
        public DateTime? labFecCambEsc{ get; set; }
        public decimal labSueldoBono{ get; set; }
        public string labObs{ get; set; }        
        public DateTime labFecReg{ get; set; }
        public DateTime? labFecMod{ get; set; }
        public string labFecObsSis{ get; set; }
        public decimal labEstado{ get; set; }
        public decimal labTipoEmp{ get; set; }
        public decimal labRbu{ get; set; }
        public decimal labVest{ get; set; }
        public decimal labBono{ get; set; }
        public decimal labQuincena{ get; set; }

        
    }
}
