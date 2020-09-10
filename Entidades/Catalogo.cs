using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class Catalogo
    {
       
        public static DataTable Parentesco()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("ID");
            datos.Columns.Add("Nombre");
            datos.Rows.Add("H", "Hijo(a)");
            datos.Rows.Add("E", "Conyugue");
            return datos;
        }
        public static DataTable PagoServicio()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("ID");
            datos.Columns.Add("Nombre");
            datos.Rows.Add(0, "Nomina");
            datos.Rows.Add(1, "Servicios Profesionales");
            datos.Rows.Add(2, "Sin Rol");
            return datos;
        }

        public static DataTable EstadoLaboral()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("ID");
            datos.Columns.Add("Nombre");
            datos.Rows.Add(1, "Activo");
            datos.Rows.Add(0, "Pasivo");
            datos.Rows.Add(2, "A prueba");
            datos.Rows.Add(3, "Inactivo");
            datos.Rows.Add(4, "Suspendido");
            datos.Rows.Add(5, "Sin Rol");
            return datos;
        }

        public static DataTable TipoActitud()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("ID");
            datos.Columns.Add("Nombre");
            datos.Rows.Add("P", "Positiva");
            datos.Rows.Add("N", "Negativa");
            return datos;
        }

        public static DataTable NivelEducacion()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("ID");
            datos.Columns.Add("Nombre");
            datos.Rows.Add("PRI", "Primaria");
            datos.Rows.Add("SEC", "Secundaria");
            datos.Rows.Add("SUP", "Superior");
            datos.Rows.Add("POS", "Postgrado");
            datos.Rows.Add("TEC", "Técnico");
            datos.Rows.Add("OTR", "Otros");
            return datos;
        }

        public static DataTable EstadoCivil()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("ID");
            datos.Columns.Add("Nombre");
            datos.Rows.Add("S", "Soltero");
            datos.Rows.Add("C", "Casado");
            datos.Rows.Add("U", "Unión Libre");
            datos.Rows.Add("Se", "Separado");
            datos.Rows.Add("D", "Divorciado");
            datos.Rows.Add("V", "Viudo");
            return datos;
        }

        public static DataTable Sexo()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("ID");
            datos.Columns.Add("Nombre");
            datos.Rows.Add(0, "Mujer");
            datos.Rows.Add(1, "Hombre");
            return datos;

        }

        public static DataTable TipoCuenta()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("ID");
            datos.Columns.Add("Nombre");
            datos.Rows.Add(1, "Cuenta Corriente");
            datos.Rows.Add(0, "Cuenta Ahorros");
            datos.Rows.Add(2, "Cuenta Virtual");
            datos.Rows.Add(3, "Cheque");
            return datos;

        }

        public static DataTable TipoEstado()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("ID");
            datos.Columns.Add("Nombre");
            datos.Rows.Add(0, "Inactivo");
            datos.Rows.Add(1, "Activo");
            return datos;
        }

        public static DataTable RespCorta()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("ID");
            datos.Columns.Add("Nombre");
            //datos.Rows.Add(DBNull.Value, "");
            datos.Rows.Add(1, "Si");
            datos.Rows.Add(0, "No");
            
            return datos;
        }
    }
}
