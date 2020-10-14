using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data;
using System.Globalization;
//using System.Text.RegularExpressions;
namespace BusinessLogic
{
    public class SistemaController
    {

        #region Variables

        #endregion

        #region Propiedades
        private SistemaRepository SistemaAD { get; set; }
        #endregion

        #region Methods
        public string ServerData()
        {
            return SistemaAD.ServerData();
        }
        public int RegistraHuella(string empID, string idHuella, string obsID)
        {
            return SistemaAD.RegistraHuella(empID, idHuella, obsID);
        }
        public int VerificaHuella(string empID, string idHuella)
        {
            return SistemaAD.VerificaHuella(empID, idHuella);
        }
        public string CapturaHuella()
        {
            return SistemaAD.CapturaHuella();
        }
        public int ComparaHuella(string strHuella, string strHuellaComparar)
        {
            return SistemaAD.ComparaHuella(strHuella, strHuellaComparar);
        }
        public string Path(string paramID)
        {
            return SistemaAD.Path(paramID);
        }
        public Boolean stateMenu(string codeSystem, string mnuCode, string userRole)
        {
            return SistemaAD.stateMenu(codeSystem, mnuCode, userRole);
        }
        public string CodeSystem()
        {
            return SistemaAD.CodeSystem();
        }
        public DataTable Usuario()
        {
            return SistemaAD.Usuario();
        }
        public bool sendEmail(string userTo, string userSubject, string userSms)
        {
            return SistemaAD.SendEmail(userTo, userSubject, userSms);
        }

        public string emailMessage(string tipo, object[,] emailVars)
        {
            return SistemaAD.emailMessage(tipo, emailVars);
        }

        public string FechaCentral()
        {
            return SistemaAD.FechaCentral();
        }
        #endregion

        #region Instancia / Constructor
        private static SistemaController _instancia;
        public static SistemaController Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SistemaController();
                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public SistemaController()
        {
            SistemaAD = SistemaRepository.Instancia;
        }
        #endregion

    }

    public class Utility
    {
        public static string iMessage = @"";
        public static bool isDate(string argu)
        {
            try
            {
                DateTime.Parse(argu);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Mostrar mensaje de informacion

        public static void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Nómina", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion


        #region Mostrar mensaje de error

        public static void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Nómina", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        public static DialogResult MensajeQuestion(string mensaje)
        {
            return MessageBox.Show(mensaje, "Sistema de Nómina", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

        }
        public static void MensajeInfo(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Nómina", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void BloodType(KeyPressEventArgs argu)
        {

            if (!char.IsLetter(argu.KeyChar) && !char.IsControl(argu.KeyChar) && !char.IsWhiteSpace(argu.KeyChar) && !(Char.IsNumber(argu.KeyChar)))
                argu.Handled = true;
        }

        public static void OnlyTextAndDigit(KeyPressEventArgs argu)
        {

            if (!char.IsLetter(argu.KeyChar) && !char.IsControl(argu.KeyChar) && !char.IsWhiteSpace(argu.KeyChar) && !(Char.IsNumber(argu.KeyChar)))
                argu.Handled = true;
        }

        public static void OnlyText(KeyPressEventArgs argu)
        {
            if (!char.IsLetter(argu.KeyChar) && !char.IsControl(argu.KeyChar) && !char.IsWhiteSpace(argu.KeyChar))
                argu.Handled = true;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }


        //public static bool IsValidEmail(string strIn)
        //{
        //    bool invalid = false;

        //    if (String.IsNullOrEmpty(strIn))
        //        return false;

        //    // Use IdnMapping class to convert Unicode domain names.
        //    strIn = System.Text.RegularExpressions.Regex.Replace(strIn, @"(@)(.+)$", DomainMapper);
        //    if (invalid)
        //        return false;

        //    // Return true if strIn is in valid e-mail format.
        //    return System.Text.RegularExpressions.Regex.IsMatch(strIn,
        //           @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        //        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
        //           System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        //}

        //private static string DomainMapper(Match match)
        //{
        //    // IdnMapping class with default property values.
        //    IdnMapping idn = new IdnMapping();

        //    string domainName = match.Groups[2].Value;
        //    try
        //    {
        //        domainName = idn.GetAscii(domainName);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        Console.WriteLine("Error occured:" + ex.Message);
        //    }
        //    catch (Exception ex2)
        //    {
        //        Console.WriteLine("Error occured:" + ex2.Message);
        //    }
        //    return match.Groups[1].Value + domainName;
        //}
        public static void OnlyDigit(KeyPressEventArgs argu)
        {
            if (!(Char.IsNumber(argu.KeyChar) || Char.IsControl(argu.KeyChar)))
                argu.Handled = true;
        }
        public static void OnlyQuantity(Object sender, KeyPressEventArgs argu)
        {
            if (!Char.IsDigit(argu.KeyChar) &&
              argu.KeyChar != (char)Keys.Back &&
              argu.KeyChar != '.')
            {
                argu.Handled = true;
            }
            else
            {
                if (argu.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.Contains('.'))
                        argu.Handled = true;
                    else
                        argu.Handled = false;
                }
            }
        }
        public static void OnlyTextDigitDash(KeyPressEventArgs argu)
        {

            if (!char.IsLetter(argu.KeyChar) && !char.IsControl(argu.KeyChar) &&
                !char.IsWhiteSpace(argu.KeyChar) && !(Char.IsNumber(argu.KeyChar)) &&
                (argu.KeyChar != '-'))
                argu.Handled = true;
        }
    }
}
