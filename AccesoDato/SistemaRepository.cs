using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Oracle.DataAccess.Client;
using System.Net;
using System.Net.Mail;

namespace DataAccess
{
    public class SistemaRepository
    {
        #region Variables
        private SmtpClient _smtpClient;
        private NetworkCredential _basicCredential;
        private MailAddress _fromAddress;
        private MailMessage _message;
        private string _UserTo;

        private static string emailFrom = "sistemas@grupotcg.com";
        private static string emailKey = "5i5t3mas@2020*";
        private static string emailServer = "192.168.1.1";
        private static string SMTPPort = "587";
        private static string enableSsl = "false";

        private const string sqlSendEmail = "DESARROLLO.ENVIA_CORREO_TCG@BBDDCENTRAL";
        private const string sqlDateServer = "SELECT SYSDATE FROM DUAL";
        private const string sqlEmailMessage = "SELECT NTF_MENSAJE FROM DESARROLLO.DAT_NOTIFICACION WHERE NTF_NOMBRE=:NTF_NOMBRE";
        private const string sqlUsuario = "SELECT USROCDGO CODIGO, USRONOMB NOMBRE, USROLOGIN, U.TPUSCDGO, USROPASS, USROSTDO, TPUSDSCR FROM DESARROLLO.DAT_USRO U JOIN DESARROLLO.DAT_TPUS T ON(T.TPUSCDGO=U.TPUSCDGO) WHERE U.USROSTDO=1 ORDER BY 2";
        private const string sqlCodeSystem = "SELECT APPCDGO FROM DESARROLLO.DAT_APP WHERE APPCODE='SARH'";
        private const string sqlMenuState = @"SELECT MENUETDO FROM DAT_MENU M
                                            WHERE APPCDGO=:codeSystem AND MENUCODE=:mnuCode
                                            AND EXISTS(SELECT * FROM DAT_TPUS_MENU T 
                                            WHERE TPUSCDGO=:userRol AND T.MENUCDGO=M.MENUCDGO)";
        private const string sqlPath = @"	SELECT SET_VALOR FROM DESARROLLO.DAT_INV_SET
	                                        WHERE SET_ID=:PARAM_ID";
        private const string sqlHuellaEmp = "SELECT HUE_ID FROM DAT_HUELLA_EMPLEADO WHERE EMP_ID=:EMP_ID";
        private const string sqlRegistraHuella = "DESARROLLO.P_HUELLA";
        private const string sqlServer = "SELECT UTL_INADDR.GET_HOST_ADDRESS IP FROM DUAL";
        private const string sqlServerPRD = "SELECT SET_VALOR IP FROM DESARROLLO.DAT_INV_SET WHERE SET_ID=79";
        //private const string s
        #endregion

        #region Properties
        private ConnectionDDBB db { get; set; }
        #endregion

        #region Methods
        public string ServerData()
        {
            string server;
            if (db.GetString(sqlServer).Equals(db.GetString(sqlServerPRD)))
                server = "PRD";
            else
                server = "TEST";

            return server;
        }
        public int RegistraHuella(string empID, string idHuella, string obsID)
        {
            OracleParameter[] prm = new OracleParameter[]
          {
                new OracleParameter(":EMP_ID",empID ),
                new OracleParameter(":HUE_ID",idHuella ),
                new OracleParameter(":OBS_ID",obsID )
          };

            return db.ExecProcedure(sqlRegistraHuella, prm);
        }
        public int VerificaHuella(string empID, string idHuella)
        {
            OracleParameter[] prm = new OracleParameter[]
          {
                new OracleParameter(":EMP_ID",empID )
          };
            int ban = 0;
            DataTable huella = db.GetData(sqlHuellaEmp, prm);
            if (huella.Rows.Count > 0)
            {
                foreach (DataRow item in huella.Rows)
                {
                    if (ComparaHuella(idHuella, item["HUE_ID"].ToString()).Equals(1))
                    {
                        ban = 1;
                        break;
                    }
                }
            }
            return ban;
        }
        public int ComparaHuella(string strHuella, string strHuellaComparar)
        {
            try
            {
                D2WEBLib.d2finger Lector = new D2WEBLib.d2finger();
                Lector.huella = strHuella;
                Lector.huellaComparar = strHuellaComparar;
                Lector.compararHuella();
                int resp = Lector.retorno;
                Lector = null;
                return resp;
            }

            catch (Exception e)
            {
                Logger.ErrorLog.ErrorRoutine(false, e);
                return 0;
            }
        }
        public string CapturaHuella()
        {
            try
            {
                D2WEBLib.d2finger Lector = new D2WEBLib.d2finger();
                Lector.identificacion = "9999999999";
                Lector.posicion = 1;
                Lector.captura();
                string strHuella = Lector.huellaCapturada;
                Lector = null;
                return strHuella;
            }
            catch (Exception e)
            {
                Logger.ErrorLog.ErrorRoutine(false, e);
                return "";
            }

        }

        public string Path(string paramID)
        {
            OracleParameter[] prm = new OracleParameter[]
           {
                new OracleParameter(":PARAM_ID",paramID )
           };
            return db.GetString(sqlPath, prm);
        }
        public Boolean stateMenu(string codeSystem, string mnuCode, string userRol)
        {
            string item;
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":codeSystem",codeSystem ),
                new OracleParameter(":mnuCode",mnuCode ),
                new OracleParameter(":userRol",userRol )
            };
            item = db.GetString(sqlMenuState, prm);
            if (item == "S")
                return true;
            else
                return false;
        }

        public string CodeSystem()
        {
            return db.GetString(sqlCodeSystem);
        }

        public DataTable Usuario()
        {
            return db.GetData(sqlUsuario);
        }

        public string emailMessage(string emailTipo, object[,] emailVars)
        {
            OracleParameter[] prm = new OracleParameter[]
            {
                new OracleParameter(":NTF_NOMBRE",emailTipo )
            };
            string result = db.GetString(sqlEmailMessage, prm);

            for (int i = 0; i < emailVars.Length / 2; i++)
            {
                if (emailVars[i, 1] != null)
                {
                    result = result.Replace(emailVars[i, 0].ToString(), emailVars[i, 1].ToString());
                }
            }
            return result;
        }
        public bool SendEmail(string userTo, string userSubject, string userSms)
        {
            //Get Notification            
            _UserTo = userTo;
            //SMTP options
            _basicCredential = new NetworkCredential(emailFrom, emailKey);
            _smtpClient = new SmtpClient();
            _smtpClient.Host = emailServer;
            _smtpClient.Port = int.Parse(SMTPPort);
            _smtpClient.EnableSsl = bool.Parse(enableSsl);
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = _basicCredential;
            //Email options
            _fromAddress = new MailAddress(emailFrom);
            _message = new MailMessage();
            _message.From = _fromAddress;
            _message.To.Add(_UserTo);
            _message.Subject = userSubject;
            _message.Body = userSms;
            _message.IsBodyHtml = true;
            try
            {
                _smtpClient.Send(_message);
                return true;
            }
            catch (Exception e)
            {
                Logger.ErrorLog.ErrorRoutine(false, e);
                return false;
            }

        }
        public string FechaCentral()
        {
            return db.GetString(sqlDateServer);
        }
        #endregion

        #region Instancia / Constructor
        private static SistemaRepository _instancia;
        public static SistemaRepository Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SistemaRepository();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public SistemaRepository()
        {
            db = ConnectionDDBB.Instancia;
        }
        #endregion
    }
}
