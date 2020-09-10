using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DataAccess;
using System.Data;
namespace BusinessLogic
{
    public class CatalogoController
    {
        private CatalogoRepository catalogoAD { get; set; }

        public CatalogoController()
        {
            catalogoAD = CatalogoRepository.Instancia;
            forma = new FrmEmergente();
        }

        public DataTable ListaProvincia()
        {
            return catalogoAD.ListaProvincia();
        }

        public DataTable ListaCiudad()
        {
            return catalogoAD.ListaCiudad();
        }
        //public List<ProvinciaEntity> ListaProvincia()
        //{
        //    return catalogoAD.ListaProvincia();
        //}

        //public List<CiudadEntity> ListaCiudad()
        //{
        //    return catalogoAD.ListaCiudad();
        //}

        public ProvinciaEntity ProvinciaAD { get; set; }

        public FrmEmergente forma { get; set; }
    }
}
