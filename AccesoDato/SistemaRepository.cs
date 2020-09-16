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
        private const string sqlUsuario = "SELECT USROCDGO CODIGO, USRONOMB NOMBRE, USROLOGIN, TPUSCDGO, USROPASS, USROSTDO FROM DESARROLLO.DAT_USRO WHERE USROSTDO=1 ORDER BY 2";
        private const string sqlCodeSystem ="SELECT APPCDGO FROM DESARROLLO.DAT_APP WHERE APPCODE='SARH'";
        private const string sqlMenuState = @"SELECT MENUETDO FROM DAT_MENU M
                                            WHERE APPCDGO=:codeSystem AND MENUCODE=:mnuCode
                                            AND EXISTS(SELECT * FROM DAT_TPUS_MENU T 
                                            WHERE TPUSCDGO=:userRol AND T.MENUCDGO=M.MENUCDGO)";
        private const string sqlPath = @"	SELECT SET_VALOR FROM DESARROLLO.DAT_INV_SET
	                                        WHERE SET_ID=:PARAM_ID";
        //private const string s
        #endregion
        
        #region Properties
        private ConnectionDDBB db { get; set; }
        #endregion
        
        #region Methods
        public string Path(string paramID)
        {
            OracleParameter[] prm = new OracleParameter[]
           {
                new OracleParameter(":PARAM_ID",paramID )
           };
            return  db.GetString(sqlPath, prm);
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
            item = db.GetString(sqlMenuState,prm);
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
            catch(Exception e)
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
