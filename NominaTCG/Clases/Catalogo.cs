using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace NominaTCG
{
    public class Catalogo
    {
        public static string CodeSystem {get; set;}
        public static string UserSystem { get; set;}
        public static string UserName { get; set; }
        public static string RoleName { get; set; }
        public static string UserRole { get; set; }
        public static string UserProfile { get; set; }
        public static string ServerData { get; set; }
        public static string PathReport { get; set; }

        public static DataTable NovedadTipo()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("ID");
            datos.Columns.Add("Nombre");
            datos.Rows.Add(1 ,"Aviso De Entrada");
            datos.Rows.Add(2 ,"Aviso De Salida");
            datos.Rows.Add(3 ,"Aviso De Nuevo Sueldo");
            datos.Rows.Add(4 ,"Aviso De Variacion De Sueldos Por Extras");
            datos.Rows.Add(5 ,"Planilla De Fondos De Reserva");
            datos.Rows.Add(6 ,"Aviso De Dias No Laborados");
            datos.Rows.Add(7 ,"Aviso Horas Trabajadas");
            return datos;

        }

        public static DataTable Porcentaje()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("DIA_PORC");
            //datos.Columns.Add("Nombre");
            datos.Rows.Add(25);
            datos.Rows.Add(50);
            datos.Rows.Add(100);
            return datos;
        }

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

        public static DataTable Actitud()
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

        public static DataTable Estado()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("ID");
            datos.Columns.Add("Nombre");
            datos.Rows.Add(1, "Activo");
            datos.Rows.Add(0, "Inactivo");
            
            return datos;
        }

        public static DataTable Condicional()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("ID");
            datos.Columns.Add("Nombre");
            datos.Rows.Add(1, "Si");
            datos.Rows.Add(0, "No");
            return datos;
        }

        public static DataTable Pagos()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("ID");
            datos.Columns.Add("Nombre");
            datos.Rows.Add(1, "No Pagado");
            datos.Rows.Add(2, "Pagado");
            return datos;
        }
        

    }

    public enum Acction
    {
        New,
        Edit,
        Borrar,
        Delete,
        Cancel,
        Save,
        Listar
    }

    public class dbType
    {
        public static int? intNull = null;
        public static bool? boolNull = null;
        public static DateTime dateResult;
        public static DateTime? dateNull = null;        
    }
    
}
