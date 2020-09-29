using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using System.Data;
using System.Configuration;
using Logger;
using Oracle.DataAccess.Types;
namespace DataAccess
{
    public class ConnectionDDBB
    {

        #region Instancia
        private static ConnectionDDBB _instancia;
        public static ConnectionDDBB Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ConnectionDDBB();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }
        #endregion

        private OracleConnection _connection;       

        private OracleConnection OpenConnection()
        {
            _connection = new OracleConnection(Properties.Settings.Default.cadenaConexion);
            _connection.Open();
            return _connection;

            //try
            //{    
            //    _connection = new OracleConnection(Properties.Settings.Default.cadenaConexion);
            //    _connection.Open();
                
            //    return _connection;
            //}
            //catch (Exception ex)
            //{   
            //    Logger.ErrorLog.ErrorRoutine(false, ex);               
            //    return _connection;
            //}            
        }
        private OracleConnection CloseConnection()
        {
            if (_connection != null)
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                    _connection.Dispose();
                }
            }

            return _connection;
            //try
            //{                
            //    if (_connection != null)
            //    {
            //        if (_connection.State != ConnectionState.Closed)
            //        {
            //            _connection.Close();
            //            _connection.Dispose();
            //        }
            //    }

            //    return _connection ;
            //}
            //catch (Exception ex)
            //{
            //    _connection.Close();
            //    _connection.Dispose();
            //    Logger.ErrorLog.ErrorRoutine(false, ex);                
            //    return _connection;
            //}

        }
        public DataSet paginacionData(string query,int recordIni, int recordMax )
        {
            DataTable data = new DataTable();
            OracleCommand cmd = new OracleCommand();
            DataSet ds = new DataSet();
            data = null;

            cmd.Connection = OpenConnection();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter apt = new OracleDataAdapter();
            apt.SelectCommand = cmd;
            apt.Fill(ds,recordIni,recordMax,"Empleado");
            data = ds.Tables[0];
            cmd.Dispose();
            CloseConnection();
            return ds;
        }

            public DataTable GetData(string query)
        {
            DataTable data = new DataTable();
            OracleCommand cmd = new OracleCommand();
            DataSet ds = new DataSet();
            data = null;

            cmd.Connection = OpenConnection();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter apt = new OracleDataAdapter();
            apt.SelectCommand = cmd;           
            apt.Fill(ds);
            data = ds.Tables[0];
            cmd.Dispose();
            CloseConnection();
            return data;

            //DataTable data = new DataTable();
            //OracleCommand cmd = new OracleCommand();
            //DataSet ds = new DataSet();
            //data = null;

            //try
            //{
            //    cmd.Connection = OpenConnection();
            //    cmd.CommandText = query;
            //    cmd.CommandType = CommandType.Text;
            //    OracleDataAdapter apt = new OracleDataAdapter();
            //    apt.SelectCommand = cmd;
            //    //apt.ReturnProviderSpecificTypes = true;
            //    apt.Fill(ds);
            //    data = ds.Tables[0];
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(false, e);
            //    throw new System.ArgumentException(e.Message);
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();
            //}
            //return data;
        }

        public DataTable GetData(string query, OracleParameter[] prm)
        {
            DataTable data = new DataTable();
            OracleCommand cmd = new OracleCommand();
            DataSet ds = new DataSet();
            data = null;
            cmd.Connection = OpenConnection();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddRange(prm);
            OracleDataAdapter apt = new OracleDataAdapter();
            apt.SelectCommand = cmd;            
            apt.Fill(ds);
            data = ds.Tables[0];
            cmd.Dispose();
            CloseConnection();
            return data;

            //DataTable data = new DataTable();
            //OracleCommand cmd = new OracleCommand();
            //DataSet ds = new DataSet();
            //data = null;

            //try
            //{
            //    cmd.Connection = OpenConnection();
            //    cmd.CommandText = query;
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Parameters.AddRange(prm);
            //    OracleDataAdapter apt = new OracleDataAdapter();
            //    apt.SelectCommand = cmd;
            //    //apt.ReturnProviderSpecificTypes = true;
            //    apt.Fill(ds);
            //    data = ds.Tables[0];
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(false, e);
            //    throw new System.ArgumentException(e.Message);
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();
            //}
            //return data;
        }
        public DataTable GetDataLong(string query, OracleParameter[] prm)
        {
            DataTable data = new DataTable();
            OracleCommand cmd = new OracleCommand();
            DataSet ds = new DataSet();
            data = null;
            cmd.Connection = OpenConnection();
            cmd.InitialLONGFetchSize = -1;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddRange(prm);
            OracleDataAdapter apt = new OracleDataAdapter();
            apt.SelectCommand = cmd;            
            apt.Fill(ds);
            data = ds.Tables[0];
            cmd.Dispose();
            CloseConnection();
            return data;            
            
            //DataTable data = new DataTable();
            //OracleCommand cmd = new OracleCommand();
            //DataSet ds = new DataSet();
            //data = null;

            //try
            //{
            //    cmd.Connection = OpenConnection();
            //    cmd.InitialLONGFetchSize = -1;
            //    cmd.CommandText = query;
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Parameters.AddRange(prm);
            //    OracleDataAdapter apt = new OracleDataAdapter();
            //    apt.SelectCommand = cmd;
            //    //apt.ReturnProviderSpecificTypes = true;
            //    apt.Fill(ds);
            //    data = ds.Tables[0];
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(false, e);
            //    throw new System.ArgumentException(e.Message);
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();
            //}
            //return data;
        }
        
        public OracleDataReader ExecuteSelect(string query)
        {
            OracleDataReader reader;
            OracleCommand cmd = new OracleCommand(query, OpenConnection());
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Dispose();
            CloseConnection();
            return reader;
            
            //OracleDataReader reader;
            //OracleCommand cmd = new OracleCommand(query, OpenConnection()); ;
            //try
            //{
            //    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //    return reader;
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(true, e);
            //    throw new System.ArgumentException(e.Message);
            //    //return null;
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();
            //}            

        }

        public int ExecProcedure(string procedure)
        {
            int returnValue = 0;
            OracleCommand cmd = new OracleCommand(procedure, OpenConnection());
            cmd.CommandText = procedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            returnValue = 1;
            cmd.Dispose();
            CloseConnection();
            return returnValue;            
            
            //int returnValue = 0;
            //OracleCommand cmd = new OracleCommand(procedure, OpenConnection()); ;
            //try
            //{
            //    cmd.CommandText = procedure;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.ExecuteNonQuery();
            //    returnValue = 1;
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(false, e);
            //    throw new System.ArgumentException(e.Message);
            //    //return 0;                
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();
            //}
            //return returnValue;

        }


        public string[] ExecProcedureOUTIN(string procedure, OracleParameter[] prm, string [] resp)
        {
            string[] p;
            OracleCommand cmd = new OracleCommand(procedure, OpenConnection());
            cmd.CommandText = procedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(prm);
            cmd.ExecuteNonQuery();
            p = new string[resp.Count()];
            for (int i = 0; i < resp.Count(); i++)
            {
                p[i] = cmd.Parameters[resp[i]].Value.ToString();
            }
            cmd.Dispose();
            CloseConnection();
            return p;            
           
            //string[] p;
            //OracleCommand cmd = new OracleCommand(procedure, OpenConnection()); ;
            //try
            //{
            //    cmd.CommandText = procedure;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddRange(prm);
            //    cmd.ExecuteNonQuery();
            //    p = new string[resp.Count()];
            //    for (int i = 0; i < resp.Count(); i++)
            //    {
            //        p[i] = cmd.Parameters[resp[i]].Value.ToString();
            //    }
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(false, e);
            //    throw new System.ArgumentException(e.Message);
            //    //string[] pd = { "0" };
            //    //return pd;                
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();
            //}
            //return p;
        }
                       
        public int ExecProcedureOUT(string procedure, OracleParameter[] prm)
        {
            int returnValue = 0;
            OracleCommand cmd = new OracleCommand(procedure, OpenConnection());
            cmd.CommandText = procedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(prm);
            cmd.ExecuteNonQuery();
            returnValue = Convert.ToInt32(cmd.Parameters[0].Value.ToString());
            cmd.Dispose();
            CloseConnection();
            return returnValue;           
            

            //int returnValue = 0;
            //OracleCommand cmd = new OracleCommand(procedure, OpenConnection()); ;
            //try
            //{
            //    cmd.CommandText = procedure;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddRange(prm);
            //    cmd.ExecuteNonQuery();
            //    returnValue = Convert.ToInt32(cmd.Parameters[0].Value.ToString());
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(false, e);
            //    //throw new System.ArgumentException(e.Message);
            //    //return 0;                
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();
            //}
            //return returnValue;

        }

        public int ExecProcedure(string procedure, OracleParameter[] prm)
        {
            int returnValue = 0;
            OracleCommand cmd = new OracleCommand(procedure, OpenConnection());
            cmd.CommandText = procedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(prm);
            cmd.ExecuteNonQuery();
            returnValue = 1;
            cmd.Dispose();
            CloseConnection();
            return returnValue;
            
            //int returnValue = 0;
            //OracleCommand cmd = new OracleCommand(procedure, OpenConnection()); ;

            //try
            //{
            //    cmd.CommandText = procedure;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddRange(prm);
            //    cmd.ExecuteNonQuery();
            //    returnValue = 1;
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(false, e);
            //    throw new Exception(e.Message);
            //    //throw new System.ArgumentException(e.Message);
            //    //return 0;                
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();                
            //}
            //return returnValue;

        }

        public int ExecQuery(string query, OracleParameter[] prm)
        {
            int returnValue = 0;
            OracleCommand cmd = new OracleCommand(query, OpenConnection());
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddRange(prm);
            cmd.ExecuteNonQuery();
            returnValue = 1;
            cmd.Dispose();
            CloseConnection();
            return returnValue;            
            
            //int returnValue = 0;
            //OracleCommand cmd = new OracleCommand(query, OpenConnection()); ;
            //try
            //{
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Parameters.AddRange(prm);
            //    cmd.ExecuteNonQuery();
            //    returnValue = 1;
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(false, e);
            //    throw new System.ArgumentException(e.Message);
            //    //return 0;                
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();
            //}
            //return returnValue;

        }

        public int ExecQuery(string query)
        {
            int returnValue = 0;
            OracleCommand cmd = new OracleCommand(query, OpenConnection());
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            returnValue = 1;
            cmd.Dispose();
            CloseConnection();
            return returnValue;           
            

            //int returnValue = 0;
            //OracleCommand cmd = new OracleCommand(query, OpenConnection()); ;
            //try
            //{
            //    cmd.CommandType = CommandType.Text;
            //    cmd.ExecuteNonQuery();
            //    returnValue = 1;
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(false, e);
            //    throw new System.ArgumentException(e.Message);
            //    //return 0;                      
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();
            //}
            //return returnValue;

        }

        public double GetDecimal(string query, OracleParameter[] prm)
        {
            double returnValue = 0;
            OracleCommand cmd = new OracleCommand(query, OpenConnection());
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddRange(prm);
            DataTable tmpResultado = new DataTable();
            OracleDataAdapter adpt = new OracleDataAdapter();
            adpt.SelectCommand = cmd;
            adpt.Fill(tmpResultado);
            if (tmpResultado.Rows.Count > 0)
            {
                returnValue = Convert.ToDouble(tmpResultado.Rows[0][0].ToString());
            }
            cmd.Dispose();
            CloseConnection();
            return returnValue;                       
            
            //double returnValue = 0;
            //OracleCommand cmd = new OracleCommand(query, OpenConnection()); ;
            //try
            //{
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Parameters.AddRange(prm);
            //    DataTable tmpResultado = new DataTable();
            //    OracleDataAdapter adpt = new OracleDataAdapter();
            //    adpt.SelectCommand = cmd;
            //    adpt.Fill(tmpResultado);
            //    if (tmpResultado.Rows.Count > 0)
            //    {
            //        returnValue = Convert.ToDouble(tmpResultado.Rows[0][0].ToString());
            //    }
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(false, e);
            //    throw new System.ArgumentException(e.Message);
            //    //return 0;               
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();
            //}
            //return returnValue;

        }

        public double GetDecimal(string query)
        {
            double returnValue = 0;
            OracleCommand cmd = new OracleCommand(query, OpenConnection());
            cmd.CommandType = CommandType.Text;
            DataTable tmpResultado = new DataTable();
            OracleDataAdapter adpt = new OracleDataAdapter();
            adpt.SelectCommand = cmd;
            adpt.Fill(tmpResultado);
            if (tmpResultado.Rows.Count > 0)
            {
                returnValue = Convert.ToDouble(tmpResultado.Rows[0][0].ToString());
            }
            cmd.Dispose();
            CloseConnection();
            return returnValue;           
            

            //double returnValue = 0;
            //OracleCommand cmd = new OracleCommand(query, OpenConnection()); ;
            //try
            //{
            //    cmd.CommandType = CommandType.Text;
            //    DataTable tmpResultado = new DataTable();
            //    OracleDataAdapter adpt = new OracleDataAdapter();
            //    adpt.SelectCommand = cmd;
            //    adpt.Fill(tmpResultado);
            //    if (tmpResultado.Rows.Count > 0)
            //    {
            //        returnValue = Convert.ToDouble(tmpResultado.Rows[0][0].ToString());
            //    }
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(false, e);
            //    throw new System.ArgumentException(e.Message);
            //    //return 0;                
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();
            //}
            //return returnValue;

        }

        public Int32 GetEntero(string query, OracleParameter[] prm)
        {
            Int32 returnValue = 0;
            OracleCommand cmd = new OracleCommand(query, OpenConnection());
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddRange(prm);
            DataTable tmpResultado = new DataTable();
            OracleDataAdapter adpt = new OracleDataAdapter();
            adpt.SelectCommand = cmd;
            adpt.Fill(tmpResultado);
            if (tmpResultado.Rows.Count > 0)
            {
                returnValue = Convert.ToInt32(tmpResultado.Rows[0][0].ToString());
            }
            cmd.Dispose();
            CloseConnection();
            return returnValue;           
           

            //Int32 returnValue = 0;
            //OracleCommand cmd = new OracleCommand(query, OpenConnection()); ;
            //try
            //{
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Parameters.AddRange(prm);
            //    DataTable tmpResultado = new DataTable();
            //    OracleDataAdapter adpt = new OracleDataAdapter();
            //    adpt.SelectCommand = cmd;
            //    adpt.Fill(tmpResultado);
            //    if (tmpResultado.Rows.Count > 0)
            //    {
            //        returnValue = Convert.ToInt32(tmpResultado.Rows[0][0].ToString());
            //    }
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(false, e);
            //    throw new System.ArgumentException(e.Message);
            //    //return 0;
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();
            //}
            //return returnValue;

        }

        public Int32 GetEntero(string query)
        {
            Int32 returnValue = 0;
            OracleCommand cmd = new OracleCommand(query, OpenConnection());
            cmd.CommandType = CommandType.Text;
            DataTable tmpResultado = new DataTable();
            OracleDataAdapter adpt = new OracleDataAdapter();
            adpt.SelectCommand = cmd;
            adpt.Fill(tmpResultado);
            if (tmpResultado.Rows.Count > 0)
            {
                returnValue = Convert.ToInt32(tmpResultado.Rows[0][0].ToString());
            }
            cmd.Dispose();
            CloseConnection();
            return returnValue;
            

            //Int32 returnValue = 0;
            //OracleCommand cmd = new OracleCommand(query, OpenConnection()); ;
            //try
            //{
            //    cmd.CommandType = CommandType.Text;
            //    DataTable tmpResultado = new DataTable();
            //    OracleDataAdapter adpt = new OracleDataAdapter();
            //    adpt.SelectCommand = cmd;
            //    adpt.Fill(tmpResultado);
            //    if (tmpResultado.Rows.Count > 0)
            //    {
            //        returnValue = Convert.ToInt32(tmpResultado.Rows[0][0].ToString());
            //    }
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(false, e);
            //    throw new System.ArgumentException(e.Message);
            //    //return 0;                
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();
            //}
            //return returnValue;

        }

        public string GetString(string query, OracleParameter[] prm)
        {
            string returnValue = string.Empty;
            OracleCommand cmd = new OracleCommand(query, OpenConnection());
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddRange(prm);
            DataTable tmpResultado = new DataTable();
            OracleDataAdapter adpt = new OracleDataAdapter();
            adpt.SelectCommand = cmd;
            adpt.Fill(tmpResultado);
            if (tmpResultado.Rows.Count > 0)
            {
                returnValue = tmpResultado.Rows[0][0].ToString();
            }
            cmd.Dispose();
            CloseConnection();
            return returnValue;            
            

            //string returnValue = string.Empty;
            //OracleCommand cmd = new OracleCommand(query, OpenConnection()); ;
            //try
            //{
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Parameters.AddRange(prm);
            //    DataTable tmpResultado = new DataTable();
            //    OracleDataAdapter adpt = new OracleDataAdapter();
            //    adpt.SelectCommand = cmd;
            //    adpt.Fill(tmpResultado);
            //    if (tmpResultado.Rows.Count > 0)
            //    {
            //        returnValue = tmpResultado.Rows[0][0].ToString();
            //    }
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(false, e);
            //    throw new System.ArgumentException(e.Message);
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();
            //}
            //return returnValue;

        }

        public string GetString(string query)
        {
            string returnValue = string.Empty;
            OracleCommand cmd = new OracleCommand(query, OpenConnection());
            cmd.CommandType = CommandType.Text;
            DataTable tmpResultado = new DataTable();
            OracleDataAdapter adpt = new OracleDataAdapter();
            adpt.SelectCommand = cmd;
            adpt.Fill(tmpResultado);
            if (tmpResultado.Rows.Count > 0)
            {
                returnValue = tmpResultado.Rows[0][0].ToString();
            }
            cmd.Dispose();
            CloseConnection();
            return returnValue;           

            //string returnValue = string.Empty;
            //OracleCommand cmd = new OracleCommand(query, OpenConnection()); ;
            //try
            //{
            //    cmd.CommandType = CommandType.Text;
            //    DataTable tmpResultado = new DataTable();
            //    OracleDataAdapter adpt = new OracleDataAdapter();
            //    adpt.SelectCommand = cmd;
            //    adpt.Fill(tmpResultado);
            //    if (tmpResultado.Rows.Count > 0)
            //    {
            //        returnValue = tmpResultado.Rows[0][0].ToString();
            //    }
            //}
            //catch (OracleException e)
            //{
            //    Logger.ErrorLog.ErrorRoutine(false, e);
            //    throw new System.ArgumentException(e.Message);
            //}
            //finally
            //{
            //    cmd.Dispose();
            //    CloseConnection();
            //}
            //return returnValue;
        }
    }
}
